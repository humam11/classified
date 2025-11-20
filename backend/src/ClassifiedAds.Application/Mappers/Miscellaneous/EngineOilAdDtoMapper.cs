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

    public static GetEngineOilAdDto MapToDto(EngineOil entity)
    {
        return new GetEngineOilAdDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            Price = new DTOs.Common.PriceResponseDto { Value = entity.Price.Value, IsDollar = entity.Price.IsDollar, ShowingPrice = entity.Price.ShowingPrice },
            LocationAd = new DTOs.Common.LocationAdResponseDto { LocationIds = entity.LocationAd.LocationIds, FullAddressArabic = entity.LocationAd.FullAddressArabic, FullAddressKurdish = entity.LocationAd.FullAddressKurdish, Street = entity.LocationAd.Street },
            Images = entity.Images.Select(img => new DTOs.Common.AdImageDto { ImageId = img.ImageId, ImageUrl = img.ImageUrl, Order = img.Order }).ToList(),
            Status = (int)entity.Status,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            ImageCount = entity.ImageCount,
            ViewsCount = entity.ViewsCount,
            Priority = entity.Priority,
            Slug = entity.Slug,
            Category = new DTOs.Common.CategoryResponseDto { CategoryJoins = entity.Category.CategoryJoins, CategoryIds = entity.Category.CategoryIds },
            Specs = new EngineOilSpecsDto
            {
                Volume = entity.Volume,
                OilType = entity.OilType,
                Viscosity = entity.Viscosity
            }
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
