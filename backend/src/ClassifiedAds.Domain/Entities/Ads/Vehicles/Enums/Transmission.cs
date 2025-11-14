using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Vehicles.Enums;

[QueryKey(ar = "ناقل-الحركة", kr = "گێربۆکس")]
public enum Transmission : byte
{
    [QueryValue(ar = "يدوي", kr = "دەستی")]
    Manual,

    [QueryValue(ar = "أوتوماتيك", kr = "ئۆتۆماتیک")]
    Automatic,

    [QueryValue(ar = "مزدوج", kr = "دووانە")]
    Dual
}
