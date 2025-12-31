# Design Document - Diploma Documentation for Classified Ads System

## Overview

This design document outlines the structure and content for comprehensive diploma documentation of a multilingual classified ads platform. The documentation will follow a logical progression from database design through application architecture to API implementation, with consistent narrative flow and visual aids.

The system is built using ASP.NET Core 9.0 with Clean Architecture principles, employing a hybrid database approach (PostgreSQL + MongoDB) to optimize for different data access patterns. The platform supports English and Russian languages.

## Architecture

### Documentation Flow Strategy

The documentation follows a **bottom-up approach**, starting with the foundational database layer and progressing through each architectural layer:

1. **Database First**: Begin with PostgreSQL schema design and SQL examples
2. **Data Modeling**: Show MongoDB document structure and inheritance patterns
3. **Domain Layer**: Present entity models that map to database structures
4. **Application Layer**: Demonstrate DTOs, validation, and business logic
5. **Infrastructure Layer**: Explain database connections and service implementations
6. **API Layer**: Document controllers, routing, and endpoints

### Narrative Consistency

Each chapter will conclude with a transition statement connecting to the next chapter:
- "Now that we have established the database schema, the next section will demonstrate how we connect to these databases..."
- "With the database connections configured, we can now explore the domain entities that represent our data..."
- "Having defined our domain models, we will examine how the application layer transforms and validates this data..."


## Components and Interfaces

### Chapter 1: Introduction

**Purpose**: Establish context and motivation for the project

**Content Structure**:
- 1.1 Project Overview
  - Brief description of classified ads platform
  - Target audience and market
  - Key differentiators (multilingual, hybrid database, Clean Architecture)
  
- 1.2 Problem Statement
  - Challenges in traditional classified ad systems
  - Need for scalable, multilingual solutions
  - Performance requirements for different data types
  
- 1.3 Objectives
  - Build scalable classified ads platform
  - Support multiple languages (English/Russian)
  - Implement SEO-friendly routing
  - Optimize data storage with hybrid database approach
  
- 1.4 Scope and Limitations
  - Features included (ad CRUD, search, categories, images)
  - Features excluded (payment processing, messaging - if not implemented)
  - Technical constraints
  
- 1.5 Technology Stack
  - Backend: ASP.NET Core 9.0, C#
  - Databases: PostgreSQL 16, MongoDB 3.5
  - Libraries: Entity Framework Core, MongoDB Driver, FluentValidation, SixLabors.ImageSharp
  - Architecture: Clean Architecture pattern

**Visual Aids**: Technology stack diagram

**Transition**: "With the project context established, Chapter 2 will detail the functional and non-functional requirements that guided the system design."


### Chapter 2: System Requirements and Use Cases

**Purpose**: Define what the system must do and who will use it

**Content Structure**:
- 2.1 Functional Requirements
  - User management (registration, authentication)
  - Ad management (create, read, update, delete)
  - Category browsing and hierarchical navigation
  - Search and filtering capabilities
  - Image upload and management
  - Multilingual content support
  
- 2.2 Non-Functional Requirements
  - Performance: Response time < 200ms for searches
  - Scalability: Support for 100,000+ ads
  - Availability: 99.9% uptime
  - Security: Data encryption, input validation
  - Usability: Intuitive API design
  - Maintainability: Clean Architecture for testability
  
- 2.3 Actor Identification
  - Primary actors: End Users, Administrators
  - Secondary actors: System (automated processes)
  
- 2.4 Use Case Diagrams
  - [Image 2.4 - System Use Case Diagram]
  - Show actors and their interactions with system
  
- 2.5 Use Case Descriptions
  - UC-01: Create Classified Ad
  - UC-02: Search Ads by Category
  - UC-03: Update Existing Ad
  - UC-04: Delete Ad
  - UC-05: Browse Category Hierarchy
  - Each use case includes: actors, preconditions, main flow, alternative flows, postconditions

**Visual Aids**: 
- Use case diagram
- Actor-system interaction diagram

**Transition**: "Having defined what the system must accomplish, Chapter 3 will present the database design that enables these requirements."


### Chapter 3: Database Design

**Purpose**: Present the hybrid database architecture and explain design decisions

**Content Structure**:

- 3.1 Hybrid Database Architecture
  - **Database-First Approach**: Explain why we design the database schema before application code
  - **PostgreSQL for Relational Data**: Users, categories, locations, brands/models
    - Reasons: ACID compliance, complex relationships, referential integrity
    - Small record counts (thousands, not millions)
  - **MongoDB for Document Data**: Ads with varying attributes
    - Reasons: Schema flexibility, polymorphic storage, fast reads
    - Large record counts (potentially millions of ads)
  - **Why Hybrid Works**: Different data access patterns optimized separately
  - **Performance Considerations**: Small PostgreSQL tables mean joins are efficient

- 3.2 PostgreSQL Schema Design
  - **Self-Referencing Tables**: Explain the pattern used in three tables
    - `locations`: City → District → Neighborhood hierarchy
    - `categories`: Parent → Child → Leaf category hierarchy
    - `brands_models`: Brand → Model hierarchy
  - **Benefits of Self-Joins**:
    - Minimizes schema complexity (one table instead of three)
    - Flexible depth (can add more levels without schema changes)
    - Efficient with small datasets (< 10,000 records per table)
  - **LTREE Extension**: PostgreSQL's hierarchical data type
    - Stores paths like '1.15.150' for Baghdad → Karkh → Mansour
    - Enables fast ancestor/descendant queries
    - GIST indexes for performance

