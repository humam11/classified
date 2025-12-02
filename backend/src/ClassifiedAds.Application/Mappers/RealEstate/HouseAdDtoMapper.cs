using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.RealEstate;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.RealEstate;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;
using static ClassifiedAds.Application.Common.FormParsingHelpers;


namespace ClassifiedAds.Application.Mappers;

public static class HouseAdDtoMapper
{
    public static House MapToEntity(
        CreateHouseAdDto dto,
        string slug,
        Guid userId,
        List<string> categoriesSlugsArabic, List<string> categoriesSlugsKurdish,
        List<ushort> locationIds,
        string fullAddressArabic,
        string fullAddressKurdish)
    {
        if (string.IsNullOrEmpty(dto.Title) || !dto.IsDollar.HasValue || !dto.PriceValue.HasValue)
        {
            throw new ArgumentException("Required fields are missing");
        }

        string showingPrice = AdDtoMapper.FormatShowingPrice(dto.IsDollar.Value, dto.PriceValue.Value);

        return new House
        {
            Title = dto.Title,
            Description = dto.Description ?? string.Empty,
            Price = new Price
            {
                IsDollar = dto.IsDollar.Value,
                Value = dto.PriceValue.Value,
                ShowingPrice = showingPrice
            },
            Category = new Category { CategoriesSlugsArabic = categoriesSlugsArabic, CategoriesSlugsKurdish = categoriesSlugsKurdish },
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
            Area = dto.Area,
            Floors = dto.Floors,
            Bedrooms = dto.Bedrooms,
            Bathrooms = dto.Bathrooms,
            Garage = dto.Garage,
            Garden = dto.Garden
        };
    }

    public static GetHouseAdDto MapToDto(House entity)
    {
        return new GetHouseAdDto
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
            Specs = new HouseSpecsDto
            {
                Area = entity.Area,
                Floors = entity.Floors,
                Bedrooms = entity.Bedrooms,
                Bathrooms = entity.Bathrooms,
                Garage = entity.Garage,
                Garden = entity.Garden
            }
        };
    }

    public static CreateHouseAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateHouseAdDto
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
            Area = FormParsingHelpers.ParseFloat(form, "Area"),
            Floors = FormParsingHelpers.ParseByte(form, "Floors"),
            Bedrooms = FormParsingHelpers.ParseByte(form, "Bedrooms"),
            Bathrooms = FormParsingHelpers.ParseByte(form, "Bathrooms"),
            Garage = FormParsingHelpers.ParseEnum<YesNo>(form, "Garage"),
            Garden = FormParsingHelpers.ParseEnum<YesNo>(form, "Garden")
        };
    }

    public static HouseAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new HouseAdDto
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
            Area = FormParsingHelpers.ParseFloat(form, "Area"),
            Floors = FormParsingHelpers.ParseByte(form, "Floors"),
            Bedrooms = FormParsingHelpers.ParseByte(form, "Bedrooms"),
            Bathrooms = FormParsingHelpers.ParseByte(form, "Bathrooms"),
            Garage = FormParsingHelpers.ParseEnum<YesNo>(form, "Garage"),
            Garden = FormParsingHelpers.ParseEnum<YesNo>(form, "Garden")
        };
    }

    public static void UpdateAttributes(Ad ad, HouseAdDto dto)
    {
        if (ad is House house)
        {
            if (dto.Area.HasValue)
                house.Area = dto.Area;
            if (dto.Floors.HasValue)
                house.Floors = dto.Floors;
            if (dto.Bedrooms.HasValue)
                house.Bedrooms = dto.Bedrooms;
            if (dto.Bathrooms.HasValue)
                house.Bathrooms = dto.Bathrooms;
            if (dto.Garage.HasValue)
                house.Garage = dto.Garage;
            if (dto.Garden.HasValue)
                house.Garden = dto.Garden;
        }
    }
}
