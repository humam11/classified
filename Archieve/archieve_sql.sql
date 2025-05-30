USE [Classfied];
GO


CREATE TABLE NewUser (
    NewUserId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50),

    Email VARCHAR(100) NULL,            -- Made NULL since NewUsers can sign up with phone
    NormalizedEmail NVARCHAR(256) NULL, -- converting all emails to the same format to make them easier to search and compare
    EmailConfirmed BIT NOT NULL, -- تأكيد البريد الإلكتروني
    PasswordHash VARBINARY(64) NOT NULL, -- تشفير كلمة المرور
    ProfilePictureUrl NVARCHAR(255) NULL, -- صورة الملف الشخصي
    PhoneNumber VARCHAR(20) NULL, -- رقم الهاتف
    PhoneNumberConfirmed BIT NOT NULL, -- تأكيد رقم الهاتف
    LockoutEnd DATETIMEOFFSET(7) NULL, -- وقت انتهاء القفل
    LockoutEnabled BIT NOT NULL, -- تفعيل القفل
    AverageRating DECIMAL(2,1) NULL,
    ReviewCount INT DEFAULT 0,

    CONSTRAINT CHK_ContactInfo CHECK (
        (PhoneNumber IS NOT NULL OR Email IS NOT NULL)
    )
);

-- NewUser Report Table  جدول بلاغات المستخدمين
CREATE TABLE NewUserReport (
   NewUserReportId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   ReasonType TINYINT CHECK (reason_type BETWEEN 1 AND 6), -- نوع البلاغ: 1=محتوى مسيء، 2=سلوك مزعج، 3=احتيال، 4=انتحال شخصية، 5=محتوى غير لائق، 6=أخرى
   ReportedAt DATETIME DEFAULT GETDATE(), -- تاريخ البلاغ
   ReporterId UNIQUEIDENTIFIER NOT NULL, -- معرف المبلغ
   ReportedId UNIQUEIDENTIFIER NOT NULL, -- معرف المبلغ عنه
   description NVARCHAR(500), -- تفاصيل إضافية للبلاغ
   FOREIGN KEY (ReporterId) REFERENCES NewUser(NewUserId),
   FOREIGN KEY (ReportedId) REFERENCES NewUser(NewUserId)
);

-- Site Feedback Table جدول تعليقات الموقع
CREATE TABLE SiteFeedback (
   FeedbackId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   FeedbackText NVARCHAR(512), -- التعليق
   ScreenshotUrl VARCHAR(512), -- رابط الصورة (تم تغييره من NVARCHAR لأن URLs تستخدم ASCII فقط)
   SubmittedAt DATETIME2(0) DEFAULT GETDATE(), -- تاريخ التقديم (بدقة ثانية واحدة)
   NewUserId UNIQUEIDENTIFIER NOT NULL, -- معرف المستخدم
   FOREIGN KEY (NewUserId) REFERENCES NewUser(NewUserId)
);

-- NewUser Review Table جدول تقييمات المستخدمين
CREATE TABLE NewUserReview  (
   NewUserReviewId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   Rating TINYINT CHECK (rating BETWEEN 1 AND 5), -- التقييم (1-5 نجوم)
   Comment NVARCHAR(1000), -- التعليق (محدود ب 1000 حرف)
   ReviewedAt DATETIME2 DEFAULT GETDATE(), -- تاريخ المراجعة
   ReviewerId UNIQUEIDENTIFIER NOT NULL, -- معرف المراجع
   ReviewedId UNIQUEIDENTIFIER NOT NULL, -- معرف الشخص المراجع
   FOREIGN KEY (ReviewerId) REFERENCES NewUser(NewUserId),
   FOREIGN KEY (ReviewedId) REFERENCES NewUser(NewUserId),
   CONSTRAINT UQ_Review UNIQUE (ReviewerId, ReviewedId) -- لمنع تكرار التقييم لنفس المستخدم
);


-- 0 = City, 1 = District, 2 = Neighborhood
CREATE TABLE Location (
    LocationId SMALLINT IDENTITY(1,1) PRIMARY KEY,
    NameArabic NVARCHAR(50) NOT NULL,
    NameKurdish NVARCHAR(50) NOT NULL,
    ParentId SMALLINT NULL,
    HierarchyPath HIERARCHYID NULL,                -- Hierarchy position
    -- level_type VARCHAR(20) CHECK (...)           -- Optional
    FOREIGN KEY (ParentId) REFERENCES Location(LocationId)
);

CREATE NONCLUSTERED INDEX IX_Location_HierarchyPath ON Location (HierarchyPath);

CREATE TABLE Address (
    AddressId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	-- is_job BIT, -- 0 no, 1 yes
    Street NVARCHAR(100), -- Street name or specific details
    FullAddress NVARCHAR(255) NOT NULL, -- Full hierarchical address (e.g., City > District > Neighborhood)
    LocationId SMALLINT NOT NULL, -- Reference to the smallest defined location in the hierarchy
    FOREIGN KEY (LocationId) REFERENCES Location(LocationId) -- Connects to the locations table
);


-- Enhanced Categories Table
CREATE TABLE Category (
    CategoryId SMALLINT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    NameArabic NVARCHAR(60) NOT NULL,
    NameKurdish NVARCHAR(60) NOT NULL,
    CategoryLevel VARCHAR(20),
    ImageUrl VARCHAR(255),
    ParentId SMALLINT NULL,
    UrlSlug VARCHAR(255) NOT NULL UNIQUE,
    HierarchyPath HIERARCHYID NULL,
    UNIQUE (Name, ParentId),
    FOREIGN KEY (ParentId) REFERENCES Category(CategoryId)
);


CREATE NONCLUSTERED INDEX IX_Category_HierarchyPath ON Category (HierarchyPath);
CREATE UNIQUE NONCLUSTERED INDEX IX_Category_UrlSlug ON Category(UrlSlug);