**SQL Example**:
```sql
-- Self-referencing categories table
CREATE TABLE categories (
    category_id SMALLSERIAL PRIMARY KEY,
    name_english VARCHAR(120) NOT NULL,
    name_russian VARCHAR(120) NOT NULL,
    parent_id SMALLINT NULL REFERENCES categories(category_id),
    hierarchy_path LTREE NULL,
    level INTEGER GENERATED ALWAYS AS (nlevel(hierarchy_path)) STORED,
    is_leaf BOOLEAN NOT NULL
);
```


- 3.3 Entity Relationship Diagram
  - [Image 3.3 - PostgreSQL ER Diagram]
  - Show all tables with relationships
  - Highlight self-referencing foreign keys
  - Indicate cardinality (1:N, N:M)
  
- 3.4 Table Descriptions and Relationships
  - **users**: User accounts with authentication data
    - UUID v7 primary keys for distributed systems
    - Location reference for user's city
    - Rating and review count for reputation
  - **locations**: Hierarchical location data (3 levels)
    - Multilingual names (English, Russian)
    - Self-referencing parent_id
    - LTREE hierarchy_path for queries
  - **categories**: Product/service categories (3 levels)
    - Multilingual names and URL slugs
    - Self-referencing parent_id
    - is_leaf flag for navigation
  - **brands_models**: Brand and model hierarchy (2 levels)
    - is_brand flag distinguishes brands from models
    - category_id links to applicable categories
    - automation_keyword for data import
  - **releases**: Model release years (sub-models)
    - Links to models (e.g., iPhone 13 → 2021, 2022)
  - **user_reports, bug_reports, user_reviews**: Moderation and feedback

**Table Relationship Examples**:
```sql
-- User has location
users.location_id → locations.location_id

-- Category hierarchy
categories.parent_id → categories.category_id

-- Brand/Model hierarchy
brands_models.parent_id → brands_models.brand_model_id
brands_models.category_id → categories.category_id

-- Release belongs to model
releases.model_id → brands_models.brand_model_id
```


- 3.5 Hierarchical Structures with LTREE
  - **What is LTREE**: PostgreSQL extension for tree-like structures
  - **Path Notation**: Dot-separated integers (e.g., '1.5.23')
  - **Query Advantages**:
    - Find all descendants: `WHERE hierarchy_path <@ '1.5'`
    - Find all ancestors: `WHERE hierarchy_path @> '1.5.23'`
    - Find siblings: `WHERE parent_id = X`
  - **Index Performance**: GIST indexes enable fast tree traversal
  - **Use Cases in System**:
    - Location navigation (show all neighborhoods in a district)
    - Category browsing (show all subcategories)
    - Brand/model filtering (show all models for a brand)

**LTREE Query Example**:
```sql
-- Find all subcategories under "Electronics"
SELECT * FROM categories 
WHERE hierarchy_path <@ (
    SELECT hierarchy_path FROM categories WHERE name_english = 'Electronics'
);

-- Find the full path for a location
SELECT name_english FROM locations 
WHERE hierarchy_path @> (
    SELECT hierarchy_path FROM locations WHERE location_id = 150
)
ORDER BY level;
-- Result: Baghdad → Karkh → Mansour
```

**Transition**: "With the relational schema established, we now examine how MongoDB complements PostgreSQL by storing the variable-structure ad documents."


- 3.6 MongoDB Collection Design
  - **Three Collections**:
    - `ads`: All advertisement types in single collection
    - `conversations`: Chat conversations between users
    - `messages`: Individual chat messages
  - **Single Collection for Ads**: Why not separate collections per type?
    - Enables polymorphic queries (search across all ad types)
    - Simplifies application code (one repository)
    - Better performance for cross-category searches
    - MongoDB handles schema variations efficiently
  - **Discriminator Pattern**: Type field identifies ad category
    - Base type: "Ad"
    - Intermediate types: "Transport", "Electronic", "RealEstate"
    - Specific types: "Car", "Laptop", "House"
  - **Embedded vs Referenced Data**:
    - Embedded: Price, Location, Images (read together with ad)
    - Referenced: User ID, Category IDs (stored in PostgreSQL)

- 3.7 Document Structure Examples
  - **Three-Level Inheritance Demonstration**:
    - Level 1: Base Ad (common fields)
    - Level 2: Transport (vehicle-specific fields)
    - Level 3: Car (car-specific fields)

**Base Ad Document**:
```json
{
  "_id": ObjectId("507f1f77bcf86cd799439041"),
  "_t": "Car",
  "title": "2022 Toyota Land Cruiser VXR",
  "description": "Premium condition, full service history",
  "price": {
    "value": 65000.00,
    "currency": "USD",
    "displayText": "$65,000"
  },
  "status": 1,
  "createdAt": ISODate("2024-05-09T11:15:00Z"),
  "updatedAt": ISODate("2024-05-09T11:15:00Z"),
  "userId": "018e9c9c-7c1a-7c1a-7c1a-7c1a7c1a7c1b",
  "slug": "2022-toyota-land-cruiser-vxr",
  "category": {
    "categoryIds": [1, 2, 3],
    "categoryPath": "1.2.3"
  },
  "location": {
    "locationIds": [1, 15, 150],
    "fullAddress": "123 Republic St, Mansour, Baghdad",
    "coordinates": {
      "latitude": 33.3152,
      "longitude": 44.3661
    }
  },
  "images": [
    {
      "imageId": "img_001",
      "imageUrl": "/images/ads/507f.../001.jpg",
      "order": 1
    }
  ]
}
```


**Transport Level (Intermediate)**:
```json
{
  // ... all base Ad fields ...
  "_t": "Car",
  "fuelType": 1,
  "enginePower": 304,
  "fuelTankCapacity": 138
}
```

