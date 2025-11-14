# MongoDB Inheritance Pattern with Separate Collections

## Overview
This document describes an architecture pattern for implementing inheritance in MongoDB with C# while maintaining separate collections for each entity type. This pattern combines the benefits of object-oriented inheritance with MongoDB's flexible document structure.

## Architecture Principles

### 1. Inheritance with Flat Document Structure
- Use C# class inheritance for code reusability and type safety
- Store documents in a flat structure with a `type` field to identify the entity type
- Keep type-specific properties nested under a `specs` object
- Each entity type gets its own MongoDB collection

### 2. Key Design Decisions
- **Separate Collections**: Each entity type (Mobile, Laptop, etc.) has its own collection
- **Type Discriminator**: Each document includes a `type` field for identification
- **Nested Specs**: Type-specific attributes are grouped under a `specs` property
- **Shared Base Properties**: Common properties (id, name, brand, price, etc.) are in the base class

## Document Structure

### Example Mobile Document
```json
{
  "_id": "507f1f77bcf86cd799439011",
  "name": "iPhone 15 Pro",
  "brand": "Apple",
  "price": 999.99,
  "stock": 50,
  "description": "Latest iPhone model",
  "createdAt": "2025-10-21T14:01:57.033Z",
  "type": "Mobile",
  "specs": {
    "screenSize": 6.1,
    "batteryCapacity": 3274,
    "ram": 8,
    "storage": 256,
    "cameraMP": 48,
    "operatingSystem": "iOS 17"
  }
}
```

### Example Laptop Document
```json
{
  "_id": "507f1f77bcf86cd799439012",
  "name": "MacBook Pro",
  "brand": "Apple",
  "price": 2499.99,
  "stock": 25,
  "description": "Professional laptop",
  "createdAt": "2025-10-21T14:01:57.033Z",
  "type": "Laptop",
  "specs": {
    "processor": "M3 Pro",
    "ram": 16,
    "storage": 512,
    "screenSize": 14.2,
    "graphicsCard": "Integrated",
    "operatingSystem": "macOS Sonoma"
  }
}
```

## Implementation Guide

### Step 1: Domain Layer - Base Entity

Create a base class with common properties and MongoDB attributes:

```csharp
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

[BsonDiscriminator(RootClass = true)]
[BsonKnownTypes(typeof(Mobile), typeof(Laptop))]  // Register all derived types
public class Electronic
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("brand")]
    public string Brand { get; set; } = string.Empty;

    [BsonElement("price")]
    public decimal Price { get; set; }

    [BsonElement("stock")]
    public int Stock { get; set; }

    [BsonElement("description")]
    public string? Description { get; set; }

    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [BsonElement("type")]
    public string Type { get; set; } = string.Empty;
}
```

**Key Points:**
- `[BsonDiscriminator(RootClass = true)]` marks this as the base class
- `[BsonKnownTypes(...)]` registers all derived types for polymorphic deserialization
- `Type` property stores the discriminator value in each document
- All common properties use `[BsonElement]` to control MongoDB field names

### Step 2: Domain Layer - Derived Entities

Create derived classes with nested specs classes:

```csharp
using MongoDB.Bson.Serialization.Attributes;

[BsonDiscriminator("Mobile")]
public class Mobile : Electronic
{
    public class MobileSpecs
    {
        [BsonElement("screenSize")]
        public double ScreenSize { get; set; }

        [BsonElement("batteryCapacity")]
        public int BatteryCapacity { get; set; }

        [BsonElement("ram")]
        public int Ram { get; set; }

        [BsonElement("storage")]
        public int Storage { get; set; }

        [BsonElement("cameraMP")]
        public int CameraMP { get; set; }

        [BsonElement("operatingSystem")]
        public string OperatingSystem { get; set; } = string.Empty;
    }

    [BsonElement("specs")]
    public MobileSpecs Specs { get; set; } = new();

    public Mobile()
    {
        Type = "Mobile";  // Set discriminator in constructor
    }
}
```

