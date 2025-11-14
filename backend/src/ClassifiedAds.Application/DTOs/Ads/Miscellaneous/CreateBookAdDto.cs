using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Miscellaneous;

public class CreateBookAdDto : CreateAdDto
{
    public BookLanguage BookLanguage { get; set; }
    public ushort Pages { get; set; }
}
