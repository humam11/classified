using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Vehicles;
using ClassifiedAds.Application.Interfaces;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Vehicles;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;
using static ClassifiedAds.Application.Common.FormParsingHelpers;

namespace ClassifiedAds.Application.Mappers.Vehicles;

public static class MotorcycleAdDtoMapper
{
    // Async mapper that handles brand resolution internally (brand only)
    public static async Task<Motorcycle> MapToEntityAsync(
        CreateMotorcycleAdDto dto,
        string slug,
        Guid userId,
        List<string> categoriesSlugsArabic,
        List<string> categoriesSlugsKurdish,
        List<ushort> locationIds,
        string fullAddressArabic,
        string fullAddressKurdish,
        string categorySlug,
        string language,
        IBrandModelReleaseService brandModelReleaseService)
    {
        if (string.IsNullOrEmpty(dto.Title) || !dto.IsDollar.HasValue || !dto.PriceValue.HasValue)
            throw new ArgumentException("Required fields are missing");

        if (string.IsNullOrEmpty(dto.BrandName))
            throw new ArgumentException("BrandName is required for Motorcycle ads");

        // Resolve brand only
        var (_, modelsSlugs) = await brandModelReleaseService.ResolveBrandAsync(
            categorySlug, language, dto.BrandName);

        string showingPrice = AdDtoMapper.FormatShowingPrice(dto.IsDollar.Value, dto.PriceValue.Value);

        return new Motorcycle
        {
            Title = dto.Title,
            Description = dto.Description ?? string.Empty,
            Price = new Price { IsDollar = dto.IsDollar.Value, Value = dto.PriceValue.Value, ShowingPrice = showingPrice },
            Category = new Category { CategoriesSlugsArabic = categoriesSlugsArabic, CategoriesSlugsKurdish = categoriesSlugsKurdish },
            LocationAd = new LocationAd { LocationIds = locationIds, Street = dto.Street, FullAddressArabic = fullAddressArabic, FullAddressKurdish = fullAddressKurdish },
            Images = new List<AdImage>(),
            Status = Status.Active,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            ImageCount = 0,
            ViewsCount = 0,
            UserId = userId,
            Priority = 0,
            Slug = slug,
            FuelType = dto.FuelType,
            EnginePower = dto.EnginePower,
            FuelTankCapacity = dto.FuelTankCapacity,
            MotorcycleDriveType = dto.MotorcycleDriveType,
            GearCount = dto.GearCount,
            ModelsSlugs = modelsSlugs
        };
    }

    public static GetMotorcycleAdDto MapToDto(Motorcycle entity)
    {
        return new GetMotorcycleAdDto
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
            Specs = new MotorcycleSpecsDto
            {
                FuelType = entity.FuelType,
                EnginePower = entity.EnginePower,
                FuelTankCapacity = entity.FuelTankCapacity,
                MotorcycleDriveType = entity.MotorcycleDriveType,
                GearCount = entity.GearCount,
                ModelsSlugs = entity.ModelsSlugs
            }
        };
    }

    public static CreateMotorcycleAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateMotorcycleAdDto
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
            FuelType = ParseEnum<Domain.Entities.Ads.Vehicles.Enums.FuelType>(form, "FuelType"),
            EnginePower = ParseUShort(form, "EnginePower"),
            FuelTankCapacity = ParseUShort(form, "FuelTankCapacity"),
            MotorcycleDriveType = ParseEnum<Domain.Entities.Ads.Vehicles.Enums.MotorcycleDriveType>(form, "MotorcycleDriveType"),
            GearCount = ParseByte(form, "GearCount"),
            BrandName = ParseString(form, "BrandName")
        };
    }

    public static MotorcycleAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new MotorcycleAdDto
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
            FuelType = ParseEnum<Domain.Entities.Ads.Vehicles.Enums.FuelType>(form, "FuelType"),
            EnginePower = ParseUShort(form, "EnginePower"),
            FuelTankCapacity = ParseUShort(form, "FuelTankCapacity"),
            MotorcycleDriveType = ParseEnum<Domain.Entities.Ads.Vehicles.Enums.MotorcycleDriveType>(form, "MotorcycleDriveType"),
            GearCount = ParseByte(form, "GearCount"),
            BrandName = ParseString(form, "BrandName")
        };
    }

    public static void UpdateAttributes(Ad ad, MotorcycleAdDto dto)
    {
        if (ad is Motorcycle motorcycle)
        {
            if (dto.FuelType.HasValue) motorcycle.FuelType = dto.FuelType;
            if (dto.EnginePower.HasValue) motorcycle.EnginePower = dto.EnginePower;
            if (dto.FuelTankCapacity.HasValue) motorcycle.FuelTankCapacity = dto.FuelTankCapacity;
            if (dto.MotorcycleDriveType.HasValue) motorcycle.MotorcycleDriveType = dto.MotorcycleDriveType;
            if (dto.GearCount.HasValue) motorcycle.GearCount = dto.GearCount;
            // Note: BrandName update requires calling BrandModelReleaseService - handled in AdService
        }
    }
}
