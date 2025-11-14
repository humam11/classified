namespace ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;

public class CreateBulldozerAdDto : CreateHeavyEquipmentAdDto
{
    public float BladeWidth { get; set; }
    public float MaxPushingCapacity { get; set; }
    public float TrackWidth { get; set; }
}
