using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Vehicles.HeavyEquipment;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers.Vehicles.HeavyEquipment;

public static class ExcavatorAdDtoMapper
{
    public static Excavator MapToEntity(CreateExcavatorAdDto dto, string slug, Guid userId, List<ushort> categoryIds, byte categoryJoins, List<ushort> locationIds, string fullAddressArabic, string fullAddressKurdish)
    {
        if (string.IsNullOrEmpty(dto.Title) || !dto.IsDollar.HasValue || !dto.PriceValue.HasValue)
            throw new ArgumentException("Required fields are missing");

        return new Excavator
        {
            Title = dto.Title, Description = dto.Description ?? string.Empty,
            Price = new Price { IsDollar = dto.IsDollar.Value, Value = dto.PriceValue.Value, ShowingPrice = AdDtoMapper.FormatShowingPrice(dto.IsDollar.Value, dto.PriceValue.Value) },
            Category = new Category { CategoryJoins = categoryJoins, CategoryIds = categoryIds },
            LocationAd = new LocationAd { LocationIds = locationIds, Street = dto.Street, FullAddressArabic = fullAddressArabic, FullAddressKurdish = fullAddressKurdish },
            Images = new List<AdImage>(), Status = Status.Active, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow,
            ImageCount = 0, ViewsCount = 0, UserId = userId, Priority = 0, Slug = slug,
            FuelType = dto.FuelType, EnginePower = dto.EnginePower, FuelTankCapacity = dto.FuelTankCapacity,
            OperatingMass = dto.OperatingMass, Weight = dto.Weight,
            BucketCapacity = dto.BucketCapacity, DiggingDepth = dto.DiggingDepth
        };
    }

    public static GetExcavatorAdDto MapToDto(Excavator entity)
    {
        return new GetExcavatorAdDto
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
            Specs = new ExcavatorSpecsDto
            {
                FuelType = entity.FuelType,
                EnginePower = entity.EnginePower,
                FuelTankCapacity = entity.FuelTankCapacity,
                OperatingMass = entity.OperatingMass,
                Weight = entity.Weight,
                BucketCapacity = entity.BucketCapacity,
                DiggingDepth = entity.DiggingDepth
            }
        };
    }

    public static CreateExcavatorAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateExcavatorAdDto
        {
            Title = baseDto.Title, Description = baseDto.Description, IsDollar = baseDto.IsDollar, PriceValue = baseDto.PriceValue,
            City = baseDto.City, Region = baseDto.Region, Neighborhood = baseDto.Neighborhood, Street = baseDto.Street, ImageFiles = baseDto.ImageFiles,
            FuelType = form.TryGetValue("FuelType", out var ft) && !string.IsNullOrWhiteSpace(ft) && Enum.TryParse<Domain.Entities.Ads.Vehicles.Enums.FuelType>(ft, out var fuelType) ? fuelType : null,
            EnginePower = form.TryGetValue("EnginePower", out var ep) && !string.IsNullOrWhiteSpace(ep) && ushort.TryParse(ep, out var enginePower) ? enginePower : null,
            FuelTankCapacity = form.TryGetValue("FuelTankCapacity", out var ftc) && !string.IsNullOrWhiteSpace(ftc) && ushort.TryParse(ftc, out var fuelTank) ? fuelTank : null,
            OperatingMass = form.TryGetValue("OperatingMass", out var om) && !string.IsNullOrWhiteSpace(om) && float.TryParse(om, out var operatingMass) ? operatingMass : null,
            Weight = form.TryGetValue("Weight", out var w) && !string.IsNullOrWhiteSpace(w) && float.TryParse(w, out var weight) ? weight : null,
            BucketCapacity = form.TryGetValue("BucketCapacity", out var bc) && !string.IsNullOrWhiteSpace(bc) && float.TryParse(bc, out var bucket) ? bucket : null,
            DiggingDepth = form.TryGetValue("DiggingDepth", out var dd) && !string.IsNullOrWhiteSpace(dd) && float.TryParse(dd, out var digging) ? digging : null
        };
    }

    public static ExcavatorAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new ExcavatorAdDto
        {
            Title = baseDto.Title, Description = baseDto.Description, IsDollar = baseDto.IsDollar, PriceValue = baseDto.PriceValue,
            City = baseDto.City, Region = baseDto.Region, Neighborhood = baseDto.Neighborhood, Street = baseDto.Street, ImageFiles = baseDto.ImageFiles,
            FuelType = form.TryGetValue("FuelType", out var ft) && !string.IsNullOrWhiteSpace(ft) && Enum.TryParse<Domain.Entities.Ads.Vehicles.Enums.FuelType>(ft, out var fuelType) ? fuelType : null,
            EnginePower = form.TryGetValue("EnginePower", out var ep) && !string.IsNullOrWhiteSpace(ep) && ushort.TryParse(ep, out var enginePower) ? enginePower : null,
            FuelTankCapacity = form.TryGetValue("FuelTankCapacity", out var ftc) && !string.IsNullOrWhiteSpace(ftc) && ushort.TryParse(ftc, out var fuelTank) ? fuelTank : null,
            OperatingMass = form.TryGetValue("OperatingMass", out var om) && !string.IsNullOrWhiteSpace(om) && float.TryParse(om, out var operatingMass) ? operatingMass : null,
            Weight = form.TryGetValue("Weight", out var w) && !string.IsNullOrWhiteSpace(w) && float.TryParse(w, out var weight) ? weight : null,
            BucketCapacity = form.TryGetValue("BucketCapacity", out var bc) && !string.IsNullOrWhiteSpace(bc) && float.TryParse(bc, out var bucket) ? bucket : null,
            DiggingDepth = form.TryGetValue("DiggingDepth", out var dd) && !string.IsNullOrWhiteSpace(dd) && float.TryParse(dd, out var digging) ? digging : null
        };
    }

    public static void UpdateAttributes(Ad ad, ExcavatorAdDto dto)
    {
        if (ad is Excavator excavator)
        {
            if (dto.FuelType.HasValue) excavator.FuelType = dto.FuelType;
            if (dto.EnginePower.HasValue) excavator.EnginePower = dto.EnginePower;
            if (dto.FuelTankCapacity.HasValue) excavator.FuelTankCapacity = dto.FuelTankCapacity;
            if (dto.OperatingMass.HasValue) excavator.OperatingMass = dto.OperatingMass;
            if (dto.Weight.HasValue) excavator.Weight = dto.Weight;
            if (dto.BucketCapacity.HasValue) excavator.BucketCapacity = dto.BucketCapacity;
            if (dto.DiggingDepth.HasValue) excavator.DiggingDepth = dto.DiggingDepth;
        }
    }
}
