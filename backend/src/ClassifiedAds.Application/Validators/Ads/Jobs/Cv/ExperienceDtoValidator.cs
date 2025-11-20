using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Jobs;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Jobs.Cv;

public class ExperienceDtoValidator : AbstractValidator<ExperienceDto>
{
    public ExperienceDtoValidator()
    {
        RuleFor(x => x.CompanyName)
            .NotEmpty()
            .WithMessage(ValidationMessages.GetMessage(
                "اسم الشركة مطلوب",
                "ناوی کۆمپانیا پێویستە"))
            .MaximumLength(200)
            .WithMessage(ValidationMessages.GetMessage(
                "اسم الشركة يجب أن لا يتجاوز 200 حرف",
                "ناوی کۆمپانیا نابێت لە 200 پیت زیاتر بێت"));

        // If CompanyName is provided, then Position is required
        RuleFor(x => x.Position)
            .NotEmpty()
            .WithMessage(ValidationMessages.GetMessage(
                "المنصب مطلوب",
                "پێگە پێویستە"))
            .When(x => !string.IsNullOrEmpty(x.CompanyName));

        RuleFor(x => x.Position)
            .MaximumLength(200)
            .WithMessage(ValidationMessages.GetMessage(
                "المنصب يجب أن لا يتجاوز 200 حرف",
                "پێگە نابێت لە 200 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.Position));

        // If CompanyName is provided, then StartDate is required
        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage(ValidationMessages.GetMessage(
                "تاريخ البدء مطلوب",
                "بەرواری دەستپێکردن پێویستە"))
            .When(x => !string.IsNullOrEmpty(x.CompanyName));

        RuleFor(x => x.StartDate)
            .LessThan(x => x.EndDate)
            .WithMessage(ValidationMessages.GetMessage(
                "تاريخ البدء يجب أن يكون قبل تاريخ الانتهاء",
                "بەرواری دەستپێکردن دەبێت پێش بەرواری کۆتایی بێت"))
            .When(x => x.EndDate != default);

        // EndDate is optional but if provided, must not be in the future
        RuleFor(x => x.EndDate)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage(ValidationMessages.GetMessage(
                "تاريخ الانتهاء يجب أن لا يكون في المستقبل",
                "بەرواری کۆتایی نابێت لە داهاتوودا بێت"))
            .When(x => x.EndDate != default);
    }
}
