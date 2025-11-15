using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Common;

/// <summary>
/// Base validator for PriceDto - validates price value and currency type.
/// ShowingPrice is server-generated and not validated here.
/// </summary>
public class PriceDtoValidator : AbstractValidator<PriceDto>
{
    public PriceDtoValidator()
    {
        RuleFor(x => x.Value)
            .GreaterThan(0)
            .WithMessage(GetMessage(
                // Price must be greater than 0
                "يجب أن يكون السعر أكبر من 0",
                "نرخ دەبێت گەورەتر بێت لە 0"));
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}

/// <summary>
/// Validator for prices that must be in local currency (IQD) only.
/// Used for: RealEstate, Service, and all Miscellaneous (except VideoGame).
/// </summary>
public class PriceLocalOnlyValidator : AbstractValidator<PriceDto>
{
    public PriceLocalOnlyValidator()
    {
        Include(new PriceDtoValidator());
        
        RuleFor(x => x.IsDollar)
            .Equal(false)
            .WithMessage(GetMessage(
                // Price must be in local currency (IQD)
                "يجب أن يكون السعر بالعملة المحلية (دينار عراقي) فقط",
                "نرخ دەبێت بە دراوی ناوخۆیی (دیناری عێراقی) بێت"));
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
