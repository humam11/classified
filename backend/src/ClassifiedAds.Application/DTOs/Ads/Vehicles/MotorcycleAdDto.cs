using ClassifiedAds.Domain.Entities.Ads.Vehicles.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Vehicles;

public class MotorcycleAdDto : TransportAdDto
{
    public MotorcycleDriveType? MotorcycleDriveType { get; set; }
    public byte? GearCount { get; set; }
    // Brand resolution input (brand only for motorcycles)
    public string? BrandName { get; set; }
}

public class CreateMotorcycleAdDto : MotorcycleAdDto
{
    // EMPTY — inherits everything
}

public class MotorcycleSpecsDto : TransportSpecsDto
{
    public MotorcycleDriveType? MotorcycleDriveType { get; set; }
    public byte? GearCount { get; set; }
    // Resolved brand slugs stored in MongoDB
    public List<string>? ModelsSlugs { get; set; }
}

public class GetMotorcycleAdDto : GetTransportAdDto
{
    [JsonPropertyOrder(200)]
    public new MotorcycleSpecsDto? Specs { get; set; }
}
