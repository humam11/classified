using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Miscellaneous;

public class CreateTireWheelAdDtoValidator : AbstractValidator<CreateTireWheelAdDto>
{
    public CreateTireWheelAdDtoValidator()
    {
        Include(new CreateAdLocalPriceOnlyValidator());

        RuleFor(x => x.Width)
            .InclusiveBetween((ushort)1, (ushort)400).WithMessage(GetMessage(
                // Width must be between 1 and 400
                "يجب أن يكون العرض بين 1 و 400",
                "پانی دەبێت لە نێوان 1 و 400 بێت"));

        RuleFor(x => x.AspectRatio)
            .InclusiveBetween((byte)1, (byte)90).WithMessage(GetMessage(
                // Aspect ratio must be between 1 and 90
                "يجب أن تكون نسبة العرض إلى الارتفاع بين 1 و 90",
                "ڕێژەی لا دەبێت لە نێوان 1 و 90 بێت"));

        RuleFor(x => x.RimDiameter)
            .InclusiveBetween((byte)1, (byte)30).WithMessage(GetMessage(
                // Rim diameter must be between 1 and 30
                "يجب أن يكون قطر الحافة بين 1 و 30",
                "تیرەی قەڕ دەبێت لە نێوان 1 و 30 بێت"));
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
