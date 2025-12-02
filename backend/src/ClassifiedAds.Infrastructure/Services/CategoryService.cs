using ClassifiedAds.Application.Interfaces;
using ClassifiedAds.Infrastructure.Data.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace ClassifiedAds.Infrastructure.Services;

// Service for resolving category slugs using PostgreSQL categories table
public class CategoryService : ICategoryService
{
    private readonly PostgresDbContext _context;

    public CategoryService(PostgresDbContext context)
    {
        _context = context;
    }

    // Gets the leaf category ID from a full slug path
    public async Task<ushort> GetCategoryIdFromSlugAsync(string categorySlug, string language)
    {
        if (string.IsNullOrWhiteSpace(categorySlug))
            throw new ArgumentException("Category slug cannot be empty");

        if (language != "ar" && language != "kr")
            throw new ArgumentException($"Invalid language: {language}. Must be 'ar' or 'kr'");

        var category = language == "ar"
            ? await _context.Categories.FirstOrDefaultAsync(c => c.UrlSlugArabic == categorySlug)
            : await _context.Categories.FirstOrDefaultAsync(c => c.UrlSlugKurdish == categorySlug);

        if (category == null)
            throw new ArgumentException($"Category not found for slug '{categorySlug}' in language '{language}'");

        return category.CategoryID;
    }

    // Resolves category slug path to both Arabic and Kurdish slugs (progressive paths)
    // Validates parent_id chain via self-joins
    public async Task<(List<string> ArabicSlugs, List<string> KurdishSlugs)> ResolveCategorySlugsAsync(
        string categorySlug,
        string language)
    {
        var arabicSlugs = new List<string>();
        var kurdishSlugs = new List<string>();

        var slugParts = categorySlug.Split('/', StringSplitOptions.RemoveEmptyEntries);

        if (slugParts.Length == 0)
            throw new ArgumentException("Category slug cannot be empty");

        if (language != "ar" && language != "kr")
            throw new ArgumentException($"Invalid language: {language}. Must be 'ar' or 'kr'");

        ushort? expectedParentId = null;
        string currentSlugPath = "";

        for (int i = 0; i < slugParts.Length; i++)
        {
            var slugPart = slugParts[i];
            currentSlugPath = i == 0 ? slugPart : $"{currentSlugPath}/{slugPart}";

            var category = language == "ar"
                ? await _context.Categories.FirstOrDefaultAsync(c => c.UrlSlugArabic == currentSlugPath)
                : await _context.Categories.FirstOrDefaultAsync(c => c.UrlSlugKurdish == currentSlugPath);

            if (category == null)
                throw new ArgumentException($"Category not found for slug path '{currentSlugPath}' in language '{language}'. Full requested path: '{categorySlug}'");

            // Validate parent_id chain
            if (i == 0)
            {
                if (category.ParentID != null)
                    throw new ArgumentException($"Invalid category hierarchy: '{currentSlugPath}' should be a root category but has parent_id = {category.ParentID}");
            }
            else
            {
                if (category.ParentID != expectedParentId)
                    throw new ArgumentException($"Invalid category hierarchy: '{currentSlugPath}' has parent_id = {category.ParentID}, expected {expectedParentId}");
            }

            arabicSlugs.Add(category.UrlSlugArabic);
            kurdishSlugs.Add(category.UrlSlugKurdish);
            expectedParentId = category.CategoryID;
        }

        return (arabicSlugs, kurdishSlugs);
    }
}
