using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Miscellaneous;

public class EngineOilAdDto : AdDto
{
    public ushort? Volume { get; set; }
    public OilType? OilType { get; set; }
    public Viscosity? Viscosity { get; set; }
}

public class CreateEngineOilAdDto : EngineOilAdDto
{
    // EMPTY — inherits everything
}

public class EngineOilSpecsDto
{
    public ushort? Volume { get; set; }
    public OilType? OilType { get; set; }
    public Viscosity? Viscosity { get; set; }
}

public class GetEngineOilAdDto : GetAdDto
{
    [JsonPropertyOrder(100)]
    public EngineOilSpecsDto? Specs { get; set; }
}
