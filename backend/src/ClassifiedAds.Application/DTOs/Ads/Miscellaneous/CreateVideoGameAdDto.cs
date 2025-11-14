using ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Miscellaneous;

public class CreateVideoGameAdDto : CreateAdDto
{
    public Region VideoGameRegion { get; set; }
    public Guid ModelId { get; set; }
}
