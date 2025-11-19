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
