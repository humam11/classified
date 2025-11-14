using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;

[QueryKey(ar = "نوع-النبات", kr = "جۆری-ڕووەک")]
public enum PlantType : byte
{
    [QueryValue(ar = "شمسي", kr = "دەرەوە")]
    Sunny,

    [QueryValue(ar = "ظل", kr = "ناوەوە")]
    Shade
}
