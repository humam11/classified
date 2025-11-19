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

        RuleFor(x => x.ModelId)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "معرف الموديل مطلوب",
                "ناسنامەی مۆدێل پێویستە"));

        this.ApplyCreateRules(); // VideoGame can be IQD or USD
    }
}
