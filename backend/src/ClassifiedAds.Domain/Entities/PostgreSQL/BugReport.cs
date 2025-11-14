using ClassifiedAds.Domain.Entities.PostgreSQL.Enums;

namespace ClassifiedAds.Domain.Entities.PostgreSQL;

public class BugReport
{
    public Guid BugReportID { get; set; }
    public string Description { get; set; }
    public string ScreenshotUrl { get; set; }
    public BugReportStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UserID { get; set; }

    public User User { get; set; }
}
