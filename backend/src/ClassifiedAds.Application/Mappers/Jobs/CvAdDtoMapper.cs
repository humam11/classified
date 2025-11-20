using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Jobs;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.JobsServices;
using ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;
using ClassifiedAds.Domain.Entities.Ads.JobsServices.ValueObjects;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;
using System.Text.Json;

namespace ClassifiedAds.Application.Mappers.Jobs;

public static class CvAdDtoMapper
{
    // Maps CreateCvAdDto to Cv entity - Used by: AdService.CreateAdAsync
    public static Cv MapToEntity(
        CreateCvAdDto dto,
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

    // Maps Cv entity to CvAdDto - Used by: AdService.GetAdByIdAsync
    public static CvAdDto MapToDto(Cv entity)
    {
        return new CvAdDto
        {
            Title = entity.Title,
            Description = entity.Description,
            IsDollar = entity.Price.IsDollar,
            PriceValue = entity.Price.Value,
            City = string.Empty, // TODO: Extract from FullAddressArabic/Kurdish
            Region = string.Empty,
            Neighborhood = string.Empty,
            Street = entity.LocationAd.Street,
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
            FirstName = form.TryGetValue("FirstName", out var firstName) && !string.IsNullOrWhiteSpace(firstName) ? firstName.ToString() : null,
            LastName = form.TryGetValue("LastName", out var lastName) && !string.IsNullOrWhiteSpace(lastName) ? lastName.ToString() : null,
            Gender = form.TryGetValue("Gender", out var gender) &&
                    !string.IsNullOrWhiteSpace(gender) &&
                    Enum.TryParse<Gender>(gender, out var g) ? g : null,
            DateOfBirth = form.TryGetValue("DateOfBirth", out var dob) &&
                         !string.IsNullOrWhiteSpace(dob) &&
                         DateTime.TryParse(dob, out var d) ? d : null,
            PhoneNumber = form.TryGetValue("PhoneNumber", out var phone) && !string.IsNullOrWhiteSpace(phone) ? phone.ToString() : null,
            ContactEmail = form.TryGetValue("ContactEmail", out var email) && !string.IsNullOrWhiteSpace(email) ? email.ToString() : null,
            JobSearchStatus = form.TryGetValue("JobSearchStatus", out var status) &&
                             !string.IsNullOrWhiteSpace(status) &&
                             Enum.TryParse<JobSearchStatus>(status, out var jss) ? jss : null,
            Education = form.TryGetValue("Education", out var education) && !string.IsNullOrWhiteSpace(education)
                ? JsonSerializer.Deserialize<List<EducationDto>>(education.ToString()) : null,
            Experience = form.TryGetValue("Experience", out var experience) && !string.IsNullOrWhiteSpace(experience)
                ? JsonSerializer.Deserialize<List<ExperienceDto>>(experience.ToString()) : null,
            Languages = form.TryGetValue("Languages", out var languages) && !string.IsNullOrWhiteSpace(languages)
                ? JsonSerializer.Deserialize<List<LanguageDto>>(languages.ToString()) : null
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
            FirstName = form.TryGetValue("FirstName", out var firstName) && !string.IsNullOrWhiteSpace(firstName) ? firstName.ToString() : null,
            LastName = form.TryGetValue("LastName", out var lastName) && !string.IsNullOrWhiteSpace(lastName) ? lastName.ToString() : null,
            Gender = form.TryGetValue("Gender", out var gender) &&
                    !string.IsNullOrWhiteSpace(gender) &&
                    Enum.TryParse<Gender>(gender, out var g) ? g : null,
            DateOfBirth = form.TryGetValue("DateOfBirth", out var dob) &&
                         !string.IsNullOrWhiteSpace(dob) &&
                         DateTime.TryParse(dob, out var d) ? d : null,
            PhoneNumber = form.TryGetValue("PhoneNumber", out var phone) && !string.IsNullOrWhiteSpace(phone) ? phone.ToString() : null,
            ContactEmail = form.TryGetValue("ContactEmail", out var email) && !string.IsNullOrWhiteSpace(email) ? email.ToString() : null,
            JobSearchStatus = form.TryGetValue("JobSearchStatus", out var status) &&
                             !string.IsNullOrWhiteSpace(status) &&
                             Enum.TryParse<JobSearchStatus>(status, out var jss) ? jss : null,
            Education = form.TryGetValue("Education", out var education) && !string.IsNullOrWhiteSpace(education)
                ? JsonSerializer.Deserialize<List<EducationDto>>(education.ToString()) : null,
            Experience = form.TryGetValue("Experience", out var experience) && !string.IsNullOrWhiteSpace(experience)
                ? JsonSerializer.Deserialize<List<ExperienceDto>>(experience.ToString()) : null,
            Languages = form.TryGetValue("Languages", out var languages) && !string.IsNullOrWhiteSpace(languages)
                ? JsonSerializer.Deserialize<List<LanguageDto>>(languages.ToString()) : null
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
