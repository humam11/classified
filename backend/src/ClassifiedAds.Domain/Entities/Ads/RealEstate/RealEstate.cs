using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.RealEstate;

[BsonDiscriminator("RealEstate")]
public class RealEstate : Ad
{
        public float Area { get; set; }

}
