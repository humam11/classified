using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.Interfaces;
using ClassifiedAds.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using FluentValidation;

namespace ClassifiedAds.Api.Controllers;

// Dynamic controller that handles all category slugs with SEO-friendly URLs
[ApiController]
[Route("api")]
public class DynamicAdsController : ControllerBase
{
    private readonly IAdService _adService;
    private readonly ILogger<DynamicAdsController> _logger;

    public DynamicAdsController(IAdService adService, ILogger<DynamicAdsController> logger)
    {
        _adService = adService;
        _logger = logger;
    }

    #region Search/Listing Endpoints

    // Dynamic route handler for all category-based URLs
    // Handles both search (ends with /ads) and single ad viewing (ends with /ads/{adSlug})
    // GET {lang}/categories/{**path}
    [HttpGet("{lang}/categories/{**path}", Order = 10)]
    public async Task<ActionResult<object>> HandleCategoryRoute(
        [FromRoute] string lang,
        [FromRoute] string path)
    {
        try
        {
            if (lang != "ar" && lang != "kr")
                return BadRequest(new { error = "Language must be 'ar' or 'kr'" });

            // Check if this is a single ad request (contains /ads/ followed by a slug)
            var adsIndex = path.LastIndexOf("/ads/", StringComparison.OrdinalIgnoreCase);
            if (adsIndex >= 0)
            {
                var adSlug = path[(adsIndex + 5)..];
                var beforeAds = path[..adsIndex];
                return await HandleSingleAdRequest(lang, beforeAds, adSlug);
            }

            // Check if this is a search endpoint (ends with /ads)
            if (!path.EndsWith("/ads", StringComparison.OrdinalIgnoreCase))
                return BadRequest(new { error = "URL must end with /ads for search or /ads/{adSlug} for single ad" });

            var categorySlug = path[..^4]; // Remove "/ads"

            // Check if URL contains /models/ - route to brand/model search
            if (categorySlug.Contains("/models/"))
                return await HandleBrandModelSearch(lang, categorySlug);

            var ads = await _adService.SearchAdsByCategoryAsync(categorySlug, lang);
            return Ok(ads);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error handling category route: {Path}", path);
            return BadRequest(new { error = ex.Message });
        }
    }

    private async Task<ActionResult<object>> HandleSingleAdRequest(string lang, string pathBeforeAds, string adSlug)
    {
        var ad = await _adService.GetAdBySlugAsync(adSlug);
        if (ad == null)
            return NotFound(new { error = "Ad not found" });

        // Get canonical URL info (includes correct category slug)
        var canonicalInfo = _adService.GetCanonicalUrlInfo(ad, lang);
        
        // Extract the category slug from the request path (before /models/ if present)
        var requestedCategorySlug = pathBeforeAds.Contains("/models/")
            ? pathBeforeAds[..pathBeforeAds.IndexOf("/models/", StringComparison.OrdinalIgnoreCase)]
            : pathBeforeAds;

        // Check if the requested category matches the ad's actual category
        var isCorrectCategory = requestedCategorySlug.Equals(canonicalInfo.CategorySlug, StringComparison.OrdinalIgnoreCase);
        
        // Check if the URL structure matches the canonical level
        var isCorrectLevel = canonicalInfo.Level switch
        {
            CanonicalUrlLevel.ReleaseYear => pathBeforeAds.Contains("/models/") && pathBeforeAds.Contains("/releases/"),
            CanonicalUrlLevel.BrandModel => pathBeforeAds.Contains("/models/") && !pathBeforeAds.Contains("/releases/"),
            CanonicalUrlLevel.CategoryOnly => !pathBeforeAds.Contains("/models/"),
            _ => true
        };

        // If category is wrong or URL level is wrong, redirect to canonical URL
        if (!isCorrectCategory || !isCorrectLevel)
        {
            var canonicalUrl = BuildCanonicalUrl(lang, canonicalInfo);
            return RedirectPermanent(canonicalUrl);
        }

        // For release year level, also verify the brand/model slug matches
        if (canonicalInfo.Level == CanonicalUrlLevel.ReleaseYear && !string.IsNullOrEmpty(canonicalInfo.BrandModelSlug))
        {
            var modelsIndex = pathBeforeAds.IndexOf("/models/", StringComparison.OrdinalIgnoreCase);
            if (modelsIndex >= 0)
            {
                var afterModels = pathBeforeAds[(modelsIndex + 8)..];
                var releasesIndex = afterModels.IndexOf("/releases/", StringComparison.OrdinalIgnoreCase);
                var requestedBrandModel = releasesIndex >= 0 ? afterModels[..releasesIndex] : afterModels;
                
                if (!requestedBrandModel.Equals(canonicalInfo.BrandModelSlug, StringComparison.OrdinalIgnoreCase))
                {
                    var canonicalUrl = BuildCanonicalUrl(lang, canonicalInfo);
                    return RedirectPermanent(canonicalUrl);
                }
            }
        }

        // For brand/model level, verify the brand/model slug matches
        if (canonicalInfo.Level == CanonicalUrlLevel.BrandModel && !string.IsNullOrEmpty(canonicalInfo.BrandModelSlug))
        {
            var modelsIndex = pathBeforeAds.IndexOf("/models/", StringComparison.OrdinalIgnoreCase);
            if (modelsIndex >= 0)
            {
                var requestedBrandModel = pathBeforeAds[(modelsIndex + 8)..];
                
                if (!requestedBrandModel.Equals(canonicalInfo.BrandModelSlug, StringComparison.OrdinalIgnoreCase))
                {
                    var canonicalUrl = BuildCanonicalUrl(lang, canonicalInfo);
                    return RedirectPermanent(canonicalUrl);
                }
            }
        }

        return Ok(ad);
    }

