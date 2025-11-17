using Microsoft.AspNetCore.Http;

namespace ClassifiedAds.Application.DTOs.Ads;

/// <summary>
/// Base DTO for ad operations (Create and Update)
/// </summary>
public class AdDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    
    // Flat price fields (currency type comes before value)
    public bool? IsDollar { get; set; }
    public decimal? PriceValue { get; set; }
    
    // Flat location fields
    public string? City { get; set; }
    public string? Region { get; set; }
    public string? Neighborhood { get; set; }
    public string? Street { get; set; }
    
    // File uploads (for multipart/form-data)
    public List<IFormFile>? ImageFiles { get; set; }
}

/// <summary>
/// DTO for creating ads - all required fields must be provided
/// </summary>
public class CreateAdDto : AdDto
{
    // Inherits all properties from AdDto
    // Validation will enforce required fields
}
