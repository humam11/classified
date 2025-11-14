namespace ClassifiedAds.Domain.Common.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class QueryValueAttribute : Attribute
{
    public string ar { get; set; }
    public string kr { get; set; }
}
