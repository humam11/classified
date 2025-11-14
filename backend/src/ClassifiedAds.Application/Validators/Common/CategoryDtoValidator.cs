using ClassifiedAds.Application.DTOs.Common;
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Common;

public class CategoryDtoValidator : AbstractValidator<CategoryDto>
{
    public CategoryDtoValidator()
    {
        RuleFor(x => x.CategoryIds)
            .NotNull()
            .WithMessage("Category IDs are required")
            .Must(ids => ids != null && ids.Count > 0)
            .WithMessage("At least one category ID is required");

        RuleFor(x => x.CategoryJoins)
            .GreaterThan((byte)0)
            .WithMessage("Category joins must be greater than 0");
    }
}
