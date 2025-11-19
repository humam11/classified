using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Electronics;

public class ComputerAdDtoValidator : AbstractValidator<ComputerAdDto>
{
    public ComputerAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new ElectronicAdDtoValidator());

        RuleFor(x => x.CPU)
            .MaximumLength(100).WithMessage(ValidationMessages.GetMessage(
                "يجب ألا يتجاوز المعالج 100 حرفًا",
                "پرۆسێسەر نابێت لە 100 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.CPU));

        RuleFor(x => x.RamSize!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "حجم الذاكرة العشوائية غير صالح",
                "قەبارەی یادی ڕام نادروستە"))
            .When(x => x.RamSize.HasValue);

        RuleFor(x => x.IsSSD!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "نوع التخزين غير صالح",
                "جۆری هەڵگرتن نادروستە"))
            .When(x => x.IsSSD.HasValue);

        RuleFor(x => x.StorageCapacity!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "سعة التخزين غير صالحة",
                "قەبارەی هەڵگرتن نادروستە"))
            .When(x => x.StorageCapacity.HasValue);

        RuleFor(x => x.GraphicsCard)
            .MaximumLength(100).WithMessage(ValidationMessages.GetMessage(
                "يجب ألا تتجاوز بطاقة الرسومات 100 حرفًا",
                "کارتی گرافیک نابێت لە 100 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.GraphicsCard));

        RuleFor(x => x.UsbPorts)
            .InclusiveBetween((byte)0, (byte)10).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون منافذ USB بين 0 و 10",
                "دەرگای USB دەبێت لە نێوان 0 و 10 بێت"))
            .When(x => x.UsbPorts.HasValue);

        RuleFor(x => x.HdmiPorts)
            .InclusiveBetween((byte)0, (byte)5).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون منافذ HDMI بين 0 و 5",
                "دەرگای HDMI دەبێت لە نێوان 0 و 5 بێت"))
            .When(x => x.HdmiPorts.HasValue);
    }
}

public class CreateComputerAdDtoValidator : AbstractValidator<CreateComputerAdDto>
{
    public CreateComputerAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new ElectronicAdDtoValidator());
        Include(new ComputerAdDtoValidator());

        // Required enum fields for creation
        RuleFor(x => x.RamSize)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "حجم الذاكرة العشوائية مطلوب",
                "قەبارەی یادی ڕام پێویستە"));

        RuleFor(x => x.IsSSD)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "نوع التخزين مطلوب",
                "جۆری هەڵگرتن پێویستە"));

        RuleFor(x => x.StorageCapacity)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "سعة التخزين مطلوبة",
                "قەبارەی هەڵگرتن پێویستە"));

        this.ApplyCreateLocalPriceRules();
    }
}