**Car Level (Specific)**:
```json
{
  // ... all base Ad fields ...
  // ... all Transport fields ...
  "_t": "Car",
  "distanceKm": 40000,
  "engineDescription": "5.7L V8",
  "cylinders": 8,
  "transmission": 1,
  "driveType": 2,
  "color": "White Pearl",
  "brandModelIds": ["brand_123", "model_456"],
  "releaseYear": "2022"
}
```

- 3.8 Discriminator Pattern Implementation
  - **C# Attribute**: `[BsonDiscriminator("Car")]` on entity classes
  - **MongoDB Field**: `_t` field stores discriminator value
  - **Polymorphic Queries**: Query base type, get all subtypes
  - **Type-Specific Queries**: Filter by discriminator for specific types
  - **Inheritance Hierarchy**: Ad → Transport → Car

**Query Examples**:
```csharp
// Get all ads (any type)
var allAds = await _adsCollection.Find(_ => true).ToListAsync();

// Get only cars
var cars = await _adsCollection
    .OfType<Car>()
    .Find(_ => true)
    .ToListAsync();

// Get all transport (cars, trucks, motorcycles)
var transport = await _adsCollection
    .OfType<Transport>()
    .Find(_ => true)
    .ToListAsync();
```

[Image 3.8 - MongoDB Document Schema Diagram]

**Transition**: "Now that both database systems are designed, the next chapter will explain how we connect to these databases and structure our application code using Clean Architecture."


### Chapter 4: Application Architecture

**Purpose**: Explain Clean Architecture implementation and layer responsibilities

**Content Structure**:

- 4.1 Clean Architecture Overview
  - **What is Clean Architecture**: Separation of concerns into concentric layers
  - **Core Principles**:
    - Dependency Rule: Dependencies point inward (outer layers depend on inner)
    - Framework Independence: Business logic doesn't depend on frameworks
    - Testability: Business rules can be tested without UI, database, or external services
    - UI Independence: Can change UI without changing business rules
  - **Why Clean Architecture for This Project**:
    - Maintainability: Clear separation makes code easier to understand
    - Testability: Can unit test business logic in isolation
    - Flexibility: Can swap databases or frameworks without rewriting business logic
    - Team Collaboration: Different teams can work on different layers
  - **Four Layers**:
    1. Domain (innermost): Entities, value objects, enums
    2. Application: Use cases, DTOs, interfaces, validators
    3. Infrastructure: Database implementations, external services
    4. API (outermost): Controllers, middleware, configuration

[Image 4.1 - Clean Architecture Layers Diagram]

- 4.2 Domain Layer Design
  - **Location**: `ClassifiedAds.Domain` project
  - **Purpose**: Core business entities and rules, no external dependencies
  - **Components**:
    - **Entities**: Ad, Car, Laptop, User, Category, Location
    - **Value Objects**: Price, LocationAd, AdImage, Education, Experience
    - **Enumerations**: Status, FuelType, Transmission, DriveType
  - **No Dependencies**: Domain layer references no other projects
  - **MongoDB Attributes**: BsonDiscriminator, BsonElement for persistence

**Entity Example**:
```csharp
[BsonDiscriminator("Car")]
public class Car : Transport
{
    public int DistanceKm { get; set; }
    public string? EngineDescription { get; set; }
    public byte Cylinders { get; set; }
    public Transmission Transmission { get; set; }
    public DriveType DriveType { get; set; }
    public string? Color { get; set; }
    public List<string>? BrandModelIds { get; set; }
}
```


**Value Object Example**:
```csharp
[BsonIgnoreExtraElements]
public class Price
{
    public decimal Value { get; set; }
    public string Currency { get; set; }
    public string DisplayText { get; set; }
}
```

**Enum with Localization**:
```csharp
[LocalizedEnumName(English = "transmission", Russian = "коробка-передач")]
public enum Transmission : byte
{
    [LanguageDisplay(English = "Manual", Russian = "Механическая")]
    Manual = 0,
    
    [LanguageDisplay(English = "Automatic", Russian = "Автоматическая")]
    Automatic = 1,
    
    [LanguageDisplay(English = "Dual", Russian = "Двойная")]
    Dual = 2
}
```

- 4.3 Application Layer Design
  - **Location**: `ClassifiedAds.Application` project
  - **Purpose**: Application business logic, use cases, data transformation
  - **Dependencies**: References Domain layer only
  - **Components**:
    - **DTOs**: AdDto, CreateCarAdDto, GetCarAdDto
    - **Mappers**: AdDtoMapper, CarAdDtoMapper
    - **Validators**: AdDtoValidator, CarAdDtoValidator (FluentValidation)
    - **Service Interfaces**: IAdService, ICategoryService, ILocationService
  - **DTO Pattern Hierarchy**:
    - `AdDto`: Base input DTO with common fields
    - `CreateCarAdDto : AdDto`: Inherits base, adds car-specific input fields
    - `GetCarAdDto : GetAdDto`: Output DTO with full nested objects

**DTO Hierarchy Explanation**:
- **Input DTOs** (AdDto, CreateCarAdDto): Flat structure for form data
  - Used in POST/PATCH operations
  - Accepts primitive types and simple objects
  - Validated by FluentValidation
- **Output DTOs** (GetAdDto, GetCarAdDto): Nested structure matching MongoDB
  - Used in GET operations
  - Contains full Price, LocationAd, Images objects
  - Matches database document structure


