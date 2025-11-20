using ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Electronics;

public class VideoConsoleAdDto : ElectronicAdDto
{
    public StorageCapacity? StorageCapacity { get; set; }
    public Region? ConsoleRegion { get; set; }
    public Guid? ModelId { get; set; }
}

public class CreateVideoConsoleAdDto : VideoConsoleAdDto
{
    // EMPTY — inherits everything
}

public class VideoConsoleSpecsDto : ElectronicSpecsDto
{
    public StorageCapacity? StorageCapacity { get; set; }
    public Region? ConsoleRegion { get; set; }
    public Guid? ModelId { get; set; }
}

public class GetVideoConsoleAdDto : GetElectronicAdDto
{
    [JsonPropertyOrder(200)]
    public new VideoConsoleSpecsDto? Specs { get; set; }
}
