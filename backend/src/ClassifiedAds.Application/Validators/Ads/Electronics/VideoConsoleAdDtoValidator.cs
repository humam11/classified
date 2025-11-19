using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Electronics;

public class VideoConsoleAdDtoValidator : AbstractValidator<VideoConsoleAdDto>
{
    public VideoConsoleAdDtoValidator()
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
    }
}

public class CreateVideoConsoleAdDtoValidator : AbstractValidator<CreateVideoConsoleAdDto>
{
    public CreateVideoConsoleAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new ElectronicAdDtoValidator());
        Include(new VideoConsoleAdDtoValidator());

        RuleFor(x => x.ModelId)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "معرف الموديل مطلوب",
                "ناسنامەی مۆدێل پێویستە"));

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
