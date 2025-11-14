using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;

[QueryKey(ar = "الدقة", kr = "وردی")]
public enum ScreenResolution : byte
{
    [QueryValue(ar = "HD", kr = "HD")]
    HD,

    [QueryValue(ar = "FHD", kr = "FHD")]
    FHD,

    [QueryValue(ar = "2K", kr = "2K")]
    K2,

    [QueryValue(ar = "4K", kr = "4K")]
    K4,

    [QueryValue(ar = "8K", kr = "8K")]
    K8
}