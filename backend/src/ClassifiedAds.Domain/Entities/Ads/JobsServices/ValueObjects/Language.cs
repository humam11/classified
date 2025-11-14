using ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.JobsServices.ValueObjects;

[BsonIgnoreExtraElements]
public class Language
{
    public string Name { get; set; }
    public LanguageProficiency LanguageProficiency { get; set; }
}
