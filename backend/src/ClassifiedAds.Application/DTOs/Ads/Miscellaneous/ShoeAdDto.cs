using ClassifiedAds.Domain.Common.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Miscellaneous;

public class ShoeAdDto : AdDto
{
    public YesNo? IsNew { get; set; }
    public byte? Size { get; set; }
}

public class CreateShoeAdDto : ShoeAdDto
{
    // EMPTY — inherits everything
}

public class ShoeSpecsDto
{
    public YesNo? IsNew { get; set; }
    public byte? Size { get; set; }
}

public class GetShoeAdDto : GetAdDto
{
    [JsonPropertyOrder(100)]
    public ShoeSpecsDto? Specs { get; set; }
}
