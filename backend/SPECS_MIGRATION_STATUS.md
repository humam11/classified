# Specs Migration Status

## Overview
Migrating all 31 ad types to use the Specs pattern where category-specific fields are grouped into a `Specs` object in GET responses.

## Progress: 10/31 DTOs Updated, 2/31 Mappers Updated

### ✅ Completed (DTOs + Mappers)
1. **Cv** - DTO ✅ Mapper ✅
2. **Service** - DTO ✅ Mapper ✅

### ✅ DTOs Updated (Mappers Pending)
3. **Book** - DTO ✅ Mapper ⏳
4. **Cloth** - DTO ✅ Mapper ⏳
5. **EngineOil** - DTO ✅ Mapper ⏳
6. **Furniture** - DTO ✅ Mapper ⏳
7. **Plant** - DTO ✅ Mapper ⏳
8. **Shoe** - DTO ✅ Mapper ⏳
9. **TireWheel** - DTO ✅ Mapper ⏳
10. **VideoGame** - DTO ✅ Mapper ⏳

### ⏳ Remaining (21/31)
11. Vacancy
12. Electronic
13. Computer
14. Laptop
15. HandheldDevice
16. TvMonitor
17. VideoConsole
18. RealEstate
19. Apartment
20. House
21. ConstructionProject
22. Transport
23. Boat
24. Car
25. Motorcycle
26. Truck
27. HeavyEquipment
28. Bulldozer
29. Bus
30. Crane
31. Excavator

## Mapper Update Pattern

For each mapper file, update the `MapToDto` method:

### Before:
```csharp
public static GetXxxAdDto MapToDto(Xxx entity)
{
    return new GetXxxAdDto
    {
        // Base fields...
        Id = entity.Id,
        Title = entity.Title,
        // ... other base fields
        
        // Category-specific fields directly on DTO
        Field1 = entity.Field1,
        Field2 = entity.Field2,
    };
}
```

### After:
```csharp
public static GetXxxAdDto MapToDto(Xxx entity)
{
    return new GetXxxAdDto
    {
        // Base fields...
        Id = entity.Id,
        Title = entity.Title,
        // ... other base fields
        
        // Category-specific fields grouped in Specs
        Specs = new XxxSpecsDto
        {
            Field1 = entity.Field1,
            Field2 = entity.Field2,
        }
    };
}
```

## Files to Update

### Miscellaneous Mappers (6 pending)
- `backend/src/ClassifiedAds.Application/Mappers/Miscellaneous/BookAdDtoMapper.cs`
- `backend/src/ClassifiedAds.Application/Mappers/Miscellaneous/ClothAdDtoMapper.cs`
- `backend/src/ClassifiedAds.Application/Mappers/Miscellaneous/EngineOilAdDtoMapper.cs`
- `backend/src/ClassifiedAds.Application/Mappers/Miscellaneous/FurnitureAdDtoMapper.cs`
- `backend/src/ClassifiedAds.Application/Mappers/Miscellaneous/PlantAdDtoMapper.cs`
- `backend/src/ClassifiedAds.Application/Mappers/Miscellaneous/ShoeAdDtoMapper.cs`
- `backend/src/ClassifiedAds.Application/Mappers/Miscellaneous/TireWheelAdDtoMapper.cs`
- `backend/src/ClassifiedAds.Application/Mappers/Miscellaneous/VideoGameAdDtoMapper.cs`

### All Other Categories (21 DTOs + 21 Mappers = 42 files)
See SPECS_MIGRATION_SCRIPT.md for complete list.

## Benefits

### Response Structure
```json
{
  "id": "123",
  "title": "Product Title",
  "description": "...",
  "price": { ... },
  "locationAd": { ... },
  "images": [ ... ],
  "status": 1,
  "createdAt": "2024-01-01T00:00:00Z",
  "updatedAt": "2024-01-01T00:00:00Z",
  "imageCount": 5,
  "viewsCount": 100,
  "priority": 0,
  "slug": "product-title",
  "category": { ... },
  "specs": {
    "field1": "value1",
    "field2": "value2"
  }
}
```

All category-specific fields are cleanly grouped under `specs`!
