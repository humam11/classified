namespace ClassifiedAds.Domain.Entities.PostgreSQL;

public class Release
{
    public ushort ReleaseId { get; set; }
    public string ReleaseYear { get; set; }
    public string ImageUrl { get; set; }
    public ushort ModelId { get; set; }

    public BrandModel Model { get; set; }
}
