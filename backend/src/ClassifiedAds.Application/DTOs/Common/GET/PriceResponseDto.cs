namespace ClassifiedAds.Application.DTOs.Common;

/// <summary>
/// Price DTO for GET responses (matches MongoDB structure)
/// </summary>
public class PriceResponseDto
{
    public decimal Value { get; set; }
    public bool IsDollar { get; set; }
    public string ShowingPrice { get; set; }
}
