using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles;

public class MotorcycleAdDtoValidator : AbstractValidator<MotorcycleAdDto>
{
    public MotorcycleAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new TransportAdDtoValidator());

        RuleFor(x => x.MotorcycleDriveType!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "نوع الدفع غير صالح",
                "جۆری هاندەر نادروستە"))
            .When(x => x.MotorcycleDriveType.HasValue);

        RuleFor(x => x.GearCount)
            .InclusiveBetween((byte)1, (byte)8).WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون عدد التروس بين 1 و 8",
                "ژمارەی گیر دەبێت لە نێوان 1 و 8 بێت"))
            .When(x => x.GearCount.HasValue);
    }
}

public class CreateMotorcycleAdDtoValidator : AbstractValidator<CreateMotorcycleAdDto>
{
    public CreateMotorcycleAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new TransportAdDtoValidator());
        Include(new MotorcycleAdDtoValidator());

        RuleFor(x => x.BrandName)
            .NotEmpty()
            .WithMessage(ValidationMessages.GetMessage(
                "اسم العلامة التجارية مطلوب",
                "ناوی براند پێویستە"));

        // Required enum fields for creation
        RuleFor(x => x.MotorcycleDriveType)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "نوع الدفع مطلوب",
                "جۆری هاندەر پێویستە"));

        this.ApplyCreateRules(); // Motorcycle can be IQD or USD
    }
}
