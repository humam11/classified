using ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;
using ClassifiedAds.Domain.Entities.Ads.JobsServices.ValueObjects;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.JobsServices;

[BsonDiscriminator("Cv")]
public class Cv : Ad
{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public JobSearchStatus JobSearchStatus { get; set; }
        public List<Education> Education { get; set; }
        public List<Experience> Experience { get; set; }
        public List<Language> Languages { get; set; }
}
