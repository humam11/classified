using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;

[QueryKey(ar = "حالة-البحث-عن-عمل", kr = "دۆخی-گەڕان-بەدوای-کار")]
public enum JobSearchStatus : byte
{
    [QueryValue(ar = "يبحث عن عمل", kr = "بەدوای کاردا دەگەڕێت")]
    LookingForWork,

    [QueryValue(ar = "موظف ويبحث عن عمل جديد", kr = "کارمەندە و بەدوای کاری نوێدا دەگەڕێت")]
    EmployedAndLooking,

    [QueryValue(ar = "لا يبحث عن عمل", kr = "بەدوای کاردا ناگەڕێت")]
    NotLooking
}
