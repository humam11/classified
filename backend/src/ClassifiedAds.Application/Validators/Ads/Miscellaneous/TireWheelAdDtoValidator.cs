using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Application.Validators.Ads;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Miscellaneous;

public class TireWheelAdDtoValidator : AbstractValidator<TireWheelAdDto>
{
    public TireWheelAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());

        RuleFor(x => x.Width)
            .InclusiveBetween((ushort)1, (ushort)400)
            .WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون العرض بين 1 و 400",
                "پانی دەبێت لە نێوان 1 و 400 بێت"))
            .When(x => x.Width.HasValue);

        RuleFor(x => x.AspectRatio)
            .InclusiveBetween((byte)1, (byte)90)
            .WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون نسبة الارتفاع بين 1 و 90",
                "ڕێژەی بەرزی دەبێت لە نێوان 1 و 90 بێت"))
            .When(x => x.AspectRatio.HasValue);

        RuleFor(x => x.RimDiameter)
            .InclusiveBetween((byte)1, (byte)30)
            .WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون قطر الحافة بين 1 و 30",
                "تیرەی قەڕ دەبێت لە نێوان 1 و 30 بێت"))
            .When(x => x.RimDiameter.HasValue);
    }
}

public class CreateTireWheelAdDtoValidator : AbstractValidator<CreateTireWheelAdDto>
{
    public CreateTireWheelAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new TireWheelAdDtoValidator());

        this.ApplyCreateLocalPriceRules();
    }
}
