using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Vehicles.Enums;

[QueryKey(ar = "نوع-الوقود", kr = "جۆری-سووتەمەنی")]
public enum FuelType : byte
{
    [QueryValue(ar = "بنزين", kr = "بەنزین")]
    Gasoline,

    [QueryValue(ar = "ديزل", kr = "دیزڵ")]
    Diesel,

    [QueryValue(ar = "كهرباء", kr = "کارەبا")]
    Electric,

    [QueryValue(ar = "هجين", kr = "هایبرید")]
    Hybrid,

    [QueryValue(ar = "غاز", kr = "گاز")]
    Gas,

    [QueryValue(ar = "أخرى", kr = "ئەویتر")]
    Other
}
