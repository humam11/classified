using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Vehicles;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Vehicles;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers.Vehicles;

public static class BoatAdDtoMapper
{
    public static Boat MapToEntity(CreateBoatAdDto dto, string slug, Guid userId, List<ushort> categoryIds, byte categoryJoins, List<ushort> locationIds, string fullAddressArabic, string fullAddressKurdish)
    {
        if (string.IsNullOrEmpty(dto.Title) || !dto.IsDollar.HasValue || !dto.PriceValue.HasValue)
            throw new ArgumentException("Required fields are missing");

        return new Boat
        {
            Title = dto.Title,
            Description = dto.Description ?? string.Empty,
            Price = new Price { IsDollar = dto.IsDollar.Value, Value = dto.PriceValue.Value, ShowingPrice = AdDtoMapper.FormatShowingPrice(dto.IsDollar.Value, dto.PriceValue.Value) },
            Category = new Category { CategoryJoins = categoryJoins, CategoryIds = categoryIds },
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

    // Maps Boat entity to BoatAdDto - Used by: AdService.GetAdByIdAsync
    public static BoatAdDto MapToDto(Boat entity)
    {
        return new BoatAdDto
        {
            Title = entity.Title,
            Description = entity.Description,
            IsDollar = entity.Price.IsDollar,
            PriceValue = entity.Price.Value,
            City = string.Empty, // TODO: Extract from FullAddressArabic/Kurdish
            Region = string.Empty,
            Neighborhood = string.Empty,
            Street = entity.LocationAd.Street,
            FuelType = entity.FuelType,
            EnginePower = entity.EnginePower,
            FuelTankCapacity = entity.FuelTankCapacity,
            Length = entity.Length,
            Capacity = entity.Capacity
        };
    }

    public static CreateBoatAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateBoatAdDto
        {
            Title = baseDto.Title, Description = baseDto.Description, IsDollar = baseDto.IsDollar, PriceValue = baseDto.PriceValue,
            City = baseDto.City, Region = baseDto.Region, Neighborhood = baseDto.Neighborhood, Street = baseDto.Street, ImageFiles = baseDto.ImageFiles,
            FuelType = form.TryGetValue("FuelType", out var ft) && !string.IsNullOrWhiteSpace(ft) && Enum.TryParse<Domain.Entities.Ads.Vehicles.Enums.FuelType>(ft, out var fuelType) ? fuelType : null,
            EnginePower = form.TryGetValue("EnginePower", out var ep) && !string.IsNullOrWhiteSpace(ep) && ushort.TryParse(ep, out var enginePower) ? enginePower : null,
            FuelTankCapacity = form.TryGetValue("FuelTankCapacity", out var ftc) && !string.IsNullOrWhiteSpace(ftc) && ushort.TryParse(ftc, out var fuelTank) ? fuelTank : null,
            Length = form.TryGetValue("Length", out var len) && !string.IsNullOrWhiteSpace(len) && float.TryParse(len, out var length) ? length : null,
            Capacity = form.TryGetValue("Capacity", out var cap) && !string.IsNullOrWhiteSpace(cap) && byte.TryParse(cap, out var capacity) ? capacity : null
        };
    }

    public static BoatAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new BoatAdDto
        {
            Title = baseDto.Title, Description = baseDto.Description, IsDollar = baseDto.IsDollar, PriceValue = baseDto.PriceValue,
            City = baseDto.City, Region = baseDto.Region, Neighborhood = baseDto.Neighborhood, Street = baseDto.Street, ImageFiles = baseDto.ImageFiles,
            FuelType = form.TryGetValue("FuelType", out var ft) && !string.IsNullOrWhiteSpace(ft) && Enum.TryParse<Domain.Entities.Ads.Vehicles.Enums.FuelType>(ft, out var fuelType) ? fuelType : null,
            EnginePower = form.TryGetValue("EnginePower", out var ep) && !string.IsNullOrWhiteSpace(ep) && ushort.TryParse(ep, out var enginePower) ? enginePower : null,
            FuelTankCapacity = form.TryGetValue("FuelTankCapacity", out var ftc) && !string.IsNullOrWhiteSpace(ftc) && ushort.TryParse(ftc, out var fuelTank) ? fuelTank : null,
            Length = form.TryGetValue("Length", out var len) && !string.IsNullOrWhiteSpace(len) && float.TryParse(len, out var length) ? length : null,
            Capacity = form.TryGetValue("Capacity", out var cap) && !string.IsNullOrWhiteSpace(cap) && byte.TryParse(cap, out var capacity) ? capacity : null
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
