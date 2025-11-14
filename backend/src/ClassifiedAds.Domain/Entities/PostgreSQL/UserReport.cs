using ClassifiedAds.Domain.Entities.PostgreSQL.Enums;

namespace ClassifiedAds.Domain.Entities.PostgreSQL;

public class UserReport
{
    public Guid UserReportID { get; set; }
    public UserReportReasonType ReasonType { get; set; }
    public string Description { get; set; }
    public UserReportStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid ReporterID { get; set; }
    public Guid ReportedID { get; set; }

    public User Reporter { get; set; }
    public User Reported { get; set; }
}
