using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Vehicles.HeavyEquipment;

[BsonDiscriminator("Excavator")]
public class Excavator : HeavyEquipment
{
    public float BucketCapacity { get; set; }
    public float DiggingDepth { get; set; }
}
