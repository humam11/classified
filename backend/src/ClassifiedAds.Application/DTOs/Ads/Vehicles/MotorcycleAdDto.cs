using ClassifiedAds.Domain.Entities.Ads.Vehicles.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Vehicles;

public class MotorcycleAdDto : TransportAdDto
{
    public MotorcycleDriveType? MotorcycleDriveType { get; set; }
    public byte? GearCount { get; set; }
    public Guid? ModelId { get; set; }
}

public class CreateMotorcycleAdDto : MotorcycleAdDto
{
    // EMPTY — inherits everything
}

public class MotorcycleSpecsDto : TransportSpecsDto
{
    public MotorcycleDriveType? MotorcycleDriveType { get; set; }
    public byte? GearCount { get; set; }
    public Guid? ModelId { get; set; }
}

public class GetMotorcycleAdDto : GetTransportAdDto
{
    [JsonPropertyOrder(200)]
    public new MotorcycleSpecsDto? Specs { get; set; }
}
