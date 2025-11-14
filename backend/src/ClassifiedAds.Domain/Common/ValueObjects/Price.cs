namespace ClassifiedAds.Domain.Common.ValueObjects;

public class Price
{
    public decimal Value { get; set; }
    public bool IsDollar { get; set; }
    public string ShowingPrice { get; set; }
}
