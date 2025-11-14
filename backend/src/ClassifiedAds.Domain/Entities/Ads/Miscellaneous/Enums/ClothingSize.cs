using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;

[QueryKey(ar = "المقاس", kr = "قەبارە")]
public enum ClothingSize : byte
{
    XS,

    S,

    M,

    L,

    XL,

    XXL,

    XXXL
}
