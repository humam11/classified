using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Jobs;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.JobsServices;
using ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;
using ClassifiedAds.Domain.Entities.Ads.JobsServices.ValueObjects;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;
using static ClassifiedAds.Application.Common.FormParsingHelpers;

namespace ClassifiedAds.Application.Mappers.Jobs;

public static class CvAdDtoMapper
{
    // Maps CreateCvAdDto to Cv entity - Used by: AdService.CreateAdAsync
    public static Cv MapToEntity(
        CreateCvAdDto dto,
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

        return new Cv
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

            // CV-specific fields
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Gender = dto.Gender,
            DateOfBirth = dto.DateOfBirth,
            PhoneNumber = dto.PhoneNumber,
            ContactEmail = dto.ContactEmail,
            JobSearchStatus = dto.JobSearchStatus,
            Education = dto.Education?.Select(e => new Education
            {
                InstitutionName = e.InstitutionName,
                EducationDegree = e.EducationDegree,
                Specialization = e.Specialization,
                StartDate = e.StartDate,
                EndDate = e.EndDate
            }).ToList(),
            Experience = dto.Experience?.Select(e => new Experience
            {
                CompanyName = e.CompanyName,
                Position = e.Position,
                StartDate = e.StartDate,
                EndDate = e.EndDate
            }).ToList(),
            Languages = dto.Languages?.Select(l => new Language
            {
                Name = l.Name,
                LanguageProficiency = l.LanguageProficiency
            }).ToList()
        };
    }

    // Maps Cv entity to GetCvAdDto - Used by: AdService.GetAdByIdAsync
    public static GetCvAdDto MapToDto(Cv entity)
    {
        return new GetCvAdDto
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
            // CV-specific fields grouped in Specs object
            Specs = new CvSpecsDto
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Gender = entity.Gender,
                DateOfBirth = entity.DateOfBirth,
                PhoneNumber = entity.PhoneNumber,
                ContactEmail = entity.ContactEmail,
                JobSearchStatus = entity.JobSearchStatus,
                Education = entity.Education?.Select(e => new EducationDto
                {
                    InstitutionName = e.InstitutionName,
                    EducationDegree = e.EducationDegree,
                    Specialization = e.Specialization,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate
                }).ToList(),
                Experience = entity.Experience?.Select(e => new ExperienceDto
                {
                    CompanyName = e.CompanyName,
                    Position = e.Position,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate
                }).ToList(),
                Languages = entity.Languages?.Select(l => new LanguageDto
                {
                    Name = l.Name,
                    LanguageProficiency = l.LanguageProficiency
                }).ToList()
            }
        };
    }

    // Maps form data to CreateCvAdDto (parses CV-specific fields) - Used by: CategoryDtoMapper.MapFormToDto
    public static CreateCvAdDto MapFormToDto(CreateAdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CreateCvAdDto
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
            FirstName = ParseString(form, "FirstName"),
            LastName = ParseString(form, "LastName"),
            Gender = ParseEnum<Gender>(form, "Gender"),
            DateOfBirth = ParseDateTime(form, "DateOfBirth"),
            PhoneNumber = ParseString(form, "PhoneNumber"),
            ContactEmail = ParseString(form, "ContactEmail"),
            JobSearchStatus = ParseEnum<JobSearchStatus>(form, "JobSearchStatus"),
            Education = ParseJson<List<EducationDto>>(form, "Education"),
            Experience = ParseJson<List<ExperienceDto>>(form, "Experience"),
            Languages = ParseJson<List<LanguageDto>>(form, "Languages")
        };
    }

    // Maps form data to CvAdDto for updates - Used by: AdService.UpdateAdAsync
    public static CvAdDto MapFormToUpdateDto(AdDto baseDto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        return new CvAdDto
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
            FirstName = ParseString(form, "FirstName"),
            LastName = ParseString(form, "LastName"),
            Gender = ParseEnum<Gender>(form, "Gender"),
            DateOfBirth = ParseDateTime(form, "DateOfBirth"),
            PhoneNumber = ParseString(form, "PhoneNumber"),
            ContactEmail = ParseString(form, "ContactEmail"),
            JobSearchStatus = ParseEnum<JobSearchStatus>(form, "JobSearchStatus"),
            Education = ParseJson<List<EducationDto>>(form, "Education"),
            Experience = ParseJson<List<ExperienceDto>>(form, "Experience"),
            Languages = ParseJson<List<LanguageDto>>(form, "Languages")
        };
    }

    // Updates CV-specific fields on existing Cv entity - Used by: AdService.UpdateAdAsync
    public static void UpdateAttributes(Ad ad, CvAdDto dto)
    {
        if (ad is Cv cv)
        {
            if (!string.IsNullOrEmpty(dto.FirstName))
                cv.FirstName = dto.FirstName;
            if (!string.IsNullOrEmpty(dto.LastName))
                cv.LastName = dto.LastName;
            if (dto.Gender.HasValue)
                cv.Gender = dto.Gender;
            if (dto.DateOfBirth.HasValue)
                cv.DateOfBirth = dto.DateOfBirth;
            if (!string.IsNullOrEmpty(dto.PhoneNumber))
                cv.PhoneNumber = dto.PhoneNumber;
            if (!string.IsNullOrEmpty(dto.ContactEmail))
                cv.ContactEmail = dto.ContactEmail;
            if (dto.JobSearchStatus.HasValue)
                cv.JobSearchStatus = dto.JobSearchStatus;
            if (dto.Education != null)
                cv.Education = dto.Education.Select(e => new Education
                {
                    InstitutionName = e.InstitutionName,
                    EducationDegree = e.EducationDegree,
                    Specialization = e.Specialization,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate
                }).ToList();
            if (dto.Experience != null)
                cv.Experience = dto.Experience.Select(e => new Experience
                {
                    CompanyName = e.CompanyName,
                    Position = e.Position,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate
                }).ToList();
            if (dto.Languages != null)
                cv.Languages = dto.Languages.Select(l => new Language
                {
                    Name = l.Name,
                    LanguageProficiency = l.LanguageProficiency
                }).ToList();
        }
    }
}
