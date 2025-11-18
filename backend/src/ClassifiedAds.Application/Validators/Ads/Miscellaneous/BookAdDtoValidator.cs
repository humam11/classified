using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Ads.Vehicles;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Miscellaneous;


public class BookAdDtoValidator : AbstractValidator<BookAdDto>
{
    public BookAdDtoValidator()
    {
        // Include base ad validation for updates
        Include(new AdDtoBaseValidator());

        // Book-specific validation (optional)
        RuleFor(x => x.BookLanguage!.Value)
            .IsValidEnum()
            .When(x => x.BookLanguage.HasValue);

        RuleFor(x => x.Pages!.Value)
            .InclusiveBetween((ushort)1, (ushort)2000)
            .WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون الصفحات بين 1 و 2000",
                "پەڕە دەبێت لە نێوان 1 و 2000 بێت"))
            .When(x => x.Pages.HasValue);
    }
}

public class CreateBookAdDtoValidator : AbstractValidator<CreateBookAdDto>
{
    public CreateBookAdDtoValidator()
    {
        // Include base ad validation
        Include(new BookAdDtoValidator());s

        // Apply all required field rules (local currency only)
        this.ApplyCreateLocalPriceRules();
    }
}