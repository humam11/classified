using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Jobs;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.JobsServices;
using ClassifiedAds.Domain.Entities.Ads.JobsServices.ValueObjects;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;
using System.Text.Json;

namespace ClassifiedAds.Application.Mappers.Jobs;

public static class ServiceAdDtoMapper
{
    // Maps CreateServiceAdDto to Service entity - Used by: AdService.CreateAdAsync
    public static Service MapToEntity(
        CreateServiceAdDto dto,
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

        return new Service
        {
            // Base ad fields
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

            // Service-specific fields
            PaymentPeriod = dto.PaymentPeriod,
            DailyAvailability = dto.DailyAvailability?.Select(da => new DailyAvailability
            {
                DayWeek = da.DayWeek ?? default,
                IsAvailable = da.IsAvailable ?? default,
                Is24Hours = da.Is24Hours ?? default,
                TimeSlots = da.TimeSlots?.Select(ts => new TimeSlot
                {
                    OpeningTime = ts.OpeningTime ?? string.Empty,
                    ClosingTime = ts.ClosingTime ?? string.Empty
                }).ToList() ?? new List<TimeSlot>()
            }).ToList()
        };
    }

    // Maps Service entity to GetServiceAdDto - Used by: AdService.GetAdByIdAsync
    public static GetServiceAdDto MapToDto(Service entity)
    {
        return new GetServiceAdDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            Price = new DTOs.Common.PriceResponseDto
            {
                Value = entity.Price.Value,
                IsDollar = entity.Price.IsDollar,
                ShowingPrice = entity.Price.ShowingPrice
            },
            LocationAd = new DTOs.Common.LocationAdResponseDto
            {
                LocationIds = entity.LocationAd.LocationIds,
                FullAddressArabic = entity.LocationAd.FullAddressArabic,
                FullAddressKurdish = entity.LocationAd.FullAddressKurdish,
                Street = entity.LocationAd.Street
            },
            Images = entity.Images.Select(img => new DTOs.Common.AdImageDto
            {
                ImageId = img.ImageId,
                ImageUrl = img.ImageUrl,
                Order = img.Order
            }).ToList(),
            Status = (int)entity.Status,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            ImageCount = entity.ImageCount,
            ViewsCount = entity.ViewsCount,
            Priority = entity.Priority,
            Slug = entity.Slug,
            Category = new DTOs.Common.CategoryResponseDto
            {
                CategoryJoins = entity.Category.CategoryJoins,
                CategoryIds = entity.Category.CategoryIds
            },
            Specs = new ServiceSpecsDto
            {
                PaymentPeriod = entity.PaymentPeriod,
                DailyAvailability = entity.DailyAvailability?.Select(da => new DailyAvailabilityDto
                {
                    DayWeek = da.DayWeek,
                    IsAvailable = da.IsAvailable,
                    Is24Hours = da.Is24Hours,
                    TimeSlots = da.TimeSlots?.Select(ts => new TimeSlotDto
                    {
                        OpeningTime = ts.OpeningTime,
                        ClosingTime = ts.ClosingTime
                    }).ToList()
                }).ToList()
            }
        };
    }

    // Maps form data to CreateServiceAdDto - Used by: CategoryDtoMapper.MapFormToDto
    public static CreateServiceAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateServiceAdDto
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
            PaymentPeriod = form.TryGetValue("PaymentPeriod", out var period) &&
                           !string.IsNullOrWhiteSpace(period) &&
                           Enum.TryParse<Domain.Entities.Ads.JobsServices.Enums.PaymentPeriod>(period, out var pp) ? pp : null,
            DailyAvailability = form.TryGetValue("DailyAvailability", out var availability) && !string.IsNullOrWhiteSpace(availability)
                ? JsonSerializer.Deserialize<List<DailyAvailabilityDto>>(availability.ToString()) : null
        };
    }

    // Maps form data to ServiceAdDto for updates - Used by: AdService.UpdateAdAsync
    public static ServiceAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new ServiceAdDto
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
            PaymentPeriod = form.TryGetValue("PaymentPeriod", out var period) &&
                           !string.IsNullOrWhiteSpace(period) &&
                           Enum.TryParse<Domain.Entities.Ads.JobsServices.Enums.PaymentPeriod>(period, out var pp) ? pp : null,
            DailyAvailability = form.TryGetValue("DailyAvailability", out var availability) && !string.IsNullOrWhiteSpace(availability)
                ? JsonSerializer.Deserialize<List<DailyAvailabilityDto>>(availability.ToString()) : null
        };
    }

    // Updates Service-specific fields on existing Service entity - Used by: AdService.UpdateAdAsync
    public static void UpdateAttributes(Ad ad, ServiceAdDto dto)
    {
        if (ad is Service service)
        {
            if (dto.PaymentPeriod.HasValue)
                service.PaymentPeriod = dto.PaymentPeriod;
            
            if (dto.DailyAvailability != null)
                service.DailyAvailability = dto.DailyAvailability.Select(da => new DailyAvailability
                {
                    DayWeek = da.DayWeek ?? default,
                    IsAvailable = da.IsAvailable ?? default,
                    Is24Hours = da.Is24Hours ?? default,
                    TimeSlots = da.TimeSlots?.Select(ts => new TimeSlot
                    {
                        OpeningTime = ts.OpeningTime ?? string.Empty,
                        ClosingTime = ts.ClosingTime ?? string.Empty
                    }).ToList() ?? new List<TimeSlot>()
                }).ToList();
        }
    }
}
