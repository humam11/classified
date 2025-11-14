using ClassifiedAds.Application.DTOs.Common;
using System.ComponentModel.DataAnnotations;

namespace ClassifiedAds.Application.DTOs.Ads;

/// <summary>
/// Base DTO for creating any type of classified ad
/// </summary>
public class CreateAdDto
{
    /// <summary>
    /// Ad title (max 100 characters)
    /// </summary>
    /// <example>تويوتا كامري 2023 نظيفة جداً</example>
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    /// <summary>
    /// Ad description (max 1000 characters)
    /// </summary>
    /// <example>سيارة نظيفة جداً، استعمال شخصي، صيانة دورية منتظمة</example>
    [MaxLength(1000)]
    public string Description { get; set; }

    /// <summary>
    /// Price information
    /// </summary>
    [Required]
    public PriceDto Price { get; set; }

    /// <summary>
    /// Category information
    /// </summary>
    [Required]
    public CategoryDto Category { get; set; }

    /// <summary>
    /// Location information
    /// </summary>
    [Required]
    public LocationAdDto LocationAd { get; set; }

    /// <summary>
    /// Ad images (1-5 images required)
    /// </summary>
    [Required]
    [MinLength(1)]
    [MaxLength(5)]
    public List<AdImageDto> Images { get; set; }
}
