using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ClassifiedAds.Domain.Entities.Chat.ValueObjects;
using ClassifiedAds.Domain.Entities.Chat.Enums;

namespace ClassifiedAds.Domain.Entities.Chat;

public class Conversation
{
    [BsonId]
    public ObjectId _id { get; set; }
    public List<Guid> Participants { get; set; }
    public Dictionary<string, ParticipantInfo> ParticipantInfo { get; set; }
    public RelatedAd RelatedAd { get; set; }
    public LastMessage LastMessage { get; set; }
    public Dictionary<string, ushort> UnreadCounts { get; set; }
    public Dictionary<string, DateTime?> ReadCursors { get; set; }
    public ConversationStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
