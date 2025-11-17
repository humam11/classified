using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles.HeavyEquipment;

public class CraneAdDtoValidator : AbstractValidator<CraneAdDto>
{
    public CraneAdDtoValidator()
    {
        Include(new HeavyEquipmentAdDtoValidator());

        RuleFor(x => x.LiftingCapacity)
            .InclusiveBetween(0.1f, 1000f).WithMessage(ValidationMessages.GetMessage(
                // Lifting capacity must be between 0.1 and 1000
                "يجب أن تكون قدرة الرفع بين 0.1 و 1000",
                "توانای هەڵگرتن دەبێت لە نێوان 0.1 و 1000 بێت"));

        RuleFor(x => x.MaxLiftingHeight)
            .InclusiveBetween(0.1f, 200f).WithMessage(ValidationMessages.GetMessage(
                // Max lifting height must be between 0.1 and 200
                "يجب أن يكون أقصى ارتفاع للرفع بين 0.1 و 200",
                "بەرزترین بەرزی هەڵگرتن دەبێت لە نێوان 0.1 و 200 بێت"));

        RuleFor(x => x.BoomLength)
            .InclusiveBetween(0.1f, 150f).WithMessage(ValidationMessages.GetMessage(
                // Boom length must be between 0.1 and 150
                "يجب أن يكون طول الذراع بين 0.1 و 150",
                "درێژی باسک دەبێت لە نێوان 0.1 و 150 بێت"));

        RuleFor(x => x.RotationAngle)
            .InclusiveBetween((ushort)1, (ushort)360).WithMessage(ValidationMessages.GetMessage(
                // Rotation angle must be between 1 and 360 degrees
                "يجب أن تكون زاوية الدوران بين 1 و 360 درجة",
                "گۆشەی سووڕان دەبێت لە نێوان 1 و 360 پلە بێت"));
    }
}
