using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Electronics;

public class CreateComputerAdDtoValidator : AbstractValidator<CreateComputerAdDto>
{
    public CreateComputerAdDtoValidator()
    {
        Include(new CreateElectronicAdDtoValidator());

        RuleFor(x => x.CPU)
            .MaximumLength(100).WithMessage(GetMessage(
                // CPU must not exceed 100 characters
                "يجب ألا يتجاوز المعالج 100 حرفًا",
                "پرۆسێسەر نابێت لە 100 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.CPU));

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
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
