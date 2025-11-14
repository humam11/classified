# Architecture Flow Diagram

## Request Flow

```
┌─────────────────────────────────────────────────────────────────────┐
│  Client Request                                                      │
│  POST /api/ar/بغداد-baghdad/categories/                             │
│       الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/         │
│       موبايلات-ذكية/ads                                              │
│  Body: CreateHandheldDeviceAdDto                                     │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│  LanguageMiddleware                                                  │
│  - Extracts "ar" from URL path                                       │
│  - Sets LanguageContext.Current = "ar"                               │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│  ASP.NET Core Routing                                                │
│  - Matches route to AdsController.CreateHandheldDeviceAd()           │
│  - Or DynamicAdsController.CreateAd() for generic endpoint           │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│  Model Binding                                                       │
│  - Deserializes JSON to CreateHandheldDeviceAdDto                    │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│  FluentValidation                                                    │
│  - CreateHandheldDeviceAdDtoValidator runs                           │
│  - Uses LanguageContext.Current to return Arabic messages            │
│  - If validation fails, returns 400 with Arabic error messages       │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│  Controller Action                                                   │
│  - Receives validated DTO                                            │
│  - Extracts categorySlug and locationSlug                            │
│  - Calls IAdService.CreateAdAsync()                                  │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│  AdService.CreateAdAsync() [TO BE IMPLEMENTED]                       │
│  1. Validate category exists (ICategoryService)                      │
│  2. Validate location exists (ILocationService)                      │
│  3. Get user ID from authentication context                          │
│  4. Map DTO to Entity (consider AutoMapper)                          │
│  5. Generate unique slug                                             │
│  6. Set timestamps (CreatedAt, UpdatedAt)                            │
│  7. Set default status (e.g., Pending)                               │
│  8. Save to MongoDB                                                  │
│  9. Return ad ID                                                     │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│  MongoDB                                                             │
│  - Saves ad document to "ads" collection                             │
│  - Returns inserted document ID                                      │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│  Controller Response                                                 │
│  - Returns 201 Created                                               │
│  - Location header: /api/ar/بغداد-baghdad/categories/ads/{id}       │
│  - Body: { "id": "507f1f77bcf86cd799439011" }                        │
└─────────────────────────────────────────────────────────────────────┘
```

## Component Diagram

```
┌─────────────────────────────────────────────────────────────────────┐
│                         Presentation Layer                           │
│  ┌──────────────────┐  ┌──────────────────┐  ┌──────────────────┐  │
│  │  AdsController   │  │ DynamicAds       │  │ Language         │  │
│  │                  │  │ Controller       │  │ Middleware       │  │
│  │ - Specific       │  │ - Generic        │  │ - Extract lang   │  │
│  │   endpoints      │  │   catch-all      │  │ - Set context    │  │
│  └──────────────────┘  └──────────────────┘  └──────────────────┘  │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│                        Application Layer                             │
│  ┌──────────────────┐  ┌──────────────────┐  ┌──────────────────┐  │
│  │  IAdService      │  │ CategoryDto      │  │ Language         │  │
│  │                  │  │ Mapper           │  │ Context          │  │
│  │ - CreateAdAsync  │  │ - Map slug to    │  │ - Current lang   │  │
│  │ - GetAdByIdAsync │  │   DTO type       │  │ - IsArabic       │  │
│  │ - UpdateAdAsync  │  │                  │  │ - IsKurdish      │  │
│  │ - DeleteAdAsync  │  │                  │  │                  │  │
│  └──────────────────┘  └──────────────────┘  └──────────────────┘  │
│                                                                      │
│  ┌──────────────────────────────────────────────────────────────┐  │
│  │  FluentValidation Validators                                  │  │
│  │  - CreateHandheldDeviceAdDtoValidator                         │  │
│  │  - CreateCarAdDtoValidator                                    │  │
│  │  - CreateHouseAdDtoValidator                                  │  │
│  │  - ... (33 validators with multilingual support)              │  │
│  └──────────────────────────────────────────────────────────────┘  │
│                                                                      │
│  ┌──────────────────────────────────────────────────────────────┐  │
│  │  DTOs                                                          │  │
│  │  - CreateAdDto (base)                                          │  │
│  │  - CreateElectronicAdDto (base)                                │  │
│  │  - CreateHandheldDeviceAdDto                                   │  │
│  │  - CreateCarAdDto                                              │  │
│  │  - ... (30+ DTOs)                                              │  │
│  └──────────────────────────────────────────────────────────────┘  │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│                          Domain Layer                                │
│  ┌──────────────────────────────────────────────────────────────┐  │
│  │  Entities                                                      │  │
│  │  - Ad (base)                                                   │  │
│  │  - Electronic (base)                                           │  │
│  │  - HandheldDevice                                              │  │
│  │  - Car                                                         │  │
│  │  - ... (30+ entities)                                          │  │
│  └──────────────────────────────────────────────────────────────┘  │
│                                                                      │
│  ┌──────────────────────────────────────────────────────────────┐  │
│  │  Value Objects                                                 │  │
│  │  - Price                                                       │  │
│  │  - Category                                                    │  │
│  │  - LocationAd                                                  │  │
│  │  - AdImage                                                     │  │
│  └──────────────────────────────────────────────────────────────┘  │
│                                                                      │
│  ┌──────────────────────────────────────────────────────────────┐  │
│  │  Enums                                                         │  │
│  │  - Status, Currency, FuelType, Color, etc.                     │  │
│  └──────────────────────────────────────────────────────────────┘  │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│                      Infrastructure Layer                            │
│  ┌──────────────────┐  ┌──────────────────┐  ┌──────────────────┐  │
│  │  AdService       │  │ MongoDbContext   │  │ ClassifiedDb     │  │
│  │  Implementation  │  │                  │  │ Context          │  │
│  │                  │  │ - MongoDB        │  │ (PostgreSQL)     │  │
│  │ - Map DTO to     │  │   connection     │  │                  │  │
│  │   Entity         │  │ - Collections    │  │ - Users          │  │
│  │ - Save to DB     │  │                  │  │ - Categories     │  │
│  │                  │  │                  │  │ - Locations      │  │
│  └──────────────────┘  └──────────────────┘  └──────────────────┘  │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│                          Data Storage                                │
│  ┌──────────────────┐                      ┌──────────────────┐     │
│  │  MongoDB         │                      │  PostgreSQL      │     │
│  │                  │                      │                  │     │
│  │ - ads collection │                      │ - users table    │     │
│  │   (documents)    │                      │ - categories     │     │
│  │                  │                      │ - locations      │     │
│  │                  │                      │ - models         │     │
│  └──────────────────┘                      └──────────────────┘     │
└─────────────────────────────────────────────────────────────────────┘
```

