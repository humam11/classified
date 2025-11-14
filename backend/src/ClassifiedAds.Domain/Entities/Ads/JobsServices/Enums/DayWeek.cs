using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;

[QueryKey(ar = "يوم-الاسبوع", kr = "ڕۆژی-هەفتە")]
public enum DayWeek : byte
{
    [QueryValue(ar = "كل يوم", kr = "هەموو ڕۆژێک")]
    Everyday,

    [QueryValue(ar = "يعتمد", kr = "پشت بە")]
    Depend,

    [QueryValue(ar = "الاحد", kr = "یەکشەممە")]
    Sunday,

    [QueryValue(ar = "الاثنين", kr = "دووشەممە")]
    Monday,

    [QueryValue(ar = "الثلاثاء", kr = "سێشەممە")]
    Tuesday,

    [QueryValue(ar = "الاربعاء", kr = "چوارشەممە")]
    Wednesday,

    [QueryValue(ar = "الخميس", kr = "پێنجشەممە")]
    Thursday,

    [QueryValue(ar = "الجمعة", kr = "هەینی")]
    Friday,

    [QueryValue(ar = "السبت", kr = "شەممە")]
    Saturday
}
