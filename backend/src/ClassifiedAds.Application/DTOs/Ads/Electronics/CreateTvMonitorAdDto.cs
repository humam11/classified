using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Electronics;

public class CreateTvMonitorAdDto : CreateElectronicAdDto
{
    public float ScreenSize { get; set; }
    public ScreenResolution ScreenResolution { get; set; }
    public YesNo SmartTv { get; set; }
    public RefreshRate RefreshRate { get; set; }
    public byte HdmiPorts { get; set; }
    public byte UsbPorts { get; set; }
    public Guid ModelId { get; set; }
}
