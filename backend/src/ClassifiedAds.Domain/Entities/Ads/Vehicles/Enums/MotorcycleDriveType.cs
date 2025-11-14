using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Vehicles.Enums;

[QueryKey(ar = "نوع-النقل", kr = "جۆری-گواستنەوە")]
public enum MotorcycleDriveType : byte
{
    [QueryValue(ar = "سلسلة", kr = "زنجیر")]
    Chain,

    [QueryValue(ar = "حزام", kr = "کەمەر")]
    Belt,

    [QueryValue(ar = "عمود", kr = "شافت")]
    Shaft,

    [QueryValue(ar = "محور", kr = "ناوەند")]
    Hub
}
