using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Miscellaneous;

[BsonDiscriminator("Plant")]
public class Plant : Ad
{
        public ushort? Height { get; set; }
        public PlantType? PlantType { get; set; }
}
