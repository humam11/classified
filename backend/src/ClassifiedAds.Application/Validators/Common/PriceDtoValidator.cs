using ClassifiedAds.Application.DTOs.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Common;

/// <summary>
/// Base validator for PriceDto - validates common price properties
/// </summary>
public class PriceDtoValidator : AbstractValidator<PriceDto>
{
    public PriceDtoValidator()
    {
        RuleFor(x => x.Value)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Price value must be greater than or equal to 0");

        RuleFor(x => x.ShowingPrice)
            .NotEmpty()
            .WithMessage("Showing price is required")
            .MaximumLength(50)
            .WithMessage("Showing price must not exceed 50 characters");
    }
}

/// <summary>
/// Validator for prices that must be in local currency (IQD) only
/// Used for: RealEstate, Service, and all Miscellaneous (except VideoGame)
/// </summary>
public class PriceLocalOnlyValidator : AbstractValidator<PriceDto>
{
    public PriceLocalOnlyValidator()
    {
        Include(new PriceDtoValidator());
        
        RuleFor(x => x.IsDollar)
            .Equal(false)
            .WithMessage("Price must be in local currency (IQD). IsDollar must be false.");
    }
}
