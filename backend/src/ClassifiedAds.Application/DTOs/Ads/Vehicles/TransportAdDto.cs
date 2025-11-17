using ClassifiedAds.Domain.Entities.Ads.Vehicles.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Vehicles;

public class TransportAdDto : AdDto
{
    public FuelType FuelType { get; set; }
    public ushort EnginePower { get; set; }
    public ushort FuelTankCapacity { get; set; }
}
