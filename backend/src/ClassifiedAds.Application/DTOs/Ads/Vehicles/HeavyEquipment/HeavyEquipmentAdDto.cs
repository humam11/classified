using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;

public class HeavyEquipmentAdDto : TransportAdDto
{
    public float? OperatingMass { get; set; }
    public float? Weight { get; set; }
}

public class CreateHeavyEquipmentAdDto : HeavyEquipmentAdDto
{
    // EMPTY — inherits everything
}

public class HeavyEquipmentSpecsDto : TransportSpecsDto
{
    public float? OperatingMass { get; set; }
    public float? Weight { get; set; }
}

public class GetHeavyEquipmentAdDto : GetTransportAdDto
{
    [JsonPropertyOrder(200)]
    public new HeavyEquipmentSpecsDto? Specs { get; set; }
}
