namespace ClassifiedAds.Application.DTOs.Ads.Miscellaneous;

public class CreateTireWheelAdDto : CreateAdDto
{
    public ushort Width { get; set; }
    public byte AspectRatio { get; set; }
    public byte RimDiameter { get; set; }
}
