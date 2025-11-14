using Microsoft.EntityFrameworkCore;
using ClassifiedAds.Domain.Entities.PostgreSQL;

namespace ClassifiedAds.Infrastructure.Data.PostgreSQL;

public class PostgresDbContext : DbContext
{
    public PostgresDbContext(DbContextOptions<PostgresDbContext> options)
        : base(options)
    {
    }

    // DbSets
    public DbSet<Location> Locations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserReport> UserReports { get; set; }
    public DbSet<BugReport> BugReports { get; set; }
    public DbSet<UserReview> UserReviews { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<BrandModel> BrandModels { get; set; }
    public DbSet<ModelRelease> ModelReleases { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure entities (database-first approach - tables already exist)
        ConfigureLocation(modelBuilder);
        ConfigureUser(modelBuilder);
        ConfigureUserReport(modelBuilder);
        ConfigureBugReport(modelBuilder);
        ConfigureUserReview(modelBuilder);
        ConfigureCategory(modelBuilder);
        ConfigureBrandModel(modelBuilder);
        ConfigureModelRelease(modelBuilder);
    }

    private void ConfigureLocation(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("locations");
            entity.HasKey(e => e.LocationID);

            // Map column names
            entity.Property(e => e.LocationID).HasColumnName("location_id");
            entity.Property(e => e.NameEnglish).HasColumnName("name_english");
            entity.Property(e => e.NameArabic).HasColumnName("name_arabic");
            entity.Property(e => e.NameKurdish).HasColumnName("name_kurdish");
            entity.Property(e => e.HierarchyPath).HasColumnName("hierarchy_path").HasColumnType("ltree");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.ParentID).HasColumnName("parent_id");

            // Relationships
            entity.HasOne(e => e.Parent)
                .WithMany(e => e.Children)
                .HasForeignKey(e => e.ParentID);
        });
    }

    private void ConfigureUser(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(e => e.UserID);

            // Map column names
            entity.Property(e => e.UserID).HasColumnName("user_id");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.NormalizedEmail).HasColumnName("normalized_email");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
            entity.Property(e => e.EmailConfirmed).HasColumnName("email_confirmed");
            entity.Property(e => e.PhoneNumberConfirmed).HasColumnName("phone_number_confirmed");
            entity.Property(e => e.ProfilePictureUrl).HasColumnName("profile_picture_url");
            entity.Property(e => e.AverageRating).HasColumnName("average_rating").HasColumnType("decimal(2,1)");
            entity.Property(e => e.ReviewCount).HasColumnName("review_count");
            entity.Property(e => e.Latitude).HasColumnName("latitude").HasColumnType("decimal(9,6)");
            entity.Property(e => e.Longitude).HasColumnName("longitude").HasColumnType("decimal(9,6)");
            entity.Property(e => e.LocationSource).HasColumnName("location_source").HasConversion<short>();
            entity.Property(e => e.LocationID).HasColumnName("location_id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");

            // Relationships
            entity.HasOne(e => e.Location)
                .WithMany()
                .HasForeignKey(e => e.LocationID);

            entity.HasMany(e => e.ReportsSubmitted)
                .WithOne(e => e.Reporter)
                .HasForeignKey(e => e.ReporterID);

            entity.HasMany(e => e.ReportsReceived)
                .WithOne(e => e.Reported)
                .HasForeignKey(e => e.ReportedID);

            entity.HasMany(e => e.ReviewsGiven)
                .WithOne(e => e.Reviewer)
                .HasForeignKey(e => e.ReviewerID);

            entity.HasMany(e => e.ReviewsReceived)
                .WithOne(e => e.Reviewed)
                .HasForeignKey(e => e.ReviewedID);
        });
    }

    private void ConfigureUserReport(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserReport>(entity =>
        {
            entity.ToTable("user_reports");
            entity.HasKey(e => e.UserReportID);

            // Map column names
            entity.Property(e => e.UserReportID).HasColumnName("user_report_id");
            entity.Property(e => e.ReasonType).HasColumnName("reason_type").HasConversion<short>();
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Status).HasColumnName("status").HasConversion<short>();
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.ReporterID).HasColumnName("reporter_id");
            entity.Property(e => e.ReportedID).HasColumnName("reported_id");
        });
    }

    private void ConfigureBugReport(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BugReport>(entity =>
        {
            entity.ToTable("bug_reports");
            entity.HasKey(e => e.BugReportID);

            // Map column names
            entity.Property(e => e.BugReportID).HasColumnName("bug_report_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ScreenshotUrl).HasColumnName("screenshot_url");
            entity.Property(e => e.Status).HasColumnName("status").HasConversion<short>();
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.UserID).HasColumnName("user_id");

            // Relationships
            entity.HasOne(e => e.User)
                .WithMany(e => e.BugReports)
                .HasForeignKey(e => e.UserID);
        });
    }

    private void ConfigureUserReview(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserReview>(entity =>
        {
            entity.ToTable("user_reviews");
            entity.HasKey(e => e.UserReviewID);

            // Map column names
            entity.Property(e => e.UserReviewID).HasColumnName("user_review_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.ReviewerID).HasColumnName("reviewer_id");
            entity.Property(e => e.ReviewedID).HasColumnName("reviewed_id");
        });
    }

    private void ConfigureCategory(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("categories");
            entity.HasKey(e => e.CategoryID);

            // Map column names
            entity.Property(e => e.CategoryID).HasColumnName("category_id");
            entity.Property(e => e.NameArabic).HasColumnName("name_arabic");
            entity.Property(e => e.NameKurdish).HasColumnName("name_kurdish");
            entity.Property(e => e.UrlSlugArabic).HasColumnName("url_slug_arabic");
            entity.Property(e => e.UrlSlugKurdish).HasColumnName("url_slug_kurdish");
            entity.Property(e => e.ImageUrl).HasColumnName("image_url");
            entity.Property(e => e.HierarchyPath).HasColumnName("hierarchy_path").HasColumnType("ltree");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.IsLeaf).HasColumnName("is_leaf");
            entity.Property(e => e.ParentID).HasColumnName("parent_id");

            // Relationships
            entity.HasOne(e => e.Parent)
                .WithMany(e => e.Children)
                .HasForeignKey(e => e.ParentID);
        });
    }

    private void ConfigureBrandModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BrandModel>(entity =>
        {
            entity.ToTable("brand_models");
            entity.HasKey(e => e.BrandModelID);

            // Map column names
            entity.Property(e => e.BrandModelID).HasColumnName("brand_model_id");
            entity.Property(e => e.NameEnglish).HasColumnName("name_english");
            entity.Property(e => e.NameArabic).HasColumnName("name_arabic");
            entity.Property(e => e.NameKurdish).HasColumnName("name_kurdish");
            entity.Property(e => e.IsBrand).HasColumnName("is_brand");
            entity.Property(e => e.UrlSlugArabic).HasColumnName("url_slug_arabic");
            entity.Property(e => e.UrlSlugKurdish).HasColumnName("url_slug_kurdish");
            entity.Property(e => e.ImageUrl).HasColumnName("image_url");
            entity.Property(e => e.AutomationKeyword).HasColumnName("automation_keyword");
            entity.Property(e => e.HierarchyPath).HasColumnName("hierarchy_path").HasColumnType("ltree");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.ParentID).HasColumnName("parent_id");
            entity.Property(e => e.CategoryID).HasColumnName("category_id");

            // Relationships
            entity.HasOne(e => e.Parent)
                .WithMany(e => e.Models)
                .HasForeignKey(e => e.ParentID);

            entity.HasOne(e => e.Category)
                .WithMany(e => e.BrandModels)
                .HasForeignKey(e => e.CategoryID);
        });
    }

    private void ConfigureModelRelease(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ModelRelease>(entity =>
        {
            entity.ToTable("model_releases");
            entity.HasKey(e => e.ModelReleaseID);

            // Map column names
            entity.Property(e => e.ModelReleaseID).HasColumnName("model_release_id");
            entity.Property(e => e.ReleaseYear).HasColumnName("release_year");
            entity.Property(e => e.UrlSlug).HasColumnName("url_slug");
            entity.Property(e => e.ImageUrl).HasColumnName("image_url");
            entity.Property(e => e.ModelID).HasColumnName("model_id");

            // Relationships
            entity.HasOne(e => e.Model)
                .WithMany(e => e.ModelReleases)
                .HasForeignKey(e => e.ModelID);
        });
    }
}
