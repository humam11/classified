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
    /// <param name="dto">The DTO containing user-provided data (flat fields)</param>
    /// <param name="slug">Generated slug for the ad</param>
    /// <param name="userId">Authenticated user's ID (from JWT token or auth context)</param>
    /// <param name="categoryIds">Resolved category IDs from PostgreSQL</param>
    /// <param name="categoryJoins">Number of category levels</param>
    /// <param name="locationIds">Resolved location IDs from PostgreSQL</param>
    /// <param name="fullAddressArabic">Full address in Arabic</param>
    /// <param name="fullAddressKurdish">Full address in Kurdish</param>
    public static Ad MapToEntity(
        CreateAdDto dto,
        string slug,
        Guid userId,
        List<ushort> categoryIds,
        byte categoryJoins,
        List<ushort> locationIds,
        string fullAddressArabic,
        string fullAddressKurdish)
    {
        // Format showing price based on user's choice
        string showingPrice = FormatShowingPrice(dto.PriceValue, dto.PriceIsDollar);

        return new Ad
        {
            // User-provided fields
            Title = dto.Title,
            Description = dto.Description,
            Price = new Price
            {
                Value = dto.PriceValue,
                IsDollar = dto.PriceIsDollar,
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

    /// <summary>
    /// Maps an Ad entity to CreateAdDto (for GET operations)
    /// </summary>
    public static CreateAdDto MapToDto(Ad entity)
    {
        return new CreateAdDto
        {
            Title = entity.Title,
            Description = entity.Description,
            PriceValue = entity.Price.Value,
            PriceIsDollar = entity.Price.IsDollar,
            City = string.Empty, // TODO: Extract from FullAddressArabic/Kurdish
            Region = string.Empty,
            Neighborhood = string.Empty,
            Street = entity.LocationAd.Street
        };
    }

    /// <summary>
    /// Formats the showing price based on value and currency
    /// </summary>
    private static string FormatShowingPrice(decimal value, bool isDollar)
    {
        string currency = isDollar ? "USD" : "IQD";
        return $"{value:N0} {currency}";
    }
}
