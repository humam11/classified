using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Miscellaneous;

public class CreateEngineOilAdDtoValidator : AbstractValidator<CreateEngineOilAdDto>
{
    public CreateEngineOilAdDtoValidator()
    {
        Include(new CreateAdLocalPriceOnlyValidator());

        RuleFor(x => x.Volume)
            .InclusiveBetween((ushort)1, (ushort)1499).WithMessage(GetMessage(
                // Volume must be between 1 and 1499
                "يجب أن يكون الحجم بين 1 و 1499",
                "قەبارە دەبێت لە نێوان 1 و 1499 بێت"));

        RuleFor(x => x.OilType)
            .IsValidEnum();

        RuleFor(x => x.Viscosity)
            .IsValidEnum();
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
