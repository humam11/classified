using ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.JobsServices;

[BsonDiscriminator("Vacancy")]
public class Vacancy : Ad
{
        public JobType? JobType { get; set; }
        public byte? ExperienceYears { get; set; }
        public EducationLevel? EducationLevel { get; set; }
        public WorkingHours? WorkingHours { get; set; }
        public decimal? Max { get; set; }
        public PaymentPeriod? PaymentPeriod { get; set; }
}
