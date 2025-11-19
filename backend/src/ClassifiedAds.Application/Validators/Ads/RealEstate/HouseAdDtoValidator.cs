using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.RealEstate;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.RealEstate;

public class HouseAdDtoValidator : AbstractValidator<HouseAdDto>
{
    public HouseAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new RealEstateAdDtoValidator());

        RuleFor(x => x.Floors)
            .InclusiveBetween((byte)1, (byte)10).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون الطوابق بين 1 و 10",
                "نهۆم دەبێت لە نێوان 1 و 10 بێت"))
            .When(x => x.Floors.HasValue);

        RuleFor(x => x.Bedrooms)
            .InclusiveBetween((byte)0, (byte)20).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون غرف النوم بين 0 و 20",
                "ژووری نوستن دەبێت لە نێوان 0 و 20 بێت"))
            .When(x => x.Bedrooms.HasValue);

        RuleFor(x => x.Bathrooms)
            .InclusiveBetween((byte)0, (byte)10).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون الحمامات بين 0 و 10",
                "ژووری ئاو دەبێت لە نێوان 0 و 10 بێت"))
            .When(x => x.Bathrooms.HasValue);

        RuleFor(x => x.Garage!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار الكراج غير صالح",
                "هەڵبژاردەی گاراج نادروستە"))
            .When(x => x.Garage.HasValue);

        RuleFor(x => x.Garden!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار الحديقة غير صالح",
                "هەڵبژاردەی باخچە نادروستە"))
            .When(x => x.Garden.HasValue);
    }
}

public class CreateHouseAdDtoValidator : AbstractValidator<CreateHouseAdDto>
{
    public CreateHouseAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new RealEstateAdDtoValidator());
        Include(new HouseAdDtoValidator());

        // Required enum fields for creation
        RuleFor(x => x.Garage)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار الكراج مطلوب",
                "هەڵبژاردەی گاراج پێویستە"));

        RuleFor(x => x.Garden)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار الحديقة مطلوب",
                "هەڵبژاردەی باخچە پێویستە"));

        this.ApplyCreateLocalPriceRules();
    }
}
