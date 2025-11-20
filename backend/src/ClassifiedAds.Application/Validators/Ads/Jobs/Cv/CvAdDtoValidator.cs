using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Jobs;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Jobs.Cv;

public class CvAdDtoValidator : AbstractValidator<CvAdDto>
{
    public CvAdDtoValidator()
    {
        // Include base ad validation for updates
        Include(new AdDtoBaseValidator());

        // CV-specific validation (optional when provided)
        RuleFor(x => x.FirstName)
            .MaximumLength(100)
            .WithMessage(ValidationMessages.GetMessage(
                "الاسم الأول يجب أن لا يتجاوز 100 حرف",
                "ناوی یەکەم نابێت لە 100 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.FirstName));

        RuleFor(x => x.LastName)
            .MaximumLength(100)
            .WithMessage(ValidationMessages.GetMessage(
                "اسم العائلة يجب أن لا يتجاوز 100 حرف",
                "ناوی خێزان نابێت لە 100 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.LastName));

        RuleFor(x => x.Gender!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "الجنس غير صالح",
                "ڕەگەز نادروستە"))
            .When(x => x.Gender.HasValue);

        RuleFor(x => x.DateOfBirth)
            .LessThan(DateTime.UtcNow.AddYears(-16))
            .WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون العمر 16 سنة على الأقل",
                "تەمەن دەبێت لانیکەم 16 ساڵ بێت"))
            .GreaterThan(DateTime.UtcNow.AddYears(-100))
            .WithMessage(ValidationMessages.GetMessage(
                "تاريخ الميلاد غير صالح",
                "بەرواری لەدایکبوون نادروستە"))
            .When(x => x.DateOfBirth.HasValue);

        RuleFor(x => x.PhoneNumber)
            .Matches(@"^[\d\s\+\-\(\)]+$")
            .WithMessage(ValidationMessages.GetMessage(
                "رقم الهاتف غير صالح",
                "ژمارەی تەلەفۆن نادروستە"))
            .MaximumLength(20)
            .WithMessage(ValidationMessages.GetMessage(
                "رقم الهاتف يجب أن لا يتجاوز 20 حرف",
                "ژمارەی تەلەفۆن نابێت لە 20 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.PhoneNumber));

        RuleFor(x => x.ContactEmail)
            .EmailAddress()
            .WithMessage(ValidationMessages.GetMessage(
                "البريد الإلكتروني غير صالح",
                "ئیمەیڵ نادروستە"))
            .MaximumLength(200)
            .WithMessage(ValidationMessages.GetMessage(
                "البريد الإلكتروني يجب أن لا يتجاوز 200 حرف",
                "ئیمەیڵ نابێت لە 200 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.ContactEmail));

        RuleFor(x => x.JobSearchStatus!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "حالة البحث عن عمل غير صالحة",
                "دۆخی گەڕان بەدوای کار نادروستە"))
            .When(x => x.JobSearchStatus.HasValue);

        // Validate nested collections
        RuleForEach(x => x.Education)
            .SetValidator(new EducationDtoValidator())
            .When(x => x.Education != null);

        RuleForEach(x => x.Experience)
            .SetValidator(new ExperienceDtoValidator())
            .When(x => x.Experience != null);

        RuleForEach(x => x.Languages)
            .SetValidator(new LanguageDtoValidator())
            .When(x => x.Languages != null);
    }
}

public class CreateCvAdDtoValidator : AbstractValidator<CreateCvAdDto>
{
    public CreateCvAdDtoValidator()
    {
        // Include CV-specific validation
        Include(new CvAdDtoValidator());

        // Apply standard create rules (includes Title, IsDollar, PriceValue, City, ImageFiles)
        this.ApplyCreateRules();

        // Street must be empty for CV
        RuleFor(x => x.Street)
            .Empty()
            .WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون الشارع فارغًا للسيرة الذاتية",
                "شەقام دەبێت بەتاڵ بێت بۆ سی ڤی"));

        // Required CV-specific fields
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage(ValidationMessages.GetMessage(
                "الاسم الأول مطلوب",
                "ناوی یەکەم پێویستە"));

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage(ValidationMessages.GetMessage(
                "اسم العائلة مطلوب",
                "ناوی خێزان پێویستە"));

        RuleFor(x => x.Gender)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "الجنس مطلوب",
                "ڕەگەز پێویستە"));

        RuleFor(x => x.DateOfBirth)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "تاريخ الميلاد مطلوب",
                "بەرواری لەدایکبوون پێویستە"));

        // At least one contact method is required (PhoneNumber OR ContactEmail)
        RuleFor(x => x)
            .Must(x => !string.IsNullOrEmpty(x.PhoneNumber) || !string.IsNullOrEmpty(x.ContactEmail))
            .WithMessage(ValidationMessages.GetMessage(
                "يجب توفير رقم الهاتف أو البريد الإلكتروني على الأقل",
                "لانیکەم ژمارەی تەلەفۆن یان ئیمەیڵ دەبێت دابین بکرێت"));

        RuleFor(x => x.JobSearchStatus)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "حالة البحث عن عمل مطلوبة",
                "دۆخی گەڕان بەدوای کار پێویستە"));
    }
}
