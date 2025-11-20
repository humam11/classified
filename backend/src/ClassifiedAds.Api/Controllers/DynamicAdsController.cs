using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.Interfaces;
using ClassifiedAds.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using FluentValidation;

namespace ClassifiedAds.Api.Controllers;

/// <summary>
/// Dynamic controller that handles all category slugs
/// </summary>
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


    [HttpPost("{lang}/categories/{**categorySlug}")]
    [Consumes("multipart/form-data")]
    [DisableRequestSizeLimit]
    [RequestFormLimits(MultipartBodyLengthLimit = 52428800)] // 50MB
    public async Task<ActionResult<string>> CreateAdMultipart(
        [FromRoute] string lang,
        [FromRoute] string categorySlug,
        [FromForm] CreateAdDto formDto)
    {
        try
        {
            // Validate language
            if (lang != "ar" && lang != "kr")
            {
                return BadRequest(new { error = "Language must be 'ar' or 'kr'" });
            }

            // Remove /ads suffix from categorySlug if present
            if (categorySlug.EndsWith("/ads", StringComparison.OrdinalIgnoreCase))
            {
                categorySlug = categorySlug[..^4]; // Remove last 4 characters ("/ads")
            }
            else
            {
                return BadRequest(new 
                { 
                    error = "Invalid URL format",
                    message = "URL must end with /ads",
                    example = "ar/categories/مركبات-ونقل/سيارات/ads"
                });
            }

            // Map form data to appropriate DTO type based on category
            var dto = CategoryDtoMapper.MapFormToDto(formDto, categorySlug, lang, Request.Form);

            // Manually validate the mapped DTO (since it might be a different type than formDto)
            var validatorType = typeof(FluentValidation.IValidator<>).MakeGenericType(dto.GetType());
            var validator = HttpContext.RequestServices.GetService(validatorType) as FluentValidation.IValidator;
            if (validator != null)
            {
                var validationContext = new FluentValidation.ValidationContext<object>(dto);
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
                "Creating ad (multipart) for category: {CategorySlug}, language: {Language}, DTO Type: {DtoType}, Images: {ImageCount}",
                categorySlug, lang, dto.GetType().Name, formDto.ImageFiles?.Count ?? 0);

            // Convert IFormFile to ImageUpload abstraction
            var imageUploads = formDto.ImageFiles.Select(img => new Application.Interfaces.ImageUpload
            {
                Stream = img.OpenReadStream(),
                FileName = img.FileName,
                Length = img.Length
            }).ToList();

            // Create the ad with images
            var adId = await _adService.CreateAdAsync(dto, categorySlug, imageUploads);
            
            return CreatedAtAction(nameof(GetAdById), new { id = adId, lang, locationSlug = "ads" }, new { id = adId });
        }
        catch (CategoryDtoMapper.CategoryNotSupportedException ex)
        {
            _logger.LogWarning(ex, "Category not supported: {CategorySlug}, Language: {Language}", ex.CategorySlug, ex.Language);
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
    

    [HttpGet("{lang}/{locationSlug}/ads/{id}")]
    public async Task<ActionResult<object>> GetAdById(
        [FromRoute] string lang,
        [FromRoute] string locationSlug,
        [FromRoute] string id)
    {
        try
        {
            var ad = await _adService.GetAdByIdAsync(id);
            if (ad == null)
            {
                return NotFound(new { error = "Ad not found" });
            }
            return Ok(ad);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting ad by id: {Id}", id);
            return BadRequest(new { error = ex.Message });
        }
    }


    /// <summary>
    /// Update an ad by ID (PATCH - partial update)
    /// </summary>
    /// <param name="lang">Language code (ar or kr)</param>
    /// <param name="id">Ad ID</param>
    /// <param name="formDto">Ad data to update (all fields optional)</param>
    /// <returns>No content on success</returns>
    /// <remarks>
    /// Example: PATCH /api/ar/ads/507f1f77bcf86cd799439011
    /// Content-Type: multipart/form-data
    /// 
    /// All fields are optional. Only provided fields will be updated.
    /// 
    /// Special rules:
    /// - If City is updated, Region and Neighborhood must be re-specified or will be cleared
    /// - If PriceIsDollar is updated, PriceValue must also be provided
    /// - If ImageFiles are provided, all old images will be replaced
    /// </remarks>
    [HttpPatch("{lang}/ads/{id}")]
    [Consumes("multipart/form-data")]
    [DisableRequestSizeLimit]
    [RequestFormLimits(MultipartBodyLengthLimit = 52428800)] // 50MB
    public async Task<ActionResult> UpdateAd(
        [FromRoute] string lang,
        [FromRoute] string id,
        [FromForm] AdDto formDto)
    {
        try
        {
            // Validate language
            if (lang != "ar" && lang != "kr")
            {
                return BadRequest(new { error = "Language must be 'ar' or 'kr'" });
            }

            _logger.LogInformation(
                "Updating ad: {AdId}, language: {Language}",
                id, lang);

            var result = await _adService.UpdateAdAsync(id, formDto, Request.Form);
            
            if (!result)
            {
                return NotFound(new { error = "Ad not found" });
            }

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

    /// <summary>
    /// Delete ad by ID
    /// </summary>
    /// <remarks>
    /// Example: DELETE /api/ar/ads/507f1f77bcf86cd799439011
    /// </remarks>
    [HttpDelete("{lang}/ads/{id}")]
    public async Task<ActionResult> DeleteAd(
        [FromRoute] string lang,
        [FromRoute] string id)
    {
        try
        {
            var result = await _adService.DeleteAdAsync(id);
            if (!result)
            {
                return NotFound(new { error = "Ad not found" });
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting ad: {Id}", id);
            return BadRequest(new { error = ex.Message });
        }
    }
}
