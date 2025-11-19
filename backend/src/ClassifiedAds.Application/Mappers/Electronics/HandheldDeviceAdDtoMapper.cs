using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Electronics;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers;

public static class HandheldDeviceAdDtoMapper
{
    public static HandheldDevice MapToEntity(
        CreateHandheldDeviceAdDto dto,
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

        return new HandheldDevice
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
            ModelId = dto.ModelId
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
            IsNew = form.TryGetValue("IsNew", out var isNew) &&
                   !string.IsNullOrWhiteSpace(isNew) &&
                   Enum.TryParse<Domain.Common.Enums.YesNo>(isNew, out var yn) ? yn : null,
            WarrantyMonths = form.TryGetValue("WarrantyMonths", out var warranty) &&
                            !string.IsNullOrWhiteSpace(warranty) &&
                            byte.TryParse(warranty, out var wm) ? wm : null,
            StorageCapacity = form.TryGetValue("StorageCapacity", out var storage) &&
                             !string.IsNullOrWhiteSpace(storage) &&
                             Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.StorageCapacity>(storage, out var sc) ? sc : null,
            RamSize = form.TryGetValue("RamSize", out var ramSize) &&
                     !string.IsNullOrWhiteSpace(ramSize) &&
                     Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.RamSize>(ramSize, out var rs) ? rs : null,
            Color = form.TryGetValue("Color", out var color) &&
                   !string.IsNullOrWhiteSpace(color) &&
                   Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.Color>(color, out var c) ? c : null,
            MainCamera = form.TryGetValue("MainCamera", out var mainCam) &&
                        !string.IsNullOrWhiteSpace(mainCam) &&
                        Enum.TryParse<Domain.Common.Enums.YesNo>(mainCam, out var mc) ? mc : null,
            FrontCamera = form.TryGetValue("FrontCamera", out var frontCam) &&
                         !string.IsNullOrWhiteSpace(frontCam) &&
                         Enum.TryParse<Domain.Common.Enums.YesNo>(frontCam, out var fc) ? fc : null,
            MainCameraResolution = form.TryGetValue("MainCameraResolution", out var mainRes) &&
                                  !string.IsNullOrWhiteSpace(mainRes) &&
                                  float.TryParse(mainRes, out var mcr) ? mcr : null,
            FrontCameraResolution = form.TryGetValue("FrontCameraResolution", out var frontRes) &&
                                   !string.IsNullOrWhiteSpace(frontRes) &&
                                   float.TryParse(frontRes, out var fcr) ? fcr : null,
            BatteryCapacity = form.TryGetValue("BatteryCapacity", out var battery) &&
                             !string.IsNullOrWhiteSpace(battery) &&
                             ushort.TryParse(battery, out var bc) ? bc : null,
            ScreenSize = form.TryGetValue("ScreenSize", out var screenSize) &&
                        !string.IsNullOrWhiteSpace(screenSize) &&
                        float.TryParse(screenSize, out var ss) ? ss : null,
            Processor = form.TryGetValue("Processor", out var proc) && !string.IsNullOrWhiteSpace(proc) ? proc.ToString() : null,
            DualSim = form.TryGetValue("DualSim", out var dualSim) &&
                     !string.IsNullOrWhiteSpace(dualSim) &&
                     Enum.TryParse<Domain.Common.Enums.YesNo>(dualSim, out var ds) ? ds : null,
            WaterproofSupport = form.TryGetValue("WaterproofSupport", out var waterproof) &&
                               !string.IsNullOrWhiteSpace(waterproof) &&
                               Enum.TryParse<Domain.Common.Enums.YesNo>(waterproof, out var wp) ? wp : null,
            StylusSupport = form.TryGetValue("StylusSupport", out var stylus) &&
                           !string.IsNullOrWhiteSpace(stylus) &&
                           Enum.TryParse<Domain.Common.Enums.YesNo>(stylus, out var st) ? st : null,
            ModelId = form.TryGetValue("ModelId", out var modelId) &&
                     !string.IsNullOrWhiteSpace(modelId) &&
                     Guid.TryParse(modelId, out var m) ? m : null
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
            IsNew = form.TryGetValue("IsNew", out var isNew) &&
                   !string.IsNullOrWhiteSpace(isNew) &&
                   Enum.TryParse<Domain.Common.Enums.YesNo>(isNew, out var yn) ? yn : null,
            WarrantyMonths = form.TryGetValue("WarrantyMonths", out var warranty) &&
                            !string.IsNullOrWhiteSpace(warranty) &&
                            byte.TryParse(warranty, out var wm) ? wm : null,
            StorageCapacity = form.TryGetValue("StorageCapacity", out var storage) &&
                             !string.IsNullOrWhiteSpace(storage) &&
                             Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.StorageCapacity>(storage, out var sc) ? sc : null,
            RamSize = form.TryGetValue("RamSize", out var ramSize) &&
                     !string.IsNullOrWhiteSpace(ramSize) &&
                     Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.RamSize>(ramSize, out var rs) ? rs : null,
            Color = form.TryGetValue("Color", out var color) &&
                   !string.IsNullOrWhiteSpace(color) &&
                   Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.Color>(color, out var c) ? c : null,
            MainCamera = form.TryGetValue("MainCamera", out var mainCam) &&
                        !string.IsNullOrWhiteSpace(mainCam) &&
                        Enum.TryParse<Domain.Common.Enums.YesNo>(mainCam, out var mc) ? mc : null,
            FrontCamera = form.TryGetValue("FrontCamera", out var frontCam) &&
                         !string.IsNullOrWhiteSpace(frontCam) &&
                         Enum.TryParse<Domain.Common.Enums.YesNo>(frontCam, out var fc) ? fc : null,
            MainCameraResolution = form.TryGetValue("MainCameraResolution", out var mainRes) &&
                                  !string.IsNullOrWhiteSpace(mainRes) &&
                                  float.TryParse(mainRes, out var mcr) ? mcr : null,
            FrontCameraResolution = form.TryGetValue("FrontCameraResolution", out var frontRes) &&
                                   !string.IsNullOrWhiteSpace(frontRes) &&
                                   float.TryParse(frontRes, out var fcr) ? fcr : null,
            BatteryCapacity = form.TryGetValue("BatteryCapacity", out var battery) &&
                             !string.IsNullOrWhiteSpace(battery) &&
                             ushort.TryParse(battery, out var bc) ? bc : null,
            ScreenSize = form.TryGetValue("ScreenSize", out var screenSize) &&
                        !string.IsNullOrWhiteSpace(screenSize) &&
                        float.TryParse(screenSize, out var ss) ? ss : null,
            Processor = form.TryGetValue("Processor", out var proc) && !string.IsNullOrWhiteSpace(proc) ? proc.ToString() : null,
            DualSim = form.TryGetValue("DualSim", out var dualSim) &&
                     !string.IsNullOrWhiteSpace(dualSim) &&
                     Enum.TryParse<Domain.Common.Enums.YesNo>(dualSim, out var ds) ? ds : null,
            WaterproofSupport = form.TryGetValue("WaterproofSupport", out var waterproof) &&
                               !string.IsNullOrWhiteSpace(waterproof) &&
                               Enum.TryParse<Domain.Common.Enums.YesNo>(waterproof, out var wp) ? wp : null,
            StylusSupport = form.TryGetValue("StylusSupport", out var stylus) &&
                           !string.IsNullOrWhiteSpace(stylus) &&
                           Enum.TryParse<Domain.Common.Enums.YesNo>(stylus, out var st) ? st : null,
            ModelId = form.TryGetValue("ModelId", out var modelId) &&
                     !string.IsNullOrWhiteSpace(modelId) &&
                     Guid.TryParse(modelId, out var m) ? m : null
        };
    }

    public static void UpdateAttributes(Ad ad, HandheldDeviceAdDto dto)
    {
        if (ad is HandheldDevice device)
        {
            if (dto.IsNew.HasValue)
                device.IsNew = dto.IsNew;
            if (dto.WarrantyMonths.HasValue)
                device.WarrantyMonths = dto.WarrantyMonths;
            if (dto.StorageCapacity.HasValue)
                device.StorageCapacity = dto.StorageCapacity;
            if (dto.RamSize.HasValue)
                device.RamSize = dto.RamSize;
            if (dto.Color.HasValue)
                device.Color = dto.Color;
            if (dto.MainCamera.HasValue)
                device.MainCamera = dto.MainCamera;
            if (dto.FrontCamera.HasValue)
                device.FrontCamera = dto.FrontCamera;
            if (dto.MainCameraResolution.HasValue)
                device.MainCameraResolution = dto.MainCameraResolution;
            if (dto.FrontCameraResolution.HasValue)
                device.FrontCameraResolution = dto.FrontCameraResolution;
            if (dto.BatteryCapacity.HasValue)
                device.BatteryCapacity = dto.BatteryCapacity;
            if (dto.ScreenSize.HasValue)
                device.ScreenSize = dto.ScreenSize;
            if (!string.IsNullOrEmpty(dto.Processor))
                device.Processor = dto.Processor;
            if (dto.DualSim.HasValue)
                device.DualSim = dto.DualSim;
            if (dto.WaterproofSupport.HasValue)
                device.WaterproofSupport = dto.WaterproofSupport;
            if (dto.StylusSupport.HasValue)
                device.StylusSupport = dto.StylusSupport;
            if (dto.ModelId.HasValue)
                device.ModelId = dto.ModelId;
        }
    }
}
