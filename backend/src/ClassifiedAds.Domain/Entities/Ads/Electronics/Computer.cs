using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Entities.Ads.Electronics.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifiedAds.Domain.Entities.Ads.Electronics;

[BsonDiscriminator("Computer")]
public class Computer : Electronic
{
        public string? CPU { get; set; }
        public RamSize? RamSize { get; set; }
        public YesNo? IsSSD { get; set; }
        public StorageCapacity? StorageCapacity { get; set; }
        public string? GraphicsCard { get; set; }
        public byte? UsbPorts { get; set; }
        public byte? HdmiPorts { get; set; }
}
