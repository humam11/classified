using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.RealEstate;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.RealEstate;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers;

public static class RealEstateAdDtoMapper
{
    public static RealEstate MapToEntity(
        CreateRealEstateAdDto dto,
        string slug,
        Guid userId,
        List<ushort> categoryIds,
        byte categoryJoins,
        List<ushort> locationIds,
        string fullAddressArabic,
        string fullAddressKurdish)
    {
        if (string.IsNullOrEmpty(dto.Title) || !dto.IsDollar.HasValue || !dto.PriceValue.HasValue)
        {
            throw new ArgumentException("Required fields are missing");
        }

        string showingPrice = AdDtoMapper.FormatShowingPrice(dto.IsDollar.Value, dto.PriceValue.Value);

        return new RealEstate
        {
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
            Images = new List<AdImage>(),
            Status = Status.Active,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            ImageCount = 0,
            ViewsCount = 0,
            UserId = userId,
            Priority = 0,
            Slug = slug,
            Area = dto.Area
        };
    }

    public static CreateRealEstateAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateRealEstateAdDto
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
            Area = form.TryGetValue("Area", out var area) &&
                  !string.IsNullOrWhiteSpace(area) &&
                  float.TryParse(area, out var a) ? a : null
        };
    }

    public static RealEstateAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new RealEstateAdDto
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
            Area = form.TryGetValue("Area", out var area) &&
                  !string.IsNullOrWhiteSpace(area) &&
                  float.TryParse(area, out var a) ? a : null
        };
    }

    public static void UpdateAttributes(Ad ad, RealEstateAdDto dto)
    {
        if (ad is RealEstate realEstate)
        {
            if (dto.Area.HasValue)
                realEstate.Area = dto.Area;
        }
    }
}
