namespace ClassifiedAds.Application.DTOs.Common;

/// <summary>
/// Image information for an ad (used for response/display only).
/// Images are uploaded via multipart/form-data separately.
/// </summary>
public class AdImageDto
{
    public string? ImageId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public byte Order { get; set; }
}
