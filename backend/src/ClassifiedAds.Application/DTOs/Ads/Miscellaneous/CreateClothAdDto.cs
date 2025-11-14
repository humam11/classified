using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Miscellaneous;

public class CreateClothAdDto : CreateAdDto
{
    public ClothCondition ClothCondition { get; set; }
    public ClothingSize ClothingSize { get; set; }
    public Season Season { get; set; }
}
