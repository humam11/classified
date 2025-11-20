using ClassifiedAds.Domain.Common.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.RealEstate;

public class ApartmentAdDto : RealEstateAdDto
{
    public byte? Bedrooms { get; set; }
    public byte? Bathrooms { get; set; }
    public YesNo? Elevator { get; set; }
    public YesNo? Furnished { get; set; }
    public byte? FloorNumber { get; set; }
}

public class CreateApartmentAdDto : ApartmentAdDto
{
    // EMPTY — inherits everything
}

public class ApartmentSpecsDto : RealEstateSpecsDto
{
    public byte? Bedrooms { get; set; }
    public byte? Bathrooms { get; set; }
    public YesNo? Elevator { get; set; }
    public YesNo? Furnished { get; set; }
    public byte? FloorNumber { get; set; }
}

public class GetApartmentAdDto : GetRealEstateAdDto
{
    [JsonPropertyOrder(200)]
    public new ApartmentSpecsDto? Specs { get; set; }
}
