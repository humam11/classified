using System;
using System.Reflection;
using System.Linq;

// Custom Attributes
[AttributeUsage(AttributeTargets.Enum)]
public class LocalizedEnumNameAttribute : Attribute
{
    public string Arabic { get; set; }
    public string Kurdish { get; set; }
}

[AttributeUsage(AttributeTargets.Enum)]
public class GetUnitsAttribute : Attribute
{
    public string Unit { get; set; }
    public GetUnitsAttribute(string unit)
    {
        Unit = unit;
    }
}

[AttributeUsage(AttributeTargets.Enum)]
public class EnumConverterAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Field)]
public class LanguageDisplayAttribute : Attribute
{
    public string Arabic { get; set; }
    public string Kurdish { get; set; }
}

// Enums
public enum Units
{
    [LanguageDisplay(Arabic = "كيلوغرام", Kurdish = "کیلۆگرام")]
    kg,
    [LanguageDisplay(Arabic = "طن", Kurdish = "تەن")]
    ton,
    [LanguageDisplay(Arabic = "غرام", Kurdish = "گرام")]
    gram,
    [LanguageDisplay(Arabic = "لتر", Kurdish = "لیتەر")]
    liter,
    [LanguageDisplay(Arabic = "متر", Kurdish = "مەتر")]
    meter,
    [LanguageDisplay(Arabic = "كم", Kurdish = "کم")]
    kilometer,
    [LanguageDisplay(Arabic = "حصان", Kurdish = "ئەسپ")]
    horsepower,
    [LanguageDisplay(Arabic = "سم", Kurdish = "سم")]
    cm,
    [LanguageDisplay(Arabic = "ملم", Kurdish = "ملم")]
    mm,
    gb,
    [LanguageDisplay(Arabic = "بوصة", Kurdish = "ئینچ")]
    inch
}

[LocalizedEnumName(Arabic = "نوع-الوقود", Kurdish = "جۆری-سووتەمەنی")]
public enum FuelType : byte
{
    [LanguageDisplay(Arabic = "بنزين", Kurdish = "بەنزین")]
    Gasoline,
    [LanguageDisplay(Arabic = "ديزل", Kurdish = "دیزەل")]
    Diesel,
    [LanguageDisplay(Arabic = "كهرباء", Kurdish = "کارەبا")]
    Electric,
    [LanguageDisplay(Arabic = "هجين", Kurdish = "هایبرید")]
    Hybrid,
    [LanguageDisplay(Arabic = "غاز", Kurdish = "گاز")]
    Gas,
    [LanguageDisplay(Arabic = "أخرى", Kurdish = "ئەویتر")]
    Other
}

[LocalizedEnumName(Arabic = "الوزن", Kurdish = "کێش")]
[GetUnits("cm")]
[EnumConverter]
public enum Weight : int
{
    Light,
    Medium,
    Heavy
}

public enum Color : int
{
    Red,
    Green,
    Blue
}

class EnumKeyValueGenerator
{
    public static string GenerateKeyValuePair(Type enumType, object enumValue, string languageCode)
    {
        // Get the key (enum name)
        string key = GetLocalizedEnumName(enumType, languageCode);
        
        // Get the value (enum member)
        string value = GetLocalizedEnumValue(enumType, enumValue, languageCode);
        
        // Get the unit if exists
        string unit = GetLocalizedUnit(enumType, languageCode);
        
        // Compose the result
        if (!string.IsNullOrEmpty(unit))
        {
            return $"{key}={value}-{unit}";
        }
        else
        {
            return $"{key}={value}";
        }
    }
    
    public static object ParseKeyValuePair(Type enumType, string keyValuePair, string languageCode)
    {
        // Split by '='
        var parts = keyValuePair.Split('=');
        if (parts.Length != 2)
            throw new ArgumentException("Invalid key-value pair format. Expected format: key=value or key=value-unit");
        
        string key = parts[0];
        string valueWithUnit = parts[1];
        
        // Verify the key matches the enum type
        string expectedKey = GetLocalizedEnumName(enumType, languageCode);
        if (key != expectedKey)
            throw new ArgumentException($"Key '{key}' does not match expected enum name '{expectedKey}'");
        
        // Remove unit if present
        string value = valueWithUnit;
        if (valueWithUnit.Contains("-"))
        {
            var valueParts = valueWithUnit.Split('-');
            value = valueParts[0];
        }
        
