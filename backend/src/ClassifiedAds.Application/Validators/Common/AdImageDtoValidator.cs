using ClassifiedAds.Application.DTOs.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Common;

public class AdImageDtoValidator : AbstractValidator<AdImageDto>
{
    public AdImageDtoValidator()
    {
        RuleFor(x => x.ImageUrl)
            .NotEmpty()
            .WithMessage("Image URL is required")
            .MaximumLength(500)
            .WithMessage("Image URL must not exceed 500 characters");

        RuleFor(x => x.Order)
            .InclusiveBetween((byte)1, (byte)5)
            .WithMessage("Image order must be between 1 and 5");
    }
}
