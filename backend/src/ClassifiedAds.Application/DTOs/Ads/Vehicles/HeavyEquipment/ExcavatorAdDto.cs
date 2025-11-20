using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;

public class ExcavatorAdDto : HeavyEquipmentAdDto
{
    public float? BucketCapacity { get; set; }
    public float? DiggingDepth { get; set; }
}

public class CreateExcavatorAdDto : ExcavatorAdDto
{
    // EMPTY — inherits everything
}

public class ExcavatorSpecsDto : HeavyEquipmentSpecsDto
{
    public float? BucketCapacity { get; set; }
    public float? DiggingDepth { get; set; }
}

public class GetExcavatorAdDto : GetHeavyEquipmentAdDto
{
    [JsonPropertyOrder(300)]
    public new ExcavatorSpecsDto? Specs { get; set; }
}
