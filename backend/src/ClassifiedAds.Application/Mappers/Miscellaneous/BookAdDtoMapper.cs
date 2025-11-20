using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Miscellaneous;
using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Application.Mappers;

public static class BookAdDtoMapper
{
    // Maps CreateBookAdDto to Book entity - Used by: AdService.CreateAdAsync
    public static Book MapToEntity(
        CreateBookAdDto dto,
        string slug,
        Guid userId,
        List<ushort> categoryIds,
        byte categoryJoins,
        List<ushort> locationIds,
        string fullAddressArabic,
        string fullAddressKurdish)
    {
        // Ensure required values are present
        if (string.IsNullOrEmpty(dto.Title) || !dto.IsDollar.HasValue || !dto.PriceValue.HasValue)
        {
            throw new ArgumentException("Required fields are missing");
        }

        string showingPrice = AdDtoMapper.FormatShowingPrice(dto.IsDollar.Value, dto.PriceValue.Value);

        return new Book
        {
            // Base ad fields
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

            // Book-specific fields (keep as null if not provided)
            BookLanguage = dto.BookLanguage,
            Pages = dto.Pages
        };
    }

    // Maps Book entity to GetBookAdDto - Used by: AdService.GetAdByIdAsync
    public static GetBookAdDto MapToDto(Book entity)
    {
        return new GetBookAdDto
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
            Specs = new BookSpecsDto
            {
                BookLanguage = entity.BookLanguage,
                Pages = entity.Pages
            }
        };
    }

    // Maps form data to CreateBookAdDto (parses book-specific fields) - Used by: CategoryDtoMapper.MapFormToDto
    public static CreateBookAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateBookAdDto
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
            BookLanguage = form.TryGetValue("BookLanguage", out var bookLang) &&
                          !string.IsNullOrWhiteSpace(bookLang) &&
                          Enum.TryParse<BookLanguage>(bookLang, out var lang)
                          ? lang : null,
            Pages = form.TryGetValue("Pages", out var pages) &&
                   !string.IsNullOrWhiteSpace(pages) &&
                   ushort.TryParse(pages, out var p) ? p : null
        };
    }

    // Maps form data to BookAdDto for updates - Used by: AdService.UpdateAdAsync
    public static BookAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new BookAdDto
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
            BookLanguage = form.TryGetValue("BookLanguage", out var bookLang) &&
                          !string.IsNullOrWhiteSpace(bookLang) &&
                          Enum.TryParse<BookLanguage>(bookLang, out var bl) ? bl : null,
            Pages = form.TryGetValue("Pages", out var pages) &&
                   !string.IsNullOrWhiteSpace(pages) &&
                   ushort.TryParse(pages, out var p) ? p : null
        };
    }

    // Updates book-specific fields on existing Book entity - Used by: AdService.UpdateAdAsync
    public static void UpdateAttributes(Ad ad, BookAdDto dto)
    {
        if (ad is Book book)
        {
            if (dto.BookLanguage.HasValue)
                book.BookLanguage = dto.BookLanguage.Value;

            if (dto.Pages.HasValue)
                book.Pages = dto.Pages.Value;
        }
    }
}
