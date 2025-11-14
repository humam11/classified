using ClassifiedAds.Domain.Common.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Miscellaneous;

public class CreateShoeAdDto : CreateAdDto
{
    public YesNo IsNew { get; set; }
    public byte Size { get; set; }
}
