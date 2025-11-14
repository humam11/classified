using ClassifiedAds.Domain.Entities.Ads.Vehicles.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Vehicles;

[BsonDiscriminator("Motorcycle")]
public class Motorcycle : Transport
{
        public MotorcycleDriveType MotorcycleDriveType { get; set; }
        public byte GearCount { get; set; }
        public Guid ModelId { get; set; }
}
