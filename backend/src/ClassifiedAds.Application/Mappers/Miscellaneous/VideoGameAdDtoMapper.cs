using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Miscellaneous;
using ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers;

public static class VideoGameAdDtoMapper
{
    // Maps CreateVideoGameAdDto to VideoGame entity - Used by: AdService.CreateAdAsync
    public static VideoGame MapToEntity(
        CreateVideoGameAdDto dto,
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

        return new VideoGame
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
            VideoGameRegion = dto.VideoGameRegion,
            ModelId = dto.ModelId ?? Guid.Empty
        };
    }

    // Maps form data to CreateVideoGameAdDto - Used by: CategoryDtoMapper.MapFormToDto
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
            VideoGameRegion = form.TryGetValue("VideoGameRegion", out var region) &&
                             !string.IsNullOrWhiteSpace(region) &&
                             Enum.TryParse<Region>(region, out var r) ? r : null,
            ModelId = form.TryGetValue("ModelId", out var modelId) &&
                     !string.IsNullOrWhiteSpace(modelId) &&
                     Guid.TryParse(modelId, out var m) ? m : null
        };
    }

    // Maps form data to VideoGameAdDto for updates - Used by: AdService.UpdateAdAsync
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
            VideoGameRegion = form.TryGetValue("VideoGameRegion", out var region) &&
                             !string.IsNullOrWhiteSpace(region) &&
                             Enum.TryParse<Region>(region, out var r) ? r : null,
            ModelId = form.TryGetValue("ModelId", out var modelId) &&
                     !string.IsNullOrWhiteSpace(modelId) &&
                     Guid.TryParse(modelId, out var m) ? m : null
        };
    }

    // Updates videogame-specific fields - Used by: AdService.UpdateAdAsync
    public static void UpdateAttributes(Ad ad, VideoGameAdDto dto)
    {
        if (ad is VideoGame game)
        {
            if (dto.VideoGameRegion.HasValue)
                game.VideoGameRegion = dto.VideoGameRegion;
            if (dto.ModelId.HasValue)
                game.ModelId = dto.ModelId.Value;
        }
    }
}
