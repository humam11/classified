using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Electronics;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers;

public static class LaptopAdDtoMapper
{
    public static Laptop MapToEntity(
        CreateLaptopAdDto dto,
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

        return new Laptop
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
            Cpu = dto.Cpu,
            RamSize = dto.RamSize,
            IsSSD = dto.IsSSD,
            StorageCapacity = dto.StorageCapacity,
            GraphicsCard = dto.GraphicsCard,
            UsbPorts = dto.UsbPorts,
            HdmiPorts = dto.HdmiPorts,
            ScreenSize = dto.ScreenSize,
            IsTouchscreen = dto.IsTouchscreen,
            Resolution = dto.Resolution,
            IsBacklitKeyboard = dto.IsBacklitKeyboard,
            HasWebcam = dto.HasWebcam,
            WebcamResolution = dto.WebcamResolution,
            HasFingerprintReader = dto.HasFingerprintReader,
            Color = dto.Color,
            ModelId = dto.ModelId
        };
    }

    public static GetLaptopAdDto MapToDto(Laptop entity)
    {
        return new GetLaptopAdDto
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
            Specs = new LaptopSpecsDto
            {
                IsNew = entity.IsNew,
                WarrantyMonths = entity.WarrantyMonths,
                Cpu = entity.Cpu,
                RamSize = entity.RamSize,
                IsSSD = entity.IsSSD,
                StorageCapacity = entity.StorageCapacity,
                GraphicsCard = entity.GraphicsCard,
                UsbPorts = entity.UsbPorts,
                HdmiPorts = entity.HdmiPorts,
                ScreenSize = entity.ScreenSize,
                IsTouchscreen = entity.IsTouchscreen,
                Resolution = entity.Resolution,
                IsBacklitKeyboard = entity.IsBacklitKeyboard,
                HasWebcam = entity.HasWebcam,
                WebcamResolution = entity.WebcamResolution,
                HasFingerprintReader = entity.HasFingerprintReader,
                Color = entity.Color,
                ModelId = entity.ModelId
            }
        };
    }

    public static CreateLaptopAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateLaptopAdDto
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
            Cpu = form.TryGetValue("Cpu", out var cpu) && !string.IsNullOrWhiteSpace(cpu) ? cpu.ToString() : null,
            RamSize = form.TryGetValue("RamSize", out var ramSize) &&
                     !string.IsNullOrWhiteSpace(ramSize) &&
                     Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.RamSize>(ramSize, out var rs) ? rs : null,
            IsSSD = form.TryGetValue("IsSSD", out var isSSD) &&
                   !string.IsNullOrWhiteSpace(isSSD) &&
                   Enum.TryParse<Domain.Common.Enums.YesNo>(isSSD, out var ssd) ? ssd : null,
            StorageCapacity = form.TryGetValue("StorageCapacity", out var storage) &&
                             !string.IsNullOrWhiteSpace(storage) &&
                             Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.StorageCapacity>(storage, out var sc) ? sc : null,
            GraphicsCard = form.TryGetValue("GraphicsCard", out var gpu) && !string.IsNullOrWhiteSpace(gpu) ? gpu.ToString() : null,
            UsbPorts = form.TryGetValue("UsbPorts", out var usb) &&
                      !string.IsNullOrWhiteSpace(usb) &&
                      byte.TryParse(usb, out var up) ? up : null,
            HdmiPorts = form.TryGetValue("HdmiPorts", out var hdmi) &&
                       !string.IsNullOrWhiteSpace(hdmi) &&
                       byte.TryParse(hdmi, out var hp) ? hp : null,
            ScreenSize = form.TryGetValue("ScreenSize", out var screenSize) &&
                        !string.IsNullOrWhiteSpace(screenSize) &&
                        float.TryParse(screenSize, out var ss) ? ss : null,
            IsTouchscreen = form.TryGetValue("IsTouchscreen", out var touch) &&
                           !string.IsNullOrWhiteSpace(touch) &&
                           Enum.TryParse<Domain.Common.Enums.YesNo>(touch, out var ts) ? ts : null,
            Resolution = form.TryGetValue("Resolution", out var res) && !string.IsNullOrWhiteSpace(res) ? res.ToString() : null,
            IsBacklitKeyboard = form.TryGetValue("IsBacklitKeyboard", out var backlit) &&
                               !string.IsNullOrWhiteSpace(backlit) &&
                               Enum.TryParse<Domain.Common.Enums.YesNo>(backlit, out var bk) ? bk : null,
            HasWebcam = form.TryGetValue("HasWebcam", out var webcam) &&
                       !string.IsNullOrWhiteSpace(webcam) &&
                       Enum.TryParse<Domain.Common.Enums.YesNo>(webcam, out var wc) ? wc : null,
            WebcamResolution = form.TryGetValue("WebcamResolution", out var wcRes) &&
                              !string.IsNullOrWhiteSpace(wcRes) &&
                              Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.WebcamResolution>(wcRes, out var wr) ? wr : null,
            HasFingerprintReader = form.TryGetValue("HasFingerprintReader", out var fingerprint) &&
                                  !string.IsNullOrWhiteSpace(fingerprint) &&
                                  Enum.TryParse<Domain.Common.Enums.YesNo>(fingerprint, out var fp) ? fp : null,
            Color = form.TryGetValue("Color", out var color) &&
                   !string.IsNullOrWhiteSpace(color) &&
                   Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.Color>(color, out var c) ? c : null,
            ModelId = form.TryGetValue("ModelId", out var modelId) &&
                     !string.IsNullOrWhiteSpace(modelId) &&
                     Guid.TryParse(modelId, out var m) ? m : null
        };
    }

    public static LaptopAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new LaptopAdDto
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
            Cpu = form.TryGetValue("Cpu", out var cpu) && !string.IsNullOrWhiteSpace(cpu) ? cpu.ToString() : null,
            RamSize = form.TryGetValue("RamSize", out var ramSize) &&
                     !string.IsNullOrWhiteSpace(ramSize) &&
                     Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.RamSize>(ramSize, out var rs) ? rs : null,
            IsSSD = form.TryGetValue("IsSSD", out var isSSD) &&
                   !string.IsNullOrWhiteSpace(isSSD) &&
                   Enum.TryParse<Domain.Common.Enums.YesNo>(isSSD, out var ssd) ? ssd : null,
            StorageCapacity = form.TryGetValue("StorageCapacity", out var storage) &&
                             !string.IsNullOrWhiteSpace(storage) &&
                             Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.StorageCapacity>(storage, out var sc) ? sc : null,
            GraphicsCard = form.TryGetValue("GraphicsCard", out var gpu) && !string.IsNullOrWhiteSpace(gpu) ? gpu.ToString() : null,
            UsbPorts = form.TryGetValue("UsbPorts", out var usb) &&
                      !string.IsNullOrWhiteSpace(usb) &&
                      byte.TryParse(usb, out var up) ? up : null,
            HdmiPorts = form.TryGetValue("HdmiPorts", out var hdmi) &&
                       !string.IsNullOrWhiteSpace(hdmi) &&
                       byte.TryParse(hdmi, out var hp) ? hp : null,
            ScreenSize = form.TryGetValue("ScreenSize", out var screenSize) &&
                        !string.IsNullOrWhiteSpace(screenSize) &&
                        float.TryParse(screenSize, out var ss) ? ss : null,
            IsTouchscreen = form.TryGetValue("IsTouchscreen", out var touch) &&
                           !string.IsNullOrWhiteSpace(touch) &&
                           Enum.TryParse<Domain.Common.Enums.YesNo>(touch, out var ts) ? ts : null,
            Resolution = form.TryGetValue("Resolution", out var res) && !string.IsNullOrWhiteSpace(res) ? res.ToString() : null,
            IsBacklitKeyboard = form.TryGetValue("IsBacklitKeyboard", out var backlit) &&
                               !string.IsNullOrWhiteSpace(backlit) &&
                               Enum.TryParse<Domain.Common.Enums.YesNo>(backlit, out var bk) ? bk : null,
            HasWebcam = form.TryGetValue("HasWebcam", out var webcam) &&
                       !string.IsNullOrWhiteSpace(webcam) &&
                       Enum.TryParse<Domain.Common.Enums.YesNo>(webcam, out var wc) ? wc : null,
            WebcamResolution = form.TryGetValue("WebcamResolution", out var wcRes) &&
                              !string.IsNullOrWhiteSpace(wcRes) &&
                              Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.WebcamResolution>(wcRes, out var wr) ? wr : null,
            HasFingerprintReader = form.TryGetValue("HasFingerprintReader", out var fingerprint) &&
                                  !string.IsNullOrWhiteSpace(fingerprint) &&
                                  Enum.TryParse<Domain.Common.Enums.YesNo>(fingerprint, out var fp) ? fp : null,
            Color = form.TryGetValue("Color", out var color) &&
                   !string.IsNullOrWhiteSpace(color) &&
                   Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.Color>(color, out var c) ? c : null,
            ModelId = form.TryGetValue("ModelId", out var modelId) &&
                     !string.IsNullOrWhiteSpace(modelId) &&
                     Guid.TryParse(modelId, out var m) ? m : null
        };
    }

    public static void UpdateAttributes(Ad ad, LaptopAdDto dto)
    {
        if (ad is Laptop laptop)
        {
            if (dto.IsNew.HasValue)
                laptop.IsNew = dto.IsNew;
            if (dto.WarrantyMonths.HasValue)
                laptop.WarrantyMonths = dto.WarrantyMonths;
            if (!string.IsNullOrEmpty(dto.Cpu))
                laptop.Cpu = dto.Cpu;
            if (dto.RamSize.HasValue)
                laptop.RamSize = dto.RamSize;
            if (dto.IsSSD.HasValue)
                laptop.IsSSD = dto.IsSSD;
            if (dto.StorageCapacity.HasValue)
                laptop.StorageCapacity = dto.StorageCapacity;
            if (!string.IsNullOrEmpty(dto.GraphicsCard))
                laptop.GraphicsCard = dto.GraphicsCard;
            if (dto.UsbPorts.HasValue)
                laptop.UsbPorts = dto.UsbPorts;
            if (dto.HdmiPorts.HasValue)
                laptop.HdmiPorts = dto.HdmiPorts;
            if (dto.ScreenSize.HasValue)
                laptop.ScreenSize = dto.ScreenSize;
            if (dto.IsTouchscreen.HasValue)
                laptop.IsTouchscreen = dto.IsTouchscreen;
            if (!string.IsNullOrEmpty(dto.Resolution))
                laptop.Resolution = dto.Resolution;
            if (dto.IsBacklitKeyboard.HasValue)
                laptop.IsBacklitKeyboard = dto.IsBacklitKeyboard;
            if (dto.HasWebcam.HasValue)
                laptop.HasWebcam = dto.HasWebcam;
            if (dto.WebcamResolution.HasValue)
                laptop.WebcamResolution = dto.WebcamResolution;
            if (dto.HasFingerprintReader.HasValue)
                laptop.HasFingerprintReader = dto.HasFingerprintReader;
            if (dto.Color.HasValue)
                laptop.Color = dto.Color;
            if (dto.ModelId.HasValue)
                laptop.ModelId = dto.ModelId;
        }
    }
}
