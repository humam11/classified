# Multilingual Enum System - Complete Guide

## Quick Overview

A C# system for generating and parsing localized enum values in Arabic and Kurdish with two output formats:
- **Query Parameter Format**: `نوع-الوقود=بنزين` (for URLs/APIs)
- **Display Format**: `بنزين` (for UI display)

---

## Core Concepts

### Two Output Formats

| Format | When to Use | Example | Separator |
|--------|-------------|---------|-----------|
| **Query Param** (`isQueryParam = true`) | URLs, API filtering | `نوع-الوقود=بنزين-لتر` | Hyphen `-` |
| **Display** (`isQueryParam = false`) | UI, showing to users | `بنزين لتر` | Space ` ` |

### Four Attributes

| Attribute | Target | Purpose |
|-----------|--------|---------|
| `[LocalizedEnumName]` | Enum Type | Localize enum name (key) |
| `[LanguageDisplay]` | Enum Member | Localize member value |
| `[GetUnits]` | Enum Type | Add unit suffix |
| `[EnumConverter]` | Enum Type | Use member names instead of numbers |

---

## API Reference

### Generate

```csharp
string result = EnumKeyValueGenerator.GenerateKeyValuePair(
    typeof(FuelType),      // Enum type
    FuelType.Gasoline,     // Enum value
    true,                  // isQueryParam: true=URL, false=Display
    "ar"                   // Language: "ar" or "kr"
);
```

**Examples:**
```csharp
// Query Parameter Format
GenerateKeyValuePair(typeof(FuelType), FuelType.Gasoline, true, "ar")
// → "نوع-الوقود=بنزين"

// Display Format
GenerateKeyValuePair(typeof(FuelType), FuelType.Gasoline, false, "ar")
// → "بنزين"

// With Units - Query
GenerateKeyValuePair(typeof(Weight), Weight.Light, true, "ar")
// → "الوزن=Light-سم"

// With Units - Display
GenerateKeyValuePair(typeof(Weight), Weight.Light, false, "ar")
// → "Light سم"
```

### Parse

```csharp
var fuel = (FuelType)EnumKeyValueGenerator.ParseKeyValuePair(
    typeof(FuelType),      // Enum type
    "نوع-الوقود=بنزين",    // String to parse
    true,                  // isQueryParam: must match generation format
    "ar"                   // Language code
);
```

**Examples:**
```csharp
// Parse Query Parameter
ParseKeyValuePair(typeof(FuelType), "نوع-الوقود=بنزين", true, "ar")
// → FuelType.Gasoline

// Parse Display
ParseKeyValuePair(typeof(FuelType), "بنزين", false, "ar")
// → FuelType.Gasoline
```

---

## Common Patterns

### Pattern 1: Fully Localized with Units
```csharp
[LocalizedEnumName(Arabic = "الوزن", Kurdish = "کێش")]
[GetUnits("kg")]
[EnumConverter]
public enum Weight : int
{
    [LanguageDisplay(Arabic = "خفيف", Kurdish = "سووک")]
    Light
}

// Query:   "الوزن=خفيف-كيلوغرام"
// Display: "خفيف كيلوغرام"
```

### Pattern 2: Localized Name and Values
```csharp
[LocalizedEnumName(Arabic = "نوع-الوقود", Kurdish = "جۆری-سووتەمەنی")]
public enum FuelType : byte
{
    [LanguageDisplay(Arabic = "بنزين", Kurdish = "بەنزین")]
    Gasoline
}

// Query:   "نوع-الوقود=بنزين"
// Display: "بنزين"
```

### Pattern 3: Boolean Values
```csharp
[EnumConverter]
public enum BooleanValue : byte
{
    [LanguageDisplay(Arabic = "لا", Kurdish = "نەخێر")]
    False = 0,
    [LanguageDisplay(Arabic = "نعم", Kurdish = "بەڵێ")]
    True = 1
}

// Query:   "BooleanValue=نعم"
// Display: "نعم"
```

