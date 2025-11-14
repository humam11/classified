using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;

[QueryKey(ar = "سعة-التخزين", kr = "قەبارەی-هەڵگرتن")]
[GetUnits("GB")]
public enum StorageCapacity : ushort
{
    GB_16 = 16,

    GB_32 = 32,

    GB_64 = 64,

    GB_128 = 128,

    GB_256 = 256,

    GB_512 = 512,

    GB_1024 = 1024,

    GB_2048 = 2048
}
