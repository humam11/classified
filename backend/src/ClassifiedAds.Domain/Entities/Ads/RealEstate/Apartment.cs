using ClassifiedAds.Domain.Common.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.RealEstate;

[BsonDiscriminator("Apartment")]
public class Apartment : RealEstate
{
        public byte? Bedrooms { get; set; }
        public byte? Bathrooms { get; set; }
        public YesNo? Elevator { get; set; }
        public YesNo? Furnished { get; set; }
        public byte? FloorNumber { get; set; }
}
