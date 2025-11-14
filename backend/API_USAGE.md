# API Usage Guide

## Overview

The API now uses a single dynamic endpoint that automatically determines the correct DTO based on the category slug.

## Endpoint

```
POST /api/{lang}/{locationSlug}/categories/{categorySlug}/ads
```

### Parameters

- `lang`: Language code (`ar` for Arabic, `kr` for Kurdish)
- `locationSlug`: Location identifier (e.g., `بغداد-baghdad`, `هەولێر-erbil`)
- `categorySlug`: Full category path (e.g., `مركبات-ونقل/سيارات`)

## How It Works

1. **Language Detection**: The middleware extracts the language from the URL
2. **Category Resolution**: The system looks up the category slug in the CategoryDtoMapper
3. **DTO Deserialization**: JSON is deserialized to the appropriate DTO type
4. **Validation**: FluentValidation validates the DTO with localized messages
5. **Persistence**: The ad is saved to MongoDB

## Examples

### Example 1: Create a Car Ad (Arabic)

**Endpoint:**
```
POST /api/ar/بغداد-baghdad/categories/مركبات-ونقل/سيارات/ads
```

**Request Body:**
```json
{
  "title": "تويوتا كامري 2023",
  "description": "سيارة نظيفة جداً",
  "price": {
    "amount": 35000,
    "currency": "USD"
  },
  "category": {
    "id": "00000000-0000-0000-0000-000000000001",
    "name": "سيارات"
  },
  "locationAd": {
    "locationId": "00000000-0000-0000-0000-000000000001",
    "street": "شارع الكرادة"
  },
  "fuelType": "Gasoline",
  "enginePower": 203,
  "fuelTankCapacity": 60,
  "distance": 5000,
  "engineDescription": "2.5L 4-Cylinder",
  "cylinders": 4,
  "color": "White",
  "images": []
}
```

**Response:**
```json
{
  "id": "507f1f77bcf86cd799439011"
}
```

### Example 2: Create a Smartphone Ad (Kurdish)

**Endpoint:**
```
POST /api/kr/هەولێر-erbil/categories/ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/مۆبایلی-زیرەک/ads
```

**Request Body:**
```json
{
  "title": "ئایفۆن 15 پرۆ ماکس",
  "description": "ئامێری نوێ، بە کارتۆن",
  "price": {
    "amount": 1500,
    "currency": "USD"
  },
  "category": {
    "id": "00000000-0000-0000-0000-000000000002",
    "name": "مۆبایلی زیرەک"
  },
  "locationAd": {
    "locationId": "00000000-0000-0000-0000-000000000002",
    "street": "شەقامی 100 مەتری"
  },
  "storageCapacity": "Storage512GB",
  "ramSize": "Ram8GB",
  "color": "Black",
  "mainCamera": "Yes",
  "frontCamera": "Yes",
  "mainCameraResolution": 48.0,
  "frontCameraResolution": 12.0,
  "batteryCapacity": 4422,
  "screenSize": 6.7,
  "processor": "A17 Pro",
  "dualSim": "Yes",
  "waterproofSupport": "Yes",
  "stylusSupport": "No",
  "isNew": "Yes",
  "warrantyMonths": 12,
  "modelId": "00000000-0000-0000-0000-000000000001",
  "images": []
}
```

### Example 3: Create a House Ad (Arabic)

**Endpoint:**
```
POST /api/ar/بغداد-baghdad/categories/العقارات-والاملاك/عقارات-للبيع/سكني/منازل-وفلل/بيوت-عادية/ads
```

**Request Body:**
```json
{
  "title": "بيت للبيع في الكرادة",
  "description": "بيت واسع مع حديقة",
  "price": {
    "amount": 250000,
    "currency": "USD"
  },
  "category": {
    "id": "00000000-0000-0000-0000-000000000003",
    "name": "بيوت عادية"
  },
  "locationAd": {
    "locationId": "00000000-0000-0000-0000-000000000001",
    "street": "شارع الكرادة"
  },
  "area": 300,
  "floors": 2,
  "bedrooms": 4,
  "bathrooms": 3,
  "images": []
}
```

## Validation Errors

Validation errors are returned in the language specified in the URL:

**Arabic Error Example:**
```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Title": ["العنوان مطلوب"],
    "Price.Amount": ["السعر يجب أن يكون أكبر من 0"]
  }
}
```

**Kurdish Error Example:**
```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Title": ["ناونیشان پێویستە"],
    "Price.Amount": ["نرخ دەبێت لە 0 زیاتر بێت"]
  }
}
```

## Supported Categories

The API supports **339 categories** in both Arabic and Kurdish. To see all supported categories:

- Arabic categories: See `Categories/Attributes-detection-transformed-ar.txt`
- Kurdish categories: See `Categories/Attributes-detection-transformed-kr.txt`

## Category to DTO Mapping

Each category slug is mapped to a specific DTO type. Examples:

| Arabic Slug | Kurdish Slug | DTO Type |
|-------------|--------------|----------|
| مركبات-ونقل/سيارات | ئۆتۆمبێل-و-گواستنەوە/ئۆتۆمبێل | CreateCarAdDto |
| الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/موبايلات-ذكية | ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/مۆبایلی-زیرەک | CreateHandheldDeviceAdDto |
| العقارات-والاملاك/عقارات-للبيع/سكني/منازل-وفلل/بيوت-عادية | خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/نیشتەجێبوون/ماڵ-و-ڤێلا/ماڵی-ئاسایی | CreateHouseAdDto |

## Swagger Documentation

Access Swagger UI at: `https://localhost:{port}/swagger`

Swagger will show:
- The single dynamic endpoint
- All possible request body structures based on category
- Validation rules
- Example requests and responses

## Testing with cURL

**Arabic Car Ad:**
```bash
curl -X POST "https://localhost:7001/api/ar/بغداد-baghdad/categories/مركبات-ونقل/سيارات/ads" \
  -H "Content-Type: application/json" \
  -d '{
    "title": "تويوتا كامري 2023",
    "description": "سيارة نظيفة",
    "price": { "amount": 35000, "currency": "USD" },
    "category": { "id": "00000000-0000-0000-0000-000000000001", "name": "سيارات" },
    "locationAd": { "locationId": "00000000-0000-0000-0000-000000000001", "street": "شارع الكرادة" },
    "fuelType": "Gasoline",
    "enginePower": 203,
    "fuelTankCapacity": 60,
    "distance": 5000,
    "engineDescription": "2.5L",
    "cylinders": 4,
    "color": "White",
    "images": []
  }'
```

## Error Responses

### Category Not Supported
```json
{
  "error": "Category not supported",
  "categorySlug": "invalid-category",
  "language": "ar",
  "message": "The category 'invalid-category' is not supported for language 'ar'"
}
```

### Invalid Language
```json
{
  "error": "Language must be 'ar' or 'kr'"
}
```

### Invalid JSON
```json
{
  "error": "Invalid JSON format",
  "details": "The JSON value could not be converted to System.String..."
}
```

## Notes

- No authentication required (as per your requirements)
- All ads are saved with `UserId = Guid.Empty` (can be updated later)
- Slugs are auto-generated from titles
- All timestamps are in UTC
- Default status is `Active`
- Default priority is `0`
