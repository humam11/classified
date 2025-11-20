using ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Jobs;

// CV Ad DTO for input operations (POST/PATCH)
public class CvAdDto : AdDto
{
    // CV-specific fields
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Gender? Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ContactEmail { get; set; }
    public JobSearchStatus? JobSearchStatus { get; set; }
    public List<EducationDto>? Education { get; set; }
    public List<ExperienceDto>? Experience { get; set; }
    public List<LanguageDto>? Languages { get; set; }
}

// CV Ad DTO for creating (POST)
public class CreateCvAdDto : CvAdDto
{
    // EMPTY — inherits everything
}

// CV specifications DTO - groups all CV-specific fields
public class CvSpecsDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Gender? Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ContactEmail { get; set; }
    public JobSearchStatus? JobSearchStatus { get; set; }
    public List<EducationDto>? Education { get; set; }
    public List<ExperienceDto>? Experience { get; set; }
    public List<LanguageDto>? Languages { get; set; }
}

// CV Ad DTO for GET responses - includes full MongoDB structure
// Base ad fields (order 1-14) come first, then CV specs (order 100)
public class GetCvAdDto : GetAdDto
{
    // CV-specific fields grouped in Specs object
    [JsonPropertyOrder(100)]
    public CvSpecsDto? Specs { get; set; }
}
