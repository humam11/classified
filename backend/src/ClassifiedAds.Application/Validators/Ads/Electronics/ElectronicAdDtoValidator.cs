using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Application.Validators.Ads;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Electronics;

public class ElectronicAdDtoValidator : AbstractValidator<ElectronicAdDto>
{
    public ElectronicAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());

        RuleFor(x => x.IsNew!.Value)
            .IsValidEnum()
            .WithMessage(ValidationMessages.GetMessage(
                "حالة المنتج غير صالحة",
                "باری بەرهەم نادروستە"))
            .When(x => x.IsNew.HasValue);

        RuleFor(x => x.WarrantyMonths)
            .InclusiveBetween((byte)0, (byte)120).WithMessage(ValidationMessages.GetMessage(
                "يجب أن تكون أشهر الضمان بين 0 و 120",
                "مانگی گەرەنتی دەبێت لە نێوان 0 و 120 بێت"))
            .When(x => x.WarrantyMonths.HasValue);
    }
}

public class CreateElectronicAdDtoValidator : AbstractValidator<CreateElectronicAdDto>
{
    public CreateElectronicAdDtoValidator()
    {
        Include(new AdDtoBaseValidator());
        Include(new ElectronicAdDtoValidator());

        // IsNew is required for creation
        RuleFor(x => x.IsNew)
            .NotNull()
            .WithMessage(ValidationMessages.GetMessage(
                "حالة المنتج مطلوبة",
                "باری بەرهەم پێویستە"));

        this.ApplyCreateLocalPriceRules();
    }
}
