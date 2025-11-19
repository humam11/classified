using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Electronics;

public class LaptopAdDtoValidator : AbstractValidator<LaptopAdDto>
{
    public LaptopAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new ElectronicAdDtoValidator());

        RuleFor(x => x.Cpu)
            .MaximumLength(100).WithMessage(ValidationMessages.GetMessage(
                "يجب ألا يتجاوز المعالج 100 حرفًا",
                "پرۆسێسەر نابێت لە 100 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.Cpu));

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

        RuleFor(x => x.ScreenSize)
            .InclusiveBetween(10f, 40f).WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون حجم الشاشة بين 10 و 40 بوصة",
                "قەبارەی شاشە دەبێت لە نێوان 10 و 40 ئینج بێت"))
            .When(x => x.ScreenSize.HasValue);

        RuleFor(x => x.IsTouchscreen!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار الشاشة اللمسية غير صالح",
                "هەڵبژاردەی شاشەی کارپێکردن نادروستە"))
            .When(x => x.IsTouchscreen.HasValue);

        RuleFor(x => x.Resolution)
            .MaximumLength(50).WithMessage(ValidationMessages.GetMessage(
                "يجب ألا تتجاوز الدقة 50 حرفًا",
                "وردبینی نابێت لە 50 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.Resolution));

        RuleFor(x => x.IsBacklitKeyboard!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار لوحة المفاتيح المضيئة غير صالح",
                "هەڵبژاردەی تەختەکلیلی ڕووناک نادروستە"))
            .When(x => x.IsBacklitKeyboard.HasValue);

        RuleFor(x => x.HasWebcam!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار الكاميرا غير صالح",
                "هەڵبژاردەی کامێرا نادروستە"))
            .When(x => x.HasWebcam.HasValue);

        RuleFor(x => x.WebcamResolution!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "دقة الكاميرا غير صالحة",
                "وردبینی کامێرا نادروستە"))
            .When(x => x.WebcamResolution.HasValue);

        RuleFor(x => x.HasFingerprintReader!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار قارئ البصمة غير صالح",
                "هەڵبژاردەی خوێنەرەوەی پەنجە نیشان نادروستە"))
            .When(x => x.HasFingerprintReader.HasValue);

        RuleFor(x => x.Color!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "اللون غير صالح",
                "ڕەنگ نادروستە"))
            .When(x => x.Color.HasValue);
    }
}

public class CreateLaptopAdDtoValidator : AbstractValidator<CreateLaptopAdDto>
{
    public CreateLaptopAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new ElectronicAdDtoValidator());
        Include(new LaptopAdDtoValidator());

        RuleFor(x => x.ModelId)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "معرف الموديل مطلوب",
                "ناسنامەی مۆدێل پێویستە"));

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

        RuleFor(x => x.IsTouchscreen)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار الشاشة اللمسية مطلوب",
                "هەڵبژاردەی شاشەی کارپێکردن پێویستە"));

        RuleFor(x => x.IsBacklitKeyboard)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار لوحة المفاتيح المضيئة مطلوب",
                "هەڵبژاردەی تەختەکلیلی ڕووناک پێویستە"));

        RuleFor(x => x.HasWebcam)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار الكاميرا مطلوب",
                "هەڵبژاردەی کامێرا پێویستە"));

        RuleFor(x => x.WebcamResolution)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "دقة الكاميرا مطلوبة",
                "وردبینی کامێرا پێویستە"));

        RuleFor(x => x.HasFingerprintReader)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار قارئ البصمة مطلوب",
                "هەڵبژاردەی خوێنەرەوەی پەنجە نیشان پێویستە"));

        RuleFor(x => x.Color)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "اللون مطلوب",
                "ڕەنگ پێویستە"));

        this.ApplyCreateRules(); // Laptop can be IQD or USD
    }
}
