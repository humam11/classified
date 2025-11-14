namespace ClassifiedAds.Domain.Entities.PostgreSQL;

public class Location
{
    public ushort LocationID { get; set; }
    public string NameEnglish { get; set; }
    public string NameArabic { get; set; }
    public string NameKurdish { get; set; }
    public string HierarchyPath { get; set; }
    public int Level { get; set; }
    public ushort? ParentID { get; set; }

    public Location Parent { get; set; }
    public ICollection<Location> Children { get; set; }
}
