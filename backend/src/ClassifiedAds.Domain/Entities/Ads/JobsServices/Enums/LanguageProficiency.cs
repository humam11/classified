using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;

[QueryKey(ar = "مستوى-الإتقان", kr = "ئاستی-شارەزایی")]
public enum LanguageProficiency : byte
{
    [QueryValue(ar = "أساسي", kr = "بنەڕەتی")]
    Basic,

    [QueryValue(ar = "متوسط", kr = "ناوەند")]
    Intermediate,

    [QueryValue(ar = "طليق", kr = "ڕەوان")]
    Fluent,

    [QueryValue(ar = "لغة أم", kr = "زمانی دایک")]
    Native,

    [QueryValue(ar = "آخر", kr = "ئەویتر")]
    Other
}
