using Microsoft.AspNetCore.Http;

namespace ClassifiedAds.Application.Common;

/// <summary>
/// Strict parsing helpers for form data - throws FormatException when value is provided but invalid
/// </summary>
public static class FormParsingHelpers
{
    public static TEnum? ParseEnum<TEnum>(IFormCollection form, string key) where TEnum : struct, Enum
    {
        if (!form.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
            return null;
        if (!Enum.TryParse<TEnum>(value, out var result))
            throw new FormatException($"Invalid value '{value}' for {key}. Expected valid {typeof(TEnum).Name} value.");
        return result;
    }

    public static byte? ParseByte(IFormCollection form, string key)
    {
        if (!form.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
            return null;
        if (!byte.TryParse(value, out var result))
            throw new FormatException($"Invalid value '{value}' for {key}. Expected a number between 0 and 255.");
        return result;
    }

    public static ushort? ParseUShort(IFormCollection form, string key)
    {
        if (!form.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
            return null;
        if (!ushort.TryParse(value, out var result))
            throw new FormatException($"Invalid value '{value}' for {key}. Expected a number between 0 and 65535.");
        return result;
    }

    public static int? ParseInt(IFormCollection form, string key)
    {
        if (!form.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
            return null;
        if (!int.TryParse(value, out var result))
            throw new FormatException($"Invalid value '{value}' for {key}. Expected a valid integer.");
        return result;
    }

    public static uint? ParseUInt(IFormCollection form, string key)
    {
        if (!form.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
            return null;
        if (!uint.TryParse(value, out var result))
            throw new FormatException($"Invalid value '{value}' for {key}. Expected a positive integer.");
        return result;
    }

    public static decimal? ParseDecimal(IFormCollection form, string key)
    {
        if (!form.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
            return null;
        if (!decimal.TryParse(value, out var result))
            throw new FormatException($"Invalid value '{value}' for {key}. Expected a valid decimal number.");
        return result;
    }

    public static float? ParseFloat(IFormCollection form, string key)
    {
        if (!form.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
            return null;
        if (!float.TryParse(value, out var result))
            throw new FormatException($"Invalid value '{value}' for {key}. Expected a valid number.");
        return result;
    }

    public static bool? ParseBool(IFormCollection form, string key)
    {
        if (!form.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
            return null;
        if (!bool.TryParse(value, out var result))
            throw new FormatException($"Invalid value '{value}' for {key}. Expected 'true' or 'false'.");
        return result;
    }

    public static string? ParseString(IFormCollection form, string key)
    {
        if (!form.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
            return null;
        return value.ToString();
    }

    public static DateTime? ParseDateTime(IFormCollection form, string key)
    {
        if (!form.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
            return null;
        if (!DateTime.TryParse(value, out var result))
            throw new FormatException($"Invalid value '{value}' for {key}. Expected a valid date/time.");
        return result;
    }

    public static T? ParseJson<T>(IFormCollection form, string key) where T : class
    {
        if (!form.TryGetValue(key, out var value) || string.IsNullOrWhiteSpace(value))
            return null;
        try
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(value.ToString());
        }
        catch (System.Text.Json.JsonException ex)
        {
            throw new FormatException($"Invalid JSON value for {key}. {ex.Message}");
        }
    }
}
