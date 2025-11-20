# Specs Migration Script

## Pattern to Apply

For each ad type, we need to:

### 1. Update DTO file (XxxAdDto.cs)
Add a specs class and update GetXxxAdDto:

```csharp
// Xxx specifications DTO - groups all Xxx-specific fields
public class XxxSpecsDto
{
    // Move all category-specific fields here
}

public class GetXxxAdDto : GetBaseAdDto  // or GetAdDto for base types
{
    [JsonPropertyOrder(100)]  // or 200 for derived types
    public XxxSpecsDto? Specs { get; set; }
}
```

### 2. Update Mapper file (XxxAdDtoMapper.cs)
Update MapToDto method:

```csharp
public static GetXxxAdDto MapToDto(Xxx entity)
{
    return new GetXxxAdDto
    {
        // Base fields (Id, Title, Description, Price, LocationAd, Images, Status, etc.)
        ...
        
        Specs = new XxxSpecsDto
        {
            // All category-specific fields
            ...
        }
    };
}
```

## Completed (2/31)
- ✅ Cv
- ✅ Service

## Remaining (29/31)

### Jobs (1)
- Vacancy

### Miscellaneous (8)
- Book
- Cloth
- EngineOil
- Furniture
- Plant
- Shoe
- TireWheel
- VideoGame

### Electronics (6)
- Electronic (base)
- Computer
- Laptop
- HandheldDevice
- TvMonitor
- VideoConsole

### RealEstate (4)
- RealEstate (base)
- Apartment
- House
- ConstructionProject

### Vehicles (5)
- Transport (base)
- Boat
- Car
- Motorcycle
- Truck

### HeavyEquipment (5)
- HeavyEquipment (base)
- Bulldozer
- Bus
- Crane
- Excavator
