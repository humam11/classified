using System.ComponentModel.DataAnnotations;

namespace ClassifiedAds.Application.DTOs.Common;

/// <summary>
/// Image information for an ad
/// </summary>
public class AdImageDto
{
    /// <summary>
    /// Image ID (auto-generated, leave null when creating)
    /// </summary>
    public string? ImageId { get; set; }

    /// <summary>
    /// Image URL (must be a valid URL)
    /// </summary>
    /// <example>https://example.com/images/car-front.jpg</example>
    [Required]
    [Url]
    public string ImageUrl { get; set; }

    /// <summary>
    /// Display order (1-5)
    /// </summary>
    /// <example>1</example>
    [Required]
    [Range(1, 5)]
    public byte Order { get; set; }
}
