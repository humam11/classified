# Mappers

This folder contains mappers that convert between DTOs and Domain Entities.

## Structure

```
Mappers/
├── AdDtoMapper.cs              # General ad mapper (CreateAdDto ↔ Ad)
├── Vehicles/                   # Vehicle category mappers (future)
│   ├── CarAdDtoMapper.cs
│   ├── MotorcycleAdDtoMapper.cs
│   └── ...
├── Electronics/                # Electronics category mappers (future)
│   ├── LaptopAdDtoMapper.cs
│   ├── ComputerAdDtoMapper.cs
│   └── ...
├── RealEstate/                 # Real estate category mappers (future)
│   ├── ApartmentAdDtoMapper.cs
│   ├── HouseAdDtoMapper.cs
│   └── ...
└── ...
```

## AdDtoMapper

The `AdDtoMapper` handles mapping for general ads (ads without category-specific attributes).

### Usage

```csharp
// DTO to Entity
var ad = AdDtoMapper.MapToEntity(createAdDto, slug);

// Entity to DTO
var dto = AdDtoMapper.MapToDto(ad);
```

### When to Use

- When creating a general ad (category not in CategoryDtoMapper)
- As a base mapper for category-specific mappers
- When retrieving ads without category-specific details

## Category-Specific Mappers (Future)

Category-specific mappers will:
1. Inherit/use AdDtoMapper for base properties
2. Add category-specific attribute mapping
3. Be organized in folders by category type

Example structure for a car ad mapper:

```csharp
public static class CarAdDtoMapper
{
    public static Ad MapToEntity(CreateCarAdDto dto, string slug)
    {
        // Use base mapper for common properties
        var ad = AdDtoMapper.MapToEntity(dto, slug);
        
        // Add car-specific attributes
        ad.Attributes = new Dictionary<string, object>
        {
            ["FuelType"] = dto.FuelType,
            ["EnginePower"] = dto.EnginePower,
            ["Distance"] = dto.Distance,
            // ... more car-specific fields
        };
        
        return ad;
    }
}
```

## Design Principles

1. **Separation of Concerns**: Each mapper handles one DTO type
2. **Reusability**: Base mapper (AdDtoMapper) is reused by category mappers
3. **Type Safety**: Strong typing for category-specific attributes
4. **Maintainability**: Easy to add new category mappers without affecting existing ones

## Current Implementation

Currently, only `AdDtoMapper` is implemented. The `AdService` uses it for all ads:

- If DTO type is `CreateAdDto` → general ad (no category-specific attributes)
- If DTO type is category-specific → uses AdDtoMapper for now (category mappers coming soon)

## Next Steps

1. Create category-specific mappers as needed
2. Update AdService to use appropriate mapper based on DTO type
3. Implement proper attribute mapping for each category
