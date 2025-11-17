using ClassifiedAds.Api.Middleware;
using ClassifiedAds.Infrastructure;
using MongoDB.Bson.Serialization.Conventions;
using Microsoft.OpenApi.Models;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Configure MongoDB to use camelCase naming convention
var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
ConventionRegistry.Register("camelCase", conventionPack, t => true);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.WriteIndented = true;
    });

// Add FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<ClassifiedAds.Application.Validators.Ads.CreateAdDtoValidator>();
builder.Services.AddFluentValidationAutoValidation();

// Configure form options for multipart requests
builder.Services.Configure<Microsoft.AspNetCore.Http.Features.FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 52428800; // 50MB
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartHeadersLengthLimit = int.MaxValue;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Classified Ads API", 
        Version = "v1",
        Description = @"Multilingual API for creating and managing classified ads in Arabic and Kurdish.

## How to use:
1. Choose language: `ar` (Arabic) or `kr` (Kurdish)
2. Choose location slug (e.g., `بغداد-baghdad`)
3. Choose category slug from the supported categories
4. Fill in the ad details according to the schema

## Example URLs:
- Arabic Car Ad: `/api/ar/بغداد-baghdad/categories/مركبات-ونقل/سيارات/ads`
- Kurdish Smartphone Ad: `/api/kr/هەولێر-erbil/categories/ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/مۆبایلی-زیرەک/ads`"
    });
    
    c.EnableAnnotations();
    
    // Use full type names for schemas to avoid conflicts
    c.CustomSchemaIds(type => type.FullName);
    
    // Add XML comments if available
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

// Add Infrastructure services (MongoDB, etc.)
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Classified Ads API v1");
    c.RoutePrefix = string.Empty; // Make Swagger the default page (root URL)
    c.DocumentTitle = "Classified Ads API";
    c.DefaultModelsExpandDepth(2);
    c.DefaultModelExpandDepth(2);
    c.DisplayRequestDuration();
});

app.UseHttpsRedirection();

// Add language middleware before authorization
app.UseLanguageMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
