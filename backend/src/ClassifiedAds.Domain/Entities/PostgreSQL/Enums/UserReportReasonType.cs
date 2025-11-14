namespace ClassifiedAds.Domain.Entities.PostgreSQL.Enums;

public enum UserReportReasonType : byte
{
    OffensiveContent,
    AnnoyingBehavior,
    Fraud,
    Impersonation,
    InappropriateContent,
    Other
}
