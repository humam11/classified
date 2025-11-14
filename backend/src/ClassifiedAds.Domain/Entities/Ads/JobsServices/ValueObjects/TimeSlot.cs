using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.JobsServices.ValueObjects;

[BsonIgnoreExtraElements]
public class TimeSlot
{
    public string OpeningTime { get; set; }
    public string ClosingTime { get; set; }
}
