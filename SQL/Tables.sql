-- PostgreSQL equivalent of ClassifiedTables.sql

-- Drop the database if it exists
-- Note: You typically run this command from another database (e.g., 'postgres')
-- or use a tool that handles this. For a script, this is how you'd do it.
-- You might need to terminate active connections first if any exist.
-- Example:
-- SELECT pg_terminate_backend(pid) FROM pg_stat_activity WHERE datname = 'Classfied';
DROP DATABASE IF EXISTS "Classfied";

-- Create the database
CREATE DATABASE "Classfied";

-- Connect to the newly created database
-- In psql, you would use: \connect Classfied
-- This line is a comment for script runners; it's not executable SQL by itself in a single script pass
-- unless the tool specifically supports it.

-- Enable extensions if they are not already enabled
CREATE EXTENSION IF NOT EXISTS "uuid-ossp"; -- For uuid_generate_v4() if preferred, gen_random_uuid() is built-in
CREATE EXTENSION IF NOT EXISTS ltree;     -- For hierarchy_path

-- User Table
CREATE TABLE "User" (
    -- Primary Key
    "UserID" UUID PRIMARY KEY DEFAULT uuid_generate_v7(),
    
    -- Core IDentifying Information
    "FirstName" VARCHAR(50) NOT NULL,
    "LastName" VARCHAR(50),
    
    -- Contact Information
    "Email" VARCHAR(100) NULL,            -- Made NULL since users can sign up with phone
    "NormalizedEmail" VARCHAR(256) NULL, -- converting all emails to the same format to make them easier to search and compare
    "PhoneNumber" VARCHAR(20) NULL,       -- رقم الهاتف
    
    -- Authentication & Security
    "PasswordHash" BYTEA NOT NULL,        -- تشفير كلمة المرور
    "EmailConfirmed" BOOLEAN NOT NULL,    -- تأكيد البريد الإلكتروني
    "PhoneNumberConfirmed" BOOLEAN NOT NULL, -- تأكيد رقم الهاتف
    "LockoutEnd" TIMESTAMPTZ NULL,        -- وقت انتهاء القفل
    "LockoutEnabled" BOOLEAN NOT NULL,    -- تفعيل القفل
    
    -- Profile Data
    "ProfilePictureUrl" VARCHAR(255) NULL, -- صورة الملف الشخصي
    "AverageRating" DECIMAL(2,1) NULL,
    "ReviewCount" INTEGER DEFAULT 0,
    

    -- Foreign Keys - Relationships
    "LocationID" UUID NULL,  -- معرف المكان (سيحمل معرف المدينة فقط التي ينتمي اليها المستخدم) لاظهار الاعلانات المناسبة فقط


    FOREIGN KEY ("LocationID") REFERENCES "Location"("LocationID"),

    -- Constraints
    CONSTRAINT "CHK_ContactInfo" CHECK (
        ("PhoneNumber" IS NOT NULL OR "Email" IS NOT NULL)
    )
);

-- User Report Table  جدول بلاغات المستخدمين
CREATE TABLE "UserReport" (
    -- Primary Key
    "UserReportID" UUID PRIMARY KEY DEFAULT uuid_generate_v7(),
    
    -- Core Report Data
    "ReasonType" SMALLINT CHECK ("ReasonType" BETWEEN 1 AND 6), -- نوع البلاغ: 1=محتوى مسيء، 2=سلوك مزعج، 3=احتيال، 4=انتحال شخصية، 5=محتوى غير لائق، 6=أخرى
    "Description" VARCHAR(500),                              -- تفاصيل إضافية للبلاغ
    
    -- Metadata
    "ReportedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- تاريخ البلاغ
    
    -- Foreign Keys - Relationships
    "ReporterID" UUID NOT NULL,  -- معرف المبلغ
    "ReportedID" UUID NOT NULL,  -- معرف المبلغ عنه
    
    -- Constraints
    FOREIGN KEY ("ReporterID") REFERENCES "User"("UserID"),
    FOREIGN KEY ("ReportedID") REFERENCES "User"("UserID")
);

