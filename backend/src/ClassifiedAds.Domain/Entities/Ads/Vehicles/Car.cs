using ClassifiedAds.Domain.Entities.Ads.Vehicles.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Vehicles;

[BsonDiscriminator("Car")]
public class Car : Transport
{
    public int? DistanceKm { get; set; }
    public string? EngineDescription { get; set; }
    public byte? Cylinders { get; set; }
    public Transmission? Transmission { get; set; }
    public CarDriveType? DriveType { get; set; }
    public string? Color { get; set; }
    
    /// <summary>
    /// Progressive brand/model slugs
    /// Example: ["toyota", "toyota/corolla"]
    /// </summary>
    public List<string>? ModelsSlugs { get; set; }
    
    /// <summary>
    /// Release year as string
    /// Example: "2024"
    /// </summary>
    public string? ReleaseYear { get; set; }
}
