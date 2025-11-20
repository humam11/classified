using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Vehicles;

public class BoatAdDto : TransportAdDto
{
    public float? Length { get; set; }
    public byte? Capacity { get; set; }
}

public class CreateBoatAdDto : BoatAdDto
{
    // EMPTY — inherits everything
}

public class BoatSpecsDto : TransportSpecsDto
{
    public float? Length { get; set; }
    public byte? Capacity { get; set; }
}

public class GetBoatAdDto : GetTransportAdDto
{
    [JsonPropertyOrder(200)]
    public new BoatSpecsDto? Specs { get; set; }
}