-- Site Feedback Table جدول تعليقات الموقع
CREATE TABLE "SiteFeedback" (
    -- Primary Key
    "FeedbackID" UUID PRIMARY KEY DEFAULT uuid_generate_v7(),
    
    -- Core Feedback Data
    "FeedbackText" VARCHAR(512),        -- التعليق
    "ScreenshotUrl" VARCHAR(512),         -- رابط الصورة

    -- Metadata
    "SubmittedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- تاريخ التقديم (بدقة ثانية واحدة)
    
    -- Foreign Keys - Relationships
    "UserID" UUID NOT NULL,   -- معرف المستخدم
    
    -- Constraints
    FOREIGN KEY ("UserID") REFERENCES "User"("UserID")
);

-- User Review Table جدول تقييمات المستخدمين
CREATE TABLE "UserReview" (
    -- Primary Key
    "UserReviewID" UUID PRIMARY KEY DEFAULT uuid_generate_v7(),

    -- Core Review Data
    "Rating" SMALLINT CHECK ("Rating" BETWEEN 1 AND 5), -- التقييم (1-5 نجوم)
    "Comment" VARCHAR(1000),                        -- التعليق (محدود ب 1000 حرف)
    
    -- Metadata
    "ReviewedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- تاريخ المراجعة
    
    -- Foreign Keys - Relationships
    "ReviewerID" UUID NOT NULL,  -- معرف المراجع
    "ReviewedID" UUID NOT NULL,  -- معرف الشخص المراجع

    -- Constraints
    FOREIGN KEY ("ReviewerID") REFERENCES "User"("UserID"),
    FOREIGN KEY ("ReviewedID") REFERENCES "User"("UserID"),
    CONSTRAINT "UQ_Review" UNIQUE ("ReviewerID", "ReviewedID") -- لمنع تكرار التقييم لنفس المستخدم
);


-- Location Table
-- 0 = City, 1 = District, 2 = Neighborhood
CREATE TABLE "Location" (
    -- Primary Key
    "LocationID" SMALLSERIAL PRIMARY KEY,

    -- Core Location Data
    "NameEnglish" VARCHAR(50) NOT NULL,
    "NameArabic" VARCHAR(50) NOT NULL,
    "NameKurdish" VARCHAR(50) NOT NULL,
    
    -- Hierarchical Data
    "hierarchy_path" LTREE NOT NULL,           -- Hierarchy position using ltree
    "Level" INTEGER GENERATED ALWAYS AS (nlevel("hierarchy_path")) STORED, -- Computed level
            
    -- Foreign Keys - Relationships
    "ParentID" SMALLINT NULL,
    
    -- Constraints
    UNIQUE ("NameEnglish", "hierarchy_path"),
    UNIQUE ("NameArabic", "hierarchy_path"),
    UNIQUE ("NameKurdish", "hierarchy_path"),



    -- For mongodb ids recieving ... (ParentID = (select id from Location where ArabicName = OR KurdishName = etc..)) 
        --        "locationIds": [1, 15, 150], // [cityId, districtId, neighborhoodId]
    UNIQUE("NameEnglish", "ParentID"),
    UNIQUE("NameArabic", "ParentID"),
    UNIQUE("NameKurdish", "ParentID"),


    FOREIGN KEY ("ParentID") REFERENCES "Location"("LocationID")
);

CREATE INDEX "IX_Location_HierarchyPath" ON "Location" USING GIST ("hierarchy_path");

-- Enhanced Categories Table
CREATE TABLE "Category" (
    -- Primary Key
    "CategoryID" SMALLSERIAL PRIMARY KEY,
    
    -- Core Descriptive Fields
    "NameArabic" VARCHAR(120) NOT NULL, -- could be duplcated
    "NameKurdish" VARCHAR(120) NOT NULL, -- could be duplcated
    
    -- Metadata Fields
    "UrlSlugArabic" VARCHAR(255) NOT NULL UNIQUE,
    "UrlSlugKurdish" VARCHAR(255) NOT NULL UNIQUE,
    "ImageUrl" VARCHAR(255),

    -- Hierarchical Data
    "hierarchy_path" LTREE NULL,
    "Level" INTEGER GENERATED ALWAYS AS (nlevel("hierarchy_path")) STORED, -- Computed level field
    
    -- Foreign Key Fields
    "ParentID" SMALLINT NULL,
    
    -- Constraints
    FOREIGN KEY ("ParentID") REFERENCES "Category"("CategoryID")
);

