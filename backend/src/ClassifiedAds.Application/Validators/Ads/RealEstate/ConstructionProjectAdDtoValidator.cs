using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.RealEstate;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.RealEstate;

public class ConstructionProjectAdDtoValidator : AbstractValidator<ConstructionProjectAdDto>
{
    public ConstructionProjectAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new RealEstateAdDtoValidator());

        RuleFor(x => x.CompletionStatus!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "حالة الإنجاز غير صالحة",
                "باری تەواوکردن نادروستە"))
            .When(x => x.CompletionStatus.HasValue);
    }
}

public class CreateConstructionProjectAdDtoValidator : AbstractValidator<CreateConstructionProjectAdDto>
{
    public CreateConstructionProjectAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new RealEstateAdDtoValidator());
        Include(new ConstructionProjectAdDtoValidator());

        // CompletionStatus is required for creation
        RuleFor(x => x.CompletionStatus)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "حالة الإنجاز مطلوبة",
                "باری تەواوکردن پێویستە"));

        this.ApplyCreateLocalPriceRules();
    }
}
