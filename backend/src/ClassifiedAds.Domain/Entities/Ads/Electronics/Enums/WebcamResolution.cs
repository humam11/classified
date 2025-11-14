using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;

[QueryKey(ar = "دقة-الكاميرا", kr = "وردی-کامێرا")]
public enum WebcamResolution : byte
{
    [QueryValue(ar = "480p", kr = "480p")]
    P480,

    [QueryValue(ar = "720p", kr = "720p")]
    P720,

    [QueryValue(ar = "1080p", kr = "1080p")]
    P1080,

    [QueryValue(ar = "1440p", kr = "1440p")]
    P1440,

    [QueryValue(ar = "4K", kr = "4K")]
    K4,

    [QueryValue(ar = "8K", kr = "8K")]
    K8,

    [QueryValue(ar = "اخرى", kr = "ئەویتر")]
    Other
}
