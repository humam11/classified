using ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Jobs;

public class CvAdDto : AdDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string ContactEmail { get; set; }
    public JobSearchStatus JobSearchStatus { get; set; }
    public List<EducationDto> Education { get; set; }
    public List<ExperienceDto> Experience { get; set; }
    public List<LanguageDto> Languages { get; set; }
}
