using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Miscellaneous;

[BsonDiscriminator("EngineOil")]
public class EngineOil : Ad
{
        public ushort Volume { get; set; }
        public OilType OilType { get; set; }
        public Viscosity Viscosity { get; set; }
}
