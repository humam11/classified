using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Miscellaneous;

public class ShoeAdDtoValidator : AbstractValidator<ShoeAdDto>
{
    public ShoeAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());

        RuleFor(x => x.IsNew!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "حالة الحذاء غير صالحة",
                "باری پێڵاو نادروستە"))
            .When(x => x.IsNew.HasValue);

        RuleFor(x => x.Size)
            .InclusiveBetween((byte)15, (byte)70)
            .WithMessage(ValidationMessages.GetMessage(
                "يجب أن يكون مقاس الحذاء بين 15 و 70",
                "قەبارەی پێڵاو دەبێت لە نێوان 15 و 70 بێت"))
            .When(x => x.Size.HasValue);
    }
}

public class CreateShoeAdDtoValidator : AbstractValidator<CreateShoeAdDto>
{
    public CreateShoeAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new ShoeAdDtoValidator());

        RuleFor(x => x.IsNew)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "حالة الحذاء مطلوبة",
                "باری پێڵاو پێویستە"));

        this.ApplyCreateLocalPriceRules();
    }
}
