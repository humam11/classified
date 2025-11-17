using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles;

public class TruckAdDtoValidator : AbstractValidator<TruckAdDto>
{
    public TruckAdDtoValidator()
    {
        // Include(new TransportAdDtoValidator());

        RuleFor(x => x.DistanceKm)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessages.GetMessage(
                // Distance must be 0 or greater
                "يجب أن تكون المسافة 0 أو أكبر",
                "مەودا دەبێت 0 یان زیاتر بێت"));

        RuleFor(x => x.LoadCapacity)
            .InclusiveBetween(0.1f, 100f).WithMessage(ValidationMessages.GetMessage(
                // Load capacity must be between 0.1 and 100
                "يجب أن تكون سعة الحمولة بين 0.1 و 100",
                "قەبارەی بار دەبێت لە نێوان 0.1 و 100 بێت"));

        RuleFor(x => x.AxleCount)
            .InclusiveBetween((byte)2, (byte)10).WithMessage(ValidationMessages.GetMessage(
                // Axle count must be between 2 and 10
                "يجب أن يكون عدد المحاور بين 2 و 10",
                "ژمارەی تەوەر دەبێت لە نێوان 2 و 10 بێت"));

        RuleFor(x => x.ModelId)
            .NotEmpty().WithMessage("Model ID is required");
    }
}
