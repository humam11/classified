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

public static class TvMonitorAdDtoMapper
{
    // Async mapper that handles brand resolution internally (brand only)
    public static async Task<TvMonitor> MapToEntityAsync(
        CreateTvMonitorAdDto dto,
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
            throw new ArgumentException("BrandName is required for TvMonitor ads");

        // Resolve brand only
        var (_, modelsSlugs) = await brandModelReleaseService.ResolveBrandAsync(
            categorySlug, language, dto.BrandName);

        string showingPrice = AdDtoMapper.FormatShowingPrice(dto.IsDollar.Value, dto.PriceValue.Value);

        return new TvMonitor
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
            ScreenSize = dto.ScreenSize,
            ScreenResolution = dto.ScreenResolution,
            SmartTv = dto.SmartTv,
            RefreshRate = dto.RefreshRate,
            HdmiPorts = dto.HdmiPorts,
            UsbPorts = dto.UsbPorts,
            ModelsSlugs = modelsSlugs
        };
    }

    public static GetTvMonitorAdDto MapToDto(TvMonitor entity)
    {
        return new GetTvMonitorAdDto
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
            Specs = new TvMonitorSpecsDto
            {
                IsNew = entity.IsNew,
                WarrantyMonths = entity.WarrantyMonths,
                ScreenSize = entity.ScreenSize,
                ScreenResolution = entity.ScreenResolution,
                SmartTv = entity.SmartTv,
                RefreshRate = entity.RefreshRate,
                HdmiPorts = entity.HdmiPorts,
                UsbPorts = entity.UsbPorts,
                ModelsSlugs = entity.ModelsSlugs
            }
        };
    }

    public static CreateTvMonitorAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateTvMonitorAdDto
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
            ScreenSize = ParseFloat(form, "ScreenSize"),
            ScreenResolution = ParseEnum<Domain.Entities.Ads.Electronics.Enums.ScreenResolution>(form, "ScreenResolution"),
            SmartTv = ParseEnum<YesNo>(form, "SmartTv"),
            RefreshRate = ParseEnum<Domain.Entities.Ads.Electronics.Enums.RefreshRate>(form, "RefreshRate"),
            HdmiPorts = ParseByte(form, "HdmiPorts"),
            UsbPorts = ParseByte(form, "UsbPorts"),
            BrandName = ParseString(form, "BrandName")
        };
    }

    public static TvMonitorAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new TvMonitorAdDto
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
            ScreenSize = ParseFloat(form, "ScreenSize"),
            ScreenResolution = ParseEnum<Domain.Entities.Ads.Electronics.Enums.ScreenResolution>(form, "ScreenResolution"),
            SmartTv = ParseEnum<YesNo>(form, "SmartTv"),
            RefreshRate = ParseEnum<Domain.Entities.Ads.Electronics.Enums.RefreshRate>(form, "RefreshRate"),
            HdmiPorts = ParseByte(form, "HdmiPorts"),
            UsbPorts = ParseByte(form, "UsbPorts"),
            BrandName = ParseString(form, "BrandName")
        };
    }

    public static void UpdateAttributes(Ad ad, TvMonitorAdDto dto)
    {
        if (ad is TvMonitor tv)
        {
            if (dto.IsNew.HasValue) tv.IsNew = dto.IsNew;
            if (dto.WarrantyMonths.HasValue) tv.WarrantyMonths = dto.WarrantyMonths;
            if (dto.ScreenSize.HasValue) tv.ScreenSize = dto.ScreenSize;
            if (dto.ScreenResolution.HasValue) tv.ScreenResolution = dto.ScreenResolution;
            if (dto.SmartTv.HasValue) tv.SmartTv = dto.SmartTv;
            if (dto.RefreshRate.HasValue) tv.RefreshRate = dto.RefreshRate;
            if (dto.HdmiPorts.HasValue) tv.HdmiPorts = dto.HdmiPorts;
            if (dto.UsbPorts.HasValue) tv.UsbPorts = dto.UsbPorts;
            // Note: BrandName update requires calling BrandModelReleaseService - handled in AdService
        }
    }
}
