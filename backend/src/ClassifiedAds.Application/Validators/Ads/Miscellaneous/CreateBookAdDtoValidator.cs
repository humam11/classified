using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Miscellaneous;

public class CreateBookAdDtoValidator : AbstractValidator<CreateBookAdDto>
{
    public CreateBookAdDtoValidator()
    {
        Include(new CreateAdLocalPriceOnlyValidator());

        RuleFor(x => x.BookLanguage)
            .IsValidEnum();

        RuleFor(x => x.Pages)
            .InclusiveBetween((ushort)1, (ushort)2000).WithMessage(GetMessage(
                // Pages must be between 1 and 2000
                "يجب أن تكون الصفحات بين 1 و 2000",
                "پەڕە دەبێت لە نێوان 1 و 2000 بێت"));
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
