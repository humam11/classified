using ClassifiedAds.Domain.Entities.Ads.RealEstate.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.RealEstate;

[BsonDiscriminator("ConstructionProject")]
public class ConstructionProject : RealEstate
{
        public CompletionStatus CompletionStatus { get; set; }
}
