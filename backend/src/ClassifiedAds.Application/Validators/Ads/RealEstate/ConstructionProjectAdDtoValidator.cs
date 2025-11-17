using ClassifiedAds.Application.DTOs.Ads.RealEstate;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.RealEstate;

public class ConstructionProjectAdDtoValidator : AbstractValidator<ConstructionProjectAdDto>
{
    public ConstructionProjectAdDtoValidator()
    {
        // Include(new RealEstateAdDtoValidator());

        RuleFor(x => x.CompletionStatus)
            .IsValidEnum();
    }
}
