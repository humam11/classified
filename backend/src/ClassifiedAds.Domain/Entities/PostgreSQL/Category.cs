namespace ClassifiedAds.Domain.Entities.PostgreSQL;

public class Category
{
    public ushort CategoryID { get; set; }
    public string NameArabic { get; set; }
    public string NameKurdish { get; set; }
    public string UrlSlugArabic { get; set; }
    public string UrlSlugKurdish { get; set; }
    public string? ImageUrl { get; set; }
    public string? HierarchyPath { get; set; }
    public byte Level { get; set; }
    public bool IsLeaf { get; set; }
    public ushort? ParentID { get; set; }

    public Category? Parent { get; set; }
    public ICollection<Category>? Children { get; set; }
    public ICollection<BrandModel>? BrandModels { get; set; }
}
