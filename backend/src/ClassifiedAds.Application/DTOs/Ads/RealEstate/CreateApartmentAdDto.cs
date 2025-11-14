using ClassifiedAds.Domain.Common.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.RealEstate;

public class CreateApartmentAdDto : CreateRealEstateAdDto
{
    public byte Bedrooms { get; set; }
    public byte Bathrooms { get; set; }
    public YesNo Elevator { get; set; }
    public YesNo Furnished { get; set; }
    public byte FloorNumber { get; set; }
}
