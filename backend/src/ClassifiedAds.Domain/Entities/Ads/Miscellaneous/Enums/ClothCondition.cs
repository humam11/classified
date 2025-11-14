using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;

[QueryKey(ar = "حالة-اللبس", kr = "دۆخی-پۆشاک")]
public enum ClothCondition : byte
{
    [QueryValue(ar = "مستعمل", kr = "بەکارهاتوو")]
    Used,

    [QueryValue(ar = "جديد", kr = "نوێ")]
    New
}
