using ClassifiedAds.Application.Interfaces;
using ClassifiedAds.Infrastructure.Data.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace ClassifiedAds.Infrastructure.Services;

// Service for resolving brand/model/release from names to IDs and slugs
public class BrandModelReleaseService : IBrandModelReleaseService
{
    private readonly PostgresDbContext _context;
    private readonly ICategoryService _categoryService;

    public BrandModelReleaseService(PostgresDbContext context, ICategoryService categoryService)
    {
        _context = context;
        _categoryService = categoryService;
    }

    // Resolves brand name to brand ID and slug for a given category
    public async Task<(ushort BrandId, List<string> ModelsSlugs)> ResolveBrandAsync(
        string categorySlug,
        string language,
        string brandName)
    {
        if (string.IsNullOrWhiteSpace(brandName))
            throw new ArgumentException("Brand name is required");

        var categoryId = await _categoryService.GetCategoryIdFromSlugAsync(categorySlug, language);

        var brand = await _context.BrandModels
            .Where(b => b.CategoryID == categoryId
                     && b.IsBrand == true
                     && b.ParentID == null
                     && b.NameEnglish.ToLower() == brandName.ToLower())
            .FirstOrDefaultAsync();

        if (brand == null)
            throw new ArgumentException($"Brand '{brandName}' not found for category '{categorySlug}'");

        var modelsSlugs = new List<string> { brand.UrlSlug };
        return (brand.BrandModelID, modelsSlugs);
    }

    // Resolves brand and model names to IDs and slugs for a given category
    public async Task<(ushort ModelId, List<string> ModelsSlugs)> ResolveBrandModelAsync(
        string categorySlug,
        string language,
        string brandName,
        string modelName)
    {
        if (string.IsNullOrWhiteSpace(brandName))
            throw new ArgumentException("Brand name is required");

        if (string.IsNullOrWhiteSpace(modelName))
            throw new ArgumentException("Model name is required");

        var categoryId = await _categoryService.GetCategoryIdFromSlugAsync(categorySlug, language);

        var brand = await _context.BrandModels
            .Where(b => b.CategoryID == categoryId
                     && b.IsBrand == true
                     && b.ParentID == null
                     && b.NameEnglish.ToLower() == brandName.ToLower())
            .FirstOrDefaultAsync();

        if (brand == null)
            throw new ArgumentException($"Brand '{brandName}' not found for category '{categorySlug}'");

        var model = await _context.BrandModels
            .Where(m => m.ParentID == brand.BrandModelID
                     && m.IsBrand == false
                     && m.NameEnglish.ToLower() == modelName.ToLower())
            .FirstOrDefaultAsync();

        if (model == null)
            throw new ArgumentException($"Model '{modelName}' not found for brand '{brandName}'");

        // model.UrlSlug already contains full path like "toyota/corolla"
        var modelsSlugs = new List<string>
        {
            brand.UrlSlug,
            model.UrlSlug
        };

        return (model.BrandModelID, modelsSlugs);
    }

    // Resolves release year for a given model
    public async Task<(ushort ReleaseId, string ReleaseYear)> ResolveReleaseAsync(
        ushort modelId,
        string releaseYear)
    {
        if (string.IsNullOrWhiteSpace(releaseYear))
            throw new ArgumentException("Release year is required");

        var release = await _context.Releases
            .Where(r => r.ModelId == modelId && r.ReleaseYear == releaseYear)
            .FirstOrDefaultAsync();

        if (release == null)
            throw new ArgumentException($"Release year '{releaseYear}' not found for the specified model");

        return (release.ReleaseId, releaseYear);
    }
}
