using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Miscellaneous;

public class TireWheelAdDto : AdDto
{
    public ushort? Width { get; set; }
    public byte? AspectRatio { get; set; }
    public byte? RimDiameter { get; set; }
}

public class CreateTireWheelAdDto : TireWheelAdDto
{
    // EMPTY — inherits everything
}

public class TireWheelSpecsDto
{
    public ushort? Width { get; set; }
    public byte? AspectRatio { get; set; }
    public byte? RimDiameter { get; set; }
}

public class GetTireWheelAdDto : GetAdDto
{
    [JsonPropertyOrder(100)]
    public TireWheelSpecsDto? Specs { get; set; }
}
