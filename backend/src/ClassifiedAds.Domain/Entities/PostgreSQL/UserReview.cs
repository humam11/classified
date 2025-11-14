namespace ClassifiedAds.Domain.Entities.PostgreSQL;

public class UserReview
{
    public Guid UserReviewID { get; set; }
    public byte Rating { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid ReviewerID { get; set; }
    public Guid ReviewedID { get; set; }

    public User Reviewer { get; set; }
    public User Reviewed { get; set; }
}
