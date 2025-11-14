using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;

[QueryKey(ar = "معدل-التحديث", kr = "ڕێژەی-نوێکردنەوە")]
[GetUnits("Hertz")]
public enum RefreshRate : byte
{
    Hz_30 = 30,

    Hz_50 = 50,

    Hz_60 = 60,

    Hz_75 = 75,

    Hz_90 = 90,

    Hz_100 = 100,

    Hz_120 = 120,

    Hz_144 = 144,

    Hz_165 = 165,

    Hz_200 = 200,

    Hz_240 = 240,

    [QueryValue(ar = "أخرى", kr = "ئەویتر")]
    Other
}
