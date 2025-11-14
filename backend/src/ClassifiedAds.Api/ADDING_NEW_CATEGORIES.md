# Adding New Categories to the API

This guide explains how to add support for new ad categories.

## Step 1: Identify the Category

From the category mapping files:
- `Categories/Attributes-detection-transformed-ar.txt` (Arabic)
- `Categories/Attributes-detection-transformed-kr.txt` (Kurdish)

Find the category slug and corresponding DTO class name.

**Example:**
```
الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/موبايلات-ذكية -- CreateHandheldDeviceAdDto.cs
ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/مۆبایلی-زیرەک -- CreateHandheldDeviceAdDto.cs
```

## Step 2: Add to CategoryDtoMapper

Edit: `backend/src/ClassifiedAds.Application/Services/CategoryDtoMapper.cs`

Add entries to both `_arabicCategoryMap` and `_kurdishCategoryMap`:

```csharp
// In _arabicCategoryMap
["الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/موبايلات-ذكية"] = typeof(CreateHandheldDeviceAdDto),

// In _kurdishCategoryMap
["ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/مۆبایلی-زیرەک"] = typeof(CreateHandheldDeviceAdDto),
```

## Step 3: Add Controller Endpoint (Optional)

If you want a specific endpoint (recommended for common categories):

Edit: `backend/src/ClassifiedAds.Api/Controllers/AdsController.cs`

```csharp
[HttpPost("الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/موبايلات-ذكية/ads")]
[HttpPost("ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/مۆبایلی-زیرەک/ads")]
public async Task<ActionResult<string>> CreateHandheldDeviceAd(
    [FromRoute] string lang,
    [FromRoute] string locationSlug,
    [FromBody] CreateHandheldDeviceAdDto dto)
{
    try
    {
        var categorySlug = lang == "ar" 
            ? "الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/موبايلات-ذكية"
            : "ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/مۆبایلی-زیرەک";
        
        var adId = await _adService.CreateAdAsync(dto, categorySlug, locationSlug);
        return CreatedAtAction(nameof(GetAdById), new { id = adId }, adId);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error creating handheld device ad");
        return BadRequest(new { error = ex.Message });
    }
}
```

## Step 4: Test the Endpoint

### Using Swagger
1. Navigate to `https://localhost:{port}/swagger`
2. Find your endpoint
3. Click "Try it out"
4. Fill in the request body
5. Execute

### Using cURL

**Arabic:**
```bash
curl -X POST "https://localhost:7001/api/ar/بغداد-baghdad/categories/الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/موبايلات-ذكية/ads" \
  -H "Content-Type: application/json" \
  -d '{
    "title": "آيفون 15",
    "description": "جهاز جديد",
    "price": { "amount": 1500, "currency": "USD" },
    "storageCapacity": "Storage256GB",
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
    "modelId": "00000000-0000-0000-0000-000000000000"
  }'
```

**Kurdish:**
```bash
curl -X POST "https://localhost:7001/api/kr/هەولێر-erbil/categories/ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/مۆبایلی-زیرەک/ads" \
  -H "Content-Type: application/json" \
  -d '{
    "title": "ئایفۆن 15",
    "description": "ئامێری نوێ",
    "price": { "amount": 1500, "currency": "USD" },
    "storageCapacity": "Storage256GB",
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
    "modelId": "00000000-0000-0000-0000-000000000000"
  }'
```

## Complete Category List

### Electronics
- Handheld Devices (smartphones, tablets) → `CreateHandheldDeviceAdDto`
- Laptops → `CreateLaptopAdDto`
- Desktop Computers → `CreateComputerAdDto`
- TV/Monitors → `CreateTvMonitorAdDto`
- Gaming Consoles → `CreateConsoleAdDto`
- Video Games → `CreateVideoGameAdDto`
- Generic Electronics → `CreateElectronicAdDto`

### Vehicles
- Cars → `CreateCarAdDto`
- Motorcycles → `CreateMotorcycleAdDto`
- Trucks → `CreateTruckAdDto`
- Boats → `CreateBoatAdDto`
- Generic Transport → `CreateTransportAdDto`

### Heavy Equipment
- Bulldozers → `CreateBulldozerAdDto`
- Buses → `CreateBusAdDto`
- Cranes → `CreateCraneAdDto`
- Excavators → `CreateExcavatorAdDto`
- Generic Heavy Equipment → `CreateHeavyEquipmentAdDto`

### Real Estate
- Houses → `CreateHouseAdDto`
- Apartments → `CreateApartmentAdDto`
- Construction Projects → `CreateConstructionProjectAdDto`
- Generic Real Estate → `CreateRealEstateAdDto`

### Jobs & Services
- CVs → `CreateCvAdDto`
- Vacancies → `CreateVacancyAdDto`
- Services → `CreateServiceAdDto`

### Miscellaneous
- Books → `CreateBookAdDto`
- Clothes → `CreateClothAdDto`
- Furniture → `CreateFurnitureAdDto`
- Engine Oil → `CreateEngineOilAdDto`
- Plants → `CreatePlantAdDto`
- Shoes → `CreateShoeAdDto`
- Tires/Wheels → `CreateTireWheelAdDto`

## Notes

- Category slugs are case-sensitive
- Both Arabic and Kurdish slugs must be added
- The DTO type must already exist in the Application layer
- Validators should already be implemented with multilingual support
- The dynamic endpoint (`DynamicAdsController`) will work automatically once added to `CategoryDtoMapper`
