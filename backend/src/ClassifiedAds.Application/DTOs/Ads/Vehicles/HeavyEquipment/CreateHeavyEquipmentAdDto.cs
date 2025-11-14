namespace ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;

public class CreateHeavyEquipmentAdDto : CreateTransportAdDto
{
    public float OperatingMass { get; set; }
    public float Weight { get; set; }
}
