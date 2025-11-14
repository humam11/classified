using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;

[QueryKey(ar = "نوع-الوظيفة", kr = "جۆری-کار")]
public enum JobType : byte
{
    [QueryValue(ar = "دوام كامل", kr = "کاری تەواو")]
    FullTime,

    [QueryValue(ar = "دوام جزئي", kr = "کاری بەشێک لە کات")]
    PartTime,

    [QueryValue(ar = "عن بعد", kr = "دوور")]
    Remote,

    [QueryValue(ar = "مؤقت", kr = "کاتی")]
    Temporary,

    [QueryValue(ar = "تدريب", kr = "ڕاهێنان")]
    Internship
}
