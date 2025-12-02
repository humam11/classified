namespace ClassifiedAds.Application.Interfaces;

// Service for resolving category slugs from PostgreSQL
public interface ICategoryService
{
    // Gets the leaf category ID from a full slug path
    // Example: "مركبات-ونقل/سيارات" → returns category_id of "سيارات"
    Task<ushort> GetCategoryIdFromSlugAsync(string categorySlug, string language);

    // Resolves category slug path to both Arabic and Kurdish slugs (progressive paths)
    // Example: "مركبات-ونقل/سيارات" → Arabic: ["مركبات-ونقل", "مركبات-ونقل/سيارات"]
    Task<(List<string> ArabicSlugs, List<string> KurdishSlugs)> ResolveCategorySlugsAsync(
        string categorySlug,
        string language);
}
