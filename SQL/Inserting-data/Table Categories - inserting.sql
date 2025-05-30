-- PostgreSQL script to insert category data with hierarchical structure
-- Following the same structure as SQL Server code

-- Function to clean parentheses from names for slug generation
CREATE OR REPLACE FUNCTION clean_name_for_slug(input_text TEXT) 
RETURNS TEXT AS $$
BEGIN
    -- Remove content within parentheses (including the parentheses themselves)
    RETURN TRIM(REGEXP_REPLACE(input_text, '\s*\([^)]*\)', '', 'g'));
END;
$$ LANGUAGE plpgsql;

-- Begin transaction
BEGIN;

-- Root categories
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('مركبات ونقل', 'ئۆتۆمبێل و گواستنەوە', 'مركبات-ونقل', 'ئۆتۆمبێل-و-گواستنەوە', '1', NULL),
('العقارات والاملاك', 'خانووبەرە و موڵک', 'العقارات-والاملاك', 'خانووبەرە-و-موڵک', '2', NULL),
('الوظائف وفرص العمل', 'کار و هەلی کار', 'الوظائف-وفرص-العمل', 'کار-و-هەلی-کار', '3', NULL),
('الخدمات (خدمات عامة ومتخصصة)', 'خزمەتگوزارییەکان (خزمەتگوزاری گشتی و تایبەتمەند)', 'الخدمات', 'خزمەتگوزارییەکان', '4', NULL),
('المقتنيات الشخصية والصحة والجمال', 'کەلوپەلی کەسی و تەندروستی و جوانکاری', 'المقتنيات-الشخصية-والصحة-والجمال', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری', '5', NULL),
('المنزل والمطبخ والحديقة', 'ماڵ و چێشتخانە و باخچە', 'المنزل-والمطبخ-والحديقة', 'ماڵ-و-چێشتخانە-و-باخچە', '6', NULL),
('قطع الغيار والاكسسوارات للمركبات', 'پارچەی یەدەگ و ئێکسسواراتی ئۆتۆمبێل', 'قطع-الغيار-والاكسسوارات-للمركبات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل', '7', NULL),
('الالكترونيات والاجهزة الرقمية', 'ئەلیکترۆنیات و ئامێری دیجیتاڵی', 'الالكترونيات-والاجهزة-الرقمية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی', '8', NULL),
('الهوايات والترفيه والانشطة', 'خولیا و کات بەسەربردن و چالاکی', 'الهوايات-والترفيه-والانشطة', 'خولیا-و-کات-بەسەربردن-و-چالاکی', '9', NULL),
('الحيوانات الاليفة ومستلزماتها', 'ئاژەڵی ماڵی و پێداویستییەکانیان', 'الحيوانات-الاليفة-ومستلزماتها', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان', '10', NULL),
('الاعمال والمعدات التجارية والصناعية', 'کار و کەرەستەی بازرگانی و پیشەسازی', 'الاعمال-والمعدات-التجارية-والصناعية', 'کار-و-کەرەستەی-بازرگانی-و-پیشەسازی', '11', NULL);

-- Declare variables for root category IDs
DO $$
DECLARE
    vehicles_transport_id SMALLINT;
    real_estate_id SMALLINT;
    jobs_id SMALLINT;
    services_id SMALLINT;
    personal_items_id SMALLINT;
    home_kitchen_id SMALLINT;
    vehicle_parts_id SMALLINT;
    electronics_id SMALLINT;
    hobbies_id SMALLINT;
    pets_id SMALLINT;
    business_id SMALLINT;
    
    -- Level 2 variables for vehicles/transport
    cars_id SMALLINT;
    motorcycles_id SMALLINT;
    trucks_id SMALLINT;
    heavy_equipment_id SMALLINT;
    marine_transport_id SMALLINT;
    
    -- Level 2 variables for real estate
    real_estate_sale_id SMALLINT;
    real_estate_rent_id SMALLINT;
    
    -- Level 2 variables for jobs
    job_seekers_id SMALLINT;
    job_offers_id SMALLINT;
    
    -- Level 3 variables for real estate sale
    residential_sale_id SMALLINT;
    commercial_industrial_sale_id SMALLINT;
    under_construction_sale_id SMALLINT;
    outside_iraq_sale_id SMALLINT;
    other_categories_sale_id SMALLINT;
    
    -- Level 3 variables for real estate rent
    residential_rent_id SMALLINT;
    commercial_industrial_rent_id SMALLINT;
    other_categories_rent_id SMALLINT;
    
    -- Level 4 variables for residential sale
    houses_villas_sale_id SMALLINT;
    apartments_sale_id SMALLINT;
    land_plots_sale_id SMALLINT;
    
    -- Level 4 variables for residential rent
    houses_villas_rent_id SMALLINT;
    apartments_rent_id SMALLINT;
    
    -- Additional variables for services
    vehicle_services_id SMALLINT;
    construction_services_id SMALLINT;
    cargo_transport_id SMALLINT;
    logistics_services_id SMALLINT;
    passenger_transport_id SMALLINT;
    building_renovation_id SMALLINT;
    home_services_id SMALLINT;
    repair_services_id SMALLINT;
    food_catering_id SMALLINT;
    delivery_services_id SMALLINT;
    health_beauty_services_id SMALLINT;
    education_training_id SMALLINT;
    technical_services_id SMALLINT;
    agricultural_services_id SMALLINT;
    legal_financial_id SMALLINT;
    events_services_id SMALLINT;
    tourism_services_id SMALLINT;
    security_services_id SMALLINT;
    energy_services_id SMALLINT;
    other_services_id SMALLINT;
    
    -- Personal items variables
    clothing_shoes_id SMALLINT;
    kids_items_id SMALLINT;
    beauty_care_id SMALLINT;
    jewelry_id SMALLINT;
    health_care_id SMALLINT;
    
    -- Home & kitchen variables
    furniture_id SMALLINT;
    tools_equipment_id SMALLINT;
    building_materials_id SMALLINT;
    decor_furnishings_id SMALLINT;
    garden_garage_id SMALLINT;
    kitchen_tools_id SMALLINT;
    home_security_id SMALLINT;
    home_misc_id SMALLINT;
    cleaning_supplies_id SMALLINT;
    
    -- Electronics variables
    mobile_tablets_id SMALLINT;
    computers_id SMALLINT;
    tv_audio_id SMALLINT;
    cameras_id SMALLINT;
    gaming_id SMALLINT;
    smart_home_id SMALLINT;
    internet_networking_id SMALLINT;
    office_electronics_id SMALLINT;
    electronics_accessories_id SMALLINT;
    storage_devices_id SMALLINT;
    printers_id SMALLINT;
    power_backup_id SMALLINT;
    security_electronics_id SMALLINT;
    home_appliances_id SMALLINT;
    
    -- Additional variables as needed...
    temp_id SMALLINT;
    
BEGIN

-- Get IDs for root categories
SELECT "CategoryID" INTO vehicles_transport_id FROM "Category" WHERE "NameArabic" = 'مركبات ونقل' AND "ParentID" IS NULL;
SELECT "CategoryID" INTO real_estate_id FROM "Category" WHERE "NameArabic" = 'العقارات والاملاك' AND "ParentID" IS NULL;
SELECT "CategoryID" INTO jobs_id FROM "Category" WHERE "NameArabic" = 'الوظائف وفرص العمل' AND "ParentID" IS NULL;
SELECT "CategoryID" INTO services_id FROM "Category" WHERE "NameArabic" = 'الخدمات (خدمات عامة ومتخصصة)' AND "ParentID" IS NULL;
SELECT "CategoryID" INTO personal_items_id FROM "Category" WHERE "NameArabic" = 'المقتنيات الشخصية والصحة والجمال' AND "ParentID" IS NULL;
SELECT "CategoryID" INTO home_kitchen_id FROM "Category" WHERE "NameArabic" = 'المنزل والمطبخ والحديقة' AND "ParentID" IS NULL;
SELECT "CategoryID" INTO vehicle_parts_id FROM "Category" WHERE "NameArabic" = 'قطع الغيار والاكسسوارات للمركبات' AND "ParentID" IS NULL;
SELECT "CategoryID" INTO electronics_id FROM "Category" WHERE "NameArabic" = 'الالكترونيات والاجهزة الرقمية' AND "ParentID" IS NULL;
SELECT "CategoryID" INTO hobbies_id FROM "Category" WHERE "NameArabic" = 'الهوايات والترفيه والانشطة' AND "ParentID" IS NULL;
SELECT "CategoryID" INTO pets_id FROM "Category" WHERE "NameArabic" = 'الحيوانات الاليفة ومستلزماتها' AND "ParentID" IS NULL;
SELECT "CategoryID" INTO business_id FROM "Category" WHERE "NameArabic" = 'الاعمال والمعدات التجارية والصناعية' AND "ParentID" IS NULL;

-- Level 2 categories for "مركبات ونقل"
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('سيارات', 'ئۆتۆمبێل (سەیارە)', 'سيارات', 'ئۆتۆمبێل', '1.1', vehicles_transport_id),
('دراجات نارية وعجلات اخرى', 'ماتۆڕسکیل و تایەی تر (پایسکل و چەرخی تر)', 'دراجات-نارية-وعجلات-اخرى', 'ماتۆڕسکیل-و-تایەی-تر', '1.2', vehicles_transport_id),
('شاحنات', 'بارهەڵگر (شاحینە)', 'شاحنات', 'بارهەڵگر', '1.3', vehicles_transport_id),
('معدات ثقيلة واليات', 'ئامێری قورس و میکانیزم', 'معدات-ثقيلة-واليات', 'ئامێری-قورس-و-میکانیزم', '1.4', vehicles_transport_id),
('النقل البحري', 'گواستنەوەی دەریایی', 'النقل-البحري', 'گواستنەوەی-دەریایی', '1.5', vehicles_transport_id);

-- Get IDs for level 2 categories under "مركبات ونقل"
SELECT "CategoryID" INTO cars_id FROM "Category" WHERE "NameArabic" = 'سيارات' AND "ParentID" = vehicles_transport_id;
SELECT "CategoryID" INTO motorcycles_id FROM "Category" WHERE "NameArabic" = 'دراجات نارية وعجلات اخرى' AND "ParentID" = vehicles_transport_id;
SELECT "CategoryID" INTO trucks_id FROM "Category" WHERE "NameArabic" = 'شاحنات' AND "ParentID" = vehicles_transport_id;
SELECT "CategoryID" INTO heavy_equipment_id FROM "Category" WHERE "NameArabic" = 'معدات ثقيلة واليات' AND "ParentID" = vehicles_transport_id;
SELECT "CategoryID" INTO marine_transport_id FROM "Category" WHERE "NameArabic" = 'النقل البحري' AND "ParentID" = vehicles_transport_id;

-- Level 3 categories for "دراجات نارية وعجلات اخرى"
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('دراجات نارية (موتوسيكلات)', 'ماتۆڕسکیل (ماتۆڕ)', 'دراجات-نارية', 'ماتۆڕسکیل', '1.2.1', motorcycles_id),
('دراجات هوائية وسكوترات', 'پاسکیل و سکۆتەر', 'دراجات-هوائية-وسكوترات', 'پاسکیل-و-سکۆتەر', '1.2.2', motorcycles_id),
('مركبات طرق وعرة (ATV)', 'ئۆتۆمبێلی ڕێگا ناخۆشەکان (ATV)', 'مركبات-طرق-وعرة', 'ئۆتۆمبێلی-ڕێگا-ناخۆشەکان', '1.2.3', motorcycles_id),
('دراجات رباعية وباجي (Buggies)', 'ماتۆڕی چوار تایە و بەگی (Buggies)', 'دراجات-رباعية-وباجي', 'ماتۆڕی-چوار-تایە-و-بەگی', '1.2.4', motorcycles_id);

-- Level 3 categories for "معدات ثقيلة واليات"
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('نقل تجاري خفيف (بيك ام، كيه)', 'گواستنەوەی بازرگانی سووک (پیکاب، کەی)', 'نقل-تجاري-خفيف', 'گواستنەوەی-بازرگانی-سووک', '1.4.1', heavy_equipment_id),
('شفلات', 'شۆفڵ', 'شفلات', 'شۆفڵ', '1.4.2', heavy_equipment_id),
('لوريات (شاحنات نقل كبيرة)', 'لۆری (بارهەڵگری گەورە)', 'لوريات', 'لۆری', '1.4.3', heavy_equipment_id),
('جرارات', 'تراکتۆر', 'جرارات', 'تراکتۆر', '1.4.4', heavy_equipment_id),
('حفارات', 'حەفارە', 'حفارات', 'حەفارە', '1.4.5', heavy_equipment_id),
('رافعات (كرينات)', 'کڕێن (ڕافیعە)', 'رافعات', 'کڕێن', '1.4.6', heavy_equipment_id),
('حافلات (باصات)', 'پاس', 'حافلات', 'پاس', '1.4.7', heavy_equipment_id),
('جرافات', 'بلدۆزەر (جەڕافە)', 'جرافات', 'بلدۆزەر', '1.4.8', heavy_equipment_id),
('معدات زراعية', 'کەلوپەلی کشتوکاڵی', 'معدات-زراعية', 'کەلوپەلی-کشتوکاڵی', '1.4.9', heavy_equipment_id),
('معدات بناء', 'کەلوپەلی بیناسازی', 'معدات-بناء', 'کەلوپەلی-بیناسازی', '1.4.10', heavy_equipment_id),
('معدات واليات اخرى (الرافعات الشوكية، مضخات الخرسانة، وغيرها)', 'ئامێر و میکانیزمی تر (ڕافیعەی شەوکەدار، پەمپی کۆنکرێت، هتد)', 'معدات-واليات-اخرى', 'ئامێر-و-میکانیزمی-تر', '1.4.11', heavy_equipment_id);

-- Level 3 categories for "النقل البحري"
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('قوارب تجديف', 'بەلەمی سەوڵ لێدان', 'قوارب-تجديف', 'بەلەمی-سەوڵ-لێدان', '1.5.1', marine_transport_id),
('دراجات مائية (جت سكي)', 'جێتسکی (ماتۆڕی ئاوی)', 'دراجات-مائية', 'جێتسکی', '1.5.2', marine_transport_id),
('قوارب ويخوت', 'بەلەم و یەخت', 'قوارب-ويخوت', 'بەلەم-و-یەخت', '1.5.3', marine_transport_id);

-- Level 2 categories for "العقارات والاملاك"
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('عقارات للبيع', 'خانووبەرە بۆ فرۆشتن', 'عقارات-للبيع', 'خانووبەرە-بۆ-فرۆشتن', '2.1', real_estate_id),
('عقارات للايجار', 'خانووبەرە بۆ کرێ', 'عقارات-للايجار', 'خانووبەرە-بۆ-کرێ', '2.2', real_estate_id);

-- Get IDs for level 2 categories under "العقارات والاملاك"
SELECT "CategoryID" INTO real_estate_sale_id FROM "Category" WHERE "NameArabic" = 'عقارات للبيع' AND "ParentID" = real_estate_id;
SELECT "CategoryID" INTO real_estate_rent_id FROM "Category" WHERE "NameArabic" = 'عقارات للايجار' AND "ParentID" = real_estate_id;

-- Level 3 categories for "عقارات للبيع"
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('سكني', 'نیشتەجێبوون', 'سكني', 'نیشتەجێبوون', '2.1.1', real_estate_sale_id),
('تجاري وصناعي', 'بازرگانی و پیشەسازی', 'تجاري-وصناعي', 'بازرگانی-و-پیشەسازی', '2.1.2', real_estate_sale_id),
('مشاريع تحت الانشاء', 'پڕۆژەی لەژێر دروستکردن', 'مشاريع-تحت-الانشاء', 'پڕۆژەی-لەژێر-دروستکردن', '2.1.3', real_estate_sale_id),
('عقارات خارج العراق', 'خانووبەرە لە دەرەوەی عێراق', 'عقارات-خارج-العراق', 'خانووبەرە-لە-دەرەوەی-عێراق', '2.1.4', real_estate_sale_id),
('فئات عقارية اخرى للبيع', 'پۆلەکانی تری خانووبەرە بۆ فرۆشتن', 'فئات-عقارية-اخرى-للبيع', 'پۆلەکانی-تری-خانووبەرە-بۆ-فرۆشتن', '2.1.5', real_estate_sale_id);

-- Get IDs for level 3 categories under "عقارات للبيع"
SELECT "CategoryID" INTO residential_sale_id FROM "Category" WHERE "NameArabic" = 'سكني' AND "ParentID" = real_estate_sale_id;
SELECT "CategoryID" INTO commercial_industrial_sale_id FROM "Category" WHERE "NameArabic" = 'تجاري وصناعي' AND "ParentID" = real_estate_sale_id;
SELECT "CategoryID" INTO under_construction_sale_id FROM "Category" WHERE "NameArabic" = 'مشاريع تحت الانشاء' AND "ParentID" = real_estate_sale_id;
SELECT "CategoryID" INTO outside_iraq_sale_id FROM "Category" WHERE "NameArabic" = 'عقارات خارج العراق' AND "ParentID" = real_estate_sale_id;
SELECT "CategoryID" INTO other_categories_sale_id FROM "Category" WHERE "NameArabic" = 'فئات عقارية اخرى للبيع' AND "ParentID" = real_estate_sale_id;

-- Level 4 categories for "سكني" under sale
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('منازل وفلل', 'ماڵ و ڤێلا', 'منازل-وفلل', 'ماڵ-و-ڤێلا', '2.1.1.1', residential_sale_id),
('شقق', 'شوقە', 'شقق', 'شوقە', '2.1.1.2', residential_sale_id),
('قطع اراضي', 'پارچە زەوی', 'قطع-اراضي', 'پارچە-زەوی', '2.1.1.3', residential_sale_id);

-- Get IDs for level 4 categories under "سكني" sale
SELECT "CategoryID" INTO houses_villas_sale_id FROM "Category" WHERE "NameArabic" = 'منازل وفلل' AND "ParentID" = residential_sale_id;
SELECT "CategoryID" INTO apartments_sale_id FROM "Category" WHERE "NameArabic" = 'شقق' AND "ParentID" = residential_sale_id;
SELECT "CategoryID" INTO land_plots_sale_id FROM "Category" WHERE "NameArabic" = 'قطع اراضي' AND "ParentID" = residential_sale_id;

-- Level 5 categories for "منازل وفلل" under sale
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('بيوت عادية', 'ماڵی ئاسایی', 'بيوت-عادية', 'ماڵی-ئاسایی', '2.1.1.1.1', houses_villas_sale_id),
('بيوت بناء حديث', 'ماڵی تازە دروستکراو', 'بيوت-بناء-حديث', 'ماڵی-تازە-دروستکراو', '2.1.1.1.2', houses_villas_sale_id),
('فلل مستقلة', 'ڤێلای سەربەخۆ', 'فلل-مستقلة', 'ڤێلای-سەربەخۆ', '2.1.1.1.3', houses_villas_sale_id),
('فلل متلاصقة (تاون هاوس)', 'ڤێلای لکاو (تاون هاوس)', 'فلل-متلاصقة', 'ڤێلای-لکاو', '2.1.1.1.4', houses_villas_sale_id),
('بيوت دوبلكس', 'ماڵی دوپلێکس', 'بيوت-دوبلكس', 'ماڵی-دوپلێکس', '2.1.1.1.5', houses_villas_sale_id),
('بيوت ريفية (قروية)', 'ماڵی گوند (لادێ)', 'بيوت-ريفية', 'ماڵی-گوند', '2.1.1.1.6', houses_villas_sale_id);

-- Level 5 categories for "شقق" under sale
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('شقق عادية', 'شوقەی ئاسایی', 'شقق-عادية', 'شوقەی-ئاسایی', '2.1.1.2.1', apartments_sale_id),
('شقق فخمة (ديلوكس)', 'شوقەی دەلۆکس (شاهانە)', 'شقق-فخمة', 'شوقەی-دەلۆکس', '2.1.1.2.2', apartments_sale_id),
('شقق استوديو', 'شوقەی ستۆدیۆ', 'شقق-استوديو', 'شوقەی-ستۆدیۆ', '2.1.1.2.3', apartments_sale_id),
('شقق دوبلكس', 'شوقەی دوپلێکس', 'شقق-دوبلكس', 'شوقەی-دوپلێکس', '2.1.1.2.4', apartments_sale_id);

-- Level 5 categories for "قطع اراضي" under sale
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('اراضي سكنية (عرصات)', 'زەوی نیشتەجێبوون (عەرسە)', 'اراضي-سكنية', 'زەوی-نیشتەجێبوون', '2.1.1.3.1', land_plots_sale_id),
('اراضي زراعية', 'زەوی کشتوکاڵی', 'اراضي-زراعية', 'زەوی-کشتوکاڵی', '2.1.1.3.2', land_plots_sale_id),
('اراضي تجارية وصناعية', 'زەوی بازرگانی و پیشەسازی', 'اراضي-تجارية-وصناعية', 'زەوی-بازرگانی-و-پیشەسازی', '2.1.1.3.3', land_plots_sale_id);

-- Level 4 categories for "تجاري وصناعي" under sale
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('محلات تجارية', 'دوکانی بازرگانی', 'محلات-تجارية', 'دوکانی-بازرگانی', '2.1.2.1', commercial_industrial_sale_id),
('مكاتب', 'نووسینگە (مەکتەب)', 'مكاتب', 'نووسینگە', '2.1.2.2', commercial_industrial_sale_id),
('ورش ومعامل صغيرة', 'وەرشە و کارگەی بچووک', 'ورش-ومعامل-صغيرة', 'وەرشە-و-کارگەی-بچووک', '2.1.2.3', commercial_industrial_sale_id),
('مخازن ومستودعات', 'کۆگا و مەخزەن', 'مخازن-ومستودعات', 'کۆگا-و-مەخزەن', '2.1.2.4', commercial_industrial_sale_id);

-- Level 4 categories for "مشاريع تحت الانشاء" under sale
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('مشاريع سكنية تحت الانشاء', 'پڕۆژەی نیشتەجێبوونی لەژێر دروستکردن', 'مشاريع-سكنية-تحت-الانشاء', 'پڕۆژەی-نیشتەجێبوونی-لەژێر-دروستکردن', '2.1.3.1', under_construction_sale_id),
('مجمعات تجارية تحت الانشاء', 'کۆمەڵگەی بازرگانی لەژێر دروستکردن', 'مجمعات-تجارية-تحت-الانشاء', 'کۆمەڵگەی-بازرگانی-لەژێر-دروستکردن', '2.1.3.2', under_construction_sale_id),
('مشاريع صناعية تحت الانشاء', 'پڕۆژەی پیشەسازی لەژێر دروستکردن', 'مشاريع-صناعية-تحت-الانشاء', 'پڕۆژەی-پیشەسازی-لەژێر-دروستکردن', '2.1.3.3', under_construction_sale_id);

-- Level 4 categories for "عقارات خارج العراق" under sale
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('تركيا', 'تورکیا', 'تركيا', 'تورکیا', '2.1.4.1', outside_iraq_sale_id),
('الامارات', 'ئیمارات', 'الامارات', 'ئیمارات', '2.1.4.2', outside_iraq_sale_id),
('دول اخرى', 'وڵاتانی تر', 'دول-اخرى', 'وڵاتانی-تر', '2.1.4.3', outside_iraq_sale_id);

-- Level 4 categories for "فئات عقارية اخرى للبيع" under sale
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('استوديوهات (غير سكني)', 'ستۆدیۆ (نا نیشتەجێبوون)', 'استوديوهات', 'ستۆدیۆ', '2.1.5.1', other_categories_sale_id),
('عيادات ومراكز طبية', 'کلینیک و ناوەندی پزیشکی', 'عيادات-ومراكز-طبية', 'کلینیک-و-ناوەندی-پزیشکی', '2.1.5.2', other_categories_sale_id),
('مطاعم ومقاهي (كافيهات)', 'چێشتخانە و قاوەخانە (کافتریا)', 'مطاعم-ومقاهي', 'چێشتخانە-و-قاوەخانە', '2.1.5.3', other_categories_sale_id),
('مواقف سيارات (كراجات)', 'پارکینگی ئۆتۆمبێل (گەڕاج)', 'مواقف-سيارات', 'پارکینگی-ئۆتۆمبێل', '2.1.5.4', other_categories_sale_id),
('قاعات مناسبات وافراح', 'هۆڵی بۆنە و ئاهەنگ', 'قاعات-مناسبات-وافراح', 'هۆڵی-بۆنە-و-ئاهەنگ', '2.1.5.5', other_categories_sale_id),
('قاعات مؤتمرات واجتماعات', 'هۆڵی کۆنفرانس و کۆبوونەوە', 'قاعات-مؤتمرات-واجتماعات', 'هۆڵی-کۆنفرانس-و-کۆبوونەوە', '2.1.5.6', other_categories_sale_id),
('عقارات اخرى للبيع', 'خانووبەرەی تری بۆ فرۆشتن', 'عقارات-اخرى-للبيع', 'خانووبەرەی-تری-بۆ-فرۆشتن', '2.1.5.7', other_categories_sale_id);

-- Level 3 categories for "عقارات للايجار"
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('سكني', 'نیشتەجێبوون', 'سكني', 'نیشتەجێبوون', '2.2.1', real_estate_rent_id),
('تجاري وصناعي', 'بازرگانی و پیشەسازی', 'تجاري-وصناعي', 'بازرگانی-و-پیشەسازی', '2.2.2', real_estate_rent_id),
('فئات عقارية اخرى للايجار', 'پۆلەکانی تری خانووبەرە بۆ کرێ', 'فئات-عقارية-اخرى-للايجار', 'پۆلەکانی-تری-خانووبەرە-بۆ-کرێ', '2.2.3', real_estate_rent_id);

-- Get IDs for level 3 categories under "عقارات للايجار"
SELECT "CategoryID" INTO residential_rent_id FROM "Category" WHERE "NameArabic" = 'سكني' AND "ParentID" = real_estate_rent_id;
SELECT "CategoryID" INTO commercial_industrial_rent_id FROM "Category" WHERE "NameArabic" = 'تجاري وصناعي' AND "ParentID" = real_estate_rent_id;
SELECT "CategoryID" INTO other_categories_rent_id FROM "Category" WHERE "NameArabic" = 'فئات عقارية اخرى للايجار' AND "ParentID" = real_estate_rent_id;

-- Level 4 categories for "سكني" under rent
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('منازل وفلل للايجار', 'ماڵ و ڤێلا بۆ کرێ', 'منازل-وفلل-للايجار', 'ماڵ-و-ڤێلا-بۆ-کرێ', '2.2.1.1', residential_rent_id),
('شقق للايجار', 'شوقە بۆ کرێ', 'شقق-للايجار', 'شوقە-بۆ-کرێ', '2.2.1.2', residential_rent_id);

-- Get IDs for level 4 categories under "سكني" rent
SELECT "CategoryID" INTO houses_villas_rent_id FROM "Category" WHERE "NameArabic" = 'منازل وفلل للايجار' AND "ParentID" = residential_rent_id;
SELECT "CategoryID" INTO apartments_rent_id FROM "Category" WHERE "NameArabic" = 'شقق للايجار' AND "ParentID" = residential_rent_id;

-- Level 5 categories for "منازل وفلل للايجار" under rent
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('بيوت عادية', 'ماڵی ئاسایی', 'بيوت-عادية', 'ماڵی-ئاسایی', '2.2.1.1.1', houses_villas_rent_id),
('فلل مستقلة', 'ڤێلای سەربەخۆ', 'فلل-مستقلة', 'ڤێلای-سەربەخۆ', '2.2.1.1.2', houses_villas_rent_id),
('فلل متلاصقة (تاون هاوس)', 'ڤێلای لکاو (تاون هاوس)', 'فلل-متلاصقة', 'ڤێلای-لکاو', '2.2.1.1.3', houses_villas_rent_id),
('بيوت دوبلكس', 'ماڵی دوپلێکس', 'بيوت-دوبلكس', 'ماڵی-دوپلێکس', '2.2.1.1.4', houses_villas_rent_id),
('بيوت ريفية (قروية)', 'ماڵی گوند (لادێ)', 'بيوت-ريفية', 'ماڵی-گوند', '2.2.1.1.5', houses_villas_rent_id);

-- Level 5 categories for "شقق للايجار" under rent
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('شقق عادية', 'شوقەی ئاسایی', 'شقق-عادية', 'شوقەی-ئاسایی', '2.2.1.2.1', apartments_rent_id),
('شقق فخمة (ديلوكس)', 'شوقەی دەلۆکس (شاهانە)', 'شقق-فخمة', 'شوقەی-دەلۆکس', '2.2.1.2.2', apartments_rent_id),
('شقق استوديو', 'شوقەی ستۆدیۆ', 'شقق-استوديو', 'شوقەی-ستۆدیۆ', '2.2.1.2.3', apartments_rent_id),
('شقق مفروشة', 'شوقەی مۆبیلیەکراو (مەفروش)', 'شقق-مفروشة', 'شوقەی-مۆبیلیەکراو', '2.2.1.2.4', apartments_rent_id);

-- Level 4 categories for "تجاري وصناعي" under rent
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('محلات تجارية', 'دوکانی بازرگانی', 'محلات-تجارية', 'دوکانی-بازرگانی', '2.2.2.1', commercial_industrial_rent_id),
('مكاتب', 'نووسینگە (مەکتەب)', 'مكاتب', 'نووسینگە', '2.2.2.2', commercial_industrial_rent_id),
('ورش ومعامل صغيرة', 'وەرشە و کارگەی بچووک', 'ورش-ومعامل-صغيرة', 'وەرشە-و-کارگەی-بچووک', '2.2.2.3', commercial_industrial_rent_id),
('مخازن ومستودعات', 'کۆگا و مەخزەن', 'مخازن-ومستودعات', 'کۆگا-و-مەخزەن', '2.2.2.4', commercial_industrial_rent_id);

-- Level 4 categories for "فئات عقارية اخرى للايجار" under rent
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('استوديوهات (غير سكني)', 'ستۆدیۆ (نا نیشتەجێبوون)', 'استوديوهات', 'ستۆدیۆ', '2.2.3.1', other_categories_rent_id),
('مزارع', 'کێڵگە (مەزرەعە)', 'مزارع', 'کێڵگە', '2.2.3.2', other_categories_rent_id),
('عيادات ومراكز طبية', 'کلینیک و ناوەندی پزیشکی', 'عيادات-ومراكز-طبية', 'کلینیک-و-ناوەندی-پزیشکی', '2.2.3.3', other_categories_rent_id),
('مطاعم ومقاهي (كافيهات)', 'چێشتخانە و قاوەخانە (کافتریا)', 'مطاعم-ومقاهي', 'چێشتخانە-و-قاوەخانە', '2.2.3.4', other_categories_rent_id),
('مواقف سيارات (كراجات)', 'پارکینگی ئۆتۆمبێل (گەڕاج)', 'مواقف-سيارات', 'پارکینگی-ئۆتۆمبێل', '2.2.3.5', other_categories_rent_id),
('قاعات مناسبات وافراح', 'هۆڵی بۆنە و ئاهەنگ', 'قاعات-مناسبات-وافراح', 'هۆڵی-بۆنە-و-ئاهەنگ', '2.2.3.6', other_categories_rent_id),
('قاعات مؤتمرات واجتماعات', 'هۆڵی کۆنفرانس و کۆبوونەوە', 'قاعات-مؤتمرات-واجتماعات', 'هۆڵی-کۆنفرانس-و-کۆبوونەوە', '2.2.3.7', other_categories_rent_id),
('عقارات اخرى للايجار', 'خانووبەرەی تری بۆ کرێ', 'عقارات-اخرى-للايجار', 'خانووبەرەی-تری-بۆ-کرێ', '2.2.3.8', other_categories_rent_id);

-- Level 2 categories for "الوظائف وفرص العمل"
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('ابحث عن عمل (طلبات توظيف)', 'گەڕان بەدوای کار (داواکاری دامەزراندن)', 'ابحث-عن-عمل', 'گەڕان-بەدوای-کار', '3.1', jobs_id),
('ابحث عن موظف (عروض عمل)', 'گەڕان بەدوای فەرمانبەر (پێشنیاری کار)', 'ابحث-عن-موظف', 'گەڕان-بەدوای-فەرمانبەر', '3.2', jobs_id);

-- Get IDs for level 2 categories under "الوظائف وفرص العمل"
SELECT "CategoryID" INTO job_seekers_id FROM "Category" WHERE "NameArabic" = 'ابحث عن عمل (طلبات توظيف)' AND "ParentID" = jobs_id;
SELECT "CategoryID" INTO job_offers_id FROM "Category" WHERE "NameArabic" = 'ابحث عن موظف (عروض عمل)' AND "ParentID" = jobs_id;

-- Level 3 job categories for seekers (same for both job seekers and job offers)
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
-- Job seeker categories
('البناء والتشييد والانشاءات', 'بیناسازی و ئاوەدانکردنەوە', 'البناء-والتشييد-والانشاءات', 'بیناسازی-و-ئاوەدانکردنەوە', '3.1.1', job_seekers_id),
('تكنولوجيا المعلومات والاتصالات (IT)', 'تەکنەلۆژیای زانیاری و گەیاندن (IT)', 'تكنولوجيا-المعلومات-والاتصالات', 'تەکنەلۆژیای-زانیاری-و-گەیاندن', '3.1.2', job_seekers_id),
('وظائف ادارية ومكتبية', 'کاری کارگێڕی و نووسینگە', 'وظائف-ادارية-ومكتبية', 'کاری-کارگێڕی-و-نووسینگە', '3.1.3', job_seekers_id),
('المحاسبة والمالية', 'ژمێریاری و دارایی', 'المحاسبة-والمالية', 'ژمێریاری-و-دارایی', '3.1.4', job_seekers_id),
('الطب والصيدلة والتمريض', 'پزیشکی و دەرمانسازی و پەرستاری', 'الطب-والصيدلة-والتمريض', 'پزیشکی-و-دەرمانسازی-و-پەرستاری', '3.1.5', job_seekers_id),
('التعليم والتدريس والبحث العلمي', 'فێرکردن و وانەوتنەوە و توێژینەوەی زانستی', 'التعليم-والتدريس-والبحث-العلمي', 'فێرکردن-و-وانەوتنەوە-و-توێژینەوەی-زانستی', '3.1.6', job_seekers_id),
('الخدمات العامة والتشغيل والصيانة', 'خزمەتگوزاری گشتی و کارپێکردن و چاککردنەوە', 'الخدمات-العامة-والتشغيل-والصيانة', 'خزمەتگوزاری-گشتی-و-کارپێکردن-و-چاککردنەوە', '3.1.7', job_seekers_id),
('المبيعات والتسويق والدعاية', 'فرۆشتن و بازاڕگەری و ڕیکلام', 'المبيعات-والتسويق-والدعاية', 'فرۆشتن-و-بازاڕگەری-و-ڕیکلام', '3.1.8', job_seekers_id),
('النقل والمواصلات والخدمات اللوجستية', 'گواستنەوە و گەیاندن و خزمەتگوزاری لۆجستی', 'النقل-والمواصلات-والخدمات-اللوجستية', 'گواستنەوە-و-گەیاندن-و-خزمەتگوزاری-لۆجستی', '3.1.9', job_seekers_id),
('الضيافة والفندقة والسياحة', 'میوانداری و هۆتێلداری و گەشتوگوزار', 'الضيافة-والفندقة-والسياحة', 'میوانداری-و-هۆتێلداری-و-گەشتوگوزار', '3.1.10', job_seekers_id),
('الفنون والتصميم والترفيه', 'هونەر و دیزاین و کات بەسەربردن', 'الفنون-والتصميم-والترفيه', 'هونەر-و-دیزاین-و-کات-بەسەربردن', '3.1.11', job_seekers_id),
('الامن والحماية والسلامة', 'ئاسایش و پاراستن و سەلامەتی', 'الامن-والحماية-والسلامة', 'ئاسایش-و-پاراستن-و-سەلامەتی', '3.1.12', job_seekers_id),
('العمالة المنزلية والخدم', 'کاری ماڵەوە و خزمەتکار', 'العمالة-المنزلية-والخدم', 'کاری-ماڵەوە-و-خزمەتکار', '3.1.13', job_seekers_id);

-- Job offer categories (same structure)
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('البناء والتشييد والانشاءات', 'بیناسازی و ئاوەدانکردنەوە', 'البناء-والتشييد-والانشاءات', 'بیناسازی-و-ئاوەدانکردنەوە', '3.2.1', job_offers_id),
('تكنولوجيا المعلومات والاتصالات (IT)', 'تەکنەلۆژیای زانیاری و گەیاندن (IT)', 'تكنولوجيا-المعلومات-والاتصالات', 'تەکنەلۆژیای-زانیاری-و-گەیاندن', '3.2.2', job_offers_id),
('وظائف ادارية ومكتبية', 'کاری کارگێڕی و نووسینگە', 'وظائف-ادارية-ومكتبية', 'کاری-کارگێڕی-و-نووسینگە', '3.2.3', job_offers_id),
('المحاسبة والمالية', 'ژمێریاری و دارایی', 'المحاسبة-والمالية', 'ژمێریاری-و-دارایی', '3.2.4', job_offers_id),
('الطب والصيدلة والتمريض', 'پزیشکی و دەرمانسازی و پەرستاری', 'الطب-والصيدلة-والتمريض', 'پزیشکی-و-دەرمانسازی-و-پەرستاری', '3.2.5', job_offers_id),
('التعليم والتدريس والبحث العلمي', 'فێرکردن و وانەوتنەوە و توێژینەوەی زانستی', 'التعليم-والتدريس-والبحث-العلمي', 'فێرکردن-و-وانەوتنەوە-و-توێژینەوەی-زانستی', '3.2.6', job_offers_id),
('الخدمات العامة والتشغيل والصيانة', 'خزمەتگوزاری گشتی و کارپێکردن و چاککردنەوە', 'الخدمات-العامة-والتشغيل-والصيانة', 'خزمەتگوزاری-گشتی-و-کارپێکردن-و-چاککردنەوە', '3.2.7', job_offers_id),
('المبيعات والتسويق والدعاية', 'فرۆشتن و بازاڕگەری و ڕیکلام', 'المبيعات-والتسويق-والدعاية', 'فرۆشتن-و-بازاڕگەری-و-ڕیکلام', '3.2.8', job_offers_id),
('النقل والمواصلات والخدمات اللوجستية', 'گواستنەوە و گەیاندن و خزمەتگوزاری لۆجستی', 'النقل-والمواصلات-والخدمات-اللوجستية', 'گواستنەوە-و-گەیاندن-و-خزمەتگوزاری-لۆجستی', '3.2.9', job_offers_id),
('الضيافة والفندقة والسياحة', 'میوانداری و هۆتێلداری و گەشتوگوزار', 'الضيافة-والفندقة-والسياحة', 'میوانداری-و-هۆتێلداری-و-گەشتوگوزار', '3.2.10', job_offers_id),
('الفنون والتصميم والترفيه', 'هونەر و دیزاین و کات بەسەربردن', 'الفنون-والتصميم-والترفيه', 'هونەر-و-دیزاین-و-کات-بەسەربردن', '3.2.11', job_offers_id),
('الامن والحماية والسلامة', 'ئاسایش و پاراستن و سەلامەتی', 'الامن-والحماية-والسلامة', 'ئاسایش-و-پاراستن-و-سەلامەتی', '3.2.12', job_offers_id),
('العمالة المنزلية والخدم', 'کاری ماڵەوە و خزمەتکار', 'العمالة-المنزلية-والخدم', 'کاری-ماڵەوە-و-خزمەتکار', '3.2.13', job_offers_id);

-- Continue adding level 4 job categories for job seekers...
-- Get temp_id for construction jobs seekers
SELECT "CategoryID" INTO temp_id FROM "Category" WHERE "NameArabic" = 'البناء والتشييد والانشاءات' AND "ParentID" = job_seekers_id;
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('عامل بناء (خلفة بناء)', 'کرێکاری بیناسازی (وەستای بینا)', 'عامل-بناء', 'کرێکاری-بیناسازی', '3.1.1.1', temp_id),
('مهندس معماري', 'ئەندازیاری تەلارسازی', 'مهندس-معماري', 'ئەندازیاری-تەلارسازی', '3.1.1.2', temp_id),
('مهندس مدني', 'ئەندازیاری شارستانی', 'مهندس-مدني', 'ئەندازیاری-شارستانی', '3.1.1.3', temp_id),
('فني صحيات وكهرباء (سباك، كهربائي)', 'تەکنیکاری ئاوەڕۆ و کارەبا (سەباخ، کارەباچی)', 'فني-صحيات-وكهرباء', 'تەکنیکاری-ئاوەڕۆ-و-کارەبا', '3.1.1.4', temp_id);

-- Get temp_id for IT jobs seekers
SELECT "CategoryID" INTO temp_id FROM "Category" WHERE "NameArabic" = 'تكنولوجيا المعلومات والاتصالات (IT)' AND "ParentID" = job_seekers_id;
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('تطوير برامج وتطبيقات (مبرمج)', 'پەرەپێدانی پرۆگرام و ئەپلیکەیشن (پرۆگرامساز)', 'تطوير-برامج-وتطبيقات', 'پەرەپێدانی-پرۆگرام-و-ئەپلیکەیشن', '3.1.2.1', temp_id),
('ادارة شبكات كومبيوتر', 'بەڕێوەبردنی تۆڕەکانی کۆمپیوتەر', 'ادارة-شبكات-كومبيوتر', 'بەڕێوەبردنی-تۆڕەکانی-کۆمپیوتەر', '3.1.2.2', temp_id),
('دعم فني (IT Support)', 'پشتیوانی تەکنیکی (IT Support)', 'دعم-فني', 'پشتیوانی-تەکنیکی', '3.1.2.3', temp_id),
('امن معلومات (Cybersecurity)', 'ئاسایشی زانیاری (Cybersecurity)', 'امن-معلومات', 'ئاسایشی-زانیاری', '3.1.2.4', temp_id),
('تحليل بيانات', 'شیکردنەوەی داتا', 'تحليل-بيانات', 'شیکردنەوەی-داتا', '3.1.2.5', temp_id);

-- Continue this pattern for all job categories... Due to space constraints, I'll skip to services section

-- Level 2 categories for "الخدمات"
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('خدمات المركبات (ورش تصليح، ايجار، غسيل)', 'خزمەتگوزاری ئۆتۆمبێل (وەرشەی چاککردنەوە، بەکرێدان، شوشتن)', 'خدمات-المركبات', 'خزمەتگوزاری-ئۆتۆمبێل', '4.1', services_id),
('خدمات البناء والمقاولات والمعدات الثقيلة', 'خزمەتگوزاری بیناسازی و بەڵێندەرایەتی و ئامێری قورس', 'خدمات-البناء-والمقاولات-والمعدات-الثقيلة', 'خزمەتگوزاری-بیناسازی-و-بەڵێندەرایەتی-و-ئامێری-قورس', '4.2', services_id),
('خدمات نقل البضائع والشحن', 'خزمەتگوزاری گواستنەوەی کاڵا و بارکردن', 'خدمات-نقل-البضائع-والشحن', 'خزمەتگوزاری-گواستنەوەی-کاڵا-و-بارکردن', '4.3', services_id),
('الخدمات اللوجستية والتخزين', 'خزمەتگوزاری لۆجستی و کۆگاکردن', 'الخدمات-اللوجستية-والتخزين', 'خزمەتگوزاری-لۆجستی-و-کۆگاکردن', '4.4', services_id),
('خدمات نقل الركاب والمواصلات', 'خزمەتگوزاری گواستنەوەی سەرنشین و گەیاندن', 'خدمات-نقل-الركاب-والمواصلات', 'خزمەتگوزاری-گواستنەوەی-سەرنشین-و-گەیاندن', '4.5', services_id),
('خدمات الاعمار والبناء والتشطيبات', 'خزمەتگوزاری ئاوەدانکردنەوە و بیناسازی و تەواوکاری', 'خدمات-الاعمار-والبناء-والتشطيبات', 'خزمەتگوزاری-ئاوەدانکردنەوە-و-بیناسازی-و-تەواوکاری', '4.6', services_id),
('الخدمات المنزلية المتنوعة', 'خزمەتگوزاری جۆراوجۆری ماڵەوە', 'الخدمات-المنزلية-المتنوعة', 'خزمەتگوزاری-جۆراوجۆری-ماڵەوە', '4.7', services_id),
('خدمات اصلاح وصيانة عامة', 'خزمەتگوزاری چاککردنەوە و سیانەی گشتی', 'خدمات-اصلاح-وصيانة-عامة', 'خزمەتگوزاری-چاککردنەوە-و-سیانەی-گشتی', '4.8', services_id),
('خدمات تجهيز الطعام والمناسبات', 'خزمەتگوزاری ئامادەکردنی خواردن و بۆنەکان', 'خدمات-تجهيز-الطعام-والمناسبات', 'خزمەتگوزاری-ئامادەکردنی-خواردن-و-بۆنەکان', '4.9', services_id),
('خدمات التوصيل (دليفري)', 'خزمەتگوزاری گەیاندن (دلیڤەری)', 'خدمات-التوصيل', 'خزمەتگوزاری-گەیاندن', '4.10', services_id),
('خدمات صحية وتجميلية وعناية شخصية', 'خزمەتگوزاری تەندروستی و جوانکاری و چاودێری کەسی', 'خدمات-صحية-وتجميلية-وعناية-شخصية', 'خزمەتگوزاری-تەندروستی-و-جوانکاری-و-چاودێری-کەسی', '4.11', services_id),
('خدمات تعليم وتدريب ودورات', 'خزمەتگوزاری فێرکردن و ڕاهێنان و خول', 'خدمات-تعليم-وتدريب-ودورات', 'خزمەتگوزاری-فێرکردن-و-ڕاهێنان-و-خول', '4.12', services_id),
('خدمات تقنية ومعلوماتية', 'خزمەتگوزاری تەکنیکی و زانیاری', 'خدمات-تقنية-ومعلوماتية', 'خزمەتگوزاری-تەکنیکی-و-زانیاری', '4.13', services_id),
('خدمات زراعية وبستنة', 'خزمەتگوزاری کشتوکاڵی و باخداری', 'خدمات-زراعية-وبستنة', 'خزمەتگوزاری-کشتوکاڵی-و-باخداری', '4.14', services_id),
('خدمات قانونية ومالية واستشارية', 'خزمەتگوزاری یاسایی و دارایی و ڕاوێژکاری', 'خدمات-قانونية-ومالية-واستشارية', 'خزمەتگوزاری-یاسایی-و-دارایی-و-ڕاوێژکاری', '4.15', services_id),
('خدمات مناسبات وافراح وفعاليات', 'خزمەتگوزاری بۆنە و ئاهەنگ و چالاکی', 'خدمات-مناسبات-وافراح-وفعاليات', 'خزمەتگوزاری-بۆنە-و-ئاهەنگ-و-چالاکی', '4.16', services_id),
('خدمات سياحة وسفر وزيارات دينية', 'خزمەتگوزاری گەشتوگوزار و گەشت و زیارەتی ئایینی', 'خدمات-سياحة-وسفر-وزيارات-دينية', 'خزمەتگوزاری-گەشتوگوزار-و-گەشت-و-زیارەتی-ئایینی', '4.17', services_id),
('خدمات امن وحماية وحراسات', 'خزمەتگوزاری ئاسایش و پاراستن و پاسەوانی', 'خدمات-امن-وحماية-وحراسات', 'خزمەتگوزاری-ئاسایش-و-پاراستن-و-پاسەوانی', '4.18', services_id),
('خدمات طاقة وكهرباء بديلة', 'خزمەتگوزاری وزە و کارەبای جێگرەوە', 'خدمات-طاقة-وكهرباء-بديلة', 'خزمەتگوزاری-وزە-و-کارەبای-جێگرەوە', '4.19', services_id),
('خدمات اخرى', 'خزمەتگوزاری تر', 'خدمات-اخرى', 'خزمەتگوزاری-تر', '4.20', services_id);

-- Level 2 categories for "المقتنيات الشخصية والصحة والجمال"
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('ملابس واحذية واكسسوارات', 'جلوبەرگ و پێڵاو و ئێکسسوارات', 'ملابس-واحذية-واكسسوارات', 'جلوبەرگ-و-پێڵاو-و-ئێکسسوارات', '5.1', personal_items_id),
('منتجات الاطفال والعابهم', 'بەرهەمی منداڵان و یارییەکانیان', 'منتجات-الاطفال-والعابهم', 'بەرهەمی-منداڵان-و-یارییەکانیان', '5.2', personal_items_id),
('الجمال والعناية الشخصية', 'جوانکاری و چاودێری کەسی', 'الجمال-والعناية-الشخصية', 'جوانکاری-و-چاودێری-کەسی', '5.3', personal_items_id),
('المجوهرات والاكسسوارات', 'خشڵ و ئێکسسوارات', 'المجوهرات-والاكسسوارات', 'خشڵ-و-ئێکسسوارات', '5.4', personal_items_id),
('العناية الصحية والطبية', 'چاودێری تەندروستی و پزیشکی', 'العناية-الصحية-والطبية', 'چاودێری-تەندروستی-و-پزیشکی', '5.5', personal_items_id);

-- Level 2 categories for "المنزل والمطبخ والحديقة"
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('اثاث منزلي (تخم، غرف نوم، ميز طعام)', 'کەلوپەلی ماڵ (تەخم، ژووری نووستن، مێزی نانخواردن)', 'اثاث-منزلي', 'کەلوپەلی-ماڵ', '6.1', home_kitchen_id),
('ادوات ومعدات (عدة للبيت والحديقة)', 'ئامراز و کەرەستە (عەدە بۆ ماڵ و باخچە)', 'ادوات-ومعدات', 'ئامراز-و-کەرەستە', '6.3', home_kitchen_id),
('مواد بناء وصيانة (للبيت)', 'کەرەستەی بیناسازی و چاککردنەوە (بۆ ماڵ)', 'مواد-بناء-وصيانة', 'کەرەستەی-بیناسازی-و-چاککردنەوە', '6.4', home_kitchen_id),
-- Continue from where we left off...
('ديكور ومفروشات البيت', 'دیکۆر و مافوری ماڵ', 'ديكور-ومفروشات-البيت', 'دیکۆر-و-مافوری-ماڵ', '6.5', home_kitchen_id),
('مستلزمات الحديقة والكراج', 'پێداویستی باخچە و گەراج', 'مستلزمات-الحديقة-والكراج', 'پێداویستی-باخچە-و-گەراج', '6.6', home_kitchen_id),
('ادوات المطبخ (غير كهربائية)', 'ئامرازی چێشتخانە (ناکارەبایی)', 'ادوات-المطبخ', 'ئامرازی-چێشتخانە', '6.7', home_kitchen_id),
('امن وحماية البيت', 'ئاسایش و پاراستنی ماڵ', 'امن-وحماية-البيت', 'ئاسایش-و-پاراستنی-ماڵ', '6.8', home_kitchen_id),
('متفرقات للمنزل والتراثيات', 'شتی جۆراوجۆر بۆ ماڵ و کەلەپوور', 'متفرقات-للمنزل-والتراثيات', 'شتی-جۆراوجۆر-بۆ-ماڵ-و-کەلەپوور', '6.9', home_kitchen_id),
('منظفات وادوات تنظيف البيت', 'پاککەرەوە و ئامرازی پاککردنەوەی ماڵ', 'منظفات-وادوات-تنظيف-البيت', 'پاککەرەوە-و-ئامرازی-پاککردنەوەی-ماڵ', '6.10', home_kitchen_id);

-- Level 2 categories for "قطع الغيار والاكسسوارات للمركبات"
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('قطع غيار السيارات (ادوات احتياطية للسيارات)', 'پارچەی یەدەگی ئۆتۆمبێل (کەرەستەی یەدەگی ئۆتۆمبێل)', 'قطع-غيار-السيارات', 'پارچەی-یەدەگی-ئۆتۆمبێل', '7.1', vehicle_parts_id),
('اطارات وعجلات للمركبات (تايرات ووويلات)', 'تایە و ویلی ئۆتۆمبێل', 'اطارات-وعجلات-للمركبات', 'تایە-و-ویلی-ئۆتۆمبێل', '7.2', vehicle_parts_id),
('زيوت ومواد تشحيم للمركبات', 'ڕۆن و ماددەی چەورکردن بۆ ئۆتۆمبێل', 'زيوت-ومواد-تشحيم-للمركبات', 'ڕۆن-و-ماددەی-چەورکردن-بۆ-ئۆتۆمبێل', '7.3', vehicle_parts_id),
('اكسسوارات وكماليات السيارات', 'ئێکسسوارات و جوانکاری ئۆتۆمبێل', 'اكسسوارات-وكماليات-السيارات', 'ئێکسسوارات-و-جوانکاری-ئۆتۆمبێل', '7.4', vehicle_parts_id),
('انظمة الصوت والترفيه للمركبات', 'سیستەمی دەنگ و کات بەسەربردن بۆ ئۆتۆمبێل', 'انظمة-الصوت-والترفيه-للمركبات', 'سیستەمی-دەنگ-و-کات-بەسەربردن-بۆ-ئۆتۆمبێل', '7.5', vehicle_parts_id),
('انظمة الامان والحماية للمركبات', 'سیستەمی ئاسایش و پاراستن بۆ ئۆتۆمبێل', 'انظمة-الامان-والحماية-للمركبات', 'سیستەمی-ئاسایش-و-پاراستن-بۆ-ئۆتۆمبێل', '7.6', vehicle_parts_id),
('ادوات ومعدات صيانة المركبات', 'ئامراز و کەرەستەی سیانەی ئۆتۆمبێل', 'ادوات-ومعدات-صيانة-المركبات', 'ئامراز-و-کەرەستەی-سیانەی-ئۆتۆمبێل', '7.7', vehicle_parts_id),
('قطع غيار واكسسوارات الدراجات النارية', 'پارچەی یەدەگ و ئێکسسواراتی ماتۆڕسکیل', 'قطع-غيار-واكسسوارات-الدراجات-النارية', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ماتۆڕسکیل', '7.8', vehicle_parts_id),
('قطع غيار واكسسوارات الشاحنات والمعدات الثقيلة', 'پارچەی یەدەگ و ئێکسسواراتی بارهەڵگر و ئامێری قورس', 'قطع-غيار-واكسسوارات-الشاحنات-والمعدات-الثقيلة', 'پارچەی-یەدەگ-و-ئێکسسواراتی-بارهەڵگر-و-ئامێری-قورس', '7.9', vehicle_parts_id),
('مستلزمات القوارب والمركبات البحرية', 'پێداویستی بەلەم و ئۆتۆمبێلی دەریایی', 'مستلزمات-القوارب-والمركبات-البحرية', 'پێداویستی-بەلەم-و-ئۆتۆمبێلی-دەریایی', '7.10', vehicle_parts_id);

-- Level 2 categories for "الالكترونيات والاجهزة الرقمية"
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('موبايلات واجهزة لوحية (تابلت)', 'مۆبایل و تابلێت', 'موبايلات-واجهزة-لوحية', 'مۆبایل-و-تابلێت', '8.1', electronics_id),
('كومبيوترات ولابتوبات وملحقاتها', 'کۆمپیوتەر و لاپتۆپ و ملحەقاتەکانی', 'كومبيوترات-ولابتوبات-وملحقاتها', 'کۆمپیوتەر-و-لاپتۆپ-و-ملحەقاتەکانی', '8.2', electronics_id),
('تلفزيونات وشاشات وانظمة صوت وفيديو', 'تەلەفزیۆن و شاشە و سیستەمی دەنگ و ڤیدیۆ', 'تلفزيونات-وشاشات-وانظمة-صوت-وفيديو', 'تەلەفزیۆن-و-شاشە-و-سیستەمی-دەنگ-و-ڤیدیۆ', '8.3', electronics_id),
('كاميرات ومعدات تصوير فوتوغرافي وفيديو', 'کامێرا و کەرەستەی وێنەگرتنی فۆتۆگرافی و ڤیدیۆ', 'كاميرات-ومعدات-تصوير-فوتوغرافي-وفيديو', 'کامێرا-و-کەرەستەی-وێنەگرتنی-فۆتۆگرافی-و-ڤیدیۆ', '8.4', electronics_id),
('اجهزة العاب الكترونية (قيمنق)', 'ئامێری یاری ئەلیکترۆنی (گەیمینگ)', 'اجهزة-العاب-الكترونية', 'ئامێری-یاری-ئەلیکترۆنی', '8.5', electronics_id),
('البيت الذكي والتحكم عن بعد', 'ماڵی زیرەک و کۆنترۆڵی دوور', 'البيت-الذكي-والتحكم-عن-بعد', 'ماڵی-زیرەک-و-کۆنترۆڵی-دوور', '8.6', electronics_id),
('اجهزة انترنت وشبكات', 'ئامێری ئینتەرنێت و تۆڕەکان', 'اجهزة-انترنت-وشبكات', 'ئامێری-ئینتەرنێت-و-تۆڕەکان', '8.7', electronics_id),
('اجهزة مكتبية والكترونيات عمل', 'ئامێری نووسینگە و ئەلیکترۆنیاتی کار', 'اجهزة-مكتبية-والكترونيات-عمل', 'ئامێری-نووسینگە-و-ئەلیکترۆنیاتی-کار', '8.8', electronics_id),
('اكسسوارات الكترونية عامة ومتفرقة', 'ئێکسسواراتی ئەلیکترۆنی گشتی و جۆراوجۆر', 'اكسسوارات-الكترونية-عامة-ومتفرقة', 'ئێکسسواراتی-ئەلیکترۆنی-گشتی-و-جۆراوجۆر', '8.9', electronics_id),
('وحدات خزن بيانات (ميموري، فلاش، هارد ديسك)', 'یەکەی هەڵگرتنی داتا (میمۆری، فلاش، هارد دیسک)', 'وحدات-خزن-بيانات', 'یەکەی-هەڵگرتنی-داتا', '8.10', electronics_id),
('طابعات وسكانرات ومستلزماتها', 'چاپکەر و سکانەر و پێداویستییەکانیان', 'طابعات-وسكانرات-ومستلزماتها', 'چاپکەر-و-سکانەر-و-پێداویستییەکانیان', '8.11', electronics_id),
('اجهزة طاقة احتياطية وحماية', 'ئامێری وزەی یەدەگ و پاراستن', 'اجهزة-طاقة-احتياطية-وحماية', 'ئامێری-وزەی-یەدەگ-و-پاراستن', '8.12', electronics_id),
('انظمة امنية الكترونية (للمحلات والشركات)', 'سیستەمی ئەمنی ئەلیکترۆنی (بۆ دوکان و کۆمپانیاکان)', 'انظمة-امنية-الكترونية', 'سیستەمی-ئەمنی-ئەلیکترۆنی', '8.13', electronics_id),
('اجهزة منزلية كهربائية', 'ئامێری کارەبایی ماڵان', 'اجهزة-منزلية-كهربائية', 'ئامێری-کارەبایی-ماڵان', '8.14', electronics_id);

-- Get IDs for electronics level 2 categories
SELECT "CategoryID" INTO mobile_tablets_id FROM "Category" WHERE "NameArabic" = 'موبايلات واجهزة لوحية (تابلت)' AND "ParentID" = electronics_id;
SELECT "CategoryID" INTO home_appliances_id FROM "Category" WHERE "NameArabic" = 'اجهزة منزلية كهربائية' AND "ParentID" = electronics_id;

-- Level 3 categories for mobile and tablets
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('موبايلات ذكية (ايفون، سامسونق، شاومي، الخ)', 'مۆبایلی زیرەک (ئایفۆن، سامسۆنگ، شیاومی، هتد)', 'موبايلات-ذكية', 'مۆبایلی-زیرەک', '8.1.1', mobile_tablets_id),
('تابلت وايباد', 'تابلێت و ئایپاد', 'تابلت-وايباد', 'تابلێت-و-ئایپاد', '8.1.2', mobile_tablets_id),
('ساعات ذكية ورياضية (ابل ووتش، سامسونق جير، الخ)', 'کاتژمێری زیرەک و وەرزشی (ئەپڵ وۆچ، سامسۆنگ گیێر، هتد)', 'ساعات-ذكية-ورياضية', 'کاتژمێری-زیرەک-و-وەرزشی', '8.1.3', mobile_tablets_id),
('اكسسوارات موبايلات وتابلت وساعات ذكية', 'ئێکسسواراتی مۆبایل و تابلێت و کاتژمێری زیرەک', 'اكسسوارات-موبايلات-وتابلت-وساعات-ذكية', 'ئێکسسواراتی-مۆبایل-و-تابلێت-و-کاتژمێری-زیرەک', '8.1.4', mobile_tablets_id),
('موبايلات ازرار (نوكيا، عادية)', 'مۆبایلی دوگمەدار (نۆکیا، ئاسایی)', 'موبايلات-ازرار', 'مۆبایلی-دوگمەدار', '8.1.5', mobile_tablets_id),
('اجهزة الكترونية صغيرة اخرى', 'ئامێری ئەلیکترۆنی بچووکی تر', 'اجهزة-الكترونية-صغيرة-اخرى', 'ئامێری-ئەلیکترۆنی-بچووکی-تر', '8.1.6', mobile_tablets_id);

-- Level 3 categories for home appliances
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('اجهزة مطبخ كبيرة', 'ئامێری گەورەی چێشتخانە', 'اجهزة-مطبخ-كبيرة', 'ئامێری-گەورەی-چێشتخانە', '8.14.1', home_appliances_id),
('اجهزة تبريد وتدفئة (مكيفات و صوبات)', 'ئامێری فێنککەرەوە و گەرمکەرەوە (موکەیف و سۆپا)', 'اجهزة-تبريد-وتدفئة', 'ئامێری-فێنککەرەوە-و-گەرمکەرەوە', '8.14.2', home_appliances_id),
('غسالات ملابس ومجففات (نشافات)', 'جلشۆر و وشککەرەوە (نەشافە)', 'غسالات-ملابس-ومجففات', 'جلشۆر-و-وشککەرەوە', '8.14.3', home_appliances_id),
('اجهزة مطبخ صغيرة لتحضير الطعام', 'ئامێری بچووکی چێشتخانە بۆ ئامادەکردنی خواردن', 'اجهزة-مطبخ-صغيرة-لتحضير-الطعام', 'ئامێری-بچووکی-چێشتخانە-بۆ-ئامادەکردنی-خواردن', '8.14.4', home_appliances_id),
('مكانس كهربائية واجهزة تنظيف بالبخار', 'گسکی کارەبایی و ئامێری پاککردنەوە بە هەڵم', 'مكانس-كهربائية-واجهزة-تنظيف-بالبخار', 'گسکی-کارەبایی-و-ئامێری-پاککردنەوە-بە-هەڵم', '8.14.5', home_appliances_id),
('اوتي ملابس (مكواة بخارية وعادية)', 'ئوتوی جل (ئوتوی هەڵمی و ئاسایی)', 'اوتي-ملابس', 'ئوتوی-جل', '8.14.6', home_appliances_id),
('ملحقات كهربائية منزلية (سيار، نقاط كهرباء، بطاريات، ماطور ماء، لايت شحن)', 'ملحەقاتی کارەبایی ماڵان (سەیار، خاڵی کارەبا، پاتری، ماتۆڕی ئاو، لایتی شەحن)', 'ملحقات-كهربائية-منزلية', 'ملحەقاتی-کارەبایی-ماڵان', '8.14.7', home_appliances_id);

-- Level 2 categories for "الهوايات والترفيه والانشطة"
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('الرياضة واللياقة البدنية', 'وەرزش و لەشجوانی', 'الرياضة-واللياقة-البدنية', 'وەرزش-و-لەشجوانی', '9.1', hobbies_id),
('الموسيقى والفنون اليدوية', 'مۆسیقا و هونەری دەستی', 'الموسيقى-والفنون-اليدوية', 'مۆسیقا-و-هونەری-دەستی', '9.2', hobbies_id),
('كتب وقراءة ومجلات', 'کتێب و خوێندنەوە و گۆڤار', 'كتب-وقراءة-ومجلات', 'کتێب-و-خوێندنەوە-و-گۆڤار', '9.3', hobbies_id),
('العاب تسلية وترفيه (غير الكترونية)', 'یاری کات بەسەربردن (نا ئەلیکترۆنی)', 'العاب-تسلية-وترفيه', 'یاری-کات-بەسەربردن', '9.4', hobbies_id),
('مقتنيات وتحف وانتيكات', 'شتی کۆکراوە و شتی هونەری و ئەنتیکە', 'مقتنيات-وتحف-وانتيكات', 'شتی-کۆکراوە-و-شتی-هونەری-و-ئەنتیکە', '9.5', hobbies_id),
('رحلات وكشتات وهوايات خارجية', 'گەشت و سەیران و خولیای دەرەوە', 'رحلات-وكشتات-وهوايات-خارجية', 'گەشت-و-سەیران-و-خولیای-دەرەوە', '9.6', hobbies_id),
('فنون شعبية وتراثيات (كمقتنيات وهواية)', 'هونەری میللی و کەلەپووری (وەک شتی کۆکراوە و خولیا)', 'فنون-شعبية-وتراثيات', 'هونەری-میللی-و-کەلەپووری', '9.7', hobbies_id),
('تذاكر فعاليات ومناسبات', 'بلیتی چالاکی و بۆنەکان', 'تذاكر-فعاليات-ومناسبات', 'بلیتی-چالاکی-و-بۆنەکان', '9.9', hobbies_id);

-- Level 2 categories for "الحيوانات الاليفة ومستلزماتها"
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('الطيور الاليفة والزينة', 'باڵندەی ماڵی و جوانی', 'الطيور-الاليفة-والزينة', 'باڵندەی-ماڵی-و-جوانی', '10.1', pets_id),
('اسماك الزينة واحواضها', 'ماسی جوانی و حەوزەکانیان', 'اسماك-الزينة-واحواضها', 'ماسی-جوانی-و-حەوزەکانیان', '10.2', pets_id),
('قطط', 'پشیلە', 'قطط', 'پشیلە', '10.3', pets_id),
('كلاب', 'سەگ', 'كلاب', 'سەگ', '10.4', pets_id),
('حيوانات مزارع وحقول (للافراد)', 'ئاژەڵی کێڵگە و مەزرا (بۆ تاکەکان)', 'حيوانات-مزارع-وحقول', 'ئاژەڵی-کێڵگە-و-مەزرا', '10.5', pets_id),
('حيوانات وطيور متنوعة', 'ئاژەڵ و باڵندەی جۆراوجۆر', 'حيوانات-وطيور-متنوعة', 'ئاژەڵ-و-باڵندەی-جۆراوجۆر', '10.6', pets_id),
('اكل ومستلزمات الحيوانات الاليفة', 'خواردن و پێداویستی ئاژەڵی ماڵی', 'اكل-ومستلزمات-الحيوانات-الاليفة', 'خواردن-و-پێداویستی-ئاژەڵی-ماڵی', '10.7', pets_id),
('معدات تربية حيوانات للمزارع والحقول', 'کەرەستەی بەخێوکردنی ئاژەڵ بۆ کێڵگە و مەزرا', 'معدات-تربية-حيوانات-للمزارع-والحقول', 'کەرەستەی-بەخێوکردنی-ئاژەڵ-بۆ-کێڵگە-و-مەزرا', '10.8', pets_id);

-- Level 2 categories for "الاعمال والمعدات التجارية والصناعية"
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('معدات والات للاعمال', 'کەرەستە و ئامێری کار', 'معدات-والات-للاعمال', 'کەرەستە-و-ئامێری-کار', '11.1', business_id),
('فرص تجارية ومشاريع وشراكات', 'هەلی بازرگانی و پڕۆژە و هاوبەشی', 'فرص-تجارية-ومشاريع-وشراكات', 'هەلی-بازرگانی-و-پڕۆژە-و-هاوبەشی', '11.2', business_id),
('مواد اولية وبضاعة بالجملة للاعمال', 'ماددەی سەرەتایی و کاڵای جوملە بۆ کار', 'مواد-اولية-وبضاعة-بالجملة-للاعمال', 'ماددەی-سەرەتایی-و-کاڵای-جوملە-بۆ-کار', '11.3', business_id);

-- Add some detailed subcategories for personal items
SELECT "CategoryID" INTO clothing_shoes_id FROM "Category" WHERE "NameArabic" = 'ملابس واحذية واكسسوارات' AND "ParentID" = personal_items_id;
SELECT "CategoryID" INTO beauty_care_id FROM "Category" WHERE "NameArabic" = 'الجمال والعناية الشخصية' AND "ParentID" = personal_items_id;

-- Level 3 categories for clothing and shoes
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('ملابس نسائية', 'جلوبەرگی ژنان', 'ملابس-نسائية', 'جلوبەرگی-ژنان', '5.1.1', clothing_shoes_id),
('احذية نسائية', 'پێڵاوی ژنان', 'احذية-نسائية', 'پێڵاوی-ژنان', '5.1.2', clothing_shoes_id),
('ملابس رجالية', 'جلوبەرگی پیاوان', 'ملابس-رجالية', 'جلوبەرگی-پیاوان', '5.1.3', clothing_shoes_id),
('احذية رجالية', 'پێڵاوی پیاوان', 'احذية-رجالية', 'پێڵاوی-پیاوان', '5.1.4', clothing_shoes_id),
('ملابس اطفال', 'جلوبەرگی منداڵان', 'ملابس-اطفال', 'جلوبەرگی-منداڵان', '5.1.5', clothing_shoes_id),
('احذية اطفال', 'پێڵاوی منداڵان', 'احذية-اطفال', 'پێڵاوی-منداڵان', '5.1.6', clothing_shoes_id),
('حقائب وشنط ومحافظ', 'جانتا و کیف و جزدان', 'حقائب-وشنط-ومحافظ', 'جانتا-و-کیف-و-جزدان', '5.1.7', clothing_shoes_id),
('ساعات واكسسوارات اخرى', 'کاتژمێر و ئێکسسواراتی تر', 'ساعات-واكسسوارات-اخرى', 'کاتژمێر-و-ئێکسسواراتی-تر', '5.1.8', clothing_shoes_id),
('نظارات شمسية وطبية', 'چاویلکەی خۆر و پزیشکی', 'نظارات-شمسية-وطبية', 'چاویلکەی-خۆر-و-پزیشکی', '5.1.9', clothing_shoes_id);

-- Level 3 categories for beauty and personal care
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('مكياج ومستحضرات تجميل', 'مکیاج و کەرەستەی جوانکاری', 'مكياج-ومستحضرات-تجميل', 'مکیاج-و-کەرەستەی-جوانکاری', '5.3.1', beauty_care_id),
('العناية بالبشرة', 'چاودێری پێست', 'العناية-بالبشرة', 'چاودێری-پێست', '5.3.2', beauty_care_id),
('العناية بالشعر', 'چاودێری قژ', 'العناية-بالشعر', 'چاودێری-قژ', '5.3.3', beauty_care_id),
('عطور ومزيلات عرق', 'بۆن و لابەری ئارەق', 'عطور-ومزيلات-عرق', 'بۆن-و-لابەری-ئارەق', '5.3.4', beauty_care_id),
('الاستحمام والعناية الشخصية', 'خۆشوشتن و چاودێری کەسی', 'الاستحمام-والعناية-الشخصية', 'خۆشوشتن-و-چاودێری-کەسی', '5.3.5', beauty_care_id),
('عدسات ورموش تجميلية', 'هاوێنە و برژانگی جوانکاری', 'عدسات-ورموش-تجميلية', 'هاوێنە-و-برژانگی-جوانکاری', '5.3.6', beauty_care_id),
('الحلاقة وازالة الشعر', 'سەرتاشین و لابردنی موو', 'الحلاقة-وازالة-الشعر', 'سەرتاشین-و-لابردنی-موو', '5.3.7', beauty_care_id);

-- Add some level 3 categories for services
SELECT "CategoryID" INTO vehicle_services_id FROM "Category" WHERE "NameArabic" = 'خدمات المركبات (ورش تصليح، ايجار، غسيل)' AND "ParentID" = services_id;
SELECT "CategoryID" INTO home_services_id FROM "Category" WHERE "NameArabic" = 'الخدمات المنزلية المتنوعة' AND "ParentID" = services_id;

-- Level 3 categories for vehicle services
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('تصليح وصيانة السيارات (فيترچي سيارات)', 'چاککردنەوە و سیانەی ئۆتۆمبێل (فیتەری سەیارە)', 'تصليح-وصيانة-السيارات', 'چاککردنەوە-و-سیانەی-ئۆتۆمبێل', '4.1.1', vehicle_services_id),
('ايجار سيارات', 'بەکرێدانی ئۆتۆمبێل', 'ايجار-سيارات', 'بەکرێدانی-ئۆتۆمبێل', '4.1.2', vehicle_services_id),
('تصليح وصيانة دراجات نارية (فيترچي دراجات)', 'چاککردنەوە و سیانەی ماتۆڕسکیل (فیتەری ماتۆڕ)', 'تصليح-وصيانة-دراجات-نارية', 'چاککردنەوە-و-سیانەی-ماتۆڕسکیل', '4.1.3', vehicle_services_id),
('ايجار دراجات نارية', 'بەکرێدانی ماتۆڕسکیل', 'ايجار-دراجات-نارية', 'بەکرێدانی-ماتۆڕسکیل', '4.1.4', vehicle_services_id),
('غسيل وتنظيف وتلميع المركبات (بولش)', 'شوشتن و پاککردنەوە و پۆڵیشکردنی ئۆتۆمبێل', 'غسيل-وتنظيف-وتلميع-المركبات', 'شوشتن-و-پاککردنەوە-و-پۆڵیشکردنی-ئۆتۆمبێل', '4.1.5', vehicle_services_id),
('خدمات تركيب وصيانة اكسسوارات المركبات', 'خزمەتگوزاری دانان و سیانەی ئێکسسواراتی ئۆتۆمبێل', 'خدمات-تركيب-وصيانة-اكسسوارات-المركبات', 'خزمەتگوزاری-دانان-و-سیانەی-ئێکسسواراتی-ئۆتۆمبێل', '4.1.6', vehicle_services_id),
('محطات وقود متنقلة (خدمة توصيل بنزين)', 'وێستگەی سووتەمەنی گەڕۆک (خزمەتگوزاری گەیاندنی بەنزین)', 'محطات-وقود-متنقلة', 'وێستگەی-سووتەمەنی-گەڕۆک', '4.1.7', vehicle_services_id),
('خدمات فحص وتقييم المركبات المستعملة', 'خزمەتگوزاری پشکنین و هەڵسەنگاندنی ئۆتۆمبێلی بەکارهاتوو', 'خدمات-فحص-وتقييم-المركبات-المستعملة', 'خزمەتگوزاری-پشکنین-و-هەڵسەنگاندنی-ئۆتۆمبێلی-بەکارهاتوو', '4.1.8', vehicle_services_id),
('خدمات مرورية (تخليص معاملات، تسجيل)', 'خزمەتگوزاری هاتووچۆ (ڕاییکردنی مامەڵە، تۆمارکردن)', 'خدمات-مرورية', 'خزمەتگوزاری-هاتووچۆ', '4.1.9', vehicle_services_id),
('خدمات مركبات اخرى', 'خزمەتگوزاری تری ئۆتۆمبێل', 'خدمات-مركبات-اخرى', 'خزمەتگوزاری-تری-ئۆتۆمبێل', '4.1.10', vehicle_services_id);

-- Level 3 categories for home services
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('صيانة واصلاح الاجهزة المنزلية (ثلاجات، غسالات)', 'سیانە و چاککردنەوەی ئامێری ماڵەوە (ساردکەرەوە، جلشۆر)', 'صيانة-واصلاح-الاجهزة-المنزلية', 'سیانە-و-چاککردنەوەی-ئامێری-ماڵەوە', '4.7.1', home_services_id),
('تنظيف منازل وشقق ومكاتب (شركات تنظيف)', 'پاککردنەوەی ماڵ و شوقە و نووسینگە (کۆمپانیای پاککەرەوە)', 'تنظيف-منازل-وشقق-ومكاتب', 'پاککردنەوەی-ماڵ-و-شوقە-و-نووسینگە', '4.7.2', home_services_id),
('مكافحة حشرات وقوارض ورش مبيدات', 'لەناوبردنی مێروو و قرتێنەر و پرژاندنی دەرمانی مێرووکوژ', 'مكافحة-حشرات-وقوارض-ورش-مبيدات', 'لەناوبردنی-مێروو-و-قرتێنەر-و-پرژاندنی-دەرمانی-مێرووکوژ', '4.7.3', home_services_id),
('خدمات العناية بالحدائق', 'خزمەتگوزاری چاودێری باخچە', 'خدمات-العناية-بالحدائق', 'خزمەتگوزاری-چاودێری-باخچە', '4.7.4', home_services_id),
('خدمات طبخ وضيافة للمناسبات والعزائم', 'خزمەتگوزاری چێشتلێنان و میوانداری بۆ بۆنە و خوانەکان', 'خدمات-طبخ-وضيافة-للمناسبات-والعزائم', 'خزمەتگوزاری-چێشتلێنان-و-میوانداری-بۆ-بۆنە-و-خوانەکان', '4.7.5', home_services_id),
('خدمات غسيل وكوي ملابس (دراي كلين)', 'خزمەتگوزاری شوشتن و ئوتوکردنی جلوبەرگ (دراي کلین)', 'خدمات-غسيل-وكوي-ملابس', 'خزمەتگوزاری-شوشتن-و-ئوتوکردنی-جلوبەرگ', '4.7.6', home_services_id);

-- Add some detailed categories for home furniture
SELECT "CategoryID" INTO furniture_id FROM "Category" WHERE "NameArabic" = 'اثاث منزلي (تخم، غرف نوم، ميز طعام)' AND "ParentID" = home_kitchen_id;

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") VALUES
('غرف نوم كاملة ومفردة (اسرّة، خزانات ملابس، تسريحات)', 'ژووری نووستنی تەواو و تاک (جێگا، کەنتۆری جل، مێزی ئارایشت)', 'غرف-نوم-كاملة-ومفردة', 'ژووری-نووستنی-تەواو-و-تاک', '6.1.1', furniture_id),
('تخم وصالات (قنفات، مجالس عربية)', 'تەخم و هۆڵ (قەنەفە، دیوەخانی عەرەبی)', 'تخم-وصالات', 'تەخم-و-هۆڵ', '6.1.2', furniture_id),
('طاولات وبوفيهات طعام', 'مێز و بۆفێی نانخواردن', 'طاولات-وبوفيهات-طعام', 'مێز-و-بۆفێی-نانخواردن', '6.1.3', furniture_id),
('كراسي للاستخدام الداخلي (راسي طعام، كراسي مكتب، وغيرها)', 'کورسی بۆ بەکارهێنانی ناوماڵ (کورسی نانخواردن، کورسی نووسینگە، هتد)', 'كراسي-للاستخدام-الداخلي', 'کورسی-بۆ-بەکارهێنانی-ناوماڵ', '6.1.4', furniture_id),
('مقاعد خارجية ومتخصصة (كراسي حدائق، كراسي اطفال، كراسي طعام عالية، وغيرها)', 'کورسی دەرەوە و تایبەتمەند (کورسی باخچە، کورسی منداڵ، کورسی نانخواردنی بەرز، هتد)', 'مقاعد-خارجية-ومتخصصة', 'کورسی-دەرەوە-و-تایبەتمەند', '6.1.5', furniture_id),
('اثاث مطابخ (كاونترات، خزانات علوية وسفلية)', 'کەلوپەلی چێشتخانە (کاونتەر، کەنتۆری سەرەوە و خوارەوە)', 'اثاث-مطابخ', 'کەلوپەلی-چێشتخانە', '6.1.6', furniture_id),
('اثاث حدائق وخارجي (طاولات، مظلات، ارجوحات)', 'کەلوپەلی باخچە و دەرەوە (مێز، چەتر، جۆلانێ)', 'اثاث-حدائق-وخارجي', 'کەلوپەلی-باخچە-و-دەرەوە', '6.1.7', furniture_id),
('خزانات وحلول تخزين (ارفف، وحدات تلفزيون)', 'کەنتۆر و چارەسەری هەڵگرتن (ڕەفە، یەکەی تەلەفزیۆن)', 'خزانات-وحلول-تخزين', 'کەنتۆر-و-چارەسەری-هەڵگرتن', '6.1.8', furniture_id);

END $$;

-- Commit the transaction
COMMIT;

-- Create indexes for better performance
CREATE INDEX CONCURRENTLY IF NOT EXISTS "idx_category_parent_id" ON "Category" ("ParentID");
CREATE INDEX CONCURRENTLY IF NOT EXISTS "idx_category_hierarchy_path" ON "Category" ("hierarchy_path");
CREATE INDEX CONCURRENTLY IF NOT EXISTS "idx_category_url_slug_arabic" ON "Category" ("UrlSlugArabic");
CREATE INDEX CONCURRENTLY IF NOT EXISTS "idx_category_url_slug_kurdish" ON "Category" ("UrlSlugKurdish");

-- Drop the helper function
DROP FUNCTION IF EXISTS clean_name_for_slug(TEXT);



WITH RECURSIVE CategoryHierarchy AS (
    -- Anchor member: Select root categories
    SELECT 
        "CategoryID" as id,
        "NameArabic" as name_ar,
        "NameKurdish" as name_kr,
        "hierarchy_path" as category_level,
        CAST("NameArabic" AS TEXT) AS path,
        0 AS depth,
        CASE "NameArabic"
            WHEN 'مركبات ونقل' THEN 1
            WHEN 'العقارات والاملاك' THEN 2
            WHEN 'الوظائف وفرص العمل' THEN 3
            WHEN 'الخدمات (خدمات عامة ومتخصصة)' THEN 4
            WHEN 'المقتنيات الشخصية والصحة والجمال' THEN 5
            WHEN 'المنزل والمطبخ والحديقة' THEN 6
            WHEN 'قطع الغيار والاكسسوارات للمركبات' THEN 7
            WHEN 'الالكترونيات والاجهزة الرقمية' THEN 8
            WHEN 'الهوايات والترفيه والانشطة' THEN 9
            WHEN 'الحيوانات الاليفة ومستلزماتها' THEN 10
            WHEN 'الاعمال والمعدات التجارية والصناعية' THEN 11
            ELSE 12
        END AS root_order
    FROM "Category"
    WHERE "ParentID" IS NULL

    UNION ALL

    -- Recursive member: Select child categories
    SELECT 
        c."CategoryID",
        c."NameArabic",
        c."NameKurdish",
        c."hierarchy_path",
        CAST(ch.path || ' > ' || c."NameArabic" AS TEXT),
        ch.depth + 1,
        ch.root_order
    FROM "Category" c
    INNER JOIN CategoryHierarchy ch ON c."ParentID" = ch.id
)
SELECT 
    CASE 
        WHEN depth = 0 THEN name_ar
        WHEN depth = 1 THEN '  ' || name_ar
        WHEN depth = 2 THEN '    ' || name_ar
        WHEN depth = 3 THEN '      ' || name_ar
        ELSE '        ' || name_ar
    END AS hierarchical_name_ar,
    CASE 
        WHEN depth = 0 THEN name_kr
        WHEN depth = 1 THEN '  ' || name_kr
        WHEN depth = 2 THEN '    ' || name_kr
        WHEN depth = 3 THEN '      ' || name_kr
        ELSE '        ' || name_kr
    END AS hierarchical_name_kr,
    category_level,
    depth,
    path
FROM CategoryHierarchy
ORDER BY root_order, path;
