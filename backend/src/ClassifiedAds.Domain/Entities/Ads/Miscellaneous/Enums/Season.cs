using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;

[QueryKey(ar = "الموسم", kr = "وەرز")]
public enum Season : byte
{
    [QueryValue(ar = "شتاء", kr = "زستان")]
    Winter,

    [QueryValue(ar = "صيف", kr = "هاوین")]
    Summer
}
