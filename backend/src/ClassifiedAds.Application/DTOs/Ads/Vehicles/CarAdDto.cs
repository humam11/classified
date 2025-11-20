using ClassifiedAds.Domain.Entities.Ads.Vehicles.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Vehicles;

public class CarAdDto : TransportAdDto
{
    public int? DistanceKm { get; set; }
    public string? EngineDescription { get; set; }
    public byte? Cylinders { get; set; }
    public Transmission? Transmission { get; set; }
    public CarDriveType? DriveType { get; set; }
    public string? Color { get; set; }
    public Guid? ModelId { get; set; }
    public Guid? SubModelReleaseId { get; set; }
}

public class CreateCarAdDto : CarAdDto
{
    // EMPTY — inherits everything
}

public class CarSpecsDto : TransportSpecsDto
{
    public int? DistanceKm { get; set; }
    public string? EngineDescription { get; set; }
    public byte? Cylinders { get; set; }
    public Transmission? Transmission { get; set; }
    public CarDriveType? DriveType { get; set; }
    public string? Color { get; set; }
    public Guid? ModelId { get; set; }
    public Guid? SubModelReleaseId { get; set; }
}

public class GetCarAdDto : GetTransportAdDto
{
    [JsonPropertyOrder(200)]
    public new CarSpecsDto? Specs { get; set; }
}
