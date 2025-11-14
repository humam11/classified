using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Vehicles;

[BsonDiscriminator("Boat")]
public class Boat : Transport
{
        public float Length { get; set; }
        public byte Capacity { get; set; }
}
