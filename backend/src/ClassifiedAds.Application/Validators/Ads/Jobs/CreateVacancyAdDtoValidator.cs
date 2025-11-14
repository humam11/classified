using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Jobs;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Jobs;

/// <summary>
/// Vacancy can have IsDollar = true or false
/// </summary>
public class CreateVacancyAdDtoValidator : AbstractValidator<CreateVacancyAdDto>
{
    public CreateVacancyAdDtoValidator()
    {
        Include(new CreateAdDtoValidator()); // Can be IQD or USD

        RuleFor(x => x.JobType)
            .IsValidEnum();

        RuleFor(x => x.ExperienceYears)
            .GreaterThanOrEqualTo((byte)0).WithMessage(GetMessage(
                // Experience years must be 0 or greater
                "يجب أن تكون سنوات الخبرة 0 أو أكثر",
                "ساڵانی ئەزموون دەبێت 0 یان زیاتر بێت"));

        RuleFor(x => x.EducationLevel)
            .IsValidEnum();

        RuleFor(x => x.WorkingHours)
            .IsValidEnum();

        RuleFor(x => x.Max)
            .GreaterThan(0).WithMessage(GetMessage(
                // Maximum salary must be greater than 0
                "يجب أن يكون الحد الأقصى للراتب أكبر من 0",
                "زۆرترین مووچە دەبێت لە 0 زیاتر بێت"));

        RuleFor(x => x.PaymentPeriod)
            .IsValidEnum();
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
