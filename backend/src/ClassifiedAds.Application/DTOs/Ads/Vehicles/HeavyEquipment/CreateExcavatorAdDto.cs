namespace ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;

public class CreateExcavatorAdDto : CreateHeavyEquipmentAdDto
{
    public float BucketCapacity { get; set; }
    public float DiggingDepth { get; set; }
}
