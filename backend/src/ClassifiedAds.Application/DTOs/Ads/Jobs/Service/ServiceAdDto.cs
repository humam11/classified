using ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;
using System.Text.Json.Serialization;

namespace ClassifiedAds.Application.DTOs.Ads.Jobs;

// Service Ad DTO for input operations (POST/PATCH)
public class ServiceAdDto : AdDto
{
    public PaymentPeriod? PaymentPeriod { get; set; }
    public List<DailyAvailabilityDto>? DailyAvailability { get; set; }
}

// Service Ad DTO for creating (POST)
public class CreateServiceAdDto : ServiceAdDto
{
    // EMPTY — inherits everything
}

// Service specifications DTO - groups all Service-specific fields
public class ServiceSpecsDto
{
    public PaymentPeriod? PaymentPeriod { get; set; }
    public List<DailyAvailabilityDto>? DailyAvailability { get; set; }
}

// Service Ad DTO for GET responses - includes full MongoDB structure
public class GetServiceAdDto : GetAdDto
{
    [JsonPropertyOrder(100)]
    public ServiceSpecsDto? Specs { get; set; }
}
