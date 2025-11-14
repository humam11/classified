using System.ComponentModel.DataAnnotations;

namespace ClassifiedAds.Application.DTOs.Common;

/// <summary>
/// Location information for an ad
/// </summary>
public class LocationAdDto
{
    /// <summary>
    /// List of location IDs from country to neighborhood
    /// </summary>
    /// <example>[1, 5, 23]</example>
    [Required]
    [MinLength(1)]
    public List<ushort> LocationIds { get; set; }

    /// <summary>
    /// Street address (optional, max 100 characters)
    /// </summary>
    /// <example>شارع الكرادة، بناية 15</example>
    [MaxLength(100)]
    public string Street { get; set; }
}