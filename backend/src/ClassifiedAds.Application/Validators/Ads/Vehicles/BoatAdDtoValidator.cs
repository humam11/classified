using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles;

public class BoatAdDtoValidator : AbstractValidator<BoatAdDto>
{
    public BoatAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new TransportAdDtoValidator());

        RuleFor(x => x.Length)
            .InclusiveBetween(0.1f, 100f).WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون الطول بين 0.1 و 100",
                "درێژی دەبێت لە نێوان 0.1 و 100 بێت"))
            .When(x => x.Length.HasValue);

        RuleFor(x => x.Capacity)
            .InclusiveBetween((byte)1, (byte)100).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون السعة بين 1 و 100",
                "قەبارە دەبێت لە نێوان 1 و 100 بێت"))
            .When(x => x.Capacity.HasValue);
    }
}

public class CreateBoatAdDtoValidator : AbstractValidator<CreateBoatAdDto>
{
    public CreateBoatAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new TransportAdDtoValidator());
        Include(new BoatAdDtoValidator());

        this.ApplyCreateLocalPriceRules(); // Boat is local currency only
    }
}
