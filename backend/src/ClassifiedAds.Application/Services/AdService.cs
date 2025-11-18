using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.Interfaces;
using ClassifiedAds.Application.Mappers;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Miscellaneous;
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


    public async Task<TDto?> GetAdByIdAsync<TDto>(string id) where TDto : class
    {
        var ad = await _adsCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
        if (ad == null) return null;
        
        // Map entity to DTO
        var dto = AdDtoMapper.MapToDto(ad);
        return dto as TDto;
    }


    public async Task<string> CreateAdAsync<TDto>(TDto dto, string categorySlug, List<ImageUpload> images) where TDto : AdDto
    {
        var slug = GenerateSlug(dto.Title);
        var userId = Guid.Empty; // TODO: Get from JWT token
        var language = LanguageContext.Current ?? "ar";

        // Resolve category from PostgreSQL
        var (categoryIds, categoryJoins) = await _categoryService.ResolveCategoryAsync(categorySlug, language);

        // Resolve location from PostgreSQL
        var locationDto = new DTOs.Common.LocationAdDto
        {
            City = dto.City,
            Region = dto.Region,
            Neighborhood = dto.Neighborhood,
            Street = dto.Street
        };
        var (locationIds, fullAddressArabic, fullAddressKurdish) =
            await _locationService.ResolveLocationAsync(locationDto, language);

        // Map DTO to entity using appropriate mapper based on DTO type
        Ad ad;
        if (dto is DTOs.Ads.Miscellaneous.CreateBookAdDto bookDto)
        {
            ad = Mappers.BookAdDtoMapper.MapToEntity(bookDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else
        {
            ad = Mappers.AdDtoMapper.MapToEntity(dto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }

        // Insert into MongoDB
        await _adsCollection.InsertOneAsync(ad);

        // Process and save images
        var processedImages = await _imageService.ProcessAndSaveImagesAsync(images, ad.Id!);

        ad.Images = processedImages.Select(img => new AdImage
        {
            ImageUrl = img.ImageUrl,
            Order = img.Order
        }).ToList();

        ad.ImageCount = (byte)ad.Images.Count;
        ad.UpdatedAt = DateTime.UtcNow;

        await _adsCollection.ReplaceOneAsync(a => a.Id == ad.Id, ad);

        return ad.Id!;
    }

    public async Task<bool> UpdateAdAsync(string id, AdDto dto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        var existingAd = await _adsCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
        if (existingAd == null) return false;

        var language = LanguageContext.Current ?? "ar";
        
        // Map form data to appropriate DTO type based on existing ad type
        var mappedDto = MapUpdateDtoByAdType(dto, existingAd, form);

        // Update title if provided
        if (!string.IsNullOrEmpty(mappedDto.Title))
        {
            existingAd.Title = mappedDto.Title;
            existingAd.Slug = GenerateSlug(mappedDto.Title);
        }

        // Update description if provided
        if (mappedDto.Description != null)
        {
            existingAd.Description = mappedDto.Description;
        }

        // Update price if provided (validator ensures PriceValue is provided when IsDollar changes)
        if (mappedDto.IsDollar.HasValue || mappedDto.PriceValue.HasValue)
        {
            // Update currency type first
            if (mappedDto.IsDollar.HasValue)
            {
                existingAd.Price.IsDollar = mappedDto.IsDollar.Value;
            }
            
            // Then update value
            if (mappedDto.PriceValue.HasValue)
            {
                existingAd.Price.Value = mappedDto.PriceValue.Value;
            }

            // Recalculate ShowingPrice after price update
            existingAd.Price.ShowingPrice = AdDtoMapper.FormatShowingPrice(
                existingAd.Price.IsDollar,
                existingAd.Price.Value);
        }

        // Update location if any location field is provided
        if (!string.IsNullOrEmpty(mappedDto.City) || !string.IsNullOrEmpty(mappedDto.Region) || 
            !string.IsNullOrEmpty(mappedDto.Neighborhood) || !string.IsNullOrEmpty(mappedDto.Street))
        {
            // Extract existing location parts
            var existingAddressParts = existingAd.LocationAd.FullAddressArabic.Split('،');
            var existingCity = existingAddressParts.Length > 0 ? existingAddressParts[0].Trim() : null;
            var existingRegion = existingAddressParts.Length > 1 ? existingAddressParts[1].Trim() : null;
            var existingNeighborhood = existingAddressParts.Length > 2 ? existingAddressParts[2].Trim() : null;

            // Determine final location values
            // If user provides a location field, use ONLY what they provide (auto-clear children)
            string? finalCity;
            string? finalRegion;
            string? finalNeighborhood;
            string? finalStreet;

            // If City is provided (whether same or different), use only provided values
            if (!string.IsNullOrEmpty(mappedDto.City))
            {
                finalCity = mappedDto.City;
                finalRegion = mappedDto.Region; // null if not provided
                finalNeighborhood = mappedDto.Neighborhood; // null if not provided
                finalStreet = mappedDto.Street; // null if not provided
            }
            // If Region is provided (and City is not), use existing City + provided Region
            else if (!string.IsNullOrEmpty(mappedDto.Region))
            {
                finalCity = existingCity;
                finalRegion = mappedDto.Region;
                finalNeighborhood = mappedDto.Neighborhood; // null if not provided
                finalStreet = mappedDto.Street; // null if not provided
            }
            // If Neighborhood is provided (and City/Region are not), use existing City/Region + provided Neighborhood
            else if (!string.IsNullOrEmpty(mappedDto.Neighborhood))
            {
                finalCity = existingCity;
                finalRegion = existingRegion;
                finalNeighborhood = mappedDto.Neighborhood;
                finalStreet = mappedDto.Street; // null if not provided
            }
            // If only Street is provided, keep all existing location data
            else
            {
                finalCity = existingCity;
                finalRegion = existingRegion;
                finalNeighborhood = existingNeighborhood;
                finalStreet = mappedDto.Street ?? existingAd.LocationAd.Street;
            }

            // Build location DTO
            var locationDto = new DTOs.Common.LocationAdDto
            {
                City = finalCity,
                Region = finalRegion,
                Neighborhood = finalNeighborhood,
                Street = finalStreet
            };

            // Resolve new location from PostgreSQL
            var (locationIds, fullAddressArabic, fullAddressKurdish) =
                await _locationService.ResolveLocationAsync(locationDto, language);

            // Create new LocationAd object (same as CreateAdAsync)
            existingAd.LocationAd = new LocationAd
            {
                LocationIds = locationIds,
                FullAddressArabic = fullAddressArabic,
                FullAddressKurdish = fullAddressKurdish,
                Street = locationDto.Street
            };
        }

        // Update category-specific attributes
        if (mappedDto is DTOs.Ads.Miscellaneous.BookAdDto bookDto)
        {
            Mappers.BookAdDtoMapper.UpdateAttributes(existingAd, bookDto);
        }

        // Update images if provided
        if (mappedDto.ImageFiles != null && mappedDto.ImageFiles.Count > 0)
        {
            await _imageService.DeleteAdImagesAsync(id);

            var imageUploads = dto.ImageFiles.Select(img => new ImageUpload
            {
                Stream = img.OpenReadStream(),
                FileName = img.FileName,
                Length = img.Length
            }).ToList();

            var processedImages = await _imageService.ProcessAndSaveImagesAsync(imageUploads, id);

            existingAd.Images = processedImages.Select(img => new AdImage
            {
                ImageUrl = img.ImageUrl,
                Order = img.Order
            }).ToList();

            existingAd.ImageCount = (byte)existingAd.Images.Count;
        }

        existingAd.UpdatedAt = DateTime.UtcNow;
        await _adsCollection.ReplaceOneAsync(a => a.Id == id, existingAd);
        return true;
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

    private AdDto MapUpdateDtoByAdType(AdDto baseDto, Ad existingAd, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        // Check the actual type of the existing ad
        if (existingAd is Book)
        {
            // Parse book-specific fields from form
            Domain.Entities.Ads.Miscellaneous.Enums.BookLanguage? bookLanguage = null;
            if (form.TryGetValue("BookLanguage", out var bookLangValue) && 
                !string.IsNullOrWhiteSpace(bookLangValue) &&
                Enum.TryParse<Domain.Entities.Ads.Miscellaneous.Enums.BookLanguage>(bookLangValue, out var parsedLang))
            {
                bookLanguage = parsedLang;
            }

            ushort? pages = null;
            if (form.TryGetValue("Pages", out var pagesValue) && 
                !string.IsNullOrWhiteSpace(pagesValue) &&
                ushort.TryParse(pagesValue, out var parsedPages))
            {
                pages = parsedPages;
            }

            return new DTOs.Ads.Miscellaneous.BookAdDto
            {
                Title = baseDto.Title,
                Description = baseDto.Description,
                IsDollar = baseDto.IsDollar,
                PriceValue = baseDto.PriceValue,
                City = baseDto.City,
                Region = baseDto.Region,
                Neighborhood = baseDto.Neighborhood,
                Street = baseDto.Street,
                ImageFiles = baseDto.ImageFiles,
                BookLanguage = bookLanguage,
                Pages = pages
            };
        }

        // Default to base AdDto for general ads
        return baseDto;
    }
}
