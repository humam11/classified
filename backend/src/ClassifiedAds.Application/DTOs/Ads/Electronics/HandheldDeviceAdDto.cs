using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Electronics;

public class HandheldDeviceAdDto : ElectronicAdDto
{
    public StorageCapacity? StorageCapacity { get; set; }
    public RamSize? RamSize { get; set; }
    public Color? Color { get; set; }
    public YesNo? MainCamera { get; set; }
    public YesNo? FrontCamera { get; set; }
    public float? MainCameraResolution { get; set; }
    public float? FrontCameraResolution { get; set; }
    public ushort? BatteryCapacity { get; set; }
    public float? ScreenSize { get; set; }
    public string? Processor { get; set; }
    public YesNo? DualSim { get; set; }
    public YesNo? WaterproofSupport { get; set; }
    public YesNo? StylusSupport { get; set; }
    public Guid? ModelId { get; set; }
}

public class CreateHandheldDeviceAdDto : HandheldDeviceAdDto
{
    // EMPTY — inherits everything
}

public class HandheldDeviceSpecsDto : ElectronicSpecsDto
{
    public StorageCapacity? StorageCapacity { get; set; }
    public RamSize? RamSize { get; set; }
    public Color? Color { get; set; }
    public YesNo? MainCamera { get; set; }
    public YesNo? FrontCamera { get; set; }
    public float? MainCameraResolution { get; set; }
    public float? FrontCameraResolution { get; set; }
    public ushort? BatteryCapacity { get; set; }
    public float? ScreenSize { get; set; }
    public string? Processor { get; set; }
    public YesNo? DualSim { get; set; }
    public YesNo? WaterproofSupport { get; set; }
    public YesNo? StylusSupport { get; set; }
    public Guid? ModelId { get; set; }
}

public class GetHandheldDeviceAdDto : GetElectronicAdDto
{
    [JsonPropertyOrder(200)]
    public new HandheldDeviceSpecsDto? Specs { get; set; }
}
