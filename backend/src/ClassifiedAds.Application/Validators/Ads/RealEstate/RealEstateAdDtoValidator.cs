using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.RealEstate;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.RealEstate;

public class RealEstateAdDtoValidator : AbstractValidator<RealEstateAdDto>
{
    public RealEstateAdDtoValidator()
    {
        // Include(new CreateAdLocalPriceOnlyValidator());

        RuleFor(x => x.Area)
            .GreaterThan(0).WithMessage(ValidationMessages.GetMessage(
                // Area must be greater than 0
                "يجب أن تكون المساحة أكبر من 0",
                "ڕووبەر دەبێت لە 0 زیاتر بێت"));
    }
}
