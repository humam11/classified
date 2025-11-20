using ClassifiedAds.Domain.Common.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Electronics;

public class ElectronicAdDto : AdDto
{
    public YesNo? IsNew { get; set; }
    public byte? WarrantyMonths { get; set; }
}

public class CreateElectronicAdDto : ElectronicAdDto
{
    // EMPTY — inherits everything
}

public class ElectronicSpecsDto
{
    public YesNo? IsNew { get; set; }
    public byte? WarrantyMonths { get; set; }
}

public class GetElectronicAdDto : GetAdDto
{
    [JsonPropertyOrder(100)]
    public ElectronicSpecsDto? Specs { get; set; }
}
