using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;

[QueryKey(ar = "الجنس", kr = "ڕەگەز")]
public enum Gender : byte
{
    [QueryValue(ar = "ذكر", kr = "نێر")]
    Male,

    [QueryValue(ar = "أنثى", kr = "مێ")]
    Female
}
