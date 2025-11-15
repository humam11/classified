namespace ClassifiedAds.Application.Interfaces;

/// <summary>
/// Service for resolving category slugs to category IDs from PostgreSQL
/// </summary>
public interface ICategoryService
{
    /// <summary>
    /// Resolves category slug path to category IDs and metadata from PostgreSQL
    /// </summary>
    /// <param name="categorySlug">Full category path slug (e.g., "مركبات-ونقل/سيارات")</param>
    /// <param name="language">Language code (ar or kr)</param>
    /// <returns>Tuple of (CategoryIds, CategoryJoins)</returns>
    Task<(List<ushort> CategoryIds, byte CategoryJoins)> ResolveCategoryAsync(
        string categorySlug,
        string language);
}
