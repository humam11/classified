namespace ClassifiedAds.Domain.Common.ValueObjects;

/// <summary>
/// Location value object stored in MongoDB.
/// Contains both user-provided data and server-resolved location IDs from PostgreSQL.
/// </summary>
public class LocationAd
{
    /// <summary>
    /// Hierarchical location IDs resolved from PostgreSQL locations table.
    /// Order: [Country, City, Region, Neighborhood]
    /// </summary>
    public List<ushort> LocationIds { get; set; }

    /// <summary>
    /// Full address in Arabic (auto-generated from location hierarchy)
    /// Example: "العراق، بغداد، الكرادة، الكرادة الشرقية"
    /// </summary>
    public string FullAddressArabic { get; set; }

    /// <summary>
    /// Full address in Kurdish (auto-generated from location hierarchy)
    /// Example: "عێراق، بەغدا، کەرادە، کەرادەی ڕۆژهەڵات"
    /// </summary>
    public string FullAddressKurdish { get; set; }

    /// <summary>
    /// Optional street address provided by user
    /// Example: "شارع الكرادة، بناية 15"
    /// </summary>
    public string? Street { get; set; }
}
