using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads;

public static class ValidationMessages
{
    public static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}

// Shared validation rules for ad creation
public static class AdValidationRules
{
    // Apply required field rules (any currency)
    public static void ApplyCreateRules<T>(this AbstractValidator<T> validator) where T : AdDto
    {
        validator.RuleFor(x => x.Title)
            .NotEmpty().WithMessage(ValidationMessages.GetMessage(
                "العنوان مطلوب",
                "ناونیشان پێویستە"));

        validator.RuleFor(x => x.IsDollar)
            .NotNull().WithMessage(ValidationMessages.GetMessage(
                "نوع العملة مطلوب",
                "جۆری دراو پێویستە"));

        validator.RuleFor(x => x.PriceValue)
            .NotNull().WithMessage(ValidationMessages.GetMessage(
                "السعر مطلوب",
                "نرخ پێویستە"));

        validator.RuleFor(x => x.City)
            .NotEmpty().WithMessage(ValidationMessages.GetMessage(
                "المدينة مطلوبة",
                "شار پێویستە"));

        validator.RuleFor(x => x.ImageFiles)
            .NotEmpty().WithMessage(ValidationMessages.GetMessage(
                "صورة واحدة على الأقل مطلوبة",
                "لانیکەم یەک وێنە پێویستە"));
    }

    // Apply required field rules (IQD only)
    public static void ApplyCreateLocalPriceRules<T>(this AbstractValidator<T> validator) where T : AdDto
    {
        validator.RuleFor(x => x.Title)
            .NotEmpty().WithMessage(ValidationMessages.GetMessage(
                "العنوان مطلوب",
                "ناونیشان پێویستە"));

        validator.RuleFor(x => x.IsDollar)
            .NotNull().WithMessage(ValidationMessages.GetMessage(
                "نوع العملة مطلوب",
                "جۆری دراو پێویستە"))
            .Equal(false).WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون السعر بالعملة المحلية (دينار عراقي) فقط",
                "نرخ دەبێت بە دراوی ناوخۆیی (دیناری عێراقی) بێت تەنها"));

        validator.RuleFor(x => x.PriceValue)
            .NotNull().WithMessage(ValidationMessages.GetMessage(
                "السعر مطلوب",
                "نرخ پێویستە"));

        validator.RuleFor(x => x.City)
            .NotEmpty().WithMessage(ValidationMessages.GetMessage(
                "المدينة مطلوبة",
                "شار پێویستە"));

        validator.RuleFor(x => x.ImageFiles)
            .NotEmpty().WithMessage(ValidationMessages.GetMessage(
                "صورة واحدة على الأقل مطلوبة",
                "لانیکەم یەک وێنە پێویستە"));
    }
}

// Base validator for AdDto (used for both create and update)
public class AdDtoBaseValidator : AbstractValidator<AdDto>
{
    public AdDtoBaseValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(ValidationMessages.GetMessage(
                "العنوان لا يمكن أن يكون فارغًا",
                "ناونیشان ناتوانێت بەتاڵ بێت"))
            .MaximumLength(100).WithMessage(ValidationMessages.GetMessage(
                "يجب ألا يتجاوز العنوان 100 حرفًا",
                "ناونیشان نابێت لە 100 پیت زیاتر بێت"))
            .When(x => x.Title != null);

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage(ValidationMessages.GetMessage(
                "يجب ألا يتجاوز الوصف 1000 حرفًا",
                "وەسف نابێت لە 1000 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.Description));

        RuleFor(x => x.PriceValue)
            .GreaterThan(0).WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون السعر أكبر من الصفر",
                "نرخ دەبێت لە سفر زیاتر بێت"))
            .When(x => x.PriceValue.HasValue);

        // Update-specific: PriceValue required when IsDollar changes
        RuleFor(x => x.PriceValue)
            .NotNull().WithMessage(ValidationMessages.GetMessage(
                "يجب إعادة تحديد قيمة السعر عند تغيير نوع العملة",
                "دەبێت نرخ دووبارە دیاری بکرێت کاتێک جۆری دراو دەگۆڕێت"))
            .When(x => x.IsDollar.HasValue);

        RuleFor(x => x.City)
            .MaximumLength(100).WithMessage(ValidationMessages.GetMessage(
                "يجب ألا تتجاوز المدينة 100 حرفًا",
                "شار نابێت لە 100 پیت زیاتر بێت"))
            .When(x => !string.IsNullOrEmpty(x.City));

        RuleFor(x => x.ImageFiles)
            .Must(images => images != null && images.Count >= 1 && images.Count <= 5)
            .WithMessage(ValidationMessages.GetMessage(
                "يجب تحميل من 1 إلى 5 صور",
                "دەبێت لە 1 بۆ 5 وێنە بار بکرێت"))
            .When(x => x.ImageFiles != null);
    }
}

public class CreateAdDtoValidator : AbstractValidator<CreateAdDto>
{
    public CreateAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        this.ApplyCreateRules();
    }
}

// For RealEstate, Service, and Miscellaneous (except VideoGame)
public class CreateAdLocalPriceOnlyValidator : AbstractValidator<CreateAdDto>
{
    public CreateAdLocalPriceOnlyValidator()
    {
        Include(new AdDtoBaseValidator());
        this.ApplyCreateLocalPriceRules();
    }
}



///// need to be edit
//public class LocationAdNoStreetValidator : AbstractValidator<LocationAdDto>
//{
//    public LocationAdNoStreetValidator()
//    {
//        Include(new LocationAdDtoValidator());

//        RuleFor(x => x.Street)
//            .Empty()
//            .WithMessage(GetMessage(
//                // Street must be empty for CV
//                "يجب أن يكون الشارع فارغًا للسيرة الذاتية",
//                "شەقام دەبێت بەتاڵ بێت بۆ سی ڤی"));
//    }

//    private static string GetMessage(string ar, string kr)
//    {
//        return LanguageContext.Current == "ar" ? ar : kr;
//    }
//}

