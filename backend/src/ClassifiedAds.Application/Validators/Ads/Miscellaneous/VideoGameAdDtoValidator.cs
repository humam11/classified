using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Miscellaneous;

// VideoGame is the only Miscellaneous item that can have IsDollar = true or false
public class VideoGameAdDtoValidator : AbstractValidator<VideoGameAdDto>
{
    public VideoGameAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());

        RuleFor(x => x.VideoGameRegion!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "منطقة اللعبة غير صالحة",
                "ناوچەی یاری نادروستە"))
            .When(x => x.VideoGameRegion.HasValue);

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

public class CreateVideoGameAdDtoValidator : AbstractValidator<CreateVideoGameAdDto>
{
    public CreateVideoGameAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new VideoGameAdDtoValidator());

        RuleFor(x => x.VideoGameRegion)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "منطقة اللعبة مطلوبة",
                "ناوچەی یاری پێویستە"));

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

        this.ApplyCreateRules(); // VideoGame can be IQD or USD
    }
}
