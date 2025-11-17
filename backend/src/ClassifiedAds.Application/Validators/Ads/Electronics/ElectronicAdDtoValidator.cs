using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Electronics;

public class ElectronicAdDtoValidator : AbstractValidator<ElectronicAdDto>
{
    public ElectronicAdDtoValidator()
    {
        // Include(new CreateAdDtoValidator());

        RuleFor(x => x.IsNew)
            .IsValidEnum();

        RuleFor(x => x.WarrantyMonths)
            .InclusiveBetween((byte)0, (byte)120).WithMessage(ValidationMessages.GetMessage(
                // Warranty months must be between 0 and 120
                "يجب أن تكون أشهر الضمان بين 0 و 120",
                "مانگی گەرەنتی دەبێت لە نێوان 0 و 120 بێت"));
    }
}
