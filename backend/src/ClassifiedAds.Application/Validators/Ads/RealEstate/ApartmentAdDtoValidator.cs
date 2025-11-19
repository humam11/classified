using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.RealEstate;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.RealEstate;

public class ApartmentAdDtoValidator : AbstractValidator<ApartmentAdDto>
{
    public ApartmentAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new RealEstateAdDtoValidator());

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

        RuleFor(x => x.Elevator!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار المصعد غير صالح",
                "هەڵبژاردەی ئاسانسۆر نادروستە"))
            .When(x => x.Elevator.HasValue);

        RuleFor(x => x.Furnished!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار الأثاث غير صالح",
                "هەڵبژاردەی کەلوپەل نادروستە"))
            .When(x => x.Furnished.HasValue);

        RuleFor(x => x.FloorNumber)
            .InclusiveBetween((byte)0, (byte)100).WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون رقم الطابق بين 0 و 100",
                "ژمارەی نهۆم دەبێت لە نێوان 0 و 100 بێت"))
            .When(x => x.FloorNumber.HasValue);
    }
}

public class CreateApartmentAdDtoValidator : AbstractValidator<CreateApartmentAdDto>
{
    public CreateApartmentAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new RealEstateAdDtoValidator());
        Include(new ApartmentAdDtoValidator());

        // Required enum fields for creation
        RuleFor(x => x.Elevator)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار المصعد مطلوب",
                "هەڵبژاردەی ئاسانسۆر پێویستە"));

        RuleFor(x => x.Furnished)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "خيار الأثاث مطلوب",
                "هەڵبژاردەی کەلوپەل پێویستە"));

        this.ApplyCreateLocalPriceRules();
    }
}
