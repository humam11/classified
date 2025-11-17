using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles.HeavyEquipment;

public class BulldozerAdDtoValidator : AbstractValidator<BulldozerAdDto>
{
    public BulldozerAdDtoValidator()
    {
        Include(new HeavyEquipmentAdDtoValidator());

        RuleFor(x => x.BladeWidth)
            .InclusiveBetween(0.1f, 10f).WithMessage(ValidationMessages.GetMessage(
                // Blade width must be between 0.1 and 10
                "يجب أن يكون عرض الشفرة بين 0.1 و 10",
                "پانی تیغ دەبێت لە نێوان 0.1 و 10 بێت"));

        RuleFor(x => x.MaxPushingCapacity)
            .InclusiveBetween(0.1f, 200f).WithMessage(ValidationMessages.GetMessage(
                // Max pushing capacity must be between 0.1 and 200
                "يجب أن تكون أقصى قدرة دفع بين 0.1 و 200",
                "زۆرترین توانای پاڵنان دەبێت لە نێوان 0.1 و 200 بێت"));

        RuleFor(x => x.TrackWidth)
            .InclusiveBetween(0.5f, 5f).WithMessage(ValidationMessages.GetMessage(
                // Track width must be between 0.5 and 5
                "يجب أن يكون عرض المسار بين 0.5 و 5",
                "پانی ڕێگە دەبێت لە نێوان 0.5 و 5 بێت"));
    }
}
