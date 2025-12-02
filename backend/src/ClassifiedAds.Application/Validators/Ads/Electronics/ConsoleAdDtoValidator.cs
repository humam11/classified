using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Electronics;

public class ConsoleAdDtoValidator : AbstractValidator<ConsoleAdDto>
{
    public ConsoleAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new ElectronicAdDtoValidator());

        RuleFor(x => x.StorageCapacity!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "سعة التخزين غير صالحة",
                "قەبارەی هەڵگرتن نادروستە"))
            .When(x => x.StorageCapacity.HasValue);

        RuleFor(x => x.ConsoleRegion!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "منطقة الجهاز غير صالحة",
                "ناوچەی ئامێر نادروستە"))
            .When(x => x.ConsoleRegion.HasValue);

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

public class CreateConsoleAdDtoValidator : AbstractValidator<CreateConsoleAdDto>
{
    public CreateConsoleAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new ElectronicAdDtoValidator());
        Include(new ConsoleAdDtoValidator());

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

        RuleFor(x => x.ConsoleRegion)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "منطقة الجهاز مطلوبة",
                "ناوچەی ئامێر پێویستە"));

        this.ApplyCreateRules(); // Console can be IQD or USD
    }
}
