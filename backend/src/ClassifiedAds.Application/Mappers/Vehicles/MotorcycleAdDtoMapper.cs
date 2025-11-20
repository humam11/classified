using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Vehicles;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Vehicles;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers.Vehicles;

public static class MotorcycleAdDtoMapper
{
    public static Motorcycle MapToEntity(
        CreateMotorcycleAdDto dto,
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

        return new Motorcycle
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
            FuelType = dto.FuelType,
            EnginePower = dto.EnginePower,
            FuelTankCapacity = dto.FuelTankCapacity,
            MotorcycleDriveType = dto.MotorcycleDriveType,
            GearCount = dto.GearCount,
            ModelId = dto.ModelId
        };
    }

    public static GetMotorcycleAdDto MapToDto(Motorcycle entity)
    {
        return new GetMotorcycleAdDto
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
            Specs = new MotorcycleSpecsDto
            {
                FuelType = entity.FuelType,
                EnginePower = entity.EnginePower,
                FuelTankCapacity = entity.FuelTankCapacity,
                MotorcycleDriveType = entity.MotorcycleDriveType,
                GearCount = entity.GearCount,
                ModelId = entity.ModelId
            }
        };
    }

    public static CreateMotorcycleAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateMotorcycleAdDto
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
            FuelType = form.TryGetValue("FuelType", out var fuelType) &&
                      !string.IsNullOrWhiteSpace(fuelType) &&
                      Enum.TryParse<Domain.Entities.Ads.Vehicles.Enums.FuelType>(fuelType, out var ft) ? ft : null,
            EnginePower = form.TryGetValue("EnginePower", out var enginePower) &&
                         !string.IsNullOrWhiteSpace(enginePower) &&
                         ushort.TryParse(enginePower, out var ep) ? ep : null,
            FuelTankCapacity = form.TryGetValue("FuelTankCapacity", out var fuelTank) &&
                              !string.IsNullOrWhiteSpace(fuelTank) &&
                              ushort.TryParse(fuelTank, out var ftc) ? ftc : null,
            MotorcycleDriveType = form.TryGetValue("MotorcycleDriveType", out var driveType) &&
                                 !string.IsNullOrWhiteSpace(driveType) &&
                                 Enum.TryParse<Domain.Entities.Ads.Vehicles.Enums.MotorcycleDriveType>(driveType, out var mdt) ? mdt : null,
            GearCount = form.TryGetValue("GearCount", out var gearCount) &&
                       !string.IsNullOrWhiteSpace(gearCount) &&
                       byte.TryParse(gearCount, out var gc) ? gc : null,
            ModelId = form.TryGetValue("ModelId", out var modelId) &&
                     !string.IsNullOrWhiteSpace(modelId) &&
                     Guid.TryParse(modelId, out var mid) ? mid : null
        };
    }

    public static MotorcycleAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new MotorcycleAdDto
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
            FuelType = form.TryGetValue("FuelType", out var fuelType) &&
                      !string.IsNullOrWhiteSpace(fuelType) &&
                      Enum.TryParse<Domain.Entities.Ads.Vehicles.Enums.FuelType>(fuelType, out var ft) ? ft : null,
            EnginePower = form.TryGetValue("EnginePower", out var enginePower) &&
                         !string.IsNullOrWhiteSpace(enginePower) &&
                         ushort.TryParse(enginePower, out var ep) ? ep : null,
            FuelTankCapacity = form.TryGetValue("FuelTankCapacity", out var fuelTank) &&
                              !string.IsNullOrWhiteSpace(fuelTank) &&
                              ushort.TryParse(fuelTank, out var ftc) ? ftc : null,
            MotorcycleDriveType = form.TryGetValue("MotorcycleDriveType", out var driveType) &&
                                 !string.IsNullOrWhiteSpace(driveType) &&
                                 Enum.TryParse<Domain.Entities.Ads.Vehicles.Enums.MotorcycleDriveType>(driveType, out var mdt) ? mdt : null,
            GearCount = form.TryGetValue("GearCount", out var gearCount) &&
                       !string.IsNullOrWhiteSpace(gearCount) &&
                       byte.TryParse(gearCount, out var gc) ? gc : null,
            ModelId = form.TryGetValue("ModelId", out var modelId) &&
                     !string.IsNullOrWhiteSpace(modelId) &&
                     Guid.TryParse(modelId, out var mid) ? mid : null
        };
    }

    public static void UpdateAttributes(Ad ad, MotorcycleAdDto dto)
    {
        if (ad is Motorcycle motorcycle)
        {
            if (dto.FuelType.HasValue)
                motorcycle.FuelType = dto.FuelType;
            if (dto.EnginePower.HasValue)
                motorcycle.EnginePower = dto.EnginePower;
            if (dto.FuelTankCapacity.HasValue)
                motorcycle.FuelTankCapacity = dto.FuelTankCapacity;
            if (dto.MotorcycleDriveType.HasValue)
                motorcycle.MotorcycleDriveType = dto.MotorcycleDriveType;
            if (dto.GearCount.HasValue)
                motorcycle.GearCount = dto.GearCount;
            if (dto.ModelId.HasValue)
                motorcycle.ModelId = dto.ModelId;
        }
    }
}
