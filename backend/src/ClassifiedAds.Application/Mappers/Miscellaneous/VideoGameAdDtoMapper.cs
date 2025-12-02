using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Application.Interfaces;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Miscellaneous;
using ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;
using static ClassifiedAds.Application.Common.FormParsingHelpers;

namespace ClassifiedAds.Application.Mappers;

public static class VideoGameAdDtoMapper
{
    // Async mapper that handles brand/model resolution internally (brand + model)
    public static async Task<VideoGame> MapToEntityAsync(
        CreateVideoGameAdDto dto,
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

        if (string.IsNullOrEmpty(dto.BrandName) || string.IsNullOrEmpty(dto.ModelName))
            throw new ArgumentException("BrandName and ModelName are required for VideoGame ads");

        // Resolve brand and model
        var (_, modelsSlugs) = await brandModelReleaseService.ResolveBrandModelAsync(
            categorySlug, language, dto.BrandName, dto.ModelName);

        string showingPrice = AdDtoMapper.FormatShowingPrice(dto.IsDollar.Value, dto.PriceValue.Value);

        return new VideoGame
        {
            Title = dto.Title,
            Description = dto.Description ?? string.Empty,
            Price = new Price { IsDollar = dto.IsDollar.Value, Value = dto.PriceValue.Value, ShowingPrice = showingPrice },
            Category = new Category { CategoriesSlugsArabic = categoriesSlugsArabic, CategoriesSlugsKurdish = categoriesSlugsKurdish },
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
            VideoGameRegion = dto.VideoGameRegion,
            ModelsSlugs = modelsSlugs
        };
    }

    public static GetVideoGameAdDto MapToDto(VideoGame entity)
    {
        return new GetVideoGameAdDto
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
            Category = new DTOs.Common.CategoryResponseDto { CategoriesSlugsArabic = entity.Category.CategoriesSlugsArabic, CategoriesSlugsKurdish = entity.Category.CategoriesSlugsKurdish },
            Specs = new VideoGameSpecsDto
            {
                VideoGameRegion = entity.VideoGameRegion,
                ModelsSlugs = entity.ModelsSlugs
            }
        };
    }

    public static CreateVideoGameAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateVideoGameAdDto
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
            VideoGameRegion = ParseEnum<Region>(form, "VideoGameRegion"),
            BrandName = ParseString(form, "BrandName"),
            ModelName = ParseString(form, "ModelName")
        };
    }

    public static VideoGameAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new VideoGameAdDto
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
            VideoGameRegion = ParseEnum<Region>(form, "VideoGameRegion"),
            BrandName = ParseString(form, "BrandName"),
            ModelName = ParseString(form, "ModelName")
        };
    }

    public static void UpdateAttributes(Ad ad, VideoGameAdDto dto)
    {
        if (ad is VideoGame game)
        {
            if (dto.VideoGameRegion.HasValue) game.VideoGameRegion = dto.VideoGameRegion;
            // Note: BrandName/ModelName update requires calling BrandModelReleaseService - handled in AdService
        }
    }
}
