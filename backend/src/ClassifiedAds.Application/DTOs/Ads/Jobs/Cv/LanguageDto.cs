using ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Jobs;

public class LanguageDto
{
    public string Name { get; set; }
    public LanguageProficiency LanguageProficiency { get; set; }
}
