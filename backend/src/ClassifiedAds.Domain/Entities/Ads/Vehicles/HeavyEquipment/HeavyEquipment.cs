using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Vehicles.HeavyEquipment;

[BsonDiscriminator("HeavyEquipment")]
public class HeavyEquipment : Transport
{
    public float? OperatingMass { get; set; }
    public float? Weight { get; set; }
}
