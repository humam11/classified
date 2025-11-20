using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Electronics;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers;

public static class TvMonitorAdDtoMapper
{
    public static TvMonitor MapToEntity(
        CreateTvMonitorAdDto dto,
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

        return new TvMonitor
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
            ScreenSize = dto.ScreenSize,
            ScreenResolution = dto.ScreenResolution,
            SmartTv = dto.SmartTv,
            RefreshRate = dto.RefreshRate,
            HdmiPorts = dto.HdmiPorts,
            UsbPorts = dto.UsbPorts,
            ModelId = dto.ModelId
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
            Category = new DTOs.Common.CategoryResponseDto { CategoryJoins = entity.Category.CategoryJoins, CategoryIds = entity.Category.CategoryIds },
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
                ModelId = entity.ModelId
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
            IsNew = form.TryGetValue("IsNew", out var isNew) &&
                   !string.IsNullOrWhiteSpace(isNew) &&
                   Enum.TryParse<Domain.Common.Enums.YesNo>(isNew, out var yn) ? yn : null,
            WarrantyMonths = form.TryGetValue("WarrantyMonths", out var warranty) &&
                            !string.IsNullOrWhiteSpace(warranty) &&
                            byte.TryParse(warranty, out var wm) ? wm : null,
            ScreenSize = form.TryGetValue("ScreenSize", out var screenSize) &&
                        !string.IsNullOrWhiteSpace(screenSize) &&
                        float.TryParse(screenSize, out var ss) ? ss : null,
            ScreenResolution = form.TryGetValue("ScreenResolution", out var resolution) &&
                              !string.IsNullOrWhiteSpace(resolution) &&
                              Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.ScreenResolution>(resolution, out var sr) ? sr : null,
            SmartTv = form.TryGetValue("SmartTv", out var smartTv) &&
                     !string.IsNullOrWhiteSpace(smartTv) &&
                     Enum.TryParse<Domain.Common.Enums.YesNo>(smartTv, out var st) ? st : null,
            RefreshRate = form.TryGetValue("RefreshRate", out var refreshRate) &&
                         !string.IsNullOrWhiteSpace(refreshRate) &&
                         Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.RefreshRate>(refreshRate, out var rr) ? rr : null,
            HdmiPorts = form.TryGetValue("HdmiPorts", out var hdmi) &&
                       !string.IsNullOrWhiteSpace(hdmi) &&
                       byte.TryParse(hdmi, out var hp) ? hp : null,
            UsbPorts = form.TryGetValue("UsbPorts", out var usb) &&
                      !string.IsNullOrWhiteSpace(usb) &&
                      byte.TryParse(usb, out var up) ? up : null,
            ModelId = form.TryGetValue("ModelId", out var modelId) &&
                     !string.IsNullOrWhiteSpace(modelId) &&
                     Guid.TryParse(modelId, out var m) ? m : null
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
            IsNew = form.TryGetValue("IsNew", out var isNew) &&
                   !string.IsNullOrWhiteSpace(isNew) &&
                   Enum.TryParse<Domain.Common.Enums.YesNo>(isNew, out var yn) ? yn : null,
            WarrantyMonths = form.TryGetValue("WarrantyMonths", out var warranty) &&
                            !string.IsNullOrWhiteSpace(warranty) &&
                            byte.TryParse(warranty, out var wm) ? wm : null,
            ScreenSize = form.TryGetValue("ScreenSize", out var screenSize) &&
                        !string.IsNullOrWhiteSpace(screenSize) &&
                        float.TryParse(screenSize, out var ss) ? ss : null,
            ScreenResolution = form.TryGetValue("ScreenResolution", out var resolution) &&
                              !string.IsNullOrWhiteSpace(resolution) &&
                              Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.ScreenResolution>(resolution, out var sr) ? sr : null,
            SmartTv = form.TryGetValue("SmartTv", out var smartTv) &&
                     !string.IsNullOrWhiteSpace(smartTv) &&
                     Enum.TryParse<Domain.Common.Enums.YesNo>(smartTv, out var st) ? st : null,
            RefreshRate = form.TryGetValue("RefreshRate", out var refreshRate) &&
                         !string.IsNullOrWhiteSpace(refreshRate) &&
                         Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.RefreshRate>(refreshRate, out var rr) ? rr : null,
            HdmiPorts = form.TryGetValue("HdmiPorts", out var hdmi) &&
                       !string.IsNullOrWhiteSpace(hdmi) &&
                       byte.TryParse(hdmi, out var hp) ? hp : null,
            UsbPorts = form.TryGetValue("UsbPorts", out var usb) &&
                      !string.IsNullOrWhiteSpace(usb) &&
                      byte.TryParse(usb, out var up) ? up : null,
            ModelId = form.TryGetValue("ModelId", out var modelId) &&
                     !string.IsNullOrWhiteSpace(modelId) &&
                     Guid.TryParse(modelId, out var m) ? m : null
        };
    }

    public static void UpdateAttributes(Ad ad, TvMonitorAdDto dto)
    {
        if (ad is TvMonitor tv)
        {
            if (dto.IsNew.HasValue)
                tv.IsNew = dto.IsNew;
            if (dto.WarrantyMonths.HasValue)
                tv.WarrantyMonths = dto.WarrantyMonths;
            if (dto.ScreenSize.HasValue)
                tv.ScreenSize = dto.ScreenSize;
            if (dto.ScreenResolution.HasValue)
                tv.ScreenResolution = dto.ScreenResolution;
            if (dto.SmartTv.HasValue)
                tv.SmartTv = dto.SmartTv;
            if (dto.RefreshRate.HasValue)
                tv.RefreshRate = dto.RefreshRate;
            if (dto.HdmiPorts.HasValue)
                tv.HdmiPorts = dto.HdmiPorts;
            if (dto.UsbPorts.HasValue)
                tv.UsbPorts = dto.UsbPorts;
            if (dto.ModelId.HasValue)
                tv.ModelId = dto.ModelId;
        }
    }
}
