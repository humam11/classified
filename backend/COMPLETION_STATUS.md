# GetXxxAdDto Migration - Completion Status

## ✅ FULLY COMPLETED (14/31 ad types)

### Jobs/Services (3/3) ✅
1. ✅ **Cv** - DTO + Mapper
2. ✅ **Service** - DTO + Mapper
3. ✅ **Vacancy** - DTO + Mapper

### Miscellaneous (8/8) ✅
4. ✅ **Book** - DTO + Mapper
5. ✅ **Cloth** - DTO + Mapper
6. ✅ **EngineOil** - DTO + Mapper
7. ✅ **Furniture** - DTO + Mapper
8. ✅ **Plant** - DTO + Mapper
9. ✅ **Shoe** - DTO + Mapper
10. ✅ **TireWheel** - DTO + Mapper
11. ✅ **VideoGame** - DTO + Mapper

### Electronics (3/6) 🔄
12. ✅ **Electronic** - DTO Done (Base class)
13. ✅ **Computer** - DTO Done
14. ✅ **Laptop** - DTO Done

## 🔄 IN PROGRESS (3/31 ad types)

### Electronics - DTOs Done, Mappers Pending
- **HandheldDevice** - Need DTO + Mapper
- **TvMonitor** - Need DTO + Mapper
- **VideoConsole** - Need DTO + Mapper

## ⏳ REMAINING (14/31 ad types)

### RealEstate (4)
- **RealEstate** (base)
- **Apartment**
- **ConstructionProject**
- **House**

### Vehicles (5)
- **Transport** (base)
- **Boat**
- **Car**
- **Motorcycle**
- **Truck**

### Heavy Equipment (5)
- **HeavyEquipment** (base)
- **Bulldozer**
- **Bus**
- **Crane**
- **Excavator**

## Next Steps

For each remaining ad type, you need to:

1. **Update DTO file** - Add `GetXxxAdDto` class
2. **Update Mapper file** - Change `MapToDto` to return `GetXxxAdDto` with full MongoDB structure

### Pattern for DTOs:
```csharp
public class GetXxxAdDto : GetAdDto  // or GetBaseTypeAdDto for derived types
{
    [JsonPropertyOrder(100)]  // Start from 100, or 200 for derived types
    public SomeType? Field1 { get; set; }
    
    [JsonPropertyOrder(101)]
    public SomeType? Field2 { get; set; }
}
```

### Pattern for Mappers:
```csharp
public static GetXxxAdDto MapToDto(Xxx entity)
{
    return new GetXxxAdDto
    {
        // Base fields (copy from MAPPER_BASE_TEMPLATE.txt)
        Id = entity.Id,
        Title = entity.Title,
        // ... all base fields ...
        
        // Category-specific fields
        Field1 = entity.Field1,
        Field2 = entity.Field2,
    };
}
```

## Files Reference

- Base template: `backend/MAPPER_BASE_TEMPLATE.txt`
- Working examples: 
  - `backend/src/ClassifiedAds.Application/DTOs/Ads/Jobs/Cv/CvAdDto.cs`
  - `backend/src/ClassifiedAds.Application/Mappers/Jobs/CvAdDtoMapper.cs`
