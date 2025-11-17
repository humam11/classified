using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Miscellaneous;

public class FurnitureAdDto : AdDto
{
    public FurnitureMaterial FurnitureMaterial { get; set; }
    public ushort Length { get; set; }
    public ushort Width { get; set; }
    public ushort Height { get; set; }
}
