using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.JobsServices.ValueObjects;

[BsonIgnoreExtraElements]
public class DailyAvailability
{
    public DayWeek DayWeek { get; set; }
    public YesNo IsAvailable { get; set; }
    public YesNo Is24Hours { get; set; }
    public List<TimeSlot> TimeSlots { get; set; }
}
