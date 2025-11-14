using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;

[QueryKey(ar = "اللون", kr = "ڕەنگ")]
public enum Color : byte
{
    [QueryValue(ar = "اسود", kr = "ڕەش")]
    Black,

    [QueryValue(ar = "ابيض", kr = "سپی")]
    White,

    [QueryValue(ar = "ذهبي", kr = "زێڕین")]
    Gold,

    [QueryValue(ar = "فضي", kr = "زیوی")]
    Silver,

    [QueryValue(ar = "ازرق", kr = "شین")]
    Blue,

    [QueryValue(ar = "احمر", kr = "سوور")]
    Red,

    [QueryValue(ar = "اخضر", kr = "سەوز")]
    Green,

    [QueryValue(ar = "وردي", kr = "پەمەیی")]
    Pink,

    [QueryValue(ar = "بنفسجي", kr = "مۆر")]
    Purple,

    [QueryValue(ar = "اخر", kr = "ئەویتر")]
    Other
}
