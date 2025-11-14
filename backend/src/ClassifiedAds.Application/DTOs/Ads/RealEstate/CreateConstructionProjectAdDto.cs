using ClassifiedAds.Domain.Entities.Ads.RealEstate.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.RealEstate;

public class CreateConstructionProjectAdDto : CreateRealEstateAdDto
{
    public CompletionStatus CompletionStatus { get; set; }
}
