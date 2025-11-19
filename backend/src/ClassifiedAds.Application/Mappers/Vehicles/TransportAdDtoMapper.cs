using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Vehicles;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Vehicles;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers.Vehicles;

public static class TransportAdDtoMapper
{
    public static Transport MapToEntity(
        CreateTransportAdDto dto,
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

        return new Transport
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
            FuelTankCapacity = dto.FuelTankCapacity
        };
    }

    // Maps Transport entity to TransportAdDto - Used by: AdService.GetAdByIdAsync
    public static TransportAdDto MapToDto(Transport entity)
    {
        return new TransportAdDto
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
            FuelTankCapacity = entity.FuelTankCapacity
        };
    }

    public static CreateTransportAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateTransportAdDto
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
                              ushort.TryParse(fuelTank, out var ftc) ? ftc : null
        };
    }

    public static TransportAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new TransportAdDto
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
                              ushort.TryParse(fuelTank, out var ftc) ? ftc : null
        };
    }

    public static void UpdateAttributes(Ad ad, TransportAdDto dto)
    {
        if (ad is Transport transport)
        {
            if (dto.FuelType.HasValue)
                transport.FuelType = dto.FuelType;
            if (dto.EnginePower.HasValue)
                transport.EnginePower = dto.EnginePower;
            if (dto.FuelTankCapacity.HasValue)
                transport.FuelTankCapacity = dto.FuelTankCapacity;
        }
    }
}
