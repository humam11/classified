# Quick Start Guide

## Prerequisites

- .NET 9.0 SDK
- MongoDB (running locally or connection string)
- PostgreSQL (running locally or connection string)

## Setup

### 1. Configure Connection Strings

Edit `backend/src/ClassifiedAds.Api/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "PostgreSQL": "Host=localhost;Database=ClassifiedAdsDb;Username=postgres;Password=yourpassword",
    "MongoDB": "mongodb://localhost:27017"
  },
  "MongoDB": {
    "DatabaseName": "ClassifiedAdsDb"
  }
}
```

### 2. Restore Packages

```bash
cd backend/src/ClassifiedAds.Api
dotnet restore
```

### 3. Run the Application

```bash
dotnet run
```

The API will start at:
- HTTPS: `https://localhost:7001`
- HTTP: `http://localhost:5000`

### 4. Access Swagger UI

Open your browser and navigate to:
```
https://localhost:7001/swagger
```

## Testing the API

### Example 1: Create a Smartphone Ad (Arabic)

**Endpoint:**
```
POST /api/ar/بغداد-baghdad/categories/الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/موبايلات-ذكية/ads
```

**Request Body:**
```json
{
  "title": "آيفون 15 برو ماكس",
  "description": "جهاز جديد بالكرتون، لم يستخدم",
  "price": {
    "amount": 1500,
    "currency": "USD"
  },
  "category": {
    "id": "00000000-0000-0000-0000-000000000001",
    "name": "موبايلات ذكية"
  },
  "locationAd": {
    "locationId": "00000000-0000-0000-0000-000000000001",
    "street": "شارع الكرادة"
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

### Example 2: Create a Car Ad (Kurdish)

**Endpoint:**
```
POST /api/kr/هەولێر-erbil/categories/ئۆتۆمبێل-و-گواستنەوە/ئۆتۆمبێل/ads
```

**Request Body:**
```json
{
  "title": "تۆیۆتا کامری 2023",
  "description": "ئۆتۆمبێلی تازە، بەکارنەهاتوو",
  "price": {
    "amount": 35000,
    "currency": "USD"
  },
  "category": {
    "id": "00000000-0000-0000-0000-000000000002",
    "name": "ئۆتۆمبێل"
  },
  "locationAd": {
    "locationId": "00000000-0000-0000-0000-000000000002",
    "street": "شەقامی 100 مەتری"
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

### Example 3: Validation Error (Missing Required Field)

**Request:**
```json
{
  "description": "جهاز جديد",
  "price": {
    "amount": 1500,
    "currency": "USD"
  }
}
```

**Response (Arabic):**
```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Title": ["العنوان مطلوب"]
  }
}
```

**Response (Kurdish):**
```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Title": ["ناونیشان پێویستە"]
  }
}
```

## Available Endpoints

### Specific Category Endpoints

1. **Handheld Devices (Smartphones/Tablets)**
   - AR: `/api/ar/{locationSlug}/categories/الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/موبايلات-ذكية/ads`
   - KR: `/api/kr/{locationSlug}/categories/ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/مۆبایلی-زیرەک/ads`

2. **Cars**
   - AR: `/api/ar/{locationSlug}/categories/مركبات-ونقل/سيارات/ads`
   - KR: `/api/kr/{locationSlug}/categories/ئۆتۆمبێل-و-گواستنەوە/ئۆتۆمبێل/ads`

3. **Houses**
   - AR: `/api/ar/{locationSlug}/categories/العقارات-والاملاك/عقارات-للبيع/سكني/منازل-وفلل/بيوت-عادية/ads`
   - KR: `/api/kr/{locationSlug}/categories/خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/نیشتەجێبوون/ماڵ-و-ڤێلا/ماڵی-ئاسایی/ads`

4. **CVs**
   - AR: `/api/ar/{locationSlug}/categories/الوظائف-وفرص-العمل/ابحث-عن-موظف/البناء-والتشييد-والانشاءات/عامل-بناء/ads`
   - KR: `/api/kr/{locationSlug}/categories/کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/بیناسازی-و-ئاوەدانکردنەوە/کرێکاری-بیناسازی/ads`

5. **Services**
   - AR: `/api/ar/{locationSlug}/categories/الخدمات/خدمات-المركبات/تصليح-وصيانة-السيارات/ads`
   - KR: `/api/kr/{locationSlug}/categories/خزمەتگوزارییەکان/خزمەتگوزاری-ئۆتۆمبێل/چاککردنەوە-و-سیانەی-ئۆتۆمبێل/ads`

6. **Books**
   - AR: `/api/ar/{locationSlug}/categories/الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/كتب-دينية-واسلامية/ads`
   - KR: `/api/kr/{locationSlug}/categories/خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/کتێبی-ئایینی-و-ئیسلامی/ads`

### Generic Endpoint

**Any Category:**
```
POST /api/{lang}/{locationSlug}/categories/{**categorySlug}/ads
```

This endpoint accepts any category slug and dynamically determines the DTO type.

## Common Issues

### Issue: "AdService.CreateAdAsync needs to be implemented"

**Solution:** The AdService is currently a stub. You need to implement the actual logic for:
- Mapping DTOs to entities
- Validating categories and locations
- Generating slugs
- Saving to MongoDB

### Issue: Validation errors not in correct language

**Solution:** Make sure:
1. Language code is in the URL (`ar` or `kr`)
2. LanguageMiddleware is registered in Program.cs
3. Validators use the `GetMessage()` helper method

### Issue: Category not found

**Solution:** Check that:
1. Category slug matches exactly (case-sensitive)
2. Category is added to `CategoryDtoMapper`
3. Both Arabic and Kurdish slugs are present

## Next Steps

1. Implement AdService with proper mapping logic
2. Add authentication/authorization
3. Implement category and location validation services
4. Add image upload functionality
5. Add search and filtering endpoints
6. Add unit and integration tests

## Documentation

- Full API Documentation: `backend/src/ClassifiedAds.Api/README_API_IMPLEMENTATION.md`
- Adding Categories Guide: `backend/src/ClassifiedAds.Api/ADDING_NEW_CATEGORIES.md`
- Implementation Summary: `backend/IMPLEMENTATION_SUMMARY.md`
- Validation Guide: `backend/src/ClassifiedAds.Application/Validators/README_MULTILINGUAL_VALIDATION.md`

## Support

For issues or questions, refer to the documentation files or check the code comments.
