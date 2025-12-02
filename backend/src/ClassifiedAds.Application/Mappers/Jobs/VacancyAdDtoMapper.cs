using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Jobs;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.JobsServices;
using ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;
using static ClassifiedAds.Application.Common.FormParsingHelpers;

namespace ClassifiedAds.Application.Mappers.Jobs;

public static class VacancyAdDtoMapper
{
    // Maps CreateVacancyAdDto to Vacancy entity - Used by: AdService.CreateAdAsync
    public static Vacancy MapToEntity(
        CreateVacancyAdDto dto,
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

        return new Vacancy
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

            // Vacancy-specific fields
            JobType = dto.JobType,
            ExperienceYears = dto.ExperienceYears,
            EducationLevel = dto.EducationLevel,
            WorkingHours = dto.WorkingHours,
            Max = dto.Max,
            PaymentPeriod = dto.PaymentPeriod
        };
    }

    // Maps Vacancy entity to VacancyAdDto - Used by: AdService.GetAdByIdAsync
    public static GetVacancyAdDto MapToDto(Vacancy entity)
    {
        return new GetVacancyAdDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            Price = new DTOs.Common.PriceResponseDto
            {
                Value = entity.Price.Value,
                IsDollar = entity.Price.IsDollar,
                ShowingPrice = entity.Price.ShowingPrice
            },
            LocationAd = new DTOs.Common.LocationAdResponseDto
            {
                LocationIds = entity.LocationAd.LocationIds,
                FullAddressArabic = entity.LocationAd.FullAddressArabic,
                FullAddressKurdish = entity.LocationAd.FullAddressKurdish,
                Street = entity.LocationAd.Street
            },
            Images = entity.Images.Select(img => new DTOs.Common.AdImageDto
            {
                ImageId = img.ImageId,
                ImageUrl = img.ImageUrl,
                Order = img.Order
            }).ToList(),
            Status = (int)entity.Status,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            ImageCount = entity.ImageCount,
            ViewsCount = entity.ViewsCount,
            Priority = entity.Priority,
            Slug = entity.Slug,
            Category = new DTOs.Common.CategoryResponseDto
            {
                CategoriesSlugsArabic = entity.Category.CategoriesSlugsArabic,
                CategoriesSlugsKurdish = entity.Category.CategoriesSlugsKurdish
            },
            Specs = new VacancySpecsDto
            {
                JobType = entity.JobType,
                ExperienceYears = entity.ExperienceYears,
                EducationLevel = entity.EducationLevel,
                WorkingHours = entity.WorkingHours,
                Max = entity.Max,
                PaymentPeriod = entity.PaymentPeriod
            }
        };
    }

    // Maps form data to CreateVacancyAdDto (parses vacancy-specific fields) - Used by: CategoryDtoMapper.MapFormToDto
    public static CreateVacancyAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateVacancyAdDto
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
            JobType = ParseEnum<JobType>(form, "JobType"),
            ExperienceYears = ParseByte(form, "ExperienceYears"),
            EducationLevel = ParseEnum<EducationLevel>(form, "EducationLevel"),
            WorkingHours = ParseEnum<WorkingHours>(form, "WorkingHours"),
            Max = ParseDecimal(form, "Max"),
            PaymentPeriod = ParseEnum<PaymentPeriod>(form, "PaymentPeriod")
        };
    }

    // Maps form data to VacancyAdDto for updates - Used by: AdService.UpdateAdAsync
    public static VacancyAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new VacancyAdDto
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
            JobType = ParseEnum<JobType>(form, "JobType"),
            ExperienceYears = ParseByte(form, "ExperienceYears"),
            EducationLevel = ParseEnum<EducationLevel>(form, "EducationLevel"),
            WorkingHours = ParseEnum<WorkingHours>(form, "WorkingHours"),
            Max = ParseDecimal(form, "Max"),
            PaymentPeriod = ParseEnum<PaymentPeriod>(form, "PaymentPeriod")
        };
    }

    // Updates vacancy-specific fields on existing Vacancy entity - Used by: AdService.UpdateAdAsync
    public static void UpdateAttributes(Ad ad, VacancyAdDto dto)
    {
        if (ad is Vacancy vacancy)
        {
            if (dto.JobType.HasValue)
                vacancy.JobType = dto.JobType;
            if (dto.ExperienceYears.HasValue)
                vacancy.ExperienceYears = dto.ExperienceYears;
            if (dto.EducationLevel.HasValue)
                vacancy.EducationLevel = dto.EducationLevel;
            if (dto.WorkingHours.HasValue)
                vacancy.WorkingHours = dto.WorkingHours;
            if (dto.Max.HasValue)
                vacancy.Max = dto.Max;
            if (dto.PaymentPeriod.HasValue)
                vacancy.PaymentPeriod = dto.PaymentPeriod;
        }
    }
}
