namespace ClassifiedAds.Domain.Entities.Chat.ValueObjects;

public class LastMessage
{
    public string Content { get; set; }
    public Guid SenderId { get; set; }
    public DateTime Timestamp { get; set; }
}
