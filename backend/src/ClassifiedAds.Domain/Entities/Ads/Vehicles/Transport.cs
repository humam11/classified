using ClassifiedAds.Domain.Entities.Ads.Vehicles.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Vehicles;

[BsonDiscriminator("Transport")]
public class Transport : Ad
{
        public FuelType FuelType { get; set; }
        public ushort EnginePower { get; set; }
        public ushort FuelTankCapacity { get; set; }
}
