using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Electronics;

public class CreateHandheldDeviceAdDtoValidator : AbstractValidator<CreateHandheldDeviceAdDto>
{
    public CreateHandheldDeviceAdDtoValidator()
    {
        Include(new CreateElectronicAdDtoValidator());

        RuleFor(x => x.StorageCapacity)
            .IsValidEnum();

        RuleFor(x => x.RamSize)
            .IsValidEnum();

        RuleFor(x => x.Color)
            .IsValidEnum();

        RuleFor(x => x.MainCamera)
            .IsValidEnum();

        RuleFor(x => x.FrontCamera)
            .IsValidEnum();

        RuleFor(x => x.MainCameraResolution)
            .InclusiveBetween((ushort)1, (ushort)400).WithMessage(GetMessage(
                // Main camera resolution must be between 1 and 400
                "يجب أن تكون دقة الكاميرا الرئيسية بين 1 و 400",
                "وردبینی کامێرای سەرەکی دەبێت لە نێوان 1 و 400 بێت"));

        RuleFor(x => x.FrontCameraResolution)
            .InclusiveBetween((ushort)1, (ushort)200).WithMessage(GetMessage(
                // Front camera resolution must be between 1 and 200
                "يجب أن تكون دقة الكاميرا الأمامية بين 1 و 200",
                "وردبینی کامێرای پێشەوە دەبێت لە نێوان 1 و 200 بێت"));

        RuleFor(x => x.BatteryCapacity)
            .InclusiveBetween((ushort)1000, (ushort)20000).WithMessage(GetMessage(
                // Battery capacity must be between 1000 and 20000
                "يجب أن تكون سعة البطارية بين 1000 و 20000",
                "قەبارەی باتری دەبێت لە نێوان 1000 و 20000 بێت"));

        RuleFor(x => x.ScreenSize)
            .InclusiveBetween(1f, 15f).WithMessage(GetMessage(
                // Screen size must be between 1 and 15 inches
                "يجب أن يكون حجم الشاشة بين 1 و 15 بوصة",
                "قەبارەی شاشە دەبێت لە نێوان 1 و 15 ئینج بێت"));

        RuleFor(x => x.Processor)
            .MaximumLength(100).WithMessage(GetMessage(
                // Processor must not exceed 100 characters
                "يجب ألا يتجاوز المعالج 100 حرفًا",
                "پرۆسێسەر نابێت لە 100 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.Processor));

        RuleFor(x => x.DualSim)
            .IsValidEnum();

        RuleFor(x => x.WaterproofSupport)
            .IsValidEnum();

        RuleFor(x => x.StylusSupport)
            .IsValidEnum();

        RuleFor(x => x.ModelId)
            .NotEmpty().WithMessage("Model ID is required");
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
