using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Electronics;

public class TvMonitorAdDtoValidator : AbstractValidator<TvMonitorAdDto>
{
    public TvMonitorAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new ElectronicAdDtoValidator());

        RuleFor(x => x.ScreenSize)
            .InclusiveBetween(10f, 100f).WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون حجم الشاشة بين 10 و 100 بوصة",
                "قەبارەی شاشە دەبێت لە نێوان 10 و 100 ئینج بێت"))
            .When(x => x.ScreenSize.HasValue);

        RuleFor(x => x.ScreenResolution!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "دقة الشاشة غير صالحة",
                "وردبینی شاشە نادروستە"))
            .When(x => x.ScreenResolution.HasValue);

        RuleFor(x => x.SmartTv!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار التلفاز الذكي غير صالح",
                "هەڵبژاردەی تەلەفیزیۆنی زیرەک نادروستە"))
            .When(x => x.SmartTv.HasValue);

        RuleFor(x => x.RefreshRate!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "معدل التحديث غير صالح",
                "ڕێژەی نوێکردنەوە نادروستە"))
            .When(x => x.RefreshRate.HasValue);

        RuleFor(x => x.HdmiPorts)
            .InclusiveBetween((byte)0, (byte)10).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون منافذ HDMI بين 0 و 10",
                "دەرگای HDMI دەبێت لە نێوان 0 و 10 بێت"))
            .When(x => x.HdmiPorts.HasValue);

        RuleFor(x => x.UsbPorts)
            .InclusiveBetween((byte)0, (byte)10).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون منافذ USB بين 0 و 10",
                "دەرگای USB دەبێت لە نێوان 0 و 10 بێت"))
            .When(x => x.UsbPorts.HasValue);
    }
}

public class CreateTvMonitorAdDtoValidator : AbstractValidator<CreateTvMonitorAdDto>
{
    public CreateTvMonitorAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new ElectronicAdDtoValidator());
        Include(new TvMonitorAdDtoValidator());

        RuleFor(x => x.ModelId)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "معرف الموديل مطلوب",
                "ناسنامەی مۆدێل پێویستە"));

        // Required enum fields for creation
        RuleFor(x => x.ScreenResolution)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "دقة الشاشة مطلوبة",
                "وردبینی شاشە پێویستە"));

        RuleFor(x => x.SmartTv)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار التلفاز الذكي مطلوب",
                "هەڵبژاردەی تەلەفیزیۆنی زیرەک پێویستە"));

        RuleFor(x => x.RefreshRate)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "معدل التحديث مطلوب",
                "ڕێژەی نوێکردنەوە پێویستە"));

        this.ApplyCreateRules(); // TvMonitor can be IQD or USD
    }
}
