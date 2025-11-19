using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Miscellaneous;
using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers;

public static class EngineOilAdDtoMapper
{
    public static EngineOil MapToEntity(
        CreateEngineOilAdDto dto,
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

        return new EngineOil
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
            OilType = dto.OilType,
            Viscosity = dto.Viscosity,
            Volume = dto.Volume
        };
    }

    public static CreateEngineOilAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateEngineOilAdDto
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
            OilType = form.TryGetValue("OilType", out var oilType) &&
                     !string.IsNullOrWhiteSpace(oilType) &&
                     Enum.TryParse<OilType>(oilType, out var ot) ? ot : null,
            Viscosity = form.TryGetValue("Viscosity", out var viscosity) &&
                       !string.IsNullOrWhiteSpace(viscosity) &&
                       Enum.TryParse<Viscosity>(viscosity, out var v) ? v : null,
            Volume = form.TryGetValue("Volume", out var volume) &&
                    !string.IsNullOrWhiteSpace(volume) &&
                    ushort.TryParse(volume, out var vol) ? vol : null
        };
    }

    public static EngineOilAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new EngineOilAdDto
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
            OilType = form.TryGetValue("OilType", out var oilType) &&
                     !string.IsNullOrWhiteSpace(oilType) &&
                     Enum.TryParse<OilType>(oilType, out var ot) ? ot : null,
            Viscosity = form.TryGetValue("Viscosity", out var viscosity) &&
                       !string.IsNullOrWhiteSpace(viscosity) &&
                       Enum.TryParse<Viscosity>(viscosity, out var v) ? v : null,
            Volume = form.TryGetValue("Volume", out var volume) &&
                    !string.IsNullOrWhiteSpace(volume) &&
                    ushort.TryParse(volume, out var vol) ? vol : null
        };
    }

    public static void UpdateAttributes(Ad ad, EngineOilAdDto dto)
    {
        if (ad is EngineOil oil)
        {
            if (dto.OilType.HasValue)
                oil.OilType = dto.OilType;
            if (dto.Viscosity.HasValue)
                oil.Viscosity = dto.Viscosity;
            if (dto.Volume.HasValue)
                oil.Volume = dto.Volume;
        }
    }
}
