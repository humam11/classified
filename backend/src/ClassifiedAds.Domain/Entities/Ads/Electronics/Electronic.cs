using ClassifiedAds.Domain.Common.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Electronics;

[BsonDiscriminator("Electronic")]
public class Electronic : Ad
{
        public YesNo IsNew { get; set; }
        public byte WarrantyMonths { get; set; }
}