```csharp
[BsonDiscriminator("Laptop")]
public class Laptop : Electronic
{
    public class LaptopSpecs
    {
        [BsonElement("processor")]
        public string Processor { get; set; } = string.Empty;

        [BsonElement("ram")]
        public int Ram { get; set; }

        [BsonElement("storage")]
        public int Storage { get; set; }

        [BsonElement("screenSize")]
        public double ScreenSize { get; set; }

        [BsonElement("graphicsCard")]
        public string GraphicsCard { get; set; } = string.Empty;

        [BsonElement("operatingSystem")]
        public string OperatingSystem { get; set; } = string.Empty;
    }

    [BsonElement("specs")]
    public LaptopSpecs Specs { get; set; } = new();

    public Laptop()
    {
        Type = "Laptop";  // Set discriminator in constructor
    }
}
```

**Key Points:**
- `[BsonDiscriminator("TypeName")]` sets the discriminator value
- Nested `Specs` class contains type-specific properties
- `[BsonElement("specs")]` ensures specs are stored under "specs" key
- Constructor sets the `Type` property automatically

### Step 3: Infrastructure Layer - MongoDB Context

Configure separate collections for each entity type:

```csharp
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var connectionString = configuration["MongoDbSettings:ConnectionString"];
        var databaseName = configuration["MongoDbSettings:DatabaseName"];

        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<Mobile> Mobiles =>
        _database.GetCollection<Mobile>("Mobiles");

    public IMongoCollection<Laptop> Laptops =>
        _database.GetCollection<Laptop>("Laptops");
}
```

**Key Points:**
- Each entity type has its own collection property
- Collections are strongly typed (e.g., `IMongoCollection<Mobile>`)
- Collection names are explicit ("Mobiles", "Laptops")
- No need for CollectionName in configuration

### Step 4: Application Layer - Repository Interface

Define repository methods for each entity type:

```csharp
public interface IElectronicRepository
{
    // Create methods for each type
    Task<Mobile> CreateMobileAsync(Mobile mobile);
    Task<Laptop> CreateLaptopAsync(Laptop laptop);
    
    // Generic methods that work across types
    Task<List<Electronic>> GetAllAsync();
    Task<Electronic?> GetByIdAsync(string id);
    
    // Type-specific query methods
    Task<List<Mobile>> GetAllMobilesAsync();
    Task<List<Laptop>> GetAllLaptopsAsync();
}
```

### Step 5: Infrastructure Layer - Repository Implementation

Implement repository with collection-specific logic:

```csharp
public class ElectronicRepository : IElectronicRepository
{
    private readonly MongoDbContext _context;

    public ElectronicRepository(MongoDbContext context)
    {
        _context = context;
    }

    // Insert into specific collection
    public async Task<Mobile> CreateMobileAsync(Mobile mobile)
    {
        await _context.Mobiles.InsertOneAsync(mobile);
        return mobile;
    }

    public async Task<Laptop> CreateLaptopAsync(Laptop laptop)
    {
        await _context.Laptops.InsertOneAsync(laptop);
        return laptop;
    }

    // Query all collections and combine results
    public async Task<List<Electronic>> GetAllAsync()
    {
        var mobiles = await _context.Mobiles.Find(_ => true).ToListAsync();
        var laptops = await _context.Laptops.Find(_ => true).ToListAsync();
        
        var allElectronics = new List<Electronic>();
        allElectronics.AddRange(mobiles);
        allElectronics.AddRange(laptops);
        
        return allElectronics;
    }

    // Search across all collections
    public async Task<Electronic?> GetByIdAsync(string id)
    {
        var mobile = await _context.Mobiles
            .Find(e => e.Id == id)
            .FirstOrDefaultAsync();
        
        if (mobile != null)
            return mobile;

        var laptop = await _context.Laptops
            .Find(e => e.Id == id)
            .FirstOrDefaultAsync();
        
        return laptop;
    }

    // Type-specific queries
    public async Task<List<Mobile>> GetAllMobilesAsync()
    {
        return await _context.Mobiles.Find(_ => true).ToListAsync();
    }

    public async Task<List<Laptop>> GetAllLaptopsAsync()
    {
        return await _context.Laptops.Find(_ => true).ToListAsync();
    }
}
```

