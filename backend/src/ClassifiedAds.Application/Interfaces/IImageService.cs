namespace ClassifiedAds.Application.Interfaces;

/// <summary>
/// Service for handling image processing and storage
/// </summary>
public interface IImageService
{
    /// <summary>
    /// Process uploaded images: convert to WebP, optimize, and save to local storage
    /// </summary>
    /// <param name="imageStreams">List of image streams with metadata</param>
    /// <param name="adId">Ad ID for organizing storage</param>
    /// <returns>List of processed image information with URLs and order</returns>
    Task<List<ProcessedImageInfo>> ProcessAndSaveImagesAsync(List<ImageUpload> imageStreams, string adId);

    /// <summary>
    /// Delete images associated with an ad
    /// </summary>
    /// <param name="adId">Ad ID</param>
    Task DeleteAdImagesAsync(string adId);
}

/// <summary>
/// Represents an uploaded image with its stream and metadata
/// </summary>
public class ImageUpload
{
    public Stream Stream { get; set; } = null!;
    public string FileName { get; set; } = string.Empty;
    public long Length { get; set; }
}

/// <summary>
/// Information about a processed image
/// </summary>
public class ProcessedImageInfo
{
    public string ImageUrl { get; set; } = string.Empty;
    public byte Order { get; set; }
}
