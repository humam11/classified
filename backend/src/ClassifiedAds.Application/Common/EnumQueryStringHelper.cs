using System.Reflection;
using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Application.Common;

/// <summary>
/// Converts enums to localized query strings for URLs
/// Based on QueryKey, QueryValue, and GetUnits attributes
/// </summary>
public static class EnumQueryStringHelper
{
    /// <summary>
    /// Converts an enum value to a localized query string
    /// Example: RamSize.Medium with lang="ar" → "ذاكرة=8-gb"
    /// </summary>
    public static string GetQueryString(Enum enumValue, string lang = null)
    {
        lang ??= LanguageContext.Current;
        var type = enumValue.GetType();

        // Get QueryKey (enum-level attribute)
        var keyAttr = type.GetCustomAttribute<QueryKeyAttribute>();
        string key = lang switch
        {
            "ar" => keyAttr?.ar ?? type.Name.ToLower(),
            "kr" => keyAttr?.kr ?? type.Name.ToLower(),
            _ => type.Name.ToLower()
        };

        // Get enum member
        var memberName = enumValue.ToString();
        var member = type.GetMember(memberName)[0];
        var valAttr = member.GetCustomAttribute<QueryValueAttribute>();

        // Check if enum has GetUnits attribute
        var unitAttr = type.GetCustomAttribute<GetUnitsAttribute>();
        string value;

        if (unitAttr != null)
        {
            // Ignore QueryValue and use numeric + unit
            int intVal = Convert.ToInt32(enumValue);
            var unitType = typeof(Domain.Common.Enums.Units);
            var unitMember = unitType.GetMember(unitAttr.UnitKey)[0];
            var unitLangAttr = unitMember.GetCustomAttribute<QueryValueAttribute>();

            string unitText = lang switch
            {
                "ar" => unitLangAttr?.ar ?? unitAttr.UnitKey,
                "kr" => unitLangAttr?.kr ?? unitAttr.UnitKey,
                _ => unitAttr.UnitKey
            };

            value = $"{intVal}-{unitText}";
        }
        else
        {
            value = lang switch
            {
                "ar" => valAttr?.ar ?? memberName,
                "kr" => valAttr?.kr ?? memberName,
                _ => memberName
            };
        }

        key = key.ToLower().Replace(" ", "-");
        value = value.ToLower().Replace(" ", "-");

        return $"{key}={value}";
    }

    /// <summary>
    /// Parses a localized query string back to enum value
    /// Example: "ذاكرة=8-gb" → RamSize.Medium
    /// </summary>
    public static T ParseQueryString<T>(string queryString, string lang = null) where T : struct, Enum
    {
        lang ??= LanguageContext.Current;
        var parts = queryString.Split('=');
        if (parts.Length != 2) throw new ArgumentException("Invalid query string format");

        var type = typeof(T);
        var unitAttr = type.GetCustomAttribute<GetUnitsAttribute>();

        if (unitAttr != null)
        {
            // Parse numeric value (e.g., "8-gb" → 8)
            var valuePart = parts[1].Split('-')[0];
            if (int.TryParse(valuePart, out int intValue))
            {
                return (T)Enum.ToObject(type, intValue);
            }
        }
        else
        {
            // Match by QueryValue
            foreach (var member in type.GetMembers())
            {
                var valAttr = member.GetCustomAttribute<QueryValueAttribute>();
                if (valAttr != null)
                {
                    string localizedValue = lang switch
                    {
                        "ar" => valAttr.ar,
                        "kr" => valAttr.kr,
                        _ => member.Name
                    };

                    if (localizedValue?.ToLower().Replace(" ", "-") == parts[1])
                    {
                        return (T)Enum.Parse(type, member.Name);
                    }
                }
            }
        }

        throw new ArgumentException($"Cannot parse '{queryString}' to {typeof(T).Name}");
    }

    /// <summary>
    /// Gets all possible query string values for an enum type
    /// Useful for generating filter options in UI
    /// </summary>
    public static Dictionary<T, string> GetAllQueryStrings<T>(string lang = null) where T : struct, Enum
    {
        lang ??= LanguageContext.Current;
        var result = new Dictionary<T, string>();

        foreach (T value in Enum.GetValues(typeof(T)))
        {
            result[value] = GetQueryString(value, lang);
        }

        return result;
    }
}
