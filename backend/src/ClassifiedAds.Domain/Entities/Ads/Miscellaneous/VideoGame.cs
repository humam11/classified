using ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Miscellaneous;

[BsonDiscriminator("VideoGame")]
public class VideoGame : Ad
{
        public Region? VideoGameRegion { get; set; }
        // Resolved brand/model slugs from PostgreSQL (brand + model)
        public List<string>? ModelsSlugs { get; set; }
}
