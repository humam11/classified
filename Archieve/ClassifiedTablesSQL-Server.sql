-- Drop the database if it exists
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'Classfied')
BEGIN
    ALTER DATABASE [Classfied] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [Classfied];
END
GO

-- Create the database
CREATE DATABASE [Classfied];
GO

-- Use the newly created database
USE [Classfied];
GO


-- User Table
CREATE TABLE User (
    -- Primary Key
    UserID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    
    -- Core IDentifying Information
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50),
    
    -- Contact Information
    Email VARCHAR(100) NULL,            -- Made NULL since users can sign up with phone
    NormalizedEmail NVARCHAR(256) NULL, -- converting all emails to the same format to make them easier to search and compare
    PhoneNumber VARCHAR(20) NULL,       -- رقم الهاتف
    
    -- Authentication & Security
    PasswordHash VARBINARY(64) NOT NULL, -- تشفير كلمة المرور
    EmailConfirmed BIT NOT NULL,         -- تأكيد البريد الإلكتروني
    PhoneNumberConfirmed BIT NOT NULL,   -- تأكيد رقم الهاتف
    LockoutEnd DATETIMEOFFSET(7) NULL,   -- وقت انتهاء القفل
    LockoutEnabled BIT NOT NULL,         -- تفعيل القفل
    
    -- Profile Data
    ProfilePictureUrl NVARCHAR(255) NULL, -- صورة الملف الشخصي
    AverageRating DECIMAL(2,1) NULL,
    ReviewCount INT DEFAULT 0,
    
    -- Constraints
    CONSTRAINT CHK_ContactInfo CHECK (
        (PhoneNumber IS NOT NULL OR Email IS NOT NULL)
    )
)

-- User Report Table  جدول بلاغات المستخدمين
CREATE TABLE UserReport (
    -- Primary Key
    UserReportID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    



    -- Core Report Data
    ReasonType TINYINT CHECK (ReasonType BETWEEN 1 AND 6), -- نوع البلاغ: 1=محتوى مسيء، 2=سلوك مزعج، 3=احتيال، 4=انتحال شخصية، 5=محتوى غير لائق، 6=أخرى
    Description NVARCHAR(500),                              -- تفاصيل إضافية للبلاغ
    

    -- Metadata
    ReportedAt DATETIME DEFAULT GETDATE(), -- تاريخ البلاغ
    

    
    -- Foreign Keys - Relationships
    ReporterID UNIQUEIDENTIFIER NOT NULL,  -- معرف المبلغ
    ReportedID UNIQUEIDENTIFIER NOT NULL,  -- معرف المبلغ عنه
    

    -- Constraints
    FOREIGN KEY (ReporterID) REFERENCES User(UserID),
    FOREIGN KEY (ReportedID) REFERENCES User(UserID)
);

-- Site Feedback Table جدول تعليقات الموقع
CREATE TABLE SiteFeedback (
    -- Primary Key
    FeedbackID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    
        
 

    -- Core Feedback Data
    FeedbackText NVARCHAR(512),        -- التعليق
    ScreenshotUrl VARCHAR(512),         -- رابط الصورة (تم تغييره من NVARCHAR لأن URLs تستخدم ASCII فقط)

    -- Metadata
    SubmittedAt DATETIME2(0) DEFAULT GETDATE(), -- تاريخ التقديم (بدقة ثانية واحدة)
    

       -- Foreign Keys - Relationships
    UserID UNIQUEIDENTIFIER NOT NULL,   -- معرف المستخدم
    


    -- Constraints
    FOREIGN KEY (UserID) REFERENCES User(UserID)
);

-- User Review Table جدول تقييمات المستخدمين
CREATE TABLE UserReview (
    -- Primary Key
    UserReviewID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),

    -- Core Review Data
    Rating TINYINT CHECK (Rating BETWEEN 1 AND 5), -- التقييم (1-5 نجوم)
    Comment NVARCHAR(1000),                        -- التعليق (محدود ب 1000 حرف)
    

    -- Metadata
    ReviewedAt DATETIME2 DEFAULT GETDATE(), -- تاريخ المراجعة
    

        
    -- Foreign Keys - Relationships
    ReviewerID UNIQUEIDENTIFIER NOT NULL,  -- معرف المراجع
    ReviewedID UNIQUEIDENTIFIER NOT NULL,  -- معرف الشخص المراجع



    -- Constraints
    FOREIGN KEY (ReviewerID) REFERENCES User(UserID),
    FOREIGN KEY (ReviewedID) REFERENCES User(UserID),
    CONSTRAINT UQ_Review UNIQUE (ReviewerID, ReviewedID) -- لمنع تكرار التقييم لنفس المستخدم
);


-- Location Table
-- 0 = City, 1 = District, 2 = Neighborhood
CREATE TABLE Location (
    -- Primary Key
    LocationID SMALLINT IDENTITY(1,1) PRIMARY KEY,


    -- Core Location Data
    NameArabic NVARCHAR(50) NOT NULL,
    NameKurdish NVARCHAR(50) NOT NULL,
    

    -- Hierarchical Data
    HierarchyPath HIERARCHYID NULL,           -- Hierarchy position
    Level AS HierarchyPath.GetLevel(),        -- Optional computed level
    

        
    -- Foreign Keys - Relationships
    ParentID SMALLINT NULL,
    

    -- Constraints
    UNIQUE (NameArabic, ParentID),
    UNIQUE (NameKurdish, ParentID),
    FOREIGN KEY (ParentID) REFERENCES Location(LocationID)
);