        // Find the matching enum member
        foreach (var enumValue in Enum.GetValues(enumType))
        {
            string generatedValue = GetLocalizedEnumValue(enumType, enumValue, languageCode);
            if (generatedValue == value)
            {
                return enumValue;
            }
        }
        
        throw new ArgumentException($"Could not find enum member matching value '{value}' in {enumType.Name}");
    }
    
    private static string GetLocalizedEnumName(Type enumType, string languageCode)
    {
        var localizedAttr = enumType.GetCustomAttribute<LocalizedEnumNameAttribute>();
        
        if (localizedAttr != null)
        {
            if (languageCode == "ar" && !string.IsNullOrEmpty(localizedAttr.Arabic))
                return localizedAttr.Arabic;
            else if (languageCode == "kr" && !string.IsNullOrEmpty(localizedAttr.Kurdish))
                return localizedAttr.Kurdish;
        }
        
        // Default: return enum type name
        return enumType.Name;
    }
    
    private static string GetLocalizedEnumValue(Type enumType, object enumValue, string languageCode)
    {
        string memberName = Enum.GetName(enumType, enumValue);
        var memberInfo = enumType.GetField(memberName);
        
        var displayAttr = memberInfo?.GetCustomAttribute<LanguageDisplayAttribute>();
        
        if (displayAttr != null)
        {
            if (languageCode == "ar" && !string.IsNullOrEmpty(displayAttr.Arabic))
                return displayAttr.Arabic;
            else if (languageCode == "kr" && !string.IsNullOrEmpty(displayAttr.Kurdish))
                return displayAttr.Kurdish;
        }
        
        // Check if EnumConverter attribute exists
        var hasEnumConverter = enumType.GetCustomAttribute<EnumConverterAttribute>() != null;
        
        if (hasEnumConverter)
        {
            // Return the member name as string
            return memberName;
        }
        else
        {
            // Return the numeric value
            return Convert.ToInt32(enumValue).ToString();
        }
    }
    
