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

        // Traverse the hierarchy level by level
        for (int i = 0; i < slugParts.Length; i++)
        {
            var slugPart = slugParts[i];
            
            // Convert URL slug back to original category name
            // Reverse the transformation done in transform-categories.ps1:
            // Original: $_ -replace '\([^)]*\)', '' -replace '،', '' -replace ',', '' -replace '\s+', '-' -replace '-+', '-' -replace '^-|-$', ''
            // Reverse: Replace hyphens with spaces
            var categoryName = slugPart.Replace("-", " ");

            // Build query based on language and parent
            var query = _context.Categories.AsQueryable();

            if (language == "ar")
            {
                query = query.Where(c => c.NameArabic == categoryName);
            }
            else if (language == "kr")
            {
                query = query.Where(c => c.NameKurdish == categoryName);
            }
            else
            {
                throw new ArgumentException($"Invalid language: {language}. Must be 'ar' or 'kr'");
            }

            // Filter by parent (null for root level, specific ID for children)
            if (currentParentId == null)
            {
                // Root level category
                query = query.Where(c => c.ParentID == null);
            }
            else
            {
                // Child category
                query = query.Where(c => c.ParentID == currentParentId.Value);
            }

            var category = await query.FirstOrDefaultAsync();

            if (category == null)
            {
                var parentInfo = currentParentId == null ? "root level" : $"parent ID {currentParentId}";
                throw new ArgumentException(
                    $"Category slug '{slugPart}' not found at {parentInfo} for language '{language}'. " +
                    $"Full path: '{categorySlug}'");
            }

            // Add category ID to the list
            categoryIds.Add((ushort)category.CategoryID);

            // Set current category as parent for next iteration
            currentParentId = (ushort)category.CategoryID;
        }

        // CategoryJoins is the number of levels in the hierarchy
        byte categoryJoins = (byte)categoryIds.Count;

        return (categoryIds, categoryJoins);
    }
}
