using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Ads.Vehicles;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles.HeavyEquipment;

public class ExcavatorAdDtoValidator : AbstractValidator<ExcavatorAdDto>
{
    public ExcavatorAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new TransportAdDtoValidator());
        Include(new HeavyEquipmentAdDtoValidator());

        RuleFor(x => x.BucketCapacity)
            .InclusiveBetween(0.1f, 10f).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون سعة الجرافة بين 0.1 و 10",
                "قەبارەی سەتڵ دەبێت لە نێوان 0.1 و 10 بێت"))
            .When(x => x.BucketCapacity.HasValue);

        RuleFor(x => x.DiggingDepth)
            .InclusiveBetween(0.1f, 30f).WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون عمق الحفر بين 0.1 و 30",
                "قووڵی هەڵکەندن دەبێت لە نێوان 0.1 و 30 بێت"))
            .When(x => x.DiggingDepth.HasValue);
    }
}

public class CreateExcavatorAdDtoValidator : AbstractValidator<CreateExcavatorAdDto>
{
    public CreateExcavatorAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new TransportAdDtoValidator());
        Include(new HeavyEquipmentAdDtoValidator());
        Include(new ExcavatorAdDtoValidator());

        this.ApplyCreateRules(); // Excavator can be IQD or USD
    }
}
