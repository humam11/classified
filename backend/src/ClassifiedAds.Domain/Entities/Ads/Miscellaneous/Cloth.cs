using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Miscellaneous;

[BsonDiscriminator("Cloth")]
public class Cloth : Ad
{
        public ClothCondition? ClothCondition { get; set; }
        public ClothingSize? ClothingSize { get; set; }
        public Season? Season { get; set; }
}
