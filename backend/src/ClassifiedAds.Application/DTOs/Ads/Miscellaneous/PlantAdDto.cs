using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Miscellaneous;

public class PlantAdDto : AdDto
{
    public ushort? Height { get; set; }
    public PlantType? PlantType { get; set; }
}

public class CreatePlantAdDto : PlantAdDto
{
    // EMPTY — inherits everything
}

public class PlantSpecsDto
{
    public ushort? Height { get; set; }
    public PlantType? PlantType { get; set; }
}

public class GetPlantAdDto : GetAdDto
{
    [JsonPropertyOrder(100)]
    public PlantSpecsDto? Specs { get; set; }
}
