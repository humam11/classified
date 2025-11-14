using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Common.ValueObjects;

public class AdImage
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ImageId { get; set; }
    public string ImageUrl { get; set; }
    public byte Order { get; set; } // 1-5
}