**DTO Example**:
```csharp
// Input DTO for creating ads
public class AdDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal PriceValue { get; set; }
    public string PriceCurrency { get; set; }
    public List<int> LocationIds { get; set; }
    public List<IFormFile>? Images { get; set; }
}

// Car-specific input DTO
public class CreateCarAdDto : AdDto
{
    public int DistanceKm { get; set; }
    public byte Cylinders { get; set; }
    public Transmission Transmission { get; set; }
}

// Output DTO with nested objects
public class GetCarAdDto : GetAdDto
{
    public int DistanceKm { get; set; }
    public byte Cylinders { get; set; }
    public Transmission Transmission { get; set; }
}

public class GetAdDto
{
    public string Id { get; set; }
    public string Title { get; set; }
    public PriceResponseDto Price { get; set; }  // Nested object
    public LocationAdResponseDto LocationAd { get; set; }  // Nested object
    public List<AdImageDto> Images { get; set; }  // Nested array
}
```

**FluentValidation Implementation**:
```csharp
public class AdDtoValidator : AbstractValidator<AdDto>
{
    public AdDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(200).WithMessage("Title too long");
            
        RuleFor(x => x.PriceValue)
            .GreaterThan(0).WithMessage("Price must be positive");
            
        RuleFor(x => x.LocationIds)
            .NotEmpty().WithMessage("Location is required")
            .Must(ids => ids.Count == 3).WithMessage("Must specify city, district, neighborhood");
    }
}

public class CreateCarAdDtoValidator : AbstractValidator<CreateCarAdDto>
{
    public CreateCarAdDtoValidator()
    {
        Include(new AdDtoValidator());  // Inherit base validation
        
        RuleFor(x => x.DistanceKm)
            .GreaterThanOrEqualTo(0).WithMessage("Distance cannot be negative");
            
        RuleFor(x => x.Cylinders)
            .InclusiveBetween((byte)3, (byte)12).WithMessage("Cylinders must be 3-12");
    }
}
```


**Validation in Controllers**:
- FluentValidation automatically validates DTOs before controller actions
- Invalid requests return 400 Bad Request with validation errors
- Validation messages are multilingual based on request language

- 4.4 Infrastructure Layer Design
  - **Location**: `ClassifiedAds.Infrastructure` project
  - **Purpose**: External concerns (databases, file system, external APIs)
  - **Dependencies**: References Domain and Application layers
  - **Components**:
    - **Database Contexts**: PostgresDbContext, MongoDbContext
    - **Service Implementations**: AdService, CategoryService, LocationService, ImageService
    - **Dependency Injection**: DependencyInjection.cs configures services

**Database Context Configuration**:
```csharp
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // PostgreSQL Configuration
        services.AddDbContext<PostgresDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PostgreSQL"))
        );

        // MongoDB Configuration
        services.AddSingleton<IMongoClient>(sp =>
        {
            var connectionString = configuration.GetConnectionString("MongoDB");
            return new MongoClient(connectionString);
        });

        services.AddScoped<IMongoDatabase>(sp =>
        {
            var mongoClient = sp.GetRequiredService<IMongoClient>();
            var databaseName = configuration["MongoDB:DatabaseName"];
            return mongoClient.GetDatabase(databaseName);
        });

        // Configure MongoDB conventions
        MongoDbConfiguration.Configure();

        // Register services
        services.AddScoped<IAdService, AdService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ILocationService, LocationService>();
        services.AddScoped<IImageService, ImageService>();

        return services;
    }
}
```


**Service Implementation Example**:
```csharp
public class AdService : IAdService
{
    private readonly IMongoCollection<Ad> _adsCollection;
    private readonly ILocationService _locationService;
    private readonly ICategoryService _categoryService;
    private readonly IImageService _imageService;

    public AdService(
        IMongoDatabase database,
        ILocationService locationService,
        ICategoryService categoryService,
        IImageService imageService)
    {
        _adsCollection = database.GetCollection<Ad>("ads");
        _locationService = locationService;
        _categoryService = categoryService;
        _imageService = imageService;
    }

    public async Task<string> CreateAdAsync<TDto>(
        TDto dto, 
        string categorySlug, 
        List<ImageUpload> images) 
        where TDto : AdDto
    {
        // Map DTO to entity
        var ad = MapDtoToEntity(dto, categorySlug);
        
        // Process images
        ad.Images = await _imageService.SaveImagesAsync(images);
        
        // Save to MongoDB
        await _adsCollection.InsertOneAsync(ad);
        
        return ad.Id;
    }
}
```

- 4.5 API Layer Design
  - **Location**: `ClassifiedAds.Api` project
  - **Purpose**: HTTP endpoints, routing, middleware
  - **Dependencies**: References Application and Infrastructure layers
  - **Components**:
    - **Controllers**: DynamicAdsController
    - **Middleware**: LanguageMiddleware, ExceptionHandlingMiddleware
    - **Configuration**: Program.cs, appsettings.json

**Controller Structure**:
```csharp
[ApiController]
[Route("api")]
public class DynamicAdsController : ControllerBase
{
    private readonly IAdService _adService;
    private readonly ILogger<DynamicAdsController> _logger;

    public DynamicAdsController(IAdService adService, ILogger<DynamicAdsController> logger)
    {
        _adService = adService;
        _logger = logger;
    }

    // Endpoints defined in section 6
}
```


- 4.6 Dependency Flow and Injection
  - **Dependency Rule**: Outer layers depend on inner layers
    - API → Application → Domain
    - Infrastructure → Application → Domain
    - API → Infrastructure (for DI configuration only)
  - **Dependency Injection**: ASP.NET Core built-in DI container
  - **Service Lifetimes**:
    - Singleton: IMongoClient (connection pooling)
    - Scoped: DbContext, Services (per HTTP request)
    - Transient: Validators (created each time)

[Image 4.6 - Dependency Flow Diagram]

**Program.cs Configuration**:
```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);

// Add FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<AdDtoValidator>();

var app = builder.Build();

// Configure middleware pipeline
app.UseMiddleware<LanguageMiddleware>();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
```

**Transition**: "With the architectural foundation established, Chapter 5 will explore the key features that make this system unique: multilingual support, dynamic routing, and robust validation."


