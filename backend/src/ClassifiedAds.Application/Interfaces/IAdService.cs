using ClassifiedAds.Application.DTOs.Ads;

namespace ClassifiedAds.Application.Interfaces;

public interface IAdService
{
    Task<string> CreateAdAsync<TDto>(TDto dto, string categorySlug, List<ImageUpload> images) where TDto : AdDto;
    Task<object?> GetAdByIdAsync(string id);
    Task<bool> UpdateAdAsync(string id, AdDto dto, Microsoft.AspNetCore.Http.IFormCollection form);
    Task<bool> DeleteAdAsync(string id);
}
