using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads.Vehicles;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles;

public class CreateBoatAdDtoValidator : AbstractValidator<CreateBoatAdDto>
{
    public CreateBoatAdDtoValidator()
    {
        Include(new CreateTransportAdDtoValidator());

        RuleFor(x => x.Length)
            .InclusiveBetween(0.1f, 100f).WithMessage(GetMessage(
                // Length must be between 0.1 and 100
                "يجب أن يكون الطول بين 0.1 و 100",
                "درێژی دەبێت لە نێوان 0.1 و 100 بێت"));

        RuleFor(x => x.Capacity)
            .InclusiveBetween((byte)1, (byte)100).WithMessage(GetMessage(
                // Capacity must be between 1 and 100
                "يجب أن تكون السعة بين 1 و 100",
                "قەبارە دەبێت لە نێوان 1 و 100 بێت"));
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