### Pattern 4: Item Condition (Used/New)
```csharp
[LocalizedEnumName(Arabic = "الحالة", Kurdish = "دۆخ")]
[EnumConverter]
public enum ItemCondition : byte
{
    [LanguageDisplay(Arabic = "مستعمل", Kurdish = "بەکارهاتوو")]
    Used = 0,
    [LanguageDisplay(Arabic = "جديد", Kurdish = "نوێ")]
    New = 1
}

// Query:   "الحالة=مستعمل" (Arabic) or "دۆخ=بەکارهاتوو" (Kurdish)
// Display: "مستعمل" (Arabic) or "بەکارهاتوو" (Kurdish)
```

### Pattern 5: No Attributes (Default)
```csharp
public enum Color : int
{
    Red,    // = 0
    Green,  // = 1
    Blue    // = 2
}

// Query:   "Color=0"
// Display: "0"
```

---

## Real-World Usage

### API Controller (Always use Query Format)
```csharp
[HttpGet("products")]
public IActionResult GetProducts(string fuelType)
{
    // Parse from URL query parameter
    var fuel = (FuelType)EnumKeyValueGenerator.ParseKeyValuePair(
        typeof(FuelType), 
        fuelType,  // "نوع-الوقود=بنزين" from URL
        true,      // Query param format
        "ar"
    );
    
    // Filter products...
    return Ok(products);
}

// URL: GET /api/products?fuelType=نوع-الوقود=بنزين
```

### UI Service (Always use Display Format)
```csharp
public ProductDisplayModel GetProductDisplay(Product product)
{
    return new ProductDisplayModel
    {
        FuelType = EnumKeyValueGenerator.GenerateKeyValuePair(
            typeof(FuelType), 
            product.FuelType, 
            false,  // Display format
            "ar"
        ),  // Result: "بنزين"
        
        Weight = EnumKeyValueGenerator.GenerateKeyValuePair(
            typeof(Weight), 
            product.Weight, 
            false,  // Display format
            "ar"
        )   // Result: "Light سم"
    };
}

// UI shows: Fuel Type: بنزين | Weight: Light سم
```

### Building Filter URLs
```csharp
public string BuildFilterUrl(FuelType fuel, string language)
{
    string fuelParam = EnumKeyValueGenerator.GenerateKeyValuePair(
        typeof(FuelType), 
        fuel, 
        true,   // Query param format
        language
    );
    
    return $"/api/products?{fuelParam}";
    // Result: "/api/products?نوع-الوقود=بنزين"
}
```

---

## Decision Matrix

### Query Parameter Format Output

| Attributes | Output Example |
|------------|----------------|
| None | `Color=0` |
| `[LocalizedEnumName]` | `الوزن=0` |
| `[LanguageDisplay]` | `FuelType=بنزين` |
| `[EnumConverter]` | `Weight=Light` |
| `[GetUnits]` | `Weight=0-كيلوغرام` |
| `[EnumConverter]` + `[LanguageDisplay]` | `BooleanValue=نعم` |
| All attributes | `نوع-الوقود=بنزين-لتر` |

### Display Format Output

| Attributes | Output Example |
|------------|----------------|
| None | `0` |
| `[LanguageDisplay]` | `بنزين` |
| `[EnumConverter]` | `Light` |
| `[GetUnits]` | `0 كيلوغرام` |
| `[EnumConverter]` + `[LanguageDisplay]` | `نعم` |
| All attributes | `بنزين لتر` |

---

## Important Rules

### ✅ DO

1. **Use Query Format in Controllers**
   ```csharp
   // Always true for API/URL filtering
   GenerateKeyValuePair(typeof(FuelType), fuel, true, "ar")
   ```

2. **Use Display Format in UI**
   ```csharp
   // Always false for showing to users
   GenerateKeyValuePair(typeof(FuelType), fuel, false, "ar")
   ```

3. **Match Format for Round-Trip**
   ```csharp
   // Generate and parse with same format
   string generated = GenerateKeyValuePair(typeof(FuelType), fuel, true, "ar");
   var parsed = ParseKeyValuePair(typeof(FuelType), generated, true, "ar");
   ```

4. **Set UTF-8 Encoding**
   ```csharp
   Console.OutputEncoding = System.Text.Encoding.UTF8;
   ```

### ❌ DON'T

