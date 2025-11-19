using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Miscellaneous;
using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers;

public static class FurnitureAdDtoMapper
{
    public static Furniture MapToEntity(
        CreateFurnitureAdDto dto,
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

        return new Furniture
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
            FurnitureMaterial = dto.FurnitureMaterial,
            Length = dto.Length,
            Width = dto.Width,
            Height = dto.Height
        };
    }

    public static CreateFurnitureAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateFurnitureAdDto
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
            FurnitureMaterial = form.TryGetValue("FurnitureMaterial", out var material) &&
                               !string.IsNullOrWhiteSpace(material) &&
                               Enum.TryParse<FurnitureMaterial>(material, out var m) ? m : null,
            Length = form.TryGetValue("Length", out var length) &&
                    !string.IsNullOrWhiteSpace(length) &&
                    ushort.TryParse(length, out var l) ? l : null,
            Width = form.TryGetValue("Width", out var width) &&
                   !string.IsNullOrWhiteSpace(width) &&
                   ushort.TryParse(width, out var w) ? w : null,
            Height = form.TryGetValue("Height", out var height) &&
                    !string.IsNullOrWhiteSpace(height) &&
                    ushort.TryParse(height, out var h) ? h : null
        };
    }

    public static FurnitureAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new FurnitureAdDto
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
            FurnitureMaterial = form.TryGetValue("FurnitureMaterial", out var material) &&
                               !string.IsNullOrWhiteSpace(material) &&
                               Enum.TryParse<FurnitureMaterial>(material, out var fm) ? fm : null,
            Length = form.TryGetValue("Length", out var length) &&
                    !string.IsNullOrWhiteSpace(length) &&
                    ushort.TryParse(length, out var l) ? l : null,
            Width = form.TryGetValue("Width", out var width) &&
                   !string.IsNullOrWhiteSpace(width) &&
                   ushort.TryParse(width, out var w) ? w : null,
            Height = form.TryGetValue("Height", out var height) &&
                    !string.IsNullOrWhiteSpace(height) &&
                    ushort.TryParse(height, out var h) ? h : null
        };
    }

    public static void UpdateAttributes(Ad ad, FurnitureAdDto dto)
    {
        if (ad is Furniture furniture)
        {
            if (dto.FurnitureMaterial.HasValue)
                furniture.FurnitureMaterial = dto.FurnitureMaterial;
            if (dto.Length.HasValue)
                furniture.Length = dto.Length;
            if (dto.Width.HasValue)
                furniture.Width = dto.Width;
            if (dto.Height.HasValue)
                furniture.Height = dto.Height;
        }
    }
}
