using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Miscellaneous;

public class ClothAdDto : AdDto
{
    public ClothCondition? ClothCondition { get; set; }
    public ClothingSize? ClothingSize { get; set; }
    public Season? Season { get; set; }
}

public class CreateClothAdDto : ClothAdDto
{
    // EMPTY — inherits everything
}

public class ClothSpecsDto
{
    public ClothCondition? ClothCondition { get; set; }
    public ClothingSize? ClothingSize { get; set; }
    public Season? Season { get; set; }
}

public class GetClothAdDto : GetAdDto
{
    [JsonPropertyOrder(100)]
    public ClothSpecsDto? Specs { get; set; }
}
