using ClassifiedAds.Application.DTOs.Ads.RealEstate;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.RealEstate;

public class CreateConstructionProjectAdDtoValidator : AbstractValidator<CreateConstructionProjectAdDto>
{
    public CreateConstructionProjectAdDtoValidator()
    {
        Include(new CreateRealEstateAdDtoValidator());

        RuleFor(x => x.CompletionStatus)
            .IsValidEnum();
    }
}
