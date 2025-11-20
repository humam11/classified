using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;

public class BusAdDto : HeavyEquipmentAdDto
{
    public byte? SeatingCapacity { get; set; }
}

public class CreateBusAdDto : BusAdDto
{
    // EMPTY — inherits everything
}

public class BusSpecsDto : HeavyEquipmentSpecsDto
{
    public byte? SeatingCapacity { get; set; }
}

public class GetBusAdDto : GetHeavyEquipmentAdDto
{
    [JsonPropertyOrder(300)]
    public new BusSpecsDto? Specs { get; set; }
}
