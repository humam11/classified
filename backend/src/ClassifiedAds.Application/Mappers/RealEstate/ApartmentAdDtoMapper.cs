using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.RealEstate;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.RealEstate;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;
using static ClassifiedAds.Application.Common.FormParsingHelpers;


namespace ClassifiedAds.Application.Mappers;

public static class ApartmentAdDtoMapper
{
    public static Apartment MapToEntity(
        CreateApartmentAdDto dto,
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

        return new Apartment
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
            Bedrooms = dto.Bedrooms,
            Bathrooms = dto.Bathrooms,
            Elevator = dto.Elevator,
            Furnished = dto.Furnished,
            FloorNumber = dto.FloorNumber
        };
    }

    public static CreateApartmentAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateApartmentAdDto
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
            Bedrooms = FormParsingHelpers.ParseByte(form, "Bedrooms"),
            Bathrooms = FormParsingHelpers.ParseByte(form, "Bathrooms"),
            Elevator = FormParsingHelpers.ParseEnum<YesNo>(form, "Elevator"),
            Furnished = FormParsingHelpers.ParseEnum<YesNo>(form, "Furnished"),
            FloorNumber = FormParsingHelpers.ParseByte(form, "FloorNumber")
        };
    }

    public static GetApartmentAdDto MapToDto(Apartment entity)
    {
        return new GetApartmentAdDto
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
            Specs = new ApartmentSpecsDto
            {
                Area = entity.Area,
                Bedrooms = entity.Bedrooms,
                Bathrooms = entity.Bathrooms,
                Elevator = entity.Elevator,
                Furnished = entity.Furnished,
                FloorNumber = entity.FloorNumber
            }
        };
    }

    public static ApartmentAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new ApartmentAdDto
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
            Bedrooms = FormParsingHelpers.ParseByte(form, "Bedrooms"),
            Bathrooms = FormParsingHelpers.ParseByte(form, "Bathrooms"),
            Elevator = FormParsingHelpers.ParseEnum<YesNo>(form, "Elevator"),
            Furnished = FormParsingHelpers.ParseEnum<YesNo>(form, "Furnished"),
            FloorNumber = FormParsingHelpers.ParseByte(form, "FloorNumber")
        };
    }

    public static void UpdateAttributes(Ad ad, ApartmentAdDto dto)
    {
        if (ad is Apartment apartment)
        {
            if (dto.Area.HasValue)
                apartment.Area = dto.Area;
            if (dto.Bedrooms.HasValue)
                apartment.Bedrooms = dto.Bedrooms;
            if (dto.Bathrooms.HasValue)
                apartment.Bathrooms = dto.Bathrooms;
            if (dto.Elevator.HasValue)
                apartment.Elevator = dto.Elevator;
            if (dto.Furnished.HasValue)
                apartment.Furnished = dto.Furnished;
            if (dto.FloorNumber.HasValue)
                apartment.FloorNumber = dto.FloorNumber;
        }
    }
}
