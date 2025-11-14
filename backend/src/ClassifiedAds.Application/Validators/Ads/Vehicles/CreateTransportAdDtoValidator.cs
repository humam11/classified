using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles;

public class CreateTransportAdDtoValidator : AbstractValidator<CreateTransportAdDto>
{
    public CreateTransportAdDtoValidator()
    {
        Include(new CreateAdDtoValidator());

        RuleFor(x => x.FuelType)
            .IsValidEnum();

        RuleFor(x => x.EnginePower)
            .GreaterThan((ushort)0).WithMessage(GetMessage(
                // Engine power must be greater than 0
                "يجب أن تكون قوة المحرك أكبر من 0",
                "هێزی بزوێنەر دەبێت لە 0 زیاتر بێت"));

        RuleFor(x => x.FuelTankCapacity)
            .GreaterThan((ushort)0).WithMessage(GetMessage(
                // Fuel tank capacity must be greater than 0
                "يجب أن تكون سعة خزان الوقود أكبر من 0",
                "قەبارەی تانکی سووتەمەنی دەبێت لە 0 زیاتر بێت"));
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
