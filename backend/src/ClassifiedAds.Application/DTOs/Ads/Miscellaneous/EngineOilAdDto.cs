using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;

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
