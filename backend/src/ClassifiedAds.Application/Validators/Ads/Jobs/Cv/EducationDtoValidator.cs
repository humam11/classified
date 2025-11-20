using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Jobs;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Jobs.Cv;

public class EducationDtoValidator : AbstractValidator<EducationDto>
{
    public EducationDtoValidator()
    {
        RuleFor(x => x.InstitutionName)
            .NotEmpty()
            .WithMessage(ValidationMessages.GetMessage(
                "اسم المؤسسة التعليمية مطلوب",
                "ناوی دامەزراوەی پەروەردە پێویستە"))
            .MaximumLength(200)
            .WithMessage(ValidationMessages.GetMessage(
                "اسم المؤسسة التعليمية يجب أن لا يتجاوز 200 حرف",
                "ناوی دامەزراوەی پەروەردە نابێت لە 200 پیت زیاتر بێت"));

        // If InstitutionName is provided, then EducationDegree is required
        RuleFor(x => x.EducationDegree)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "الدرجة العلمية مطلوبة",
                "بڕوانامەی زانستی پێویستە"))
            .When(x => !string.IsNullOrEmpty(x.InstitutionName));

        RuleFor(x => x.EducationDegree)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "الدرجة العلمية غير صالحة",
                "بڕوانامەی زانستی نادروستە"));

        // If InstitutionName is provided, then Specialization is required
        RuleFor(x => x.Specialization)
            .NotEmpty()
            .WithMessage(ValidationMessages.GetMessage(
                "التخصص مطلوب",
                "پسپۆڕی پێویستە"))
            .When(x => !string.IsNullOrEmpty(x.InstitutionName));

        RuleFor(x => x.Specialization)
            .MaximumLength(200)
            .WithMessage(ValidationMessages.GetMessage(
                "التخصص يجب أن لا يتجاوز 200 حرف",
                "پسپۆڕی نابێت لە 200 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.Specialization));

        // If InstitutionName is provided, then StartDate is required
        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage(ValidationMessages.GetMessage(
                "تاريخ البدء مطلوب",
                "بەرواری دەستپێکردن پێویستە"))
            .When(x => !string.IsNullOrEmpty(x.InstitutionName));

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
