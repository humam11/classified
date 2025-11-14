using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers;

/// <summary>
/// Maps CreateAdDto to Ad entity (general ad without category-specific attributes)
/// </summary>
public static class AdDtoMapper
{
    /// <summary>
    /// Maps a CreateAdDto to an Ad entity
    /// </summary>
    public static Ad MapToEntity(CreateAdDto dto, string slug)
    {
        return new Ad
        {
            Title = dto.Title,
            Description = dto.Description,
            Price = new Price
            {
                Value = dto.Price.Value,
                IsDollar = dto.Price.IsDollar,
                ShowingPrice = dto.Price.ShowingPrice
            },
            Category = new Category
            {
                CategoryJoins = dto.Category.CategoryJoins,
                CategoryIds = dto.Category.CategoryIds
            },
            LocationAd = new LocationAd
            {
                LocationIds = dto.LocationAd.LocationIds,
                Street = dto.LocationAd.Street,
                FullAddressArabic = string.Empty, // Will be populated from location service
                FullAddressKurdish = string.Empty  // Will be populated from location service
            },
            Images = dto.Images?.Select(img => new AdImage
            {
                ImageUrl = img.ImageUrl,
                Order = img.Order,
                ImageId = img.ImageId
            }).ToList() ?? new List<AdImage>(),
            Status = Status.Active,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            ImageCount = (byte)(dto.Images?.Count ?? 0),
            ViewsCount = 0,
            UserId = Guid.Empty, // TODO: Get from authentication context
            Priority = 0,
            Slug = slug
        };
    }

    /// <summary>
    /// Maps an Ad entity to CreateAdDto
    /// </summary>
    public static CreateAdDto MapToDto(Ad entity)
    {
        return new CreateAdDto
        {
            Title = entity.Title,
            Description = entity.Description,
            Price = new DTOs.Common.PriceDto
            {
                Value = entity.Price.Value,
                IsDollar = entity.Price.IsDollar,
                ShowingPrice = entity.Price.ShowingPrice
            },
            Category = new DTOs.Common.CategoryDto
            {
                CategoryJoins = entity.Category.CategoryJoins,
                CategoryIds = entity.Category.CategoryIds
            },
            LocationAd = new DTOs.Common.LocationAdDto
            {
                LocationIds = entity.LocationAd.LocationIds,
                Street = entity.LocationAd.Street
            },
            Images = entity.Images?.Select(img => new DTOs.Common.AdImageDto
            {
                ImageUrl = img.ImageUrl,
                Order = img.Order,
                ImageId = img.ImageId
            }).ToList() ?? new List<DTOs.Common.AdImageDto>()
        };
    }
}
