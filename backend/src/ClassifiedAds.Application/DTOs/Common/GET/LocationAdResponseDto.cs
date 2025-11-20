namespace ClassifiedAds.Application.DTOs.Common;

/// <summary>
/// LocationAd DTO for GET responses (matches MongoDB structure)
/// </summary>
public class LocationAdResponseDto
{
    public List<ushort> LocationIds { get; set; }
    public string FullAddressArabic { get; set; }
    public string FullAddressKurdish { get; set; }
    public string? Street { get; set; }
}
