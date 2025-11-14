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
[GetUnits("kg")]
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

/// <summary>
/// Boolean enum for yes/no values with localized display.
/// Demonstrates: [EnumConverter] + [LanguageDisplay] for boolean-like values
/// Output format: "BooleanValue=نعم" (Arabic) or "BooleanValue=بەڵێ" (Kurdish)
/// </summary>
[EnumConverter]
public enum BooleanValue : byte
{
    [LanguageDisplay(Arabic = "لا", Kurdish = "نەخێر")]
    False = 0,
    [LanguageDisplay(Arabic = "نعم", Kurdish = "بەڵێ")]
    True = 1
}

/// <summary>
/// Condition enum for used/new items with localized display.
/// Demonstrates: [LocalizedEnumName] + [EnumConverter] + [LanguageDisplay] for condition values
/// Output format: "الحالة=مستعمل" (Arabic) or "دۆخ=بەکارهاتوو" (Kurdish)
/// </summary>
[LocalizedEnumName(Arabic = "الحالة", Kurdish = "دۆخ")]
[EnumConverter]
public enum ItemCondition : byte
{
    [LanguageDisplay(Arabic = "مستعمل", Kurdish = "بەکارهاتوو")]
    Used = 0,
    [LanguageDisplay(Arabic = "جديد", Kurdish = "نوێ")]
    New = 1
}

class EnumKeyValueGenerator
{
    public static string GenerateKeyValuePair(Type enumType, object enumValue, bool isQueryParam, string languageCode)
    {
        // Get the value (enum member)
        string value = GetLocalizedEnumValue(enumType, enumValue, languageCode);
        
        // Get the unit if exists
        string unit = GetLocalizedUnit(enumType, languageCode);
        
        if (isQueryParam)
        {
            // For query parameters: include key and use hyphens for spaces
            string key = GetLocalizedEnumName(enumType, languageCode);
            
            // Replace spaces with hyphens in value and unit for query params
            string queryValue = value.Replace(" ", "-");
            
            if (!string.IsNullOrEmpty(unit))
            {
                string queryUnit = unit.Replace(" ", "-");
                return $"{key}={queryValue}-{queryUnit}";
            }
            else
            {
                return $"{key}={queryValue}";
            }
        }
        else
        {
            // For display: only value and unit with space
            if (!string.IsNullOrEmpty(unit))
            {
                return $"{value} {unit}";
            }
            else
            {
                return value;
            }
        }
    }
    
    // Overload for backward compatibility
    public static string GenerateKeyValuePair(Type enumType, object enumValue, string languageCode)
    {
        return GenerateKeyValuePair(enumType, enumValue, true, languageCode);
    }
    
