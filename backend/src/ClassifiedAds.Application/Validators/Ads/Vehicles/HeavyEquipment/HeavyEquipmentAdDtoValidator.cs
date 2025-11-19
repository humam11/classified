using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Ads.Vehicles;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles.HeavyEquipment;

public class HeavyEquipmentAdDtoValidator : AbstractValidator<HeavyEquipmentAdDto>
{
    public HeavyEquipmentAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new TransportAdDtoValidator());

        RuleFor(x => x.OperatingMass)
            .InclusiveBetween(0.1f, 100000f).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون الكتلة التشغيلية بين 0.1 و 100000",
                "بارستەی کارکردن دەبێت لە نێوان 0.1 و 100000 بێت"))
            .When(x => x.OperatingMass.HasValue);

        RuleFor(x => x.Weight)
            .InclusiveBetween(0.1f, 200f).WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون الوزن بين 0.1 و 200",
                "کێش دەبێت لە نێوان 0.1 و 200 بێت"))
            .When(x => x.Weight.HasValue);
    }
}

public class CreateHeavyEquipmentAdDtoValidator : AbstractValidator<CreateHeavyEquipmentAdDto>
{
    public CreateHeavyEquipmentAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new TransportAdDtoValidator());
        Include(new HeavyEquipmentAdDtoValidator());

        this.ApplyCreateRules(); // HeavyEquipment can be IQD or USD
    }
}
