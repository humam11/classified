using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Miscellaneous;

/// <summary>
/// VideoGame is the only Miscellaneous item that can have IsDollar = true or false
/// </summary>
public class CreateVideoGameAdDtoValidator : AbstractValidator<CreateVideoGameAdDto>
{
    public CreateVideoGameAdDtoValidator()
    {
        Include(new CreateAdDtoValidator()); // Can be IQD or USD

        RuleFor(x => x.VideoGameRegion)
            .IsValidEnum();

        RuleFor(x => x.ModelId)
            .NotEmpty().WithMessage("Model ID is required");
    }
}
