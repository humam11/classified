namespace ClassifiedAds.Application.DTOs.Common;

/// <summary>
/// Category DTO for GET responses (matches MongoDB structure)
/// </summary>
public class CategoryResponseDto
{
    public byte CategoryJoins { get; set; }
    public List<ushort> CategoryIds { get; set; }
}
