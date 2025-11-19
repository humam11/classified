using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Electronics;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers;

public static class VideoConsoleAdDtoMapper
{
    public static VideoConsole MapToEntity(
        CreateVideoConsoleAdDto dto,
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

        return new VideoConsole
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
            IsNew = dto.IsNew,
            WarrantyMonths = dto.WarrantyMonths,
            StorageCapacity = dto.StorageCapacity,
            ConsoleRegion = dto.ConsoleRegion,
            ModelId = dto.ModelId
        };
    }

    public static CreateVideoConsoleAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateVideoConsoleAdDto
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
            IsNew = form.TryGetValue("IsNew", out var isNew) &&
                   !string.IsNullOrWhiteSpace(isNew) &&
                   Enum.TryParse<Domain.Common.Enums.YesNo>(isNew, out var yn) ? yn : null,
            WarrantyMonths = form.TryGetValue("WarrantyMonths", out var warranty) &&
                            !string.IsNullOrWhiteSpace(warranty) &&
                            byte.TryParse(warranty, out var wm) ? wm : null,
            StorageCapacity = form.TryGetValue("StorageCapacity", out var storage) &&
                             !string.IsNullOrWhiteSpace(storage) &&
                             Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.StorageCapacity>(storage, out var sc) ? sc : null,
            ConsoleRegion = form.TryGetValue("ConsoleRegion", out var region) &&
                           !string.IsNullOrWhiteSpace(region) &&
                           Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.Region>(region, out var cr) ? cr : null,
            ModelId = form.TryGetValue("ModelId", out var modelId) &&
                     !string.IsNullOrWhiteSpace(modelId) &&
                     Guid.TryParse(modelId, out var m) ? m : null
        };
    }

    public static VideoConsoleAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new VideoConsoleAdDto
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
            IsNew = form.TryGetValue("IsNew", out var isNew) &&
                   !string.IsNullOrWhiteSpace(isNew) &&
                   Enum.TryParse<Domain.Common.Enums.YesNo>(isNew, out var yn) ? yn : null,
            WarrantyMonths = form.TryGetValue("WarrantyMonths", out var warranty) &&
                            !string.IsNullOrWhiteSpace(warranty) &&
                            byte.TryParse(warranty, out var wm) ? wm : null,
            StorageCapacity = form.TryGetValue("StorageCapacity", out var storage) &&
                             !string.IsNullOrWhiteSpace(storage) &&
                             Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.StorageCapacity>(storage, out var sc) ? sc : null,
            ConsoleRegion = form.TryGetValue("ConsoleRegion", out var region) &&
                           !string.IsNullOrWhiteSpace(region) &&
                           Enum.TryParse<Domain.Entities.Ads.Electronics.Enums.Region>(region, out var cr) ? cr : null,
            ModelId = form.TryGetValue("ModelId", out var modelId) &&
                     !string.IsNullOrWhiteSpace(modelId) &&
                     Guid.TryParse(modelId, out var m) ? m : null
        };
    }

    public static void UpdateAttributes(Ad ad, VideoConsoleAdDto dto)
    {
        if (ad is VideoConsole console)
        {
            if (dto.IsNew.HasValue)
                console.IsNew = dto.IsNew;
            if (dto.WarrantyMonths.HasValue)
                console.WarrantyMonths = dto.WarrantyMonths;
            if (dto.StorageCapacity.HasValue)
                console.StorageCapacity = dto.StorageCapacity;
            if (dto.ConsoleRegion.HasValue)
                console.ConsoleRegion = dto.ConsoleRegion;
            if (dto.ModelId.HasValue)
                console.ModelId = dto.ModelId;
        }
    }
}
