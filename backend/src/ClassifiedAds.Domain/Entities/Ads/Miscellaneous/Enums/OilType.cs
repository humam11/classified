using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;

[QueryKey(ar = "نوع-الزيت", kr = "جۆری-ڕۆن")]
public enum OilType : byte
{
    [QueryValue(ar = "زيت محرك", kr = "ڕۆنی بزوێنەر")]
    EngineOil,

    [QueryValue(ar = "زيت ناقل الحركة", kr = "ڕۆنی گێربۆکس")]
    TransmissionOil,

    [QueryValue(ar = "زيت هيدروليكي", kr = "ڕۆنی هایدرۆلیک")]
    HydraulicOil,

    [QueryValue(ar = "زيت التروس", kr = "ڕۆنی گیر")]
    GearOil,

    [QueryValue(ar = "زيت الفرق", kr = "ڕۆنی دیفرانسیەل")]
    DifferentialOil,

    [QueryValue(ar = "شحم", kr = "چەورییە")]
    Grease,

    [QueryValue(ar = "زيت توجيه القوة", kr = "ڕۆنی پاوەر")]
    PowerSteeringOil,

    [QueryValue(ar = "زيت الفرامل", kr = "ڕۆنی فرێن")]
    BrakeOil,

    [QueryValue(ar = "زيت التبريد", kr = "ڕۆنی سارکەرەوە")]
    CoolantOil,

    [QueryValue(ar = "اخرى", kr = "ئەویتر")]
    Other
}
