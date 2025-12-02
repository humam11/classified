using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.RealEstate;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.RealEstate;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;
using static ClassifiedAds.Application.Common.FormParsingHelpers;


namespace ClassifiedAds.Application.Mappers;

public static class ConstructionProjectAdDtoMapper
{
    public static ConstructionProject MapToEntity(
        CreateConstructionProjectAdDto dto,
        string slug,
        Guid userId,
        List<string> categoriesSlugsArabic, List<string> categoriesSlugsKurdish,
        List<ushort> locationIds,
        string fullAddressArabic,
        string fullAddressKurdish)
    {
        if (string.IsNullOrEmpty(dto.Title) || !dto.IsDollar.HasValue || !dto.PriceValue.HasValue)
        {
            throw new ArgumentException("Required fields are missing");
        }

        string showingPrice = AdDtoMapper.FormatShowingPrice(dto.IsDollar.Value, dto.PriceValue.Value);

        return new ConstructionProject
        {
            Title = dto.Title,
            Description = dto.Description ?? string.Empty,
            Price = new Price
            {
                IsDollar = dto.IsDollar.Value,
                Value = dto.PriceValue.Value,
                ShowingPrice = showingPrice
            },
            Category = new Category { CategoriesSlugsArabic = categoriesSlugsArabic, CategoriesSlugsKurdish = categoriesSlugsKurdish },
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
            Area = dto.Area,
            CompletionStatus = dto.CompletionStatus
        };
    }

    public static GetConstructionProjectAdDto MapToDto(ConstructionProject entity)
    {
        return new GetConstructionProjectAdDto
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
            Specs = new ConstructionProjectSpecsDto
            {
                Area = entity.Area,
                CompletionStatus = entity.CompletionStatus
            }
        };
    }

    public static CreateConstructionProjectAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateConstructionProjectAdDto
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
            Area = FormParsingHelpers.ParseFloat(form, "Area"),
            CompletionStatus = FormParsingHelpers.ParseEnum<Domain.Entities.Ads.RealEstate.Enums.CompletionStatus>(form, "CompletionStatus")
        };
    }

    public static ConstructionProjectAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new ConstructionProjectAdDto
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
            Area = FormParsingHelpers.ParseFloat(form, "Area"),
            CompletionStatus = FormParsingHelpers.ParseEnum<Domain.Entities.Ads.RealEstate.Enums.CompletionStatus>(form, "CompletionStatus")
        };
    }

    public static void UpdateAttributes(Ad ad, ConstructionProjectAdDto dto)
    {
        if (ad is ConstructionProject project)
        {
            if (dto.Area.HasValue)
                project.Area = dto.Area;
            if (dto.CompletionStatus.HasValue)
                project.CompletionStatus = dto.CompletionStatus;
        }
    }
}
