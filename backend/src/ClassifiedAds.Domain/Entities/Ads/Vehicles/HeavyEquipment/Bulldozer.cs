using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Vehicles.HeavyEquipment;

[BsonDiscriminator("Bulldozer")]
public class Bulldozer : HeavyEquipment
{
    public float? BladeWidth { get; set; }
    public float? MaxPushingCapacity { get; set; }
    public float? TrackWidth { get; set; }
}
