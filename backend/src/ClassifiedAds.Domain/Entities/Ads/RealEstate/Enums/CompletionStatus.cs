using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.RealEstate.Enums;

[QueryKey(ar = "نسبة-الانجاز", kr = "ڕێژەی-تەواوبوون")]
public enum CompletionStatus : byte
{
    [QueryValue(ar = "تحت الانشاء", kr = "لەژێر دروستکردندایە")]
    UnderConstruction,

    [QueryValue(ar = "قيد التشطيب", kr = "لە تەواوکردندایە")]
    Finishing,

    [QueryValue(ar = "تشطيب كامل", kr = "تەواو تەواوکراوە")]
    FullyFinished
}
