namespace ClassifiedAds.Domain.Common.ValueObjects;

/// <summary>
/// Category value object for MongoDB storage
/// Stores progressive slug paths for both Arabic and Kurdish
/// </summary>
public class Category
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
