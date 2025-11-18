using ClassifiedAds.Domain.Entities.Ads.Miscellaneous.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Miscellaneous;

[BsonDiscriminator("Book")]
public class Book : Ad
{
        public BookLanguage? BookLanguage { get; set; }
        public ushort? Pages { get; set; }
}
