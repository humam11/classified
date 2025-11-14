using ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Jobs;

public class CreateVacancyAdDto : CreateAdDto
{
    public JobType JobType { get; set; }
    public byte ExperienceYears { get; set; }
    public EducationLevel EducationLevel { get; set; }
    public WorkingHours WorkingHours { get; set; }
    public decimal Max { get; set; }
    public PaymentPeriod PaymentPeriod { get; set; }
}
