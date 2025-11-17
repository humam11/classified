using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers;


public static class AdDtoMapper
{
    // Maps a CreateAdDto to an Ad entity
    public static Ad MapToEntity(
        AdDto dto,
        string slug,
        Guid userId,
        List<ushort> categoryIds,
        byte categoryJoins,
        List<ushort> locationIds,
        string fullAddressArabic,
        string fullAddressKurdish)
    {
        // Ensure required values are present (validation should have caught this)
        if (string.IsNullOrEmpty(dto.Title) || !dto.IsDollar.HasValue || !dto.PriceValue.HasValue)
        {
            throw new ArgumentException("Required fields are missing");
        }

        // Format showing price based on user's choice
        string showingPrice = FormatShowingPrice(dto.IsDollar.Value, dto.PriceValue.Value);

        return new Ad
        {
            // User-provided fields
            Title = dto.Title,
            Description = dto.Description ?? string.Empty,
            Price = new Price
            {
                IsDollar = dto.IsDollar.Value,
                Value = dto.PriceValue.Value,
                ShowingPrice = showingPrice
            },
            Category = new Category
            {
                CategoryJoins = categoryJoins,
                CategoryIds = categoryIds
            },
            LocationAd = new LocationAd
            {
                LocationIds = locationIds,
                Street = dto.Street,
                FullAddressArabic = fullAddressArabic,
                FullAddressKurdish = fullAddressKurdish
            },
            Images = new List<AdImage>(), // Images will be added after processing uploads

            // System-generated fields
            Status = Status.Active,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            ImageCount = 0, // Will be updated after image processing
            ViewsCount = 0,
            UserId = userId,
            Priority = 0,
            Slug = slug
        };
    }

    // Maps an Ad entity to AdDto (for GET operations)
    public static AdDto MapToDto(Ad entity)
    {
        return new AdDto
        {
            Title = entity.Title,
            Description = entity.Description,
            IsDollar = entity.Price.IsDollar,
            PriceValue = entity.Price.Value,
            City = string.Empty, // TODO: Extract from FullAddressArabic/Kurdish
            Region = string.Empty,
            Neighborhood = string.Empty,
            Street = entity.LocationAd.Street
        };
    }

    // Formats the showing price based on currency and value
    public static string FormatShowingPrice(bool isDollar, decimal value)
    {
        string currency = isDollar ? "USD" : "IQD";
        return $"{value:N0} {currency}";
    }
}
