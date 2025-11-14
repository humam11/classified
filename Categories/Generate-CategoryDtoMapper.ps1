# PowerShell Script to Generate CategoryDtoMapper from Arabic and Kurdish files

$arabicFile = "Categories/Attributes-detection-transformed-ar.txt"
$kurdishFile = "Categories/Attributes-detection-transformed-kr.txt"
$outputFile = "backend/src/ClassifiedAds.Application/Services/CategoryDtoMapper.cs"

# Read files
$arabicLines = Get-Content $arabicFile -Encoding UTF8
$kurdishLines = Get-Content $kurdishFile -Encoding UTF8

# Parse lines into hashtable: DTO -> List of (language, slug)
$dtoMappings = @{}

foreach ($line in $arabicLines) {
    if ($line -match '^(.+?)\s+--\s+(.+?)$') {
        $slug = $matches[1].Trim()
        $dto = $matches[2].Trim()
        
        if (-not $dtoMappings.ContainsKey($dto)) {
            $dtoMappings[$dto] = @()
        }
        
        $dtoMappings[$dto] += @{
            Language = "ar"
            Slug = $slug
        }
    }
}

foreach ($line in $kurdishLines) {
    if ($line -match '^(.+?)\s+--\s+(.+?)$') {
        $slug = $matches[1].Trim()
        $dto = $matches[2].Trim()
        
        if (-not $dtoMappings.ContainsKey($dto)) {
            $dtoMappings[$dto] = @()
        }
        
        $dtoMappings[$dto] += @{
            Language = "kr"
            Slug = $slug
        }
    }
}

# Group by DTO and separate Arabic/Kurdish
$arabicMap = @{}
$kurdishMap = @{}

foreach ($dto in $dtoMappings.Keys) {
    $entries = $dtoMappings[$dto]
    
    foreach ($entry in $entries) {
        if ($entry.Language -eq "ar") {
            $arabicMap[$entry.Slug] = $dto
        } else {
            $kurdishMap[$entry.Slug] = $dto
        }
    }
}

# Generate C# code
$csCode = @"
using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Electronics.HandheldDevice;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Application.DTOs.Ads.Vehicles;
using ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;
using ClassifiedAds.Application.DTOs.Ads.RealEstate;
using ClassifiedAds.Application.DTOs.Ads.JobsServices;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;

namespace ClassifiedAds.Application.Services;

/// <summary>
/// Maps category slugs to their corresponding DTO types
/// Auto-generated from Attributes-detection-transformed files
/// </summary>
public static class CategoryDtoMapper
{
    private static readonly Dictionary<string, Type> _arabicCategoryMap = new()
    {
"@

# Add Arabic mappings
$sortedArabicKeys = $arabicMap.Keys | Sort-Object
foreach ($slug in $sortedArabicKeys) {
    $dto = $arabicMap[$slug]
    $dtoType = $dto -replace '\.cs$', ''
    $csCode += "`n        [`"$slug`"] = typeof($dtoType),"
}

$csCode += @"

    };

    private static readonly Dictionary<string, Type> _kurdishCategoryMap = new()
    {
"@

# Add Kurdish mappings
$sortedKurdishKeys = $kurdishMap.Keys | Sort-Object
foreach ($slug in $sortedKurdishKeys) {
    $dto = $kurdishMap[$slug]
    $dtoType = $dto -replace '\.cs$', ''
    $csCode += "`n        [`"$slug`"] = typeof($dtoType),"
}

$csCode += @"

    };

    /// <summary>
    /// Gets the DTO type for a given category slug and language
    /// </summary>
    /// <param name="categorySlug">The category slug (e.g., "مركبات-ونقل/سيارات")</param>
    /// <param name="language">Language code ("ar" or "kr")</param>
    /// <returns>The corresponding DTO type, or null if not found</returns>
    public static Type? GetDtoType(string categorySlug, string language)
    {
        var map = language.ToLower() == "ar" ? _arabicCategoryMap : _kurdishCategoryMap;
        return map.TryGetValue(categorySlug, out var type) ? type : null;
    }

    /// <summary>
    /// Checks if a category slug is supported for the given language
    /// </summary>
    public static bool IsCategorySupported(string categorySlug, string language)
    {
        return GetDtoType(categorySlug, language) != null;
    }

    /// <summary>
    /// Gets all supported category slugs for a language
    /// </summary>
    public static IEnumerable<string> GetAllCategorySlugs(string language)
    {
        var map = language.ToLower() == "ar" ? _arabicCategoryMap : _kurdishCategoryMap;
        return map.Keys;
    }

    /// <summary>
    /// Gets the DTO type name for a category slug
    /// </summary>
    public static string? GetDtoTypeName(string categorySlug, string language)
    {
        var type = GetDtoType(categorySlug, language);
        return type?.Name;
    }
}
"@

# Write to file
$csCode | Out-File -FilePath $outputFile -Encoding UTF8

Write-Host "✅ CategoryDtoMapper generated successfully!" -ForegroundColor Green
Write-Host "📁 Output: $outputFile" -ForegroundColor Cyan
Write-Host "📊 Arabic mappings: $($arabicMap.Count)" -ForegroundColor Yellow
Write-Host "📊 Kurdish mappings: $($kurdishMap.Count)" -ForegroundColor Yellow
Write-Host "📊 Total unique DTOs: $($dtoMappings.Keys.Count)" -ForegroundColor Yellow
