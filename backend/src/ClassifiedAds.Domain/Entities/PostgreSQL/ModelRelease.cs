namespace ClassifiedAds.Domain.Entities.PostgreSQL;

public class ModelRelease
{
    public ushort ModelReleaseID { get; set; }
    public ushort ReleaseYear { get; set; }
    public string UrlSlug { get; set; }
    public string ImageUrl { get; set; }
    public ushort ModelID { get; set; }

    public BrandModel Model { get; set; }
}
