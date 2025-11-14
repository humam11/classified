using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Electronics;

public class CreateTvMonitorAdDtoValidator : AbstractValidator<CreateTvMonitorAdDto>
{
    public CreateTvMonitorAdDtoValidator()
    {
        Include(new CreateElectronicAdDtoValidator());

        RuleFor(x => x.ScreenSize)
            .InclusiveBetween(10f, 100f).WithMessage(GetMessage(
                // Screen size must be between 10 and 100 inches
                "يجب أن يكون حجم الشاشة بين 10 و 100 بوصة",
                "قەبارەی شاشە دەبێت لە نێوان 10 و 100 ئینج بێت"));

        RuleFor(x => x.ScreenResolution)
            .IsValidEnum();

        RuleFor(x => x.SmartTv)
            .IsValidEnum();

        RuleFor(x => x.RefreshRate)
            .IsValidEnum();

        RuleFor(x => x.HdmiPorts)
            .InclusiveBetween((byte)0, (byte)10).WithMessage(GetMessage(
                // HDMI ports must be between 0 and 10
                "يجب أن تكون منافذ HDMI بين 0 و 10",
                "دەرگای HDMI دەبێت لە نێوان 0 و 10 بێت"));

        RuleFor(x => x.UsbPorts)
            .InclusiveBetween((byte)0, (byte)10).WithMessage(GetMessage(
                // USB ports must be between 0 and 10
                "يجب أن تكون منافذ USB بين 0 و 10",
                "دەرگای USB دەبێت لە نێوان 0 و 10 بێت"));

        RuleFor(x => x.ModelId)
            .NotEmpty().WithMessage("Model ID is required");
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
