using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Miscellaneous;

public class BookAdDto : AdDto
{
    public BookLanguage? BookLanguage { get; set; }
    public ushort? Pages { get; set; }
}

public class CreateBookAdDto : BookAdDto
{
    // Empty class same pattern as CreateAdDto
}