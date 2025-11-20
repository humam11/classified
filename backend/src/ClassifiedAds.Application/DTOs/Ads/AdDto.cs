using ClassifiedAds.Application.DTOs.Common;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads;

// Base DTO for ad input operations (Create and Update)
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

// DTO for creating ads - all required fields must be provided
public class CreateAdDto : AdDto
{
    // Inherits all properties from AdDto
    // Validation will enforce required fields
}

// Base DTO for ad GET responses - includes full MongoDB structure
public class GetAdDto
{
    // Full response fields (populated when retrieving from MongoDB)
    // Order: Base ad fields first, then category-specific fields
    [JsonPropertyOrder(1)]
    public string? Id { get; set; }
    
    [JsonPropertyOrder(2)]
    public string? Title { get; set; }
    
    [JsonPropertyOrder(3)]
    public string? Description { get; set; }
    
    [JsonPropertyOrder(4)]
    public PriceResponseDto? Price { get; set; }
    
    [JsonPropertyOrder(5)]
    public LocationAdResponseDto? LocationAd { get; set; }
    
    [JsonPropertyOrder(6)]
    public List<AdImageDto>? Images { get; set; }
    
    [JsonPropertyOrder(7)]
    public int? Status { get; set; }
    
    [JsonPropertyOrder(8)]
    public DateTime? CreatedAt { get; set; }
    
    [JsonPropertyOrder(9)]
    public DateTime? UpdatedAt { get; set; }
    
    [JsonPropertyOrder(10)]
    public byte? ImageCount { get; set; }
    
    [JsonPropertyOrder(11)]
    public int? ViewsCount { get; set; }
    
    [JsonPropertyOrder(12)]
    public byte? Priority { get; set; }
    
    [JsonPropertyOrder(13)]
    public string? Slug { get; set; }
    
    [JsonPropertyOrder(14)]
    public CategoryResponseDto? Category { get; set; }
}
