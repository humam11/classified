using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.RealEstate;
using ClassifiedAds.Application.Validators.Ads;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.RealEstate;

public class RealEstateAdDtoValidator : AbstractValidator<RealEstateAdDto>
{
    public RealEstateAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());

        RuleFor(x => x.Area)
            .GreaterThan(0).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون المساحة أكبر من 0",
                "ڕووبەر دەبێت لە 0 زیاتر بێت"))
            .When(x => x.Area.HasValue);
    }
}

public class CreateRealEstateAdDtoValidator : AbstractValidator<CreateRealEstateAdDto>
{
    public CreateRealEstateAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new RealEstateAdDtoValidator());

        this.ApplyCreateLocalPriceRules();
    }
}
