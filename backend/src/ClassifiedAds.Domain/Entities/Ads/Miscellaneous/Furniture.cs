using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Miscellaneous;

[BsonDiscriminator("Furniture")]
public class Furniture : Ad
{
        public FurnitureMaterial FurnitureMaterial { get; set; }
        public ushort Length { get; set; }
        public ushort Width { get; set; }
        public ushort Height { get; set; }
}
