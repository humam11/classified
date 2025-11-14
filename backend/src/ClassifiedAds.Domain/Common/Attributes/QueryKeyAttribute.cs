namespace ClassifiedAds.Domain.Common.Attributes;

[AttributeUsage(AttributeTargets.Enum)]
public class QueryKeyAttribute : Attribute
{
    public string ar { get; set; }
    public string kr { get; set; }
}