### Chapter 5: Key Features Implementation

**Purpose**: Detail the implementation of critical system features

**Content Structure**:

- 5.1 Multilingual Support System
  - **Language Routing**: URL prefix determines language (en/ru)
  - **Route Pattern**: `/api/{lang}/categories/{path}`
  - **Language Context**: Middleware extracts language from route
  - **Enum Localization**: Custom attributes for multilingual enums
  - **Database Localization**: Language-specific columns in PostgreSQL
  - **Validation Messages**: FluentValidation with language-specific messages

**Language Middleware**:
```csharp
public class LanguageMiddleware
{
    private readonly RequestDelegate _next;

    public LanguageMiddleware(RequestDelegate _next)
    {
        this._next = _next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var lang = context.Request.RouteValues["lang"]?.ToString();
        
        if (lang == "en" || lang == "ru")
        {
            LanguageContext.CurrentLanguage = lang;
        }
        
        await _next(context);
    }
}
```

**Enum Localization Attributes**:
```csharp
[AttributeUsage(AttributeTargets.Enum)]
public class LocalizedEnumNameAttribute : Attribute
{
    public string English { get; set; }
    public string Russian { get; set; }
}

[AttributeUsage(AttributeTargets.Field)]
public class LanguageDisplayAttribute : Attribute
{
    public string English { get; set; }
    public string Russian { get; set; }
    
    public string GetDisplay(string language)
    {
        return language == "ru" ? Russian : English;
    }
}
```


- 5.2 Dynamic SEO-Friendly Routing
  - **Catch-All Route**: `{**path}` captures entire URL path
  - **Route Parsing**: Extract category, brand/model, release year, ad slug
  - **URL Patterns**:
    - Category only: `/en/categories/vehicles/cars/ads`
    - With brand/model: `/en/categories/vehicles/cars/models/toyota-camry/ads`
    - With release: `/en/categories/vehicles/cars/models/toyota-camry/releases/2022/ads`
    - Single ad: `/en/categories/vehicles/cars/ads/2022-toyota-camry-excellent`
  - **Slug Generation**: Convert titles to URL-safe strings
  - **Canonical URLs**: Build most specific URL for each ad

**Route Handling Logic**:
```csharp
[HttpGet("{lang}/categories/{**path}")]
public async Task<ActionResult<object>> HandleCategoryRoute(
    [FromRoute] string lang,
    [FromRoute] string path)
{
    // Validate language
    if (lang != "en" && lang != "ru")
        return BadRequest(new { error = "Language must be 'en' or 'ru'" });

    // Check for single ad request (/ads/{slug})
    var adsIndex = path.LastIndexOf("/ads/");
    if (adsIndex >= 0)
    {
        var adSlug = path[(adsIndex + 5)..];
        var beforeAds = path[..adsIndex];
        return await HandleSingleAdRequest(lang, beforeAds, adSlug);
    }

    // Check for search endpoint (ends with /ads)
    if (!path.EndsWith("/ads"))
        return BadRequest(new { error = "URL must end with /ads" });

    var categorySlug = path[..^4]; // Remove "/ads"

    // Check for brand/model search
    if (categorySlug.Contains("/models/"))
        return await HandleBrandModelSearch(lang, categorySlug);

    // Standard category search
    var ads = await _adService.SearchAdsByCategoryAsync(categorySlug, lang);
    return Ok(ads);
}
```

**Slug Generation**:
```csharp
private string GenerateSlug(string title)
{
    // Convert to lowercase
    var slug = title.ToLowerInvariant();
    
    // Remove special characters
    slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");
    
    // Replace spaces with hyphens
    slug = Regex.Replace(slug, @"\s+", "-");
    
    // Remove duplicate hyphens
    slug = Regex.Replace(slug, @"-+", "-");
    
    return slug.Trim('-');
}
```


- 5.3 Image Upload and Management
  - **Upload Handling**: Multipart/form-data with 50MB limit
  - **Storage Strategy**: File system under wwwroot/images/ads/{adId}/
  - **Image Processing**: SixLabors.ImageSharp for resizing/optimization
  - **Metadata Storage**: AdImage value object in MongoDB
  - **Deletion**: Cleanup files when ad is deleted

**Image Upload Configuration**:
```csharp
[HttpPost("{lang}/categories/{**categorySlug}")]
[Consumes("multipart/form-data")]
[DisableRequestSizeLimit]
[RequestFormLimits(MultipartBodyLengthLimit = 52428800)] // 50MB
public async Task<ActionResult<string>> CreateAd(
    [FromRoute] string lang,
    [FromRoute] string categorySlug,
    [FromForm] CreateAdDto formDto)
{
    // Extract images from form
    var images = formDto.Images?.Select(f => new ImageUpload
    {
        FileName = f.FileName,
        ContentType = f.ContentType,
        Stream = f.OpenReadStream()
    }).ToList();

    // Create ad with images
    var adId = await _adService.CreateAdAsync(formDto, categorySlug, images);
    
    return Ok(new { id = adId });
}
```

**Image Service Implementation**:
```csharp
public class ImageService : IImageService
{
    private readonly string _imageBasePath;

    public ImageService(IWebHostEnvironment env)
    {
        _imageBasePath = Path.Combine(env.WebRootPath, "images", "ads");
    }

    public async Task<List<AdImage>> SaveImagesAsync(
        string adId, 
        List<ImageUpload> images)
    {
        var adImagePath = Path.Combine(_imageBasePath, adId);
        Directory.CreateDirectory(adImagePath);

        var savedImages = new List<AdImage>();
        byte order = 1;

        foreach (var image in images)
        {
            var imageId = Guid.NewGuid().ToString();
            var extension = Path.GetExtension(image.FileName);
            var fileName = $"{imageId}{extension}";
            var filePath = Path.Combine(adImagePath, fileName);

            // Save file
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.Stream.CopyToAsync(fileStream);
            }

            // Resize/optimize with ImageSharp
            await OptimizeImageAsync(filePath);

            savedImages.Add(new AdImage
            {
                ImageId = imageId,
                ImageUrl = $"/images/ads/{adId}/{fileName}",
                Order = order++
            });
        }

        return savedImages;
    }
}
```


