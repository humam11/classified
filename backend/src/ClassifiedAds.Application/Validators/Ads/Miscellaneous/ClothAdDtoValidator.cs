using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Miscellaneous;

public class ClothAdDtoValidator : AbstractValidator<ClothAdDto>
{
    public ClothAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());

        RuleFor(x => x.ClothCondition!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "حالة الملابس غير صالحة",
                "باری جلوبەرگ نادروستە"))
            .When(x => x.ClothCondition.HasValue);

        RuleFor(x => x.ClothingSize!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "مقاس الملابس غير صالح",
                "قەبارەی جلوبەرگ نادروستە"))
            .When(x => x.ClothingSize.HasValue);

        RuleFor(x => x.Season!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "الموسم غير صالح",
                "وەرز نادروستە"))
            .When(x => x.Season.HasValue);
    }
}

public class CreateClothAdDtoValidator : AbstractValidator<CreateClothAdDto>
{
    public CreateClothAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new ClothAdDtoValidator());

        RuleFor(x => x.ClothCondition)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "حالة الملابس مطلوبة",
                "باری جلوبەرگ پێویستە"));

        RuleFor(x => x.ClothingSize)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "مقاس الملابس مطلوب",
                "قەبارەی جلوبەرگ پێویستە"));

        RuleFor(x => x.Season)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "الموسم مطلوب",
                "وەرز پێویستە"));

        this.ApplyCreateLocalPriceRules();
    }
}
