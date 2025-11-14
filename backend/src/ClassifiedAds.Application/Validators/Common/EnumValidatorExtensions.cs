using FluentValidation;

namespace ClassifiedAds.Application.Validators.Common;

public static class EnumValidatorExtensions
{
    /// <summary>
    /// Validates that an enum value is defined in the enum type
    /// </summary>
    public static IRuleBuilderOptions<T, TEnum> IsValidEnum<T, TEnum>(this IRuleBuilder<T, TEnum> ruleBuilder) 
        where TEnum : struct, Enum
    {
        return ruleBuilder
            .Must(value => Enum.IsDefined(typeof(TEnum), value))
            .WithMessage($"{{PropertyName}} must be a valid {typeof(TEnum).Name} value");
    }

    /// <summary>
    /// Validates that a nullable enum value is defined in the enum type when not null
    /// </summary>
    public static IRuleBuilderOptions<T, TEnum?> IsValidEnumWhenNotNull<T, TEnum>(this IRuleBuilder<T, TEnum?> ruleBuilder) 
        where TEnum : struct, Enum
    {
        return ruleBuilder
            .Must(value => !value.HasValue || Enum.IsDefined(typeof(TEnum), value.Value))
            .WithMessage($"{{PropertyName}} must be a valid {typeof(TEnum).Name} value when provided");
    }
}
