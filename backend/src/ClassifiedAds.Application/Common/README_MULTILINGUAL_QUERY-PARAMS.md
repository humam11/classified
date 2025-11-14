# Multilingual System Documentation

## Overview

This system provides:
1. **Localized Validation Messages** - Error messages in Arabic (ar) or Kurdish (kr)
2. **Enum Query String Generation** - Convert enums to SEO-friendly localized URLs
3. **Language Context** - Thread-safe language detection from URL

## Components

### 1. LanguageContext
**File:** `LanguageContext.cs`

Holds the current request language (ar/kr) using AsyncLocal for thread safety.

```csharp
// Set language from URL middleware
LanguageContext.CurrentLanguage = "ar"; // or "kr"

// Check current language
if (LanguageContext.IsArabic) { ... }
if (LanguageContext.IsKurdish) { ... }
```

### 2. ValidationMessages
**File:** `ValidationMessages.cs`

Provides localized validation error messages.

```csharp
// Usage in validators
RuleFor(x => x.Title)
    .NotEmpty().WithMessage(ValidationMessages.Required(ValidationMessages.Fields.Title))
    .MaximumLength(100).WithMessage(ValidationMessages.MaxLength(ValidationMessages.Fields.Title, 100));

// Arabic output: "العنوان مطلوب"
// Kurdish output: "ناونیشان پێویستە"
```

**Available Methods:**
- `Required(fieldName)` - Field is required
- `MaxLength(fieldName, max)` - Maximum length validation
- `MinLength(fieldName, min)` - Minimum length validation
- `GreaterThan(fieldName, value)` - Greater than validation
- `Between(fieldName, min, max)` - Range validation
- `InvalidEmail` - Email format error
- `InvalidEnum(enumName)` - Enum validation error

**Field Names:**
All common field names are available in `ValidationMessages.Fields`:
- Title, Description, Price, Category, Location, Images
- FirstName, LastName, Email, PhoneNumber
- Area, Pages, ModelId, etc.

### 3. EnumQueryStringHelper
**File:** `EnumQueryStringHelper.cs`

Converts enums to localized query strings for SEO-friendly URLs.

```csharp
// Convert enum to query string
var queryString = EnumQueryStringHelper.GetQueryString(JobType.FullTime, "ar");
// Result: "نوع-الوظيفة=دوام-كامل"

// Parse query string back to enum
var jobType = EnumQueryStringHelper.ParseQueryString<JobType>("نوع-الوظيفة=دوام-كامل", "ar");
// Result: JobType.FullTime

// Get all possible values for UI filters
var allOptions = EnumQueryStringHelper.GetAllQueryStrings<JobType>("ar");
// Result: Dictionary with all JobType values and their Arabic query strings
```

## Enum Attributes

### QueryKey Attribute
Applied to enum type to define localized key name.

```csharp
[QueryKey(ar = "نوع-الوظيفة", kr = "جۆری-کار")]
public enum JobType : byte
{
    FullTime,
    PartTime
}
```

### QueryValue Attribute
Applied to enum members to define localized values.

```csharp
public enum JobType : byte
{
    [QueryValue(ar = "دوام كامل", kr = "کاری تەواو")]
    FullTime,
    
    [QueryValue(ar = "دوام جزئي", kr = "کاری بەشێک لە کات")]
    PartTime
}
```

### GetUnits Attribute
For enums with numeric values that need units.

```csharp
[QueryKey(ar = "ذاكرة", kr = "بیرگە")]
[GetUnits("gb")]
public enum RamSize : byte
{
    Small = 4,
    Medium = 8,
    Large = 16
}

// Result: "ذاكرة=8-gb" (ignores QueryValue, uses numeric + unit)
```

## URL Structure Examples

### Arabic URLs
```
/ar/baghdad-بغداد/categories/electronics-الكترونيات/ads?نوع-الوظيفة=دوام-كامل&ذاكرة=8-gb
```

### Kurdish URLs
```
/kr/baghdad-بەغدا/categories/electronics-ئەلیکترۆنیات/ads?جۆری-کار=کاری-تەواو&بیرگە=8-gb
```

## Integration with API

### Middleware Setup
Create middleware to extract language from URL:

```csharp
public class LanguageMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Extract language from URL path
        var path = context.Request.Path.Value;
        if (path.StartsWith("/ar/"))
        {
            LanguageContext.CurrentLanguage = "ar";
        }
        else if (path.StartsWith("/kr/"))
        {
            LanguageContext.CurrentLanguage = "kr";
        }
        
        await next(context);
    }
}
```

### Controller Usage
```csharp
[HttpGet("{locationSlug}/categories/{categorySlug}/ads")]
public async Task<ActionResult<PagedResultDto<AdListItemDto>>> SearchAds(
    [FromQuery] AdSearchQueryDto query)
{
    // Language is already set by middleware
    // Validation messages will be in correct language
    // Enum parsing will use correct language
    
    return await _adService.SearchAsync(query);
}
```

## MongoDB Configuration

Enums are stored as strings in MongoDB (configured in `MongoDbConfiguration.cs`):

```json
{
  "jobType": "FullTime",
  "status": "Active"
}
```

This ensures:
- Database is language-independent
- Enum order changes don't break data
- Easy debugging and readability

## Testing

```csharp
[Fact]
public void Validator_WithArabicLanguage_ReturnsArabicMessages()
{
    // Arrange
    LanguageContext.CurrentLanguage = "ar";
    var validator = new CreateVacancyAdDtoValidator();
    var dto = new CreateVacancyAdDto { Title = "" };
    
    // Act
    var result = validator.Validate(dto);
    
    // Assert
    Assert.Contains("العنوان مطلوب", result.Errors[0].ErrorMessage);
}

[Fact]
public void EnumQueryString_WithArabic_ReturnsArabicQuery()
{
    // Arrange & Act
    var query = EnumQueryStringHelper.GetQueryString(JobType.FullTime, "ar");
    
    // Assert
    Assert.Equal("نوع-الوظيفة=دوام-كامل", query);
}
```

## Best Practices

1. **Always set language early** - Use middleware to set LanguageContext at request start
2. **Use ValidationMessages.Fields** - Don't hardcode field names
3. **Test both languages** - Ensure all enums have ar and kr translations
4. **Keep URLs lowercase** - System automatically converts to lowercase with hyphens
5. **Store enums as strings** - MongoDB configuration handles this automatically

## Future Enhancements

- Add English (en) support
- Cache translated messages for performance
- Add validation for missing translations
- Generate TypeScript types for frontend
