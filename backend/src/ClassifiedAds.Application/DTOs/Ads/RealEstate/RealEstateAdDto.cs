using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.RealEstate;

public class RealEstateAdDto : AdDto
{
    public float? Area { get; set; }
}

public class CreateRealEstateAdDto : RealEstateAdDto
{
    // EMPTY — inherits everything
}

public class RealEstateSpecsDto
{
    public float? Area { get; set; }
}

public class GetRealEstateAdDto : GetAdDto
{
    [JsonPropertyOrder(100)]
    public RealEstateSpecsDto? Specs { get; set; }
}
