using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles.HeavyEquipment;

public class CreateExcavatorAdDtoValidator : AbstractValidator<CreateExcavatorAdDto>
{
    public CreateExcavatorAdDtoValidator()
    {
        Include(new CreateHeavyEquipmentAdDtoValidator());

        RuleFor(x => x.BucketCapacity)
            .InclusiveBetween(0.1f, 10f).WithMessage(GetMessage(
                // Bucket capacity must be between 0.1 and 10
                "يجب أن تكون سعة الجرافة بين 0.1 و 10",
                "قەبارەی سەتڵ دەبێت لە نێوان 0.1 و 10 بێت"));

        RuleFor(x => x.DiggingDepth)
            .InclusiveBetween(0.1f, 30f).WithMessage(GetMessage(
                // Digging depth must be between 0.1 and 30
                "يجب أن يكون عمق الحفر بين 0.1 و 30",
                "قووڵی هەڵکەندن دەبێت لە نێوان 0.1 و 30 بێت"));
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
