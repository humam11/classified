using ClassifiedAds.Application.DTOs.Common;
using ClassifiedAds.Application.Interfaces;
using ClassifiedAds.Infrastructure.Data.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace ClassifiedAds.Infrastructure.Services;

/// <summary>
/// Service for resolving location names to IDs using PostgreSQL locations table
/// </summary>
public class LocationService : ILocationService
{
    private readonly PostgresDbContext _context;

    public LocationService(PostgresDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Resolves location names (City/Region/Neighborhood) to location IDs from PostgreSQL
    /// Uses hierarchical self-join to find locations in the hierarchy
    /// </summary>
    public async Task<(List<ushort> LocationIds, string FullAddressArabic, string FullAddressKurdish)> ResolveLocationAsync(
        LocationAdDto locationDto,
        string language)
    {
        var locationIds = new List<ushort>();
        var addressPartsArabic = new List<string>();
        var addressPartsKurdish = new List<string>();

        // Determine which name column to use based on language
        var nameColumn = language == "ar" ? "name_arabic" : "name_kurdish";

        // Step 1: Find City (level 1 in your hierarchy - Baghdad, Erbil, etc.)
        var cityQuery = language == "ar"
            ? _context.Locations.Where(l => l.NameArabic == locationDto.City && l.Level == 1)
            : _context.Locations.Where(l => l.NameKurdish == locationDto.City && l.Level == 1);

        var city = await cityQuery.FirstOrDefaultAsync();

        if (city == null)
        {
            throw new ArgumentException($"City '{locationDto.City}' not found in database");
        }

        // Add city to IDs (no country level in your data)
        locationIds.Add(city.LocationID);
        addressPartsArabic.Add(city.NameArabic);
        addressPartsKurdish.Add(city.NameKurdish);

        // Step 2: Find Region (if provided) - level 2, child of city
        if (!string.IsNullOrEmpty(locationDto.Region))
        {
            var regionQuery = language == "ar"
                ? _context.Locations.Where(l => l.NameArabic == locationDto.Region && l.ParentID == city.LocationID && l.Level == 2)
                : _context.Locations.Where(l => l.NameKurdish == locationDto.Region && l.ParentID == city.LocationID && l.Level == 2);

            var region = await regionQuery.FirstOrDefaultAsync();

            if (region == null)
            {
                throw new ArgumentException($"Region '{locationDto.Region}' not found under city '{locationDto.City}'");
            }

            locationIds.Add(region.LocationID);
            addressPartsArabic.Add(region.NameArabic);
            addressPartsKurdish.Add(region.NameKurdish);

            // Step 3: Find Neighborhood (if provided) - level 3, child of region
            if (!string.IsNullOrEmpty(locationDto.Neighborhood))
            {
                var neighborhoodQuery = language == "ar"
                    ? _context.Locations.Where(l => l.NameArabic == locationDto.Neighborhood && l.ParentID == region.LocationID && l.Level == 3)
                    : _context.Locations.Where(l => l.NameKurdish == locationDto.Neighborhood && l.ParentID == region.LocationID && l.Level == 3);

                var neighborhood = await neighborhoodQuery.FirstOrDefaultAsync();

                if (neighborhood == null)
                {
                    throw new ArgumentException($"Neighborhood '{locationDto.Neighborhood}' not found under region '{locationDto.Region}'");
                }

                locationIds.Add(neighborhood.LocationID);
                addressPartsArabic.Add(neighborhood.NameArabic);
                addressPartsKurdish.Add(neighborhood.NameKurdish);
            }
        }

        // Build full addresses
        var fullAddressArabic = string.Join("، ", addressPartsArabic);
        var fullAddressKurdish = string.Join("، ", addressPartsKurdish);

        return (locationIds, fullAddressArabic, fullAddressKurdish);
    }
}
