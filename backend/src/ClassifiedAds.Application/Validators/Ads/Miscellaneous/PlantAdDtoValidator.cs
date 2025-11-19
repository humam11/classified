using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Miscellaneous;

public class PlantAdDtoValidator : AbstractValidator<PlantAdDto>
{
    public PlantAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());

        RuleFor(x => x.PlantType!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "نوع النبات غير صالح",
                "جۆری ڕووەک نادروستە"))
            .When(x => x.PlantType.HasValue);

        RuleFor(x => x.Height)
            .InclusiveBetween((ushort)1, (ushort)2000)
            .WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون الارتفاع بين 1 و 2000",
                "بەرزی دەبێت لە نێوان 1 و 2000 بێت"))
            .When(x => x.Height.HasValue);
    }
}

public class CreatePlantAdDtoValidator : AbstractValidator<CreatePlantAdDto>
{
    public CreatePlantAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new PlantAdDtoValidator());

        RuleFor(x => x.PlantType)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "نوع النبات مطلوب",
                "جۆری ڕووەک پێویستە"));

        this.ApplyCreateLocalPriceRules();
    }
}
