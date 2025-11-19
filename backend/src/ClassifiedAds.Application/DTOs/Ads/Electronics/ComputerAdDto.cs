using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Electronics;

public class ComputerAdDto : ElectronicAdDto
{
    public string? CPU { get; set; }
    public RamSize? RamSize { get; set; }
    public YesNo? IsSSD { get; set; }
    public StorageCapacity? StorageCapacity { get; set; }
    public string? GraphicsCard { get; set; }
    public byte? UsbPorts { get; set; }
    public byte? HdmiPorts { get; set; }
}

public class CreateComputerAdDto : ComputerAdDto
{
    // EMPTY — inherits everything
}
