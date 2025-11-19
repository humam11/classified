using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Vehicles.HeavyEquipment;

[BsonDiscriminator("Crane")]
public class Crane : HeavyEquipment
{
    public float? LiftingCapacity { get; set; }
    public float? MaxLiftingHeight { get; set; }
    public float? BoomLength { get; set; }
    public ushort? RotationAngle { get; set; }
}
