using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using ClassifiedAds.Domain.Entities.Chat;

namespace ClassifiedAds.Infrastructure.Data.MongoDB;

public static class MongoDbConfiguration
{
    private static bool _isConfigured = false;

    public static void Configure()
    {
        if (_isConfigured)
            return;

        // Configure GUID serialization
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

        var conventionPack = new ConventionPack
        {
            new EnumRepresentationConvention(BsonType.String)
        };

        ConventionRegistry.Register(
            "EnumStringConvention",
            conventionPack,
            t => t.IsEnum);

        // Register Chat class maps (they don't use inheritance)
        RegisterChatClassMaps();

        _isConfigured = true;
    }

    private static void RegisterChatClassMaps()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(Conversation)))
        {
            BsonClassMap.RegisterClassMap<Conversation>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(c => c._id);
            });
        }

        if (!BsonClassMap.IsClassMapRegistered(typeof(Message)))
        {
            BsonClassMap.RegisterClassMap<Message>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(c => c._id);
            });
        }
    }
}
