namespace ClassifiedAds.Domain.Entities.PostgreSQL;

public class BrandModel
{
    public ushort BrandModelID { get; set; }
    public string NameEnglish { get; set; }
    public string? NameArabic { get; set; }
    public string? NameKurdish { get; set; }
    public bool IsBrand { get; set; }
    public string UrlSlug { get; set; }
    public string ImageUrl { get; set; }
    public string? AutomationKeyword { get; set; }
    public string? HierarchyPath { get; set; }
    public byte Level { get; set; }
    public ushort? ParentID { get; set; }
    public ushort CategoryID { get; set; }

    public BrandModel? Parent { get; set; }
    public ICollection<BrandModel>? Models { get; set; }
    public Category? Category { get; set; }
    public ICollection<Release>? Releases { get; set; }
}
