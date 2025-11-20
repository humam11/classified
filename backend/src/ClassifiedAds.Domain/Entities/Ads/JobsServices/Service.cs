using ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;
using ClassifiedAds.Domain.Entities.Ads.JobsServices.ValueObjects;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.JobsServices;

[BsonDiscriminator("Service")]
public class Service : Ad
{
    
        public PaymentPeriod? PaymentPeriod { get; set; }
        public List<DailyAvailability>? DailyAvailability { get; set; }
}
