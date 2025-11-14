# Multilingual Validation Messages

## Overview
This application supports multilingual validation messages in **Arabic (ar)** and **Kurdish (kr)** based on the language code provided in the URL path.

## Language Detection
The language code is extracted from the URL:
- Example: `{apiPrefix}/ar/baghdad-بغداد/categories/...` → Language: `ar`
- Example: `{apiPrefix}/kr/erbil-هەولێر/categories/...` → Language: `kr`

The `LanguageContext` class provides the current language context throughout the application.

## Implementation Summary

All validators in the `Ads` folder have been updated with multilingual support:
- **33 validators** updated with Arabic and Kurdish translations
- **User-facing messages** translated (field validations, business rules)
- **Server-side messages** kept in English (IDs, technical errors)
- **Enum validations** handled separately (not translated in validators)

## Validation Message Strategy

### User-Facing Messages (Translated)
Messages that users will see are translated into Arabic and Kurdish:
- Field validation errors (required, max length, between, etc.)
- Business rule violations
- Format errors (email, phone, etc.)

**Example:**
```csharp
RuleFor(x => x.Color)
    .NotEmpty().WithMessage(GetMessage(
        // Color is required
        "اللون مطلوب",
        "ڕەنگ پێویستە"))
    .MaximumLength(50).WithMessage(GetMessage(
        // Color must not exceed 50 characters
        "يجب ألا يتجاوز اللون 50 حرفًا",
        "ڕەنگ نابێت لە 50 پیت زیاتر بێت"));
```

### Server-Side Messages (English Only)
Messages related to server-side errors or technical issues remain in English:
- ID validation errors (ModelId, CategoryId, etc.)
- Internal consistency checks
- Database constraint violations

**Example:**
```csharp
RuleFor(x => x.ModelId)
    .NotEmpty().WithMessage("Model ID is required"); // No translation needed
```

## Implementation Pattern

Each validator file contains its own message translation helper at the bottom:

```csharp
public class CreateCarAdDtoValidator : AbstractValidator<CreateCarAdDto>
{
    public CreateCarAdDtoValidator()
    {
        Include(new CreateTransportAdDtoValidator());

        RuleFor(x => x.Color)
            .NotEmpty().WithMessage(GetMessage(
                // Color is required
                "اللون مطلوب",
                "ڕەنگ پێویستە"));
    }

    private static string GetMessage(string ar, string kr)
    {
        return LanguageContext.Current == "ar" ? ar : kr;
    }
}
```

**Key Points:**
- English message as comment for developer reference
- Arabic and Kurdish as parameters (both always provided together)
- Simple ternary operator for language selection
- No fallback needed (URL always has ar or kr)

## Updated Validators

### Base Validators (3)
- `CreateAdDtoValidator` - Common ad validations (Title, Description, Price, Location, Images)
- `CreateTransportAdDtoValidator` - Vehicle base validations (FuelType, EnginePower, FuelTankCapacity)
- `CreateElectronicAdDtoValidator` - Electronics base validations (IsNew, WarrantyMonths)

### Vehicles (4)
- `CreateCarAdDtoValidator` - Distance, EngineDescription, Cylinders, Color
- `CreateBoatAdDtoValidator` - Length, Capacity
- `CreateMotorcycleAdDtoValidator` - GearCount
- `CreateTruckAdDtoValidator` - Distance, LoadCapacity, AxleCount

### Heavy Equipment (5)
- `CreateHeavyEquipmentAdDtoValidator` - OperatingMass, Weight
- `CreateBusAdDtoValidator` - SeatingCapacity
- `CreateBulldozerAdDtoValidator` - BladeWidth, MaxPushingCapacity, TrackWidth
- `CreateCraneAdDtoValidator` - LiftingCapacity, MaxLiftingHeight, BoomLength, RotationAngle
- `CreateExcavatorAdDtoValidator` - BucketCapacity, DiggingDepth

### Electronics (6)
- `CreateComputerAdDtoValidator` - CPU, GraphicsCard, UsbPorts, HdmiPorts
- `CreateConsoleAdDtoValidator` - (Only enum validations, no translations needed)
- `CreateHandheldDeviceAdDtoValidator` - MainCameraResolution, FrontCameraResolution, BatteryCapacity, ScreenSize, Processor
- `CreateLaptopAdDtoValidator` - Cpu, GraphicsCard, UsbPorts, HdmiPorts, ScreenSize, Resolution
- `CreateTvMonitorAdDtoValidator` - ScreenSize, HdmiPorts, UsbPorts

### Real Estate (4)
- `CreateRealEstateAdDtoValidator` - Area
- `CreateApartmentAdDtoValidator` - Bedrooms, Bathrooms, FloorNumber
- `CreateHouseAdDtoValidator` - Floors, Bedrooms, Bathrooms
- `CreateConstructionProjectAdDtoValidator` - (Only enum validations, no translations needed)

### Jobs (3)
- `CreateCvAdDtoValidator` - FirstName, LastName, DateOfBirth, PhoneNumber, ContactEmail, ContactInfo
- `CreateVacancyAdDtoValidator` - ExperienceYears, MaxSalary
- `CreateServiceAdDtoValidator` - DailyAvailability, TimeSlots

### Miscellaneous (8)
- `CreateBookAdDtoValidator` - Pages
- `CreateClothAdDtoValidator` - (Only enum validations, no translations needed)
- `CreateEngineOilAdDtoValidator` - Volume
- `CreateFurnitureAdDtoValidator` - Length, Width, Height
- `CreatePlantAdDtoValidator` - Height
- `CreateShoeAdDtoValidator` - Size
- `CreateTireWheelAdDtoValidator` - Width, AspectRatio, RimDiameter
- `CreateVideoGameAdDtoValidator` - (Only enum validations, no translations needed)

### Common (1)
- `LocationDtoValidator` - Only the `Street` field translated
- `LocationNoStreetValidator` - Street null validation translated

## Translation Guidelines

### What to Translate
✅ Field names and labels
✅ Validation rules (required, max length, between)
✅ Business rules
✅ User instructions
✅ Format errors (email, phone)

### What NOT to Translate
❌ Technical IDs (ModelId, CategoryId, UserId, LocationId)
❌ Server-side errors
❌ Database constraint messages
❌ Internal system messages
❌ Enum validations (handled by separate enum system)

## Adding New Translations

When adding a new validator or validation rule:

1. Add `using ClassifiedAds.Application.Common;` at the top
2. Write validation with English comment and Arabic/Kurdish translations:
```csharp
RuleFor(x => x.FieldName)
    .NotEmpty().WithMessage(GetMessage(
        // English message for reference
        "Arabic translation",
        "Kurdish translation"));
```
3. Add the helper method at the bottom of the class:
```csharp
private static string GetMessage(string ar, string kr)
{
    return LanguageContext.Current == "ar" ? ar : kr;
}
```

## Language Context Usage

The `LanguageContext` class provides:
- `LanguageContext.Current` - Returns current language code ("ar", "kr")
- `LanguageContext.IsArabic` - Returns true if current language is Arabic
- `LanguageContext.IsKurdish` - Returns true if current language is Kurdish

This context is set by the API middleware based on the URL path.

## Notes

- All validators follow the same pattern for consistency
- English comments preserved for developer reference
- No centralized message file - each validator is self-contained
- Enum validations use separate system with QueryKey/QueryValue attributes
- Common validators (Price, Category, AdImage) not translated as they contain technical validations only
- Both Arabic and Kurdish translations are always provided together
