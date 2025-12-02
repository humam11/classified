using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Electronics;

public class HandheldDeviceAdDtoValidator : AbstractValidator<HandheldDeviceAdDto>
{
    public HandheldDeviceAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new ElectronicAdDtoValidator());

        RuleFor(x => x.StorageCapacity!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "سعة التخزين غير صالحة",
                "قەبارەی هەڵگرتن نادروستە"))
            .When(x => x.StorageCapacity.HasValue);

        RuleFor(x => x.RamSize!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "حجم الذاكرة العشوائية غير صالح",
                "قەبارەی یادی ڕام نادروستە"))
            .When(x => x.RamSize.HasValue);

        RuleFor(x => x.Color!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "اللون غير صالح",
                "ڕەنگ نادروستە"))
            .When(x => x.Color.HasValue);

        RuleFor(x => x.MainCamera!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار الكاميرا الرئيسية غير صالح",
                "هەڵبژاردەی کامێرای سەرەکی نادروستە"))
            .When(x => x.MainCamera.HasValue);

        RuleFor(x => x.FrontCamera!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار الكاميرا الأمامية غير صالح",
                "هەڵبژاردەی کامێرای پێشەوە نادروستە"))
            .When(x => x.FrontCamera.HasValue);

        RuleFor(x => x.MainCameraResolution)
            .InclusiveBetween(1f, 400f).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون دقة الكاميرا الرئيسية بين 1 و 400",
                "وردبینی کامێرای سەرەکی دەبێت لە نێوان 1 و 400 بێت"))
            .When(x => x.MainCameraResolution.HasValue);

        RuleFor(x => x.FrontCameraResolution)
            .InclusiveBetween(1f, 200f).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون دقة الكاميرا الأمامية بين 1 و 200",
                "وردبینی کامێرای پێشەوە دەبێت لە نێوان 1 و 200 بێت"))
            .When(x => x.FrontCameraResolution.HasValue);

        RuleFor(x => x.BatteryCapacity)
            .InclusiveBetween((ushort)1000, (ushort)20000).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون سعة البطارية بين 1000 و 20000",
                "قەبارەی باتری دەبێت لە نێوان 1000 و 20000 بێت"))
            .When(x => x.BatteryCapacity.HasValue);

        RuleFor(x => x.ScreenSize)
            .InclusiveBetween(1f, 15f).WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون حجم الشاشة بين 1 و 15 بوصة",
                "قەبارەی شاشە دەبێت لە نێوان 1 و 15 ئینج بێت"))
            .When(x => x.ScreenSize.HasValue);

        RuleFor(x => x.Processor)
            .MaximumLength(100).WithMessage(ValidationMessages.GetMessage(
                "يجب ألا يتجاوز المعالج 100 حرفًا",
                "پرۆسێسەر نابێت لە 100 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.Processor));

        RuleFor(x => x.DualSim!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار الشريحة المزدوجة غير صالح",
                "هەڵبژاردەی دوو سیمکارت نادروستە"))
            .When(x => x.DualSim.HasValue);

        RuleFor(x => x.WaterproofSupport!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار مقاومة الماء غير صالح",
                "هەڵبژاردەی بەرگەگرتن لە ئاو نادروستە"))
            .When(x => x.WaterproofSupport.HasValue);

        RuleFor(x => x.StylusSupport!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار دعم القلم غير صالح",
                "هەڵبژاردەی پشتگیری پێنووس نادروستە"))
            .When(x => x.StylusSupport.HasValue);

        // Update-specific: ModelName required when BrandName changes
        RuleFor(x => x.ModelName)
            .NotEmpty()
            .WithMessage(ValidationMessages.GetMessage(
                "يجب تحديد الموديل عند تغيير العلامة التجارية",
                "دەبێت مۆدێل دیاری بکرێت کاتێک براند دەگۆڕێت"))
            .When(x => !string.IsNullOrEmpty(x.BrandName));

        // Update-specific: BrandName required when ModelName changes
        RuleFor(x => x.BrandName)
            .NotEmpty()
            .WithMessage(ValidationMessages.GetMessage(
                "يجب تحديد العلامة التجارية عند تغيير الموديل",
                "دەبێت براند دیاری بکرێت کاتێک مۆدێل دەگۆڕێت"))
            .When(x => !string.IsNullOrEmpty(x.ModelName));
    }
}

public class CreateHandheldDeviceAdDtoValidator : AbstractValidator<CreateHandheldDeviceAdDto>
{
    public CreateHandheldDeviceAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new ElectronicAdDtoValidator());
        Include(new HandheldDeviceAdDtoValidator());

        RuleFor(x => x.BrandName)
            .NotEmpty()
            .WithMessage(ValidationMessages.GetMessage(
                "اسم العلامة التجارية مطلوب",
                "ناوی براند پێویستە"));

        RuleFor(x => x.ModelName)
            .NotEmpty()
            .WithMessage(ValidationMessages.GetMessage(
                "اسم الموديل مطلوب",
                "ناوی مۆدێل پێویستە"));

        // Required enum fields for creation
        RuleFor(x => x.StorageCapacity)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "سعة التخزين مطلوبة",
                "قەبارەی هەڵگرتن پێویستە"));

        RuleFor(x => x.RamSize)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "حجم الذاكرة العشوائية مطلوب",
                "قەبارەی یادی ڕام پێویستە"));

        RuleFor(x => x.Color)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "اللون مطلوب",
                "ڕەنگ پێویستە"));

        RuleFor(x => x.MainCamera)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار الكاميرا الرئيسية مطلوب",
                "هەڵبژاردەی کامێرای سەرەکی پێویستە"));

        RuleFor(x => x.FrontCamera)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار الكاميرا الأمامية مطلوب",
                "هەڵبژاردەی کامێرای پێشەوە پێویستە"));

        RuleFor(x => x.DualSim)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار الشريحة المزدوجة مطلوب",
                "هەڵبژاردەی دوو سیمکارت پێویستە"));

        RuleFor(x => x.WaterproofSupport)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار مقاومة الماء مطلوب",
                "هەڵبژاردەی بەرگەگرتن لە ئاو پێویستە"));

        RuleFor(x => x.StylusSupport)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار دعم القلم مطلوب",
                "هەڵبژاردەی پشتگیری پێنووس پێویستە"));

        this.ApplyCreateRules(); // HandheldDevice can be IQD or USD
    }
}