- 5.4 Data Validation Strategy
  - **Three Validation Layers**:
    1. **Client-side**: (If implemented) JavaScript validation
    2. **API Layer**: FluentValidation on DTOs
    3. **Database Layer**: PostgreSQL constraints, MongoDB schema validation
  - **FluentValidation Benefits**:
    - Declarative validation rules
    - Reusable validators
    - Multilingual error messages
    - Automatic integration with ASP.NET Core
  - **Validation for Create vs Update**:
    - Create: All required fields must be present
    - Update: Only provided fields are validated
    - Partial updates supported via PATCH

**Validation Example**:
```csharp
public class CreateCarAdDtoValidator : AbstractValidator<CreateCarAdDto>
{
    public CreateCarAdDtoValidator()
    {
        // Base ad validation
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(lang => 
                lang == "ru" ? "Название обязательно" : "Title is required")
            .MaximumLength(200);

        RuleFor(x => x.PriceValue)
            .GreaterThan(0).WithMessage(lang => 
                lang == "ru" ? "Цена должна быть положительной" : "Price must be positive");

        // Car-specific validation
        RuleFor(x => x.DistanceKm)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(1000000);

        RuleFor(x => x.Transmission)
            .IsInEnum().WithMessage(lang => 
                lang == "ru" ? "Недопустимый тип коробки передач" : "Invalid transmission type");

        // Conditional validation
        When(x => x.DistanceKm > 0, () =>
        {
            RuleFor(x => x.DistanceKm)
                .Must(BeReasonableDistance)
                .WithMessage("Distance seems unrealistic for vehicle age");
        });
    }

    private bool BeReasonableDistance(int km)
    {
        return km <= 500000; // Max reasonable distance
    }
}
```

**Database Constraints**:
```sql
-- PostgreSQL constraints
ALTER TABLE users ADD CONSTRAINT chk_contact_info 
    CHECK (phone_number IS NOT NULL OR email IS NOT NULL);

ALTER TABLE user_reviews ADD CONSTRAINT chk_rating 
    CHECK (rating BETWEEN 1 AND 5);

ALTER TABLE categories ADD CONSTRAINT chk_hierarchy 
    CHECK ((parent_id IS NULL AND level = 0) OR (parent_id IS NOT NULL AND level > 0));
```


- 5.5 Error Handling Approach
  - **Exception Middleware**: Catches all unhandled exceptions
  - **Validation Errors**: Return 400 Bad Request with error details
  - **Not Found**: Return 404 for missing resources
  - **Server Errors**: Return 500 with generic message (hide details in production)
  - **Logging**: Structured logging with Serilog or built-in logger

**Error Response Format**:
```json
{
  "error": "Validation failed",
  "details": {
    "Title": ["Title is required"],
    "PriceValue": ["Price must be positive"]
  },
  "timestamp": "2024-05-09T11:15:00Z"
}
```

**Transition**: "With the core features implemented, Chapter 6 will document all API endpoints and provide request/response examples for each operation."


### Chapter 6: API Documentation

**Purpose**: Comprehensive reference for all API endpoints

**Content Structure**:

- 6.1 Endpoint Overview
  - **Base URL**: `https://api.example.com/api`
  - **Language Prefix**: All routes start with `/{lang}` where lang = en | ru
  - **Content Types**: 
    - GET: application/json
    - POST/PATCH: multipart/form-data (for images) or application/json
  - **Authentication**: (If implemented) Bearer token in Authorization header
  - **Rate Limiting**: (If implemented) X-RateLimit headers

**Endpoint Summary Table**:
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /{lang}/categories/{path}/ads | Search ads by category |
| GET | /{lang}/categories/{path}/ads/{slug} | Get single ad |
| POST | /{lang}/categories/{path} | Create new ad |
| PATCH | /{lang}/ads/{id} | Update ad by ID |
| PATCH | /{lang}/categories/{path}/ads/{slug} | Update ad by slug |
| DELETE | /{lang}/ads/{id} | Delete ad by ID |
| DELETE | /{lang}/categories/{path}/ads/{slug} | Delete ad by slug |

- 6.2 Create Ad Operations
  - **Endpoint**: `POST /{lang}/categories/{categorySlug}`
  - **Purpose**: Create a new classified ad
  - **Content-Type**: multipart/form-data
  - **Request Body**: CreateAdDto (specific type based on category)
  - **Response**: 201 Created with ad ID and canonical URL

**Request Example**:
```http
POST /api/en/categories/vehicles/cars HTTP/1.1
Content-Type: multipart/form-data; boundary=----WebKitFormBoundary

------WebKitFormBoundary
Content-Disposition: form-data; name="title"

2022 Toyota Camry - Excellent Condition
------WebKitFormBoundary
Content-Disposition: form-data; name="description"

Well-maintained vehicle with full service history
------WebKitFormBoundary
Content-Disposition: form-data; name="priceValue"

25000
------WebKitFormBoundary
Content-Disposition: form-data; name="priceCurrency"

USD
------WebKitFormBoundary
Content-Disposition: form-data; name="locationIds"

1
------WebKitFormBoundary
Content-Disposition: form-data; name="locationIds"

15
------WebKitFormBoundary
Content-Disposition: form-data; name="locationIds"

150
------WebKitFormBoundary
Content-Disposition: form-data; name="distanceKm"

45000
------WebKitFormBoundary
Content-Disposition: form-data; name="transmission"

1
------WebKitFormBoundary
Content-Disposition: form-data; name="images"; filename="car1.jpg"
Content-Type: image/jpeg

[binary image data]
------WebKitFormBoundary--
```


