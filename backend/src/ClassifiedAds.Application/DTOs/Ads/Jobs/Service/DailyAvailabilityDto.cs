using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;

namespace ClassifiedAds.Application.DTOs.Ads.Jobs;

public class DailyAvailabilityDto
{
    public DayWeek DayWeek { get; set; }
    public YesNo IsAvailable { get; set; }
    public YesNo Is24Hours { get; set; }
    public List<TimeSlotDto> TimeSlots { get; set; }
}
