namespace ClassifiedAds.Application.Interfaces;

// Service for resolving brand/model/release from names to IDs and slugs
public interface IBrandModelReleaseService
{
    // Resolves brand name to brand ID and slug for a given category (Trucks - brand only)
    Task<(ushort BrandId, List<string> ModelsSlugs)> ResolveBrandAsync(
        string categorySlug,
        string language,
        string brandName);

    // Resolves brand and model names to IDs and slugs (Cars - brand + model)
    Task<(ushort ModelId, List<string> ModelsSlugs)> ResolveBrandModelAsync(
        string categorySlug,
        string language,
        string brandName,
        string modelName);

    // Resolves release year for a given model (Cars - release year)
    Task<(ushort ReleaseId, string ReleaseYear)> ResolveReleaseAsync(
        ushort modelId,
        string releaseYear);
}