    private static string GetLocalizedUnit(Type enumType, string languageCode)
    {
        var unitAttr = enumType.GetCustomAttribute<GetUnitsAttribute>();
        
        if (unitAttr != null && !string.IsNullOrEmpty(unitAttr.Unit))
        {
            // Try to parse the unit as an enum member of Units
            if (Enum.TryParse(typeof(Units), unitAttr.Unit, out object unitEnum))
            {
                var unitMemberInfo = typeof(Units).GetField(unitAttr.Unit);
                var unitDisplayAttr = unitMemberInfo?.GetCustomAttribute<LanguageDisplayAttribute>();
                
                if (unitDisplayAttr != null)
                {
                    if (languageCode == "ar" && !string.IsNullOrEmpty(unitDisplayAttr.Arabic))
                        return unitDisplayAttr.Arabic;
                    else if (languageCode == "kr" && !string.IsNullOrEmpty(unitDisplayAttr.Kurdish))
                        return unitDisplayAttr.Kurdish;
                }
                
                // Default: return the unit string itself
                return unitAttr.Unit;
            }
        }
        
        return null;
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        Console.WriteLine("=== Enum Key-Value Generator ===\n");
        
        // Example 1: FuelType with Arabic
        Console.WriteLine("Example 1: FuelType.Gasoline with Arabic (ar)");
        string result1 = EnumKeyValueGenerator.GenerateKeyValuePair(typeof(FuelType), FuelType.Gasoline, "ar");
        Console.WriteLine(result1);
        Console.WriteLine();
        
        // Example 2: FuelType with Kurdish
        Console.WriteLine("Example 2: FuelType.Diesel with Kurdish (kr)");
        string result2 = EnumKeyValueGenerator.GenerateKeyValuePair(typeof(FuelType), FuelType.Diesel, "kr");
        Console.WriteLine(result2);
        Console.WriteLine();
        
        // Example 3: Weight with Arabic (has units and EnumConverter)
        Console.WriteLine("Example 3: Weight.Light with Arabic (ar)");
        string result3 = EnumKeyValueGenerator.GenerateKeyValuePair(typeof(Weight), Weight.Light, "ar");
        Console.WriteLine(result3);
        Console.WriteLine();
        
        // Example 4: Weight with Kurdish
        Console.WriteLine("Example 4: Weight.Heavy with Kurdish (kr)");
        string result4 = EnumKeyValueGenerator.GenerateKeyValuePair(typeof(Weight), Weight.Heavy, "kr");
        Console.WriteLine(result4);
        Console.WriteLine();
        
        // Example 5: Color (no attributes)
        Console.WriteLine("Example 5: Color.Red with Arabic (ar) - no attributes");
        string result5 = EnumKeyValueGenerator.GenerateKeyValuePair(typeof(Color), Color.Red, "ar");
        Console.WriteLine(result5);
        Console.WriteLine();
        
        // Example 6: All FuelType values in Arabic
        Console.WriteLine("Example 6: All FuelType values in Arabic");
        foreach (FuelType fuel in Enum.GetValues(typeof(FuelType)))
        {
            string result = EnumKeyValueGenerator.GenerateKeyValuePair(typeof(FuelType), fuel, "ar");
            Console.WriteLine(result);
        }
        Console.WriteLine();
        
        // Example 7: All Weight values in Kurdish
        Console.WriteLine("Example 7: All Weight values in Kurdish");
        foreach (Weight weight in Enum.GetValues(typeof(Weight)))
        {
            string result = EnumKeyValueGenerator.GenerateKeyValuePair(typeof(Weight), weight, "kr");
            Console.WriteLine(result);
        }
        Console.WriteLine();
        
        Console.WriteLine("=== Reverse Lookup (Parse Key-Value) ===\n");
        
        // Example 8: Parse Arabic FuelType
        Console.WriteLine("Example 8: Parse 'نوع-الوقود=بنزين' (Arabic)");
        var parsed1 = EnumKeyValueGenerator.ParseKeyValuePair(typeof(FuelType), "نوع-الوقود=بنزين", "ar");
        Console.WriteLine($"Result: {parsed1} (Type: {parsed1.GetType().Name})");
        Console.WriteLine();
        
        // Example 9: Parse Kurdish FuelType
        Console.WriteLine("Example 9: Parse 'جۆری-سووتەمەنی=دیزەل' (Kurdish)");
        var parsed2 = EnumKeyValueGenerator.ParseKeyValuePair(typeof(FuelType), "جۆری-سووتەمەنی=دیزەل", "kr");
        Console.WriteLine($"Result: {parsed2} (Type: {parsed2.GetType().Name})");
        Console.WriteLine();
        
        // Example 10: Parse Arabic Weight with unit
        Console.WriteLine("Example 10: Parse 'الوزن=Light-سم' (Arabic with unit)");
        var parsed3 = EnumKeyValueGenerator.ParseKeyValuePair(typeof(Weight), "الوزن=Light-سم", "ar");
        Console.WriteLine($"Result: {parsed3} (Type: {parsed3.GetType().Name})");
        Console.WriteLine();
        
        // Example 11: Parse Kurdish Weight with unit
        Console.WriteLine("Example 11: Parse 'کێش=Heavy-سم' (Kurdish with unit)");
        var parsed4 = EnumKeyValueGenerator.ParseKeyValuePair(typeof(Weight), "کێش=Heavy-سم", "kr");
        Console.WriteLine($"Result: {parsed4} (Type: {parsed4.GetType().Name})");
        Console.WriteLine();
        
        // Example 12: Parse Color (no attributes)
        Console.WriteLine("Example 12: Parse 'Color=0' (no attributes)");
        var parsed5 = EnumKeyValueGenerator.ParseKeyValuePair(typeof(Color), "Color=0", "ar");
        Console.WriteLine($"Result: {parsed5} (Type: {parsed5.GetType().Name})");
        Console.WriteLine();
        
        // Example 13: Round-trip test
        Console.WriteLine("Example 13: Round-trip test (Generate -> Parse)");
        string generated = EnumKeyValueGenerator.GenerateKeyValuePair(typeof(FuelType), FuelType.Electric, "ar");
        Console.WriteLine($"Generated: {generated}");
        var parsedBack = (FuelType)EnumKeyValueGenerator.ParseKeyValuePair(typeof(FuelType), generated, "ar");
        Console.WriteLine($"Parsed back: {parsedBack}");
        Console.WriteLine($"Match: {parsedBack == FuelType.Electric}");
    }
}