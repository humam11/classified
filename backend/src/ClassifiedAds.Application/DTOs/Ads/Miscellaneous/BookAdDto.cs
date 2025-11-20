using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Miscellaneous;

public class BookAdDto : AdDto
{
    public BookLanguage? BookLanguage { get; set; }
    public ushort? Pages { get; set; }
}

public class CreateBookAdDto : BookAdDto
{
    // EMPTY — inherits everything
}

public class BookSpecsDto
{
    public BookLanguage? BookLanguage { get; set; }
    public ushort? Pages { get; set; }
}

public class GetBookAdDto : GetAdDto
{
    [JsonPropertyOrder(100)]
    public BookSpecsDto? Specs { get; set; }
}