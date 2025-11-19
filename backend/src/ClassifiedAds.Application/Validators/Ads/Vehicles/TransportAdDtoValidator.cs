using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles;

public class TransportAdDtoValidator : AbstractValidator<TransportAdDto>
{
    public TransportAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());

        RuleFor(x => x.FuelType!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "نوع الوقود غير صالح",
                "جۆری سووتەمەنی نادروستە"))
            .When(x => x.FuelType.HasValue);

        RuleFor(x => x.EnginePower)
            .GreaterThan((ushort)0).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون قوة المحرك أكبر من 0",
                "هێزی بزوێنەر دەبێت لە 0 زیاتر بێت"))
            .When(x => x.EnginePower.HasValue);

        RuleFor(x => x.FuelTankCapacity)
            .GreaterThan((ushort)0).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون سعة خزان الوقود أكبر من 0",
                "قەبارەی تانکی سووتەمەنی دەبێت لە 0 زیاتر بێت"))
            .When(x => x.FuelTankCapacity.HasValue);
    }
}

public class CreateTransportAdDtoValidator : AbstractValidator<CreateTransportAdDto>
{
    public CreateTransportAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new TransportAdDtoValidator());

        // FuelType is required for creation
        RuleFor(x => x.FuelType)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "نوع الوقود مطلوب",
                "جۆری سووتەمەنی پێویستە"));

        this.ApplyCreateRules(); // Vehicles can be IQD or USD
    }
}
