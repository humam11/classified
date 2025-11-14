using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;

[QueryKey(ar = "لغة-الكتاب", kr = "زمانی-کتێب")]
public enum BookLanguage : byte
{
    [QueryValue(ar = "عربي", kr = "عەرەبی")]
    Arabic,

    [QueryValue(ar = "كردي", kr = "کوردی")]
    Kurdish,

    [QueryValue(ar = "انجليزي", kr = "ئینگلیزی")]
    English,

    [QueryValue(ar = "فرنسي", kr = "فەرەنسی")]
    French,

    [QueryValue(ar = "الماني", kr = "ئاڵمانی")]
    German,

    [QueryValue(ar = "اخر", kr = "ئەویتر")]
    Other
}
