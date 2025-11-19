namespace ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;

public class BusAdDto : HeavyEquipmentAdDto
{
    public byte? SeatingCapacity { get; set; }
}

public class CreateBusAdDto : BusAdDto
{
    // EMPTY — inherits everything
}
