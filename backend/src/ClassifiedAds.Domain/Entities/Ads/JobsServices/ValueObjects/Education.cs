using ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.JobsServices.ValueObjects;

[BsonIgnoreExtraElements]
public class Education
{
    public string InstitutionName { get; set; }
    public EducationDegree EducationDegree { get; set; }
    public string Specialization { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
