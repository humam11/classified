using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;

[QueryKey(ar = "ريجن", kr = "ڕێجین")]
public enum Region : byte
{
    [QueryValue(ar = "امريكي", kr = "ئەمریکی")]
    American,

    [QueryValue(ar = "اوربي", kr = "ئەورووپی")]
    European,

    [QueryValue(ar = "ياباني", kr = "ژاپۆنی")]
    Japanese,

    [QueryValue(ar = "شامل", kr = "گشتی")]
    RegionFree,

    [QueryValue(ar = "اخرى", kr = "ئەویتر")]
    Other
}
