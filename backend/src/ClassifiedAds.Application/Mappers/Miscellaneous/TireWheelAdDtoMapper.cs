using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Miscellaneous;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers;

public static class TireWheelAdDtoMapper
{
    public static TireWheel MapToEntity(
        CreateTireWheelAdDto dto,
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

        return new TireWheel
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
            Width = dto.Width,
            AspectRatio = dto.AspectRatio,
            RimDiameter = dto.RimDiameter
        };
    }

    public static CreateTireWheelAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateTireWheelAdDto
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
            Width = form.TryGetValue("Width", out var width) &&
                   !string.IsNullOrWhiteSpace(width) &&
                   ushort.TryParse(width, out var w) ? w : null,
            AspectRatio = form.TryGetValue("AspectRatio", out var aspectRatio) &&
                         !string.IsNullOrWhiteSpace(aspectRatio) &&
                         byte.TryParse(aspectRatio, out var ar) ? ar : null,
            RimDiameter = form.TryGetValue("RimDiameter", out var rimDiameter) &&
                         !string.IsNullOrWhiteSpace(rimDiameter) &&
                         byte.TryParse(rimDiameter, out var rd) ? rd : null
        };
    }

    public static TireWheelAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new TireWheelAdDto
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
            Width = form.TryGetValue("Width", out var width) &&
                   !string.IsNullOrWhiteSpace(width) &&
                   ushort.TryParse(width, out var w) ? w : null,
            AspectRatio = form.TryGetValue("AspectRatio", out var aspectRatio) &&
                         !string.IsNullOrWhiteSpace(aspectRatio) &&
                         byte.TryParse(aspectRatio, out var ar) ? ar : null,
            RimDiameter = form.TryGetValue("RimDiameter", out var rimDiameter) &&
                         !string.IsNullOrWhiteSpace(rimDiameter) &&
                         byte.TryParse(rimDiameter, out var rd) ? rd : null
        };
    }

    public static void UpdateAttributes(Ad ad, TireWheelAdDto dto)
    {
        if (ad is TireWheel tire)
        {
            if (dto.Width.HasValue)
                tire.Width = dto.Width;
            if (dto.AspectRatio.HasValue)
                tire.AspectRatio = dto.AspectRatio;
            if (dto.RimDiameter.HasValue)
                tire.RimDiameter = dto.RimDiameter;
        }
    }
}
