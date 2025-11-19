using ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Electronics;

[BsonDiscriminator("VideoConsole")]
public class VideoConsole : Electronic
{
        public StorageCapacity? StorageCapacity { get; set; }
        public Region? ConsoleRegion { get; set; }
        public Guid? ModelId { get; set; }
}
