using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Ads.Vehicles;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles.HeavyEquipment;

public class BusAdDtoValidator : AbstractValidator<BusAdDto>
{
    public BusAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new TransportAdDtoValidator());
        Include(new HeavyEquipmentAdDtoValidator());

        RuleFor(x => x.SeatingCapacity)
            .InclusiveBetween((byte)1, (byte)200).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون سعة المقاعد بين 1 و 200",
                "قەبارەی دانیشتن دەبێت لە نێوان 1 و 200 بێت"))
            .When(x => x.SeatingCapacity.HasValue);
    }
}

public class CreateBusAdDtoValidator : AbstractValidator<CreateBusAdDto>
{
    public CreateBusAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new TransportAdDtoValidator());
        Include(new HeavyEquipmentAdDtoValidator());
        Include(new BusAdDtoValidator());

        this.ApplyCreateRules(); // Bus can be IQD or USD
    }
}
