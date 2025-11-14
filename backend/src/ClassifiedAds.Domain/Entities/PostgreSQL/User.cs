using ClassifiedAds.Domain.Entities.PostgreSQL.Enums;

namespace ClassifiedAds.Domain.Entities.PostgreSQL;

public class User
{
    public Guid UserID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string NormalizedEmail { get; set; }
    public string PhoneNumber { get; set; }
    public byte[] PasswordHash { get; set; }
    public bool EmailConfirmed { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public string ProfilePictureUrl { get; set; }
    public decimal? AverageRating { get; set; }
    public int ReviewCount { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public LocationSource LocationSource { get; set; }
    public ushort? LocationID { get; set; }
    public DateTime CreatedAt { get; set; }

    public Location Location { get; set; }
    public ICollection<UserReport> ReportsSubmitted { get; set; }
    public ICollection<UserReport> ReportsReceived { get; set; }
    public ICollection<UserReview> ReviewsGiven { get; set; }
    public ICollection<UserReview> ReviewsReceived { get; set; }
    public ICollection<BugReport> BugReports { get; set; }
}
