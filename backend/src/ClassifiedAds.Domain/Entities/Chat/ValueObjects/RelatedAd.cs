using MongoDB.Bson;

namespace ClassifiedAds.Domain.Entities.Chat.ValueObjects;

public class RelatedAd
{
    public ObjectId Id { get; set; }
    public string Title { get; set; }
    public string Price { get; set; }
    public string MainImage { get; set; }
}
