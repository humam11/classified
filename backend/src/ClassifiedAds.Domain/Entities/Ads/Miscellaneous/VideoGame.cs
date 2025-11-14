using ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Miscellaneous;

[BsonDiscriminator("VideoGame")]
public class VideoGame : Ad
{
        public Region VideoGameRegion { get; set; }
        public Guid ModelId { get; set; }
}
