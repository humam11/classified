using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Jobs;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Jobs;

/// <summary>
/// CV can have IsDollar = true or false
/// Street must be null for privacy protection
/// </summary>
public class CreateCvAdDtoValidator : AbstractValidator<CreateCvAdDto>
{
    public CreateCvAdDtoValidator()
    {
        Include(new CreateAdDtoValidator()); // Can be IQD or USD

        // Street should not be provided for CV ads
        RuleFor(x => x.Street)
            .Empty().WithMessage(GetMessage(
                // Street should not be provided for CV
                "يجب أن يكون الشارع فارغًا للسيرة الذاتية",
                "شەقام دەبێت بەتاڵ بێت بۆ سی ڤی"))
            .When(x => !string.IsNullOrEmpty(x.Street));

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage(GetMessage(
                // First name is required
                "الاسم الأول مطلوب",
                "ناوی یەکەم پێویستە"))
            .MaximumLength(50).WithMessage(GetMessage(
                // First name must not exceed 50 characters
                "يجب ألا يتجاوز الاسم الأول 50 حرفًا",
                "ناوی یەکەم نابێت لە 50 پیت زیاتر بێت"));

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage(GetMessage(
                // Last name is required
                "اسم العائلة مطلوب",
                "ناوی کۆتایی پێویستە"))
            .MaximumLength(50).WithMessage(GetMessage(
                // Last name must not exceed 50 characters
                "يجب ألا يتجاوز اسم العائلة 50 حرفًا",
                "ناوی کۆتایی نابێت لە 50 پیت زیاتر بێت"));

        RuleFor(x => x.Gender)
            .IsValidEnum();

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage(GetMessage(
                // Date of birth is required
                "تاريخ الميلاد مطلوب",
                "بەرواری لەدایکبوون پێویستە"))
            .LessThan(DateTime.UtcNow).WithMessage(GetMessage(
                // Date of birth must be in the past
                "يجب أن يكون تاريخ الميلاد في الماضي",
                "بەرواری لەدایکبوون دەبێت لە ڕابردوو بێت"));

        RuleFor(x => x.PhoneNumber)
            .MaximumLength(20).WithMessage(GetMessage(
                // Phone number must not exceed 20 characters
                "يجب ألا يتجاوز رقم الهاتف 20 حرفًا",
                "ژمارەی تەلەفۆن نابێت لە 20 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.PhoneNumber));

        RuleFor(x => x.ContactEmail)
            .EmailAddress().WithMessage(GetMessage(
                // Invalid email format
                "تنسيق البريد الإلكتروني غير صالح",
                "شێوازی ئیمەیڵ نادروستە"))
            .MaximumLength(100).WithMessage(GetMessage(
                // Email must not exceed 100 characters
                "يجب ألا يتجاوز البريد الإلكتروني 100 حرفًا",
                "ئیمەیڵ نابێت لە 100 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.ContactEmail));

        RuleFor(x => x)
            .Must(x => !string.IsNullOrEmpty(x.PhoneNumber) || !string.IsNullOrEmpty(x.ContactEmail))
            .WithMessage(GetMessage(
                // Either phone number or contact email must be provided
                "يجب توفير رقم الهاتف أو البريد الإلكتروني",
                "دەبێت ژمارەی تەلەفۆن یان ئیمەیڵ دابین بکرێت"));

        RuleFor(x => x.JobSearchStatus)
            .IsValidEnum();
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
