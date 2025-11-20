using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Electronics;

public class TvMonitorAdDto : ElectronicAdDto
{
    public float? ScreenSize { get; set; }
    public ScreenResolution? ScreenResolution { get; set; }
    public YesNo? SmartTv { get; set; }
    public RefreshRate? RefreshRate { get; set; }
    public byte? HdmiPorts { get; set; }
    public byte? UsbPorts { get; set; }
    public Guid? ModelId { get; set; }
}

public class CreateTvMonitorAdDto : TvMonitorAdDto
{
    // EMPTY — inherits everything
}

public class TvMonitorSpecsDto : ElectronicSpecsDto
{
    public float? ScreenSize { get; set; }
    public ScreenResolution? ScreenResolution { get; set; }
    public YesNo? SmartTv { get; set; }
    public RefreshRate? RefreshRate { get; set; }
    public byte? HdmiPorts { get; set; }
    public byte? UsbPorts { get; set; }
    public Guid? ModelId { get; set; }
}

public class GetTvMonitorAdDto : GetElectronicAdDto
{
    [JsonPropertyOrder(200)]
    public new TvMonitorSpecsDto? Specs { get; set; }
}
