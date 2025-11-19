using ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;

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
