namespace ClassifiedAds.Application.DTOs.Ads.Vehicles;

public class BoatAdDto : TransportAdDto
{
    public float? Length { get; set; }
    public byte? Capacity { get; set; }
}

public class CreateBoatAdDto : BoatAdDto
{
    // EMPTY — inherits everything
}
