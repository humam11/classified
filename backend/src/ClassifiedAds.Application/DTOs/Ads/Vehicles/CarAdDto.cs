using ClassifiedAds.Domain.Entities.Ads.Vehicles.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Vehicles;

public class CarAdDto : TransportAdDto
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
