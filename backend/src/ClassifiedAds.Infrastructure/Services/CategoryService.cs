using ClassifiedAds.Application.Interfaces;
using ClassifiedAds.Infrastructure.Data.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace ClassifiedAds.Infrastructure.Services;

/// <summary>
/// Service for resolving category slugs to IDs using PostgreSQL categories table
/// </summary>
public class CategoryService : ICategoryService
{
    private readonly PostgresDbContext _context;

    public CategoryService(PostgresDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Resolves category slug path to category IDs using hierarchical self-join
    /// Example: "مركبات-ونقل/سيارات" → finds parent "مركبات-ونقل", then child "سيارات"
    /// </summary>
    public async Task<(List<ushort> CategoryIds, byte CategoryJoins)> ResolveCategoryAsync(
        string categorySlug,
        string language)
    {
        var categoryIds = new List<ushort>();

        // Split the slug by '/' to get hierarchy levels
        var slugParts = categorySlug.Split('/', StringSplitOptions.RemoveEmptyEntries);

        if (slugParts.Length == 0)
        {
            throw new ArgumentException("Category slug cannot be empty");
        }

        ushort? currentParentId = null;

        // Build the full slug path progressively to match against url_slug columns
        string currentSlugPath = "";
        
        // Traverse the hierarchy level by level
        for (int i = 0; i < slugParts.Length; i++)
        {
            var slugPart = slugParts[i];
            
            // Build progressive slug path (e.g., "مركبات-ونقل", then "مركبات-ونقل/سيارات")
            currentSlugPath = i == 0 ? slugPart : $"{currentSlugPath}/{slugPart}";

            // Build query based on language - match against url_slug columns
            var query = _context.Categories.AsQueryable();

            if (language == "ar")
            {
                query = query.Where(c => c.UrlSlugArabic == currentSlugPath);
            }
            else if (language == "kr")
            {
                query = query.Where(c => c.UrlSlugKurdish == currentSlugPath);
            }
            else
            {
                throw new ArgumentException($"Invalid language: {language}. Must be 'ar' or 'kr'");
            }

            var category = await query.FirstOrDefaultAsync();

            if (category == null)
            {
                throw new ArgumentException(
                    $"Category not found for slug path '{currentSlugPath}' in language '{language}'. " +
                    $"Full requested path: '{categorySlug}'");
            }

            // Add category ID to the list
            categoryIds.Add((ushort)category.CategoryID);

            // Set current category as parent for next iteration (for validation purposes)
            currentParentId = (ushort)category.CategoryID;
        }

        // CategoryJoins is the number of levels in the hierarchy
        byte categoryJoins = (byte)categoryIds.Count;

        return (categoryIds, categoryJoins);
    }
}
