using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using ClassifiedAds.Infrastructure.Data.MongoDB;
using ClassifiedAds.Infrastructure.Data.PostgreSQL;
using ClassifiedAds.Application.Interfaces;
using ClassifiedAds.Application.Services;

namespace ClassifiedAds.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // PostgreSQL Configuration with snake_case naming
        services.AddDbContext<PostgresDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("PostgreSQL")
            )
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
            var databaseName = configuration["MongoDB:DatabaseName"] ?? "ClassifiedAdsDb";
            return mongoClient.GetDatabase(databaseName);
        });

        services.AddScoped<MongoDbContext>(sp =>
        {
            var mongoClient = sp.GetRequiredService<IMongoClient>();
            var databaseName = configuration["MongoDB:DatabaseName"] ?? "ClassifiedAdsDb";
            return new MongoDbContext(mongoClient, databaseName);
        });

        // Configure MongoDB conventions on startup
        MongoDbConfiguration.Configure();

        // Register Application Services
        services.AddScoped<IAdService, AdService>();

        return services;
    }
}
