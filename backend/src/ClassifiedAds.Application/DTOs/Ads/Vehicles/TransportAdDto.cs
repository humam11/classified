using ClassifiedAds.Domain.Entities.Ads.Vehicles.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Vehicles;

public class TransportAdDto : AdDto
{
    public FuelType? FuelType { get; set; }
    public ushort? EnginePower { get; set; }
    public ushort? FuelTankCapacity { get; set; }
}

public class CreateTransportAdDto : TransportAdDto
{
    // EMPTY — inherits everything
}

public class TransportSpecsDto
{
    public FuelType? FuelType { get; set; }
    public ushort? EnginePower { get; set; }
    public ushort? FuelTankCapacity { get; set; }
}

public class GetTransportAdDto : GetAdDto
{
    [JsonPropertyOrder(100)]
    public TransportSpecsDto? Specs { get; set; }
}
