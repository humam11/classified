using ClassifiedAds.Domain.Common.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Miscellaneous;

[BsonDiscriminator("Shoe")]
public class Shoe : Ad
{
        public YesNo? IsNew { get; set; }
        public byte? Size { get; set; }
}
