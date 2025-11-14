using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Electronics;

public class CreateConsoleAdDtoValidator : AbstractValidator<CreateConsoleAdDto>
{
    public CreateConsoleAdDtoValidator()
    {
        Include(new CreateElectronicAdDtoValidator());

        RuleFor(x => x.StorageCapacity)
            .IsValidEnum();

        RuleFor(x => x.ConsoleRegion)
            .IsValidEnum();

        RuleFor(x => x.ModelId)
            .NotEmpty().WithMessage("Model ID is required");
    }
}
