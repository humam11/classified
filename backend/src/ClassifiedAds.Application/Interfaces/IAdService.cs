using ClassifiedAds.Application.DTOs.Ads;

namespace ClassifiedAds.Application.Interfaces;

public interface IAdService
{
    Task<string> CreateAdAsync<TDto>(TDto dto, string categorySlug, List<ImageUpload> images) where TDto : CreateAdDto;
    Task<TDto?> GetAdByIdAsync<TDto>(string id) where TDto : class;
    Task<bool> UpdateAdAsync(string id, AdDto dto);
    Task<bool> DeleteAdAsync(string id);
}