    public static object ParseKeyValuePair(Type enumType, string keyValuePair, bool isQueryParam, string languageCode)
    {
        if (isQueryParam)
        {
            // Parse query parameter format: key=value or key=value-unit
            var parts = keyValuePair.Split('=');
            if (parts.Length != 2)
                throw new ArgumentException("Invalid key-value pair format. Expected format: key=value or key=value-unit");
            
            string key = parts[0];
            string valueWithUnit = parts[1];
            
            // Verify the key matches the enum type
            string expectedKey = GetLocalizedEnumName(enumType, languageCode);
            if (key != expectedKey)
                throw new ArgumentException($"Key '{key}' does not match expected enum name '{expectedKey}'");
            
            // Get the unit to determine how many parts belong to it
            string expectedUnit = GetLocalizedUnit(enumType, languageCode);
            string value = valueWithUnit;
            
            if (!string.IsNullOrEmpty(expectedUnit))
            {
                // Count hyphens in the expected unit to know how many parts belong to it
                int unitHyphenCount = expectedUnit.Replace(" ", "-").Split('-').Length;
                
                // Split the valueWithUnit and separate value from unit
                var allParts = valueWithUnit.Split('-');
                
                if (allParts.Length > unitHyphenCount)
                {
                    // Take all parts except the last unitHyphenCount parts as the value
                    int valueParts = allParts.Length - unitHyphenCount;
                    value = string.Join("-", allParts.Take(valueParts));
                }
            }
            
            // Convert hyphens back to spaces for matching
            string valueForMatching = value.Replace("-", " ");
            
            // Find the matching enum member
            foreach (var enumValue in Enum.GetValues(enumType))
            {
                string generatedValue = GetLocalizedEnumValue(enumType, enumValue, languageCode);
                if (generatedValue == valueForMatching)
                {
                    return enumValue;
                }
            }
            
            throw new ArgumentException($"Could not find enum member matching value '{valueForMatching}' in {enumType.Name}");
        }
        else
        {
            // Parse display format: value or value unit (space separated)
            string value = keyValuePair;
            
            // Get the unit to determine how many words belong to it
            string expectedUnit = GetLocalizedUnit(enumType, languageCode);
            
            if (!string.IsNullOrEmpty(expectedUnit))
            {
                // Count words in the expected unit
                int unitWordCount = expectedUnit.Split(' ').Length;
                
                // Split the keyValuePair and separate value from unit
                var allParts = keyValuePair.Split(' ');
                
                if (allParts.Length > unitWordCount)
                {
                    // Take all parts except the last unitWordCount parts as the value
                    int valueParts = allParts.Length - unitWordCount;
                    value = string.Join(" ", allParts.Take(valueParts));
                }
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
    }
    
    // Overload for backward compatibility (defaults to query param format)
    public static object ParseKeyValuePair(Type enumType, string keyValuePair, string languageCode)
    {
        return ParseKeyValuePair(enumType, keyValuePair, true, languageCode);
    }
    
    public static string GetLocalizedEnumName(Type enumType, string languageCode)
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
    
    public static string GetLocalizedEnumValue(Type enumType, object enumValue, string languageCode)
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
    
    public static string GetLocalizedUnit(Type enumType, string languageCode)
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
        
        Console.WriteLine("=== Multilingual Enum System - Comprehensive Examples ===\n");
        
        // Example 1: FuelType (LocalizedEnumName + LanguageDisplay)
        Console.WriteLine("1. FuelType - Localized name and values");
        Console.WriteLine($"   Query:   {EnumKeyValueGenerator.GenerateKeyValuePair(typeof(FuelType), FuelType.Gasoline, true, "ar")}");
        Console.WriteLine($"   Display: {EnumKeyValueGenerator.GenerateKeyValuePair(typeof(FuelType), FuelType.Gasoline, false, "ar")}");
        Console.WriteLine($"   Parse:   {EnumKeyValueGenerator.ParseKeyValuePair(typeof(FuelType), "نوع-الوقود=بنزين", true, "ar")}\n");
        
        // Example 2: Weight (LocalizedEnumName + GetUnits + EnumConverter)
        Console.WriteLine("2. Weight - With units and EnumConverter");
        Console.WriteLine($"   Query:   {EnumKeyValueGenerator.GenerateKeyValuePair(typeof(Weight), Weight.Light, true, "ar")}");
        Console.WriteLine($"   Display: {EnumKeyValueGenerator.GenerateKeyValuePair(typeof(Weight), Weight.Light, false, "ar")}");
        Console.WriteLine($"   Parse Query:   {EnumKeyValueGenerator.ParseKeyValuePair(typeof(Weight), "الوزن=Light-كيلوغرام", true, "ar")}");
        Console.WriteLine($"   Parse Display: {EnumKeyValueGenerator.ParseKeyValuePair(typeof(Weight), "Light كيلوغرام", false, "ar")}\n");
        
        // Example 3: BooleanValue (EnumConverter + LanguageDisplay)
        Console.WriteLine("3. BooleanValue - Boolean with localized values");
        Console.WriteLine($"   Query:   {EnumKeyValueGenerator.GenerateKeyValuePair(typeof(BooleanValue), BooleanValue.True, true, "ar")}");
        Console.WriteLine($"   Display: {EnumKeyValueGenerator.GenerateKeyValuePair(typeof(BooleanValue), BooleanValue.True, false, "ar")}");
        Console.WriteLine($"   Parse:   {EnumKeyValueGenerator.ParseKeyValuePair(typeof(BooleanValue), "BooleanValue=نعم", true, "ar")}\n");
        
        // Example 4: ItemCondition (LocalizedEnumName + EnumConverter + LanguageDisplay)
        Console.WriteLine("4. ItemCondition - Used/New with full localization");
        Console.WriteLine($"   Query:   {EnumKeyValueGenerator.GenerateKeyValuePair(typeof(ItemCondition), ItemCondition.Used, true, "ar")}");
        Console.WriteLine($"   Display: {EnumKeyValueGenerator.GenerateKeyValuePair(typeof(ItemCondition), ItemCondition.Used, false, "ar")}");
        Console.WriteLine($"   Parse:   {EnumKeyValueGenerator.ParseKeyValuePair(typeof(ItemCondition), "الحالة=مستعمل", true, "ar")}\n");
        
        // Example 5: Color (No attributes - default behavior)
        Console.WriteLine("5. Color - No attributes (numeric values)");
        Console.WriteLine($"   Query:   {EnumKeyValueGenerator.GenerateKeyValuePair(typeof(Color), Color.Red, true, "ar")}");
        Console.WriteLine($"   Display: {EnumKeyValueGenerator.GenerateKeyValuePair(typeof(Color), Color.Red, false, "ar")}");
        Console.WriteLine($"   Parse:   {EnumKeyValueGenerator.ParseKeyValuePair(typeof(Color), "Color=0", true, "ar")}\n");
        
        // Example 6: Kurdish language
        Console.WriteLine("6. Kurdish Language Example");
        Console.WriteLine($"   Query:   {EnumKeyValueGenerator.GenerateKeyValuePair(typeof(ItemCondition), ItemCondition.New, true, "kr")}");
        Console.WriteLine($"   Display: {EnumKeyValueGenerator.GenerateKeyValuePair(typeof(ItemCondition), ItemCondition.New, false, "kr")}");
        Console.WriteLine($"   Parse:   {EnumKeyValueGenerator.ParseKeyValuePair(typeof(ItemCondition), "دۆخ=نوێ", true, "kr")}\n");
        
        // Example 7: Round-trip test
        Console.WriteLine("7. Round-trip Test (Generate → Parse → Match)");
        var original = FuelType.Electric;
        var generated = EnumKeyValueGenerator.GenerateKeyValuePair(typeof(FuelType), original, true, "ar");
        var parsed = (FuelType)EnumKeyValueGenerator.ParseKeyValuePair(typeof(FuelType), generated, true, "ar");
        Console.WriteLine($"   Original:  {original}");
        Console.WriteLine($"   Generated: {generated}");
        Console.WriteLine($"   Parsed:    {parsed}");
        Console.WriteLine($"   Match:     {original == parsed}");
    }
}