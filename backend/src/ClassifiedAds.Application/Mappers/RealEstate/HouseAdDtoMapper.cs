using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.RealEstate;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.RealEstate;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers;

public static class HouseAdDtoMapper
{
    public static House MapToEntity(
        CreateHouseAdDto dto,
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
            Category = new DTOs.Common.CategoryResponseDto { CategoryJoins = entity.Category.CategoryJoins, CategoryIds = entity.Category.CategoryIds },
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
            Area = form.TryGetValue("Area", out var area) &&
                  !string.IsNullOrWhiteSpace(area) &&
                  float.TryParse(area, out var a) ? a : null,
            Floors = form.TryGetValue("Floors", out var floors) &&
                    !string.IsNullOrWhiteSpace(floors) &&
                    byte.TryParse(floors, out var fl) ? fl : null,
            Bedrooms = form.TryGetValue("Bedrooms", out var bedrooms) &&
                      !string.IsNullOrWhiteSpace(bedrooms) &&
                      byte.TryParse(bedrooms, out var br) ? br : null,
            Bathrooms = form.TryGetValue("Bathrooms", out var bathrooms) &&
                       !string.IsNullOrWhiteSpace(bathrooms) &&
                       byte.TryParse(bathrooms, out var ba) ? ba : null,
            Garage = form.TryGetValue("Garage", out var garage) &&
                    !string.IsNullOrWhiteSpace(garage) &&
                    Enum.TryParse<YesNo>(garage, out var ga) ? ga : null,
            Garden = form.TryGetValue("Garden", out var garden) &&
                    !string.IsNullOrWhiteSpace(garden) &&
                    Enum.TryParse<YesNo>(garden, out var gd) ? gd : null
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
            Area = form.TryGetValue("Area", out var area) &&
                  !string.IsNullOrWhiteSpace(area) &&
                  float.TryParse(area, out var a) ? a : null,
            Floors = form.TryGetValue("Floors", out var floors) &&
                    !string.IsNullOrWhiteSpace(floors) &&
                    byte.TryParse(floors, out var fl) ? fl : null,
            Bedrooms = form.TryGetValue("Bedrooms", out var bedrooms) &&
                      !string.IsNullOrWhiteSpace(bedrooms) &&
                      byte.TryParse(bedrooms, out var br) ? br : null,
            Bathrooms = form.TryGetValue("Bathrooms", out var bathrooms) &&
                       !string.IsNullOrWhiteSpace(bathrooms) &&
                       byte.TryParse(bathrooms, out var ba) ? ba : null,
            Garage = form.TryGetValue("Garage", out var garage) &&
                    !string.IsNullOrWhiteSpace(garage) &&
                    Enum.TryParse<YesNo>(garage, out var ga) ? ga : null,
            Garden = form.TryGetValue("Garden", out var garden) &&
                    !string.IsNullOrWhiteSpace(garden) &&
                    Enum.TryParse<YesNo>(garden, out var gd) ? gd : null
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
