using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Vehicles.HeavyEquipment;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;
using FuelType = ClassifiedAds.Domain.Entities.Ads.Vehicles.Enums.FuelType;
using static ClassifiedAds.Application.Common.FormParsingHelpers;


namespace ClassifiedAds.Application.Mappers.Vehicles.HeavyEquipment;

public static class CraneAdDtoMapper
{
    public static Crane MapToEntity(CreateCraneAdDto dto, string slug, Guid userId, List<string> categoriesSlugsArabic, List<string> categoriesSlugsKurdish, List<ushort> locationIds, string fullAddressArabic, string fullAddressKurdish)
    {
        if (string.IsNullOrEmpty(dto.Title) || !dto.IsDollar.HasValue || !dto.PriceValue.HasValue)
            throw new ArgumentException("Required fields are missing");

        return new Crane
        {
            Title = dto.Title, Description = dto.Description ?? string.Empty,
            Price = new Price { IsDollar = dto.IsDollar.Value, Value = dto.PriceValue.Value, ShowingPrice = AdDtoMapper.FormatShowingPrice(dto.IsDollar.Value, dto.PriceValue.Value) },
            Category = new Category { CategoriesSlugsArabic = categoriesSlugsArabic, CategoriesSlugsKurdish = categoriesSlugsKurdish },
            LocationAd = new LocationAd { LocationIds = locationIds, Street = dto.Street, FullAddressArabic = fullAddressArabic, FullAddressKurdish = fullAddressKurdish },
            Images = new List<AdImage>(), Status = Status.Active, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow,
            ImageCount = 0, ViewsCount = 0, UserId = userId, Priority = 0, Slug = slug,
            FuelType = dto.FuelType, EnginePower = dto.EnginePower, FuelTankCapacity = dto.FuelTankCapacity,
            OperatingMass = dto.OperatingMass, Weight = dto.Weight,
            LiftingCapacity = dto.LiftingCapacity, MaxLiftingHeight = dto.MaxLiftingHeight, BoomLength = dto.BoomLength, RotationAngle = dto.RotationAngle
        };
    }

    public static GetCraneAdDto MapToDto(Crane entity)
    {
        return new GetCraneAdDto
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
            Category = new DTOs.Common.CategoryResponseDto { CategoriesSlugsArabic = entity.Category.CategoriesSlugsArabic, CategoriesSlugsKurdish = entity.Category.CategoriesSlugsKurdish },
            Specs = new CraneSpecsDto
            {
                FuelType = entity.FuelType,
                EnginePower = entity.EnginePower,
                FuelTankCapacity = entity.FuelTankCapacity,
                OperatingMass = entity.OperatingMass,
                Weight = entity.Weight,
                LiftingCapacity = entity.LiftingCapacity,
                MaxLiftingHeight = entity.MaxLiftingHeight,
                BoomLength = entity.BoomLength,
                RotationAngle = entity.RotationAngle
            }
        };
    }

    public static CreateCraneAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateCraneAdDto
        {
            Title = baseDto.Title, Description = baseDto.Description, IsDollar = baseDto.IsDollar, PriceValue = baseDto.PriceValue,
            City = baseDto.City, Region = baseDto.Region, Neighborhood = baseDto.Neighborhood, Street = baseDto.Street, ImageFiles = baseDto.ImageFiles,
            FuelType = FormParsingHelpers.ParseEnum<FuelType>(form, "FuelType"),
            EnginePower = FormParsingHelpers.ParseUShort(form, "EnginePower"),
            FuelTankCapacity = FormParsingHelpers.ParseUShort(form, "FuelTankCapacity"),
            OperatingMass = FormParsingHelpers.ParseFloat(form, "OperatingMass"),
            Weight = FormParsingHelpers.ParseFloat(form, "Weight"),
            LiftingCapacity = FormParsingHelpers.ParseFloat(form, "LiftingCapacity"),
            MaxLiftingHeight = FormParsingHelpers.ParseFloat(form, "MaxLiftingHeight"),
            BoomLength = FormParsingHelpers.ParseFloat(form, "BoomLength"),
            RotationAngle = FormParsingHelpers.ParseUShort(form, "RotationAngle")
        };
    }

    public static CraneAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CraneAdDto
        {
            Title = baseDto.Title, Description = baseDto.Description, IsDollar = baseDto.IsDollar, PriceValue = baseDto.PriceValue,
            City = baseDto.City, Region = baseDto.Region, Neighborhood = baseDto.Neighborhood, Street = baseDto.Street, ImageFiles = baseDto.ImageFiles,
            FuelType = FormParsingHelpers.ParseEnum<FuelType>(form, "FuelType"),
            EnginePower = FormParsingHelpers.ParseUShort(form, "EnginePower"),
            FuelTankCapacity = FormParsingHelpers.ParseUShort(form, "FuelTankCapacity"),
            OperatingMass = FormParsingHelpers.ParseFloat(form, "OperatingMass"),
            Weight = FormParsingHelpers.ParseFloat(form, "Weight"),
            LiftingCapacity = FormParsingHelpers.ParseFloat(form, "LiftingCapacity"),
            MaxLiftingHeight = FormParsingHelpers.ParseFloat(form, "MaxLiftingHeight"),
            BoomLength = FormParsingHelpers.ParseFloat(form, "BoomLength"),
            RotationAngle = FormParsingHelpers.ParseUShort(form, "RotationAngle")
        };
    }

    public static void UpdateAttributes(Ad ad, CraneAdDto dto)
    {
        if (ad is Crane crane)
        {
            if (dto.FuelType.HasValue) crane.FuelType = dto.FuelType;
            if (dto.EnginePower.HasValue) crane.EnginePower = dto.EnginePower;
            if (dto.FuelTankCapacity.HasValue) crane.FuelTankCapacity = dto.FuelTankCapacity;
            if (dto.OperatingMass.HasValue) crane.OperatingMass = dto.OperatingMass;
            if (dto.Weight.HasValue) crane.Weight = dto.Weight;
            if (dto.LiftingCapacity.HasValue) crane.LiftingCapacity = dto.LiftingCapacity;
            if (dto.MaxLiftingHeight.HasValue) crane.MaxLiftingHeight = dto.MaxLiftingHeight;
            if (dto.BoomLength.HasValue) crane.BoomLength = dto.BoomLength;
            if (dto.RotationAngle.HasValue) crane.RotationAngle = dto.RotationAngle;
        }
    }
}
