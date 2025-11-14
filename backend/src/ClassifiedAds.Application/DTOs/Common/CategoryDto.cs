using System.ComponentModel.DataAnnotations;

namespace ClassifiedAds.Application.DTOs.Common;

/// <summary>
/// Category information for an ad
/// </summary>
public class CategoryDto
{
    /// <summary>
    /// Number of category levels (e.g., 2 for "مركبات-ونقل/سيارات")
    /// </summary>
    /// <example>2</example>
    [Required]
    public byte CategoryJoins { get; set; }

    /// <summary>
    /// List of category IDs from root to leaf
    /// </summary>
    /// <example>[1, 15]</example>
    [Required]
    [MinLength(1)]
    public List<ushort> CategoryIds { get; set; }
}
