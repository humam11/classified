using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.Interfaces;
using ClassifiedAds.Application.Mappers;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;
using MongoDB.Driver;
using System.Text.RegularExpressions;

namespace ClassifiedAds.Application.Services;

public class AdService : IAdService
{
    private readonly IMongoCollection<Ad> _adsCollection;
    private readonly ILocationService _locationService;
    private readonly ICategoryService _categoryService;
    private readonly IImageService _imageService;

    public AdService(IMongoDatabase database, ILocationService locationService, ICategoryService categoryService, IImageService imageService)
    {
        _adsCollection = database.GetCollection<Ad>("ads");
        _locationService = locationService;
        _categoryService = categoryService;
        _imageService = imageService;
    }

    public async Task<string> CreateAdAsync<TDto>(TDto dto, string categorySlug, string locationSlug) where TDto : CreateAdDto
    {
        // Generate slug first
        var slug = GenerateSlug(dto.Title);

        // TODO: Get userId from authentication context (JWT token)
        var userId = Guid.Empty;

        // Get language from LanguageContext (set by LanguageMiddleware)
        var language = LanguageContext.Current ?? "ar";

        // Resolve category from PostgreSQL
        var (categoryIds, categoryJoins) =
            await _categoryService.ResolveCategoryAsync(categorySlug, language);

        // Resolve location from PostgreSQL (convert flat fields to LocationAdDto)
        var locationDto = new DTOs.Common.LocationAdDto
        {
            City = dto.City,
            Region = dto.Region,
            Neighborhood = dto.Neighborhood,
            Street = dto.Street
        };
        var (locationIds, fullAddressArabic, fullAddressKurdish) =
            await _locationService.ResolveLocationAsync(locationDto, language);

        // Use AdDtoMapper to create entity
        var ad = AdDtoMapper.MapToEntity(dto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);

        // Insert into MongoDB
        await _adsCollection.InsertOneAsync(ad);

        return ad.Id!;
    }

    public async Task<TDto?> GetAdByIdAsync<TDto>(string id) where TDto : class
    {
        var ad = await _adsCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
        if (ad == null) return null;
        
        // Map entity to DTO
        var dto = AdDtoMapper.MapToDto(ad);
        return dto as TDto;
    }


    public async Task<string> CreateAdWithImagesAsync<TDto>(TDto dto, string categorySlug, List<ImageUpload> images) where TDto : CreateAdDto
    {
        // Generate slug first
        var slug = GenerateSlug(dto.Title);

        // TODO: Get userId from authentication context (JWT token)
        var userId = Guid.Empty;

        // Get language from LanguageContext (set by LanguageMiddleware)
        var language = LanguageContext.Current ?? "ar";

        // Resolve category from PostgreSQL
        var (categoryIds, categoryJoins) =
            await _categoryService.ResolveCategoryAsync(categorySlug, language);

        // Resolve location from PostgreSQL (convert flat fields to LocationAdDto)
        var locationDto = new DTOs.Common.LocationAdDto
        {
            City = dto.City,
            Region = dto.Region,
            Neighborhood = dto.Neighborhood,
            Street = dto.Street
        };
        var (locationIds, fullAddressArabic, fullAddressKurdish) =
            await _locationService.ResolveLocationAsync(locationDto, language);

        // Create ad entity (without images initially)
        var ad = AdDtoMapper.MapToEntity(dto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);

        // Insert into MongoDB to get the ID
        await _adsCollection.InsertOneAsync(ad);

        // Process and save images
        var processedImages = await _imageService.ProcessAndSaveImagesAsync(images, ad.Id!);

        // Update ad with processed images
        ad.Images = processedImages.Select(img => new AdImage
        {
            ImageUrl = img.ImageUrl,
            Order = img.Order
        }).ToList();

        ad.ImageCount = (byte)ad.Images.Count;
        ad.UpdatedAt = DateTime.UtcNow;

        // Update the ad in MongoDB with images
        await _adsCollection.ReplaceOneAsync(a => a.Id == ad.Id, ad);

        return ad.Id!;
    }

    public async Task<bool> DeleteAdAsync(string id)
    {
        // Delete associated images first
        await _imageService.DeleteAdImagesAsync(id);
        
        // Delete ad from MongoDB
        var result = await _adsCollection.DeleteOneAsync(a => a.Id == id);
        return result.DeletedCount > 0;
    }

    private string GenerateSlug(string title)
    {
        // Simple slug generation - remove special characters and replace spaces with hyphens
        var slug = title.ToLowerInvariant();
        slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");
        slug = Regex.Replace(slug, @"\s+", "-");
        slug = Regex.Replace(slug, @"-+", "-");
        slug = slug.Trim('-');
        
        // Add random suffix to ensure uniqueness
        slug += "-" + Guid.NewGuid().ToString("N").Substring(0, 8);
        
        return slug;
    }
}
