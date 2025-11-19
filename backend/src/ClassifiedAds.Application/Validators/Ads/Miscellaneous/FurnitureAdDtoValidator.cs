using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Miscellaneous;

public class FurnitureAdDtoValidator : AbstractValidator<FurnitureAdDto>
{
    public FurnitureAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());

        RuleFor(x => x.FurnitureMaterial!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "مادة الأثاث غير صالحة",
                "ماددەی کەلوپەل نادروستە"))
            .When(x => x.FurnitureMaterial.HasValue);

        RuleFor(x => x.Length)
            .InclusiveBetween((ushort)1, (ushort)1000)
            .WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون الطول بين 1 و 1000",
                "درێژی دەبێت لە نێوان 1 و 1000 بێت"))
            .When(x => x.Length.HasValue);

        RuleFor(x => x.Width)
            .InclusiveBetween((ushort)1, (ushort)1000)
            .WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون العرض بين 1 و 1000",
                "پانی دەبێت لە نێوان 1 و 1000 بێت"))
            .When(x => x.Width.HasValue);

        RuleFor(x => x.Height)
            .InclusiveBetween((ushort)1, (ushort)500)
            .WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون الارتفاع بين 1 و 500",
                "بەرزی دەبێت لە نێوان 1 و 500 بێت"))
            .When(x => x.Height.HasValue);
    }
}

public class CreateFurnitureAdDtoValidator : AbstractValidator<CreateFurnitureAdDto>
{
    public CreateFurnitureAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new FurnitureAdDtoValidator());

        RuleFor(x => x.FurnitureMaterial)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "مادة الأثاث مطلوبة",
                "ماددەی کەلوپەل پێویستە"));

        this.ApplyCreateLocalPriceRules();
    }
}
