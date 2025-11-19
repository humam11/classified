namespace ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;

public class ExcavatorAdDto : HeavyEquipmentAdDto
{
    public float? BucketCapacity { get; set; }
    public float? DiggingDepth { get; set; }
}

public class CreateExcavatorAdDto : ExcavatorAdDto
{
    // EMPTY — inherits everything
}
