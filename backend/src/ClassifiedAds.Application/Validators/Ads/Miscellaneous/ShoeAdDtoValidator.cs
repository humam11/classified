using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Miscellaneous;

public class ShoeAdDtoValidator : AbstractValidator<ShoeAdDto>
{
    public ShoeAdDtoValidator()
    {
        // Include(new CreateAdLocalPriceOnlyValidator());

        RuleFor(x => x.IsNew)
            .IsValidEnum();

        RuleFor(x => x.Size)
            .InclusiveBetween((byte)15, (byte)70).WithMessage(ValidationMessages.GetMessage(
                // Shoe size must be between 15 and 70
                "يجب أن يكون مقاس الحذاء بين 15 و 70",
                "قەبارەی پێڵاو دەبێت لە نێوان 15 و 70 بێت"));
    }
}
