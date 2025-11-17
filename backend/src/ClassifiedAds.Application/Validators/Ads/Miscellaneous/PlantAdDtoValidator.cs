using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Miscellaneous;

public class PlantAdDtoValidator : AbstractValidator<PlantAdDto>
{
    public PlantAdDtoValidator()
    {
        // Include(new CreateAdLocalPriceOnlyValidator());

        RuleFor(x => x.Height)
            .InclusiveBetween((ushort)1, (ushort)2000).WithMessage(ValidationMessages.GetMessage(
                // Height must be between 1 and 2000
                "يجب أن يكون الارتفاع بين 1 و 2000",
                "بەرزی دەبێت لە نێوان 1 و 2000 بێت"));

        RuleFor(x => x.PlantType)
            .IsValidEnum();
    }
}
