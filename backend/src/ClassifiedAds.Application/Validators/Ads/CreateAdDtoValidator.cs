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

        RuleFor(x => x.Price)
            .NotNull().WithMessage(GetMessage(
                // Price is required
                "السعر مطلوب",
                "نرخ پێویستە"))
            .SetValidator(new PriceDtoValidator());

        //RuleFor(x => x.Status)
        //    .IsValidEnum();

        RuleFor(x => x.Category)
            .NotNull().WithMessage("Category is required")
            .SetValidator(new CategoryDtoValidator());

        RuleFor(x => x.LocationAd)
            .NotNull().WithMessage(GetMessage(
                // Location is required
                "الموقع مطلوب",
                "شوێن پێویستە"))
            .SetValidator(new LocationAdDtoValidator());

        RuleFor(x => x.Images)
            .NotNull().WithMessage(GetMessage(
                // Images are required
                "الصور مطلوبة",
                "وێنەکان پێویستە"))
            .Must(images => images != null && images.Count > 0)
            .WithMessage(GetMessage(
                // At least one image is required
                "مطلوب صورة واحدة على الأقل",
                "لانیکەم یەک وێنە پێویستە"))
            .Must(images => images == null || images.Count <= 5)
            .WithMessage(GetMessage(
                // Maximum 5 images allowed
                "الحد الأقصى 5 صور مسموح",
                "زۆرترین 5 وێنە ڕێگەپێدراوە"));

        RuleForEach(x => x.Images)
            .SetValidator(new AdImageDtoValidator());
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
        RuleFor(x => x.Price)
            .NotNull().WithMessage(GetMessage(
                // Price is required
                "السعر مطلوب",
                "نرخ پێویستە"))
            .SetValidator(new PriceLocalOnlyValidator());
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
