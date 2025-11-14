using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Electronics;

public class CreateLaptopAdDtoValidator : AbstractValidator<CreateLaptopAdDto>
{
    public CreateLaptopAdDtoValidator()
    {
        Include(new CreateElectronicAdDtoValidator());

        RuleFor(x => x.Cpu)
            .MaximumLength(100).WithMessage(GetMessage(
                // CPU must not exceed 100 characters
                "يجب ألا يتجاوز المعالج 100 حرفًا",
                "پرۆسێسەر نابێت لە 100 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.Cpu));

        RuleFor(x => x.RamSize)
            .IsValidEnum();

        RuleFor(x => x.IsSSD)
            .IsValidEnum();

        RuleFor(x => x.StorageCapacity)
            .IsValidEnum();

        RuleFor(x => x.GraphicsCard)
            .MaximumLength(100).WithMessage(GetMessage(
                // Graphics card must not exceed 100 characters
                "يجب ألا تتجاوز بطاقة الرسومات 100 حرفًا",
                "کارتی گرافیک نابێت لە 100 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.GraphicsCard));

        RuleFor(x => x.UsbPorts)
            .InclusiveBetween((byte)0, (byte)10).WithMessage(GetMessage(
                // USB ports must be between 0 and 10
                "يجب أن تكون منافذ USB بين 0 و 10",
                "دەرگای USB دەبێت لە نێوان 0 و 10 بێت"));

        RuleFor(x => x.HdmiPorts)
            .InclusiveBetween((byte)0, (byte)5).WithMessage(GetMessage(
                // HDMI ports must be between 0 and 5
                "يجب أن تكون منافذ HDMI بين 0 و 5",
                "دەرگای HDMI دەبێت لە نێوان 0 و 5 بێت"));

        RuleFor(x => x.ScreenSize)
            .InclusiveBetween(10f, 40f).WithMessage(GetMessage(
                // Screen size must be between 10 and 40 inches
                "يجب أن يكون حجم الشاشة بين 10 و 40 بوصة",
                "قەبارەی شاشە دەبێت لە نێوان 10 و 40 ئینج بێت"));

        RuleFor(x => x.IsTouchscreen)
            .IsValidEnum();

        RuleFor(x => x.Resolution)
            .MaximumLength(50).WithMessage(GetMessage(
                // Resolution must not exceed 50 characters
                "يجب ألا تتجاوز الدقة 50 حرفًا",
                "وردبینی نابێت لە 50 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.Resolution));

        RuleFor(x => x.IsBacklitKeyboard)
            .IsValidEnum();

        RuleFor(x => x.HasWebcam)
            .IsValidEnum();

        RuleFor(x => x.WebcamResolution)
            .IsValidEnum();

        RuleFor(x => x.HasFingerprintReader)
            .IsValidEnum();

        RuleFor(x => x.Color)
            .IsValidEnum();

        RuleFor(x => x.ModelId)
            .NotEmpty().WithMessage("Model ID is required");
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