**Key Points:**
- Create methods insert into specific collections
- GetAll methods query multiple collections and combine results
- GetById searches across all collections sequentially
- Type-specific methods query only their respective collection

### Step 6: API Layer - Controllers

Create separate controllers for each entity type:

```csharp
[ApiController]
[Route("api/[controller]")]
public class MobileController : ControllerBase
{
    private readonly IElectronicRepository _repository;

    public MobileController(IElectronicRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<ActionResult<Mobile>> Create([FromBody] CreateMobileDto dto)
    {
        var mobile = new Mobile
        {
            Name = dto.Name,
            Brand = dto.Brand,
            Price = dto.Price,
            Stock = dto.Stock,
            Description = dto.Description,
            Specs = new Mobile.MobileSpecs
            {
                ScreenSize = dto.ScreenSize,
                BatteryCapacity = dto.BatteryCapacity,
                Ram = dto.Ram,
                Storage = dto.Storage,
                CameraMP = dto.CameraMP,
                OperatingSystem = dto.OperatingSystem
            }
        };

        var created = await _repository.CreateMobileAsync(mobile);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Mobile>> GetById(string id)
    {
        var mobile = await _repository.GetByIdAsync(id);
        if (mobile == null || mobile.Type != "Mobile")
            return NotFound();
        return Ok(mobile);
    }

    [HttpGet]
    public async Task<ActionResult<List<Mobile>>> GetAll()
    {
        var mobiles = await _repository.GetAllMobilesAsync();
        return Ok(mobiles);
    }
}
```

**Key Points:**
- Each controller handles one entity type
- DTOs map to entity with specs nested properly
- GetById validates the type matches expected type
- Type property is set automatically by entity constructor

### Step 7: Application Layer - DTOs

Create DTOs with flat structure for API input:

```csharp
public class CreateMobileDto
{
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? Description { get; set; }
    
    // Spec properties at root level for easier API consumption
    public double ScreenSize { get; set; }
    public int BatteryCapacity { get; set; }
    public int Ram { get; set; }
    public int Storage { get; set; }
    public int CameraMP { get; set; }
    public string OperatingSystem { get; set; } = string.Empty;
}
```

### Step 8: Configuration

Update appsettings.json:

```json
{
  "MongoDbSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "ElectronicsStoreDb"
  }
}
```

**Note:** No `CollectionName` needed since collections are defined in MongoDbContext.

## Benefits of This Pattern

### 1. Type Safety
- Strong typing in C# code
- Compile-time checking for entity properties
- IntelliSense support in IDE

### 2. Separation of Concerns
- Each entity type has its own collection
- Easy to apply collection-specific indexes
- Independent scaling and optimization per collection

### 3. Query Performance
- Type-specific queries only hit one collection
- No need to filter by type in queries
- Efficient indexes per collection

### 4. Maintainability
- Clear inheritance hierarchy in code
- Easy to add new entity types
- Consistent document structure

### 5. Flexibility
- Each collection can have different indexes
- Different sharding strategies per collection
- Type-specific validation rules

## Adding New Entity Types

To add a new entity type (e.g., Tablet):

1. **Create Entity Class**:
```csharp
[BsonDiscriminator("Tablet")]
public class Tablet : Electronic
{
    public class TabletSpecs
    {
        [BsonElement("screenSize")]
        public double ScreenSize { get; set; }
        
        [BsonElement("hasPen")]
        public bool HasPen { get; set; }
        
        // ... other tablet-specific properties
    }

    [BsonElement("specs")]
    public TabletSpecs Specs { get; set; } = new();

    public Tablet()
    {
        Type = "Tablet";
    }
}
```

