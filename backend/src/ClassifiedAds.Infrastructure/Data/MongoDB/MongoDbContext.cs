using MongoDB.Driver;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Chat;

namespace ClassifiedAds.Infrastructure.Data.MongoDB;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IMongoClient mongoClient, string databaseName)
    {
        _database = mongoClient.GetDatabase(databaseName);
        
        // Ensure MongoDB is configured with camelCase convention
        MongoDbConfiguration.Configure();
    }

    // MongoDB Collections
    public IMongoCollection<Ad> Ads => _database.GetCollection<Ad>("ads");
    public IMongoCollection<Conversation> Conversations => _database.GetCollection<Conversation>("conversations");
    public IMongoCollection<Message> Messages => _database.GetCollection<Message>("messages");
}
