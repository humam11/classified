using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.RealEstate;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.RealEstate;

public class HouseAdDtoValidator : AbstractValidator<HouseAdDto>
{
    public HouseAdDtoValidator()
    {
        // Include(new RealEstateAdDtoValidator());

        RuleFor(x => x.Floors)
            .InclusiveBetween((byte)1, (byte)10).WithMessage(ValidationMessages.GetMessage(
                // Floors must be between 1 and 10
                "يجب أن تكون الطوابق بين 1 و 10",
                "نهۆم دەبێت لە نێوان 1 و 10 بێت"));

        RuleFor(x => x.Bedrooms)
            .InclusiveBetween((byte)0, (byte)20).WithMessage(ValidationMessages.GetMessage(
                // Bedrooms must be between 0 and 20
                "يجب أن تكون غرف النوم بين 0 و 20",
                "ژووری نوستن دەبێت لە نێوان 0 و 20 بێت"));

        RuleFor(x => x.Bathrooms)
            .InclusiveBetween((byte)0, (byte)10).WithMessage(ValidationMessages.GetMessage(
                // Bathrooms must be between 0 and 10
                "يجب أن تكون الحمامات بين 0 و 10",
                "ژووری ئاو دەبێت لە نێوان 0 و 10 بێت"));

        RuleFor(x => x.Garage)
            .IsValidEnum();

        RuleFor(x => x.Garden)
            .IsValidEnum();
    }
}
