namespace ClassifiedAds.Application.DTOs.Common;

/// <summary>
/// AdImage DTO for GET responses (matches MongoDB structure)
/// </summary>
public class AdImageDto
{
    public string? ImageId { get; set; }
    public string ImageUrl { get; set; }
    public byte Order { get; set; }
}
