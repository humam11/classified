using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Miscellaneous;
using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers;

public static class PlantAdDtoMapper
{
    public static Plant MapToEntity(
        CreatePlantAdDto dto,
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

        return new Plant
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
            Height = dto.Height,
            PlantType = dto.PlantType
        };
    }

    public static CreatePlantAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreatePlantAdDto
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
            Height = form.TryGetValue("Height", out var height) &&
                    !string.IsNullOrWhiteSpace(height) &&
                    ushort.TryParse(height, out var h) ? h : null,
            PlantType = form.TryGetValue("PlantType", out var plantType) &&
                       !string.IsNullOrWhiteSpace(plantType) &&
                       Enum.TryParse<PlantType>(plantType, out var pt) ? pt : null
        };
    }

    public static PlantAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new PlantAdDto
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
            Height = form.TryGetValue("Height", out var height) &&
                    !string.IsNullOrWhiteSpace(height) &&
                    ushort.TryParse(height, out var h) ? h : null,
            PlantType = form.TryGetValue("PlantType", out var plantType) &&
                       !string.IsNullOrWhiteSpace(plantType) &&
                       Enum.TryParse<PlantType>(plantType, out var pt) ? pt : null
        };
    }

    public static void UpdateAttributes(Ad ad, PlantAdDto dto)
    {
        if (ad is Plant plant)
        {
            if (dto.Height.HasValue)
                plant.Height = dto.Height;
            if (dto.PlantType.HasValue)
                plant.PlantType = dto.PlantType;
        }
    }
}
