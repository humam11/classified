using ClassifiedAds.Domain.Entities.Ads.RealEstate.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.RealEstate;

public class ConstructionProjectAdDto : RealEstateAdDto
{
    public CompletionStatus? CompletionStatus { get; set; }
}

public class CreateConstructionProjectAdDto : ConstructionProjectAdDto
{
    // EMPTY — inherits everything
}

public class ConstructionProjectSpecsDto : RealEstateSpecsDto
{
    public CompletionStatus? CompletionStatus { get; set; }
}

public class GetConstructionProjectAdDto : GetRealEstateAdDto
{
    [JsonPropertyOrder(200)]
    public new ConstructionProjectSpecsDto? Specs { get; set; }
}
