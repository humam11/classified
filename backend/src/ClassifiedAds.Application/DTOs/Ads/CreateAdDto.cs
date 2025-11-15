using Microsoft.AspNetCore.Http;

namespace ClassifiedAds.Application.DTOs.Ads;

/// <summary>
/// Base DTO for creating any type of classified ad.
/// Uses flat fields for multipart/form-data compatibility.
/// </summary>
public class CreateAdDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    // Flat price fields
    public decimal PriceValue { get; set; }
    public bool PriceIsDollar { get; set; }
    
    // Flat location fields
    public string City { get; set; } = string.Empty;
    public string? Region { get; set; }
    public string? Neighborhood { get; set; }
    public string? Street { get; set; }
    
    // File uploads (for multipart/form-data)
    public List<IFormFile>? ImageFiles { get; set; }
}
