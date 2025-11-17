using ClassifiedAds.Domain.Entities.Ads.RealEstate.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.RealEstate;

public class ConstructionProjectAdDto : RealEstateAdDto
{
    public CompletionStatus CompletionStatus { get; set; }
}
