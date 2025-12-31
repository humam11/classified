# Appendix D: Key Code Samples

## D.1 Domain Layer Examples

### D.1.1 Car Entity

```csharp
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Vehicles
{
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
}
```

---

### D.1.2 Price Value Object

```csharp
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Common.ValueObjects
{
    [BsonIgnoreExtraElements]
    public class Price
    {
        public decimal Value { get; set; }
        public string Currency { get; set; } = "USD";
        public string DisplayText { get; set; } = string.Empty;
    }
}
```

---

### D.1.3 Localized Enum

```csharp
using ClassifiedAds.Domain.Common.Attributes;

namespace ClassifiedAds.Domain.Common.Enums
{
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
}
```

---

## D.2 Application Layer Examples

### D.2.1 Create Car Ad DTO

```csharp
namespace ClassifiedAds.Application.DTOs.Ads.Vehicles
{
    public class CreateCarAdDto : AdDto
    {
        public int DistanceKm { get; set; }
        public string? EngineDescription { get; set; }
        public byte Cylinders { get; set; }
        public Transmission Transmission { get; set; }
        public DriveType DriveType { get; set; }
        public string? Color { get; set; }
        public List<string>? BrandModelIds { get; set; }
    }
}
```

---

### D.2.2 FluentValidation Validator

```csharp
using FluentValidation;

namespace ClassifiedAds.Application.Validators.Ads.Vehicles
{
    public class CreateCarAdDtoValidator : AbstractValidator<CreateCarAdDto>
    {
        public CreateCarAdDtoValidator()
        {
            Include(new AdDtoValidator());
            
            RuleFor(x => x.DistanceKm)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Distance cannot be negative");
                
            RuleFor(x => x.Cylinders)
                .InclusiveBetween((byte)3, (byte)12)
                .WithMessage("Cylinders must be between 3 and 12");
                
            RuleFor(x => x.Transmission)
                .IsInEnum()
                .WithMessage("Invalid transmission type");
        }
    }
}
```

---

### D.2.3 DTO Mapper

```csharp
namespace ClassifiedAds.Application.Mappers.Vehicles
{
    public static class CarAdDtoMapper
    {
        public static Car MapToEntity(CreateCarAdDto dto, string categorySlug)
        {
            return new Car
            {
                Title = dto.Title,
                Description = dto.Description,
                Price = new Price
                {
                    Value = dto.PriceValue,
                    Currency = dto.PriceCurrency,
                    DisplayText = $"{dto.PriceCurrency} {dto.PriceValue:N2}"
                },
                Location = new LocationAd
                {
                    LocationIds = dto.LocationIds,
                    FullAddress = dto.FullAddress
                },
                DistanceKm = dto.DistanceKm,
                Cylinders = dto.Cylinders,
                Transmission = dto.Transmission,
                DriveType = dto.DriveType,
                Color = dto.Color,
                BrandModelIds = dto.BrandModelIds,
                Status = Status.Active,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
```

---

## D.3 Infrastructure Layer Examples

### D.3.1 MongoDB Context Configuration

```csharp
using MongoDB.Bson.Serialization.Conventions;

namespace ClassifiedAds.Infrastructure.Data.MongoDB
{
    public static class MongoDbConfiguration
    {
        public static void Configure()
        {
            var conventionPack = new ConventionPack
            {
                new CamelCaseElementNameConvention(),
                new IgnoreExtraElementsConvention(true),
                new EnumRepresentationConvention(BsonType.Int32)
            };
            
            ConventionRegistry.Register(
                "CustomConventions",
                conventionPack,
                t => true
            );
        }
    }
}
```

---

### D.3.2 Ad Service Implementation

```csharp
using MongoDB.Driver;

namespace ClassifiedAds.Infrastructure.Services
{
    public class AdService : IAdService
    {
        private readonly IMongoCollection<Ad> _adsCollection;
        private readonly IImageService _imageService;

        public AdService(
            IMongoDatabase database,
            IImageService imageService)
        {
            _adsCollection = database.GetCollection<Ad>("ads");
            _imageService = imageService;
        }

        public async Task<string> CreateAdAsync<TDto>(
            TDto dto,
            string categorySlug,
            List<ImageUpload> images)
            where TDto : AdDto
        {
            var ad = MapDtoToEntity(dto, categorySlug);
            
            if (images?.Any() == true)
            {
                ad.Images = await _imageService.SaveImagesAsync(
                    images,
                    ad.Id
                );
            }
            
            await _adsCollection.InsertOneAsync(ad);
            
            return ad.Id;
        }

        public async Task<List<Ad>> SearchAdsByCategoryAsync(
            string categorySlug,
            string language)
        {
            var filter = Builders<Ad>.Filter.Eq("status", Status.Active);
            
            return await _adsCollection
                .Find(filter)
                .SortByDescending(a => a.CreatedAt)
                .ToListAsync();
        }
    }
}
```

---

## D.4 API Layer Examples

### D.4.1 Controller Action

```csharp
[ApiController]
[Route("api")]
public class DynamicAdsController : ControllerBase
{
    private readonly IAdService _adService;

    public DynamicAdsController(IAdService adService)
    {
        _adService = adService;
    }

    [HttpPost("{lang}/categories/{**categorySlug}")]
    [Consumes("multipart/form-data")]
    [RequestFormLimits(MultipartBodyLengthLimit = 52428800)]
    public async Task<ActionResult<string>> CreateAd(
        [FromRoute] string lang,
        [FromRoute] string categorySlug,
        [FromForm] CreateCarAdDto dto)
    {
        if (lang != "en" && lang != "ru")
            return BadRequest(new { error = "Invalid language" });

        var images = dto.Images?.Select(f => new ImageUpload
        {
            FileName = f.FileName,
            ContentType = f.ContentType,
            Stream = f.OpenReadStream()
        }).ToList();

        var adId = await _adService.CreateAdAsync(
            dto,
            categorySlug,
            images
        );

        return CreatedAtAction(
            nameof(GetAd),
            new { lang, categorySlug, adId },
            new { id = adId }
        );
    }
}
```

---

### D.4.2 Language Middleware

```csharp
namespace ClassifiedAds.Api.Middleware
{
    public class LanguageMiddleware
    {
        private readonly RequestDelegate _next;

        public LanguageMiddleware(RequestDelegate next)
        {
            _next = next;
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
}
```

---

### D.4.3 Program.cs Configuration

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddValidatorsFromAssemblyContaining<AdDtoValidator>();

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<LanguageMiddleware>();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
```

---

## D.5 SQL Examples

### D.5.1 LTREE Query - Find All Subcategories

```sql
-- Find all subcategories under "Electronics"
SELECT 
    category_id,
    name_english,
    level
FROM categories 
WHERE hierarchy_path <@ (
    SELECT hierarchy_path 
    FROM categories 
    WHERE name_english = 'Electronics'
)
ORDER BY hierarchy_path;
```

---

### D.5.2 LTREE Query - Find Category Path

```sql
-- Find the full path for a category
SELECT 
    name_english,
    level
FROM categories 
WHERE hierarchy_path @> (
    SELECT hierarchy_path 
    FROM categories 
    WHERE category_id = 150
)
ORDER BY level;
```

---

### D.5.3 Self-Join Query - Get Brand with Models

```sql
-- Get all models for a specific brand
SELECT 
    b.name AS brand_name,
    m.name AS model_name
FROM brands_models b
LEFT JOIN brands_models m ON m.parent_id = b.brand_model_id
WHERE b.is_brand = TRUE
  AND b.name = 'Toyota'
ORDER BY m.name;
```

---

**End of Appendix D**