    private async Task<ActionResult<object>> HandleBrandModelSearch(string lang, string categorySlug)
    {
        // Parse: {categorySlug}/models/{brandModelSlug} or {categorySlug}/models/{brandModelSlug}/releases/{releaseYear}
        var modelsIndex = categorySlug.IndexOf("/models/", StringComparison.OrdinalIgnoreCase);
        var baseCategorySlug = categorySlug[..modelsIndex];
        var afterModels = categorySlug[(modelsIndex + 8)..]; // Skip "/models/"

        // Check for releases
        var releasesIndex = afterModels.IndexOf("/releases/", StringComparison.OrdinalIgnoreCase);
        if (releasesIndex >= 0)
        {
            var brandModelSlug = afterModels[..releasesIndex];
            var releaseYear = afterModels[(releasesIndex + 10)..]; // Skip "/releases/"

            var ads = await _adService.SearchAdsByReleaseYearAsync(baseCategorySlug, brandModelSlug, releaseYear, lang);
            return Ok(ads);
        }
        else
        {
            var brandModelSlug = afterModels;
            var ads = await _adService.SearchAdsByBrandModelAsync(baseCategorySlug, brandModelSlug, lang);
            return Ok(ads);
        }
    }

    #endregion

    #region Update/Delete Endpoints

    // Update ad by ID (short form)
    // PATCH {lang}/ads/{id}
    [HttpPatch("{lang}/ads/{id}")]
    [Consumes("multipart/form-data")]
    [DisableRequestSizeLimit]
    [RequestFormLimits(MultipartBodyLengthLimit = 52428800)]
    public async Task<ActionResult> UpdateAdById(
        [FromRoute] string lang,
        [FromRoute] string id,
        [FromForm] AdDto formDto)
    {
        return await UpdateAdInternal(lang, id, formDto);
    }

    // Update ad at category level
    // PATCH {lang}/categories/{categorySlug}/ads/{adSlug}
    [HttpPatch("{lang}/categories/{categorySlug}/ads/{adSlug}")]
    [Consumes("multipart/form-data")]
    [DisableRequestSizeLimit]
    [RequestFormLimits(MultipartBodyLengthLimit = 52428800)]
    public async Task<ActionResult> UpdateAdByCategoryAndSlug(
        [FromRoute] string lang,
        [FromRoute] string categorySlug,
        [FromRoute] string adSlug,
        [FromForm] AdDto formDto)
    {
        var ad = await _adService.GetAdBySlugAsync(adSlug);
        if (ad == null)
            return NotFound(new { error = "Ad not found" });

        var idProp = ad.GetType().GetProperty("Id");
        var id = idProp?.GetValue(ad)?.ToString();
        if (string.IsNullOrEmpty(id))
            return NotFound(new { error = "Ad ID not found" });

        return await UpdateAdInternal(lang, id, formDto);
    }


