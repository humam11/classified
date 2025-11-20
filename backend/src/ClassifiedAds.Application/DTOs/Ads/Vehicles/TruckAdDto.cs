using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Vehicles;

public class TruckAdDto : TransportAdDto
{
    public int? DistanceKm { get; set; }
    public float? LoadCapacity { get; set; }
    public byte? AxleCount { get; set; }
    public Guid? ModelId { get; set; }
}

public class CreateTruckAdDto : TruckAdDto
{
    // EMPTY — inherits everything
}

public class TruckSpecsDto : TransportSpecsDto
{
    public int? DistanceKm { get; set; }
    public float? LoadCapacity { get; set; }
    public byte? AxleCount { get; set; }
    public Guid? ModelId { get; set; }
}

public class GetTruckAdDto : GetTransportAdDto
{
    [JsonPropertyOrder(200)]
    public new TruckSpecsDto? Specs { get; set; }
}
