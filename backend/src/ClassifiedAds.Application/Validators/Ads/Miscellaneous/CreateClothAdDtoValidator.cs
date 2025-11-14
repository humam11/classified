using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Miscellaneous;

public class CreateClothAdDtoValidator : AbstractValidator<CreateClothAdDto>
{
    public CreateClothAdDtoValidator()
    {
        Include(new CreateAdLocalPriceOnlyValidator());

        RuleFor(x => x.ClothCondition)
            .IsValidEnum();

        RuleFor(x => x.ClothingSize)
            .IsValidEnum();

        RuleFor(x => x.Season)
            .IsValidEnum();
    }
}
