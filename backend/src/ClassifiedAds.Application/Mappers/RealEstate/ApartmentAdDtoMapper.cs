using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.RealEstate;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.RealEstate;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers;

public static class ApartmentAdDtoMapper
{
    public static Apartment MapToEntity(
        CreateApartmentAdDto dto,
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
            Area = form.TryGetValue("Area", out var area) &&
                  !string.IsNullOrWhiteSpace(area) &&
                  float.TryParse(area, out var a) ? a : null,
            Bedrooms = form.TryGetValue("Bedrooms", out var bedrooms) &&
                      !string.IsNullOrWhiteSpace(bedrooms) &&
                      byte.TryParse(bedrooms, out var br) ? br : null,
            Bathrooms = form.TryGetValue("Bathrooms", out var bathrooms) &&
                       !string.IsNullOrWhiteSpace(bathrooms) &&
                       byte.TryParse(bathrooms, out var ba) ? ba : null,
            Elevator = form.TryGetValue("Elevator", out var elevator) &&
                      !string.IsNullOrWhiteSpace(elevator) &&
                      Enum.TryParse<YesNo>(elevator, out var el) ? el : null,
            Furnished = form.TryGetValue("Furnished", out var furnished) &&
                       !string.IsNullOrWhiteSpace(furnished) &&
                       Enum.TryParse<YesNo>(furnished, out var fu) ? fu : null,
            FloorNumber = form.TryGetValue("FloorNumber", out var floor) &&
                         !string.IsNullOrWhiteSpace(floor) &&
                         byte.TryParse(floor, out var fn) ? fn : null
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
            Area = form.TryGetValue("Area", out var area) &&
                  !string.IsNullOrWhiteSpace(area) &&
                  float.TryParse(area, out var a) ? a : null,
            Bedrooms = form.TryGetValue("Bedrooms", out var bedrooms) &&
                      !string.IsNullOrWhiteSpace(bedrooms) &&
                      byte.TryParse(bedrooms, out var br) ? br : null,
            Bathrooms = form.TryGetValue("Bathrooms", out var bathrooms) &&
                       !string.IsNullOrWhiteSpace(bathrooms) &&
                       byte.TryParse(bathrooms, out var ba) ? ba : null,
            Elevator = form.TryGetValue("Elevator", out var elevator) &&
                      !string.IsNullOrWhiteSpace(elevator) &&
                      Enum.TryParse<YesNo>(elevator, out var el) ? el : null,
            Furnished = form.TryGetValue("Furnished", out var furnished) &&
                       !string.IsNullOrWhiteSpace(furnished) &&
                       Enum.TryParse<YesNo>(furnished, out var fu) ? fu : null,
            FloorNumber = form.TryGetValue("FloorNumber", out var floor) &&
                         !string.IsNullOrWhiteSpace(floor) &&
                         byte.TryParse(floor, out var fn) ? fn : null
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
