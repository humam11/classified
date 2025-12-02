using ClassifiedAds.Domain.Entities.Ads.Vehicles.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Vehicles;

[BsonDiscriminator("Motorcycle")]
public class Motorcycle : Transport
{
        public MotorcycleDriveType? MotorcycleDriveType { get; set; }
        public byte? GearCount { get; set; }
        // Resolved brand slugs from PostgreSQL (brand only)
        public List<string>? ModelsSlugs { get; set; }
}
