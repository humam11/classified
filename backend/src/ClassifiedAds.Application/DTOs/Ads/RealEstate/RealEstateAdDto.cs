namespace ClassifiedAds.Application.DTOs.Ads.RealEstate;

public class RealEstateAdDto : AdDto
{
    public float? Area { get; set; }
}

public class CreateRealEstateAdDto : RealEstateAdDto
{
    // EMPTY — inherits everything
}
