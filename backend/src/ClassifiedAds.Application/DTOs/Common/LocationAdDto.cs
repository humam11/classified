using System.ComponentModel.DataAnnotations;

namespace ClassifiedAds.Application.DTOs.Common;

/// <summary>
/// Location information for an ad.
/// User provides location names, server resolves them to IDs using the locations table.
/// </summary>
public class LocationAdDto
{
    /// <summary>
    /// City name (Arabic or Kurdish depending on language context)
    /// </summary>
    /// <example>بغداد</example>
    [Required]
    [MaxLength(50)]
    public string City { get; set; }

    /// <summary>
    /// Region/District name within the city (Arabic or Kurdish) - Optional
    /// </summary>
    /// <example>الكرادة</example>
    [MaxLength(50)]
    public string? Region { get; set; }

    /// <summary>
    /// Neighborhood name within the region (Arabic or Kurdish) - Optional
    /// </summary>
    /// <example>الكرادة الشرقية</example>
    [MaxLength(50)]
    public string? Neighborhood { get; set; }

    /// <summary>
    /// Street address (optional, max 100 characters)
    /// </summary>
    /// <example>شارع الكرادة، بناية 15</example>
    [MaxLength(100)]
    public string? Street { get; set; }
}