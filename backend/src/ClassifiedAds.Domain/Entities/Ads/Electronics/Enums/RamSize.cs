using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;

[QueryKey(ar = "حجم-الذاكرة-العشوائية", kr = "قەبارەی-یادی-کاتی")]
[GetUnits("GB")]
public enum RamSize : byte
{
    GB_4 = 4,

    GB_8 = 8,

    GB_16 = 16,

    GB_32 = 32,

    GB_64 = 64
}
