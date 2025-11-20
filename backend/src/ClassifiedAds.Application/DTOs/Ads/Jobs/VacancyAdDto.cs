using ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Jobs;

public class VacancyAdDto : AdDto
{
    public JobType? JobType { get; set; }
    public byte? ExperienceYears { get; set; }
    public EducationLevel? EducationLevel { get; set; }
    public WorkingHours? WorkingHours { get; set; }
    public decimal? Max { get; set; }
    public PaymentPeriod? PaymentPeriod { get; set; }
}

public class CreateVacancyAdDto : VacancyAdDto
{
    // EMPTY — inherits everything
}

public class VacancySpecsDto
{
    public JobType? JobType { get; set; }
    public byte? ExperienceYears { get; set; }
    public EducationLevel? EducationLevel { get; set; }
    public WorkingHours? WorkingHours { get; set; }
    public decimal? Max { get; set; }
    public PaymentPeriod? PaymentPeriod { get; set; }
}

public class GetVacancyAdDto : GetAdDto
{
    [JsonPropertyOrder(100)]
    public VacancySpecsDto? Specs { get; set; }
}
