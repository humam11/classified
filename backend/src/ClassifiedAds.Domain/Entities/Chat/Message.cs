using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ClassifiedAds.Domain.Entities.Chat.Enums;

namespace ClassifiedAds.Domain.Entities.Chat;

public class Message
{
    [BsonId]
    public ObjectId _id { get; set; }
    public ObjectId ConversationId { get; set; }
    public Guid SenderId { get; set; }
    public ContentType ContentType { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
}
