using ClassifiedAds.Domain.Entities.Ads.Vehicles.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Vehicles;

public class CreateTransportAdDto : CreateAdDto
{
    public FuelType FuelType { get; set; }
    public ushort EnginePower { get; set; }
    public ushort FuelTankCapacity { get; set; }
}
