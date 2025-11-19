using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Vehicles;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Vehicles;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers.Vehicles;

public static class CarAdDtoMapper
{
    public static Car MapToEntity(
        CreateCarAdDto dto,
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

        return new Car
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
            DistanceKm = dto.DistanceKm,
            EngineDescription = dto.EngineDescription,
            Cylinders = dto.Cylinders,
            Transmission = dto.Transmission,
            DriveType = dto.DriveType,
            Color = dto.Color,
            ModelId = dto.ModelId,
            SubModelReleaseId = dto.SubModelReleaseId
        };
    }

    // Maps Car entity to CarAdDto - Used by: AdService.GetAdByIdAsync
    public static CarAdDto MapToDto(Car entity)
    {
        return new CarAdDto
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
            DistanceKm = entity.DistanceKm,
            EngineDescription = entity.EngineDescription,
            Cylinders = entity.Cylinders,
            Transmission = entity.Transmission,
            DriveType = entity.DriveType,
            Color = entity.Color,
            ModelId = entity.ModelId,
            SubModelReleaseId = entity.SubModelReleaseId
        };
    }

    public static CreateCarAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateCarAdDto
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
            DistanceKm = form.TryGetValue("DistanceKm", out var distance) &&
                        !string.IsNullOrWhiteSpace(distance) &&
                        int.TryParse(distance, out var dk) ? dk : null,
            EngineDescription = form.TryGetValue("EngineDescription", out var engineDesc) && 
                               !string.IsNullOrWhiteSpace(engineDesc) ? engineDesc.ToString() : null,
            Cylinders = form.TryGetValue("Cylinders", out var cylinders) &&
                       !string.IsNullOrWhiteSpace(cylinders) &&
                       byte.TryParse(cylinders, out var c) ? c : null,
            Transmission = form.TryGetValue("Transmission", out var transmission) &&
                          !string.IsNullOrWhiteSpace(transmission) &&
                          Enum.TryParse<Domain.Entities.Ads.Vehicles.Enums.Transmission>(transmission, out var t) ? t : null,
            DriveType = form.TryGetValue("DriveType", out var driveType) &&
                       !string.IsNullOrWhiteSpace(driveType) &&
                       Enum.TryParse<Domain.Entities.Ads.Vehicles.Enums.CarDriveType>(driveType, out var dt) ? dt : null,
            Color = form.TryGetValue("Color", out var color) && !string.IsNullOrWhiteSpace(color) ? color.ToString() : null,
            ModelId = form.TryGetValue("ModelId", out var modelId) &&
                     !string.IsNullOrWhiteSpace(modelId) &&
                     Guid.TryParse(modelId, out var mid) ? mid : null,
            SubModelReleaseId = form.TryGetValue("SubModelReleaseId", out var subModelId) &&
                               !string.IsNullOrWhiteSpace(subModelId) &&
                               Guid.TryParse(subModelId, out var smid) ? smid : null
        };
    }

    public static CarAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CarAdDto
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
            DistanceKm = form.TryGetValue("DistanceKm", out var distance) &&
                        !string.IsNullOrWhiteSpace(distance) &&
                        int.TryParse(distance, out var dk) ? dk : null,
            EngineDescription = form.TryGetValue("EngineDescription", out var engineDesc) && 
                               !string.IsNullOrWhiteSpace(engineDesc) ? engineDesc.ToString() : null,
            Cylinders = form.TryGetValue("Cylinders", out var cylinders) &&
                       !string.IsNullOrWhiteSpace(cylinders) &&
                       byte.TryParse(cylinders, out var c) ? c : null,
            Transmission = form.TryGetValue("Transmission", out var transmission) &&
                          !string.IsNullOrWhiteSpace(transmission) &&
                          Enum.TryParse<Domain.Entities.Ads.Vehicles.Enums.Transmission>(transmission, out var t) ? t : null,
            DriveType = form.TryGetValue("DriveType", out var driveType) &&
                       !string.IsNullOrWhiteSpace(driveType) &&
                       Enum.TryParse<Domain.Entities.Ads.Vehicles.Enums.CarDriveType>(driveType, out var dt) ? dt : null,
            Color = form.TryGetValue("Color", out var color) && !string.IsNullOrWhiteSpace(color) ? color.ToString() : null,
            ModelId = form.TryGetValue("ModelId", out var modelId) &&
                     !string.IsNullOrWhiteSpace(modelId) &&
                     Guid.TryParse(modelId, out var mid) ? mid : null,
            SubModelReleaseId = form.TryGetValue("SubModelReleaseId", out var subModelId) &&
                               !string.IsNullOrWhiteSpace(subModelId) &&
                               Guid.TryParse(subModelId, out var smid) ? smid : null
        };
    }

    public static void UpdateAttributes(Ad ad, CarAdDto dto)
    {
        if (ad is Car car)
        {
            if (dto.FuelType.HasValue)
                car.FuelType = dto.FuelType;
            if (dto.EnginePower.HasValue)
                car.EnginePower = dto.EnginePower;
            if (dto.FuelTankCapacity.HasValue)
                car.FuelTankCapacity = dto.FuelTankCapacity;
            if (dto.DistanceKm.HasValue)
                car.DistanceKm = dto.DistanceKm;
            if (!string.IsNullOrEmpty(dto.EngineDescription))
                car.EngineDescription = dto.EngineDescription;
            if (dto.Cylinders.HasValue)
                car.Cylinders = dto.Cylinders;
            if (dto.Transmission.HasValue)
                car.Transmission = dto.Transmission;
            if (dto.DriveType.HasValue)
                car.DriveType = dto.DriveType;
            if (!string.IsNullOrEmpty(dto.Color))
                car.Color = dto.Color;
            if (dto.ModelId.HasValue)
                car.ModelId = dto.ModelId;
            if (dto.SubModelReleaseId.HasValue)
                car.SubModelReleaseId = dto.SubModelReleaseId;
        }
    }
}
