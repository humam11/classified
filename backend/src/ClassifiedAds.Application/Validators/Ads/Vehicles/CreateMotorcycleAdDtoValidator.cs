using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles;

public class CreateMotorcycleAdDtoValidator : AbstractValidator<CreateMotorcycleAdDto>
{
    public CreateMotorcycleAdDtoValidator()
    {
        Include(new CreateTransportAdDtoValidator());

        RuleFor(x => x.MotorcycleDriveType)
            .IsValidEnum();

        RuleFor(x => x.GearCount)
            .InclusiveBetween((byte)1, (byte)8).WithMessage(GetMessage(
                // Gear count must be between 1 and 8
                "يجب أن يكون عدد التروس بين 1 و 8",
                "ژمارەی گیر دەبێت لە نێوان 1 و 8 بێت"));

        RuleFor(x => x.ModelId)
            .NotEmpty().WithMessage("Model ID is required");
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
