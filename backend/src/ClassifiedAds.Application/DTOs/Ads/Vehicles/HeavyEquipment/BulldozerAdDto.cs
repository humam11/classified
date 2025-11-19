namespace ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;

public class BulldozerAdDto : HeavyEquipmentAdDto
{
    public float? BladeWidth { get; set; }
    public float? MaxPushingCapacity { get; set; }
    public float? TrackWidth { get; set; }
}

public class CreateBulldozerAdDto : BulldozerAdDto
{
    // EMPTY — inherits everything
}