    // Update ad at brand/model level
    // PATCH {lang}/categories/{categorySlug}/models/{brandModelSlug}/ads/{adSlug}
    [HttpPatch("{lang}/categories/{categorySlug}/models/{brandModelSlug}/ads/{adSlug}")]
    [Consumes("multipart/form-data")]
    [DisableRequestSizeLimit]
    [RequestFormLimits(MultipartBodyLengthLimit = 52428800)]
    public async Task<ActionResult> UpdateAdByBrandModelAndSlug(
        [FromRoute] string lang,
        [FromRoute] string categorySlug,
        [FromRoute] string brandModelSlug,
        [FromRoute] string adSlug,
        [FromForm] AdDto formDto)
    {
        var ad = await _adService.GetAdBySlugAsync(adSlug);
        if (ad == null)
            return NotFound(new { error = "Ad not found" });

        var idProp = ad.GetType().GetProperty("Id");
        var id = idProp?.GetValue(ad)?.ToString();
        if (string.IsNullOrEmpty(id))
            return NotFound(new { error = "Ad ID not found" });

        return await UpdateAdInternal(lang, id, formDto);
    }

    // Update ad at release year level
    // PATCH {lang}/categories/{categorySlug}/models/{brandModelSlug}/releases/{releaseYear}/ads/{adSlug}
    [HttpPatch("{lang}/categories/{categorySlug}/models/{brandModelSlug}/releases/{releaseYear}/ads/{adSlug}")]
    [Consumes("multipart/form-data")]
    [DisableRequestSizeLimit]
    [RequestFormLimits(MultipartBodyLengthLimit = 52428800)]
    public async Task<ActionResult> UpdateAdByReleaseYearAndSlug(
        [FromRoute] string lang,
        [FromRoute] string categorySlug,
        [FromRoute] string brandModelSlug,
        [FromRoute] string releaseYear,
        [FromRoute] string adSlug,
        [FromForm] AdDto formDto)
    {
        var ad = await _adService.GetAdBySlugAsync(adSlug);
        if (ad == null)
            return NotFound(new { error = "Ad not found" });

        var idProp = ad.GetType().GetProperty("Id");
        var id = idProp?.GetValue(ad)?.ToString();
        if (string.IsNullOrEmpty(id))
            return NotFound(new { error = "Ad ID not found" });

        return await UpdateAdInternal(lang, id, formDto);
    }

    // Delete ad by ID (short form)
    // DELETE {lang}/ads/{id}
    [HttpDelete("{lang}/ads/{id}")]
    public async Task<ActionResult> DeleteAdById(
        [FromRoute] string lang,
        [FromRoute] string id)
    {
        return await DeleteAdInternal(lang, id);
    }

    // Delete ad at category level
    // DELETE {lang}/categories/{categorySlug}/ads/{adSlug}
    [HttpDelete("{lang}/categories/{categorySlug}/ads/{adSlug}")]
    public async Task<ActionResult> DeleteAdByCategoryAndSlug(
        [FromRoute] string lang,
        [FromRoute] string categorySlug,
        [FromRoute] string adSlug)
    {
        var ad = await _adService.GetAdBySlugAsync(adSlug);
        if (ad == null)
            return NotFound(new { error = "Ad not found" });

        var idProp = ad.GetType().GetProperty("Id");
        var id = idProp?.GetValue(ad)?.ToString();
        if (string.IsNullOrEmpty(id))
            return NotFound(new { error = "Ad ID not found" });

        return await DeleteAdInternal(lang, id);
    }

    // Delete ad at brand/model level
    // DELETE {lang}/categories/{categorySlug}/models/{brandModelSlug}/ads/{adSlug}
    [HttpDelete("{lang}/categories/{categorySlug}/models/{brandModelSlug}/ads/{adSlug}")]
    public async Task<ActionResult> DeleteAdByBrandModelAndSlug(
        [FromRoute] string lang,
        [FromRoute] string categorySlug,
        [FromRoute] string brandModelSlug,
        [FromRoute] string adSlug)
    {
        var ad = await _adService.GetAdBySlugAsync(adSlug);
        if (ad == null)
            return NotFound(new { error = "Ad not found" });

        var idProp = ad.GetType().GetProperty("Id");
        var id = idProp?.GetValue(ad)?.ToString();
        if (string.IsNullOrEmpty(id))
            return NotFound(new { error = "Ad ID not found" });

        return await DeleteAdInternal(lang, id);
    }

