using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles.HeavyEquipment;

public class HeavyEquipmentAdDtoValidator : AbstractValidator<HeavyEquipmentAdDto>
{
    public HeavyEquipmentAdDtoValidator()
    {
        Include(new TransportAdDtoValidator());

        RuleFor(x => x.OperatingMass)
            .InclusiveBetween(0.1f, 100000f).WithMessage(ValidationMessages.GetMessage(
                // Operating mass must be between 0.1 and 100000
                "يجب أن تكون الكتلة التشغيلية بين 0.1 و 100000",
                "بارستەی کارکردن دەبێت لە نێوان 0.1 و 100000 بێت"));

        RuleFor(x => x.Weight)
            .InclusiveBetween(0.1f, 200f).WithMessage(ValidationMessages.GetMessage(
                // Weight must be between 0.1 and 200
                "يجب أن يكون الوزن بين 0.1 و 200",
                "کێش دەبێت لە نێوان 0.1 و 200 بێت"));
    }
}
