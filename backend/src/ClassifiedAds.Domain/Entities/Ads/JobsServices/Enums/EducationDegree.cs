using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;

[QueryKey(ar = "الدرجة-العلمية", kr = "بڕوانامەی-زانستی")]
public enum EducationDegree : byte
{
    [QueryValue(ar = "ثانوي", kr = "ئامادەیی")]
    HighSchool,

    [QueryValue(ar = "دبلوم", kr = "دبلۆم")]
    Diploma,

    [QueryValue(ar = "بكالوريوس", kr = "بەکالۆریۆس")]
    Bachelor,

    [QueryValue(ar = "ماجستير", kr = "ماستەر")]
    Master,

    [QueryValue(ar = "دكتوراه", kr = "دکتۆرا")]
    PhD,

    [QueryValue(ar = "أخرى", kr = "ئەویتر")]
    Other
}