-- Brands & Models Table جدول العلامات التجارية والموديلات
CREATE TABLE BrandModel (
    BrandModelId SMALLINT IDENTITY(1,1) PRIMARY KEY,                    -- Auto-incremented ID
    Name VARCHAR(50) NOT NULL,                                -- English name
    NameArabic NVARCHAR(50),                                     -- Arabic name
    NameKurdish NVARCHAR(50),                                     -- Kurdish name
    UrlSlug VARCHAR(255) NOT NULL UNIQUE,                    -- For clean URLs like 'toyota' or 'corolla'
    IsBrand BIT NOT NULL,                                    -- 1 = Brand, 0 = Model
    ParentId SMALLINT,                                       -- Brand ID (for models)
    CategoryId SMALLINT NOT NULL,                            -- Linked category
    ImageUrl VARCHAR(255) NOT NULL,                          -- Image URL
    HierarchyPath HIERARCHYID NULL,                          -- HIERARCHYID for hierarchy
    -- level AS hierarchy_path.GetLevel(),                    -- Optional computed level

    UNIQUE (Name, ParentId, CategoryId),
    CONSTRAINT FK_BrandModel_Category FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId),
    CONSTRAINT FK_BrandModel_Parent FOREIGN KEY (ParentId) REFERENCES BrandModel(BrandModelId),
    CONSTRAINT CHK_BrandModel_Hierarchy CHECK (
        (IsBrand = 1 AND ParentId IS NULL) OR
        (IsBrand = 0 AND ParentId IS NOT NULL)
    )
);

CREATE NONCLUSTERED INDEX IX_BrandModel_HierarchyPath ON BrandModel (HierarchyPath);
CREATE UNIQUE NONCLUSTERED INDEX IX_BrandModel_UrlSlug ON BrandModel(UrlSlug);

--FULL URL /{lang}/{category_slug}/{subcategory_slug}/{brand_slug}/{model_slug}/{release_year_slug}

-- Sub Models Table
CREATE TABLE ModelRelease (
    ModelReleaseId SMALLINT IDENTITY(1,1) PRIMARY KEY,                -- Unique ID
    ModelId SMALLINT NOT NULL,                           -- FK to brands_models (must be a model)
    ReleaseYear SMALLINT NOT NULL CHECK (ReleaseYear BETWEEN 1900 AND 2100),
    UrlSlug VARCHAR(20) NOT NULL,                        -- For URL (e.g., '2020')
    ImageUrl VARCHAR(255) NOT NULL,                      -- Optional image (e.g., car photo)

    UNIQUE (ModelId, ReleaseYear),                  -- No duplicate releases per model
    FOREIGN KEY (ModelId) REFERENCES BrandModel(BrandModelId)
);

CREATE NONCLUSTERED INDEX IX_ModelRelease_ModelId_UrlSlug ON ModelRelease(ModelId, UrlSlug);



CREATE TABLE ads (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),

   title NVARCHAR(255) NOT NULL CHECK (LEN(TRIM(title)) >= 3), -- عنوان الإعلان (3 أحرف على الأقل)
   description NVARCHAR(512), -- وصف الإعلان
   price DECIMAL(10,2) CHECK (price >= 0), -- السعر (لا يمكن أن يكون سالباً)
   is_active BIT DEFAULT 1 NOT NULL, -- 0=غير نشط، 1=نشط
   created_at DATETIME2 DEFAULT SYSDATETIME() NOT NULL, -- تاريخ ووقت إنشاء الإعلان
   image_count INT DEFAULT 0,             -- Number of images for the ad
   views_count INT DEFAULT 0 NOT NULL, -- Number of times the ad has been viewed


    showing_price NVARCHAR(50),
    is_dollar BIT, -- 0 IQD, 1 $ for transport_attrs, electronic_attrs, video_games_attrs ONLY!

   NewUser_id UNIQUEIDENTIFIER NOT NULL, -- معرف المستخدم
   address_id UNIQUEIDENTIFIER NOT NULL, -- معرف العنوان
   category_id SMALLINT NOT NULL, -- معرف الفئة

   priority TINYINT NOT NULL DEFAULT 4 CHECK (priority BETWEEN 1 AND 4), -- أولوية الإعلان: 1=عالي جداً، 2=عالي، 3=متوسط، 4=عادي (افتراضي)

   FOREIGN KEY (NewUser_id) REFERENCES NewUsers(id),
   FOREIGN KEY (category_id) REFERENCES categories(id),
   FOREIGN KEY (address_id) REFERENCES addresses(id),
);

-- جدول صور الإعلان
CREATE TABLE ad_images (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   image_url NVARCHAR(255), -- رابط الصورة
   image_order TINYINT CHECK (image_order BETWEEN 1 AND 5), -- ترتيب الصورة (1-5)
   ad_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإعلان
   FOREIGN KEY (ad_id) REFERENCES ads(id) ON DELETE CASCADE ON UPDATE CASCADE
);


-- WE COULD USE CACHE INSTEAD

-- -- Favorite Ads Table  جدول الإعلانات المفضلة
-- CREATE TABLE favorite_ads (
--    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
--    added_at DATETIME2(0) DEFAULT GETDATE(), -- تاريخ الإضافة 
--    ad_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإعلان
--    NewUser_id UNIQUEIDENTIFIER NOT NULL, -- معرف المستخدم
--    UNIQUE (id, ad_id), -- لمنع تكرار نفس الإعلان في مفضلة نفس المستخدم
--    FOREIGN KEY (NewUser_id) REFERENCES NewUsers(id),
--    FOREIGN KEY (ad_id) REFERENCES ads(id) ON DELETE CASCADE ON UPDATE CASCADE
-- );


-- POSTPONE FOR NOW! 

-- -- جدول المدفوعات
-- CREATE TABLE payments (
--    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
--    amount DECIMAL(10,2) NOT NULL CHECK (amount > 0), -- المبلغ (يجب أن يكون أكبر من صفر)
--    payment_type TINYINT NOT NULL CHECK (payment_type BETWEEN 1 AND 2), -- نوع الدفع: 1=ترويج إعلان، 2=اشتراك
--    created_at DATETIME DEFAULT GETDATE(), -- تاريخ الإنشاء
--    NewUser_id UNIQUEIDENTIFIER NOT NULL, -- معرف المستخدم
--    FOREIGN KEY (NewUser_id) REFERENCES NewUsers(id)
-- );

