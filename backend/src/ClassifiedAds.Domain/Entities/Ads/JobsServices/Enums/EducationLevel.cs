using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;

[QueryKey(ar = "المستوى-التعليمي", kr = "ئاستی-پەروەردە")]
public enum EducationLevel : byte
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

    [QueryValue(ar = "غير مطلوب", kr = "پێویست نییە")]
    NotRequired
}
