using ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Electronics;

[BsonDiscriminator("Console")]
public class Console : Electronic
{
    public StorageCapacity? StorageCapacity { get; set; }
    public Region? ConsoleRegion { get; set; }
    // Resolved brand/model slugs from PostgreSQL (brand + model)
    public List<string>? ModelsSlugs { get; set; }
}
