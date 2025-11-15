using ClassifiedAds.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;

namespace ClassifiedAds.Infrastructure.Services;

public class ImageService : IImageService
{
    private readonly string _storagePath;
    private readonly string _baseUrl;
    private readonly ILogger<ImageService> _logger;
    private const int MaxWidth = 1600;  // Reduced for smaller file sizes
    private const int MaxHeight = 900;  // Reduced for smaller file sizes

    public ImageService(IConfiguration configuration, ILogger<ImageService> logger)
    {
        _storagePath = configuration["ImageStorage:Path"] ?? "wwwroot/images/ads";
        _baseUrl = configuration["ImageStorage:BaseUrl"] ?? "/images/ads";
        _logger = logger;

        // Ensure storage directory exists
        if (!Directory.Exists(_storagePath))
        {
            Directory.CreateDirectory(_storagePath);
        }
    }

    public async Task<List<ProcessedImageInfo>> ProcessAndSaveImagesAsync(List<ImageUpload> images, string adId)
    {
        var processedImages = new List<ProcessedImageInfo>();
        
        // Create ad-specific directory
        var adDirectory = Path.Combine(_storagePath, adId);
        if (!Directory.Exists(adDirectory))
        {
            Directory.CreateDirectory(adDirectory);
        }

        byte order = 1;
        foreach (var imageUpload in images)
        {
            try
            {
                // Generate unique filename
                var fileName = $"{Guid.NewGuid()}.webp";
                var filePath = Path.Combine(adDirectory, fileName);

                // Process and save image
                using var image = await Image.LoadAsync(imageUpload.Stream);

                var originalWidth = image.Width;
                var originalHeight = image.Height;

                // Resize if needed (maintain aspect ratio)
                if (image.Width > MaxWidth || image.Height > MaxHeight)
                {
                    image.Mutate(x => x.Resize(new ResizeOptions
                    {
                        Size = new Size(MaxWidth, MaxHeight),
                        Mode = ResizeMode.Max,
                        Sampler = KnownResamplers.Lanczos3 // High quality resampling
                    }));
                }

                // Save as WebP with aggressive compression
                var encoder = new WebpEncoder
                {
                    Quality = 75, // Reduced from 85 for smaller file size (still good quality)
                    FileFormat = WebpFileFormatType.Lossy,
                    Method = WebpEncodingMethod.BestQuality,
                    NearLossless = false // Use full lossy compression for smaller files
                };

                await image.SaveAsync(filePath, encoder);

                // Get file size after compression
                var fileInfo = new FileInfo(filePath);
                var finalSizeKb = fileInfo.Length / 1024;

                // Generate URL
                var imageUrl = $"{_baseUrl}/{adId}/{fileName}";

                processedImages.Add(new ProcessedImageInfo
                {
                    ImageUrl = imageUrl,
                    Order = order++
                });

                _logger.LogInformation(
                    "Processed image for ad {AdId}: {FileName}, Original: {OriginalSize}KB ({OriginalWidth}x{OriginalHeight}), Final: {FinalSize}KB ({Width}x{Height}), Compression: {CompressionRatio}%",
                    adId, fileName, imageUpload.Length / 1024, originalWidth, originalHeight, 
                    finalSizeKb, image.Width, image.Height, 
                    Math.Round((1 - (double)finalSizeKb / (imageUpload.Length / 1024)) * 100, 1));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing image {FileName} for ad {AdId}", imageUpload.FileName, adId);
                throw new InvalidOperationException($"Failed to process image '{imageUpload.FileName}': {ex.Message}", ex);
            }
        }

        return processedImages;
    }

    public async Task DeleteAdImagesAsync(string adId)
    {
        try
        {
            var adDirectory = Path.Combine(_storagePath, adId);
            if (Directory.Exists(adDirectory))
            {
                Directory.Delete(adDirectory, recursive: true);
                _logger.LogInformation("Deleted images for ad {AdId}", adId);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting images for ad {AdId}", adId);
            // Don't throw - image deletion failure shouldn't prevent ad deletion
        }

        await Task.CompletedTask;
    }
}
