namespace ClassifiedAds.Domain.Common.ValueObjects;

/// <summary>
/// Price value object stored in MongoDB.
/// Currency type and display format are determined by server based on category rules.
/// </summary>
public class Price
{

    public decimal Value { get; set; }

    public bool IsDollar { get; set; }

    public string ShowingPrice { get; set; }
}