-- -- Ad Promotions Table جدول ترقيات الإعلانات
-- CREATE TABLE ad_promotions (
--    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
--     created_at DATETIME2(0) DEFAULT GETDATE(), -- وقت إنشاء الترقية (بدقة ثانية واحدة)
--     payment_id UNIQUEIDENTIFIER NOT NULL, -- معرف عملية الدفع
--     ad_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإعلان
--     FOREIGN KEY (payment_id) REFERENCES payments(id),
--     FOREIGN KEY (ad_id) REFERENCES ads(id) ON DELETE CASCADE
-- );

-- -- Subscriptions Table جدول الاشتراكات
-- CREATE TABLE subscriptions (
--    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
--    start_date DATE NOT NULL, -- تاريخ بداية الاشتراك (بدون وقت)
--    end_date DATE NOT NULL, -- تاريخ نهاية الاشتراك (بدون وقت)
--    payment_id UNIQUEIDENTIFIER NOT NULL, -- معرف الدفع
--    NewUser_id UNIQUEIDENTIFIER NOT NULL, -- معرف المستخدم
--    CONSTRAINT check_dates CHECK (end_date > start_date), -- للتأكد من أن تاريخ النهاية بعد البداية
--    FOREIGN KEY (NewUser_id) REFERENCES NewUsers(id),
--    FOREIGN KEY (payment_id) REFERENCES payments(id)
-- );




-- USING NON-RELATIONAL DB INSTEAD

-- example how mongodb collection would look like
-- {
--   "_id": "64a7b3d12f7b9e1234567890",
--   "AdId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
--   "InitiatorId": "2da95f64-5717-4562-b3fc-2c963f66afa6", 
--   "RecipientId": "1ea85f64-5717-4562-b3fc-2c963f66afa6",
--   "CreatedAt": "2023-07-06T15:32:33.123Z",
--   "Messages": [
--     {
--       "Id": "6fa85f64-5717-4562-b3fc-2c963f66afa6",
--       "SenderId": "2da95f64-5717-4562-b3fc-2c963f66afa6",
--       "Content": "Hello, I'm interested in your translation services",
--       "VoiceUrl": null,
--       "ImageUrl": null,
--       "SentAt": "2023-07-06T15:32:33.123Z",
--       "IsRead": true
--     },
--     {
--       "Id": "7fa85f64-5717-4562-b3fc-2c963f66afa6",
--       "SenderId": "1ea85f64-5717-4562-b3fc-2c963f66afa6",
--       "Content": "Here's an example of my work",
--       "VoiceUrl": null,
--       "ImageUrl": "https://storage.example.com/images/sample123.jpg",
--       "SentAt": "2023-07-06T15:35:10.456Z",
--       "IsRead": false
--     }
--   ]
-- }


-- -- Conversation Table جدول المحادثات
-- CREATE TABLE conversations (
--    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
--    created_at DATETIME2(0) DEFAULT GETDATE(), -- تاريخ الإنشاء (دقة ثانية واحدة)
--    ad_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإعلان
--    initiator_id UNIQUEIDENTIFIER NOT NULL, -- معرف المبادر بالمحادثة
--    recipient_id UNIQUEIDENTIFIER NOT NULL, -- معرف المستلم
--    CONSTRAINT FK_conversations_ads FOREIGN KEY (ad_id) REFERENCES ads(id),
--    CONSTRAINT FK_conversations_initiator FOREIGN KEY (initiator_id) REFERENCES NewUsers(id),
--    CONSTRAINT FK_conversations_recipient FOREIGN KEY (recipient_id) REFERENCES NewUsers(id),
--    CONSTRAINT CK_different_NewUsers CHECK (initiator_id != recipient_id) -- التحقق من أن المبادر والمستلم مستخدمين مختلفين
-- );

-- -- Message Table جدول الرسائل
-- CREATE TABLE [messages] (
--    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
--    content NVARCHAR(MAX) NULL, -- محتوى الرسالة النصية
--    voice_url VARCHAR(255) NULL, -- رابط الرسالة الصوتية
--    sent_at DATETIME2(0) DEFAULT GETDATE(), -- تاريخ الإرسال
--    sender_id UNIQUEIDENTIFIER NOT NULL, -- معرف المرسل
--    conversations_id UNIQUEIDENTIFIER NOT NULL, -- معرف المحادثة
--    FOREIGN KEY (conversations_id) REFERENCES conversations(id) ON DELETE CASCADE,
--    FOREIGN KEY (sender_id) REFERENCES NewUsers(id),
--    CHECK (content IS NOT NULL OR voice_url IS NOT NULL) -- يجب أن تحتوي الرسالة على نص أو صوت
-- );

