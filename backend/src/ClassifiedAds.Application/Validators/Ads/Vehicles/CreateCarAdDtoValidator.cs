using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles;

public class CreateCarAdDtoValidator : AbstractValidator<CreateCarAdDto>
{
    public CreateCarAdDtoValidator()
    {
        Include(new CreateTransportAdDtoValidator());

        RuleFor(x => x.DistanceKm)
            .GreaterThanOrEqualTo(0).WithMessage(GetMessage(
                // Distance must be 0 or greater
                "يجب أن تكون المسافة 0 أو أكبر",
                "مەودا دەبێت 0 یان زیاتر بێت"));

        RuleFor(x => x.EngineDescription)
            .MaximumLength(200).WithMessage(GetMessage(
                // Engine description must not exceed 200 characters
                "يجب ألا يتجاوز وصف المحرك 200 حرفًا",
                "وەسفی بزوێنەر نابێت لە 200 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.EngineDescription));

        RuleFor(x => x.Cylinders)
            .InclusiveBetween((byte)1, (byte)16).WithMessage(GetMessage(
                // Cylinders must be between 1 and 16
                "يجب أن تكون الأسطوانات بين 1 و 16",
                "سلندەر دەبێت لە نێوان 1 و 16 بێت"));

        RuleFor(x => x.Transmission)
            .IsValidEnum();

        RuleFor(x => x.DriveType)
            .IsValidEnum();

        RuleFor(x => x.Color)
            .NotEmpty().WithMessage(GetMessage(
                // Color is required
                "اللون مطلوب",
                "ڕەنگ پێویستە"))
            .MaximumLength(50).WithMessage(GetMessage(
                // Color must not exceed 50 characters
                "يجب ألا يتجاوز اللون 50 حرفًا",
                "ڕەنگ نابێت لە 50 پیت زیاتر بێت"));

        RuleFor(x => x.ModelId)
            .NotEmpty().WithMessage("Model ID is required");

        RuleFor(x => x.SubModelReleaseId)
            .NotEmpty().WithMessage("Sub-model release ID is required");
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
