using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles.HeavyEquipment;

public class BusAdDtoValidator : AbstractValidator<BusAdDto>
{
    public BusAdDtoValidator()
    {
        Include(new HeavyEquipmentAdDtoValidator());

        RuleFor(x => x.SeatingCapacity)
            .InclusiveBetween((byte)1, (byte)200).WithMessage(ValidationMessages.GetMessage(
                // Seating capacity must be between 1 and 200
                "يجب أن تكون سعة المقاعد بين 1 و 200",
                "قەبارەی دانیشتن دەبێت لە نێوان 1 و 200 بێت"));
    }
}
