using System.ComponentModel.DataAnnotations;

namespace ClassifiedAds.Application.DTOs.Common;

/// <summary>
/// Price information for an ad
/// </summary>
public class PriceDto
{
    /// <summary>
    /// Price value
    /// </summary>
    /// <example>35000</example>
    [Required]
    public decimal Value { get; set; }

    /// <summary>
    /// Whether the price is in USD (true) or IQD (false)
    /// </summary>
    /// <example>true</example>
    [Required]
    public bool IsDollar { get; set; }

    /// <summary>
    /// Display text for the price (e.g., "35,000 USD" or "قابل للتفاوض")
    /// </summary>
    /// <example>35,000 USD</example>
    [Required]
    public string ShowingPrice { get; set; }
}