    // Delete ad at release year level
    // DELETE {lang}/categories/{categorySlug}/models/{brandModelSlug}/releases/{releaseYear}/ads/{adSlug}
    [HttpDelete("{lang}/categories/{categorySlug}/models/{brandModelSlug}/releases/{releaseYear}/ads/{adSlug}")]
    public async Task<ActionResult> DeleteAdByReleaseYearAndSlug(
        [FromRoute] string lang,
        [FromRoute] string categorySlug,
        [FromRoute] string brandModelSlug,
        [FromRoute] string releaseYear,
        [FromRoute] string adSlug)
    {
        var ad = await _adService.GetAdBySlugAsync(adSlug);
        if (ad == null)
            return NotFound(new { error = "Ad not found" });

        var idProp = ad.GetType().GetProperty("Id");
        var id = idProp?.GetValue(ad)?.ToString();
        if (string.IsNullOrEmpty(id))
            return NotFound(new { error = "Ad ID not found" });

        return await DeleteAdInternal(lang, id);
    }

    #endregion

    #region Create Ad Endpoint

    // Create a new ad
    // POST {lang}/categories/{categorySlug}/ads
    [HttpPost("{lang}/categories/{**categorySlug}")]
    [Consumes("multipart/form-data")]
    [DisableRequestSizeLimit]
    [RequestFormLimits(MultipartBodyLengthLimit = 52428800)]
    public async Task<ActionResult<string>> CreateAd(
        [FromRoute] string lang,
        [FromRoute] string categorySlug,
        [FromForm] CreateAdDto formDto)
    {
        try
        {
            if (lang != "ar" && lang != "kr")
                return BadRequest(new { error = "Language must be 'ar' or 'kr'" });

            if (!categorySlug.EndsWith("/ads", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest(new
                {
                    error = "Invalid URL format",
                    message = "URL must end with /ads",
                    example = "ar/categories/مركبات-ونقل/سيارات/ads"
                });
            }

            categorySlug = categorySlug[..^4];

            var dto = CategoryDtoMapper.MapFormToDto(formDto, categorySlug, lang, Request.Form);

            // Validate the mapped DTO
            var validatorType = typeof(IValidator<>).MakeGenericType(dto.GetType());
            var validator = HttpContext.RequestServices.GetService(validatorType) as IValidator;
            if (validator != null)
            {
                var validationContext = new ValidationContext<object>(dto);
                var validationResult = await validator.ValidateAsync(validationContext);
                if (!validationResult.IsValid)
                {
                    return BadRequest(new
                    {
                        errors = validationResult.Errors.Select(e => new
                        {
                            field = e.PropertyName,
                            message = e.ErrorMessage
                        })
                    });
                }
            }

            _logger.LogInformation(
                "Creating ad for category: {CategorySlug}, language: {Language}, DTO Type: {DtoType}",
                categorySlug, lang, dto.GetType().Name);

            var imageUploads = formDto.ImageFiles?.Select(img => new ImageUpload
            {
                Stream = img.OpenReadStream(),
                FileName = img.FileName,
                Length = img.Length
            }).ToList() ?? new List<ImageUpload>();

            var adId = await _adService.CreateAdAsync(dto, categorySlug, imageUploads);

            // Get the created ad to return its slug for the canonical URL
            var createdAd = await _adService.GetAdByIdAsync(adId);
            var slugProp = createdAd?.GetType().GetProperty("Slug");
            var adSlug = slugProp?.GetValue(createdAd)?.ToString() ?? "";

            // URL-encode for the Location header (must be ASCII)
            var encodedCategorySlug = Uri.EscapeDataString(categorySlug);
            var encodedAdSlug = Uri.EscapeDataString(adSlug);
            
            return Created($"/api/{lang}/categories/{encodedCategorySlug}/ads/{encodedAdSlug}", new { id = adId, slug = adSlug });
        }
        catch (CategoryDtoMapper.CategoryNotSupportedException ex)
        {
            _logger.LogWarning(ex, "Category not supported: {CategorySlug}", ex.CategorySlug);
            return BadRequest(new
            {
                error = "Category not supported",
                categorySlug = ex.CategorySlug,
                language = ex.Language,
                message = ex.Message
            });
        }
        catch (FormatException ex)
        {
            _logger.LogError(ex, "Invalid format in form data");
            return BadRequest(new { error = "Invalid format in form data", details = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating ad");
            return BadRequest(new { error = ex.Message });
        }
    }

    #endregion

    #region Helper Methods

    private async Task<ActionResult> UpdateAdInternal(string lang, string id, AdDto formDto)
    {
        try
        {
            if (lang != "ar" && lang != "kr")
                return BadRequest(new { error = "Language must be 'ar' or 'kr'" });

            var existingAd = await _adService.GetAdByIdAsync(id);
            if (existingAd == null)
                return NotFound(new { error = "Ad not found" });

            var dtoType = CategoryDtoMapper.GetUpdateDtoTypeFromAdResponse(existingAd);
            if (dtoType != null && dtoType != typeof(AdDto))
            {
                var mappedDto = CategoryDtoMapper.MapFormToUpdateDto(formDto, dtoType, Request.Form);

                var validatorType = typeof(IValidator<>).MakeGenericType(dtoType);
                var validator = HttpContext.RequestServices.GetService(validatorType) as IValidator;
                if (validator != null)
                {
                    var validationContext = new ValidationContext<object>(mappedDto);
                    var validationResult = await validator.ValidateAsync(validationContext);
                    if (!validationResult.IsValid)
                    {
                        return BadRequest(new
                        {
                            errors = validationResult.Errors.Select(e => new
                            {
                                field = e.PropertyName,
                                message = e.ErrorMessage
                            })
                        });
                    }
                }
            }

            _logger.LogInformation("Updating ad: {AdId}, language: {Language}", id, lang);

            var result = await _adService.UpdateAdAsync(id, formDto, Request.Form);
            if (!result)
                return NotFound(new { error = "Ad not found" });

            return NoContent();
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid argument while updating ad: {Id}", id);
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating ad: {Id}", id);
            return BadRequest(new { error = ex.Message });
        }
    }

    private async Task<ActionResult> DeleteAdInternal(string lang, string id)
    {
        try
        {
            if (lang != "ar" && lang != "kr")
                return BadRequest(new { error = "Language must be 'ar' or 'kr'" });

            var result = await _adService.DeleteAdAsync(id);
            if (!result)
                return NotFound(new { error = "Ad not found" });

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting ad: {Id}", id);
            return BadRequest(new { error = ex.Message });
        }
    }

    private string BuildCanonicalUrl(string lang, CanonicalUrlInfo info)
    {
        // URL-encode each path segment separately (preserve / as path separator)
        var categorySlug = EncodePathSegments(info.CategorySlug);
        var adSlug = Uri.EscapeDataString(info.AdSlug);
        var brandModelSlug = !string.IsNullOrEmpty(info.BrandModelSlug) 
            ? EncodePathSegments(info.BrandModelSlug) 
            : null;
        
        var baseUrl = $"/api/{lang}/categories/{categorySlug}";

        return info.Level switch
        {
            CanonicalUrlLevel.ReleaseYear when !string.IsNullOrEmpty(brandModelSlug) && !string.IsNullOrEmpty(info.ReleaseYear)
                => $"{baseUrl}/models/{brandModelSlug}/releases/{info.ReleaseYear}/ads/{adSlug}",
            CanonicalUrlLevel.BrandModel when !string.IsNullOrEmpty(brandModelSlug)
                => $"{baseUrl}/models/{brandModelSlug}/ads/{adSlug}",
            _ => $"{baseUrl}/ads/{adSlug}"
        };
    }

    // Encode each path segment separately, preserving / as path separator
    private static string EncodePathSegments(string path)
    {
        if (string.IsNullOrEmpty(path))
            return path;
        
        var segments = path.Split('/');
        var encodedSegments = segments.Select(Uri.EscapeDataString);
        return string.Join("/", encodedSegments);
    }

    #endregion
}
