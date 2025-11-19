using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Electronics;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers;

public static class ElectronicAdDtoMapper
{
    public static Electronic MapToEntity(
        CreateElectronicAdDto dto,
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

        return new Electronic
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
            WarrantyMonths = dto.WarrantyMonths
        };
    }

    public static CreateElectronicAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateElectronicAdDto
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
                            byte.TryParse(warranty, out var wm) ? wm : null
        };
    }

    public static ElectronicAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new ElectronicAdDto
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
                            byte.TryParse(warranty, out var wm) ? wm : null
        };
    }

    public static void UpdateAttributes(Ad ad, ElectronicAdDto dto)
    {
        if (ad is Electronic electronic)
        {
            if (dto.IsNew.HasValue)
                electronic.IsNew = dto.IsNew;
            if (dto.WarrantyMonths.HasValue)
                electronic.WarrantyMonths = dto.WarrantyMonths;
        }
    }
}