-- Transport Attributes Table جدول سمات وسائل النقل
CREATE TABLE transport_attrs (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   fuel_type TINYINT CHECK (fuel_type BETWEEN 1 AND 6), -- نوع الوقود: 1=بنزين، 2=ديزل (كاز)، 3=كهرباء، 4=هجين، 5=غاز، 6=أخرى
   engine_power SMALLINT CHECK (engine_power BETWEEN 1 AND 9999), -- قوة المحرك (حصان)
   fuel_tank_capacity SMALLINT CHECK (fuel_tank_capacity BETWEEN 1 AND 1000), -- سعة خزان الوقود (لتر)
   --is_dollar BIT, -- 0 IQD, 1 $
   ad_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإعلان
   FOREIGN KEY (ad_id) REFERENCES ads(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Car Attributes Table  جدول سمات السيارات
-- جدول سمات السيارات
CREATE TABLE car_attrs (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   is_new BIT NOT NULL, -- 1=مستعمل، 0=جديد
   engine_description NVARCHAR(50), -- وصف المحرك (إدخال يدوي) مثال: توربو، سوبر تشارج، تيربو مزدوج
   cylinders TINYINT CHECK (cylinders IN (3,4,5,6,8,10,12)), -- عدد السلندرات
   transmission TINYINT CHECK (transmission BETWEEN 1 AND 3), -- ناقل الحركة: 1=يدوي، 2=أوتوماتيك، 3=مزوج (أوتوماتيك وعادي
   drive_type TINYINT CHECK (drive_type BETWEEN 1 AND 3), -- نوع الدفع: 1=أمامي، 2=خلفي، 3=رباعي
   color NVARCHAR(30), -- اللون
   
   transport_attrs_id UNIQUEIDENTIFIER NOT NULL,
   sub_model_release_id SMALLINT NOT NULL,
   model_id SMALLINT NOT NULL,
   
   FOREIGN KEY (transport_attrs_id) REFERENCES transport_attrs(id),
   FOREIGN KEY (sub_model_release_id) REFERENCES sub_model_releases(id),
   FOREIGN KEY (model_id) REFERENCES brands_models(id)
);

-- Trucks Properties Table  جدول سمات الشاحنات
CREATE TABLE truck_attrs (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   load_capacity DECIMAL(6,2) CHECK (load_capacity BETWEEN 0.5 AND 100), -- قدرة التحميل (طن)
   number_of_axles TINYINT CHECK (number_of_axles BETWEEN 2 AND 12), -- عدد المحاور
   transport_attrs_id UNIQUEIDENTIFIER NOT NULL, -- معرف خصائص المعدات الثقيلة
   model_id SMALLINT NOT NULL, -- معرف الماركة والموديل
   FOREIGN KEY (model_id) REFERENCES brands_models(id),
   FOREIGN KEY (transport_attrs_id) REFERENCES transport_attrs(id)
);

-- Motorcycles Attributes Table جدول سمات الدراجات النارية
CREATE TABLE motorcycle_attrs (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   drive_type TINYINT CHECK (drive_type BETWEEN 1 AND 3), -- نوع الدفع: 1=سلسلة، 2=حزام، 3=عمود
   gear_count TINYINT CHECK (gear_count BETWEEN 1 AND 10), -- عدد السرعات
   
   transport_attrs_id UNIQUEIDENTIFIER NOT NULL, -- معرف خصائص النقل
   model_id SMALLINT NOT NULL, -- معرف الماركة والموديل
   FOREIGN KEY (model_id) REFERENCES brands_models(id),
   FOREIGN KEY (transport_attrs_id) REFERENCES transport_attrs(id)
);

-- Heavy Equipment Attributes Table  جدول سمات المعدات الثقيلة
CREATE TABLE heavy_equipment_attrs (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   operating_mass DECIMAL(8,2) CHECK (operating_mass BETWEEN 1 AND 9999.99), -- الوزن التشغيلي (كغ)
   weight DECIMAL(8,2) CHECK (weight BETWEEN 1 AND 9999), -- الوزن الاساسي (طن)
   transport_attrs_id UNIQUEIDENTIFIER NOT NULL, -- معرف خصائص النقل
   FOREIGN KEY (transport_attrs_id) REFERENCES transport_attrs(id)
);

-- Bulldozers Properties Table  جدول سمات البلدوزرات
CREATE TABLE bulldozer_attrs (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   blade_width DECIMAL(5,2) CHECK (blade_width BETWEEN 1 AND 100), -- عرض الشفرة (م)
   max_pushing_capacity DECIMAL(8,2) CHECK (max_pushing_capacity BETWEEN 1 AND 1000), -- أقصى قدرة دفع (طن)
   track_width DECIMAL(4,2) CHECK (track_width BETWEEN 0.3 AND 10), -- عرض المسار (م)
   heavy_equipment_attrs_id UNIQUEIDENTIFIER NOT NULL, -- معرف خصائص المعدات الثقيلة
   FOREIGN KEY (heavy_equipment_attrs_id) REFERENCES heavy_equipment_attrs(id)
);

-- Cranes Properties Table جدول سمات الرافعات
CREATE TABLE crane_attrs (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   lifting_capacity DECIMAL(8,2) CHECK (lifting_capacity BETWEEN 0 AND 1000), -- قدرة الرفع (طن)
   max_lifting_height DECIMAL(5,2) CHECK (max_lifting_height BETWEEN 0 AND 500), -- أقصى ارتفاع للرفع (م)
   boom_length DECIMAL(5,2) CHECK (boom_length BETWEEN 0 AND 500), -- طول الذراع (م)
   rotation_angle SMALLINT CHECK (rotation_angle BETWEEN 0 AND 360), -- زاوية الدوران (درجة)
   heavy_equipment_attrs_id UNIQUEIDENTIFIER NOT NULL, -- معرف خصائص المعدات الثقيلة
   FOREIGN KEY (heavy_equipment_attrs_id) REFERENCES heavy_equipment_attrs(id)
);

-- Bus Properties Table
CREATE TABLE bus_attrs (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	seating_capacity TINYINT CHECK (seating_capacity BETWEEN 1 AND 100), -- عدد المقاعد (1-100)
	heavy_equipment_attrs_id UNIQUEIDENTIFIER NOT NULL, -- معرف خصائص المعدات الثقيلة
	FOREIGN KEY (heavy_equipment_attrs_id) REFERENCES heavy_equipment_attrs(id)
);

-- Excavators Properties Table جدول سمات الحفارات
CREATE TABLE excavator_attrs (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   bucket_capacity DECIMAL(3,1) CHECK (bucket_capacity BETWEEN 0.1 AND 30.0), -- سعة الدلو (م مكعب)
   max_digging_depth DECIMAL(5,2) CHECK (max_digging_depth BETWEEN 0 AND 100.00), -- أقصى عمق للحفر (م)
   heavy_equipment_attrs_id UNIQUEIDENTIFIER NOT NULL, -- معرف خصائص المعدات الثقيلة
   FOREIGN KEY (heavy_equipment_attrs_id) REFERENCES heavy_equipment_attrs(id)
);


-- Boats and Marine Attributes Table
CREATE TABLE boat_and_marine_attrs (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	length DECIMAL(5,2) CHECK (length BETWEEN 1 AND 100), -- الطول (م)
    capacity TINYINT CHECK (capacity BETWEEN 1 AND 100), -- السعة (عدد الأشخاص)
	transport_attrs_id UNIQUEIDENTIFIER NOT NULL, -- معرف خصائص النقل
	FOREIGN KEY (transport_attrs_id) REFERENCES transport_attrs(id)
);

-- Real Estate Attributes Table
CREATE TABLE real_estate_attrs (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    area DECIMAL(10,2), -- المساحة (متر مربع)
	ad_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإعلان
   FOREIGN KEY (ad_id) REFERENCES ads(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- جدول سمات المنازل
CREATE TABLE house_attrs (
	id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	floors TINYINT CHECK (floors BETWEEN 1 AND 10), -- عدد الطوابق
	bedrooms TINYINT CHECK (bedrooms BETWEEN 1 AND 20), -- عدد غرف النوم
	bathrooms TINYINT CHECK (bathrooms BETWEEN 1 AND 10), -- عدد الحمامات
	garage BIT, -- وجود كراج (0=لا، 1=نعم)
	garden BIT, -- وجود حديقة (0=لا، 1=نعم)
	is_new BIT, -- 1 مستعمل، 0 جديد
	real_estate_attrs_id UNIQUEIDENTIFIER NOT NULL, -- معرف خصائص العقار
	FOREIGN KEY (real_estate_attrs_id) REFERENCES real_estate_attrs(id)
);

-- جدول سمات المشاريع تحت الإنشاء
CREATE TABLE project_under_construction_attrs (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    completion_status TINYINT CHECK (completion_status BETWEEN 1 AND 3), -- نسبة الإنجاز: 1=تحت الإنشاء، 2=قيد التشطيب، 3=تشطيب كامل
    real_estate_attrs_id UNIQUEIDENTIFIER REFERENCES real_estate_attrs(id) -- معرف خصائص العقار
);

-- جدول سمات الشقق
CREATE TABLE apartment_attrs (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    is_new BIT, -- 1 قديمة، 0 جديدة
    bedrooms TINYINT CHECK (bedrooms BETWEEN 0 AND 10), -- للتحقق من صحة عدد الغرف
    bathrooms TINYINT CHECK (bathrooms BETWEEN 0 AND 10), -- للتحقق من صحة عدد الحمامات
    elevator BIT, -- وجود مصعد (0=لا، 1=نعم)
    furnished BIT, -- مفروش (0=لا، 1=نعم)
    floor_number TINYINT CHECK (floor_number BETWEEN 0 AND 99), -- للتحقق من صحة رقم الطابق
	real_estate_attrs_id UNIQUEIDENTIFIER, -- معرف خصائص العقار
	FOREIGN KEY (real_estate_attrs_id) REFERENCES real_estate_attrs(id)
);

-- General Electronics Attributes Table جدول سمات الإلكترونيات العامة
CREATE TABLE electronic_attrs (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    is_new BIT, -- 1 مستعمل، 0 جديد
    warranty_type TINYINT CHECK (warranty_type BETWEEN 0 AND 4), -- نوع الضمان: 0=بدون، 1=وكيل، 2=محل، 3=مصنع، 4=دولي
    warranty_months TINYINT CHECK (warranty_months BETWEEN 0 AND 60), -- مدة الضمان بالأشهر
	--is_dollar BIT, -- 0 IQD, 1 $
    ad_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإعلان
    FOREIGN KEY (ad_id) REFERENCES ads(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Laptops and Desktop Computers Attributes Table جدول سمات الحواسيب والأجهزة المحمولة
CREATE TABLE computer_and_laptop_attrs (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   processor_type TINYINT CHECK (processor_type BETWEEN 1 AND 6), -- نوع المعالج: 1=Intel Core i3, 2=i5, 3=i7, 4=i9, 5=AMD Ryzen, 6=Other
   ram_size TINYINT CHECK (ram_size IN (4,8,16,32,64)), -- حجم الذاكرة بالجيجابايت
   storage_type BIT, -- نوع التخزين: 0=HDD, 1=SSD
   storage_size SMALLINT CHECK (storage_size IN (128,256,512,1024,2048)), -- سعة التخزين بالجيجابايت
   graphics_type TINYINT CHECK (graphics_type BETWEEN 1 AND 4), -- 1=Integrated, 2=NVIDIA, 3=AMD, 4=Other
   os_type TINYINT CHECK (os_type BETWEEN 1 AND 4), -- نظام التشغيل: 1=Windows, 2=macOS, 3=Linux, 4=Other
   screen_size DECIMAL(3,1) CHECK (screen_size BETWEEN 11.0 AND 32.0), -- حجم الشاشة بالبوصة
   is_touchscreen BIT, -- شاشة لمس: 0=لا، 1=نعم
   usb_ports TINYINT CHECK (usb_ports BETWEEN 0 AND 10), -- عدد منافذ USB
   hdmi_ports TINYINT CHECK (hdmi_ports BETWEEN 0 AND 4), -- عدد منافذ HDMI
   
   electronic_attrs_id UNIQUEIDENTIFIER NOT NULL, -- معرف السمات الإلكترونية
   model_id SMALLINT NOT NULL, -- معرف العلامة التجارية/الموديل
   
   FOREIGN KEY (model_id) REFERENCES brands_models(id),
   FOREIGN KEY (electronic_attrs_id) REFERENCES electronic_attrs(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Television Attributes Table جدول سمات الشاشات والتلفزيونات
CREATE TABLE monitor_and_television_attrs (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   screen_size DECIMAL(4,1) CHECK (screen_size BETWEEN 20 AND 100), -- حجم الشاشة (20-100 بوصة)
   resolution TINYINT CHECK (resolution BETWEEN 1 AND 5), -- الدقة: 1=HD, 2=FHD, 3=2K, 4=4K, 5=8K
   smart_tv BIT, -- تلفزيون ذكي (0=لا، 1=نعم)
   refresh_rate TINYINT CHECK (refresh_rate IN (60,75,90,120,144,165,240)), -- معدل التحديث (هرتز)
   hdmi_ports TINYINT CHECK (hdmi_ports BETWEEN 1 AND 8), -- عدد منافذ HDMI
   usb_ports TINYINT CHECK (usb_ports BETWEEN 0 AND 8), -- عدد منافذ USB
   
   electronic_attrs_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإلكترونيات
   model_id SMALLINT NOT NULL, -- معرف العلامة التجارية

   FOREIGN KEY (model_id) REFERENCES brands_models(id),
   FOREIGN KEY (electronic_attrs_id) REFERENCES electronic_attrs(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Mobile Phones Attributes Table جدول سمات الهواتف الذكية والأجهزة اللوحية
CREATE TABLE smart_phone_and_tablet_attrs (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   storage_capacity SMALLINT CHECK (storage_capacity IN (16,32,64,128,256,512,1024)), -- سعة التخزين (جيجابايت)
   ram TINYINT CHECK (ram IN (1,2,3,4,6,8,12,16,32)), -- الذاكرة العشوائية (جيجابايت)
   color TINYINT CHECK (color BETWEEN 1 AND 10), -- اللون: 1=أسود، 2=أبيض، 3=ذهبي، 4=فضي، 5=أزرق، 6=أحمر، 7=أخضر، 8=وردي، 9=بنفسجي، 10=آخر
   main_camera BIT, -- 0 لا يدعم، 1 يدعم
   front_camera BIT, -- 0 لا يدعم، 1 يدعم
   main_camera_resolution DECIMAL(4,1) CHECK (main_camera_resolution BETWEEN 0 AND 200), -- دقة الكاميرا الرئيسية (ميجابكسل)
   front_camera_resolution DECIMAL(3,1) CHECK (front_camera_resolution BETWEEN 0 AND 50), -- دقة الكاميرا الأمامية (ميجابكسل)
   battery_capacity SMALLINT CHECK (battery_capacity BETWEEN 1000 AND 15000), -- سعة البطارية (مللي أمبير)
   screen_size DECIMAL(3,1) CHECK (screen_size BETWEEN 3.0 AND 14.0), -- حجم الشاشة (بوصة)
   processor TINYINT CHECK (processor BETWEEN 1 AND 8), -- المعالج: 1=Snapdragon، 2=MediaTek، 3=Apple، 4=Exynos، 5=Kirin، 6=Dimensity، 7=Bionic، 8=آخر
   dual_sim BIT, -- 0 لا يدعم، 1 يدعم شريحتين
   waterproof_support BIT, -- 0 لا يدعم، 1 يدعم مقاومة الماء
   stylus_support BIT, -- 0 لا يدعم، 1 يدعم القلم
   
   electronic_attrs_id UNIQUEIDENTIFIER NOT NULL,
   model_id SMALLINT NOT NULL, -- معرف العلامة التجارية
   
   FOREIGN KEY (model_id) REFERENCES brands_models(id),
   FOREIGN KEY (electronic_attrs_id) REFERENCES electronic_attrs(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Consoles Attributes Table جدول سمات أجهزة الألعاب
CREATE TABLE console_attrs (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   storage_capacity SMALLINT CHECK (storage_capacity BETWEEN 1 AND 4000), -- سعة التخزين (جيجابايت)
   region TINYINT CHECK (region BETWEEN 1 AND 5), -- المنطقة: 1=أمريكا، 2=أوروبا، 3=اليابان، 4=جميع المناطق، 5=أخرى
   
   electronic_attrs_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإلكترونيات
   model_id SMALLINT NOT NULL, -- معرف العلامة التجارية
   
   FOREIGN KEY (model_id) REFERENCES brands_models(id),
   FOREIGN KEY (electronic_attrs_id) REFERENCES electronic_attrs(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Video Games Attributes Table
CREATE TABLE video_games_attrs (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	model_id SMALLINT NOT NULL, -- معرف العلامة التجارية
    region TINYINT CHECK (region BETWEEN 1 AND 5), -- المنطقة: 1=امريكي 2=اوربي, 3=ياباني, 4=شامل، 5=اخرى
	ad_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإعلان
	
	FOREIGN KEY (model_id) REFERENCES brands_models(id),
	FOREIGN KEY (ad_id) REFERENCES ads(id) ON DELETE CASCADE ON UPDATE CASCADE
);


-- Shoe Attributes Table - جدول سمات الأحذية
CREATE TABLE shoe_attrs (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    size INT CHECK (size BETWEEN 20 AND 60), -- المقاس (رقم الحذاء)
    is_new BIT, -- 1=جديد، 0=مستعمل
    ad_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإعلان
    
    FOREIGN KEY (ad_id) REFERENCES ads(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Cloth Attributes Table - جدول سمات الملابس
CREATE TABLE cloth_attrs (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    size TINYINT CHECK (size BETWEEN 1 AND 8), -- المقاس: 1=XS، 2=S، 3=M، 4=L، 5=XL، 6=XXL، 7=XXXL، 8=أخرى
    is_new BIT, -- 1=جديد، 0=مستعمل
    is_summer BIT, -- الموسم: 1=صيف، 0=شتاء
    ad_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإعلان
    
    FOREIGN KEY (ad_id) REFERENCES ads(id) ON DELETE CASCADE ON UPDATE CASCADE
);


-- جدول سمات الأثاث والديكور Furniture and Decor Attributes Table
CREATE TABLE furniture_and_decor_attrs (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   material TINYINT CHECK (material BETWEEN 1 AND 8), -- المادة: 1=خشب، 2=معدن، 3=زجاج، 4=بلاستيك، 5=قماش، 6=جلد، 7=رخام، 8=أخرى
   length SMALLINT CHECK (length BETWEEN 1 AND 1000), -- الطول (سم)
   width SMALLINT CHECK (width BETWEEN 1 AND 1000), -- العرض (سم)
   height SMALLINT CHECK (height BETWEEN 1 AND 500), -- الارتفاع (سم)
   ad_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإعلان
   FOREIGN KEY (ad_id) REFERENCES ads(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Garden and Plant Attributes Table
CREATE TABLE garden_and_plant_attrs (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    height DECIMAL(5,2), -- الارتفاع (سم)
	is_indoor BIT, -- نوع النبات (1 = ظل، 0 = شمسي)
	ad_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإعلان
    FOREIGN KEY (ad_id) REFERENCES ads(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- جدول سمات الإطارات والعجلات Tires and Wheels Attributes Table
CREATE TABLE tire_and_wheel_attrs (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    width DECIMAL(5,2) CHECK (width BETWEEN 13.5 AND 100), -- عرض الإطار (13.5 سم - 100 سم)
    diameter DECIMAL(5,2) CHECK (diameter BETWEEN 33.02 AND 121.92), -- قطر العجلة (33.02 سم - 121.92 سم)
	height DECIMAL(5,2), -- الارتفاع الفعلي (سم) يتم إدخاله يدويًا
    ad_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإعلان
    FOREIGN KEY (ad_id) REFERENCES ads(id) ON DELETE CASCADE ON UPDATE CASCADE
);


-- Car Accessories Attributes Table DELETED!!
CREATE TABLE car_accessory_attrs (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    color NVARCHAR(50), -- اللون
    material TINYINT CHECK (material BETWEEN 1 AND 6), -- المادة: 1=بلاستيك، 2=معدن، 3=جلد، 4=قماش، 5=مطاط، 6=آخر
	ad_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإعلان
    FOREIGN KEY (ad_id) REFERENCES ads(id) ON DELETE CASCADE ON UPDATE CASCADE

);

-- Engine oil Attributes Table !NOT COMPLETED! take look for engine-oil_example.json for complete attrs  
CREATE TABLE engine_oil_attrs (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),

    volume DECIMAL(7,2) CHECK (volume BETWEEN 0.01 AND 99999.99), -- الحجم (لتر)
	ad_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإعلان
    

    model_id SMALLINT NOT NULL, -- معرف العلامة التجارية


    FOREIGN KEY (model_id) REFERENCES brands_models(id),
   FOREIGN KEY (ad_id) REFERENCES ads(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- جدول سمات الكتب
CREATE TABLE book_attrs (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   book_language TINYINT CHECK (book_language BETWEEN 1 AND 4), -- اللغة: 1=العربية، 2=الكردية، 3=الانجليزية، 4=أخرى
   pages SMALLINT CHECK (pages BETWEEN 1 AND 10000), -- عدد الصفحات (1-10000)
   ad_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإعلان
   FOREIGN KEY (ad_id) REFERENCES ads(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- جدول سمات فرص العمل Vacancy Attributes Table
CREATE TABLE vacancy_attrs (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   job_type TINYINT CHECK (job_type BETWEEN 1 AND 5), -- نوع الوظيفة: 1=دوام كامل، 2=دوام جزئي، 3=عن بعد، 4=مؤقت، 5=تدريب
   experience_years TINYINT CHECK (experience_years BETWEEN 0 AND 50), -- سنوات الخبرة المطلوبة
   education_level TINYINT CHECK (education_level BETWEEN 1 AND 6), -- المستوى التعليمي: 1=ثانوي، 2=دبلوم، 3=بكالوريوس، 4=ماجستير، 5=دكتوراه، 6=غير مطلوب
   working_hours TINYINT CHECK (working_hours BETWEEN 1 AND 4), -- ساعات العمل: 1=صباحي، 2=مسائي، 3=نوبات، 4=مرن
   ad_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإعلان
   FOREIGN KEY (ad_id) REFERENCES ads(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- NewUser CV Table جدول السيرة الذاتية للمستخدم
CREATE TABLE cv_attrs (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   first_name NVARCHAR(50) NOT NULL, -- الاسم الأول
   last_name NVARCHAR(50) NOT NULL, -- الاسم الأخير
   gender BIT CHECK (gender IN (0, 1)), -- الجنس: 0=ذكر، 1=أنثى
   date_of_birth DATE CHECK (date_of_birth > '1940-01-01'), -- تاريخ الميلاد
   phone_number VARCHAR(20), -- رقم الهاتف (changed from NVARCHAR as numbers are ASCII)
   contact_email VARCHAR(255), -- Contact email
   ad_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإعلان
   FOREIGN KEY (ad_id) REFERENCES ads(id) ON DELETE CASCADE ON UPDATE CASCADE,
   CHECK (phone_number IS NOT NULL OR contact_email IS NOT NULL)
);


-- Education Table  جدول التعليم
CREATE TABLE educations (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   institution_name NVARCHAR(100) NOT NULL, -- اسم المؤسسة التعليمية
   degree TINYINT CHECK (degree BETWEEN 1 AND 6) NOT NULL, -- الدرجة: 1=ثانوي، 2=دبلوم، 3=بكالوريوس، 4=ماجستير، 5=دكتوراه، 6=أخرى
   field_study TINYINT CHECK (field_study BETWEEN 1 AND 6), -- المجال: 1=هندسة، 2=طب، 3=علوم، 4=تجارة، 5=تعليم، 6=أخرى
   start_date DATE NOT NULL, -- تاريخ البدء
   end_date DATE, -- تاريخ الانتهاء
   cv_attrs_id UNIQUEIDENTIFIER NOT NULL, -- معرف السيرة الذاتية
   FOREIGN KEY (cv_attrs_id) REFERENCES cv_attrs(id) ON DELETE CASCADE ON UPDATE CASCADE,
   CHECK (end_date >= start_date) -- للتأكد من أن تاريخ الانتهاء بعد تاريخ البدء
);

-- Experience Table جدول الخبرات العملية
CREATE TABLE experiences (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   company_name VARCHAR(100), -- اسم الشركة
   position VARCHAR(100), -- المنصب
   start_date DATE, -- تاريخ البدء
   end_date DATE, -- تاريخ الانتهاء
   cv_attrs_id UNIQUEIDENTIFIER NOT NULL, -- معرف السيرة الذاتية
   FOREIGN KEY (cv_attrs_id) REFERENCES cv_attrs(id) ON DELETE CASCADE ON UPDATE CASCADE,
   CONSTRAINT chk_dates CHECK (end_date IS NULL OR end_date >= start_date) -- للتأكد من صحة التواريخ
);

CREATE TABLE languages (
   id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
   name NVARCHAR(50), -- Language name (e.g., English, Arabic)
   proficiency TINYINT CHECK (proficiency BETWEEN 1 AND 5), -- مستوى الإتقان: 1=أساسي، 2=متوسط، 3=طليق، 4=لغة أم، 5=آخر
   cv_attrs_id UNIQUEIDENTIFIER NOT NULL, -- Foreign key linking to the cv_attrs table
   FOREIGN KEY (cv_attrs_id) REFERENCES cv_attrs(id) ON DELETE CASCADE ON UPDATE CASCADE
);








-- Service Attributes Table (Service-level attributes only)
CREATE TABLE service_attrs (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    price_type TINYINT CHECK (price_type BETWEEN 1 AND 6), -- 1=للخدمة، 2=للمتر، 3=للقطعة، 4=للساعة، 5=لليوم، 6=للدقيقة
    ad_id UNIQUEIDENTIFIER NOT NULL, -- معرف الإعلان
    FOREIGN KEY (ad_id) REFERENCES ads(id) ON DELETE CASCADE ON UPDATE CASCADE
    -- Add any other service-level attributes here
);
GO

-- Service Daily Availability Table (per day, with 24-hour flag)
CREATE TABLE service_daily_availability (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    service_attr_id UNIQUEIDENTIFIER NOT NULL, -- Link to the service attributes
    day_of_week TINYINT CHECK (day_of_week BETWEEN 1 AND 7), -- 1=Sunday, 2=Monday, 3=Tuesday, 4=Wednesday, 5=Thursday, 6=Friday, 7=Saturday
    is_available BIT DEFAULT 0, -- Toggle for whether the service is available on this day
    is_24_hours BIT DEFAULT 0, -- Whether the service is available 24 hours on this day
    FOREIGN KEY (service_attr_id) REFERENCES service_attrs(id) ON DELETE CASCADE ON UPDATE CASCADE,
    UNIQUE (service_attr_id, day_of_week) -- Ensures only one entry per day per service
);
GO

-- Service Time Slots Table (multiple slots per day)
CREATE TABLE service_time_slots (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
    service_daily_availability_id UNIQUEIDENTIFIER NOT NULL, -- Link to the daily availability entry
    opening_time TIME NOT NULL, -- Store specific opening time
    closing_time TIME NOT NULL, -- Store specific closing time
    FOREIGN KEY (service_daily_availability_id) REFERENCES service_daily_availability(id) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT chk_opening_before_closing CHECK (opening_time < closing_time)
);
GO


-- Returns all time slots for the service on the given day if available and not 24 hours
-- SELECT s.id AS service_id, d.day_of_week, d.is_24_hours, t.opening_time, t.closing_time
-- FROM service_attrs s
-- JOIN service_daily_availability d ON s.id = d.service_attr_id
-- LEFT JOIN service_time_slots t ON d.id = t.service_daily_availability_id
-- WHERE s.id = @service_id AND d.day_of_week = @day_of_week AND d.is_available = 1
-- ORDER BY t.opening_time;

-- Indexes for performance related to services tables
-- CREATE INDEX idx_service_daily_availability_service_attr_id ON service_daily_availability(service_attr_id);
-- CREATE INDEX idx_service_daily_availability_day_of_week ON service_daily_availability(day_of_week);
-- CREATE INDEX idx_service_time_slots_service_daily_availability_id ON service_time_slots(service_daily_availability_id);








-- CREATE INDEX idx_ads_NewUser_id ON ads(NewUser_id);
-- CREATE INDEX idx_ads_category_id ON ads(category_id);
-- CREATE INDEX idx_ads_address_id ON ads(address_id);
-- CREATE INDEX idx_ad_images_ad_id ON ad_images(ad_id);
-- CREATE INDEX idx_ads_title ON ads(title);
-- CREATE INDEX idx_ads_price ON ads(price);
-- CREATE INDEX idx_ads_is_active ON ads(is_active);
-- CREATE INDEX idx_ads_created_at ON ads(created_at);
-- CREATE INDEX idx_ads_category_location ON ads(category_id, address_id);
-- CREATE INDEX idx_ads_active ON ads(is_active) WHERE is_active = 1;



-- STUDY THEN ADD FULL TEXT SEARCH
--Enable full-text search on your database (run once)
-- EXEC sp_fulltext_database 'enable';


-- -- Create unique index to serve as key for full-text index
-- CREATE UNIQUE INDEX UI_ads_id ON ads(id);

-- -- Create full-text catalog (if it doesn't exist already)
-- CREATE FULLTEXT CATALOG ftCatalog AS DEFAULT;

-- -- Create full-text index on ads.title and ads.description
-- CREATE FULLTEXT INDEX ON ads(title, description) KEY INDEX UI_ads_id;



GO
CREATE TRIGGER trg_NewUser_reviews_after_insert_delete
ON NewUser_reviews
AFTER INSERT, DELETE
AS
BEGIN
    -- Update review_count and average_rating for reviewed NewUsers
    UPDATE NewUsers
    SET
        review_count = (SELECT COUNT(*) FROM NewUser_reviews WHERE reviewed_id = NewUsers.id),
        average_rating = (SELECT AVG(CAST(rating AS DECIMAL(2,1))) FROM NewUser_reviews WHERE reviewed_id = NewUsers.id)
    WHERE id IN (
        SELECT reviewed_id FROM inserted
        UNION
        SELECT reviewed_id FROM deleted
    );
END


GO
CREATE TRIGGER trg_ad_images_after_insert_delete
ON ad_images
AFTER INSERT, DELETE
AS
BEGIN
    -- Update image_count for affected ads
    UPDATE ads
    SET image_count = (
        SELECT COUNT(*) FROM ad_images WHERE ad_id = ads.id
    )
    WHERE id IN (
        SELECT ad_id FROM inserted
        UNION
        SELECT ad_id FROM deleted
    );
END


-- THIS TRIGGER POSTPONED FOR NOW!

-- CREATE TRIGGER trg_ads_insert_update
-- ON ads
-- AFTER INSERT, UPDATE
-- AS
-- BEGIN
--     UPDATE a
--     SET
--         NewUser_name = u.name,
--         category_name_ar = c.name_ar,
--         category_name_kr = c.name_kr,
--         location_name_ar = l.name_ar,
--         location_name_kr = l.name_kr
--     FROM ads a
--     INNER JOIN inserted i ON a.id = i.id
--     INNER JOIN NewUsers u ON i.NewUser_id = u.id
--     INNER JOIN categories c ON i.category_id = c.id
--     INNER JOIN addresses ad ON i.address_id = ad.id
--     INNER JOIN locations l ON ad.location_id = l.id
--     WHERE a.id = i.id;
-- END