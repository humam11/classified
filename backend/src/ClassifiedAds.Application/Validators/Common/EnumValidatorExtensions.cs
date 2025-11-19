using FluentValidation;

namespace ClassifiedAds.Application.Validators.Common;

public static class EnumValidatorExtensions
{
    // Validates that an enum value is defined in the enum type
    public static IRuleBuilderOptions<T, TEnum> IsValidEnum<T, TEnum>(this IRuleBuilder<T, TEnum> ruleBuilder) 
        where TEnum : struct, Enum
    {
        return ruleBuilder
            .Must(value => Enum.IsDefined(typeof(TEnum), value))
            .WithMessage($"{{PropertyName}} must be a valid {typeof(TEnum).Name} value");
    }

    // Validates that a nullable enum value is defined in the enum type (required - not null)
    public static IRuleBuilderOptions<T, TEnum?> IsValidEnum<T, TEnum>(this IRuleBuilder<T, TEnum?> ruleBuilder) 
        where TEnum : struct, Enum
    {
        return ruleBuilder
            .Must(value => value.HasValue && Enum.IsDefined(typeof(TEnum), value.Value))
            .WithMessage($"{{PropertyName}} must be a valid {typeof(TEnum).Name} value");
    }

    // Validates that a nullable enum value is defined when provided (optional)
    public static IRuleBuilderOptions<T, TEnum?> IsValidEnumWhenNotNull<T, TEnum>(this IRuleBuilder<T, TEnum?> ruleBuilder) 
        where TEnum : struct, Enum
    {
        return ruleBuilder
            .Must(value => !value.HasValue || Enum.IsDefined(typeof(TEnum), value.Value))
            .WithMessage($"{{PropertyName}} must be a valid {typeof(TEnum).Name} value when provided");
    }
}
