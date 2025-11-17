using System.ComponentModel.DataAnnotations;

namespace ClassifiedAds.Application.DTOs.Common;

/// <summary>
/// Location information for an ad.
/// User provides location names, server resolves them to IDs using the locations table.
/// </summary>
public class LocationAdDto
{

    public string City { get; set; }


    public string? Region { get; set; }


    public string? Neighborhood { get; set; }


    public string? Street { get; set; }
}