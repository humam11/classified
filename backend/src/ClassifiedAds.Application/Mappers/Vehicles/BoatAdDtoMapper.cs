using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Vehicles;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Vehicles;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;
using static ClassifiedAds.Application.Common.FormParsingHelpers;

namespace ClassifiedAds.Application.Mappers.Vehicles;

public static class BoatAdDtoMapper
{
    public static Boat MapToEntity(CreateBoatAdDto dto, string slug, Guid userId, List<string> categoriesSlugsArabic, List<string> categoriesSlugsKurdish, List<ushort> locationIds, string fullAddressArabic, string fullAddressKurdish)
    {
        if (string.IsNullOrEmpty(dto.Title) || !dto.IsDollar.HasValue || !dto.PriceValue.HasValue)
            throw new ArgumentException("Required fields are missing");

        return new Boat
        {
            Title = dto.Title,
            Description = dto.Description ?? string.Empty,
            Price = new Price { IsDollar = dto.IsDollar.Value, Value = dto.PriceValue.Value, ShowingPrice = AdDtoMapper.FormatShowingPrice(dto.IsDollar.Value, dto.PriceValue.Value) },
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
            FuelType = dto.FuelType,
            EnginePower = dto.EnginePower,
            FuelTankCapacity = dto.FuelTankCapacity,
            Length = dto.Length,
            Capacity = dto.Capacity
        };
    }

    public static GetBoatAdDto MapToDto(Boat entity)
    {
        return new GetBoatAdDto
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
            Specs = new BoatSpecsDto
            {
                FuelType = entity.FuelType,
                EnginePower = entity.EnginePower,
                FuelTankCapacity = entity.FuelTankCapacity,
                Length = entity.Length,
                Capacity = entity.Capacity
            }
        };
    }

    public static CreateBoatAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateBoatAdDto
        {
            Title = baseDto.Title, Description = baseDto.Description, IsDollar = baseDto.IsDollar, PriceValue = baseDto.PriceValue,
            City = baseDto.City, Region = baseDto.Region, Neighborhood = baseDto.Neighborhood, Street = baseDto.Street, ImageFiles = baseDto.ImageFiles,
            FuelType = ParseEnum<Domain.Entities.Ads.Vehicles.Enums.FuelType>(form, "FuelType"),
            EnginePower = ParseUShort(form, "EnginePower"),
            FuelTankCapacity = ParseUShort(form, "FuelTankCapacity"),
            Length = ParseFloat(form, "Length"),
            Capacity = ParseByte(form, "Capacity")
        };
    }

    public static BoatAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new BoatAdDto
        {
            Title = baseDto.Title, Description = baseDto.Description, IsDollar = baseDto.IsDollar, PriceValue = baseDto.PriceValue,
            City = baseDto.City, Region = baseDto.Region, Neighborhood = baseDto.Neighborhood, Street = baseDto.Street, ImageFiles = baseDto.ImageFiles,
            FuelType = ParseEnum<Domain.Entities.Ads.Vehicles.Enums.FuelType>(form, "FuelType"),
            EnginePower = ParseUShort(form, "EnginePower"),
            FuelTankCapacity = ParseUShort(form, "FuelTankCapacity"),
            Length = ParseFloat(form, "Length"),
            Capacity = ParseByte(form, "Capacity")
        };
    }

    public static void UpdateAttributes(Ad ad, BoatAdDto dto)
    {
        if (ad is Boat boat)
        {
            if (dto.FuelType.HasValue) boat.FuelType = dto.FuelType;
            if (dto.EnginePower.HasValue) boat.EnginePower = dto.EnginePower;
            if (dto.FuelTankCapacity.HasValue) boat.FuelTankCapacity = dto.FuelTankCapacity;
            if (dto.Length.HasValue) boat.Length = dto.Length;
            if (dto.Capacity.HasValue) boat.Capacity = dto.Capacity;
        }
    }
}
