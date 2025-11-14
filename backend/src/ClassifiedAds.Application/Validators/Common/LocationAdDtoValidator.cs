using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Common;

/// <summary>
/// Base validator for LocationDto - validates common location properties
/// </summary>
public class LocationAdDtoValidator : AbstractValidator<LocationAdDto>
{
    public LocationAdDtoValidator()
    {

        RuleFor(x => x.LocationIds)
            .NotNull()
            .WithMessage("Location IDs are required")
            .Must(ids => ids != null && ids.Count > 0)
            .WithMessage("At least one location ID is required");

        //RuleFor(x => x.FullAddressArabic)
        //    .MaximumLength(200)
        //    .When(x => !string.IsNullOrEmpty(x.FullAddressArabic))
        //    .WithMessage("Full address (Arabic) must not exceed 200 characters");

        //RuleFor(x => x.FullAddressKurdish)
        //    .MaximumLength(200)
        //    .When(x => !string.IsNullOrEmpty(x.FullAddressKurdish))
        //    .WithMessage("Full address (Kurdish) must not exceed 200 characters");

        RuleFor(x => x.Street)
            .MaximumLength(100)
            .When(x => !string.IsNullOrEmpty(x.Street))
            .WithMessage(GetMessage(
                // Street must not exceed 100 characters
                "يجب ألا يتجاوز الشارع 100 حرفًا",
                "شەقام نابێت لە 100 پیت زیاتر بێت"));
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}

/// <summary>
/// Validator for locations where Street must be null
/// Used for: CV
/// </summary>
public class LocationAdNoStreetValidator : AbstractValidator<LocationAdDto>
{
    public LocationAdNoStreetValidator()
    {
        Include(new LocationAdDtoValidator());

        RuleFor(x => x.Street)
            .Null()
            .WithMessage(GetMessage(
                // Street must be null for CV
                "يجب أن يكون الشارع فارغًا للسيرة الذاتية",
                "شەقام دەبێت بەتاڵ بێت بۆ سی ڤی"));
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
