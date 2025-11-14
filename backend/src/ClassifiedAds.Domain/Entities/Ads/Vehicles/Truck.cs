using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Vehicles;

[BsonDiscriminator("Truck")]
public class Truck : Transport
{
        public int DistanceKm { get; set; }
        public float LoadCapacity { get; set; }
        public byte AxleCount { get; set; }
        public Guid ModelId { get; set; }
}
