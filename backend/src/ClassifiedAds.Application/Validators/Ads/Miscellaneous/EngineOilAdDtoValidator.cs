using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Miscellaneous;

public class EngineOilAdDtoValidator : AbstractValidator<EngineOilAdDto>
{
    public EngineOilAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());

        RuleFor(x => x.OilType!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "نوع الزيت غير صالح",
                "جۆری ڕۆن نادروستە"))
            .When(x => x.OilType.HasValue);

        RuleFor(x => x.Viscosity!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "اللزوجة غير صالحة",
                "قەوارەیی نادروستە"))
            .When(x => x.Viscosity.HasValue);

        RuleFor(x => x.Volume)
            .InclusiveBetween((ushort)1, (ushort)1499)
            .WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون الحجم بين 1 و 1499",
                "قەبارە دەبێت لە نێوان 1 و 1499 بێت"))
            .When(x => x.Volume.HasValue);
    }
}

public class CreateEngineOilAdDtoValidator : AbstractValidator<CreateEngineOilAdDto>
{
    public CreateEngineOilAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new EngineOilAdDtoValidator());

        RuleFor(x => x.OilType)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "نوع الزيت مطلوب",
                "جۆری ڕۆن پێویستە"));

        RuleFor(x => x.Viscosity)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "اللزوجة مطلوبة",
                "قەوارەیی پێویستە"));

        this.ApplyCreateLocalPriceRules();
    }
}
