using ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Jobs;

public class ServiceAdDto : AdDto
{
    public PaymentPeriod PaymentPeriod { get; set; }
    public List<DailyAvailabilityDto> DailyAvailability { get; set; }
}
