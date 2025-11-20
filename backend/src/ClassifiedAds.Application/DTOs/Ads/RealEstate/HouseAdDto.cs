using ClassifiedAds.Domain.Common.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.RealEstate;

public class HouseAdDto : RealEstateAdDto
{
    public byte? Floors { get; set; }
    public byte? Bedrooms { get; set; }
    public byte? Bathrooms { get; set; }
    public YesNo? Garage { get; set; }
    public YesNo? Garden { get; set; }
}

public class CreateHouseAdDto : HouseAdDto
{
    // EMPTY — inherits everything
}

public class HouseSpecsDto : RealEstateSpecsDto
{
    public byte? Floors { get; set; }
    public byte? Bedrooms { get; set; }
    public byte? Bathrooms { get; set; }
    public YesNo? Garage { get; set; }
    public YesNo? Garden { get; set; }
}

public class GetHouseAdDto : GetRealEstateAdDto
{
    [JsonPropertyOrder(200)]
    public new HouseSpecsDto? Specs { get; set; }
}
