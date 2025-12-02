using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Vehicles;

// Base Truck DTO for updates (all fields optional)
public class TruckAdDto : TransportAdDto
{
    public int? DistanceKm { get; set; }
    public float? LoadCapacity { get; set; }
    public byte? AxleCount { get; set; }
    public string? BrandName { get; set; }
}

// Create Truck DTO - BrandName is required
public class CreateTruckAdDto : TruckAdDto
{
}

// Truck specs for GET response
public class TruckSpecsDto : TransportSpecsDto
{
    public int? DistanceKm { get; set; }
    public float? LoadCapacity { get; set; }
    public byte? AxleCount { get; set; }
    public List<string>? ModelsSlugs { get; set; }
}

// GET response DTO for Truck
public class GetTruckAdDto : GetTransportAdDto
{
    [JsonPropertyOrder(200)]
    public new TruckSpecsDto? Specs { get; set; }
}
