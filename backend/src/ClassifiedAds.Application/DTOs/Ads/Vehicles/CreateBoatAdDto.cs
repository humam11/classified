namespace ClassifiedAds.Application.DTOs.Ads.Vehicles;

public class CreateBoatAdDto : CreateTransportAdDto
{
    public float Length { get; set; }
    public byte Capacity { get; set; }
}
