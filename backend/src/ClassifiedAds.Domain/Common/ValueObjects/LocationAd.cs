namespace ClassifiedAds.Domain.Common.ValueObjects;

public class LocationAd
{
    public List<ushort> LocationIds { get; set; }
    public string FullAddressArabic { get; set; }
    public string FullAddressKurdish { get; set; }
    public string Street { get; set; }
}
