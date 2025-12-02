using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Application.Interfaces;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Electronics;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;
using static ClassifiedAds.Application.Common.FormParsingHelpers;

namespace ClassifiedAds.Application.Mappers;

public static class HandheldDeviceAdDtoMapper
{
    // Async mapper that handles brand/model resolution internally (brand + model)
    public static async Task<HandheldDevice> MapToEntityAsync(
        CreateHandheldDeviceAdDto dto,
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

        if (string.IsNullOrEmpty(dto.BrandName) || string.IsNullOrEmpty(dto.ModelName))
            throw new ArgumentException("BrandName and ModelName are required for HandheldDevice ads");

        // Resolve brand and model
        var (_, modelsSlugs) = await brandModelReleaseService.ResolveBrandModelAsync(
            categorySlug, language, dto.BrandName, dto.ModelName);

        string showingPrice = AdDtoMapper.FormatShowingPrice(dto.IsDollar.Value, dto.PriceValue.Value);

        return new HandheldDevice
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
            IsNew = dto.IsNew,
            WarrantyMonths = dto.WarrantyMonths,
            StorageCapacity = dto.StorageCapacity,
            RamSize = dto.RamSize,
            Color = dto.Color,
            MainCamera = dto.MainCamera,
            FrontCamera = dto.FrontCamera,
            MainCameraResolution = dto.MainCameraResolution,
            FrontCameraResolution = dto.FrontCameraResolution,
            BatteryCapacity = dto.BatteryCapacity,
            ScreenSize = dto.ScreenSize,
            Processor = dto.Processor,
            DualSim = dto.DualSim,
            WaterproofSupport = dto.WaterproofSupport,
            StylusSupport = dto.StylusSupport,
            ModelsSlugs = modelsSlugs
        };
    }

    public static GetHandheldDeviceAdDto MapToDto(HandheldDevice entity)
    {
        return new GetHandheldDeviceAdDto
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
            Specs = new HandheldDeviceSpecsDto
            {
                IsNew = entity.IsNew,
                WarrantyMonths = entity.WarrantyMonths,
                StorageCapacity = entity.StorageCapacity,
                RamSize = entity.RamSize,
                Color = entity.Color,
                MainCamera = entity.MainCamera,
                FrontCamera = entity.FrontCamera,
                MainCameraResolution = entity.MainCameraResolution,
                FrontCameraResolution = entity.FrontCameraResolution,
                BatteryCapacity = entity.BatteryCapacity,
                ScreenSize = entity.ScreenSize,
                Processor = entity.Processor,
                DualSim = entity.DualSim,
                WaterproofSupport = entity.WaterproofSupport,
                StylusSupport = entity.StylusSupport,
                ModelsSlugs = entity.ModelsSlugs
            }
        };
    }

    public static CreateHandheldDeviceAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateHandheldDeviceAdDto
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
            IsNew = ParseEnum<YesNo>(form, "IsNew"),
            WarrantyMonths = ParseByte(form, "WarrantyMonths"),
            StorageCapacity = ParseEnum<Domain.Entities.Ads.Electronics.Enums.StorageCapacity>(form, "StorageCapacity"),
            RamSize = ParseEnum<Domain.Entities.Ads.Electronics.Enums.RamSize>(form, "RamSize"),
            Color = ParseEnum<Domain.Entities.Ads.Electronics.Enums.Color>(form, "Color"),
            MainCamera = ParseEnum<YesNo>(form, "MainCamera"),
            FrontCamera = ParseEnum<YesNo>(form, "FrontCamera"),
            MainCameraResolution = ParseFloat(form, "MainCameraResolution"),
            FrontCameraResolution = ParseFloat(form, "FrontCameraResolution"),
            BatteryCapacity = ParseUShort(form, "BatteryCapacity"),
            ScreenSize = ParseFloat(form, "ScreenSize"),
            Processor = ParseString(form, "Processor"),
            DualSim = ParseEnum<YesNo>(form, "DualSim"),
            WaterproofSupport = ParseEnum<YesNo>(form, "WaterproofSupport"),
            StylusSupport = ParseEnum<YesNo>(form, "StylusSupport"),
            BrandName = ParseString(form, "BrandName"),
            ModelName = ParseString(form, "ModelName")
        };
    }

    public static HandheldDeviceAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new HandheldDeviceAdDto
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
            IsNew = ParseEnum<YesNo>(form, "IsNew"),
            WarrantyMonths = ParseByte(form, "WarrantyMonths"),
            StorageCapacity = ParseEnum<Domain.Entities.Ads.Electronics.Enums.StorageCapacity>(form, "StorageCapacity"),
            RamSize = ParseEnum<Domain.Entities.Ads.Electronics.Enums.RamSize>(form, "RamSize"),
            Color = ParseEnum<Domain.Entities.Ads.Electronics.Enums.Color>(form, "Color"),
            MainCamera = ParseEnum<YesNo>(form, "MainCamera"),
            FrontCamera = ParseEnum<YesNo>(form, "FrontCamera"),
            MainCameraResolution = ParseFloat(form, "MainCameraResolution"),
            FrontCameraResolution = ParseFloat(form, "FrontCameraResolution"),
            BatteryCapacity = ParseUShort(form, "BatteryCapacity"),
            ScreenSize = ParseFloat(form, "ScreenSize"),
            Processor = ParseString(form, "Processor"),
            DualSim = ParseEnum<YesNo>(form, "DualSim"),
            WaterproofSupport = ParseEnum<YesNo>(form, "WaterproofSupport"),
            StylusSupport = ParseEnum<YesNo>(form, "StylusSupport"),
            BrandName = ParseString(form, "BrandName"),
            ModelName = ParseString(form, "ModelName")
        };
    }

    public static void UpdateAttributes(Ad ad, HandheldDeviceAdDto dto)
    {
        if (ad is HandheldDevice device)
        {
            if (dto.IsNew.HasValue) device.IsNew = dto.IsNew;
            if (dto.WarrantyMonths.HasValue) device.WarrantyMonths = dto.WarrantyMonths;
            if (dto.StorageCapacity.HasValue) device.StorageCapacity = dto.StorageCapacity;
            if (dto.RamSize.HasValue) device.RamSize = dto.RamSize;
            if (dto.Color.HasValue) device.Color = dto.Color;
            if (dto.MainCamera.HasValue) device.MainCamera = dto.MainCamera;
            if (dto.FrontCamera.HasValue) device.FrontCamera = dto.FrontCamera;
            if (dto.MainCameraResolution.HasValue) device.MainCameraResolution = dto.MainCameraResolution;
            if (dto.FrontCameraResolution.HasValue) device.FrontCameraResolution = dto.FrontCameraResolution;
            if (dto.BatteryCapacity.HasValue) device.BatteryCapacity = dto.BatteryCapacity;
            if (dto.ScreenSize.HasValue) device.ScreenSize = dto.ScreenSize;
            if (!string.IsNullOrEmpty(dto.Processor)) device.Processor = dto.Processor;
            if (dto.DualSim.HasValue) device.DualSim = dto.DualSim;
            if (dto.WaterproofSupport.HasValue) device.WaterproofSupport = dto.WaterproofSupport;
            if (dto.StylusSupport.HasValue) device.StylusSupport = dto.StylusSupport;
            // Note: BrandName/ModelName update requires calling BrandModelReleaseService - handled in AdService
        }
    }
}
