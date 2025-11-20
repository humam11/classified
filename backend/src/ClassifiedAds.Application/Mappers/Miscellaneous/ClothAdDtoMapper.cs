using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Miscellaneous;
using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers;

public static class ClothAdDtoMapper
{
    // Maps CreateClothAdDto to Cloth entity - Used by: AdService.CreateAdAsync
    public static Cloth MapToEntity(
        CreateClothAdDto dto,
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

        return new Cloth
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
            ClothCondition = dto.ClothCondition,
            ClothingSize = dto.ClothingSize,
            Season = dto.Season
        };
    }

    public static GetClothAdDto MapToDto(Cloth entity)
    {
        return new GetClothAdDto
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
            Specs = new ClothSpecsDto
            {
                ClothCondition = entity.ClothCondition,
                ClothingSize = entity.ClothingSize,
                Season = entity.Season
            }
        };
    }

    // Maps form data to CreateClothAdDto - Used by: CategoryDtoMapper.MapFormToDto
    public static CreateClothAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateClothAdDto
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
            ClothCondition = form.TryGetValue("ClothCondition", out var condition) &&
                            !string.IsNullOrWhiteSpace(condition) &&
                            Enum.TryParse<ClothCondition>(condition, out var c) ? c : null,
            ClothingSize = form.TryGetValue("ClothingSize", out var size) &&
                          !string.IsNullOrWhiteSpace(size) &&
                          Enum.TryParse<ClothingSize>(size, out var s) ? s : null,
            Season = form.TryGetValue("Season", out var season) &&
                    !string.IsNullOrWhiteSpace(season) &&
                    Enum.TryParse<Season>(season, out var se) ? se : null
        };
    }

    // Maps form data to ClothAdDto for updates - Used by: AdService.UpdateAdAsync
    public static ClothAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new ClothAdDto
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
            ClothCondition = form.TryGetValue("ClothCondition", out var condition) &&
                            !string.IsNullOrWhiteSpace(condition) &&
                            Enum.TryParse<ClothCondition>(condition, out var cc) ? cc : null,
            ClothingSize = form.TryGetValue("ClothingSize", out var size) &&
                          !string.IsNullOrWhiteSpace(size) &&
                          Enum.TryParse<ClothingSize>(size, out var cs) ? cs : null,
            Season = form.TryGetValue("Season", out var season) &&
                    !string.IsNullOrWhiteSpace(season) &&
                    Enum.TryParse<Season>(season, out var s) ? s : null
        };
    }

    // Updates cloth-specific fields - Used by: AdService.UpdateAdAsync
    public static void UpdateAttributes(Ad ad, ClothAdDto dto)
    {
        if (ad is Cloth cloth)
        {
            if (dto.ClothCondition.HasValue)
                cloth.ClothCondition = dto.ClothCondition;
            if (dto.ClothingSize.HasValue)
                cloth.ClothingSize = dto.ClothingSize;
            if (dto.Season.HasValue)
                cloth.Season = dto.Season;
        }
    }
}
