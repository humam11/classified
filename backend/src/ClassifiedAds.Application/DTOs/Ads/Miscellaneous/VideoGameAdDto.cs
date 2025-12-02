using ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Miscellaneous;

public class VideoGameAdDto : AdDto
{
    public Region? VideoGameRegion { get; set; }
    // Brand/Model resolution inputs (brand + model for video games)
    public string? BrandName { get; set; }
    public string? ModelName { get; set; }
}

public class CreateVideoGameAdDto : VideoGameAdDto
{
    // EMPTY — inherits everything
}

public class VideoGameSpecsDto
{
    public Region? VideoGameRegion { get; set; }
    // Resolved brand/model slugs stored in MongoDB
    public List<string>? ModelsSlugs { get; set; }
}

public class GetVideoGameAdDto : GetAdDto
{
    [JsonPropertyOrder(100)]
    public VideoGameSpecsDto? Specs { get; set; }
}
