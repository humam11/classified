using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads;

/// <summary>
/// Base validator for all CreateAdDto types with common validation rules
/// </summary>
public class CreateAdDtoValidator : AbstractValidator<CreateAdDto>
{
    public CreateAdDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(GetMessage(
                // Title is required
                "العنوان مطلوب",
                "ناونیشان پێویستە"))
            .MaximumLength(100).WithMessage(GetMessage(
                // Title must not exceed 100 characters
                "يجب ألا يتجاوز العنوان 100 حرفًا",
                "ناونیشان نابێت لە 100 پیت زیاتر بێت"));

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage(GetMessage(
                // Description must not exceed 1000 characters
                "يجب ألا يتجاوز الوصف 1000 حرفًا",
                "وەسف نابێت لە 1000 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.Description));

        // Price validation (flat fields)
        RuleFor(x => x.PriceValue)
            .GreaterThan(0).WithMessage(GetMessage(
                // Price must be greater than zero
                "يجب أن يكون السعر أكبر من الصفر",
                "نرخ دەبێت لە سفر زیاتر بێت"));

        // Location validation (flat fields)
        RuleFor(x => x.City)
            .NotEmpty().WithMessage(GetMessage(
                // City is required
                "المدينة مطلوبة",
                "شار پێویستە"))
            .MaximumLength(100).WithMessage(GetMessage(
                // City must not exceed 100 characters
                "يجب ألا تتجاوز المدينة 100 حرفًا",
                "شار نابێت لە 100 پیت زیاتر بێت"));

        // Images validation (for multipart uploads)
        RuleFor(x => x.ImageFiles)
            .NotEmpty().WithMessage(GetMessage(
                // At least one image is required
                "صورة واحدة على الأقل مطلوبة",
                "لانیکەم یەک وێنە پێویستە"))
            .Must(images => images != null && images.Count >= 1 && images.Count <= 5)
            .WithMessage(GetMessage(
                // Between 1 and 5 images are required
                "يجب تحميل من 1 إلى 5 صور",
                "دەبێت لە 1 بۆ 5 وێنە بار بکرێت"));
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}

/// <summary>
/// Validator for ads that must have price in local currency only (IQD)
/// Used for: RealEstate, Service, and Miscellaneous (except VideoGame)
/// </summary>
public class CreateAdLocalPriceOnlyValidator : AbstractValidator<CreateAdDto>
{
    public CreateAdLocalPriceOnlyValidator()
    {
        Include(new CreateAdDtoValidator());

        // Override price validator to enforce local currency only
        RuleFor(x => x.PriceIsDollar)
            .Equal(false).WithMessage(GetMessage(
                // Price must be in local currency (IQD) only
                "يجب أن يكون السعر بالعملة المحلية (دينار عراقي) فقط",
                "نرخ دەبێت بە دراوی ناوخۆیی (دیناری عێراقی) بێت تەنها"));
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
