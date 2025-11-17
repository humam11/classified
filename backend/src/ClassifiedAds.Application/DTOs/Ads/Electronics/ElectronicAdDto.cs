using ClassifiedAds.Domain.Common.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Electronics;

public class ElectronicAdDto : AdDto
{
    public YesNo IsNew { get; set; }
    public byte WarrantyMonths { get; set; }
}
