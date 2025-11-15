using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Common;

public class LocationAdDtoValidator : AbstractValidator<LocationAdDto>
{
    public LocationAdDtoValidator()
    {
        // City is required
        RuleFor(x => x.City)
            .NotEmpty()
            .WithMessage(GetMessage(
                "المدينة مطلوبة",
                "شار پێویستە"))
            .MaximumLength(50)
            .WithMessage(GetMessage(
                "يجب ألا تتجاوز المدينة 50 حرفًا",
                "شار نابێت لە 50 پیت زیاتر بێت"));

        // Region is optional
        RuleFor(x => x.Region)
            .MaximumLength(50)
            .When(x => !string.IsNullOrEmpty(x.Region))
            .WithMessage(GetMessage(
                "يجب ألا تتجاوز المنطقة 50 حرفًا",
                "ناوچە نابێت لە 50 پیت زیاتر بێت"));

        // Neighborhood is optional
        RuleFor(x => x.Neighborhood)
            .MaximumLength(50)
            .When(x => !string.IsNullOrEmpty(x.Neighborhood))
            .WithMessage(GetMessage(
                "يجب ألا يتجاوز الحي 50 حرفًا",
                "گەڕەک نابێت لە 50 پیت زیاتر بێت"));

        // Street is optional
        RuleFor(x => x.Street)
            .MaximumLength(100)
            .When(x => !string.IsNullOrEmpty(x.Street))
            .WithMessage(GetMessage(
                "يجب ألا يتجاوز الشارع 100 حرفًا",
                "شەقام نابێت لە 100 پیت زیاتر بێت"));
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}

public class LocationAdNoStreetValidator : AbstractValidator<LocationAdDto>
{
    public LocationAdNoStreetValidator()
    {
        Include(new LocationAdDtoValidator());

        RuleFor(x => x.Street)
            .Empty()
            .WithMessage(GetMessage(
                // Street must be empty for CV
                "يجب أن يكون الشارع فارغًا للسيرة الذاتية",
                "شەقام دەبێت بەتاڵ بێت بۆ سی ڤی"));
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
