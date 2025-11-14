using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.Interfaces;
using ClassifiedAds.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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

    /// <summary>
    /// Create an ad for any category
    /// </summary>
    /// <param name="lang">Language code (ar or kr)</param>
    /// <param name="categorySlug">Full category path slug</param>
    /// <param name="dto">Ad data as JSON - structure depends on category</param>
    /// <returns>Created ad ID</returns>
    /// <remarks>
    /// Example: POST /api/ar/categories/مركبات-ونقل/سيارات/ads
    /// </remarks>
    [HttpPost("{lang}/categories/{**categorySlug}")]
    public async Task<ActionResult<string>> CreateAd(
        [FromRoute] string lang,
        [FromRoute] string categorySlug,
        [FromBody] JsonElement dto)
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
                categorySlug = categorySlug.Substring(0, categorySlug.Length - 4);
            }

            // Get DTO type for category
            var dtoType = CategoryDtoMapper.GetDtoType(categorySlug, lang);
            if (dtoType == null)
            {
                return BadRequest(new 
                { 
                    error = "Category not supported",
                    categorySlug,
                    language = lang,
                    message = $"The category '{categorySlug}' is not supported for language '{lang}'"
                });
            }

            // Deserialize JSON to the appropriate DTO type
            var adDto = JsonSerializer.Deserialize(dto.GetRawText(), dtoType, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (adDto == null)
            {
                return BadRequest(new { error = "Failed to deserialize ad data" });
            }

            // Cast to CreateAdDto (all DTOs inherit from this)
            if (adDto is not CreateAdDto createAdDto)
            {
                return BadRequest(new { error = "Invalid DTO type" });
            }

            _logger.LogInformation(
                "Creating ad for category: {CategorySlug}, language: {Language}, DTO: {DtoType}",
                categorySlug, lang, dtoType.Name);

            // Create the ad
            var adId = await _adService.CreateAdAsync(createAdDto, categorySlug, string.Empty);
            
            return CreatedAtAction(nameof(GetAdById), new { id = adId, lang, locationSlug = "ads" }, new { id = adId });
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "JSON deserialization error");
            return BadRequest(new { error = "Invalid JSON format", details = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating ad");
            return BadRequest(new { error = ex.Message });
        }
    }

    /// <summary>
    /// Get ad by ID
    /// </summary>
    /// <remarks>
    /// Example: GET /api/ar/بغداد/ads/507f1f77bcf86cd799439011
    /// </remarks>
    [HttpGet("{lang}/{locationSlug}/ads/{id}")]
    public async Task<ActionResult<CreateAdDto>> GetAdById(
        [FromRoute] string lang,
        [FromRoute] string locationSlug,
        [FromRoute] string id)
    {
        try
        {
            var ad = await _adService.GetAdByIdAsync<CreateAdDto>(id);
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
    /// Update ad by ID
    /// </summary>
    /// <remarks>
    /// Example: PUT /api/ar/ads/507f1f77bcf86cd799439011
    /// </remarks>
    [HttpPut("{lang}/ads/{id}")]
    public async Task<ActionResult> UpdateAd(
        [FromRoute] string lang,
        [FromRoute] string id,
        [FromBody] JsonElement dto)
    {
        try
        {
            // TODO: Implement update logic
            return BadRequest(new { error = "Update not yet implemented" });
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
