using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Miscellaneous;

[BsonDiscriminator("TireWheel")]
public class TireWheel : Ad
{
        public ushort? Width { get; set; }
        public byte? AspectRatio { get; set; }
        public byte? RimDiameter { get; set; }
}
