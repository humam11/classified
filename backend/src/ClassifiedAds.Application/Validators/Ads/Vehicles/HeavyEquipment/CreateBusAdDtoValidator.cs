using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles.HeavyEquipment;

public class CreateBusAdDtoValidator : AbstractValidator<CreateBusAdDto>
{
    public CreateBusAdDtoValidator()
    {
        Include(new CreateHeavyEquipmentAdDtoValidator());

        RuleFor(x => x.SeatingCapacity)
            .InclusiveBetween((byte)1, (byte)200).WithMessage(GetMessage(
                // Seating capacity must be between 1 and 200
                "يجب أن تكون سعة المقاعد بين 1 و 200",
                "قەبارەی دانیشتن دەبێت لە نێوان 1 و 200 بێت"));
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
