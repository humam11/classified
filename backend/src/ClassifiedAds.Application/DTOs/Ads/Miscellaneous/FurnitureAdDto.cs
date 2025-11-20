using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Miscellaneous;

public class FurnitureAdDto : AdDto
{
    public FurnitureMaterial? FurnitureMaterial { get; set; }
    public ushort? Length { get; set; }
    public ushort? Width { get; set; }
    public ushort? Height { get; set; }
}

public class CreateFurnitureAdDto : FurnitureAdDto
{
    // EMPTY — inherits everything
}

public class FurnitureSpecsDto
{
    public FurnitureMaterial? FurnitureMaterial { get; set; }
    public ushort? Length { get; set; }
    public ushort? Width { get; set; }
    public ushort? Height { get; set; }
}

public class GetFurnitureAdDto : GetAdDto
{
    [JsonPropertyOrder(100)]
    public FurnitureSpecsDto? Specs { get; set; }
}
