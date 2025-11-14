using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Common.Enums;

public enum Units
{
    [QueryValue(ar = "كيلوغرام", kr = "کیلۆگرام")]
    kg,

    [QueryValue(ar = "طن", kr = "تەن")]
    ton,

    [QueryValue(ar = "غرام", kr = "گرام")]
    gram,

    [QueryValue(ar = "لتر", kr = "لیتەر")]
    liter,

    [QueryValue(ar = "متر", kr = "مەتر")]
    meter,

    [QueryValue(ar = "كم", kr = "کم")]
    kilometer,

    [QueryValue(ar = "حصان", kr = "ئەسپ")]
    horsepower,

    [QueryValue(ar = "سم", kr = "سم")]
    cm,

    [QueryValue(ar = "ملم", kr = "ملم")]
    mm,

    gb,

    [QueryValue(ar = "بوصة", kr = "ئینچ")]
    inch,

    [QueryValue(ar = "هرتز", kr = "هێرتز")]
    hertz
}
