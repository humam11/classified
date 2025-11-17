using ClassifiedAds.Domain.Entities.Ads.Vehicles.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Vehicles;

public class MotorcycleAdDto : TransportAdDto
{
    public MotorcycleDriveType MotorcycleDriveType { get; set; }
    public byte GearCount { get; set; }
    public Guid ModelId { get; set; }
}
