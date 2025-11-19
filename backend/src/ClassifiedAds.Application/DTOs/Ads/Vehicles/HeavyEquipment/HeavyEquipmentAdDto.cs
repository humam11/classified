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
