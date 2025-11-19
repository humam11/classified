using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Miscellaneous;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers;

public static class ShoeAdDtoMapper
{
    public static Shoe MapToEntity(
        CreateShoeAdDto dto,
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

        return new Shoe
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
            Size = dto.Size
        };
    }

    public static CreateShoeAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateShoeAdDto
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
                   Enum.TryParse<YesNo>(isNew, out var yn) ? yn : null,
            Size = form.TryGetValue("Size", out var size) &&
                  !string.IsNullOrWhiteSpace(size) &&
                  byte.TryParse(size, out var s) ? s : null
        };
    }

    public static ShoeAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new ShoeAdDto
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
                   Enum.TryParse<YesNo>(isNew, out var yn) ? yn : null,
            Size = form.TryGetValue("Size", out var size) &&
                  !string.IsNullOrWhiteSpace(size) &&
                  byte.TryParse(size, out var sz) ? sz : null
        };
    }

    public static void UpdateAttributes(Ad ad, ShoeAdDto dto)
    {
        if (ad is Shoe shoe)
        {
            if (dto.IsNew.HasValue)
                shoe.IsNew = dto.IsNew;
            if (dto.Size.HasValue)
                shoe.Size = dto.Size;
        }
    }
}
