using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Application.Validators.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Electronics;

public class ConsoleAdDtoValidator : AbstractValidator<ConsoleAdDto>
{
    public ConsoleAdDtoValidator()
    {
        // Include(new ElectronicAdDtoValidator());

        RuleFor(x => x.StorageCapacity)
            .IsValidEnum();

        RuleFor(x => x.ConsoleRegion)
            .IsValidEnum();

        RuleFor(x => x.ModelId)
            .NotEmpty().WithMessage("Model ID is required");
    }
}
