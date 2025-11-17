using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Miscellaneous;

public class PlantAdDto : AdDto
{
    public ushort Height { get; set; }
    public PlantType PlantType { get; set; }
}
