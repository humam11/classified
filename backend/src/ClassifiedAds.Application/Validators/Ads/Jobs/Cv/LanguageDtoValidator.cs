using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Jobs;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Jobs.Cv;

public class LanguageDtoValidator : AbstractValidator<LanguageDto>
{
    public LanguageDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(ValidationMessages.GetMessage(
                "اسم اللغة مطلوب",
                "ناوی زمان پێویستە"))
            .MaximumLength(100)
            .WithMessage(ValidationMessages.GetMessage(
                "اسم اللغة يجب أن لا يتجاوز 100 حرف",
                "ناوی زمان نابێت لە 100 پیت زیاتر بێت"));

        // If Name is provided, then LanguageProficiency is required
        RuleFor(x => x.LanguageProficiency)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "مستوى الإتقان مطلوب",
                "ئاستی شارەزایی پێویستە"))
            .When(x => !string.IsNullOrEmpty(x.Name));

        RuleFor(x => x.LanguageProficiency)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "مستوى الإتقان غير صالح",
                "ئاستی شارەزایی نادروستە"));
    }
}
