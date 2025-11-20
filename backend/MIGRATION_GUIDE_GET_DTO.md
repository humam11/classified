# Migration Guide: Adding GetXxxAdDto for All Ad Types

## Pattern to Follow

For each ad type, you need to:

### 1. Update the DTO file (e.g., `XxxAdDto.cs`)

Add a `GetXxxAdDto` class that inherits from `GetAdDto`:

```csharp
using System.Text.Json.Serialization;

// Xxx Ad DTO for GET responses - includes full MongoDB structure
public class GetXxxAdDto : GetAdDto
{
    // Add category-specific fields with JsonPropertyOrder starting from 100
    [JsonPropertyOrder(100)]
    public SomeType? Field1 { get; set; }
    
    [JsonPropertyOrder(101)]
    public SomeType? Field2 { get; set; }
    
    // ... continue for all fields
}
```

### 2. Update the Mapper file (e.g., `XxxAdDtoMapper.cs`)

Update the `MapToDto` method to return `GetXxxAdDto`:

```csharp
public static GetXxxAdDto MapToDto(Xxx entity)
{
    return new GetXxxAdDto
    {
        // Base ad fields (order 1-14)
        Id = entity.Id,
        Title = entity.Title,
        Description = entity.Description,
        Price = new DTOs.Common.PriceResponseDto
        {
            Value = entity.Price.Value,
            IsDollar = entity.Price.IsDollar,
            ShowingPrice = entity.Price.ShowingPrice
        },
        LocationAd = new DTOs.Common.LocationAdResponseDto
        {
            LocationIds = entity.LocationAd.LocationIds,
            FullAddressArabic = entity.LocationAd.FullAddressArabic,
            FullAddressKurdish = entity.LocationAd.FullAddressKurdish,
            Street = entity.LocationAd.Street
        },
        Images = entity.Images.Select(img => new DTOs.Common.AdImageDto
        {
            ImageId = img.ImageId,
            ImageUrl = img.ImageUrl,
            Order = img.Order
        }).ToList(),
        Status = (int)entity.Status,
        CreatedAt = entity.CreatedAt,
        UpdatedAt = entity.UpdatedAt,
        ImageCount = entity.ImageCount,
        ViewsCount = entity.ViewsCount,
        Priority = entity.Priority,
        Slug = entity.Slug,
        Category = new DTOs.Common.CategoryResponseDto
        {
            CategoryJoins = entity.Category.CategoryJoins,
            CategoryIds = entity.Category.CategoryIds
        },
        
        // Category-specific fields
        Field1 = entity.Field1,
        Field2 = entity.Field2,
        // ... map all category-specific fields
    };
}
```

## Completed Ad Types ✅

### Jobs/Services (3/3) ✅
1. **Cv** - ✅ Done
2. **Service** - ✅ Done
3. **Vacancy** - ✅ Done

### Miscellaneous (8/8) ✅
4. **Book** - ✅ DTO Done
5. **Cloth** - ✅ DTO Done
6. **EngineOil** - ✅ DTO Done
7. **Furniture** - ✅ DTO Done
8. **Plant** - ✅ DTO Done
9. **Shoe** - ✅ DTO Done
10. **TireWheel** - ✅ DTO Done
11. **VideoGame** - ✅ DTO Done

## Remaining Ad Types (18)

### Jobs/Services (1)
- [ ] Vacancy

### Electronics (6)
- [ ] Computer
- [ ] Electronic
- [ ] HandheldDevice
- [ ] Laptop
- [ ] TvMonitor
- [ ] VideoConsole

### Miscellaneous (8)
- [ ] Book
- [ ] Cloth
- [ ] EngineOil
- [ ] Furniture
- [ ] Plant
- [ ] Shoe
- [ ] TireWheel
- [ ] VideoGame

### RealEstate (4)
- [ ] Apartment
- [ ] ConstructionProject
- [ ] House
- [ ] RealEstate

### Vehicles (5)
- [ ] Boat
- [ ] Car
- [ ] Motorcycle
- [ ] Transport
- [ ] Truck

### Heavy Equipment (5)
- [ ] Bulldozer
- [ ] Bus
- [ ] Crane
- [ ] Excavator
- [ ] HeavyEquipment

## Files to Update

For each ad type `Xxx`:
1. `backend/src/ClassifiedAds.Application/DTOs/Ads/{Category}/XxxAdDto.cs`
2. `backend/src/ClassifiedAds.Application/Mappers/{Category}/XxxAdDtoMapper.cs`

Total: **58 files** remaining (29 ad types × 2 files each)
