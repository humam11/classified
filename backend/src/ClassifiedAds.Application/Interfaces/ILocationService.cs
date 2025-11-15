using ClassifiedAds.Application.DTOs.Common;

namespace ClassifiedAds.Application.Interfaces;

/// <summary>
/// Service for resolving location names to IDs and building full addresses
/// </summary>
public interface ILocationService
{
    /// <summary>
    /// Resolves location names (City/Region/Neighborhood) to location IDs from PostgreSQL
    /// </summary>
    /// <param name="locationDto">Location DTO with City, Region, Neighborhood</param>
    /// <param name="language">Language code (ar or kr)</param>
    /// <returns>Tuple of (LocationIds, FullAddressArabic, FullAddressKurdish)</returns>
    Task<(List<ushort> LocationIds, string FullAddressArabic, string FullAddressKurdish)> ResolveLocationAsync(
        LocationAdDto locationDto, 
        string language);
}
