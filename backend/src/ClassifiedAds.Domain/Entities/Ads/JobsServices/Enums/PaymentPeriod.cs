using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.JobsServices.Enums;

[QueryKey(ar = "طريقة-الدفع", kr = "شێوازی-پارەدان")]
public enum PaymentPeriod : byte
{
    [QueryValue(ar = "شهريًا", kr = "مانگانە")]
    PerMonth,

    [QueryValue(ar = "لكل وردية", kr = "بۆ هەر شیفتێک")]
    PerShift,

    [QueryValue(ar = "لكل ساعة", kr = "بۆ هەر کاتژمێرێک")]
    PerHour,

    [QueryValue(ar = "لكل خدمة", kr = "بۆ هەر خزمەتگوزارییەک")]
    PerService,

    [QueryValue(ar = "للخدمة", kr = "بۆ خزمەتگوزاری")]
    PerServiceAlt,

    [QueryValue(ar = "للمتر", kr = "بۆ مەتر")]
    PerMeter,

    [QueryValue(ar = "للقطعة", kr = "بۆ پارچە")]
    PerPiece,

    [QueryValue(ar = "لليوم", kr = "بۆ ڕۆژ")]
    PerDay,

    [QueryValue(ar = "للدقيقة", kr = "بۆ خولەک")]
    PerMinute
}
