using ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Electronics;

public class ConsoleAdDto : ElectronicAdDto
{
    public StorageCapacity? StorageCapacity { get; set; }
    public Region? ConsoleRegion { get; set; }
    // Brand/Model resolution inputs (brand + model for consoles)
    public string? BrandName { get; set; }
    public string? ModelName { get; set; }
}

public class CreateConsoleAdDto : ConsoleAdDto
{
    // EMPTY — inherits everything
}

public class ConsoleSpecsDto : ElectronicSpecsDto
{
    public StorageCapacity? StorageCapacity { get; set; }
    public Region? ConsoleRegion { get; set; }
    // Resolved brand/model slugs stored in MongoDB
    public List<string>? ModelsSlugs { get; set; }
}

public class GetConsoleAdDto : GetElectronicAdDto
{
    [JsonPropertyOrder(200)]
    public new ConsoleSpecsDto? Specs { get; set; }
}
