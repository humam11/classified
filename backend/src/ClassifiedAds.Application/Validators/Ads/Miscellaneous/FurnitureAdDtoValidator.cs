using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Miscellaneous;

public class FurnitureAdDtoValidator : AbstractValidator<FurnitureAdDto>
{
    public FurnitureAdDtoValidator()
    {
        // Include(new CreateAdLocalPriceOnlyValidator());

        RuleFor(x => x.FurnitureMaterial)
            .IsValidEnum();

        RuleFor(x => x.Length)
            .InclusiveBetween((ushort)1, (ushort)1000).WithMessage(ValidationMessages.GetMessage(
                // Length must be between 1 and 1000
                "يجب أن يكون الطول بين 1 و 1000",
                "درێژی دەبێت لە نێوان 1 و 1000 بێت"));

        RuleFor(x => x.Width)
            .InclusiveBetween((ushort)1, (ushort)1000).WithMessage(ValidationMessages.GetMessage(
                // Width must be between 1 and 1000
                "يجب أن يكون العرض بين 1 و 1000",
                "پانی دەبێت لە نێوان 1 و 1000 بێت"));

        RuleFor(x => x.Height)
            .InclusiveBetween((ushort)1, (ushort)500).WithMessage(ValidationMessages.GetMessage(
                // Height must be between 1 and 500
                "يجب أن يكون الارتفاع بين 1 و 500",
                "بەرزی دەبێت لە نێوان 1 و 500 بێت"));
    }
}
