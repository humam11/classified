using ClassifiedAds.Application.DTOs.Ads;

namespace ClassifiedAds.Application.Interfaces;

public interface IAdService
{
    Task<string> CreateAdAsync<TDto>(TDto dto, string categorySlug, List<ImageUpload> images) where TDto : AdDto;
    Task<object?> GetAdByIdAsync(string id);
    Task<object?> GetAdBySlugAsync(string slug);
    Task<bool> UpdateAdAsync(string id, AdDto dto, Microsoft.AspNetCore.Http.IFormCollection form);
    Task<bool> DeleteAdAsync(string id);
    
    // Search/Listing methods
    Task<List<object>> SearchAdsByCategoryAsync(string categorySlug, string language);
    Task<List<object>> SearchAdsByBrandModelAsync(string categorySlug, string brandModelSlug, string language);
    Task<List<object>> SearchAdsByReleaseYearAsync(string categorySlug, string brandModelSlug, string releaseYear, string language);
    
    // Canonical URL helper
    CanonicalUrlInfo GetCanonicalUrlInfo(object adDto, string language);
}

// Information needed to construct the canonical URL for an ad
public class CanonicalUrlInfo
{
    public required string AdSlug { get; set; }
    public required string CategorySlug { get; set; }
    public string? BrandModelSlug { get; set; }
    public string? ReleaseYear { get; set; }
    public CanonicalUrlLevel Level { get; set; }
}

public enum CanonicalUrlLevel
{
    CategoryOnly,      // Most ads: real estate, jobs, services, etc.
    BrandModel,        // Truck, Motorcycle, VideoGame, HandheldDevice, Laptop, TvMonitor, Console
    ReleaseYear        // Cars only
}
