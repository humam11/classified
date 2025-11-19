using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Ads.Vehicles;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles.HeavyEquipment;

public class CraneAdDtoValidator : AbstractValidator<CraneAdDto>
{
    public CraneAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new TransportAdDtoValidator());
        Include(new HeavyEquipmentAdDtoValidator());

        RuleFor(x => x.LiftingCapacity)
            .InclusiveBetween(0.1f, 1000f).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون قدرة الرفع بين 0.1 و 1000",
                "توانای هەڵگرتن دەبێت لە نێوان 0.1 و 1000 بێت"))
            .When(x => x.LiftingCapacity.HasValue);

        RuleFor(x => x.MaxLiftingHeight)
            .InclusiveBetween(0.1f, 200f).WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون أقصى ارتفاع للرفع بين 0.1 و 200",
                "بەرزترین بەرزی هەڵگرتن دەبێت لە نێوان 0.1 و 200 بێت"))
            .When(x => x.MaxLiftingHeight.HasValue);

        RuleFor(x => x.BoomLength)
            .InclusiveBetween(0.1f, 150f).WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون طول الذراع بين 0.1 و 150",
                "درێژی باسک دەبێت لە نێوان 0.1 و 150 بێت"))
            .When(x => x.BoomLength.HasValue);

        RuleFor(x => x.RotationAngle)
            .InclusiveBetween((ushort)1, (ushort)360).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون زاوية الدوران بين 1 و 360 درجة",
                "گۆشەی سووڕان دەبێت لە نێوان 1 و 360 پلە بێت"))
            .When(x => x.RotationAngle.HasValue);
    }
}

public class CreateCraneAdDtoValidator : AbstractValidator<CreateCraneAdDto>
{
    public CreateCraneAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new TransportAdDtoValidator());
        Include(new HeavyEquipmentAdDtoValidator());
        Include(new CraneAdDtoValidator());

        this.ApplyCreateRules(); // Crane can be IQD or USD
    }
}
