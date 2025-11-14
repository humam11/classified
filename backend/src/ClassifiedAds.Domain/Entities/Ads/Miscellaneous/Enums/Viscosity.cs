using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;

[QueryKey(ar = "اللزوجة", kr = "لەسکی")]
public enum Viscosity : byte
{
    [QueryValue(ar = "0W-20", kr = "0W-20")]
    W0_20,

    [QueryValue(ar = "0W-30", kr = "0W-30")]
    W0_30,

    [QueryValue(ar = "5W-20", kr = "5W-20")]
    W5_20,

    [QueryValue(ar = "5W-30", kr = "5W-30")]
    W5_30,

    [QueryValue(ar = "5W-40", kr = "5W-40")]
    W5_40,

    [QueryValue(ar = "10W-30", kr = "10W-30")]
    W10_30,

    [QueryValue(ar = "10W-40", kr = "10W-40")]
    W10_40,

    [QueryValue(ar = "15W-40", kr = "15W-40")]
    W15_40,

    [QueryValue(ar = "20W-50", kr = "20W-50")]
    W20_50,

    [QueryValue(ar = "SAE 30", kr = "SAE 30")]
    SAE_30,

    [QueryValue(ar = "SAE 40", kr = "SAE 40")]
    SAE_40,

    [QueryValue(ar = "SAE 50", kr = "SAE 50")]
    SAE_50,

    [QueryValue(ar = "75W-80", kr = "75W-80")]
    W75_80,

    [QueryValue(ar = "75W-90", kr = "75W-90")]
    W75_90,

    [QueryValue(ar = "80W-90", kr = "80W-90")]
    W80_90,

    [QueryValue(ar = "85W-140", kr = "85W-140")]
    W85_140,

    [QueryValue(ar = "ATF", kr = "ATF")]
    ATF,

    [QueryValue(ar = "DOT 3", kr = "DOT 3")]
    DOT_3,

    [QueryValue(ar = "DOT 4", kr = "DOT 4")]
    DOT_4,

    [QueryValue(ar = "أخرى", kr = "ئەویتر")]
    Other
}