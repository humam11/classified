using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles;

public class TruckAdDtoValidator : AbstractValidator<TruckAdDto>
{
    public TruckAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new TransportAdDtoValidator());

        RuleFor(x => x.DistanceKm)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون المسافة 0 أو أكبر",
                "مەودا دەبێت 0 یان زیاتر بێت"))
            .When(x => x.DistanceKm.HasValue);

        RuleFor(x => x.LoadCapacity)
            .InclusiveBetween(0.1f, 100f).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون سعة الحمولة بين 0.1 و 100",
                "قەبارەی بار دەبێت لە نێوان 0.1 و 100 بێت"))
            .When(x => x.LoadCapacity.HasValue);

        RuleFor(x => x.AxleCount)
            .InclusiveBetween((byte)2, (byte)10).WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون عدد المحاور بين 2 و 10",
                "ژمارەی تەوەر دەبێت لە نێوان 2 و 10 بێت"))
            .When(x => x.AxleCount.HasValue);
    }
}

public class CreateTruckAdDtoValidator : AbstractValidator<CreateTruckAdDto>
{
    public CreateTruckAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new TransportAdDtoValidator());
        Include(new TruckAdDtoValidator());

        RuleFor(x => x.ModelId)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "معرف الموديل مطلوب",
                "ناسنامەی مۆدێل پێویستە"));

        this.ApplyCreateRules(); // Truck can be IQD or USD
    }
}