CREATE NONCLUSTERED INDEX IX_Location_HierarchyPath ON Location (HierarchyPath);

-- Enhanced Categories Table
CREATE TABLE Category (
    -- Primary Key
    CategoryID SMALLINT IDENTITY(1,1) PRIMARY KEY,
    

    -- Core Descriptive Fields
    NameArabic NVARCHAR(60) NOT NULL,
    NameKurdish NVARCHAR(60) NOT NULL,
    

    -- Metadata Fields
    UrlSlugArabic NVARCHAR(255) NOT NULL,
    UrlSlugKurdish NVARCHAR(255) NOT NULL,
    ImageUrl VARCHAR(255),

    -- Hierarchical Data
    HierarchyPath HIERARCHYID NULL,
    Level AS hierarchy_path.GetLevel(), -- Computed level field
    

        -- Foreign Key Fields
    ParentID SMALLINT NULL,
    
    -- Constraints
    UNIQUE (NameArabic, ParentID),
    UNIQUE (NameKurdish, ParentID),
    FOREIGN KEY (ParentID) REFERENCES Category(CategoryID)
);


CREATE NONCLUSTERED INDEX IX_Category_HierarchyPath ON Category (HierarchyPath);
CREATE UNIQUE NONCLUSTERED INDEX IX_Category_UrlSlug ON Category(UrlSlug);


-- Brands & Models Table جدول العلامات التجارية والموديلات
CREATE TABLE BrandModel (
    -- Primary Key
    BrandModelID SMALLINT IDENTITY(1,1) PRIMARY KEY,         -- Auto-incremented ID
    
        


    -- Core Descriptive Fields
    Name VARCHAR(50) NOT NULL,                               -- English name
    NameArabic NVARCHAR(50),                                 -- Arabic name
    NameKurdish NVARCHAR(50),                                -- Kurdish name
    IsBrand BIT NOT NULL,                                    -- 1 = Brand, 0 = Model

    -- Metadata Fields
    UrlSlugArabic NVARCHAR(255) NOT NULL UNIQUE,             -- Arabic URL slug (e.g., name column+"سامسونج")
    UrlSlugKurdish NVARCHAR(255) NOT NULL UNIQUE,            -- name column + Kurdish URL slug

    ImageUrl VARCHAR(255) NOT NULL,                          -- Image URL
    
    -- Hierarchical Data
    HierarchyPath HIERARCHYID NULL,                          -- HIERARCHYID for hierarchy
    Level AS HierarchyPath.GetLevel(),                       -- Optional computed level

    -- Foreign Keys - Relationships
    ParentID SMALLINT,                                       -- Brand ID (for models)
    CategoryID SMALLINT NOT NULL,                            -- Linked category
    


    -- Constraints
    UNIQUE (Name, ParentID, CategoryID),
    CONSTRAINT FK_BrandModel_Category FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID),
    CONSTRAINT FK_BrandModel_Parent FOREIGN KEY (ParentID) REFERENCES BrandModel(BrandModelID),
    CONSTRAINT CHK_BrandModel_Hierarchy CHECK (
        (IsBrand = 1 AND ParentID IS NULL) OR
        (IsBrand = 0 AND ParentID IS NOT NULL)
    )
);

CREATE NONCLUSTERED INDEX IX_BrandModel_HierarchyPath ON BrandModel (HierarchyPath);
CREATE UNIQUE NONCLUSTERED INDEX IX_BrandModel_UrlSlug ON BrandModel(UrlSlug);

--FULL URL /{lang}/{category_slug}/{subcategory_slug}/{brand_slug}/{model_slug}/{release_year_slug}

-- Sub Models Table
-- Sub Models Table
CREATE TABLE ModelRelease (
    -- Primary Key
    ModelReleaseID SMALLINT IDENTITY(1,1) PRIMARY KEY,       -- Unique ID
    

    -- Core Data Fields
    ReleaseYear SMALLINT NOT NULL CHECK (ReleaseYear BETWEEN 1900 AND 2100),
    

    -- Metadata Fields
    UrlSlug VARCHAR(20) NOT NULL,                            -- For URL (e.g., '2020')
    ImageUrl VARCHAR(255) NOT NULL,                          -- Optional image (e.g., car photo)


    -- Foreign Keys - Relationships
    ModelID SMALLINT NOT NULL,                               -- FK to brands_models (must be a model)
    
    -- Constraints
    UNIQUE (ModelID, ReleaseYear),                           -- No duplicate releases per model
    FOREIGN KEY (ModelID) REFERENCES BrandModel(BrandModelID)
);

CREATE NONCLUSTERED INDEX IX_ModelRelease_ModelID_UrlSlug ON ModelRelease(ModelID, UrlSlug);
