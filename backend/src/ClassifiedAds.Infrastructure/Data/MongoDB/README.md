# MongoDB Configuration

This folder contains MongoDB configuration and context for the ClassifiedAds application.

## Document Structure with Nested Specs

All ad entities use a **nested specs pattern** for type-specific properties, following MongoDB best practices for inheritance.

### Document Structure

Each ad document has:
- **Base properties**: Common fields like `title`, `description`, `price`, etc.
- **type field**: Discriminator identifying the entity type (e.g., "Car", "Laptop")
- **specs object**: Nested object containing type-specific properties

### Multi-Level Inheritance

For entities with multi-level inheritance (e.g., Bulldozer → HeavyEquipment → Transport → Ad), the specs are nested:

```json
{
  "_id": ObjectId("..."),
  "title": "Caterpillar D9 Bulldozer",
  "description": "Heavy-duty bulldozer",
  "price": { "amount": 250000, "currency": "USD" },
  "type": "Bulldozer",
  "specs": {
    "fuelType": "Diesel",
    "enginePower": 405,
    "fuelTankCapacity": 1000,
    "operatingMass": 48500,
    "weight": 49000,
    "bladeWidth": 4.27,
    "maxPushingCapacity": 70000,
    "trackWidth": 0.91
  }
}
```

### Single-Level Inheritance

For entities directly extending Ad (e.g., Car → Transport → Ad):

```json
{
  "_id": ObjectId("..."),
  "title": "Toyota Camry 2020",
  "description": "Well-maintained sedan",
  "price": { "amount": 25000, "currency": "USD" },
  "type": "Car",
  "specs": {
    "fuelType": "Gasoline",
    "enginePower": 203,
    "fuelTankCapacity": 60,
    "distanceKm": 45000,
    "engineDescription": "2.5L 4-Cylinder",
    "cylinders": 4,
    "transmission": "Automatic",
    "driveType": "FWD",
    "color": "Silver",
    "modelId": "..."
  }
}
```

## Field Naming Convention

All MongoDB fields use **explicit [BsonElement] attributes** with camelCase naming:

```csharp
[BsonElement("title")]
public string Title { get; set; }

[BsonElement("createdAt")]
public DateTime CreatedAt { get; set; }
```

This approach provides:
- **Full control** over field names in MongoDB
- **Consistency** across all documents
- **No surprises** from automatic conventions

## Enum Representation

Enums are stored as **strings** for better readability:

```json
{
  "status": "Active",
  "fuelType": "Diesel",
  "transmission": "Automatic"
}
```

## Inheritance Pattern

### BsonDiscriminator Attributes

Each class in the inheritance hierarchy uses `[BsonDiscriminator]`:

```csharp
[BsonDiscriminator(RootClass = true)]
[BsonKnownTypes(typeof(Transport), typeof(Car), ...)]
public class Ad { ... }

[BsonDiscriminator("Transport")]
public abstract class Transport : Ad { ... }

[BsonDiscriminator("Car")]
public class Car : Transport { ... }
```

### Nested Specs Classes

Type-specific properties are grouped in nested specs classes:

```csharp
public class Car : Transport
{
    public class CarSpecs : TransportSpecs
    {
        [BsonElement("distanceKm")]
        public int DistanceKm { get; set; }
        
        [BsonElement("transmission")]
        public Transmission Transmission { get; set; }
        // ... other car-specific properties
    }

    [BsonElement("specs")]
    public new CarSpecs Specs { get; set; } = new();

    public Car()
    {
        Type = "Car";
    }
}
```

## Entity Hierarchies

### Vehicles
- **Transport** (abstract base)
  - Car
  - Motorcycle
  - Truck
  - Boat
  - **HeavyEquipment** (abstract)
    - Bulldozer
    - Crane
    - Excavator
    - Bus

### Electronics
- **Electronics** (abstract base)
  - Laptop
  - Computer
  - TvMonitor
  - HandheldDevice
  - Console

### Real Estate
- **RealEstate** (abstract base)
  - House
  - Apartment
  - ConstructionProject

### Jobs & Services
- Cv (directly extends Ad)
- Service (directly extends Ad)
- Vacancy (directly extends Ad)

### Miscellaneous
- Book, Cloth, EngineOil, Furniture, Plant, Shoe, TireWheel, VideoGame (all directly extend Ad)

## Usage

The configuration is automatically applied when the `MongoDbContext` is instantiated:

```csharp
// In Program.cs
builder.Services.AddInfrastructure(builder.Configuration);

// In your service
public class AdService
{
    private readonly MongoDbContext _mongoContext;
    
    public AdService(MongoDbContext mongoContext)
    {
        _mongoContext = mongoContext;
    }
    
    public async Task<Car> CreateCarAsync(Car car)
    {
        await _mongoContext.Ads.InsertOneAsync(car);
        return car;
    }
    
    public async Task<Ad> GetAdAsync(ObjectId id)
    {
        return await _mongoContext.Ads
            .Find(a => a._id == id)
            .FirstOrDefaultAsync();
    }
}
```

## Configuration

Add MongoDB connection settings to `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "MongoDB": "mongodb://localhost:27017"
  },
  "MongoDB": {
    "DatabaseName": "ClassifiedAdsDb",
    "Collections": {
      "Ads": "ads",
      "Conversations": "conversations",
      "Messages": "messages"
    }
  }
}
```

## Collections

The application uses **three separate MongoDB collections**:

1. **ads**: All ad types (Car, Laptop, House, etc.) stored in a single collection
   - Uses `type` field as discriminator to identify entity type
   - Enables polymorphic queries across all ad types
   - Single collection for better performance and simpler queries

2. **conversations**: Chat conversations between users
   - Separate collection for messaging functionality
   - Independent from ads collection

3. **messages**: Individual chat messages
   - Separate collection for message storage
   - Linked to conversations via conversationId

## Benefits

1. **Clean Document Structure**: Type-specific properties are clearly organized under `specs`
2. **Type Safety**: Strong typing in C# with compile-time checking
3. **Polymorphic Queries**: Query all ads or filter by specific type
4. **Maintainability**: Easy to add new entity types or properties
5. **Readability**: Clear separation between base and type-specific properties