## Language Context Flow

```
┌─────────────────────────────────────────────────────────────────────┐
│  URL: /api/ar/بغداد-baghdad/categories/.../ads                      │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│  LanguageMiddleware                                                  │
│  Regex: ^/(?:api/)?(?<lang>ar|kr)/                                  │
│  Extracts: "ar"                                                      │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│  LanguageContext.Current = "ar"                                      │
│  (Thread-safe AsyncLocal storage)                                    │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│  Validator.GetMessage(ar, kr)                                        │
│  Returns: ar (because LanguageContext.Current == "ar")               │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│  Validation Error Response                                           │
│  { "Title": ["العنوان مطلوب"] }                                      │
└─────────────────────────────────────────────────────────────────────┘
```

## Category Slug to DTO Mapping

```
┌─────────────────────────────────────────────────────────────────────┐
│  Category Slug (Arabic)                                              │
│  "الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/             │
│   موبايلات-ذكية"                                                     │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│  CategoryDtoMapper.GetDtoType(categorySlug, "ar")                    │
│  Looks up in _arabicCategoryMap                                      │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│  Returns: typeof(CreateHandheldDeviceAdDto)                          │
└─────────────────────────────────────────────────────────────────────┘
                                    │
                                    ▼
┌─────────────────────────────────────────────────────────────────────┐
│  Controller uses this type for:                                      │
│  - Model binding                                                     │
│  - Validation                                                        │
│  - Service call                                                      │
└─────────────────────────────────────────────────────────────────────┘
```

## DTO Inheritance Hierarchy

```
CreateAdDto (base)
├── Title
├── Description
├── Price
├── Category
├── LocationAd
└── Images

    ├── CreateElectronicAdDto
    │   ├── IsNew
    │   └── WarrantyMonths
    │       ├── CreateHandheldDeviceAdDto
    │       │   ├── StorageCapacity
    │       │   ├── RamSize
    │       │   ├── MainCameraResolution
    │       │   └── ...
    │       ├── CreateLaptopAdDto
    │       ├── CreateComputerAdDto
    │       └── CreateTvMonitorAdDto
    │
    ├── CreateTransportAdDto
    │   ├── FuelType
    │   ├── EnginePower
    │   └── FuelTankCapacity
    │       ├── CreateCarAdDto
    │       │   ├── Distance
    │       │   ├── Cylinders
    │       │   └── Color
    │       ├── CreateMotorcycleAdDto
    │       └── CreateTruckAdDto
    │
    ├── CreateRealEstateAdDto
    │   └── Area
    │       ├── CreateHouseAdDto
    │       │   ├── Floors
    │       │   ├── Bedrooms
    │       │   └── Bathrooms
    │       └── CreateApartmentAdDto
    │
    └── CreateServiceAdDto
        ├── DailyAvailability
        └── TimeSlots
```

## Validation Flow

```
Request with CreateHandheldDeviceAdDto
            │
            ▼
┌───────────────────────────────────────┐
│ CreateHandheldDeviceAdDtoValidator    │
│ Include(CreateElectronicAdDtoValidator)│
└───────────────────────────────────────┘
            │
            ▼
┌───────────────────────────────────────┐
│ CreateElectronicAdDtoValidator        │
│ Include(CreateAdDtoValidator)         │
└───────────────────────────────────────┘
            │
            ▼
┌───────────────────────────────────────┐
│ CreateAdDtoValidator                  │
│ - Title validation                    │
│ - Description validation              │
│ - Price validation                    │
│ - Category validation                 │
│ - Location validation                 │
│ - Images validation                   │
└───────────────────────────────────────┘
            │
            ▼
All validators use GetMessage(ar, kr)
to return localized error messages
```

## Key Design Decisions

1. **Language in URL Path**: Makes language explicit and easy to extract
2. **Thread-Safe Context**: AsyncLocal ensures language is isolated per request
3. **Generic Service Interface**: Supports all DTO types without code duplication
4. **Category Slug Mapping**: Centralized mapping for easy maintenance
5. **DTO Inheritance**: Reduces code duplication and ensures consistency
6. **Validator Composition**: Reuses base validators through Include()
7. **Multilingual Validation**: Each validator contains all language messages
8. **Catch-All Routing**: Supports any category slug dynamically
