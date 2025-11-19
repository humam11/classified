namespace ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;

public class CraneAdDto : HeavyEquipmentAdDto
{
    public float? LiftingCapacity { get; set; }
    public float? MaxLiftingHeight { get; set; }
    public float? BoomLength { get; set; }
    public ushort? RotationAngle { get; set; }
}

public class CreateCraneAdDto : CraneAdDto
{
    // EMPTY — inherits everything
}
