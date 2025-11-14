using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Vehicles.Enums;

[QueryKey(ar = "نوع-الدفع", kr = "جۆری-هاندان")]
public enum CarDriveType : byte
{
    [QueryValue(ar = "أمامي", kr = "پێشەوە")]
    Front,

    [QueryValue(ar = "خلفي", kr = "دواوە")]
    Rear,

    [QueryValue(ar = "رباعي", kr = "چوار چەرخ")]
    FourWheel
}