**Response Example**:
```json
{
  "id": "507f1f77bcf86cd799439041",
  "canonicalUrl": "/api/en/categories/vehicles/cars/models/toyota-camry/releases/2022/ads/2022-toyota-camry-excellent",
  "message": "Ad created successfully"
}
```

- 6.3 Retrieve and Search Operations
  - **Search by Category**: `GET /{lang}/categories/{categorySlug}/ads`
  - **Search by Brand/Model**: `GET /{lang}/categories/{categorySlug}/models/{brandSlug}/ads`
  - **Search by Release**: `GET /{lang}/categories/{categorySlug}/models/{brandSlug}/releases/{year}/ads`
  - **Get Single Ad**: `GET /{lang}/categories/{path}/ads/{adSlug}`
  - **Query Parameters**: (If implemented) page, limit, sort, filter

**Search Request Example**:
```http
GET /api/en/categories/vehicles/cars/models/toyota-camry/ads?page=1&limit=20 HTTP/1.1
```

**Search Response Example**:
```json
{
  "total": 45,
  "page": 1,
  "limit": 20,
  "ads": [
    {
      "id": "507f1f77bcf86cd799439041",
      "title": "2022 Toyota Camry - Excellent Condition",
      "description": "Well-maintained vehicle...",
      "price": {
        "value": 25000.00,
        "currency": "USD",
        "displayText": "$25,000"
      },
      "location": {
        "locationIds": [1, 15, 150],
        "fullAddress": "123 Main St, District, City"
      },
      "images": [
        {
          "imageId": "img_001",
          "imageUrl": "/images/ads/507f.../001.jpg",
          "order": 1
        }
      ],
      "distanceKm": 45000,
      "transmission": 1,
      "slug": "2022-toyota-camry-excellent",
      "createdAt": "2024-05-09T11:15:00Z"
    }
  ]
}
```

**Single Ad Request Example**:
```http
GET /api/en/categories/vehicles/cars/ads/2022-toyota-camry-excellent HTTP/1.1
```

**Single Ad Response**: Same structure as search result item, but single object instead of array


- 6.4 Update Ad Operations
  - **Update by ID**: `PATCH /{lang}/ads/{id}`
  - **Update by Slug**: `PATCH /{lang}/categories/{categorySlug}/ads/{adSlug}`
  - **Content-Type**: multipart/form-data
  - **Partial Updates**: Only provided fields are updated
  - **Image Handling**: Can add new images, existing images remain

**Update Request Example**:
```http
PATCH /api/en/ads/507f1f77bcf86cd799439041 HTTP/1.1
Content-Type: multipart/form-data; boundary=----WebKitFormBoundary

------WebKitFormBoundary
Content-Disposition: form-data; name="priceValue"

24000
------WebKitFormBoundary
Content-Disposition: form-data; name="distanceKm"

46000
------WebKitFormBoundary--
```

**Update Response Example**:
```json
{
  "message": "Ad updated successfully",
  "updatedAt": "2024-05-10T14:30:00Z"
}
```

- 6.5 Delete Ad Operations
  - **Delete by ID**: `DELETE /{lang}/ads/{id}`
  - **Delete by Slug**: `DELETE /{lang}/categories/{categorySlug}/ads/{adSlug}`
  - **Cascade**: Deletes ad document and associated images from file system
  - **Response**: 204 No Content on success

**Delete Request Example**:
```http
DELETE /api/en/ads/507f1f77bcf86cd799439041 HTTP/1.1
```

**Delete Response**: 204 No Content (empty body)

- 6.6 Request and Response Examples
  - **Error Responses**:
    - 400 Bad Request: Validation errors
    - 404 Not Found: Resource doesn't exist
    - 500 Internal Server Error: Server-side error

**400 Validation Error Example**:
```json
{
  "error": "Validation failed",
  "details": {
    "PriceValue": ["Price must be positive"],
    "LocationIds": ["Must specify city, district, neighborhood"]
  }
}
```

**404 Not Found Example**:
```json
{
  "error": "Ad not found",
  "requestedId": "507f1f77bcf86cd799439041"
}
```

**Transition**: "With the API fully documented, Chapter 7 will visualize the system workflows through activity diagrams and sequence diagrams."


### Chapter 7: Activity Diagrams and Workflows

**Purpose**: Visualize system processes and data flow

**Content Structure**:

- 7.1 Create Ad Workflow
  - **Actors**: User, API, Application Layer, Infrastructure Layer, Databases
  - **Steps**:
    1. User submits form with ad data and images
    2. API validates language parameter
    3. FluentValidation validates DTO
    4. Application layer maps DTO to entity
    5. Infrastructure saves images to file system
    6. Infrastructure saves ad to MongoDB
    7. Infrastructure queries PostgreSQL for category/location data
    8. API returns success response with ad ID

[Image 7.1 - Create Ad Activity Diagram]

**Activity Diagram Elements**:
- Start node
- Decision nodes (validation checks)
- Action nodes (save image, save ad)
- Fork/join nodes (parallel operations)
- End node

