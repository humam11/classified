using ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Electronics;

public class ConsoleAdDto : ElectronicAdDto
{
    public StorageCapacity StorageCapacity { get; set; }
    public Region ConsoleRegion { get; set; }
    public Guid ModelId { get; set; }
}
