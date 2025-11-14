using ClassifiedAds.Domain.Entities.Ads.Vehicles.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Vehicles;

[BsonDiscriminator("Car")]
public class Car : Transport
{
        public int DistanceKm { get; set; }
        public string EngineDescription { get; set; }
        public byte Cylinders { get; set; }
        public Transmission Transmission { get; set; }
        public CarDriveType DriveType { get; set; }
        public string Color { get; set; }
        public Guid ModelId { get; set; }
        public Guid SubModelReleaseId { get; set; }
}
