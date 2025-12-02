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

public static class LaptopAdDtoMapper
{
    // Async mapper that handles brand resolution internally (brand only)
    public static async Task<Laptop> MapToEntityAsync(
        CreateLaptopAdDto dto,
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
            throw new ArgumentException("BrandName is required for Laptop ads");

        // Resolve brand only
        var (_, modelsSlugs) = await brandModelReleaseService.ResolveBrandAsync(
            categorySlug, language, dto.BrandName);

        string showingPrice = AdDtoMapper.FormatShowingPrice(dto.IsDollar.Value, dto.PriceValue.Value);

        return new Laptop
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
            ModelsSlugs = modelsSlugs
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
            Category = new DTOs.Common.CategoryResponseDto { CategoriesSlugsArabic = entity.Category.CategoriesSlugsArabic, CategoriesSlugsKurdish = entity.Category.CategoriesSlugsKurdish },
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
                ModelsSlugs = entity.ModelsSlugs
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
            IsNew = ParseEnum<YesNo>(form, "IsNew"),
            WarrantyMonths = ParseByte(form, "WarrantyMonths"),
            Cpu = ParseString(form, "Cpu"),
            RamSize = ParseEnum<Domain.Entities.Ads.Electronics.Enums.RamSize>(form, "RamSize"),
            IsSSD = ParseEnum<YesNo>(form, "IsSSD"),
            StorageCapacity = ParseEnum<Domain.Entities.Ads.Electronics.Enums.StorageCapacity>(form, "StorageCapacity"),
            GraphicsCard = ParseString(form, "GraphicsCard"),
            UsbPorts = ParseByte(form, "UsbPorts"),
            HdmiPorts = ParseByte(form, "HdmiPorts"),
            ScreenSize = ParseFloat(form, "ScreenSize"),
            IsTouchscreen = ParseEnum<YesNo>(form, "IsTouchscreen"),
            Resolution = ParseString(form, "Resolution"),
            IsBacklitKeyboard = ParseEnum<YesNo>(form, "IsBacklitKeyboard"),
            HasWebcam = ParseEnum<YesNo>(form, "HasWebcam"),
            WebcamResolution = ParseEnum<Domain.Entities.Ads.Electronics.Enums.WebcamResolution>(form, "WebcamResolution"),
            HasFingerprintReader = ParseEnum<YesNo>(form, "HasFingerprintReader"),
            Color = ParseEnum<Domain.Entities.Ads.Electronics.Enums.Color>(form, "Color"),
            BrandName = ParseString(form, "BrandName")
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
            IsNew = ParseEnum<YesNo>(form, "IsNew"),
            WarrantyMonths = ParseByte(form, "WarrantyMonths"),
            Cpu = ParseString(form, "Cpu"),
            RamSize = ParseEnum<Domain.Entities.Ads.Electronics.Enums.RamSize>(form, "RamSize"),
            IsSSD = ParseEnum<YesNo>(form, "IsSSD"),
            StorageCapacity = ParseEnum<Domain.Entities.Ads.Electronics.Enums.StorageCapacity>(form, "StorageCapacity"),
            GraphicsCard = ParseString(form, "GraphicsCard"),
            UsbPorts = ParseByte(form, "UsbPorts"),
            HdmiPorts = ParseByte(form, "HdmiPorts"),
            ScreenSize = ParseFloat(form, "ScreenSize"),
            IsTouchscreen = ParseEnum<YesNo>(form, "IsTouchscreen"),
            Resolution = ParseString(form, "Resolution"),
            IsBacklitKeyboard = ParseEnum<YesNo>(form, "IsBacklitKeyboard"),
            HasWebcam = ParseEnum<YesNo>(form, "HasWebcam"),
            WebcamResolution = ParseEnum<Domain.Entities.Ads.Electronics.Enums.WebcamResolution>(form, "WebcamResolution"),
            HasFingerprintReader = ParseEnum<YesNo>(form, "HasFingerprintReader"),
            Color = ParseEnum<Domain.Entities.Ads.Electronics.Enums.Color>(form, "Color"),
            BrandName = ParseString(form, "BrandName")
        };
    }

    public static void UpdateAttributes(Ad ad, LaptopAdDto dto)
    {
        if (ad is Laptop laptop)
        {
            if (dto.IsNew.HasValue) laptop.IsNew = dto.IsNew;
            if (dto.WarrantyMonths.HasValue) laptop.WarrantyMonths = dto.WarrantyMonths;
            if (!string.IsNullOrEmpty(dto.Cpu)) laptop.Cpu = dto.Cpu;
            if (dto.RamSize.HasValue) laptop.RamSize = dto.RamSize;
            if (dto.IsSSD.HasValue) laptop.IsSSD = dto.IsSSD;
            if (dto.StorageCapacity.HasValue) laptop.StorageCapacity = dto.StorageCapacity;
            if (!string.IsNullOrEmpty(dto.GraphicsCard)) laptop.GraphicsCard = dto.GraphicsCard;
            if (dto.UsbPorts.HasValue) laptop.UsbPorts = dto.UsbPorts;
            if (dto.HdmiPorts.HasValue) laptop.HdmiPorts = dto.HdmiPorts;
            if (dto.ScreenSize.HasValue) laptop.ScreenSize = dto.ScreenSize;
            if (dto.IsTouchscreen.HasValue) laptop.IsTouchscreen = dto.IsTouchscreen;
            if (!string.IsNullOrEmpty(dto.Resolution)) laptop.Resolution = dto.Resolution;
            if (dto.IsBacklitKeyboard.HasValue) laptop.IsBacklitKeyboard = dto.IsBacklitKeyboard;
            if (dto.HasWebcam.HasValue) laptop.HasWebcam = dto.HasWebcam;
            if (dto.WebcamResolution.HasValue) laptop.WebcamResolution = dto.WebcamResolution;
            if (dto.HasFingerprintReader.HasValue) laptop.HasFingerprintReader = dto.HasFingerprintReader;
            if (dto.Color.HasValue) laptop.Color = dto.Color;
            // Note: BrandName update requires calling BrandModelReleaseService - handled in AdService
        }
    }
}
