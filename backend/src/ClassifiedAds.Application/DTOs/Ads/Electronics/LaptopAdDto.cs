using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Electronics;

public class LaptopAdDto : ElectronicAdDto
{
    public string Cpu { get; set; }
    public RamSize RamSize { get; set; }
    public YesNo IsSSD { get; set; }
    public StorageCapacity StorageCapacity { get; set; }
    public string GraphicsCard { get; set; }
    public byte UsbPorts { get; set; }
    public byte HdmiPorts { get; set; }
    public float ScreenSize { get; set; }
    public YesNo IsTouchscreen { get; set; }
    public string Resolution { get; set; }
    public YesNo IsBacklitKeyboard { get; set; }
    public YesNo HasWebcam { get; set; }
    public WebcamResolution WebcamResolution { get; set; }
    public YesNo HasFingerprintReader { get; set; }
    public Color Color { get; set; }
    public Guid ModelId { get; set; }
}
