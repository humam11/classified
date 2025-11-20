using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Jobs;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Jobs;

public class VacancyAdDtoValidator : AbstractValidator<VacancyAdDto>
{
    public VacancyAdDtoValidator()
    {
        // Include base ad validation for updates
        Include(new AdDtoBaseValidator());

        // Vacancy-specific validation (optional when provided)
        RuleFor(x => x.JobType!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "نوع الوظيفة غير صالح",
                "جۆری کار نادروستە"))
            .When(x => x.JobType.HasValue);

        RuleFor(x => x.ExperienceYears)
            .GreaterThanOrEqualTo((byte)0)
            .WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون سنوات الخبرة 0 أو أكثر",
                "ساڵانی ئەزموون دەبێت 0 یان زیاتر بێت"))
            .When(x => x.ExperienceYears.HasValue);

        RuleFor(x => x.EducationLevel!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "المستوى التعليمي غير صالح",
                "ئاستی پەروەردە نادروستە"))
            .When(x => x.EducationLevel.HasValue);

        RuleFor(x => x.WorkingHours!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "ساعات العمل غير صالحة",
                "کاتژمێرەکانی کار نادروستە"))
            .When(x => x.WorkingHours.HasValue);

        RuleFor(x => x.Max)
            .GreaterThan(0)
            .WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون الحد الأقصى للراتب أكبر من 0",
                "زۆرترین مووچە دەبێت لە 0 زیاتر بێت"))
            .When(x => x.Max.HasValue);

        RuleFor(x => x.PaymentPeriod!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "طريقة الدفع غير صالحة",
                "شێوازی پارەدان نادروستە"))
            .When(x => x.PaymentPeriod.HasValue);
    }
}

public class CreateVacancyAdDtoValidator : AbstractValidator<CreateVacancyAdDto>
{
    public CreateVacancyAdDtoValidator()
    {
        // Include base ad validation
        Include(new AdDtoBaseValidator());

        // Include vacancy-specific validation
        Include(new VacancyAdDtoValidator());

        // Required fields for creation
        RuleFor(x => x.JobType)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "نوع الوظيفة مطلوب",
                "جۆری کار پێویستە"));

        RuleFor(x => x.EducationLevel)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "المستوى التعليمي مطلوب",
                "ئاستی پەروەردە پێویستە"));

        RuleFor(x => x.WorkingHours)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "ساعات العمل مطلوبة",
                "کاتژمێرەکانی کار پێویستە"));


        RuleFor(x => x.PaymentPeriod)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "طريقة الدفع مطلوبة",
                "شێوازی پارەدان پێویستە"));

        // Apply all required field rules (can be IQD or USD)
        this.ApplyCreateRules();
    }
}
