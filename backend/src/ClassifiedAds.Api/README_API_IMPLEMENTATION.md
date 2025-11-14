# Classified Ads API Implementation

## Overview
This API supports multilingual ad creation with Arabic (ar) and Kurdish (kr) languages. The language is automatically extracted from the URL path.

## URL Structure

```
POST {apiPrefix}/{lang}/{locationSlug}/categories/{categorySlug}/ads
```

### Examples

**Arabic:**
```
POST /api/ar/بغداد-baghdad/categories/الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/موبايلات-ذكية/ads
```

**Kurdish:**
```
POST /api/kr/هەولێر-erbil/categories/ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/مۆبایلی-زیرەک/ads
```

## Components

### 1. Language Middleware
**Location:** `backend/src/ClassifiedAds.Api/Middleware/LanguageMiddleware.cs`

Extracts language code from URL path and sets it in `LanguageContext.Current`.

**Pattern:** `/api/{lang}/...` where lang is `ar` or `kr`

### 2. Language Context
**Location:** `backend/src/ClassifiedAds.Application/Common/LanguageContext.cs`

Thread-safe storage for current request language. Used by FluentValidation validators to return localized messages.

### 3. Controllers

#### AdsController
**Location:** `backend/src/ClassifiedAds.Api/Controllers/AdsController.cs`

Specific endpoints for common categories with strongly-typed DTOs:
- Handheld devices (smartphones, tablets)
- Cars
- Houses
- CVs
- Services
- Books

#### DynamicAdsController
**Location:** `backend/src/ClassifiedAds.Api/Controllers/DynamicAdsController.cs`

Generic endpoint that accepts any category slug:
```
POST /api/{lang}/{locationSlug}/categories/{**categorySlug}/ads
```

Uses `CategoryDtoMapper` to determine the correct DTO type based on category slug.

### 4. Category DTO Mapper
**Location:** `backend/src/ClassifiedAds.Application/Services/CategoryDtoMapper.cs`

Maps category slugs to their corresponding DTO types. Maintains separate mappings for Arabic and Kurdish.

**Usage:**
```csharp
var dtoType = CategoryDtoMapper.GetDtoType(categorySlug, language);
```

### 5. Ad Service Interface
**Location:** `backend/src/ClassifiedAds.Application/Interfaces/IAdService.cs`

Generic interface for CRUD operations on ads:
```csharp
Task<string> CreateAdAsync<TDto>(TDto dto, string categorySlug, string locationSlug);
Task<TDto?> GetAdByIdAsync<TDto>(string id);
Task<bool> UpdateAdAsync<TDto>(string id, TDto dto);
Task<bool> DeleteAdAsync(string id);
```

## DTO Structure by Category

### Electronics - Handheld Devices
**DTO:** `CreateHandheldDeviceAdDto`

**Categories:**
- AR: `الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/موبايلات-ذكية`
- KR: `ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/مۆبایلی-زیرەک`

**Fields:**
- Title, Description, Price (from base)
- StorageCapacity, RamSize, Color
- MainCameraResolution, FrontCameraResolution
- BatteryCapacity, ScreenSize, Processor
- DualSim, WaterproofSupport, StylusSupport
- ModelId

### Vehicles - Cars
**DTO:** `CreateCarAdDto`

**Categories:**
- AR: `مركبات-ونقل/سيارات`
- KR: `ئۆتۆمبێل-و-گواستنەوە/ئۆتۆمبێل`

**Fields:**
- Title, Description, Price (from base)
- FuelType, EnginePower, FuelTankCapacity (from transport base)
- Distance, EngineDescription, Cylinders, Color

### Real Estate - Houses
**DTO:** `CreateHouseAdDto`

**Categories:**
- AR: `العقارات-والاملاك/عقارات-للبيع/سكني/منازل-وفلل/بيوت-عادية`
- KR: `خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/نیشتەجێبوون/ماڵ-و-ڤێلا/ماڵی-ئاسایی`

