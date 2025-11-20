using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Vehicles;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Vehicles;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers.Vehicles;

public static class TruckAdDtoMapper
{
    public static Truck MapToEntity(
        CreateTruckAdDto dto,
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

        return new Truck
        {
            Title = dto.Title,
            Description = dto.Description ?? string.Empty,
            Price = new Price { IsDollar = dto.IsDollar.Value, Value = dto.PriceValue.Value, ShowingPrice = showingPrice },
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
            DistanceKm = dto.DistanceKm,
            LoadCapacity = dto.LoadCapacity,
            AxleCount = dto.AxleCount,
            ModelId = dto.ModelId
        };
    }

    public static GetTruckAdDto MapToDto(Truck entity)
    {
        return new GetTruckAdDto
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
            Specs = new TruckSpecsDto
            {
                FuelType = entity.FuelType,
                EnginePower = entity.EnginePower,
                FuelTankCapacity = entity.FuelTankCapacity,
                DistanceKm = entity.DistanceKm,
                LoadCapacity = entity.LoadCapacity,
                AxleCount = entity.AxleCount,
                ModelId = entity.ModelId
            }
        };
    }

    public static CreateTruckAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateTruckAdDto
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
            FuelType = form.TryGetValue("FuelType", out var ft) && !string.IsNullOrWhiteSpace(ft) && Enum.TryParse<Domain.Entities.Ads.Vehicles.Enums.FuelType>(ft, out var fuelType) ? fuelType : null,
            EnginePower = form.TryGetValue("EnginePower", out var ep) && !string.IsNullOrWhiteSpace(ep) && ushort.TryParse(ep, out var enginePower) ? enginePower : null,
            FuelTankCapacity = form.TryGetValue("FuelTankCapacity", out var ftc) && !string.IsNullOrWhiteSpace(ftc) && ushort.TryParse(ftc, out var fuelTank) ? fuelTank : null,
            DistanceKm = form.TryGetValue("DistanceKm", out var dk) && !string.IsNullOrWhiteSpace(dk) && int.TryParse(dk, out var distance) ? distance : null,
            LoadCapacity = form.TryGetValue("LoadCapacity", out var lc) && !string.IsNullOrWhiteSpace(lc) && float.TryParse(lc, out var load) ? load : null,
            AxleCount = form.TryGetValue("AxleCount", out var ac) && !string.IsNullOrWhiteSpace(ac) && byte.TryParse(ac, out var axle) ? axle : null,
            ModelId = form.TryGetValue("ModelId", out var mid) && !string.IsNullOrWhiteSpace(mid) && Guid.TryParse(mid, out var modelId) ? modelId : null
        };
    }

    public static TruckAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new TruckAdDto
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
            FuelType = form.TryGetValue("FuelType", out var ft) && !string.IsNullOrWhiteSpace(ft) && Enum.TryParse<Domain.Entities.Ads.Vehicles.Enums.FuelType>(ft, out var fuelType) ? fuelType : null,
            EnginePower = form.TryGetValue("EnginePower", out var ep) && !string.IsNullOrWhiteSpace(ep) && ushort.TryParse(ep, out var enginePower) ? enginePower : null,
            FuelTankCapacity = form.TryGetValue("FuelTankCapacity", out var ftc) && !string.IsNullOrWhiteSpace(ftc) && ushort.TryParse(ftc, out var fuelTank) ? fuelTank : null,
            DistanceKm = form.TryGetValue("DistanceKm", out var dk) && !string.IsNullOrWhiteSpace(dk) && int.TryParse(dk, out var distance) ? distance : null,
            LoadCapacity = form.TryGetValue("LoadCapacity", out var lc) && !string.IsNullOrWhiteSpace(lc) && float.TryParse(lc, out var load) ? load : null,
            AxleCount = form.TryGetValue("AxleCount", out var ac) && !string.IsNullOrWhiteSpace(ac) && byte.TryParse(ac, out var axle) ? axle : null,
            ModelId = form.TryGetValue("ModelId", out var mid) && !string.IsNullOrWhiteSpace(mid) && Guid.TryParse(mid, out var modelId) ? modelId : null
        };
    }

    public static void UpdateAttributes(Ad ad, TruckAdDto dto)
    {
        if (ad is Truck truck)
        {
            if (dto.FuelType.HasValue) truck.FuelType = dto.FuelType;
            if (dto.EnginePower.HasValue) truck.EnginePower = dto.EnginePower;
            if (dto.FuelTankCapacity.HasValue) truck.FuelTankCapacity = dto.FuelTankCapacity;
            if (dto.DistanceKm.HasValue) truck.DistanceKm = dto.DistanceKm;
            if (dto.LoadCapacity.HasValue) truck.LoadCapacity = dto.LoadCapacity;
            if (dto.AxleCount.HasValue) truck.AxleCount = dto.AxleCount;
            if (dto.ModelId.HasValue) truck.ModelId = dto.ModelId;
        }
    }
}
