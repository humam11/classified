using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Vehicles.HeavyEquipment;

[BsonDiscriminator("Bus")]
public class Bus : HeavyEquipment
{
    public byte? SeatingCapacity { get; set; }
}
