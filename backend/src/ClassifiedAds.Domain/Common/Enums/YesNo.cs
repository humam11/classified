using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Common.Enums;

public enum YesNo : byte
{
    [QueryValue(ar = "لا", kr = "نەخێر")]
    No,

    [QueryValue(ar = "نعم", kr = "بەڵێ")]
    Yes
}
