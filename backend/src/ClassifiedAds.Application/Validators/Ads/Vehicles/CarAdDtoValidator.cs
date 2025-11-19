using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles;

public class CarAdDtoValidator : AbstractValidator<CarAdDto>
{
    public CarAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new TransportAdDtoValidator());

        RuleFor(x => x.DistanceKm)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون المسافة 0 أو أكبر",
                "مەودا دەبێت 0 یان زیاتر بێت"))
            .When(x => x.DistanceKm.HasValue);

        RuleFor(x => x.EngineDescription)
            .MaximumLength(200).WithMessage(ValidationMessages.GetMessage(
                "يجب ألا يتجاوز وصف المحرك 200 حرفًا",
                "وەسفی بزوێنەر نابێت لە 200 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.EngineDescription));

        RuleFor(x => x.Cylinders)
            .InclusiveBetween((byte)1, (byte)16).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون الأسطوانات بين 1 و 16",
                "سلندەر دەبێت لە نێوان 1 و 16 بێت"))
            .When(x => x.Cylinders.HasValue);

        RuleFor(x => x.Transmission!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "ناقل الحركة غير صالح",
                "گێربۆکس نادروستە"))
            .When(x => x.Transmission.HasValue);

        RuleFor(x => x.DriveType!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "نوع الدفع غير صالح",
                "جۆری هاندەر نادروستە"))
            .When(x => x.DriveType.HasValue);

        RuleFor(x => x.Color)
            .MaximumLength(50).WithMessage(ValidationMessages.GetMessage(
                "يجب ألا يتجاوز اللون 50 حرفًا",
                "ڕەنگ نابێت لە 50 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.Color));
    }
}

public class CreateCarAdDtoValidator : AbstractValidator<CreateCarAdDto>
{
    public CreateCarAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new TransportAdDtoValidator());
        Include(new CarAdDtoValidator());

        RuleFor(x => x.ModelId)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "معرف الموديل مطلوب",
                "ناسنامەی مۆدێل پێویستە"));

        RuleFor(x => x.SubModelReleaseId)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "معرف سنة الموديل مطلوب",
                "ناسنامەی ساڵی مۆدێل پێویستە"));

        // Required enum fields for creation
        RuleFor(x => x.Transmission)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "ناقل الحركة مطلوب",
                "گێربۆکس پێویستە"));

        RuleFor(x => x.DriveType)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "نوع الدفع مطلوب",
                "جۆری هاندەر پێویستە"));

        this.ApplyCreateRules(); // Car can be IQD or USD
    }
}