**Sequence Diagram**:
```
User -> API: POST /en/categories/vehicles/cars
API -> Validator: Validate CreateCarAdDto
Validator -> API: Validation OK
API -> AdService: CreateAdAsync(dto, images)
AdService -> ImageService: SaveImagesAsync(images)
ImageService -> FileSystem: Write image files
FileSystem -> ImageService: File paths
ImageService -> AdService: Image metadata
AdService -> CategoryService: GetCategoryBySlug("vehicles/cars")
CategoryService -> PostgreSQL: SELECT * FROM categories WHERE...
PostgreSQL -> CategoryService: Category data
CategoryService -> AdService: Category IDs
AdService -> MongoDB: InsertOneAsync(ad)
MongoDB -> AdService: Inserted ID
AdService -> API: Ad ID
API -> User: 201 Created {id, canonicalUrl}
```

[Image 7.1b - Create Ad Sequence Diagram]


- 7.2 Search and Browse Workflow
  - **Actors**: User, API, Application Layer, Infrastructure Layer, Databases
  - **Steps**:
    1. User requests ads by category/brand/model
    2. API parses URL path (category slug, brand slug, release year)
    3. Application layer determines search type
    4. Infrastructure queries PostgreSQL for category/brand IDs
    5. Infrastructure queries MongoDB with filters
    6. Infrastructure enriches results with PostgreSQL data
    7. API returns paginated results

[Image 7.2 - Search Workflow Activity Diagram]

**Decision Tree for Route Parsing**:
```
URL: /en/categories/{path}
├─ Does path contain "/ads/"?
│  ├─ Yes: Single ad request
│  │  └─ Extract ad slug, query by slug
│  └─ No: Continue
├─ Does path end with "/ads"?
│  ├─ No: Return 400 Bad Request
│  └─ Yes: Search request
│     ├─ Does path contain "/models/"?
│     │  ├─ Yes: Brand/model search
│     │  │  ├─ Does path contain "/releases/"?
│     │  │  │  ├─ Yes: Release year search
│     │  │  │  └─ No: Brand/model search
│     │  └─ No: Category search
```

[Image 7.2b - Route Parsing Decision Tree]

- 7.3 Update Ad Workflow
  - **Actors**: User, API, Application Layer, Infrastructure Layer, Databases
  - **Steps**:
    1. User submits PATCH request with updated fields
    2. API retrieves existing ad from MongoDB
    3. FluentValidation validates only provided fields
    4. Application layer merges changes with existing data
    5. Infrastructure processes new images (if any)
    6. Infrastructure updates MongoDB document
    7. API returns success response

[Image 7.3 - Update Ad Activity Diagram]

**Partial Update Logic**:
- Only fields present in request are validated and updated
- Null/missing fields are ignored (not set to null)
- Images can be added but not removed via PATCH
- UpdatedAt timestamp is automatically set


- 7.4 Category Navigation Workflow
  - **Actors**: User, API, Application Layer, Infrastructure Layer, PostgreSQL
  - **Steps**:
    1. User requests category hierarchy
    2. API queries PostgreSQL categories table
    3. Infrastructure uses LTREE to find descendants
    4. Infrastructure builds tree structure
    5. API returns hierarchical JSON

[Image 7.4 - Category Navigation Activity Diagram]

**LTREE Query for Hierarchy**:
```sql
-- Get all subcategories under "Vehicles"
WITH vehicle_category AS (
    SELECT hierarchy_path 
    FROM categories 
    WHERE name_english = 'Vehicles'
)
SELECT c.* 
FROM categories c, vehicle_category vc
WHERE c.hierarchy_path <@ vc.hierarchy_path
ORDER BY c.hierarchy_path;
```

- 7.5 Image Upload Workflow
  - **Actors**: User, API, ImageService, FileSystem
  - **Steps**:
    1. User includes images in multipart form
    2. API extracts IFormFile objects
    3. ImageService creates directory for ad
    4. ImageService saves each image to disk
    5. ImageService optimizes images with ImageSharp
    6. ImageService generates metadata (URL, order)
    7. Metadata returned to AdService for MongoDB storage

[Image 7.5 - Image Upload Activity Diagram]

**Image Processing Steps**:
1. Validate file type (JPEG, PNG, WebP)
2. Validate file size (< 5MB per image)
3. Generate unique filename (GUID + extension)
4. Save original to disk
5. Create thumbnail (if needed)
6. Optimize compression
7. Return metadata

**Transition**: "Having explored the system's design and workflows, Chapter 8 will summarize the project achievements and discuss future enhancements."


### Chapter 8: Conclusion

**Purpose**: Summarize the project and reflect on outcomes

**Content Structure**:

- 8.1 Project Summary
  - **System Overview**: Multilingual classified ads platform with hybrid database architecture
  - **Key Technologies**: ASP.NET Core 9.0, PostgreSQL, MongoDB, Clean Architecture
  - **Core Features**:
    - Multilingual support (English/Russian)
    - Dynamic SEO-friendly routing
    - Hierarchical categories and locations
    - Image upload and management
    - Comprehensive validation
    - RESTful API design
  - **Architecture Benefits**:
    - Maintainable: Clear separation of concerns
    - Testable: Business logic isolated from infrastructure
    - Scalable: Hybrid database optimizes for different workloads
    - Flexible: Can swap implementations without changing business logic

- 8.2 Key Achievements
  - **Database Design**:
    - Efficient self-referencing tables with LTREE
    - Hybrid approach optimizes for different data patterns
    - Small PostgreSQL tables enable fast joins
    - MongoDB discriminator pattern enables polymorphic storage
  - **Clean Architecture Implementation**:
    - Four distinct layers with clear responsibilities
    - Dependency injection throughout
    - Framework-independent business logic
  - **Multilingual System**:
    - Language-specific routing
    - Localized enums and validation messages
    - Language-specific database columns
  - **Developer Experience**:
    - Consistent DTO patterns (AdDto → CreateCarAdDto)
    - FluentValidation for declarative rules
    - Comprehensive API documentation

