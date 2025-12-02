using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Vehicles;
using ClassifiedAds.Application.Interfaces;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Vehicles;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;
using static ClassifiedAds.Application.Common.FormParsingHelpers;

namespace ClassifiedAds.Application.Mappers.Vehicles;

public static class CarAdDtoMapper
{
    // Async mapper that handles brand/model/release resolution internally
    public static async Task<Car> MapToEntityAsync(
        CreateCarAdDto dto,
        string slug,
        Guid userId,
        List<string> categoriesSlugsArabic,
        List<string> categoriesSlugsKurdish,
        List<ushort> locationIds,
        string fullAddressArabic,
        string fullAddressKurdish,
        string categorySlug,
        string language,
        IBrandModelReleaseService brandModelReleaseService)
    {
        if (string.IsNullOrEmpty(dto.Title) || !dto.IsDollar.HasValue || !dto.PriceValue.HasValue)
            throw new ArgumentException("Required fields are missing");

        if (string.IsNullOrEmpty(dto.BrandName) || string.IsNullOrEmpty(dto.ModelName) || string.IsNullOrEmpty(dto.ReleaseYear))
            throw new ArgumentException("BrandName, ModelName, and ReleaseYear are required for Car ads");

        // Resolve brand, model, and release
        var (modelId, modelsSlugs) = await brandModelReleaseService.ResolveBrandModelAsync(
            categorySlug, language, dto.BrandName, dto.ModelName);
        var (_, releaseYear) = await brandModelReleaseService.ResolveReleaseAsync(modelId, dto.ReleaseYear);

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
                CategoriesSlugsArabic = categoriesSlugsArabic,
                CategoriesSlugsKurdish = categoriesSlugsKurdish
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
            ModelsSlugs = modelsSlugs,
            ReleaseYear = releaseYear
        };
    }

    public static GetCarAdDto MapToDto(Car entity)
    {
        return new GetCarAdDto
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
                CategoriesSlugsArabic = entity.Category.CategoriesSlugsArabic, 
                CategoriesSlugsKurdish = entity.Category.CategoriesSlugsKurdish 
            },
            Specs = new CarSpecsDto
            {
                FuelType = entity.FuelType,
                EnginePower = entity.EnginePower,
                FuelTankCapacity = entity.FuelTankCapacity,
                DistanceKm = entity.DistanceKm,
                EngineDescription = entity.EngineDescription,
                Cylinders = entity.Cylinders,
                Transmission = entity.Transmission,
                DriveType = entity.DriveType,
                Color = entity.Color,
                ModelsSlugs = entity.ModelsSlugs,
                ReleaseYear = entity.ReleaseYear
            }
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
            FuelType = ParseEnum<Domain.Entities.Ads.Vehicles.Enums.FuelType>(form, "FuelType"),
            EnginePower = ParseUShort(form, "EnginePower"),
            FuelTankCapacity = ParseUShort(form, "FuelTankCapacity"),
            DistanceKm = ParseInt(form, "DistanceKm"),
            EngineDescription = form.TryGetValue("EngineDescription", out var engineDesc) && 
                               !string.IsNullOrWhiteSpace(engineDesc) ? engineDesc.ToString() : null,
            Cylinders = ParseByte(form, "Cylinders"),
            Transmission = ParseEnum<Domain.Entities.Ads.Vehicles.Enums.Transmission>(form, "Transmission"),
            DriveType = ParseEnum<Domain.Entities.Ads.Vehicles.Enums.CarDriveType>(form, "DriveType"),
            Color = form.TryGetValue("Color", out var color) && !string.IsNullOrWhiteSpace(color) ? color.ToString() : null,
            BrandName = form.TryGetValue("BrandName", out var brandName) && !string.IsNullOrWhiteSpace(brandName) ? brandName.ToString() : null,
            ModelName = form.TryGetValue("ModelName", out var modelName) && !string.IsNullOrWhiteSpace(modelName) ? modelName.ToString() : null,
            ReleaseYear = form.TryGetValue("ReleaseYear", out var releaseYear) && !string.IsNullOrWhiteSpace(releaseYear) ? releaseYear.ToString() : null
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
            FuelType = ParseEnum<Domain.Entities.Ads.Vehicles.Enums.FuelType>(form, "FuelType"),
            EnginePower = ParseUShort(form, "EnginePower"),
            FuelTankCapacity = ParseUShort(form, "FuelTankCapacity"),
            DistanceKm = ParseInt(form, "DistanceKm"),
            EngineDescription = form.TryGetValue("EngineDescription", out var engineDesc) && 
                               !string.IsNullOrWhiteSpace(engineDesc) ? engineDesc.ToString() : null,
            Cylinders = ParseByte(form, "Cylinders"),
            Transmission = ParseEnum<Domain.Entities.Ads.Vehicles.Enums.Transmission>(form, "Transmission"),
            DriveType = ParseEnum<Domain.Entities.Ads.Vehicles.Enums.CarDriveType>(form, "DriveType"),
            Color = form.TryGetValue("Color", out var color) && !string.IsNullOrWhiteSpace(color) ? color.ToString() : null,
            BrandName = form.TryGetValue("BrandName", out var brandName) && !string.IsNullOrWhiteSpace(brandName) ? brandName.ToString() : null,
            ModelName = form.TryGetValue("ModelName", out var modelName) && !string.IsNullOrWhiteSpace(modelName) ? modelName.ToString() : null,
            ReleaseYear = form.TryGetValue("ReleaseYear", out var releaseYear) && !string.IsNullOrWhiteSpace(releaseYear) ? releaseYear.ToString() : null
        };
    }

    public static void UpdateAttributes(Ad ad, CarAdDto dto)
    {
        if (ad is Car car)
        {
            if (dto.FuelType.HasValue) car.FuelType = dto.FuelType;
            if (dto.EnginePower.HasValue) car.EnginePower = dto.EnginePower;
            if (dto.FuelTankCapacity.HasValue) car.FuelTankCapacity = dto.FuelTankCapacity;
            if (dto.DistanceKm.HasValue) car.DistanceKm = dto.DistanceKm;
            if (!string.IsNullOrEmpty(dto.EngineDescription)) car.EngineDescription = dto.EngineDescription;
            if (dto.Cylinders.HasValue) car.Cylinders = dto.Cylinders;
            if (dto.Transmission.HasValue) car.Transmission = dto.Transmission;
            if (dto.DriveType.HasValue) car.DriveType = dto.DriveType;
            if (!string.IsNullOrEmpty(dto.Color)) car.Color = dto.Color;
            // Note: BrandName/ModelName/ReleaseYear update requires calling BrandModelReleaseService - handled in AdService
        }
    }

}
