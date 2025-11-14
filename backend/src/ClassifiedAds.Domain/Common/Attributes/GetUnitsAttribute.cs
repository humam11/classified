namespace ClassifiedAds.Domain.Common.Attributes;

[AttributeUsage(AttributeTargets.Enum)]
public class GetUnitsAttribute : Attribute
{
    public string UnitKey { get; }

    public GetUnitsAttribute(string unitKey) => UnitKey = unitKey;
}
