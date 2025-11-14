using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;

[QueryKey(ar = "ساعات-العمل", kr = "کاتژمێرەکانی-کار")]
public enum WorkingHours : byte
{
    [QueryValue(ar = "صباحي", kr = "بەیانی")]
    Morning,

    [QueryValue(ar = "مسائي", kr = "ئێوارە")]
    Evening,

    [QueryValue(ar = "نوبات", kr = "شیفت")]
    Shifts,

    [QueryValue(ar = "مرن", kr = "نەرم")]
    Flexible
}