2. **Update Base Class**:
```csharp
[BsonKnownTypes(typeof(Mobile), typeof(Laptop), typeof(Tablet))]
public class Electronic { ... }
```

3. **Add Collection to Context**:
```csharp
public IMongoCollection<Tablet> Tablets =>
    _database.GetCollection<Tablet>("Tablets");
```

4. **Add Repository Methods**:
```csharp
Task<Tablet> CreateTabletAsync(Tablet tablet);
Task<List<Tablet>> GetAllTabletsAsync();
```

5. **Create Controller and DTO**:
- TabletController with CRUD endpoints
- CreateTabletDto with tablet-specific properties

6. **Update GetAllAsync and GetByIdAsync**:
```csharp
public async Task<List<Electronic>> GetAllAsync()
{
    var mobiles = await _context.Mobiles.Find(_ => true).ToListAsync();
    var laptops = await _context.Laptops.Find(_ => true).ToListAsync();
    var tablets = await _context.Tablets.Find(_ => true).ToListAsync();
    
    var allElectronics = new List<Electronic>();
    allElectronics.AddRange(mobiles);
    allElectronics.AddRange(laptops);
    allElectronics.AddRange(tablets);
    
    return allElectronics;
}
```

## Common Patterns

### Pattern 1: Type-Specific Queries
```csharp
// Query only mobiles with specific criteria
var iosMobiles = await _context.Mobiles
    .Find(m => m.Specs.OperatingSystem == "iOS")
    .ToListAsync();
```

### Pattern 2: Cross-Type Queries
```csharp
// Get all electronics by brand (requires querying all collections)
public async Task<List<Electronic>> GetByBrandAsync(string brand)
{
    var mobiles = await _context.Mobiles
        .Find(m => m.Brand == brand)
        .ToListAsync();
    
    var laptops = await _context.Laptops
        .Find(l => l.Brand == brand)
        .ToListAsync();
    
    var result = new List<Electronic>();
    result.AddRange(mobiles);
    result.AddRange(laptops);
    
    return result;
}
```

### Pattern 3: Type Checking in Controllers
```csharp
[HttpGet("{id}")]
public async Task<ActionResult<Mobile>> GetById(string id)
{
    var item = await _repository.GetByIdAsync(id);
    
    // Validate type matches expected type
    if (item == null || item.Type != "Mobile")
        return NotFound();
    
    return Ok(item);
}
```

## Best Practices

1. **Always Set Type in Constructor**: Ensures type field is always populated correctly
2. **Use BsonElement Attributes**: Control exact field names in MongoDB
3. **Nest Type-Specific Properties**: Keep specs under a "specs" object for clarity
4. **Separate Collections**: One collection per entity type for better performance
5. **Type Validation**: Always validate type in GetById operations
6. **Consistent Naming**: Use consistent naming conventions (PascalCase in C#, camelCase in MongoDB)
7. **Index Strategy**: Create indexes specific to each collection's query patterns
8. **DTO Mapping**: Keep DTOs flat for easier API consumption, map to nested structure in controller

## MongoDB Indexes

Recommended indexes for each collection:

```javascript
// Mobiles collection
db.Mobiles.createIndex({ "brand": 1 })
db.Mobiles.createIndex({ "price": 1 })
db.Mobiles.createIndex({ "specs.operatingSystem": 1 })
db.Mobiles.createIndex({ "createdAt": -1 })

// Laptops collection
db.Laptops.createIndex({ "brand": 1 })
db.Laptops.createIndex({ "price": 1 })
db.Laptops.createIndex({ "specs.processor": 1 })
db.Laptops.createIndex({ "createdAt": -1 })
```

## Summary

This pattern provides:
- Clean inheritance in C# domain layer
- Flat, consistent document structure in MongoDB
- Separate collections for each entity type
- Type discriminator field for identification
- Nested specs object for type-specific properties
- Strong typing and compile-time safety
- Efficient queries and indexing strategies

Use this pattern when you need inheritance with MongoDB while maintaining clean separation between entity types and optimal query performance.
