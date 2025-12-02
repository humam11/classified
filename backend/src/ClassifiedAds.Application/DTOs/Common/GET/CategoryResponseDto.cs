namespace ClassifiedAds.Application.DTOs.Common;

/// <summary>
/// Category DTO for GET responses (matches MongoDB structure)
/// </summary>
public class CategoryResponseDto
{
    /// <summary>
    /// Progressive Arabic slug paths
    /// Example: ["مركبات-ونقل", "مركبات-ونقل/سيارات"]
    /// </summary>
    public List<string> CategoriesSlugsArabic { get; set; } = new();

    /// <summary>
    /// Progressive Kurdish slug paths
    /// Example: ["ئۆتۆمبێل-و-گواستنەوە", "ئۆتۆمبێل-و-گواستنەوە/ئۆتۆمبێل"]
    /// </summary>
    public List<string> CategoriesSlugsKurdish { get; set; } = new();
}
