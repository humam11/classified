using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;

[QueryKey(ar = "مجال-الدراسة", kr = "بواری-خوێندن")]
public enum FieldOfStudy : byte
{
    [QueryValue(ar = "هندسة", kr = "ئەندازیاری")]
    Engineering,

    [QueryValue(ar = "طب", kr = "پزیشکی")]
    Medicine,

    [QueryValue(ar = "علوم", kr = "زانست")]
    Science,

    [QueryValue(ar = "تجارة", kr = "بازرگانی")]
    Business,

    [QueryValue(ar = "تعليم", kr = "پەروەردە")]
    Education,

    [QueryValue(ar = "أخرى", kr = "ئەویتر")]
    Other
}