CREATE INDEX "IX_Category_HierarchyPath" ON "Category" USING GIST ("hierarchy_path");
-- The original SQL Server script had a UNIQUE index on a non-existent "UrlSlug" column.
-- "UrlSlugArabic" and "UrlSlugKurdish" are already marked UNIQUE above.

-- Brands & Models Table جدول العلامات التجارية والموديلات
CREATE TABLE "BrandModel" (
    -- Primary Key
    "BrandModelID" SMALLSERIAL PRIMARY KEY,         -- Auto-incremented ID
    
    -- Core Descriptive Fields
    "Name" VARCHAR(50) NOT NULL,                               -- English name
    "NameArabic" VARCHAR(50),                                 -- Arabic name
    "NameKurdish" VARCHAR(50),                                -- Kurdish name
    "IsBrand" BOOLEAN NOT NULL,                                    -- TRUE = Brand, FALSE = Model

    -- Metadata Fields
    "UrlSlugArabic" VARCHAR(255) NOT NULL UNIQUE,             -- Arabic URL slug
    "UrlSlugKurdish" VARCHAR(255) NOT NULL UNIQUE,            -- Kurdish URL slug
    "ImageUrl" VARCHAR(255) NOT NULL,                          -- Image URL
    


    "AutomationKeyword" VARCHAR(255) NULL UNIQUE,
    
    -- Hierarchical Data
    "hierarchy_path" LTREE NULL,                          -- LTREE for hierarchy
    "Level" INTEGER GENERATED ALWAYS AS (nlevel("hierarchy_path")) STORED, -- Optional computed level

    -- Foreign Keys - Relationships
    "ParentID" SMALLINT,                                       -- Brand ID (for models)
    "CategoryID" SMALLINT NOT NULL,                            -- Linked category
    
    -- Constraints
    UNIQUE ("Name", "ParentID", "CategoryID"),
    CONSTRAINT "FK_BrandModel_Category" FOREIGN KEY ("CategoryID") REFERENCES "Category"("CategoryID"),
    CONSTRAINT "FK_BrandModel_Parent" FOREIGN KEY ("ParentID") REFERENCES "BrandModel"("BrandModelID"),
    CONSTRAINT "CHK_BrandModel_Hierarchy" CHECK (
        ("IsBrand" = TRUE AND "ParentID" IS NULL) OR
        ("IsBrand" = FALSE AND "ParentID" IS NOT NULL)
    )
);

CREATE INDEX "IX_BrandModel_HierarchyPath" ON "BrandModel" USING GIST ("hierarchy_path");
-- The original SQL Server script had a UNIQUE index on a non-existent "UrlSlug" column.
-- "UrlSlugArabic" and "UrlSlugKurdish" are already marked UNIQUE above.


-- Sub Models Table (Model Release Year)
CREATE TABLE "ModelRelease" (
    -- Primary Key
    "ModelReleaseID" SMALLSERIAL PRIMARY KEY,       -- Unique ID
    
    -- Core Data Fields
    "ReleaseYear" SMALLINT NOT NULL CHECK ("ReleaseYear" BETWEEN 1900 AND 2100),
    
    -- Metadata Fields
    "UrlSlug" VARCHAR(20) NOT NULL,                            -- For URL (e.g., '2020')
    "ImageUrl" VARCHAR(255) NOT NULL,                          -- Optional image (e.g., car photo)

    -- Foreign Keys - Relationships
    "ModelID" SMALLINT NOT NULL,                               -- FK to brands_models (must be a model)
    
    -- Constraints
    UNIQUE ("ModelID", "ReleaseYear"),                           -- No duplicate releases per model
    FOREIGN KEY ("ModelID") REFERENCES "BrandModel"("BrandModelID")
);

CREATE INDEX "IX_ModelRelease_ModelID_UrlSlug" ON "ModelRelease"("ModelID", "UrlSlug");