**Fields:**
- Title, Description, Price (from base)
- Area (from real estate base)
- Floors, Bedrooms, Bathrooms

## Validation

All validators support multilingual messages. The validation messages are automatically returned in the language specified in the URL.

**Example validation error (Arabic):**
```json
{
  "errors": {
    "Title": ["العنوان مطلوب"],
    "Price": ["السعر يجب أن يكون أكبر من 0"]
  }
}
```

**Example validation error (Kurdish):**
```json
{
  "errors": {
    "Title": ["ناونیشان پێویستە"],
    "Price": ["نرخ دەبێت لە 0 زیاتر بێت"]
  }
}
```

## Swagger Documentation

Access Swagger UI at: `https://localhost:{port}/swagger`

The API documentation shows:
- All available endpoints
- Required fields for each category
- Example request/response bodies
- Validation rules

## Implementation Status

### ✅ Completed
- Language middleware
- Language context
- Controller structure
- Interface definitions
- Category DTO mapper
- Swagger configuration

### ⚠️ Pending Implementation
- AdService implementation with proper DTO-to-Entity mapping
- Category validation service
- Location validation service
- Slug generation service
- User authentication/authorization
- Image upload handling
- Dynamic DTO deserialization in DynamicAdsController

## Next Steps

1. **Implement AdService:**
   - DTO to Entity mapping (consider AutoMapper)
   - Category validation against database
   - Location validation against database
   - Slug generation logic
   - User context integration

2. **Add Category Service:**
   - Validate category slug exists
   - Get category metadata
   - Map category to DTO type

3. **Add Location Service:**
   - Validate location slug exists
   - Get location details

4. **Implement Authentication:**
   - JWT token validation
   - User context from token
   - Authorization policies

5. **Add Image Upload:**
   - File upload endpoint
   - Image validation
   - Storage service (local/cloud)

6. **Complete Dynamic Controller:**
   - Implement JSON to DTO deserialization
   - Use CategoryDtoMapper for type resolution
   - Handle all category types dynamically

## Testing

### Example cURL Request (Arabic - Smartphone)

```bash
curl -X POST "https://localhost:7001/api/ar/بغداد-baghdad/categories/الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/موبايلات-ذكية/ads" \
  -H "Content-Type: application/json" \
  -d '{
    "title": "آيفون 15 برو ماكس",
    "description": "جهاز جديد بالكرتون",
    "price": {
      "amount": 1500,
      "currency": "USD"
    },
    "storageCapacity": "Storage512GB",
    "ramSize": "Ram8GB",
    "color": "Black",
    "mainCameraResolution": 48.0,
    "frontCameraResolution": 12.0,
    "batteryCapacity": 4422,
    "screenSize": 6.7,
    "processor": "A17 Pro",
    "dualSim": "Yes",
    "waterproofSupport": "Yes",
    "stylusSupport": "No",
    "modelId": "guid-here"
  }'
```

### Example cURL Request (Kurdish - Car)

```bash
curl -X POST "https://localhost:7001/api/kr/هەولێر-erbil/categories/ئۆتۆمبێل-و-گواستنەوە/ئۆتۆمبێل/ads" \
  -H "Content-Type: application/json" \
  -d '{
    "title": "تۆیۆتا کامری 2023",
    "description": "ئۆتۆمبێلی تازە",
    "price": {
      "amount": 35000,
      "currency": "USD"
    },
    "fuelType": "Gasoline",
    "enginePower": 203,
    "fuelTankCapacity": 60,
    "distance": 5000,
    "engineDescription": "2.5L 4-Cylinder",
    "cylinders": 4,
    "color": "White"
  }'
```

## Notes

- All endpoints require language code in URL (`ar` or `kr`)
- Location slug format: `{arabic-name}-{english-name}` or `{kurdish-name}-{english-name}`
- Category slugs must match exactly (case-sensitive)
- Validation messages are automatically localized based on URL language
- DTOs inherit from base classes (CreateAdDto, CreateTransportAdDto, etc.)
