using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;

[QueryKey(ar = "نوع-المادة", kr = "جۆری-مادە")]
public enum FurnitureMaterial : byte
{
    [QueryValue(ar = "خشب", kr = "دار")]
    Wood,

    [QueryValue(ar = "حديد", kr = "ئاسن")]
    Metal,

    [QueryValue(ar = "زجاج", kr = "شووشە")]
    Glass,

    [QueryValue(ar = "بلاستيك", kr = "پلاستیک")]
    Plastic,

    [QueryValue(ar = "جلد", kr = "چەرم")]
    Leather,

    [QueryValue(ar = "قماش", kr = "قوماش")]
    Fabric,

    [QueryValue(ar = "اخر", kr = "ئەویتر")]
    Other
}
