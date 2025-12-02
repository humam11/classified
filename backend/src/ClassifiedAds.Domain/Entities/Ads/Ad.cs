using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;

namespace ClassifiedAds.Domain.Entities.Ads;

[BsonDiscriminator(RootClass = true)]
[BsonKnownTypes(
    typeof(Vehicles.Transport),
    typeof(Vehicles.Car),
    typeof(Vehicles.Motorcycle),
    typeof(Vehicles.Truck),
    typeof(Vehicles.Boat),
    typeof(Vehicles.HeavyEquipment.HeavyEquipment),
    typeof(Vehicles.HeavyEquipment.Bulldozer),
    typeof(Vehicles.HeavyEquipment.Bus),
    typeof(Vehicles.HeavyEquipment.Crane),
    typeof(Vehicles.HeavyEquipment.Excavator),
    typeof(RealEstate.RealEstate),
    typeof(RealEstate.House),
    typeof(RealEstate.Apartment),
    typeof(RealEstate.ConstructionProject),
    typeof(Electronics.Electronic),
    typeof(Electronics.Laptop),
    typeof(Electronics.Computer),
    typeof(Electronics.TvMonitor),
    typeof(Electronics.HandheldDevice),
    typeof(Electronics.Console),
    typeof(JobsServices.Cv),
    typeof(JobsServices.Service),
    typeof(JobsServices.Vacancy),
    typeof(Miscellaneous.Book),
    typeof(Miscellaneous.Cloth),
    typeof(Miscellaneous.EngineOil),
    typeof(Miscellaneous.Furniture),
    typeof(Miscellaneous.Plant),
    typeof(Miscellaneous.Shoe),
    typeof(Miscellaneous.TireWheel),
    typeof(Miscellaneous.VideoGame)
)]
public class Ad
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Price Price { get; set; }
    public Status Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public byte ImageCount { get; set; }
    public int ViewsCount { get; set; }
    public Guid UserId { get; set; }
    public byte Priority { get; set; }
    public Category Category { get; set; }
    public string Slug { get; set; }
    public LocationAd LocationAd { get; set; }
    public List<AdImage> Images { get; set; }
}
