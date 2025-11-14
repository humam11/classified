using ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Jobs;

public class EducationDto
{
    public string InstitutionName { get; set; }
    public EducationDegree EducationDegree { get; set; }
    public string Specialization { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
