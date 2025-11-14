using ClassifiedAds.Domain.Common.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.RealEstate;

public class CreateHouseAdDto : CreateRealEstateAdDto
{
    public byte Floors { get; set; }
    public byte Bedrooms { get; set; }
    public byte Bathrooms { get; set; }
    public YesNo Garage { get; set; }
    public YesNo Garden { get; set; }
}