1. **Mix Formats**
   ```csharp
   // WRONG: Generate with query, parse with display
   string gen = GenerateKeyValuePair(typeof(FuelType), fuel, true, "ar");
   var parsed = ParseKeyValuePair(typeof(FuelType), gen, false, "ar"); // ERROR!
   ```

2. **Use Display Format in URLs**
   ```csharp
   // WRONG: Missing key, ambiguous
   string url = $"/api/products?fuel={displayValue}"; // "بنزين" only
   ```

3. **Use Query Format in UI**
   ```csharp
   // WRONG: Shows redundant key to user
   // UI: "Fuel Type: نوع-الوقود=بنزين" (confusing)
   ```

---

## Format Comparison

### Visual Breakdown

**Query Parameter Format:**
```
نوع-الوقود=بنزين-لتر
│         │ │    │
│         │ │    └─ Unit (localized, spaces replaced with hyphens)
│         │ └────── Value (localized, spaces replaced with hyphens)
│         └──────── Separator (=)
└────────────────── Key (localized enum name)
```

**Display Format:**
```
بنزين لتر
│    │
│    └─ Unit (localized, with spaces)
└────── Value (localized, with spaces)
```

### Side-by-Side Examples

| Enum | Query Parameter | Display |
|------|----------------|---------|
| FuelType.Gasoline (ar) | `نوع-الوقود=بنزين` | `بنزين` |
| Weight.Light (ar) | `الوزن=Light-سم` | `Light سم` |
| BooleanValue.True (kr) | `BooleanValue=بەڵێ` | `بەڵێ` |
| ItemCondition.Used (ar) | `الحالة=مستعمل` | `مستعمل` |
| ItemCondition.New (kr) | `دۆخ=نوێ` | `نوێ` |
| Color.Red | `Color=0` | `0` |

---

## Helper Methods (Public)

```csharp
// Get localized enum name (key)
string key = EnumKeyValueGenerator.GetLocalizedEnumName(typeof(FuelType), "ar");
// → "نوع-الوقود"

// Get localized enum value
string value = EnumKeyValueGenerator.GetLocalizedEnumValue(typeof(FuelType), FuelType.Gasoline, "ar");
// → "بنزين"

// Get localized unit
string unit = EnumKeyValueGenerator.GetLocalizedUnit(typeof(Weight), "ar");
// → "كيلوغرام"
```

---

## Quick Reference

### Language Codes
- `"ar"` = Arabic (العربية)
- `"kr"` = Kurdish (کوردی)

### Available Units
```csharp
kg, ton, gram, liter, meter, kilometer, horsepower, cm, mm, gb, inch
```

### Method Signatures
```csharp
// Generate
public static string GenerateKeyValuePair(
    Type enumType, 
    object enumValue, 
    bool isQueryParam, 
    string languageCode
)

// Parse
public static object ParseKeyValuePair(
    Type enumType, 
    string keyValuePair, 
    bool isQueryParam, 
    string languageCode
)

// Backward compatible overloads (default to query param format)
public static string GenerateKeyValuePair(Type enumType, object enumValue, string languageCode)
public static object ParseKeyValuePair(Type enumType, string keyValuePair, string languageCode)
```

---

## Testing Checklist

- [ ] Test query parameter format for URL building
- [ ] Test display format for UI rendering
- [ ] Test round-trip conversion (generate → parse)
- [ ] Test with units (both formats)
- [ ] Test without units
- [ ] Test boolean values
- [ ] Test with Arabic ("ar")
- [ ] Test with Kurdish ("kr")
- [ ] Test enums with no attributes
- [ ] Test enums with all attributes
- [ ] Verify UTF-8 encoding is set

---

## Summary

**Key Takeaway:** Use `isQueryParam = true` for APIs/URLs, `isQueryParam = false` for UI display.

**Format Differences:**
- Query: `key=value-unit` (includes key, hyphen separator, all spaces in value/unit replaced with hyphens)
- Display: `value unit` (value only, space separator, preserves spaces in value/unit)

**Best Practice:** Always match the format between generation and parsing for round-trip compatibility.

**Important Note:** In query parameter format, all spaces in localized values and units are automatically replaced with hyphens. For example, "كيلو غرام" becomes "كيلو-غرام" in URLs.
