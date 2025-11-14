using ClassifiedAds.Domain.Common.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.RealEstate;

[BsonDiscriminator("House")]
public class House : RealEstate
{
        public byte Floors { get; set; }
        public byte Bedrooms { get; set; }
        public byte Bathrooms { get; set; }
        public YesNo Garage { get; set; }
        public YesNo Garden { get; set; }
}
