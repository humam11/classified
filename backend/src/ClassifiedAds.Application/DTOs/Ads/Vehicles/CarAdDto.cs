using ClassifiedAds.Domain.Entities.Ads.Vehicles.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Vehicles;

// Base Car DTO for updates (all fields optional)
public class CarAdDto : TransportAdDto
{
    public int? DistanceKm { get; set; }
    public string? EngineDescription { get; set; }
    public byte? Cylinders { get; set; }
    public Transmission? Transmission { get; set; }
    public CarDriveType? DriveType { get; set; }
    public string? Color { get; set; }
    public string? BrandName { get; set; }
    public string? ModelName { get; set; }
    public string? ReleaseYear { get; set; }
}

// Create Car DTO - BrandName, ModelName, ReleaseYear are required
public class CreateCarAdDto : CarAdDto
{
}

// Car specs for GET response
public class CarSpecsDto : TransportSpecsDto
{
    public int? DistanceKm { get; set; }
    public string? EngineDescription { get; set; }
    public byte? Cylinders { get; set; }
    public Transmission? Transmission { get; set; }
    public CarDriveType? DriveType { get; set; }
    public string? Color { get; set; }
    public List<string>? ModelsSlugs { get; set; }
    public string? ReleaseYear { get; set; }
}

// GET response DTO for Car
public class GetCarAdDto : GetTransportAdDto
{
    [JsonPropertyOrder(200)]
    public new CarSpecsDto? Specs { get; set; }
}
