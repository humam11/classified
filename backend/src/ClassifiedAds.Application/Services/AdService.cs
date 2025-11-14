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

    public AdService(IMongoDatabase database)
    {
        _adsCollection = database.GetCollection<Ad>("ads");
    }

    public async Task<string> CreateAdAsync<TDto>(TDto dto, string categorySlug, string locationSlug) where TDto : CreateAdDto
    {
        // Generate slug first
        var slug = GenerateSlug(dto.Title);

        // Check if this is a general ad (CreateAdDto) or category-specific ad
        Ad ad;
        
        if (dto.GetType() == typeof(CreateAdDto))
        {
            // General ad - use AdDtoMapper
            ad = AdDtoMapper.MapToEntity(dto, slug);
        }
        else
        {
            // Category-specific ad - use AdDtoMapper for base properties
            // TODO: Add category-specific mappers later
            ad = AdDtoMapper.MapToEntity(dto, slug);
            
            // For now, we'll store the entire DTO as additional attributes
            // This will be replaced with proper category-specific mappers
        }

        // Insert into MongoDB
        await _adsCollection.InsertOneAsync(ad);

        return ad.Id!;
    }

    public async Task<TDto?> GetAdByIdAsync<TDto>(string id) where TDto : class
    {
        var ad = await _adsCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
        if (ad == null) return null;
        
        // Map entity to DTO
        if (typeof(TDto) == typeof(CreateAdDto))
        {
            // General ad - use AdDtoMapper
            var dto = AdDtoMapper.MapToDto(ad);
            return dto as TDto;
        }
        else
        {
            // Category-specific ad - use AdDtoMapper for base properties
            // TODO: Add category-specific mappers later
            var dto = AdDtoMapper.MapToDto(ad);
            return dto as TDto;
        }
    }


    public async Task<bool> DeleteAdAsync(string id)
    {
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
