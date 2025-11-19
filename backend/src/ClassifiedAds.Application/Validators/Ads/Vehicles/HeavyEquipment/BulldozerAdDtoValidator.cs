using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Ads.Vehicles;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles.HeavyEquipment;

public class BulldozerAdDtoValidator : AbstractValidator<BulldozerAdDto>
{
    public BulldozerAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new TransportAdDtoValidator());
        Include(new HeavyEquipmentAdDtoValidator());

        RuleFor(x => x.BladeWidth)
            .InclusiveBetween(0.1f, 10f).WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون عرض الشفرة بين 0.1 و 10",
                "پانی تیغ دەبێت لە نێوان 0.1 و 10 بێت"))
            .When(x => x.BladeWidth.HasValue);

        RuleFor(x => x.MaxPushingCapacity)
            .InclusiveBetween(0.1f, 200f).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون أقصى قدرة دفع بين 0.1 و 200",
                "زۆرترین توانای پاڵنان دەبێت لە نێوان 0.1 و 200 بێت"))
            .When(x => x.MaxPushingCapacity.HasValue);

        RuleFor(x => x.TrackWidth)
            .InclusiveBetween(0.5f, 5f).WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون عرض المسار بين 0.5 و 5",
                "پانی ڕێگە دەبێت لە نێوان 0.5 و 5 بێت"))
            .When(x => x.TrackWidth.HasValue);
    }
}

public class CreateBulldozerAdDtoValidator : AbstractValidator<CreateBulldozerAdDto>
{
    public CreateBulldozerAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new TransportAdDtoValidator());
        Include(new HeavyEquipmentAdDtoValidator());
        Include(new BulldozerAdDtoValidator());

        this.ApplyCreateRules(); // Bulldozer can be IQD or USD
    }
}
