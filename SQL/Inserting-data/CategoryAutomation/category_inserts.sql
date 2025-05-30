-- PostgreSQL script to insert all category data
-- Generated automatically - do not edit manually
-- Total categories to insert: 715

BEGIN;

-- Disable triggers for better performance
SET session_replication_role = replica;

-- Level 1 Category: 1 - مركبات ونقل

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مركبات ونقل', 'ئۆتۆمبێل و گواستنەوە', 'مركبات-ونقل', 'ئۆتۆمبێل-و-گواستنەوە', '1', NULL);
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('سيارات', 'ئۆتۆمبێل (سەیارە)', 'مركبات-ونقل/سيارات', 'ئۆتۆمبێل-و-گواستنەوە/ئۆتۆمبێل', '1.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('دراجات نارية وعجلات اخرى', 'ماتۆڕسکیل و تایەی تر (پایسکل و چەرخی تر)', 'مركبات-ونقل/دراجات-نارية-وعجلات-اخرى', 'ئۆتۆمبێل-و-گواستنەوە/ماتۆڕسکیل-و-تایەی-تر', '1.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('دراجات نارية (موتوسيكلات)', 'ماتۆڕسکیل (ماتۆڕ)', 'مركبات-ونقل/دراجات-نارية-وعجلات-اخرى/دراجات-نارية', 'ئۆتۆمبێل-و-گواستنەوە/ماتۆڕسکیل-و-تایەی-تر/ماتۆڕسکیل', '1.2.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('دراجات هوائية وسكوترات', 'پاسکیل و سکۆتەر', 'مركبات-ونقل/دراجات-نارية-وعجلات-اخرى/دراجات-هوائية-وسكوترات', 'ئۆتۆمبێل-و-گواستنەوە/ماتۆڕسکیل-و-تایەی-تر/پاسکیل-و-سکۆتەر', '1.2.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مركبات طرق وعرة (ATV)', 'ئۆتۆمبێلی ڕێگا ناخۆشەکان (ATV)', 'مركبات-ونقل/دراجات-نارية-وعجلات-اخرى/مركبات-طرق-وعرة', 'ئۆتۆمبێل-و-گواستنەوە/ماتۆڕسکیل-و-تایەی-تر/ئۆتۆمبێلی-ڕێگا-ناخۆشەکان', '1.2.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('دراجات رباعية وباجي (Buggies)', 'ماتۆڕی چوار تایە و بەگی (Buggies)', 'مركبات-ونقل/دراجات-نارية-وعجلات-اخرى/دراجات-رباعية-وباجي', 'ئۆتۆمبێل-و-گواستنەوە/ماتۆڕسکیل-و-تایەی-تر/ماتۆڕی-چوار-تایە-و-بەگی', '1.2.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('شاحنات', 'بارهەڵگر (شاحینە)', 'مركبات-ونقل/شاحنات', 'ئۆتۆمبێل-و-گواستنەوە/بارهەڵگر', '1.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معدات ثقيلة واليات', 'ئامێری قورس و میکانیزم', 'مركبات-ونقل/معدات-ثقيلة-واليات', 'ئۆتۆمبێل-و-گواستنەوە/ئامێری-قورس-و-میکانیزم', '1.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('نقل تجاري خفيف (بيك ام، كيه)', 'گواستنەوەی بازرگانی سووک (پیکاب، کەی)', 'مركبات-ونقل/معدات-ثقيلة-واليات/نقل-تجاري-خفيف', 'ئۆتۆمبێل-و-گواستنەوە/ئامێری-قورس-و-میکانیزم/گواستنەوەی-بازرگانی-سووک', '1.4.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1.4'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('شفلات', 'شۆفڵ', 'مركبات-ونقل/معدات-ثقيلة-واليات/شفلات', 'ئۆتۆمبێل-و-گواستنەوە/ئامێری-قورس-و-میکانیزم/شۆفڵ', '1.4.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('لوريات (شاحنات نقل كبيرة)', 'لۆری (بارهەڵگری گەورە)', 'مركبات-ونقل/معدات-ثقيلة-واليات/لوريات', 'ئۆتۆمبێل-و-گواستنەوە/ئامێری-قورس-و-میکانیزم/لۆری', '1.4.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('جرارات', 'تراکتۆر', 'مركبات-ونقل/معدات-ثقيلة-واليات/جرارات', 'ئۆتۆمبێل-و-گواستنەوە/ئامێری-قورس-و-میکانیزم/تراکتۆر', '1.4.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('حفارات', 'حەفارە', 'مركبات-ونقل/معدات-ثقيلة-واليات/حفارات', 'ئۆتۆمبێل-و-گواستنەوە/ئامێری-قورس-و-میکانیزم/حەفارە', '1.4.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('رافعات (كرينات)', 'کڕێن (ڕافیعە)', 'مركبات-ونقل/معدات-ثقيلة-واليات/رافعات', 'ئۆتۆمبێل-و-گواستنەوە/ئامێری-قورس-و-میکانیزم/کڕێن', '1.4.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('حافلات (باصات)', 'پاس', 'مركبات-ونقل/معدات-ثقيلة-واليات/حافلات', 'ئۆتۆمبێل-و-گواستنەوە/ئامێری-قورس-و-میکانیزم/پاس', '1.4.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('جرافات', 'بلدۆزەر (جەڕافە)', 'مركبات-ونقل/معدات-ثقيلة-واليات/جرافات', 'ئۆتۆمبێل-و-گواستنەوە/ئامێری-قورس-و-میکانیزم/بلدۆزەر', '1.4.8', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معدات زراعية', 'کەلوپەلی کشتوکاڵی', 'مركبات-ونقل/معدات-ثقيلة-واليات/معدات-زراعية', 'ئۆتۆمبێل-و-گواستنەوە/ئامێری-قورس-و-میکانیزم/کەلوپەلی-کشتوکاڵی', '1.4.9', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معدات بناء', 'کەلوپەلی بیناسازی', 'مركبات-ونقل/معدات-ثقيلة-واليات/معدات-بناء', 'ئۆتۆمبێل-و-گواستنەوە/ئامێری-قورس-و-میکانیزم/کەلوپەلی-بیناسازی', '1.4.10', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معدات واليات اخرى (الرافعات الشوكية، مضخات الخرسانة، وغيرها)', 'ئامێر و میکانیزمی تر (ڕافیعەی شەوکەدار، پەمپی کۆنکرێت، هتد)', 'مركبات-ونقل/معدات-ثقيلة-واليات/معدات-واليات-اخرى', 'ئۆتۆمبێل-و-گواستنەوە/ئامێری-قورس-و-میکانیزم/ئامێر-و-میکانیزمی-تر', '1.4.11', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1.4'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('النقل البحري', 'گواستنەوەی دەریایی', 'مركبات-ونقل/النقل-البحري', 'ئۆتۆمبێل-و-گواستنەوە/گواستنەوەی-دەریایی', '1.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قوارب تجديف', 'بەلەمی سەوڵ لێدان', 'مركبات-ونقل/النقل-البحري/قوارب-تجديف', 'ئۆتۆمبێل-و-گواستنەوە/گواستنەوەی-دەریایی/بەلەمی-سەوڵ-لێدان', '1.5.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('دراجات مائية (جت سكي)', 'جێتسکی (ماتۆڕی ئاوی)', 'مركبات-ونقل/النقل-البحري/دراجات-مائية', 'ئۆتۆمبێل-و-گواستنەوە/گواستنەوەی-دەریایی/جێتسکی', '1.5.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قوارب ويخوت', 'بەلەم و یەخت', 'مركبات-ونقل/النقل-البحري/قوارب-ويخوت', 'ئۆتۆمبێل-و-گواستنەوە/گواستنەوەی-دەریایی/بەلەم-و-یەخت', '1.5.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '1.5'));

-- End of Level 1 Category: 1

-- Level 1 Category: 2 - العقارات والاملاك

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('العقارات والاملاك', 'خانووبەرە و موڵک', 'العقارات-والاملاك', 'خانووبەرە-و-موڵک', '2', NULL);
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عقارات للبيع', 'خانووبەرە بۆ فرۆشتن', 'العقارات-والاملاك/عقارات-للبيع', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن', '2.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('سكني', 'نیشتەجێبوون', 'العقارات-والاملاك/عقارات-للبيع/سكني', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/نیشتەجێبوون', '2.1.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('منازل وفلل', 'ماڵ و ڤێلا', 'العقارات-والاملاك/عقارات-للبيع/سكني/منازل-وفلل', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/نیشتەجێبوون/ماڵ-و-ڤێلا', '2.1.1.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('بيوت عادية', 'ماڵی ئاسایی', 'العقارات-والاملاك/عقارات-للبيع/سكني/منازل-وفلل/بيوت-عادية', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/نیشتەجێبوون/ماڵ-و-ڤێلا/ماڵی-ئاسایی', '2.1.1.1.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.1.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('بيوت بناء حديث', 'ماڵی تازە دروستکراو', 'العقارات-والاملاك/عقارات-للبيع/سكني/منازل-وفلل/بيوت-بناء-حديث', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/نیشتەجێبوون/ماڵ-و-ڤێلا/ماڵی-تازە-دروستکراو', '2.1.1.1.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.1.1'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('فلل مستقلة', 'ڤێلای سەربەخۆ', 'العقارات-والاملاك/عقارات-للبيع/سكني/منازل-وفلل/فلل-مستقلة', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/نیشتەجێبوون/ماڵ-و-ڤێلا/ڤێلای-سەربەخۆ', '2.1.1.1.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.1.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('فلل متلاصقة (تاون هاوس)', 'ڤێلای لکاو (تاون هاوس)', 'العقارات-والاملاك/عقارات-للبيع/سكني/منازل-وفلل/فلل-متلاصقة', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/نیشتەجێبوون/ماڵ-و-ڤێلا/ڤێلای-لکاو', '2.1.1.1.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.1.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('بيوت دوبلكس', 'ماڵی دوپلێکس', 'العقارات-والاملاك/عقارات-للبيع/سكني/منازل-وفلل/بيوت-دوبلكس', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/نیشتەجێبوون/ماڵ-و-ڤێلا/ماڵی-دوپلێکس', '2.1.1.1.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.1.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('بيوت ريفية (قروية)', 'ماڵی گوند (لادێ)', 'العقارات-والاملاك/عقارات-للبيع/سكني/منازل-وفلل/بيوت-ريفية', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/نیشتەجێبوون/ماڵ-و-ڤێلا/ماڵی-گوند', '2.1.1.1.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.1.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('شقق', 'شوقە', 'العقارات-والاملاك/عقارات-للبيع/سكني/شقق', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/نیشتەجێبوون/شوقە', '2.1.1.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('شقق عادية', 'شوقەی ئاسایی', 'العقارات-والاملاك/عقارات-للبيع/سكني/شقق/شقق-عادية', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/نیشتەجێبوون/شوقە/شوقەی-ئاسایی', '2.1.1.2.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.1.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('شقق فخمة (ديلوكس)', 'شوقەی دەلۆکس (شاهانە)', 'العقارات-والاملاك/عقارات-للبيع/سكني/شقق/شقق-فخمة', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/نیشتەجێبوون/شوقە/شوقەی-دەلۆکس', '2.1.1.2.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.1.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('شقق استوديو', 'شوقەی ستۆدیۆ', 'العقارات-والاملاك/عقارات-للبيع/سكني/شقق/شقق-استوديو', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/نیشتەجێبوون/شوقە/شوقەی-ستۆدیۆ', '2.1.1.2.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.1.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('شقق دوبلكس', 'شوقەی دوپلێکس', 'العقارات-والاملاك/عقارات-للبيع/سكني/شقق/شقق-دوبلكس', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/نیشتەجێبوون/شوقە/شوقەی-دوپلێکس', '2.1.1.2.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.1.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قطع اراضي', 'پارچە زەوی', 'العقارات-والاملاك/عقارات-للبيع/سكني/قطع-اراضي', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/نیشتەجێبوون/پارچە-زەوی', '2.1.1.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.1'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اراضي سكنية (عرصات)', 'زەوی نیشتەجێبوون (عەرسە)', 'العقارات-والاملاك/عقارات-للبيع/سكني/قطع-اراضي/اراضي-سكنية', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/نیشتەجێبوون/پارچە-زەوی/زەوی-نیشتەجێبوون', '2.1.1.3.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.1.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اراضي زراعية', 'زەوی کشتوکاڵی', 'العقارات-والاملاك/عقارات-للبيع/سكني/قطع-اراضي/اراضي-زراعية', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/نیشتەجێبوون/پارچە-زەوی/زەوی-کشتوکاڵی', '2.1.1.3.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.1.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اراضي تجارية وصناعية', 'زەوی بازرگانی و پیشەسازی', 'العقارات-والاملاك/عقارات-للبيع/سكني/قطع-اراضي/اراضي-تجارية-وصناعية', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/نیشتەجێبوون/پارچە-زەوی/زەوی-بازرگانی-و-پیشەسازی', '2.1.1.3.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.1.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تجاري وصناعي', 'بازرگانی و پیشەسازی', 'العقارات-والاملاك/عقارات-للبيع/تجاري-وصناعي', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/بازرگانی-و-پیشەسازی', '2.1.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('محلات تجارية', 'دوکانی بازرگانی', 'العقارات-والاملاك/عقارات-للبيع/تجاري-وصناعي/محلات-تجارية', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/بازرگانی-و-پیشەسازی/دوکانی-بازرگانی', '2.1.2.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مكاتب', 'نووسینگە (مەکتەب)', 'العقارات-والاملاك/عقارات-للبيع/تجاري-وصناعي/مكاتب', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/بازرگانی-و-پیشەسازی/نووسینگە', '2.1.2.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ورش ومعامل صغيرة', 'وەرشە و کارگەی بچووک', 'العقارات-والاملاك/عقارات-للبيع/تجاري-وصناعي/ورش-ومعامل-صغيرة', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/بازرگانی-و-پیشەسازی/وەرشە-و-کارگەی-بچووک', '2.1.2.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مخازن ومستودعات', 'کۆگا و مەخزەن', 'العقارات-والاملاك/عقارات-للبيع/تجاري-وصناعي/مخازن-ومستودعات', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/بازرگانی-و-پیشەسازی/کۆگا-و-مەخزەن', '2.1.2.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مشاريع تحت الانشاء', 'پڕۆژەی لەژێر دروستکردن', 'العقارات-والاملاك/عقارات-للبيع/مشاريع-تحت-الانشاء', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/پڕۆژەی-لەژێر-دروستکردن', '2.1.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مشاريع سكنية تحت الانشاء', 'پڕۆژەی نیشتەجێبوونی لەژێر دروستکردن', 'العقارات-والاملاك/عقارات-للبيع/مشاريع-تحت-الانشاء/مشاريع-سكنية-تحت-الانشاء', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/پڕۆژەی-لەژێر-دروستکردن/پڕۆژەی-نیشتەجێبوونی-لەژێر-دروستکردن', '2.1.3.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.3'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مجمعات تجارية تحت الانشاء', 'کۆمەڵگەی بازرگانی لەژێر دروستکردن', 'العقارات-والاملاك/عقارات-للبيع/مشاريع-تحت-الانشاء/مجمعات-تجارية-تحت-الانشاء', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/پڕۆژەی-لەژێر-دروستکردن/کۆمەڵگەی-بازرگانی-لەژێر-دروستکردن', '2.1.3.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مشاريع صناعية تحت الانشاء', 'پڕۆژەی پیشەسازی لەژێر دروستکردن', 'العقارات-والاملاك/عقارات-للبيع/مشاريع-تحت-الانشاء/مشاريع-صناعية-تحت-الانشاء', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/پڕۆژەی-لەژێر-دروستکردن/پڕۆژەی-پیشەسازی-لەژێر-دروستکردن', '2.1.3.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عقارات خارج العراق', 'خانووبەرە لە دەرەوەی عێراق', 'العقارات-والاملاك/عقارات-للبيع/عقارات-خارج-العراق', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/خانووبەرە-لە-دەرەوەی-عێراق', '2.1.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تركيا', 'تورکیا', 'العقارات-والاملاك/عقارات-للبيع/عقارات-خارج-العراق/تركيا', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/خانووبەرە-لە-دەرەوەی-عێراق/تورکیا', '2.1.4.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الامارات', 'ئیمارات', 'العقارات-والاملاك/عقارات-للبيع/عقارات-خارج-العراق/الامارات', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/خانووبەرە-لە-دەرەوەی-عێراق/ئیمارات', '2.1.4.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('دول اخرى', 'وڵاتانی تر', 'العقارات-والاملاك/عقارات-للبيع/عقارات-خارج-العراق/دول-اخرى', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/خانووبەرە-لە-دەرەوەی-عێراق/وڵاتانی-تر', '2.1.4.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('فئات عقارية اخرى للبيع', 'پۆلەکانی تری خانووبەرە بۆ فرۆشتن', 'العقارات-والاملاك/عقارات-للبيع/فئات-عقارية-اخرى-للبيع', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/پۆلەکانی-تری-خانووبەرە-بۆ-فرۆشتن', '2.1.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('استوديوهات (غير سكني)', 'ستۆدیۆ (نا نیشتەجێبوون)', 'العقارات-والاملاك/عقارات-للبيع/فئات-عقارية-اخرى-للبيع/استوديوهات', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/پۆلەکانی-تری-خانووبەرە-بۆ-فرۆشتن/ستۆدیۆ', '2.1.5.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عيادات ومراكز طبية', 'کلینیک و ناوەندی پزیشکی', 'العقارات-والاملاك/عقارات-للبيع/فئات-عقارية-اخرى-للبيع/عيادات-ومراكز-طبية', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/پۆلەکانی-تری-خانووبەرە-بۆ-فرۆشتن/کلینیک-و-ناوەندی-پزیشکی', '2.1.5.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مطاعم ومقاهي (كافيهات)', 'چێشتخانە و قاوەخانە (کافتریا)', 'العقارات-والاملاك/عقارات-للبيع/فئات-عقارية-اخرى-للبيع/مطاعم-ومقاهي', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/پۆلەکانی-تری-خانووبەرە-بۆ-فرۆشتن/چێشتخانە-و-قاوەخانە', '2.1.5.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.5'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مواقف سيارات (كراجات)', 'پارکینگی ئۆتۆمبێل (گەڕاج)', 'العقارات-والاملاك/عقارات-للبيع/فئات-عقارية-اخرى-للبيع/مواقف-سيارات', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/پۆلەکانی-تری-خانووبەرە-بۆ-فرۆشتن/پارکینگی-ئۆتۆمبێل', '2.1.5.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قاعات مناسبات وافراح', 'هۆڵی بۆنە و ئاهەنگ', 'العقارات-والاملاك/عقارات-للبيع/فئات-عقارية-اخرى-للبيع/قاعات-مناسبات-وافراح', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/پۆلەکانی-تری-خانووبەرە-بۆ-فرۆشتن/هۆڵی-بۆنە-و-ئاهەنگ', '2.1.5.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قاعات مؤتمرات واجتماعات', 'هۆڵی کۆنفرانس و کۆبوونەوە', 'العقارات-والاملاك/عقارات-للبيع/فئات-عقارية-اخرى-للبيع/قاعات-مؤتمرات-واجتماعات', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/پۆلەکانی-تری-خانووبەرە-بۆ-فرۆشتن/هۆڵی-کۆنفرانس-و-کۆبوونەوە', '2.1.5.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عقارات اخرى للبيع', 'خانووبەرەی تری بۆ فرۆشتن', 'العقارات-والاملاك/عقارات-للبيع/فئات-عقارية-اخرى-للبيع/عقارات-اخرى-للبيع', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-فرۆشتن/پۆلەکانی-تری-خانووبەرە-بۆ-فرۆشتن/خانووبەرەی-تری-بۆ-فرۆشتن', '2.1.5.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.1.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عقارات للايجار', 'خانووبەرە بۆ کرێ', 'العقارات-والاملاك/عقارات-للايجار', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ', '2.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('سكني', 'نیشتەجێبوون', 'العقارات-والاملاك/عقارات-للايجار/سكني', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/نیشتەجێبوون', '2.2.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('منازل وفلل للايجار', 'ماڵ و ڤێلا بۆ کرێ', 'العقارات-والاملاك/عقارات-للايجار/سكني/منازل-وفلل-للايجار', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/نیشتەجێبوون/ماڵ-و-ڤێلا-بۆ-کرێ', '2.2.1.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('بيوت عادية', 'ماڵی ئاسایی', 'العقارات-والاملاك/عقارات-للايجار/سكني/منازل-وفلل-للايجار/بيوت-عادية', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/نیشتەجێبوون/ماڵ-و-ڤێلا-بۆ-کرێ/ماڵی-ئاسایی', '2.2.1.1.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.1.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('فلل مستقلة', 'ڤێلای سەربەخۆ', 'العقارات-والاملاك/عقارات-للايجار/سكني/منازل-وفلل-للايجار/فلل-مستقلة', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/نیشتەجێبوون/ماڵ-و-ڤێلا-بۆ-کرێ/ڤێلای-سەربەخۆ', '2.2.1.1.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.1.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('فلل متلاصقة (تاون هاوس)', 'ڤێلای لکاو (تاون هاوس)', 'العقارات-والاملاك/عقارات-للايجار/سكني/منازل-وفلل-للايجار/فلل-متلاصقة', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/نیشتەجێبوون/ماڵ-و-ڤێلا-بۆ-کرێ/ڤێلای-لکاو', '2.2.1.1.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.1.1'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('بيوت دوبلكس', 'ماڵی دوپلێکس', 'العقارات-والاملاك/عقارات-للايجار/سكني/منازل-وفلل-للايجار/بيوت-دوبلكس', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/نیشتەجێبوون/ماڵ-و-ڤێلا-بۆ-کرێ/ماڵی-دوپلێکس', '2.2.1.1.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.1.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('بيوت ريفية (قروية)', 'ماڵی گوند (لادێ)', 'العقارات-والاملاك/عقارات-للايجار/سكني/منازل-وفلل-للايجار/بيوت-ريفية', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/نیشتەجێبوون/ماڵ-و-ڤێلا-بۆ-کرێ/ماڵی-گوند', '2.2.1.1.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.1.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('شقق للايجار', 'شوقە بۆ کرێ', 'العقارات-والاملاك/عقارات-للايجار/سكني/شقق-للايجار', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/نیشتەجێبوون/شوقە-بۆ-کرێ', '2.2.1.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('شقق عادية', 'شوقەی ئاسایی', 'العقارات-والاملاك/عقارات-للايجار/سكني/شقق-للايجار/شقق-عادية', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/نیشتەجێبوون/شوقە-بۆ-کرێ/شوقەی-ئاسایی', '2.2.1.2.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.1.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('شقق فخمة (ديلوكس)', 'شوقەی دەلۆکس (شاهانە)', 'العقارات-والاملاك/عقارات-للايجار/سكني/شقق-للايجار/شقق-فخمة', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/نیشتەجێبوون/شوقە-بۆ-کرێ/شوقەی-دەلۆکس', '2.2.1.2.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.1.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('شقق استوديو', 'شوقەی ستۆدیۆ', 'العقارات-والاملاك/عقارات-للايجار/سكني/شقق-للايجار/شقق-استوديو', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/نیشتەجێبوون/شوقە-بۆ-کرێ/شوقەی-ستۆدیۆ', '2.2.1.2.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.1.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('شقق مفروشة', 'شوقەی مۆبیلیەکراو (مەفروش)', 'العقارات-والاملاك/عقارات-للايجار/سكني/شقق-للايجار/شقق-مفروشة', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/نیشتەجێبوون/شوقە-بۆ-کرێ/شوقەی-مۆبیلیەکراو', '2.2.1.2.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.1.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تجاري وصناعي', 'بازرگانی و پیشەسازی', 'العقارات-والاملاك/عقارات-للايجار/تجاري-وصناعي', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/بازرگانی-و-پیشەسازی', '2.2.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('محلات تجارية', 'دوکانی بازرگانی', 'العقارات-والاملاك/عقارات-للايجار/تجاري-وصناعي/محلات-تجارية', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/بازرگانی-و-پیشەسازی/دوکانی-بازرگانی', '2.2.2.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مكاتب', 'نووسینگە (مەکتەب)', 'العقارات-والاملاك/عقارات-للايجار/تجاري-وصناعي/مكاتب', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/بازرگانی-و-پیشەسازی/نووسینگە', '2.2.2.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.2'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ورش ومعامل صغيرة', 'وەرشە و کارگەی بچووک', 'العقارات-والاملاك/عقارات-للايجار/تجاري-وصناعي/ورش-ومعامل-صغيرة', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/بازرگانی-و-پیشەسازی/وەرشە-و-کارگەی-بچووک', '2.2.2.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مخازن ومستودعات', 'کۆگا و مەخزەن', 'العقارات-والاملاك/عقارات-للايجار/تجاري-وصناعي/مخازن-ومستودعات', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/بازرگانی-و-پیشەسازی/کۆگا-و-مەخزەن', '2.2.2.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('فئات عقارية اخرى للايجار', 'پۆلەکانی تری خانووبەرە بۆ کرێ', 'العقارات-والاملاك/عقارات-للايجار/فئات-عقارية-اخرى-للايجار', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/پۆلەکانی-تری-خانووبەرە-بۆ-کرێ', '2.2.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('استوديوهات (غير سكني)', 'ستۆدیۆ (نا نیشتەجێبوون)', 'العقارات-والاملاك/عقارات-للايجار/فئات-عقارية-اخرى-للايجار/استوديوهات', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/پۆلەکانی-تری-خانووبەرە-بۆ-کرێ/ستۆدیۆ', '2.2.3.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مزارع', 'کێڵگە (مەزرەعە)', 'العقارات-والاملاك/عقارات-للايجار/فئات-عقارية-اخرى-للايجار/مزارع', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/پۆلەکانی-تری-خانووبەرە-بۆ-کرێ/کێڵگە', '2.2.3.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عيادات ومراكز طبية', 'کلینیک و ناوەندی پزیشکی', 'العقارات-والاملاك/عقارات-للايجار/فئات-عقارية-اخرى-للايجار/عيادات-ومراكز-طبية', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/پۆلەکانی-تری-خانووبەرە-بۆ-کرێ/کلینیک-و-ناوەندی-پزیشکی', '2.2.3.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مطاعم ومقاهي (كافيهات)', 'چێشتخانە و قاوەخانە (کافتریا)', 'العقارات-والاملاك/عقارات-للايجار/فئات-عقارية-اخرى-للايجار/مطاعم-ومقاهي', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/پۆلەکانی-تری-خانووبەرە-بۆ-کرێ/چێشتخانە-و-قاوەخانە', '2.2.3.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مواقف سيارات (كراجات)', 'پارکینگی ئۆتۆمبێل (گەڕاج)', 'العقارات-والاملاك/عقارات-للايجار/فئات-عقارية-اخرى-للايجار/مواقف-سيارات', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/پۆلەکانی-تری-خانووبەرە-بۆ-کرێ/پارکینگی-ئۆتۆمبێل', '2.2.3.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قاعات مناسبات وافراح', 'هۆڵی بۆنە و ئاهەنگ', 'العقارات-والاملاك/عقارات-للايجار/فئات-عقارية-اخرى-للايجار/قاعات-مناسبات-وافراح', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/پۆلەکانی-تری-خانووبەرە-بۆ-کرێ/هۆڵی-بۆنە-و-ئاهەنگ', '2.2.3.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قاعات مؤتمرات واجتماعات', 'هۆڵی کۆنفرانس و کۆبوونەوە', 'العقارات-والاملاك/عقارات-للايجار/فئات-عقارية-اخرى-للايجار/قاعات-مؤتمرات-واجتماعات', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/پۆلەکانی-تری-خانووبەرە-بۆ-کرێ/هۆڵی-کۆنفرانس-و-کۆبوونەوە', '2.2.3.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.3'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عقارات اخرى للايجار', 'خانووبەرەی تری بۆ کرێ', 'العقارات-والاملاك/عقارات-للايجار/فئات-عقارية-اخرى-للايجار/عقارات-اخرى-للايجار', 'خانووبەرە-و-موڵک/خانووبەرە-بۆ-کرێ/پۆلەکانی-تری-خانووبەرە-بۆ-کرێ/خانووبەرەی-تری-بۆ-کرێ', '2.2.3.8', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '2.2.3'));

-- End of Level 1 Category: 2

-- Level 1 Category: 3 - الوظائف وفرص العمل

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الوظائف وفرص العمل', 'کار و هەلی کار', 'الوظائف-وفرص-العمل', 'کار-و-هەلی-کار', '3', NULL);
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ابحث عن عمل (طلبات توظيف)', 'گەڕان بەدوای کار (داواکاری دامەزراندن)', 'الوظائف-وفرص-العمل/ابحث-عن-عمل', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار', '3.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('البناء والتشييد والانشاءات', 'بیناسازی و ئاوەدانکردنەوە', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/البناء-والتشييد-والانشاءات', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/بیناسازی-و-ئاوەدانکردنەوە', '3.1.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عامل بناء (خلفة بناء)', 'کرێکاری بیناسازی (وەستای بینا)', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/البناء-والتشييد-والانشاءات/عامل-بناء', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/بیناسازی-و-ئاوەدانکردنەوە/کرێکاری-بیناسازی', '3.1.1.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مهندس معماري', 'ئەندازیاری تەلارسازی', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/البناء-والتشييد-والانشاءات/مهندس-معماري', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/بیناسازی-و-ئاوەدانکردنەوە/ئەندازیاری-تەلارسازی', '3.1.1.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مهندس مدني', 'ئەندازیاری شارستانی', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/البناء-والتشييد-والانشاءات/مهندس-مدني', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/بیناسازی-و-ئاوەدانکردنەوە/ئەندازیاری-شارستانی', '3.1.1.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('فني صحيات وكهرباء (سباك، كهربائي)', 'تەکنیکاری ئاوەڕۆ و کارەبا (سەباخ، کارەباچی)', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/البناء-والتشييد-والانشاءات/فني-صحيات-وكهرباء', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/بیناسازی-و-ئاوەدانکردنەوە/تەکنیکاری-ئاوەڕۆ-و-کارەبا', '3.1.1.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تكنولوجيا المعلومات والاتصالات (IT)', 'تەکنەلۆژیای زانیاری و گەیاندن (IT)', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/تكنولوجيا-المعلومات-والاتصالات', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/تەکنەلۆژیای-زانیاری-و-گەیاندن', '3.1.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تطوير برامج وتطبيقات (مبرمج)', 'پەرەپێدانی پرۆگرام و ئەپلیکەیشن (پرۆگرامساز)', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/تكنولوجيا-المعلومات-والاتصالات/تطوير-برامج-وتطبيقات', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/تەکنەلۆژیای-زانیاری-و-گەیاندن/پەرەپێدانی-پرۆگرام-و-ئەپلیکەیشن', '3.1.2.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.2'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادارة شبكات كومبيوتر', 'بەڕێوەبردنی تۆڕەکانی کۆمپیوتەر', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/تكنولوجيا-المعلومات-والاتصالات/ادارة-شبكات-كومبيوتر', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/تەکنەلۆژیای-زانیاری-و-گەیاندن/بەڕێوەبردنی-تۆڕەکانی-کۆمپیوتەر', '3.1.2.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('دعم فني (IT Support)', 'پشتیوانی تەکنیکی (IT Support)', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/تكنولوجيا-المعلومات-والاتصالات/دعم-فني', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/تەکنەلۆژیای-زانیاری-و-گەیاندن/پشتیوانی-تەکنیکی', '3.1.2.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('امن معلومات (Cybersecurity)', 'ئاسایشی زانیاری (Cybersecurity)', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/تكنولوجيا-المعلومات-والاتصالات/امن-معلومات', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/تەکنەلۆژیای-زانیاری-و-گەیاندن/ئاسایشی-زانیاری', '3.1.2.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تحليل بيانات', 'شیکردنەوەی داتا', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/تكنولوجيا-المعلومات-والاتصالات/تحليل-بيانات', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/تەکنەلۆژیای-زانیاری-و-گەیاندن/شیکردنەوەی-داتا', '3.1.2.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('وظائف ادارية ومكتبية', 'کاری کارگێڕی و نووسینگە', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/وظائف-ادارية-ومكتبية', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/کاری-کارگێڕی-و-نووسینگە', '3.1.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مساعد اداري', 'یاریدەدەری کارگێڕی', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/وظائف-ادارية-ومكتبية/مساعد-اداري', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/کاری-کارگێڕی-و-نووسینگە/یاریدەدەری-کارگێڕی', '3.1.3.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مدير مكتب', 'بەڕێوەبەری نووسینگە', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/وظائف-ادارية-ومكتبية/مدير-مكتب', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/کاری-کارگێڕی-و-نووسینگە/بەڕێوەبەری-نووسینگە', '3.1.3.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('موظف استقبال', 'فەرمانبەری پێشوازی', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/وظائف-ادارية-ومكتبية/موظف-استقبال', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/کاری-کارگێڕی-و-نووسینگە/فەرمانبەری-پێشوازی', '3.1.3.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('سكرتارية تنفيذية', 'سکرتاریەتی جێبەجێکار', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/وظائف-ادارية-ومكتبية/سكرتارية-تنفيذية', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/کاری-کارگێڕی-و-نووسینگە/سکرتاریەتی-جێبەجێکار', '3.1.3.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('المحاسبة والمالية', 'ژمێریاری و دارایی', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/المحاسبة-والمالية', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/ژمێریاری-و-دارایی', '3.1.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('محاسب', 'ژمێریار', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/المحاسبة-والمالية/محاسب', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/ژمێریاری-و-دارایی/ژمێریار', '3.1.4.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مدقق حسابات', 'وردبینەری هەژمارەکان', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/المحاسبة-والمالية/مدقق-حسابات', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/ژمێریاری-و-دارایی/وردبینەری-هەژمارەکان', '3.1.4.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('محلل مالي', 'شیکەرەوەی دارایی', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/المحاسبة-والمالية/محلل-مالي', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/ژمێریاری-و-دارایی/شیکەرەوەی-دارایی', '3.1.4.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مدير مالي', 'بەڕێوەبەری دارایی', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/المحاسبة-والمالية/مدير-مالي', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/ژمێریاری-و-دارایی/بەڕێوەبەری-دارایی', '3.1.4.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الطب والصيدلة والتمريض', 'پزیشکی و دەرمانسازی و پەرستاری', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الطب-والصيدلة-والتمريض', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/پزیشکی-و-دەرمانسازی-و-پەرستاری', '3.1.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('طبيب عام', 'پزیشکی گشتی', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الطب-والصيدلة-والتمريض/طبيب-عام', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/پزیشکی-و-دەرمانسازی-و-پەرستاری/پزیشکی-گشتی', '3.1.5.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('طبيب اسنان', 'پزیشکی ددان', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الطب-والصيدلة-والتمريض/طبيب-اسنان', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/پزیشکی-و-دەرمانسازی-و-پەرستاری/پزیشکی-ددان', '3.1.5.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('صيدلاني', 'دەرمانساز', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الطب-والصيدلة-والتمريض/صيدلاني', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/پزیشکی-و-دەرمانسازی-و-پەرستاری/دەرمانساز', '3.1.5.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ممرض او ممرضة', 'پەرستار (نێر یان مێ)', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الطب-والصيدلة-والتمريض/ممرض-او-ممرضة', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/پزیشکی-و-دەرمانسازی-و-پەرستاری/پەرستار', '3.1.5.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('التعليم والتدريس والبحث العلمي', 'فێرکردن و وانەوتنەوە و توێژینەوەی زانستی', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/التعليم-والتدريس-والبحث-العلمي', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/فێرکردن-و-وانەوتنەوە-و-توێژینەوەی-زانستی', '3.1.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مدرس او معلم', 'مامۆستا', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/التعليم-والتدريس-والبحث-العلمي/مدرس-او-معلم', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/فێرکردن-و-وانەوتنەوە-و-توێژینەوەی-زانستی/مامۆستا', '3.1.6.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('باحث علمي', 'توێژەری زانستی', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/التعليم-والتدريس-والبحث-العلمي/باحث-علمي', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/فێرکردن-و-وانەوتنەوە-و-توێژینەوەی-زانستی/توێژەری-زانستی', '3.1.6.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('فني مختبرات علمية', 'تەکنیکاری تاقیگەی زانستی', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/التعليم-والتدريس-والبحث-العلمي/فني-مختبرات-علمية', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/فێرکردن-و-وانەوتنەوە-و-توێژینەوەی-زانستی/تەکنیکاری-تاقیگەی-زانستی', '3.1.6.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مدرب مهني وحرفي', 'ڕاهێنەری پیشەیی و دەستی', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/التعليم-والتدريس-والبحث-العلمي/مدرب-مهني-وحرفي', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/فێرکردن-و-وانەوتنەوە-و-توێژینەوەی-زانستی/ڕاهێنەری-پیشەیی-و-دەستی', '3.1.6.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الخدمات العامة والتشغيل والصيانة', 'خزمەتگوزاری گشتی و کارپێکردن و چاککردنەوە', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الخدمات-العامة-والتشغيل-والصيانة', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/خزمەتگوزاری-گشتی-و-کارپێکردن-و-چاککردنەوە', '3.1.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عمال صيانة (فيترچي، حداد، نجار)', 'کرێکاری چاککردنەوە (فیتەر، ئاسنگەر، دارتاش)', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الخدمات-العامة-والتشغيل-والصيانة/عمال-صيانة', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/خزمەتگوزاری-گشتی-و-کارپێکردن-و-چاککردنەوە/کرێکاری-چاککردنەوە', '3.1.7.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مشرف عمليات', 'سەرپەرشتیاری کارەکان', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الخدمات-العامة-والتشغيل-والصيانة/مشرف-عمليات', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/خزمەتگوزاری-گشتی-و-کارپێکردن-و-چاککردنەوە/سەرپەرشتیاری-کارەکان', '3.1.7.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('موظف خدمات عامة', 'فەرمانبەری خزمەتگوزاری گشتی', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الخدمات-العامة-والتشغيل-والصيانة/موظف-خدمات-عامة', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/خزمەتگوزاری-گشتی-و-کارپێکردن-و-چاککردنەوە/فەرمانبەری-خزمەتگوزاری-گشتی', '3.1.7.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مشغل معدات ثقيلة', 'کارپێکەری ئامێری قورس', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الخدمات-العامة-والتشغيل-والصيانة/مشغل-معدات-ثقيلة', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/خزمەتگوزاری-گشتی-و-کارپێکردن-و-چاککردنەوە/کارپێکەری-ئامێری-قورس', '3.1.7.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('المبيعات والتسويق والدعاية', 'فرۆشتن و بازاڕگەری و ڕیکلام', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/المبيعات-والتسويق-والدعاية', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/فرۆشتن-و-بازاڕگەری-و-ڕیکلام', '3.1.8', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مندوب مبيعات وتسويق', 'نوێنەری فرۆشتن و بازاڕگەری', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/المبيعات-والتسويق-والدعاية/مندوب-مبيعات-وتسويق', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/فرۆشتن-و-بازاڕگەری-و-ڕیکلام/نوێنەری-فرۆشتن-و-بازاڕگەری', '3.1.8.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مدير مبيعات', 'بەڕێوەبەری فرۆشتن', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/المبيعات-والتسويق-والدعاية/مدير-مبيعات', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/فرۆشتن-و-بازاڕگەری-و-ڕیکلام/بەڕێوەبەری-فرۆشتن', '3.1.8.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اخصائي تسويق الكتروني', 'پسپۆڕی بازاڕگەری ئەلیکترۆنی', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/المبيعات-والتسويق-والدعاية/اخصائي-تسويق-الكتروني', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/فرۆشتن-و-بازاڕگەری-و-ڕیکلام/پسپۆڕی-بازاڕگەری-ئەلیکترۆنی', '3.1.8.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اخصائي علاقات عامة', 'پسپۆڕی پەیوەندییە گشتییەکان', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/المبيعات-والتسويق-والدعاية/اخصائي-علاقات-عامة', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/فرۆشتن-و-بازاڕگەری-و-ڕیکلام/پسپۆڕی-پەیوەندییە-گشتییەکان', '3.1.8.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('النقل والمواصلات والخدمات اللوجستية', 'گواستنەوە و گەیاندن و خزمەتگوزاری لۆجستی', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/النقل-والمواصلات-والخدمات-اللوجستية', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/گواستنەوە-و-گەیاندن-و-خزمەتگوزاری-لۆجستی', '3.1.9', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('سائق شاحنة او تريلة', 'شۆفێری بارهەڵگر یان ترێلە', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/النقل-والمواصلات-والخدمات-اللوجستية/سائق-شاحنة-او-تريلة', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/گواستنەوە-و-گەیاندن-و-خزمەتگوزاری-لۆجستی/شۆفێری-بارهەڵگر-یان-ترێلە', '3.1.9.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مشرف لوجستي (نقل وتخزين)', 'سەرپەرشتیاری لۆجستی (گواستنەوە و کۆگاکردن)', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/النقل-والمواصلات-والخدمات-اللوجستية/مشرف-لوجستي', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/گواستنەوە-و-گەیاندن-و-خزمەتگوزاری-لۆجستی/سەرپەرشتیاری-لۆجستی', '3.1.9.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('موظف مخازن (امين مخزن)', 'فەرمانبەری کۆگا (ئەمینی کۆگا)', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/النقل-والمواصلات-والخدمات-اللوجستية/موظف-مخازن', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/گواستنەوە-و-گەیاندن-و-خزمەتگوزاری-لۆجستی/فەرمانبەری-کۆگا', '3.1.9.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('منسق شحن وتوصيل', 'هەماهەنگکاری بارکردن و گەیاندن', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/النقل-والمواصلات-والخدمات-اللوجستية/منسق-شحن-وتوصيل', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/گواستنەوە-و-گەیاندن-و-خزمەتگوزاری-لۆجستی/هەماهەنگکاری-بارکردن-و-گەیاندن', '3.1.9.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الضيافة والفندقة والسياحة', 'میوانداری و هۆتێلداری و گەشتوگوزار', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الضيافة-والفندقة-والسياحة', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/میوانداری-و-هۆتێلداری-و-گەشتوگوزار', '3.1.10', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('موظف استقبال فندقي', 'فەرمانبەری پێشوازی هۆتێل', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الضيافة-والفندقة-والسياحة/موظف-استقبال-فندقي', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/میوانداری-و-هۆتێلداری-و-گەشتوگوزار/فەرمانبەری-پێشوازی-هۆتێل', '3.1.10.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('شيف او طباخ', 'شێف یان چێشتلێنەر', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الضيافة-والفندقة-والسياحة/شيف-او-طباخ', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/میوانداری-و-هۆتێلداری-و-گەشتوگوزار/شێف-یان-چێشتلێنەر', '3.1.10.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('نادل (ويتر)', 'گارسۆن (وەیتەر)', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الضيافة-والفندقة-والسياحة/نادل', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/میوانداری-و-هۆتێلداری-و-گەشتوگوزار/گارسۆن', '3.1.10.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('منظم فعاليات ومناسبات', 'ڕێکخەری چالاکی و بۆنەکان', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الضيافة-والفندقة-والسياحة/منظم-فعاليات-ومناسبات', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/میوانداری-و-هۆتێلداری-و-گەشتوگوزار/ڕێکخەری-چالاکی-و-بۆنەکان', '3.1.10.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الفنون والتصميم والترفيه', 'هونەر و دیزاین و کات بەسەربردن', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الفنون-والتصميم-والترفيه', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/هونەر-و-دیزاین-و-کات-بەسەربردن', '3.1.11', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ممثل او فنان', 'ئەکتەر یان هونەرمەند', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الفنون-والتصميم-والترفيه/ممثل-او-فنان', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/هونەر-و-دیزاین-و-کات-بەسەربردن/ئەکتەر-یان-هونەرمەند', '3.1.11.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.11'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مصور فوتوغرافي وفيديو', 'وێنەگری فۆتۆگرافی و ڤیدیۆ', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الفنون-والتصميم-والترفيه/مصور-فوتوغرافي-وفيديو', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/هونەر-و-دیزاین-و-کات-بەسەربردن/وێنەگری-فۆتۆگرافی-و-ڤیدیۆ', '3.1.11.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.11'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مصمم جرافيك', 'دیزاینەری گرافیک', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الفنون-والتصميم-والترفيه/مصمم-جرافيك', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/هونەر-و-دیزاین-و-کات-بەسەربردن/دیزاینەری-گرافیک', '3.1.11.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.11'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('منتج ومونتير فيديو', 'بەرهەمهێنەر و مۆنتێری ڤیدیۆ', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الفنون-والتصميم-والترفيه/منتج-ومونتير-فيديو', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/هونەر-و-دیزاین-و-کات-بەسەربردن/بەرهەمهێنەر-و-مۆنتێری-ڤیدیۆ', '3.1.11.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.11'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الامن والحماية والسلامة', 'ئاسایش و پاراستن و سەلامەتی', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الامن-والحماية-والسلامة', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/ئاسایش-و-پاراستن-و-سەلامەتی', '3.1.12', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('حارس امن', 'پاسەوانی ئاسایش', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الامن-والحماية-والسلامة/حارس-امن', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/ئاسایش-و-پاراستن-و-سەلامەتی/پاسەوانی-ئاسایش', '3.1.12.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.12'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مشرف امن', 'سەرپەرشتیاری ئاسایش', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الامن-والحماية-والسلامة/مشرف-امن', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/ئاسایش-و-پاراستن-و-سەلامەتی/سەرپەرشتیاری-ئاسایش', '3.1.12.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.12'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مسؤول سلامة مهنية', 'بەرپرسی سەلامەتی پیشەیی', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الامن-والحماية-والسلامة/مسؤول-سلامة-مهنية', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/ئاسایش-و-پاراستن-و-سەلامەتی/بەرپرسی-سەلامەتی-پیشەیی', '3.1.12.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.12'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مشغل كاميرات مراقبة', 'کارپێکەری کامێرای چاودێری', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/الامن-والحماية-والسلامة/مشغل-كاميرات-مراقبة', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/ئاسایش-و-پاراستن-و-سەلامەتی/کارپێکەری-کامێرای-چاودێری', '3.1.12.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.12'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('العمالة المنزلية والخدم', 'کاری ماڵەوە و خزمەتکار', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/العمالة-المنزلية-والخدم', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/کاری-ماڵەوە-و-خزمەتکار', '3.1.13', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عاملة تنظيف منزل', 'کرێکاری پاککردنەوەی ماڵ (ژن)', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/العمالة-المنزلية-والخدم/عاملة-تنظيف-منزل', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/کاری-ماڵەوە-و-خزمەتکار/کرێکاری-پاککردنەوەی-ماڵ', '3.1.13.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.13'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('طباخ منزلي', 'چێشتلێنەری ماڵ', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/العمالة-المنزلية-والخدم/طباخ-منزلي', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/کاری-ماڵەوە-و-خزمەتکار/چێشتلێنەری-ماڵ', '3.1.13.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.13'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('سائق خاص', 'شۆفێری تایبەت', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/العمالة-المنزلية-والخدم/سائق-خاص', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/کاری-ماڵەوە-و-خزمەتکار/شۆفێری-تایبەت', '3.1.13.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.13'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مربية اطفال', 'دایەنی منداڵ', 'الوظائف-وفرص-العمل/ابحث-عن-عمل/العمالة-المنزلية-والخدم/مربية-اطفال', 'کار-و-هەلی-کار/گەڕان-بەدوای-کار/کاری-ماڵەوە-و-خزمەتکار/دایەنی-منداڵ', '3.1.13.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.1.13'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ابحث عن موظف (عروض عمل)', 'گەڕان بەدوای فەرمانبەر (پێشنیاری کار)', 'الوظائف-وفرص-العمل/ابحث-عن-موظف', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر', '3.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('البناء والتشييد والانشاءات', 'بیناسازی و ئاوەدانکردنەوە', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/البناء-والتشييد-والانشاءات', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/بیناسازی-و-ئاوەدانکردنەوە', '3.2.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عامل بناء (خلفة بناء)', 'کرێکاری بیناسازی (وەستای بینا)', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/البناء-والتشييد-والانشاءات/عامل-بناء', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/بیناسازی-و-ئاوەدانکردنەوە/کرێکاری-بیناسازی', '3.2.1.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مهندس معماري', 'ئەندازیاری تەلارسازی', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/البناء-والتشييد-والانشاءات/مهندس-معماري', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/بیناسازی-و-ئاوەدانکردنەوە/ئەندازیاری-تەلارسازی', '3.2.1.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مهندس مدني', 'ئەندازیاری شارستانی', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/البناء-والتشييد-والانشاءات/مهندس-مدني', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/بیناسازی-و-ئاوەدانکردنەوە/ئەندازیاری-شارستانی', '3.2.1.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('فني صحيات وكهرباء (سباك، كهربائي)', 'تەکنیکاری ئاوەڕۆ و کارەبا (سەباخ، کارەباچی)', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/البناء-والتشييد-والانشاءات/فني-صحيات-وكهرباء', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/بیناسازی-و-ئاوەدانکردنەوە/تەکنیکاری-ئاوەڕۆ-و-کارەبا', '3.2.1.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تكنولوجيا المعلومات والاتصالات (IT)', 'تەکنەلۆژیای زانیاری و گەیاندن (IT)', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/تكنولوجيا-المعلومات-والاتصالات', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/تەکنەلۆژیای-زانیاری-و-گەیاندن', '3.2.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تطوير برامج وتطبيقات (مبرمج)', 'پەرەپێدانی پرۆگرام و ئەپلیکەیشن (پرۆگرامساز)', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/تكنولوجيا-المعلومات-والاتصالات/تطوير-برامج-وتطبيقات', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/تەکنەلۆژیای-زانیاری-و-گەیاندن/پەرەپێدانی-پرۆگرام-و-ئەپلیکەیشن', '3.2.2.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادارة شبكات كومبيوتر', 'بەڕێوەبردنی تۆڕەکانی کۆمپیوتەر', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/تكنولوجيا-المعلومات-والاتصالات/ادارة-شبكات-كومبيوتر', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/تەکنەلۆژیای-زانیاری-و-گەیاندن/بەڕێوەبردنی-تۆڕەکانی-کۆمپیوتەر', '3.2.2.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('دعم فني (IT Support)', 'پشتیوانی تەکنیکی (IT Support)', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/تكنولوجيا-المعلومات-والاتصالات/دعم-فني', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/تەکنەلۆژیای-زانیاری-و-گەیاندن/پشتیوانی-تەکنیکی', '3.2.2.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('امن معلومات (Cybersecurity)', 'ئاسایشی زانیاری (Cybersecurity)', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/تكنولوجيا-المعلومات-والاتصالات/امن-معلومات', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/تەکنەلۆژیای-زانیاری-و-گەیاندن/ئاسایشی-زانیاری', '3.2.2.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.2'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تحليل بيانات', 'شیکردنەوەی داتا', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/تكنولوجيا-المعلومات-والاتصالات/تحليل-بيانات', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/تەکنەلۆژیای-زانیاری-و-گەیاندن/شیکردنەوەی-داتا', '3.2.2.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('وظائف ادارية ومكتبية', 'کاری کارگێڕی و نووسینگە', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/وظائف-ادارية-ومكتبية', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/کاری-کارگێڕی-و-نووسینگە', '3.2.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مساعد اداري', 'یاریدەدەری کارگێڕی', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/وظائف-ادارية-ومكتبية/مساعد-اداري', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/کاری-کارگێڕی-و-نووسینگە/یاریدەدەری-کارگێڕی', '3.2.3.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مدير مكتب', 'بەڕێوەبەری نووسینگە', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/وظائف-ادارية-ومكتبية/مدير-مكتب', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/کاری-کارگێڕی-و-نووسینگە/بەڕێوەبەری-نووسینگە', '3.2.3.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('موظف استقبال', 'فەرمانبەری پێشوازی', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/وظائف-ادارية-ومكتبية/موظف-استقبال', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/کاری-کارگێڕی-و-نووسینگە/فەرمانبەری-پێشوازی', '3.2.3.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('سكرتارية تنفيذية', 'سکرتاریەتی جێبەجێکار', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/وظائف-ادارية-ومكتبية/سكرتارية-تنفيذية', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/کاری-کارگێڕی-و-نووسینگە/سکرتاریەتی-جێبەجێکار', '3.2.3.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('المحاسبة والمالية', 'ژمێریاری و دارایی', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/المحاسبة-والمالية', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/ژمێریاری-و-دارایی', '3.2.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('محاسب', 'ژمێریار', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/المحاسبة-والمالية/محاسب', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/ژمێریاری-و-دارایی/ژمێریار', '3.2.4.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مدقق حسابات', 'وردبینەری هەژمارەکان', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/المحاسبة-والمالية/مدقق-حسابات', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/ژمێریاری-و-دارایی/وردبینەری-هەژمارەکان', '3.2.4.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('محلل مالي', 'شیکەرەوەی دارایی', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/المحاسبة-والمالية/محلل-مالي', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/ژمێریاری-و-دارایی/شیکەرەوەی-دارایی', '3.2.4.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.4'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مدير مالي', 'بەڕێوەبەری دارایی', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/المحاسبة-والمالية/مدير-مالي', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/ژمێریاری-و-دارایی/بەڕێوەبەری-دارایی', '3.2.4.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الطب والصيدلة والتمريض', 'پزیشکی و دەرمانسازی و پەرستاری', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الطب-والصيدلة-والتمريض', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/پزیشکی-و-دەرمانسازی-و-پەرستاری', '3.2.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('طبيب عام', 'پزیشکی گشتی', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الطب-والصيدلة-والتمريض/طبيب-عام', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/پزیشکی-و-دەرمانسازی-و-پەرستاری/پزیشکی-گشتی', '3.2.5.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('طبيب اسنان', 'پزیشکی ددان', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الطب-والصيدلة-والتمريض/طبيب-اسنان', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/پزیشکی-و-دەرمانسازی-و-پەرستاری/پزیشکی-ددان', '3.2.5.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('صيدلاني', 'دەرمانساز', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الطب-والصيدلة-والتمريض/صيدلاني', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/پزیشکی-و-دەرمانسازی-و-پەرستاری/دەرمانساز', '3.2.5.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ممرض او ممرضة', 'پەرستار (نێر یان مێ)', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الطب-والصيدلة-والتمريض/ممرض-او-ممرضة', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/پزیشکی-و-دەرمانسازی-و-پەرستاری/پەرستار', '3.2.5.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('التعليم والتدريس والبحث العلمي', 'فێرکردن و وانەوتنەوە و توێژینەوەی زانستی', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/التعليم-والتدريس-والبحث-العلمي', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/فێرکردن-و-وانەوتنەوە-و-توێژینەوەی-زانستی', '3.2.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مدرس او معلم', 'مامۆستا', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/التعليم-والتدريس-والبحث-العلمي/مدرس-او-معلم', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/فێرکردن-و-وانەوتنەوە-و-توێژینەوەی-زانستی/مامۆستا', '3.2.6.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('باحث علمي', 'توێژەری زانستی', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/التعليم-والتدريس-والبحث-العلمي/باحث-علمي', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/فێرکردن-و-وانەوتنەوە-و-توێژینەوەی-زانستی/توێژەری-زانستی', '3.2.6.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('فني مختبرات علمية', 'تەکنیکاری تاقیگەی زانستی', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/التعليم-والتدريس-والبحث-العلمي/فني-مختبرات-علمية', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/فێرکردن-و-وانەوتنەوە-و-توێژینەوەی-زانستی/تەکنیکاری-تاقیگەی-زانستی', '3.2.6.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.6'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مدرب مهني وحرفي', 'ڕاهێنەری پیشەیی و دەستی', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/التعليم-والتدريس-والبحث-العلمي/مدرب-مهني-وحرفي', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/فێرکردن-و-وانەوتنەوە-و-توێژینەوەی-زانستی/ڕاهێنەری-پیشەیی-و-دەستی', '3.2.6.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الخدمات العامة والتشغيل والصيانة', 'خزمەتگوزاری گشتی و کارپێکردن و چاککردنەوە', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الخدمات-العامة-والتشغيل-والصيانة', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/خزمەتگوزاری-گشتی-و-کارپێکردن-و-چاککردنەوە', '3.2.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عمال صيانة (فيترچي، حداد، نجار)', 'کرێکاری چاککردنەوە (فیتەر، ئاسنگەر، دارتاش)', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الخدمات-العامة-والتشغيل-والصيانة/عمال-صيانة', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/خزمەتگوزاری-گشتی-و-کارپێکردن-و-چاککردنەوە/کرێکاری-چاککردنەوە', '3.2.7.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مشرف عمليات', 'سەرپەرشتیاری کارەکان', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الخدمات-العامة-والتشغيل-والصيانة/مشرف-عمليات', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/خزمەتگوزاری-گشتی-و-کارپێکردن-و-چاککردنەوە/سەرپەرشتیاری-کارەکان', '3.2.7.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('موظف خدمات عامة', 'فەرمانبەری خزمەتگوزاری گشتی', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الخدمات-العامة-والتشغيل-والصيانة/موظف-خدمات-عامة', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/خزمەتگوزاری-گشتی-و-کارپێکردن-و-چاککردنەوە/فەرمانبەری-خزمەتگوزاری-گشتی', '3.2.7.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مشغل معدات ثقيلة', 'کارپێکەری ئامێری قورس', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الخدمات-العامة-والتشغيل-والصيانة/مشغل-معدات-ثقيلة', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/خزمەتگوزاری-گشتی-و-کارپێکردن-و-چاککردنەوە/کارپێکەری-ئامێری-قورس', '3.2.7.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('المبيعات والتسويق والدعاية', 'فرۆشتن و بازاڕگەری و ڕیکلام', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/المبيعات-والتسويق-والدعاية', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/فرۆشتن-و-بازاڕگەری-و-ڕیکلام', '3.2.8', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مندوب مبيعات وتسويق', 'نوێنەری فرۆشتن و بازاڕگەری', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/المبيعات-والتسويق-والدعاية/مندوب-مبيعات-وتسويق', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/فرۆشتن-و-بازاڕگەری-و-ڕیکلام/نوێنەری-فرۆشتن-و-بازاڕگەری', '3.2.8.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مدير مبيعات', 'بەڕێوەبەری فرۆشتن', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/المبيعات-والتسويق-والدعاية/مدير-مبيعات', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/فرۆشتن-و-بازاڕگەری-و-ڕیکلام/بەڕێوەبەری-فرۆشتن', '3.2.8.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اخصائي تسويق الكتروني', 'پسپۆڕی بازاڕگەری ئەلیکترۆنی', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/المبيعات-والتسويق-والدعاية/اخصائي-تسويق-الكتروني', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/فرۆشتن-و-بازاڕگەری-و-ڕیکلام/پسپۆڕی-بازاڕگەری-ئەلیکترۆنی', '3.2.8.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.8'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اخصائي علاقات عامة', 'پسپۆڕی پەیوەندییە گشتییەکان', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/المبيعات-والتسويق-والدعاية/اخصائي-علاقات-عامة', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/فرۆشتن-و-بازاڕگەری-و-ڕیکلام/پسپۆڕی-پەیوەندییە-گشتییەکان', '3.2.8.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('النقل والمواصلات والخدمات اللوجستية', 'گواستنەوە و گەیاندن و خزمەتگوزاری لۆجستی', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/النقل-والمواصلات-والخدمات-اللوجستية', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/گواستنەوە-و-گەیاندن-و-خزمەتگوزاری-لۆجستی', '3.2.9', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('سائق شاحنة او تريلة', 'شۆفێری بارهەڵگر یان ترێلە', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/النقل-والمواصلات-والخدمات-اللوجستية/سائق-شاحنة-او-تريلة', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/گواستنەوە-و-گەیاندن-و-خزمەتگوزاری-لۆجستی/شۆفێری-بارهەڵگر-یان-ترێلە', '3.2.9.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مشرف لوجستي (نقل وتخزين)', 'سەرپەرشتیاری لۆجستی (گواستنەوە و کۆگاکردن)', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/النقل-والمواصلات-والخدمات-اللوجستية/مشرف-لوجستي', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/گواستنەوە-و-گەیاندن-و-خزمەتگوزاری-لۆجستی/سەرپەرشتیاری-لۆجستی', '3.2.9.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('موظف مخازن (امين مخزن)', 'فەرمانبەری کۆگا (ئەمینی کۆگا)', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/النقل-والمواصلات-والخدمات-اللوجستية/موظف-مخازن', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/گواستنەوە-و-گەیاندن-و-خزمەتگوزاری-لۆجستی/فەرمانبەری-کۆگا', '3.2.9.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('منسق شحن وتوصيل', 'هەماهەنگکاری بارکردن و گەیاندن', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/النقل-والمواصلات-والخدمات-اللوجستية/منسق-شحن-وتوصيل', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/گواستنەوە-و-گەیاندن-و-خزمەتگوزاری-لۆجستی/هەماهەنگکاری-بارکردن-و-گەیاندن', '3.2.9.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الضيافة والفندقة والسياحة', 'میوانداری و هۆتێلداری و گەشتوگوزار', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الضيافة-والفندقة-والسياحة', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/میوانداری-و-هۆتێلداری-و-گەشتوگوزار', '3.2.10', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('موظف استقبال فندقي', 'فەرمانبەری پێشوازی هۆتێل', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الضيافة-والفندقة-والسياحة/موظف-استقبال-فندقي', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/میوانداری-و-هۆتێلداری-و-گەشتوگوزار/فەرمانبەری-پێشوازی-هۆتێل', '3.2.10.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('شيف او طباخ', 'شێف یان چێشتلێنەر', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الضيافة-والفندقة-والسياحة/شيف-او-طباخ', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/میوانداری-و-هۆتێلداری-و-گەشتوگوزار/شێف-یان-چێشتلێنەر', '3.2.10.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('نادل (ويتر)', 'گارسۆن (وەیتەر)', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الضيافة-والفندقة-والسياحة/نادل', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/میوانداری-و-هۆتێلداری-و-گەشتوگوزار/گارسۆن', '3.2.10.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.10'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('منظم فعاليات ومناسبات', 'ڕێکخەری چالاکی و بۆنەکان', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الضيافة-والفندقة-والسياحة/منظم-فعاليات-ومناسبات', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/میوانداری-و-هۆتێلداری-و-گەشتوگوزار/ڕێکخەری-چالاکی-و-بۆنەکان', '3.2.10.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الفنون والتصميم والترفيه', 'هونەر و دیزاین و کات بەسەربردن', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الفنون-والتصميم-والترفيه', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/هونەر-و-دیزاین-و-کات-بەسەربردن', '3.2.11', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ممثل او فنان', 'ئەکتەر یان هونەرمەند', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الفنون-والتصميم-والترفيه/ممثل-او-فنان', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/هونەر-و-دیزاین-و-کات-بەسەربردن/ئەکتەر-یان-هونەرمەند', '3.2.11.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.11'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مصور فوتوغرافي وفيديو', 'وێنەگری فۆتۆگرافی و ڤیدیۆ', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الفنون-والتصميم-والترفيه/مصور-فوتوغرافي-وفيديو', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/هونەر-و-دیزاین-و-کات-بەسەربردن/وێنەگری-فۆتۆگرافی-و-ڤیدیۆ', '3.2.11.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.11'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مصمم جرافيك', 'دیزاینەری گرافیک', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الفنون-والتصميم-والترفيه/مصمم-جرافيك', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/هونەر-و-دیزاین-و-کات-بەسەربردن/دیزاینەری-گرافیک', '3.2.11.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.11'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('منتج ومونتير فيديو', 'بەرهەمهێنەر و مۆنتێری ڤیدیۆ', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الفنون-والتصميم-والترفيه/منتج-ومونتير-فيديو', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/هونەر-و-دیزاین-و-کات-بەسەربردن/بەرهەمهێنەر-و-مۆنتێری-ڤیدیۆ', '3.2.11.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.11'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الامن والحماية والسلامة', 'ئاسایش و پاراستن و سەلامەتی', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الامن-والحماية-والسلامة', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/ئاسایش-و-پاراستن-و-سەلامەتی', '3.2.12', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('حارس امن', 'پاسەوانی ئاسایش', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الامن-والحماية-والسلامة/حارس-امن', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/ئاسایش-و-پاراستن-و-سەلامەتی/پاسەوانی-ئاسایش', '3.2.12.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.12'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مشرف امن', 'سەرپەرشتیاری ئاسایش', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الامن-والحماية-والسلامة/مشرف-امن', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/ئاسایش-و-پاراستن-و-سەلامەتی/سەرپەرشتیاری-ئاسایش', '3.2.12.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.12'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مسؤول سلامة مهنية', 'بەرپرسی سەلامەتی پیشەیی', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الامن-والحماية-والسلامة/مسؤول-سلامة-مهنية', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/ئاسایش-و-پاراستن-و-سەلامەتی/بەرپرسی-سەلامەتی-پیشەیی', '3.2.12.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.12'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مشغل كاميرات مراقبة', 'کارپێکەری کامێرای چاودێری', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/الامن-والحماية-والسلامة/مشغل-كاميرات-مراقبة', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/ئاسایش-و-پاراستن-و-سەلامەتی/کارپێکەری-کامێرای-چاودێری', '3.2.12.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.12'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('العمالة المنزلية والخدم', 'کاری ماڵەوە و خزمەتکار', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/العمالة-المنزلية-والخدم', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/کاری-ماڵەوە-و-خزمەتکار', '3.2.13', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عاملة تنظيف منزل', 'کرێکاری پاککردنەوەی ماڵ (ژن)', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/العمالة-المنزلية-والخدم/عاملة-تنظيف-منزل', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/کاری-ماڵەوە-و-خزمەتکار/کرێکاری-پاککردنەوەی-ماڵ', '3.2.13.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.13'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('طباخ منزلي', 'چێشتلێنەری ماڵ', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/العمالة-المنزلية-والخدم/طباخ-منزلي', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/کاری-ماڵەوە-و-خزمەتکار/چێشتلێنەری-ماڵ', '3.2.13.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.13'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('سائق خاص (سايق بيت)', 'شۆفێری تایبەت (شۆفێری ماڵ)', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/العمالة-المنزلية-والخدم/سائق-خاص', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/کاری-ماڵەوە-و-خزمەتکار/شۆفێری-تایبەت', '3.2.13.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.13'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مربية اطفال', 'دایەنی منداڵ', 'الوظائف-وفرص-العمل/ابحث-عن-موظف/العمالة-المنزلية-والخدم/مربية-اطفال', 'کار-و-هەلی-کار/گەڕان-بەدوای-فەرمانبەر/کاری-ماڵەوە-و-خزمەتکار/دایەنی-منداڵ', '3.2.13.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '3.2.13'));

-- End of Level 1 Category: 3

-- Level 1 Category: 4 - الخدمات (خدمات عامة ومتخصصة)

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الخدمات (خدمات عامة ومتخصصة)', 'خزمەتگوزارییەکان (خزمەتگوزاری گشتی و تایبەتمەند)', 'الخدمات', 'خزمەتگوزارییەکان', '4', NULL);
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات المركبات (ورش تصليح، ايجار، غسيل)', 'خزمەتگوزاری ئۆتۆمبێل (وەرشەی چاککردنەوە، بەکرێدان، شوشتن)', 'الخدمات/خدمات-المركبات', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئۆتۆمبێل', '4.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تصليح وصيانة السيارات (فيترچي سيارات)', 'چاککردنەوە و سیانەی ئۆتۆمبێل (فیتەری سەیارە)', 'الخدمات/خدمات-المركبات/تصليح-وصيانة-السيارات', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئۆتۆمبێل/چاککردنەوە-و-سیانەی-ئۆتۆمبێل', '4.1.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ايجار سيارات', 'بەکرێدانی ئۆتۆمبێل', 'الخدمات/خدمات-المركبات/ايجار-سيارات', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئۆتۆمبێل/بەکرێدانی-ئۆتۆمبێل', '4.1.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.1'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تصليح وصيانة دراجات نارية (فيترچي دراجات)', 'چاککردنەوە و سیانەی ماتۆڕسکیل (فیتەری ماتۆڕ)', 'الخدمات/خدمات-المركبات/تصليح-وصيانة-دراجات-نارية', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئۆتۆمبێل/چاککردنەوە-و-سیانەی-ماتۆڕسکیل', '4.1.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ايجار دراجات نارية', 'بەکرێدانی ماتۆڕسکیل', 'الخدمات/خدمات-المركبات/ايجار-دراجات-نارية', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئۆتۆمبێل/بەکرێدانی-ماتۆڕسکیل', '4.1.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('غسيل وتنظيف وتلميع المركبات (بولش)', 'شوشتن و پاککردنەوە و پۆڵیشکردنی ئۆتۆمبێل', 'الخدمات/خدمات-المركبات/غسيل-وتنظيف-وتلميع-المركبات', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئۆتۆمبێل/شوشتن-و-پاککردنەوە-و-پۆڵیشکردنی-ئۆتۆمبێل', '4.1.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات تركيب وصيانة اكسسوارات المركبات', 'خزمەتگوزاری دانان و سیانەی ئێکسسواراتی ئۆتۆمبێل', 'الخدمات/خدمات-المركبات/خدمات-تركيب-وصيانة-اكسسوارات-المركبات', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئۆتۆمبێل/خزمەتگوزاری-دانان-و-سیانەی-ئێکسسواراتی-ئۆتۆمبێل', '4.1.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('محطات وقود متنقلة (خدمة توصيل بنزين)', 'وێستگەی سووتەمەنی گەڕۆک (خزمەتگوزاری گەیاندنی بەنزین)', 'الخدمات/خدمات-المركبات/محطات-وقود-متنقلة', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئۆتۆمبێل/وێستگەی-سووتەمەنی-گەڕۆک', '4.1.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات فحص وتقييم المركبات المستعملة', 'خزمەتگوزاری پشکنین و هەڵسەنگاندنی ئۆتۆمبێلی بەکارهاتوو', 'الخدمات/خدمات-المركبات/خدمات-فحص-وتقييم-المركبات-المستعملة', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئۆتۆمبێل/خزمەتگوزاری-پشکنین-و-هەڵسەنگاندنی-ئۆتۆمبێلی-بەکارهاتوو', '4.1.8', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات مرورية (تخليص معاملات، تسجيل)', 'خزمەتگوزاری هاتووچۆ (ڕاییکردنی مامەڵە، تۆمارکردن)', 'الخدمات/خدمات-المركبات/خدمات-مرورية', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئۆتۆمبێل/خزمەتگوزاری-هاتووچۆ', '4.1.9', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات مركبات اخرى', 'خزمەتگوزاری تری ئۆتۆمبێل', 'الخدمات/خدمات-المركبات/خدمات-مركبات-اخرى', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئۆتۆمبێل/خزمەتگوزاری-تری-ئۆتۆمبێل', '4.1.10', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات البناء والمقاولات والمعدات الثقيلة', 'خزمەتگوزاری بیناسازی و بەڵێندەرایەتی و ئامێری قورس', 'الخدمات/خدمات-البناء-والمقاولات-والمعدات-الثقيلة', 'خزمەتگوزارییەکان/خزمەتگوزاری-بیناسازی-و-بەڵێندەرایەتی-و-ئامێری-قورس', '4.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مقاولات بناء وترميم', 'بەڵێندەرایەتی بیناسازی و نۆژەنکردنەوە', 'الخدمات/خدمات-البناء-والمقاولات-والمعدات-الثقيلة/مقاولات-بناء-وترميم', 'خزمەتگوزارییەکان/خزمەتگوزاری-بیناسازی-و-بەڵێندەرایەتی-و-ئامێری-قورس/بەڵێندەرایەتی-بیناسازی-و-نۆژەنکردنەوە', '4.2.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.2'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تاجير معدات ثقيلة (كرينات، حفارات، شفلات)', 'بەکرێدانی ئامێری قورس (کڕێن، حەفارە، شۆفڵ)', 'الخدمات/خدمات-البناء-والمقاولات-والمعدات-الثقيلة/تاجير-معدات-ثقيلة', 'خزمەتگوزارییەکان/خزمەتگوزاری-بیناسازی-و-بەڵێندەرایەتی-و-ئامێری-قورس/بەکرێدانی-ئامێری-قورس', '4.2.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات صيانة واصلاح المعدات الثقيلة', 'خزمەتگوزاری سیانە و چاککردنەوەی ئامێری قورس', 'الخدمات/خدمات-البناء-والمقاولات-والمعدات-الثقيلة/خدمات-صيانة-واصلاح-المعدات-الثقيلة', 'خزمەتگوزارییەکان/خزمەتگوزاری-بیناسازی-و-بەڵێندەرایەتی-و-ئامێری-قورس/خزمەتگوزاری-سیانە-و-چاککردنەوەی-ئامێری-قورس', '4.2.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات بناء ومعدات اخرى', 'خزمەتگوزاری بیناسازی و ئامێری تر', 'الخدمات/خدمات-البناء-والمقاولات-والمعدات-الثقيلة/خدمات-بناء-ومعدات-اخرى', 'خزمەتگوزارییەکان/خزمەتگوزاری-بیناسازی-و-بەڵێندەرایەتی-و-ئامێری-قورس/خزمەتگوزاری-بیناسازی-و-ئامێری-تر', '4.2.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات نقل البضائع والشحن', 'خزمەتگوزاری گواستنەوەی کاڵا و بارکردن', 'الخدمات/خدمات-نقل-البضائع-والشحن', 'خزمەتگوزارییەکان/خزمەتگوزاری-گواستنەوەی-کاڵا-و-بارکردن', '4.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('نقل البضائع داخل المدن (نقل اثاث، بضائع خفيفة)', 'گواستنەوەی کاڵا لەناو شارەکان (گواستنەوەی کەلوپەل، کاڵای سووک)', 'الخدمات/خدمات-نقل-البضائع-والشحن/نقل-البضائع-داخل-المدن', 'خزمەتگوزارییەکان/خزمەتگوزاری-گواستنەوەی-کاڵا-و-بارکردن/گواستنەوەی-کاڵا-لەناو-شارەکان', '4.3.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('نقل البضائع بين المحافظات', 'گواستنەوەی کاڵا لەنێوان پارێزگاکان', 'الخدمات/خدمات-نقل-البضائع-والشحن/نقل-البضائع-بين-المحافظات', 'خزمەتگوزارییەکان/خزمەتگوزاری-گواستنەوەی-کاڵا-و-بارکردن/گواستنەوەی-کاڵا-لەنێوان-پارێزگاکان', '4.3.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('النقل الدولي للبضائع', 'گواستنەوەی نێودەوڵەتی کاڵا', 'الخدمات/خدمات-نقل-البضائع-والشحن/النقل-الدولي-للبضائع', 'خزمەتگوزارییەکان/خزمەتگوزاری-گواستنەوەی-کاڵا-و-بارکردن/گواستنەوەی-نێودەوڵەتی-کاڵا', '4.3.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات الشحن الثقيل والتخليص الكمركي', 'خزمەتگوزاری بارکردنی قورس و دەرکردنی گومرگی', 'الخدمات/خدمات-نقل-البضائع-والشحن/خدمات-الشحن-الثقيل-والتخليص-الكمركي', 'خزمەتگوزارییەکان/خزمەتگوزاری-گواستنەوەی-کاڵا-و-بارکردن/خزمەتگوزاری-بارکردنی-قورس-و-دەرکردنی-گومرگی', '4.3.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الخدمات اللوجستية والتخزين', 'خزمەتگوزاری لۆجستی و کۆگاکردن', 'الخدمات/الخدمات-اللوجستية-والتخزين', 'خزمەتگوزارییەکان/خزمەتگوزاری-لۆجستی-و-کۆگاکردن', '4.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادارة سلسلة التوريد', 'بەڕێوەبردنی زنجیرەی دابینکردن', 'الخدمات/الخدمات-اللوجستية-والتخزين/ادارة-سلسلة-التوريد', 'خزمەتگوزارییەکان/خزمەتگوزاری-لۆجستی-و-کۆگاکردن/بەڕێوەبردنی-زنجیرەی-دابینکردن', '4.4.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.4'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات تخزين في مستودعات', 'خزمەتگوزاری کۆگاکردن لە مەخزەنەکان', 'الخدمات/الخدمات-اللوجستية-والتخزين/خدمات-تخزين-في-مستودعات', 'خزمەتگوزارییەکان/خزمەتگوزاری-لۆجستی-و-کۆگاکردن/خزمەتگوزاری-کۆگاکردن-لە-مەخزەنەکان', '4.4.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عمال تحميل وتفريغ (حمالة)', 'کرێکاری بارکردن و داگرتن (حەماڵ)', 'الخدمات/الخدمات-اللوجستية-والتخزين/عمال-تحميل-وتفريغ', 'خزمەتگوزارییەکان/خزمەتگوزاری-لۆجستی-و-کۆگاکردن/کرێکاری-بارکردن-و-داگرتن', '4.4.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات تعبئة وتغليف ونقل', 'خزمەتگوزاری پاکەتکردن و پێچانەوە و گواستنەوە', 'الخدمات/الخدمات-اللوجستية-والتخزين/خدمات-تعبئة-وتغليف-ونقل', 'خزمەتگوزارییەکان/خزمەتگوزاری-لۆجستی-و-کۆگاکردن/خزمەتگوزاری-پاکەتکردن-و-پێچانەوە-و-گواستنەوە', '4.4.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادارة المخازن والمستودعات', 'بەڕێوەبردنی کۆگا و مەخزەنەکان', 'الخدمات/الخدمات-اللوجستية-والتخزين/ادارة-المخازن-والمستودعات', 'خزمەتگوزارییەکان/خزمەتگوزاری-لۆجستی-و-کۆگاکردن/بەڕێوەبردنی-کۆگا-و-مەخزەنەکان', '4.4.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات نقل الركاب والمواصلات', 'خزمەتگوزاری گواستنەوەی سەرنشین و گەیاندن', 'الخدمات/خدمات-نقل-الركاب-والمواصلات', 'خزمەتگوزارییەکان/خزمەتگوزاری-گواستنەوەی-سەرنشین-و-گەیاندن', '4.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات باصات وسفر بين المدن', 'خزمەتگوزاری پاس و گەشتکردن لەنێوان شارەکان', 'الخدمات/خدمات-نقل-الركاب-والمواصلات/خدمات-باصات-وسفر-بين-المدن', 'خزمەتگوزارییەکان/خزمەتگوزاری-گواستنەوەی-سەرنشین-و-گەیاندن/خزمەتگوزاری-پاس-و-گەشتکردن-لەنێوان-شارەکان', '4.5.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات نقل جماعي داخل المدن (خطوط، تكسي جماعي)', 'خزمەتگوزاری گواستنەوەی بەکۆمەڵ لەناو شارەکان (هێڵ، تەکسی بەکۆمەڵ)', 'الخدمات/خدمات-نقل-الركاب-والمواصلات/خدمات-نقل-جماعي-داخل-المدن', 'خزمەتگوزارییەکان/خزمەتگوزاری-گواستنەوەی-سەرنشین-و-گەیاندن/خزمەتگوزاری-گواستنەوەی-بەکۆمەڵ-لەناو-شارەکان', '4.5.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات نقل للزيارات الدينية والسياحية', 'خزمەتگوزاری گواستنەوە بۆ زیارەتی ئایینی و گەشتیاری', 'الخدمات/خدمات-نقل-الركاب-والمواصلات/خدمات-نقل-للزيارات-الدينية-والسياحية', 'خزمەتگوزارییەکان/خزمەتگوزاری-گواستنەوەی-سەرنشین-و-گەیاندن/خزمەتگوزاری-گواستنەوە-بۆ-زیارەتی-ئایینی-و-گەشتیاری', '4.5.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات نقل للمناسبات الخاصة', 'خزمەتگوزاری گواستنەوە بۆ بۆنە تایبەتەکان', 'الخدمات/خدمات-نقل-الركاب-والمواصلات/خدمات-نقل-للمناسبات-الخاصة', 'خزمەتگوزارییەکان/خزمەتگوزاری-گواستنەوەی-سەرنشین-و-گەیاندن/خزمەتگوزاری-گواستنەوە-بۆ-بۆنە-تایبەتەکان', '4.5.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات الاعمار والبناء والتشطيبات', 'خزمەتگوزاری ئاوەدانکردنەوە و بیناسازی و تەواوکاری', 'الخدمات/خدمات-الاعمار-والبناء-والتشطيبات', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئاوەدانکردنەوە-و-بیناسازی-و-تەواوکاری', '4.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('بناء وترميم المنازل والشقق (مقاولات بناء)', 'دروستکردن و نۆژەنکردنەوەی ماڵ و شوقە (بەڵێندەرایەتی بیناسازی)', 'الخدمات/خدمات-الاعمار-والبناء-والتشطيبات/بناء-وترميم-المنازل-والشقق', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئاوەدانکردنەوە-و-بیناسازی-و-تەواوکاری/دروستکردن-و-نۆژەنکردنەوەی-ماڵ-و-شوقە', '4.6.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات كهرباء وسباكة (تاسيس وصيانة)', 'خزمەتگوزاری کارەبا و ئاوەڕۆ (دانان و چاککردنەوە)', 'الخدمات/خدمات-الاعمار-والبناء-والتشطيبات/خدمات-كهرباء-وسباكة', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئاوەدانکردنەوە-و-بیناسازی-و-تەواوکاری/خزمەتگوزاری-کارەبا-و-ئاوەڕۆ', '4.6.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تركيب وصيانة انظمة تبريد وتكييف', 'دانان و سیانەی سیستەمی فێنککەرەوە و هەواگۆڕکێ', 'الخدمات/خدمات-الاعمار-والبناء-والتشطيبات/تركيب-وصيانة-انظمة-تبريد-وتكييف', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئاوەدانکردنەوە-و-بیناسازی-و-تەواوکاری/دانان-و-سیانەی-سیستەمی-فێنککەرەوە-و-هەواگۆڕکێ', '4.6.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اعمال بناء وتشطيب (لبخ، صبغ، ديكورات جبس)', 'کاری بیناسازی و تەواوکاری (لێباخ، بۆیاخ، دیکۆراتی گەچ)', 'الخدمات/خدمات-الاعمار-والبناء-والتشطيبات/اعمال-بناء-وتشطيب', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئاوەدانکردنەوە-و-بیناسازی-و-تەواوکاری/کاری-بیناسازی-و-تەواوکاری', '4.6.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ترميم المباني التراثية والاثرية', 'نۆژەنکردنەوەی باڵەخانە کەلەپووری و شوێنەوارییەکان', 'الخدمات/خدمات-الاعمار-والبناء-والتشطيبات/ترميم-المباني-التراثية-والاثرية', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئاوەدانکردنەوە-و-بیناسازی-و-تەواوکاری/نۆژەنکردنەوەی-باڵەخانە-کەلەپووری-و-شوێنەوارییەکان', '4.6.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الخدمات المنزلية المتنوعة', 'خزمەتگوزاری جۆراوجۆری ماڵەوە', 'الخدمات/الخدمات-المنزلية-المتنوعة', 'خزمەتگوزارییەکان/خزمەتگوزاری-جۆراوجۆری-ماڵەوە', '4.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('صيانة واصلاح الاجهزة المنزلية (ثلاجات، غسالات)', 'سیانە و چاککردنەوەی ئامێری ماڵەوە (ساردکەرەوە، جلشۆر)', 'الخدمات/الخدمات-المنزلية-المتنوعة/صيانة-واصلاح-الاجهزة-المنزلية', 'خزمەتگوزارییەکان/خزمەتگوزاری-جۆراوجۆری-ماڵەوە/سیانە-و-چاککردنەوەی-ئامێری-ماڵەوە', '4.7.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تنظيف منازل وشقق ومكاتب (شركات تنظيف)', 'پاککردنەوەی ماڵ و شوقە و نووسینگە (کۆمپانیای پاککەرەوە)', 'الخدمات/الخدمات-المنزلية-المتنوعة/تنظيف-منازل-وشقق-ومكاتب', 'خزمەتگوزارییەکان/خزمەتگوزاری-جۆراوجۆری-ماڵەوە/پاککردنەوەی-ماڵ-و-شوقە-و-نووسینگە', '4.7.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مكافحة حشرات وقوارض ورش مبيدات', 'لەناوبردنی مێروو و قرتێنەر و پرژاندنی دەرمانی مێرووکوژ', 'الخدمات/الخدمات-المنزلية-المتنوعة/مكافحة-حشرات-وقوارض-ورش-مبيدات', 'خزمەتگوزارییەکان/خزمەتگوزاری-جۆراوجۆری-ماڵەوە/لەناوبردنی-مێروو-و-قرتێنەر-و-پرژاندنی-دەرمانی-مێرووکوژ', '4.7.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات العناية بالحدائق', 'خزمەتگوزاری چاودێری باخچە', 'الخدمات/الخدمات-المنزلية-المتنوعة/خدمات-العناية-بالحدائق', 'خزمەتگوزارییەکان/خزمەتگوزاری-جۆراوجۆری-ماڵەوە/خزمەتگوزاری-چاودێری-باخچە', '4.7.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.7'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات طبخ وضيافة للمناسبات والعزائم', 'خزمەتگوزاری چێشتلێنان و میوانداری بۆ بۆنە و خوانەکان', 'الخدمات/الخدمات-المنزلية-المتنوعة/خدمات-طبخ-وضيافة-للمناسبات-والعزائم', 'خزمەتگوزارییەکان/خزمەتگوزاری-جۆراوجۆری-ماڵەوە/خزمەتگوزاری-چێشتلێنان-و-میوانداری-بۆ-بۆنە-و-خوانەکان', '4.7.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات غسيل وكوي ملابس (دراي كلين)', 'خزمەتگوزاری شوشتن و ئوتوکردنی جلوبەرگ (دراي کلین)', 'الخدمات/الخدمات-المنزلية-المتنوعة/خدمات-غسيل-وكوي-ملابس', 'خزمەتگوزارییەکان/خزمەتگوزاری-جۆراوجۆری-ماڵەوە/خزمەتگوزاری-شوشتن-و-ئوتوکردنی-جلوبەرگ', '4.7.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات اصلاح وصيانة عامة', 'خزمەتگوزاری چاککردنەوە و سیانەی گشتی', 'الخدمات/خدمات-اصلاح-وصيانة-عامة', 'خزمەتگوزارییەکان/خزمەتگوزاری-چاککردنەوە-و-سیانەی-گشتی', '4.8', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('صيانة اجهزة كهربائية منزلية صغيرة', 'سیانەی ئامێری کارەبایی بچووکی ماڵەوە', 'الخدمات/خدمات-اصلاح-وصيانة-عامة/صيانة-اجهزة-كهربائية-منزلية-صغيرة', 'خزمەتگوزارییەکان/خزمەتگوزاری-چاککردنەوە-و-سیانەی-گشتی/سیانەی-ئامێری-کارەبایی-بچووکی-ماڵەوە', '4.8.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تصليح وتنجيد اثاث منزلي', 'چاککردنەوە و قوماشکردنی کەلوپەلی ماڵەوە', 'الخدمات/خدمات-اصلاح-وصيانة-عامة/تصليح-وتنجيد-اثاث-منزلي', 'خزمەتگوزارییەکان/خزمەتگوزاری-چاککردنەوە-و-سیانەی-گشتی/چاککردنەوە-و-قوماشکردنی-کەلوپەلی-ماڵەوە', '4.8.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تصليح احذية وحقائب وساعات', 'چاککردنەوەی پێڵاو و جانتا و کاتژمێر', 'الخدمات/خدمات-اصلاح-وصيانة-عامة/تصليح-احذية-وحقائب-وساعات', 'خزمەتگوزارییەکان/خزمەتگوزاری-چاککردنەوە-و-سیانەی-گشتی/چاککردنەوەی-پێڵاو-و-جانتا-و-کاتژمێر', '4.8.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تصليح دراجات هوائية وسكوترات', 'چاککردنەوەی پاسکیل و سکۆتەر', 'الخدمات/خدمات-اصلاح-وصيانة-عامة/تصليح-دراجات-هوائية-وسكوترات', 'خزمەتگوزارییەکان/خزمەتگوزاری-چاککردنەوە-و-سیانەی-گشتی/چاککردنەوەی-پاسکیل-و-سکۆتەر', '4.8.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات سباكة وكهرباء منزلية (تصليحات)', 'خزمەتگوزاری ئاوەڕۆ و کارەبای ماڵەوە (چاککردنەوە)', 'الخدمات/خدمات-اصلاح-وصيانة-عامة/خدمات-سباكة-وكهرباء-منزلية', 'خزمەتگوزارییەکان/خزمەتگوزاری-چاککردنەوە-و-سیانەی-گشتی/خزمەتگوزاری-ئاوەڕۆ-و-کارەبای-ماڵەوە', '4.8.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات تجهيز الطعام والمناسبات', 'خزمەتگوزاری ئامادەکردنی خواردن و بۆنەکان', 'الخدمات/خدمات-تجهيز-الطعام-والمناسبات', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئامادەکردنی-خواردن-و-بۆنەکان', '4.9', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات طبخ منزلي حسب الطلب', 'خزمەتگوزاری چێشتلێنانی ماڵەوە بەپێی داواکاری', 'الخدمات/خدمات-تجهيز-الطعام-والمناسبات/خدمات-طبخ-منزلي-حسب-الطلب', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئامادەکردنی-خواردن-و-بۆنەکان/خزمەتگوزاری-چێشتلێنانی-ماڵەوە-بەپێی-داواکاری', '4.9.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.9'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تجهيز ولائم ومناسبات', 'ئامادەکردنی خوان و بۆنەکان', 'الخدمات/خدمات-تجهيز-الطعام-والمناسبات/تجهيز-ولائم-ومناسبات', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئامادەکردنی-خواردن-و-بۆنەکان/ئامادەکردنی-خوان-و-بۆنەکان', '4.9.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات توزيع وجبات جاهزة للشركات والموظفين', 'خزمەتگوزاری دابەشکردنی ژەمی ئامادەکراو بۆ کۆمپانیا و فەرمانبەران', 'الخدمات/خدمات-تجهيز-الطعام-والمناسبات/خدمات-توزيع-وجبات-جاهزة-للشركات-والموظفين', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئامادەکردنی-خواردن-و-بۆنەکان/خزمەتگوزاری-دابەشکردنی-ژەمی-ئامادەکراو-بۆ-کۆمپانیا-و-فەرمانبەران', '4.9.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات التوصيل (دليفري)', 'خزمەتگوزاری گەیاندن (دلیڤەری)', 'الخدمات/خدمات-التوصيل', 'خزمەتگوزارییەکان/خزمەتگوزاری-گەیاندن', '4.10', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('توصيل طلبات طعام من المطاعم', 'گەیاندنی داواکاری خواردن لە چێشتخانەکان', 'الخدمات/خدمات-التوصيل/توصيل-طلبات-طعام-من-المطاعم', 'خزمەتگوزارییەکان/خزمەتگوزاری-گەیاندن/گەیاندنی-داواکاری-خواردن-لە-چێشتخانەکان', '4.10.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('توصيل طلبات من السوبرماركت والصيدليات', 'گەیاندنی داواکاری لە سوپەرمارکێت و دەرمانخانەکان', 'الخدمات/خدمات-التوصيل/توصيل-طلبات-من-السوبرماركت-والصيدليات', 'خزمەتگوزارییەکان/خزمەتگوزاری-گەیاندن/گەیاندنی-داواکاری-لە-سوپەرمارکێت-و-دەرمانخانەکان', '4.10.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('توصيل قناني غاز ومياه معدنية للمنازل', 'گەیاندنی بوتڵی غاز و ئاوی کانزایی بۆ ماڵەکان', 'الخدمات/خدمات-التوصيل/توصيل-قناني-غاز-ومياه-معدنية-للمنازل', 'خزمەتگوزارییەکان/خزمەتگوزاری-گەیاندن/گەیاندنی-بوتڵی-غاز-و-ئاوی-کانزایی-بۆ-ماڵەکان', '4.10.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات صحية وتجميلية وعناية شخصية', 'خزمەتگوزاری تەندروستی و جوانکاری و چاودێری کەسی', 'الخدمات/خدمات-صحية-وتجميلية-وعناية-شخصية', 'خزمەتگوزارییەکان/خزمەتگوزاری-تەندروستی-و-جوانکاری-و-چاودێری-کەسی', '4.11', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات تمريض منزلي ورعاية صحية لكبار السن', 'خزمەتگوزاری پەرستاری ماڵەوە و چاودێری تەندروستی بۆ بەساڵاچووان', 'الخدمات/خدمات-صحية-وتجميلية-وعناية-شخصية/خدمات-تمريض-منزلي-ورعاية-صحية-لكبار-السن', 'خزمەتگوزارییەکان/خزمەتگوزاری-تەندروستی-و-جوانکاری-و-چاودێری-کەسی/خزمەتگوزاری-پەرستاری-ماڵەوە-و-چاودێری-تەندروستی-بۆ-بەساڵاچووان', '4.11.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.11'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات عيادات متنقلة وفحوصات منزلية', 'خزمەتگوزاری کلینیکی گەڕۆک و پشکنینی ماڵەوە', 'الخدمات/خدمات-صحية-وتجميلية-وعناية-شخصية/خدمات-عيادات-متنقلة-وفحوصات-منزلية', 'خزمەتگوزارییەکان/خزمەتگوزاری-تەندروستی-و-جوانکاری-و-چاودێری-کەسی/خزمەتگوزاری-کلینیکی-گەڕۆک-و-پشکنینی-ماڵەوە', '4.11.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.11'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات تجميل وليزر وعناية بالبشرة (مراكز تجميل)', 'خزمەتگوزاری جوانکاری و لێزەر و چاودێری پێست (ناوەندی جوانکاری)', 'الخدمات/خدمات-صحية-وتجميلية-وعناية-شخصية/خدمات-تجميل-وليزر-وعناية-بالبشرة', 'خزمەتگوزارییەکان/خزمەتگوزاری-تەندروستی-و-جوانکاری-و-چاودێری-کەسی/خزمەتگوزاری-جوانکاری-و-لێزەر-و-چاودێری-پێست', '4.11.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.11'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('صالونات حلاقة وتجميل (نسائي ورجالي)', 'ئارایشتگای سەرتاشین و جوانکاری (ژنان و پیاوان)', 'الخدمات/خدمات-صحية-وتجميلية-وعناية-شخصية/صالونات-حلاقة-وتجميل', 'خزمەتگوزارییەکان/خزمەتگوزاری-تەندروستی-و-جوانکاری-و-چاودێری-کەسی/ئارایشتگای-سەرتاشین-و-جوانکاری', '4.11.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.11'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات حجامة وعلاج طبيعي وطب بديل', 'خزمەتگوزاری کەڵەشاخ و چارەسەری سروشتی و پزیشکی جێگرەوە', 'الخدمات/خدمات-صحية-وتجميلية-وعناية-شخصية/خدمات-حجامة-وعلاج-طبيعي-وطب-بديل', 'خزمەتگوزارییەکان/خزمەتگوزاری-تەندروستی-و-جوانکاری-و-چاودێری-کەسی/خزمەتگوزاری-کەڵەشاخ-و-چارەسەری-سروشتی-و-پزیشکی-جێگرەوە', '4.11.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.11'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات تعليم وتدريب ودورات', 'خزمەتگوزاری فێرکردن و ڕاهێنان و خول', 'الخدمات/خدمات-تعليم-وتدريب-ودورات', 'خزمەتگوزارییەکان/خزمەتگوزاری-فێرکردن-و-ڕاهێنان-و-خول', '4.12', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('دروس خصوصية وتقوية للطلاب', 'وانەی تایبەت و بەهێزکردن بۆ قوتابیان', 'الخدمات/خدمات-تعليم-وتدريب-ودورات/دروس-خصوصية-وتقوية-للطلاب', 'خزمەتگوزارییەکان/خزمەتگوزاری-فێرکردن-و-ڕاهێنان-و-خول/وانەی-تایبەت-و-بەهێزکردن-بۆ-قوتابیان', '4.12.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.12'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('دورات تعليم لغات', 'خولی فێربوونی زمان', 'الخدمات/خدمات-تعليم-وتدريب-ودورات/دورات-تعليم-لغات', 'خزمەتگوزارییەکان/خزمەتگوزاری-فێرکردن-و-ڕاهێنان-و-خول/خولی-فێربوونی-زمان', '4.12.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.12'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('دورات كومبيوتر وبرمجة وتكنولوجيا معلومات', 'خولی کۆمپیوتەر و پرۆگرامسازی و تەکنەلۆژیای زانیاری', 'الخدمات/خدمات-تعليم-وتدريب-ودورات/دورات-كومبيوتر-وبرمجة-وتكنولوجيا-معلومات', 'خزمەتگوزارییەکان/خزمەتگوزاری-فێرکردن-و-ڕاهێنان-و-خول/خولی-کۆمپیوتەر-و-پرۆگرامسازی-و-تەکنەلۆژیای-زانیاری', '4.12.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.12'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('دورات تدريب مهني وحرفي (خياطة، نجارة)', 'خولی ڕاهێنانی پیشەیی و دەستی (دوورمان، دارتاشی)', 'الخدمات/خدمات-تعليم-وتدريب-ودورات/دورات-تدريب-مهني-وحرفي', 'خزمەتگوزارییەکان/خزمەتگوزاری-فێرکردن-و-ڕاهێنان-و-خول/خولی-ڕاهێنانی-پیشەیی-و-دەستی', '4.12.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.12'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات تقنية ومعلوماتية', 'خزمەتگوزاری تەکنیکی و زانیاری', 'الخدمات/خدمات-تقنية-ومعلوماتية', 'خزمەتگوزارییەکان/خزمەتگوزاری-تەکنیکی-و-زانیاری', '4.13', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('صيانة موبايلات وكومبيوترات ولابتوبات', 'چاککردنەوەی مۆبایل و کۆمپیوتەر و لاپتۆپ', 'الخدمات/خدمات-تقنية-ومعلوماتية/صيانة-موبايلات-وكومبيوترات-ولابتوبات', 'خزمەتگوزارییەکان/خزمەتگوزاری-تەکنیکی-و-زانیاری/چاککردنەوەی-مۆبایل-و-کۆمپیوتەر-و-لاپتۆپ', '4.13.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.13'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تصميم وتطوير مواقع الكترونية وتطبيقات', 'دیزاین و پەرەپێدانی ماڵپەڕ و ئەپلیکەیشن', 'الخدمات/خدمات-تقنية-ومعلوماتية/تصميم-وتطوير-مواقع-الكترونية-وتطبيقات', 'خزمەتگوزارییەکان/خزمەتگوزاری-تەکنیکی-و-زانیاری/دیزاین-و-پەرەپێدانی-ماڵپەڕ-و-ئەپلیکەیشن', '4.13.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.13'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات تسويق الكتروني ودعاية واعلان اونلاين', 'خزمەتگوزاری بازاڕگەری ئەلیکترۆنی و ڕیکلامی ئۆنلاین', 'الخدمات/خدمات-تقنية-ومعلوماتية/خدمات-تسويق-الكتروني-ودعاية-واعلان-اونلاين', 'خزمەتگوزارییەکان/خزمەتگوزاری-تەکنیکی-و-زانیاری/خزمەتگوزاری-بازاڕگەری-ئەلیکترۆنی-و-ڕیکلامی-ئۆنلاین', '4.13.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.13'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات شبكات انترنت وتاسيس (تمديد كيبلات)', 'خزمەتگوزاری تۆڕەکانی ئینتەرنێت و دامەزراندن (ڕاکێشانی کێبڵ)', 'الخدمات/خدمات-تقنية-ومعلوماتية/خدمات-شبكات-انترنت-وتاسيس', 'خزمەتگوزارییەکان/خزمەتگوزاری-تەکنیکی-و-زانیاری/خزمەتگوزاری-تۆڕەکانی-ئینتەرنێت-و-دامەزراندن', '4.13.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.13'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تركيب وصيانة كاميرات مراقبة وانظمة امنية', 'دانان و سیانەی کامێرای چاودێری و سیستەمی ئاسایش', 'الخدمات/خدمات-تقنية-ومعلوماتية/تركيب-وصيانة-كاميرات-مراقبة-وانظمة-امنية', 'خزمەتگوزارییەکان/خزمەتگوزاری-تەکنیکی-و-زانیاری/دانان-و-سیانەی-کامێرای-چاودێری-و-سیستەمی-ئاسایش', '4.13.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.13'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات زراعية وبستنة', 'خزمەتگوزاری کشتوکاڵی و باخداری', 'الخدمات/خدمات-زراعية-وبستنة', 'خزمەتگوزارییەکان/خزمەتگوزاری-کشتوکاڵی-و-باخداری', '4.14', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('زراعة وخدمة نخيل واشجار مثمرة', 'چاندن و خزمەتکردنی دارخورما و داری بەردار', 'الخدمات/خدمات-زراعية-وبستنة/زراعة-وخدمة-نخيل-واشجار-مثمرة', 'خزمەتگوزارییەکان/خزمەتگوزاری-کشتوکاڵی-و-باخداری/چاندن-و-خزمەتکردنی-دارخورما-و-داری-بەردار', '4.14.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.14'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تصميم وتنسيق حدائق منزلية وعامة', 'دیزاین و ڕێکخستنی باخچەی ماڵان و گشتی', 'الخدمات/خدمات-زراعية-وبستنة/تصميم-وتنسيق-حدائق-منزلية-وعامة', 'خزمەتگوزارییەکان/خزمەتگوزاری-کشتوکاڵی-و-باخداری/دیزاین-و-ڕێکخستنی-باخچەی-ماڵان-و-گشتی', '4.14.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.14'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات ري وتسميد ومكافحة امراض نباتات', 'خزمەتگوزاری ئاودێری و پەینکردن و لەناوبردنی نەخۆشی ڕووەک', 'الخدمات/خدمات-زراعية-وبستنة/خدمات-ري-وتسميد-ومكافحة-امراض-نباتات', 'خزمەتگوزارییەکان/خزمەتگوزاری-کشتوکاڵی-و-باخداری/خزمەتگوزاری-ئاودێری-و-پەینکردن-و-لەناوبردنی-نەخۆشی-ڕووەک', '4.14.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.14'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مكافحة افات زراعية وحشرات ضارة', 'لەناوبردنی ئافاتی کشتوکاڵی و مێرووی زیانبەخش', 'الخدمات/خدمات-زراعية-وبستنة/مكافحة-افات-زراعية-وحشرات-ضارة', 'خزمەتگوزارییەکان/خزمەتگوزاری-کشتوکاڵی-و-باخداری/لەناوبردنی-ئافاتی-کشتوکاڵی-و-مێرووی-زیانبەخش', '4.14.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.14'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات قانونية ومالية واستشارية', 'خزمەتگوزاری یاسایی و دارایی و ڕاوێژکاری', 'الخدمات/خدمات-قانونية-ومالية-واستشارية', 'خزمەتگوزارییەکان/خزمەتگوزاری-یاسایی-و-دارایی-و-ڕاوێژکاری', '4.15', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات محاماة واستشارات قانونية (كتابة عرائض)', 'خزمەتگوزاری پارێزەری و ڕاوێژی یاسایی (نووسینی داواکاری)', 'الخدمات/خدمات-قانونية-ومالية-واستشارية/خدمات-محاماة-واستشارات-قانونية', 'خزمەتگوزارییەکان/خزمەتگوزاری-یاسایی-و-دارایی-و-ڕاوێژکاری/خزمەتگوزاری-پارێزەری-و-ڕاوێژی-یاسایی', '4.15.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.15'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات محاسبة وتنظيم حسابات وضرائب', 'خزمەتگوزاری ژمێریاری و ڕێکخستنی هەژمار و باج', 'الخدمات/خدمات-قانونية-ومالية-واستشارية/خدمات-محاسبة-وتنظيم-حسابات-وضرائب', 'خزمەتگوزارییەکان/خزمەتگوزاری-یاسایی-و-دارایی-و-ڕاوێژکاری/خزمەتگوزاری-ژمێریاری-و-ڕێکخستنی-هەژمار-و-باج', '4.15.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.15'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات صيرفة وتحويل اموال (ويسترن يونيون، زين كاش، فاست بي)', 'خزمەتگوزاری ئاڵوگۆڕی دراو و گواستنەوەی پارە (وێسترن یونیەن، زەین کاش، فاست پەی)', 'الخدمات/خدمات-قانونية-ومالية-واستشارية/خدمات-صيرفة-وتحويل-اموال', 'خزمەتگوزارییەکان/خزمەتگوزاری-یاسایی-و-دارایی-و-ڕاوێژکاری/خزمەتگوزاری-ئاڵوگۆڕی-دراو-و-گواستنەوەی-پارە', '4.15.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.15'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات تامين (سيارات، صحي، سفر، حياة)', 'خزمەتگوزاری دڵنیایی (ئۆتۆمبێل، تەندروستی، گەشت، ژیان)', 'الخدمات/خدمات-قانونية-ومالية-واستشارية/خدمات-تامين', 'خزمەتگوزارییەکان/خزمەتگوزاری-یاسایی-و-دارایی-و-ڕاوێژکاری/خزمەتگوزاری-دڵنیایی', '4.15.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.15'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات مناسبات وافراح وفعاليات', 'خزمەتگوزاری بۆنە و ئاهەنگ و چالاکی', 'الخدمات/خدمات-مناسبات-وافراح-وفعاليات', 'خزمەتگوزارییەکان/خزمەتگوزاری-بۆنە-و-ئاهەنگ-و-چالاکی', '4.16', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تنظيم حفلات اعراس ومناسبات خاصة (منسق حفلات)', 'ڕێکخستنی ئاهەنگی هاوسەرگیری و بۆنەی تایبەت (ڕێکخەری ئاهەنگ)', 'الخدمات/خدمات-مناسبات-وافراح-وفعاليات/تنظيم-حفلات-اعراس-ومناسبات-خاصة', 'خزمەتگوزارییەکان/خزمەتگوزاری-بۆنە-و-ئاهەنگ-و-چالاکی/ڕێکخستنی-ئاهەنگی-هاوسەرگیری-و-بۆنەی-تایبەت', '4.16.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.16'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات تجهيز طعام للولائم والعزاء (مضايف)', 'خزمەتگوزاری ئامادەکردنی خواردن بۆ خوان و پرسە (مەزەخانە)', 'الخدمات/خدمات-مناسبات-وافراح-وفعاليات/خدمات-تجهيز-طعام-للولائم-والعزاء', 'خزمەتگوزارییەکان/خزمەتگوزاری-بۆنە-و-ئاهەنگ-و-چالاکی/خزمەتگوزاری-ئامادەکردنی-خواردن-بۆ-خوان-و-پرسە', '4.16.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.16'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تاجير قاعات مناسبات وخيم ولوازم افراح', 'بەکرێدانی هۆڵی بۆنە و خێوەت و پێداویستی ئاهەنگ', 'الخدمات/خدمات-مناسبات-وافراح-وفعاليات/تاجير-قاعات-مناسبات-وخيم-ولوازم-افراح', 'خزمەتگوزارییەکان/خزمەتگوزاری-بۆنە-و-ئاهەنگ-و-چالاکی/بەکرێدانی-هۆڵی-بۆنە-و-خێوەت-و-پێداویستی-ئاهەنگ', '4.16.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.16'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تصوير فوتوغرافي وفيديو للمناسبات (مصورين)', 'وێنەگرتنی فۆتۆگرافی و ڤیدیۆیی بۆنەکان (وێنەگر)', 'الخدمات/خدمات-مناسبات-وافراح-وفعاليات/تصوير-فوتوغرافي-وفيديو-للمناسبات', 'خزمەتگوزارییەکان/خزمەتگوزاری-بۆنە-و-ئاهەنگ-و-چالاکی/وێنەگرتنی-فۆتۆگرافی-و-ڤیدیۆیی-بۆنەکان', '4.16.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.16'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات سياحة وسفر وزيارات دينية', 'خزمەتگوزاری گەشتوگوزار و گەشت و زیارەتی ئایینی', 'الخدمات/خدمات-سياحة-وسفر-وزيارات-دينية', 'خزمەتگوزارییەکان/خزمەتگوزاری-گەشتوگوزار-و-گەشت-و-زیارەتی-ئایینی', '4.17', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تنظيم رحلات سياحية داخل وخارج العراق (كروبات)', 'ڕێکخستنی گەشتی گەشتیاری لەناو و دەرەوەی عێراق (گرووپ)', 'الخدمات/خدمات-سياحة-وسفر-وزيارات-دينية/تنظيم-رحلات-سياحية-داخل-وخارج-العراق', 'خزمەتگوزارییەکان/خزمەتگوزاری-گەشتوگوزار-و-گەشت-و-زیارەتی-ئایینی/ڕێکخستنی-گەشتی-گەشتیاری-لەناو-و-دەرەوەی-عێراق', '4.17.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.17'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات حج وعمرة وزيارات', 'خزمەتگوزاری حەج و عومرە و زیارەت', 'الخدمات/خدمات-سياحة-وسفر-وزيارات-دينية/خدمات-حج-وعمرة-وزيارات', 'خزمەتگوزارییەکان/خزمەتگوزاری-گەشتوگوزار-و-گەشت-و-زیارەتی-ئایینی/خزمەتگوزاری-حەج-و-عومرە-و-زیارەت', '4.17.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.17'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تنظيم زيارات للعتبات المقدسة والاماكن الاثرية', 'ڕێکخستنی زیارەت بۆ شوێنە پیرۆزەکان و شوێنەوارەکان', 'الخدمات/خدمات-سياحة-وسفر-وزيارات-دينية/تنظيم-زيارات-للعتبات-المقدسة-والاماكن-الاثرية', 'خزمەتگوزارییەکان/خزمەتگوزاری-گەشتوگوزار-و-گەشت-و-زیارەتی-ئایینی/ڕێکخستنی-زیارەت-بۆ-شوێنە-پیرۆزەکان-و-شوێنەوارەکان', '4.17.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.17'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات امن وحماية وحراسات', 'خزمەتگوزاری ئاسایش و پاراستن و پاسەوانی', 'الخدمات/خدمات-امن-وحماية-وحراسات', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئاسایش-و-پاراستن-و-پاسەوانی', '4.18', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات حراسة للمنشآت والشخصيات (شركات امنية)', 'خزمەتگوزاری پاسەوانی بۆ دامەزراوە و کەسایەتییەکان (کۆمپانیای ئەمنی)', 'الخدمات/خدمات-امن-وحماية-وحراسات/خدمات-حراسة-للمنشآت-والشخصيات', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئاسایش-و-پاراستن-و-پاسەوانی/خزمەتگوزاری-پاسەوانی-بۆ-دامەزراوە-و-کەسایەتییەکان', '4.18.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.18'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تركيب انظمة انذار وحماية ومراقبة', 'دانانی سیستەمی ئاگادارکەرەوە و پاراستن و چاودێری', 'الخدمات/خدمات-امن-وحماية-وحراسات/تركيب-انظمة-انذار-وحماية-ومراقبة', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئاسایش-و-پاراستن-و-پاسەوانی/دانانی-سیستەمی-ئاگادارکەرەوە-و-پاراستن-و-چاودێری', '4.18.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.18'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات مرافقة امنية وحماية شخصية', 'خزمەتگوزاری یاوەری ئەمنی و پاراستنی کەسی', 'الخدمات/خدمات-امن-وحماية-وحراسات/خدمات-مرافقة-امنية-وحماية-شخصية', 'خزمەتگوزارییەکان/خزمەتگوزاری-ئاسایش-و-پاراستن-و-پاسەوانی/خزمەتگوزاری-یاوەری-ئەمنی-و-پاراستنی-کەسی', '4.18.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.18'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات طاقة وكهرباء بديلة', 'خزمەتگوزاری وزە و کارەبای جێگرەوە', 'الخدمات/خدمات-طاقة-وكهرباء-بديلة', 'خزمەتگوزارییەکان/خزمەتگوزاری-وزە-و-کارەبای-جێگرەوە', '4.19', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تركيب وصيانة الواح طاقة شمسية ومنظومات', 'دانان و سیانەی پانێڵی وزەی خۆر و سیستەمەکان', 'الخدمات/خدمات-طاقة-وكهرباء-بديلة/تركيب-وصيانة-الواح-طاقة-شمسية-ومنظومات', 'خزمەتگوزارییەکان/خزمەتگوزاری-وزە-و-کارەبای-جێگرەوە/دانان-و-سیانەی-پانێڵی-وزەی-خۆر-و-سیستەمەکان', '4.19.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.19'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات توزيع وقود وغاز للمنازل والمشاريع', 'خزمەتگوزاری دابەشکردنی سووتەمەنی و غاز بۆ ماڵان و پڕۆژەکان', 'الخدمات/خدمات-طاقة-وكهرباء-بديلة/خدمات-توزيع-وقود-وغاز-للمنازل-والمشاريع', 'خزمەتگوزارییەکان/خزمەتگوزاری-وزە-و-کارەبای-جێگرەوە/خزمەتگوزاری-دابەشکردنی-سووتەمەنی-و-غاز-بۆ-ماڵان-و-پڕۆژەکان', '4.19.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.19'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('صيانة مولدات كهربائية ومحطات طاقة', 'سیانەی مۆلیدەی کارەبایی و وێستگەی وزە', 'الخدمات/خدمات-طاقة-وكهرباء-بديلة/صيانة-مولدات-كهربائية-ومحطات-طاقة', 'خزمەتگوزارییەکان/خزمەتگوزاری-وزە-و-کارەبای-جێگرەوە/سیانەی-مۆلیدەی-کارەبایی-و-وێستگەی-وزە', '4.19.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.19'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات اخرى', 'خزمەتگوزاری تر', 'الخدمات/خدمات-اخرى', 'خزمەتگوزارییەکان/خزمەتگوزاری-تر', '4.20', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات ترجمة وتوثيق مستندات (مكاتب ترجمة)', 'خزمەتگوزاری وەرگێڕان و پەسەندکردنی بەڵگەنامە (نووسینگەی وەرگێڕان)', 'الخدمات/خدمات-اخرى/خدمات-ترجمة-وتوثيق-مستندات', 'خزمەتگوزارییەکان/خزمەتگوزاری-تر/خزمەتگوزاری-وەرگێڕان-و-پەسەندکردنی-بەڵگەنامە', '4.20.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.20'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات رعاية كبار السن والاطفال وذوي الاحتياجات الخاصة', 'خزمەتگوزاری چاودێری بەساڵاچووان و منداڵان و خاوەن پێداویستی تایبەت', 'الخدمات/خدمات-اخرى/خدمات-رعاية-كبار-السن-والاطفال-وذوي-الاحتياجات-الخاصة', 'خزمەتگوزارییەکان/خزمەتگوزاری-تر/خزمەتگوزاری-چاودێری-بەساڵاچووان-و-منداڵان-و-خاوەن-پێداویستی-تایبەت', '4.20.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.20'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خدمات خياطة وتفصيل وتعديل ملابس (خياطين)', 'خزمەتگوزاری دوورین و بڕین و دەستکاریکردنی جلوبەرگ (بەرگدروو)', 'الخدمات/خدمات-اخرى/خدمات-خياطة-وتفصيل-وتعديل-ملابس', 'خزمەتگوزارییەکان/خزمەتگوزاری-تر/خزمەتگوزاری-دوورین-و-بڕین-و-دەستکاریکردنی-جلوبەرگ', '4.20.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '4.20'));

-- End of Level 1 Category: 4

-- Level 1 Category: 5 - المقتنيات الشخصية والصحة والجمال

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('المقتنيات الشخصية والصحة والجمال', 'کەلوپەلی کەسی و تەندروستی و جوانکاری', 'المقتنيات-الشخصية-والصحة-والجمال', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری', '5', NULL);
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ملابس واحذية واكسسوارات', 'جلوبەرگ و پێڵاو و ئێکسسوارات', 'المقتنيات-الشخصية-والصحة-والجمال/ملابس-واحذية-واكسسوارات', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جلوبەرگ-و-پێڵاو-و-ئێکسسوارات', '5.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ملابس نسائية', 'جلوبەرگی ژنان', 'المقتنيات-الشخصية-والصحة-والجمال/ملابس-واحذية-واكسسوارات/ملابس-نسائية', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جلوبەرگ-و-پێڵاو-و-ئێکسسوارات/جلوبەرگی-ژنان', '5.1.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('احذية نسائية', 'پێڵاوی ژنان', 'المقتنيات-الشخصية-والصحة-والجمال/ملابس-واحذية-واكسسوارات/احذية-نسائية', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جلوبەرگ-و-پێڵاو-و-ئێکسسوارات/پێڵاوی-ژنان', '5.1.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ملابس رجالية', 'جلوبەرگی پیاوان', 'المقتنيات-الشخصية-والصحة-والجمال/ملابس-واحذية-واكسسوارات/ملابس-رجالية', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جلوبەرگ-و-پێڵاو-و-ئێکسسوارات/جلوبەرگی-پیاوان', '5.1.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('احذية رجالية', 'پێڵاوی پیاوان', 'المقتنيات-الشخصية-والصحة-والجمال/ملابس-واحذية-واكسسوارات/احذية-رجالية', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جلوبەرگ-و-پێڵاو-و-ئێکسسوارات/پێڵاوی-پیاوان', '5.1.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.1'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ملابس اطفال', 'جلوبەرگی منداڵان', 'المقتنيات-الشخصية-والصحة-والجمال/ملابس-واحذية-واكسسوارات/ملابس-اطفال', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جلوبەرگ-و-پێڵاو-و-ئێکسسوارات/جلوبەرگی-منداڵان', '5.1.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('احذية اطفال', 'پێڵاوی منداڵان', 'المقتنيات-الشخصية-والصحة-والجمال/ملابس-واحذية-واكسسوارات/احذية-اطفال', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جلوبەرگ-و-پێڵاو-و-ئێکسسوارات/پێڵاوی-منداڵان', '5.1.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('حقائب وشنط ومحافظ', 'جانتا و کیف و جزدان', 'المقتنيات-الشخصية-والصحة-والجمال/ملابس-واحذية-واكسسوارات/حقائب-وشنط-ومحافظ', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جلوبەرگ-و-پێڵاو-و-ئێکسسوارات/جانتا-و-کیف-و-جزدان', '5.1.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ساعات واكسسوارات اخرى', 'کاتژمێر و ئێکسسواراتی تر', 'المقتنيات-الشخصية-والصحة-والجمال/ملابس-واحذية-واكسسوارات/ساعات-واكسسوارات-اخرى', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جلوبەرگ-و-پێڵاو-و-ئێکسسوارات/کاتژمێر-و-ئێکسسواراتی-تر', '5.1.8', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكسسوارات رجالية (محابس، سبح، اقلام)', 'ئێکسسواراتی پیاوان (ئەنگوستیلە، تەزبیح، قەڵەم)', 'المقتنيات-الشخصية-والصحة-والجمال/ملابس-واحذية-واكسسوارات/ساعات-واكسسوارات-اخرى/اكسسوارات-رجالية', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جلوبەرگ-و-پێڵاو-و-ئێکسسوارات/کاتژمێر-و-ئێکسسواراتی-تر/ئێکسسواراتی-پیاوان', '5.1.8.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.1.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكسسوارات نسائية (تراجي، كلايد، اساور)', 'ئێکسسواراتی ژنان (گواره، ملوانکە، بازن)', 'المقتنيات-الشخصية-والصحة-والجمال/ملابس-واحذية-واكسسوارات/ساعات-واكسسوارات-اخرى/اكسسوارات-نسائية', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جلوبەرگ-و-پێڵاو-و-ئێکسسوارات/کاتژمێر-و-ئێکسسواراتی-تر/ئێکسسواراتی-ژنان', '5.1.8.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.1.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكسسوارات شعر (ماشات، قراصات)', 'ئێکسسواراتی قژ (ماشه، قڕاسە)', 'المقتنيات-الشخصية-والصحة-والجمال/ملابس-واحذية-واكسسوارات/ساعات-واكسسوارات-اخرى/اكسسوارات-شعر', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جلوبەرگ-و-پێڵاو-و-ئێکسسوارات/کاتژمێر-و-ئێکسسواراتی-تر/ئێکسسواراتی-قژ', '5.1.8.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.1.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ساعات يد (رجالية ونسائية)', 'کاتژمێری دەست (پیاوان و ژنان)', 'المقتنيات-الشخصية-والصحة-والجمال/ملابس-واحذية-واكسسوارات/ساعات-واكسسوارات-اخرى/ساعات-يد', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جلوبەرگ-و-پێڵاو-و-ئێکسسوارات/کاتژمێر-و-ئێکسسواراتی-تر/کاتژمێری-دەست', '5.1.8.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.1.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اساور ومجوهرات (اكسسوار)', 'بازن و خشڵ (ئێکسسوار)', 'المقتنيات-الشخصية-والصحة-والجمال/ملابس-واحذية-واكسسوارات/ساعات-واكسسوارات-اخرى/اساور-ومجوهرات', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جلوبەرگ-و-پێڵاو-و-ئێکسسوارات/کاتژمێر-و-ئێکسسواراتی-تر/بازن-و-خشڵ', '5.1.8.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.1.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكسسوارات اخرى', 'ئێکسسواراتی تر', 'المقتنيات-الشخصية-والصحة-والجمال/ملابس-واحذية-واكسسوارات/ساعات-واكسسوارات-اخرى/اكسسوارات-اخرى', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جلوبەرگ-و-پێڵاو-و-ئێکسسوارات/کاتژمێر-و-ئێکسسواراتی-تر/ئێکسسواراتی-تر', '5.1.8.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.1.8'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('نظارات شمسية وطبية', 'چاویلکەی خۆر و پزیشکی', 'المقتنيات-الشخصية-والصحة-والجمال/ملابس-واحذية-واكسسوارات/نظارات-شمسية-وطبية', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جلوبەرگ-و-پێڵاو-و-ئێکسسوارات/چاویلکەی-خۆر-و-پزیشکی', '5.1.9', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('منتجات الاطفال والعابهم', 'بەرهەمی منداڵان و یارییەکانیان', 'المقتنيات-الشخصية-والصحة-والجمال/منتجات-الاطفال-والعابهم', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/بەرهەمی-منداڵان-و-یارییەکانیان', '5.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عربات اطفال', 'عەرەبانەی منداڵان', 'المقتنيات-الشخصية-والصحة-والجمال/منتجات-الاطفال-والعابهم/عربات-اطفال', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/بەرهەمی-منداڵان-و-یارییەکانیان/عەرەبانەی-منداڵان', '5.2.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اثاث غرف اطفال', 'کەلوپەلی ژووری منداڵان', 'المقتنيات-الشخصية-والصحة-والجمال/منتجات-الاطفال-والعابهم/اثاث-غرف-اطفال', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/بەرهەمی-منداڵان-و-یارییەکانیان/کەلوپەلی-ژووری-منداڵان', '5.2.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مقاعد سيارات للاطفال (كار سيت)', 'کورسی ئۆتۆمبێل بۆ منداڵان (کار سیت)', 'المقتنيات-الشخصية-والصحة-والجمال/منتجات-الاطفال-والعابهم/مقاعد-سيارات-للاطفال', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/بەرهەمی-منداڵان-و-یارییەکانیان/کورسی-ئۆتۆمبێل-بۆ-منداڵان', '5.2.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('دراجات هوائية وسكوترات اطفال', 'پاسکیل و سکۆتەری منداڵان', 'المقتنيات-الشخصية-والصحة-والجمال/منتجات-الاطفال-والعابهم/دراجات-هوائية-وسكوترات-اطفال', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/بەرهەمی-منداڵان-و-یارییەکانیان/پاسکیل-و-سکۆتەری-منداڵان', '5.2.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اسرة وفرشات اطفال', 'جێگا و دۆشەکی منداڵان', 'المقتنيات-الشخصية-والصحة-والجمال/منتجات-الاطفال-والعابهم/اسرة-وفرشات-اطفال', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/بەرهەمی-منداڵان-و-یارییەکانیان/جێگا-و-دۆشەکی-منداڵان', '5.2.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('العاب تعليمية وفكرية للاطفال', 'یاری فێرکاری و هزری بۆ منداڵان', 'المقتنيات-الشخصية-والصحة-والجمال/منتجات-الاطفال-والعابهم/العاب-تعليمية-وفكرية-للاطفال', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/بەرهەمی-منداڵان-و-یارییەکانیان/یاری-فێرکاری-و-هزری-بۆ-منداڵان', '5.2.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('دمى وعرائس والعاب بنات', 'بووکەڵە و یاری کچان', 'المقتنيات-الشخصية-والصحة-والجمال/منتجات-الاطفال-والعابهم/دمى-وعرائس-والعاب-بنات', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/بەرهەمی-منداڵان-و-یارییەکانیان/بووکەڵە-و-یاری-کچان', '5.2.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مستلزمات وقرطاسية مدرسية', 'پێداویستی و قوتابخانە', 'المقتنيات-الشخصية-والصحة-والجمال/منتجات-الاطفال-والعابهم/مستلزمات-وقرطاسية-مدرسية', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/بەرهەمی-منداڵان-و-یارییەکانیان/پێداویستی-و-قوتابخانە', '5.2.8', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.2'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الجمال والعناية الشخصية', 'جوانکاری و چاودێری کەسی', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی', '5.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مكياج ومستحضرات تجميل', 'مکیاج و کەرەستەی جوانکاری', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/مكياج-ومستحضرات-تجميل', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/مکیاج-و-کەرەستەی-جوانکاری', '5.3.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مكياج وجه وعيون (فاونديشن، حمره، كحل، ماسكارا، ايشادو)', 'مکیاجی دەموچاو و چاو (فاوندەیشن، سووراو، کل، ماسکارا، ئایشادۆ)', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/مكياج-ومستحضرات-تجميل/مكياج-وجه-وعيون', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/مکیاج-و-کەرەستەی-جوانکاری/مکیاجی-دەموچاو-و-چاو', '5.3.1.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادوات ومزيلات مكياج (فرش، اسفنجات، مزيلات)', 'کەرەستە و لابەری مکیاج (فڵچە، ئیسفەنج، لابەر)', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/مكياج-ومستحضرات-تجميل/ادوات-ومزيلات-مكياج', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/مکیاج-و-کەرەستەی-جوانکاری/کەرەستە-و-لابەری-مکیاج', '5.3.1.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تجميل اظافر (صبغ، اظافر تركيب)', 'جوانکاری نینۆک (بۆیە، نینۆکی دەستکرد)', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/مكياج-ومستحضرات-تجميل/تجميل-اظافر', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/مکیاج-و-کەرەستەی-جوانکاری/جوانکاری-نینۆک', '5.3.1.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('العناية بالبشرة', 'چاودێری پێست', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/العناية-بالبشرة', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/چاودێری-پێست', '5.3.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('العناية بالوجه (كريمات، سيرومات، غسول، مقشر)', 'چاودێری دەموچاو (کرێم، سیرۆم، غەسول، موقەشیر)', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/العناية-بالبشرة/العناية-بالوجه', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/چاودێری-پێست/چاودێری-دەموچاو', '5.3.2.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('العناية بالجسم (لوشنات، مرطبات، مقشرات جسم)', 'چاودێری لەش (لۆشن، شێدارکەرەوە، موقەشیری لەش)', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/العناية-بالبشرة/العناية-بالجسم', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/چاودێری-پێست/چاودێری-لەش', '5.3.2.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('العناية بالايدي والاقدام والشفاه', 'چاودێری دەست و پێ و لێو', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/العناية-بالبشرة/العناية-بالايدي-والاقدام-والشفاه', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/چاودێری-پێست/چاودێری-دەست-و-پێ-و-لێو', '5.3.2.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('العناية بالشعر', 'چاودێری قژ', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/العناية-بالشعر', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/چاودێری-قژ', '5.3.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('شامبو وبلسم وصبغات شعر', 'شامپۆ و بەلسەم و بۆیەی قژ', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/العناية-بالشعر/شامبو-وبلسم-وصبغات-شعر', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/چاودێری-قژ/شامپۆ-و-بەلسەم-و-بۆیەی-قژ', '5.3.3.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادوات واجهزة تصفيف (سشوار، فرش، كاوية)', 'کەرەستە و ئامێری ڕازاندنەوە (سشوار، فڵچە، کاویە)', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/العناية-بالشعر/ادوات-واجهزة-تصفيف', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/چاودێری-قژ/کەرەستە-و-ئامێری-ڕازاندنەوە', '5.3.3.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('منتجات تصفيف وعطور الشعر (جل، سبراي، سيروم)', 'بەرهەمی ڕازاندنەوە و بۆنی قژ (جێڵ، سپرای، سیرۆم)', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/العناية-بالشعر/منتجات-تصفيف-وعطور-الشعر', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/چاودێری-قژ/بەرهەمی-ڕازاندنەوە-و-بۆنی-قژ', '5.3.3.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عطور ومزيلات عرق', 'بۆن و لابەری ئارەق', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/عطور-ومزيلات-عرق', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/بۆن-و-لابەری-ئارەق', '5.3.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عطور نسائية ورجالية', 'بۆنی ژنان و پیاوان', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/عطور-ومزيلات-عرق/عطور-نسائية-ورجالية', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/بۆن-و-لابەری-ئارەق/بۆنی-ژنان-و-پیاوان', '5.3.4.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معطرات جسم ومزيلات عرق', 'بۆنخۆشکەری لەش و لابەری ئارەق', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/عطور-ومزيلات-عرق/معطرات-جسم-ومزيلات-عرق', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/بۆن-و-لابەری-ئارەق/بۆنخۆشکەری-لەش-و-لابەری-ئارەق', '5.3.4.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عطور عربية وبخور ومخمرية', 'بۆنی عەرەبی و بخوور و مەخمەرییە', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/عطور-ومزيلات-عرق/عطور-عربية-وبخور-ومخمرية', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/بۆن-و-لابەری-ئارەق/بۆنی-عەرەبی-و-بخوور-و-مەخمەرییە', '5.3.4.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الاستحمام والعناية الشخصية', 'خۆشوشتن و چاودێری کەسی', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/الاستحمام-والعناية-الشخصية', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/خۆشوشتن-و-چاودێری-کەسی', '5.3.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('منتجات الاستحمام (غسول جسم، صابون، زيوت)', 'بەرهەمی خۆشوشتن (غەسولی لەش، سابوون، زەیت)', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/الاستحمام-والعناية-الشخصية/منتجات-الاستحمام', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/خۆشوشتن-و-چاودێری-کەسی/بەرهەمی-خۆشوشتن', '5.3.5.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادوات استحمام ومساج (ليفة، حجر قدم، اجهزة مساج)', 'کەرەستەی خۆشوشتن و مەساج (لیفکە، بەردی پێ، ئامێری مەساج)', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/الاستحمام-والعناية-الشخصية/ادوات-استحمام-ومساج', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/خۆشوشتن-و-چاودێری-کەسی/کەرەستەی-خۆشوشتن-و-مەساج', '5.3.5.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3.5'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عدسات ورموش تجميلية', 'هاوێنە و برژانگی جوانکاری', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/عدسات-ورموش-تجميلية', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/هاوێنە-و-برژانگی-جوانکاری', '5.3.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('رموش صناعية ومستلزماتها', 'برژانگی دەستکرد و پێداویستییەکانی', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/عدسات-ورموش-تجميلية/رموش-صناعية-ومستلزماتها', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/هاوێنە-و-برژانگی-جوانکاری/برژانگی-دەستکرد-و-پێداویستییەکانی', '5.3.6.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عدسات لاصقة تجميلية ومحاليل', 'هاوێنەی لکاو (عەدەسە)ی جوانکاری و گیراوەکانی', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/عدسات-ورموش-تجميلية/عدسات-لاصقة-تجميلية-ومحاليل', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/هاوێنە-و-برژانگی-جوانکاری/هاوێنەی-لکاوی-جوانکاری-و-گیراوەکانی', '5.3.6.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الحلاقة وازالة الشعر', 'سەرتاشین و لابردنی موو', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/الحلاقة-وازالة-الشعر', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/سەرتاشین-و-لابردنی-موو', '5.3.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة ومنتجات ازالة الشعر (براون، ليزر، شمع، كريمات)', 'ئامێر و بەرهەمی لابردنی موو (براون، لێزەر، مۆم، کرێم)', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/الحلاقة-وازالة-الشعر/اجهزة-ومنتجات-ازالة-الشعر', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/سەرتاشین-و-لابردنی-موو/ئامێر-و-بەرهەمی-لابردنی-موو', '5.3.7.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مكائن وادوات حلاقة رجالية (كهربائية، فرشاة، معجون)', 'مەکینە و کەرەستەی سەرتاشینی پیاوان (کارەبایی، فڵچە، مەعجوون)', 'المقتنيات-الشخصية-والصحة-والجمال/الجمال-والعناية-الشخصية/الحلاقة-وازالة-الشعر/مكائن-وادوات-حلاقة-رجالية', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/جوانکاری-و-چاودێری-کەسی/سەرتاشین-و-لابردنی-موو/مەکینە-و-کەرەستەی-سەرتاشینی-پیاوان', '5.3.7.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.3.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('المجوهرات والاكسسوارات', 'خشڵ و ئێکسسوارات', 'المقتنيات-الشخصية-والصحة-والجمال/المجوهرات-والاكسسوارات', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/خشڵ-و-ئێکسسوارات', '5.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مجوهرات ذهب وفضة', 'خشڵی زێڕ و زیو', 'المقتنيات-الشخصية-والصحة-والجمال/المجوهرات-والاكسسوارات/مجوهرات-ذهب-وفضة', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/خشڵ-و-ئێکسسوارات/خشڵی-زێڕ-و-زیو', '5.4.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مجوهرات الماس واحجار كريمة', 'خشڵی ئەڵماس و بەردی بەنرخ', 'المقتنيات-الشخصية-والصحة-والجمال/المجوهرات-والاكسسوارات/مجوهرات-الماس-واحجار-كريمة', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/خشڵ-و-ئێکسسوارات/خشڵی-ئەڵماس-و-بەردی-بەنرخ', '5.4.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('العناية الصحية والطبية', 'چاودێری تەندروستی و پزیشکی', 'المقتنيات-الشخصية-والصحة-والجمال/العناية-الصحية-والطبية', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/چاودێری-تەندروستی-و-پزیشکی', '5.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('العناية النسائية (فوط صحية، غسول مناطق حساسة)', 'چاودێری ژنان (فۆتەی تەندروستی، غەسولی ناوچە هەستیارەکان)', 'المقتنيات-الشخصية-والصحة-والجمال/العناية-الصحية-والطبية/العناية-النسائية', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/چاودێری-تەندروستی-و-پزیشکی/چاودێری-ژنان', '5.5.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('العناية بالفم والاسنان (فرش، معجون، غسول، خيط)', 'چاودێری دەم و ددان (فڵچە، مەعجوون، غەسول، دەزوو)', 'المقتنيات-الشخصية-والصحة-والجمال/العناية-الصحية-والطبية/العناية-بالفم-والاسنان', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/چاودێری-تەندروستی-و-پزیشکی/چاودێری-دەم-و-ددان', '5.5.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('فيتامينات ومكملات غذائية ورياضية', 'ڤیتامین و تەواوکەری خۆراکی و وەرزشی', 'المقتنيات-الشخصية-والصحة-والجمال/العناية-الصحية-والطبية/فيتامينات-ومكملات-غذائية-ورياضية', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/چاودێری-تەندروستی-و-پزیشکی/ڤیتامین-و-تەواوکەری-خۆراکی-و-وەرزشی', '5.5.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('منتجات تنحيف ورشاقة', 'بەرهەمی لاوازکردن و ڕێکی لەش', 'المقتنيات-الشخصية-والصحة-والجمال/العناية-الصحية-والطبية/منتجات-تنحيف-ورشاقة', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/چاودێری-تەندروستی-و-پزیشکی/بەرهەمی-لاوازکردن-و-ڕێکی-لەش', '5.5.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مستلزمات طبية شخصية (كمامات، معقمات)', 'پێداویستی پزیشکی کەسی (دەمامک، پاککەرەوە)', 'المقتنيات-الشخصية-والصحة-والجمال/العناية-الصحية-والطبية/مستلزمات-طبية-شخصية', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/چاودێری-تەندروستی-و-پزیشکی/پێداویستی-پزیشکی-کەسی', '5.5.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الصحة الجنسية (واقيات، مزلقات)', 'تەندروستی سێکسی (کۆندۆم، لووسكەر)', 'المقتنيات-الشخصية-والصحة-والجمال/العناية-الصحية-والطبية/الصحة-الجنسية', 'کەلوپەلی-کەسی-و-تەندروستی-و-جوانکاری/چاودێری-تەندروستی-و-پزیشکی/تەندروستی-سێکسی', '5.5.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '5.5'));

-- End of Level 1 Category: 5

-- Level 1 Category: 6 - المنزل والمطبخ والحديقة

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('المنزل والمطبخ والحديقة', 'ماڵ و چێشتخانە و باخچە', 'المنزل-والمطبخ-والحديقة', 'ماڵ-و-چێشتخانە-و-باخچە', '6', NULL);
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اثاث منزلي (تخم، غرف نوم، ميز طعام)', 'کەلوپەلی ماڵ (تەخم، ژووری نووستن، مێزی نانخواردن)', 'المنزل-والمطبخ-والحديقة/اثاث-منزلي', 'ماڵ-و-چێشتخانە-و-باخچە/کەلوپەلی-ماڵ', '6.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('غرف نوم كاملة ومفردة (اسرّة، خزانات ملابس، تسريحات)', 'ژووری نووستنی تەواو و تاک (جێگا، کەنتۆری جل، مێزی ئارایشت)', 'المنزل-والمطبخ-والحديقة/اثاث-منزلي/غرف-نوم-كاملة-ومفردة', 'ماڵ-و-چێشتخانە-و-باخچە/کەلوپەلی-ماڵ/ژووری-نووستنی-تەواو-و-تاک', '6.1.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تخم وصالات (قنفات، مجالس عربية)', 'تەخم و هۆڵ (قەنەفە، دیوەخانی عەرەبی)', 'المنزل-والمطبخ-والحديقة/اثاث-منزلي/تخم-وصالات', 'ماڵ-و-چێشتخانە-و-باخچە/کەلوپەلی-ماڵ/تەخم-و-هۆڵ', '6.1.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.1'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('طاولات وبوفيهات طعام', 'مێز و بۆفێی نانخواردن', 'المنزل-والمطبخ-والحديقة/اثاث-منزلي/طاولات-وبوفيهات-طعام', 'ماڵ-و-چێشتخانە-و-باخچە/کەلوپەلی-ماڵ/مێز-و-بۆفێی-نانخواردن', '6.1.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كراسي للاستخدام الداخلي (راسي طعام، كراسي مكتب، وغيرها)', 'کورسی بۆ بەکارهێنانی ناوماڵ (کورسی نانخواردن، کورسی نووسینگە، هتد)', 'المنزل-والمطبخ-والحديقة/اثاث-منزلي/كراسي-للاستخدام-الداخلي', 'ماڵ-و-چێشتخانە-و-باخچە/کەلوپەلی-ماڵ/کورسی-بۆ-بەکارهێنانی-ناوماڵ', '6.1.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مقاعد خارجية ومتخصصة (كراسي حدائق، كراسي اطفال، كراسي طعام عالية، وغيرها)', 'کورسی دەرەوە و تایبەتمەند (کورسی باخچە، کورسی منداڵ، کورسی نانخواردنی بەرز، هتد)', 'المنزل-والمطبخ-والحديقة/اثاث-منزلي/مقاعد-خارجية-ومتخصصة', 'ماڵ-و-چێشتخانە-و-باخچە/کەلوپەلی-ماڵ/کورسی-دەرەوە-و-تایبەتمەند', '6.1.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اثاث مطابخ (كاونترات، خزانات علوية وسفلية)', 'کەلوپەلی چێشتخانە (کاونتەر، کەنتۆری سەرەوە و خوارەوە)', 'المنزل-والمطبخ-والحديقة/اثاث-منزلي/اثاث-مطابخ', 'ماڵ-و-چێشتخانە-و-باخچە/کەلوپەلی-ماڵ/کەلوپەلی-چێشتخانە', '6.1.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اثاث حدائق وخارجي (طاولات، مظلات، ارجوحات)', 'کەلوپەلی باخچە و دەرەوە (مێز، چەتر، جۆلانێ)', 'المنزل-والمطبخ-والحديقة/اثاث-منزلي/اثاث-حدائق-وخارجي', 'ماڵ-و-چێشتخانە-و-باخچە/کەلوپەلی-ماڵ/کەلوپەلی-باخچە-و-دەرەوە', '6.1.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خزانات وحلول تخزين (ارفف، وحدات تلفزيون)', 'کەنتۆر و چارەسەری هەڵگرتن (ڕەفە، یەکەی تەلەفزیۆن)', 'المنزل-والمطبخ-والحديقة/اثاث-منزلي/خزانات-وحلول-تخزين', 'ماڵ-و-چێشتخانە-و-باخچە/کەلوپەلی-ماڵ/کەنتۆر-و-چارەسەری-هەڵگرتن', '6.1.8', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادوات ومعدات (عدة للبيت والحديقة)', 'ئامراز و کەرەستە (عەدە بۆ ماڵ و باخچە)', 'المنزل-والمطبخ-والحديقة/ادوات-ومعدات', 'ماڵ-و-چێشتخانە-و-باخچە/ئامراز-و-کەرەستە', '6.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عدة كهربائية يدوية (دريل، كوسرة، منشار كهربائي)', 'عەدەی کارەبایی دەستی (دڕێل، کۆسەرە، مشار کارەبایی)', 'المنزل-والمطبخ-والحديقة/ادوات-ومعدات/عدة-كهربائية-يدوية', 'ماڵ-و-چێشتخانە-و-باخچە/ئامراز-و-کەرەستە/عەدەی-کارەبایی-دەستی', '6.3.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عدة يدوية (مفكات، چاكوك، بلايس، سبانات، فيته)', 'عەدەی دەستی (دەسکی، چەکوش، پلایس، سپانە، فیتە)', 'المنزل-والمطبخ-والحديقة/ادوات-ومعدات/عدة-يدوية', 'ماڵ-و-چێشتخانە-و-باخچە/ئامراز-و-کەرەستە/عەدەی-دەستی', '6.3.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('طفايات حريق منزلية', 'ئاگرکوژێنەوەی ماڵان', 'المنزل-والمطبخ-والحديقة/ادوات-ومعدات/طفايات-حريق-منزلية', 'ماڵ-و-چێشتخانە-و-باخچە/ئامراز-و-کەرەستە/ئاگرکوژێنەوەی-ماڵان', '6.3.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.3'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مواد بناء وصيانة (للبيت)', 'کەرەستەی بیناسازی و چاککردنەوە (بۆ ماڵ)', 'المنزل-والمطبخ-والحديقة/مواد-بناء-وصيانة', 'ماڵ-و-چێشتخانە-و-باخچە/کەرەستەی-بیناسازی-و-چاککردنەوە', '6.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مستلزمات بناء (اسمنت، رمل، طابوق)', 'پێداویستی بیناسازی (چیمەنتۆ، لم، خشت)', 'المنزل-والمطبخ-والحديقة/مواد-بناء-وصيانة/مستلزمات-بناء', 'ماڵ-و-چێشتخانە-و-باخچە/کەرەستەی-بیناسازی-و-چاککردنەوە/پێداویستی-بیناسازی', '6.4.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ابواب وشبابيك', 'دەرگا و پەنجەرە', 'المنزل-والمطبخ-والحديقة/مواد-بناء-وصيانة/ابواب-وشبابيك', 'ماڵ-و-چێشتخانە-و-باخچە/کەرەستەی-بیناسازی-و-چاککردنەوە/دەرگا-و-پەنجەرە', '6.4.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اصباغ ولوازمها (فرش، رولات)', 'بۆیاخ و پێداویستییەکانی (فڵچە، ڕۆڵە)', 'المنزل-والمطبخ-والحديقة/مواد-بناء-وصيانة/اصباغ-ولوازمها', 'ماڵ-و-چێشتخانە-و-باخچە/کەرەستەی-بیناسازی-و-چاککردنەوە/بۆیاخ-و-پێداویستییەکانی', '6.4.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ديكور ومفروشات البيت', 'دیکۆر و مافوری ماڵ', 'المنزل-والمطبخ-والحديقة/ديكور-ومفروشات-البيت', 'ماڵ-و-چێشتخانە-و-باخچە/دیکۆر-و-مافوری-ماڵ', '6.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('سجاد وزوالي وموكيت وبردات (ستائر)', 'فەرش و مافور و مۆکێت و پەردە (ستارە)', 'المنزل-والمطبخ-والحديقة/ديكور-ومفروشات-البيت/سجاد-وزوالي-وموكيت-وبردات', 'ماڵ-و-چێشتخانە-و-باخچە/دیکۆر-و-مافوری-ماڵ/فەرش-و-مافور-و-مۆکێت-و-پەردە', '6.5.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('انارة و ثريات وديكورات اضاءة', 'ڕووناکی و سرەییا و دیکۆراتی ڕووناکی', 'المنزل-والمطبخ-والحديقة/ديكور-ومفروشات-البيت/انارة-و-ثريات-وديكورات-اضاءة', 'ماڵ-و-چێشتخانە-و-باخچە/دیکۆر-و-مافوری-ماڵ/ڕووناکی-و-سرەییا-و-دیکۆراتی-ڕووناکی', '6.5.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('لوحات وتحف فنية وانتيكات', 'تابلۆ و شتی هونەری و ئەنتیکە', 'المنزل-والمطبخ-والحديقة/ديكور-ومفروشات-البيت/لوحات-وتحف-فنية-وانتيكات', 'ماڵ-و-چێشتخانە-و-باخچە/دیکۆر-و-مافوری-ماڵ/تابلۆ-و-شتی-هونەری-و-ئەنتیکە', '6.5.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مفروشات (شراشف، بطانيات، كفرات، وجوه كوشات)', 'ڕایەخ (چەرچەف، بەتانی، کەوەری قەنەفە، ڕووی کوشن)', 'المنزل-والمطبخ-والحديقة/ديكور-ومفروشات-البيت/مفروشات', 'ماڵ-و-چێشتخانە-و-باخچە/دیکۆر-و-مافوری-ماڵ/ڕایەخ', '6.5.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معطرات جو وبخور للمنزل', 'بۆنخۆشکەری هەوا و بخوور بۆ ماڵ', 'المنزل-والمطبخ-والحديقة/ديكور-ومفروشات-البيت/معطرات-جو-وبخور-للمنزل', 'ماڵ-و-چێشتخانە-و-باخچە/دیکۆر-و-مافوری-ماڵ/بۆنخۆشکەری-هەوا-و-بخوور-بۆ-ماڵ', '6.5.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.5'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكسسوارات حمامات وديكور', 'ئێکسسواراتی حەمام و دیکۆر', 'المنزل-والمطبخ-والحديقة/ديكور-ومفروشات-البيت/اكسسوارات-حمامات-وديكور', 'ماڵ-و-چێشتخانە-و-باخچە/دیکۆر-و-مافوری-ماڵ/ئێکسسواراتی-حەمام-و-دیکۆر', '6.5.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ديكورات منزلية اخرى (مزهرية، اطارات الصور، وغيرها)', 'دیکۆراتی تری ماڵ (گوڵدان، چوارچێوەی وێنە، هتد)', 'المنزل-والمطبخ-والحديقة/ديكور-ومفروشات-البيت/ديكورات-منزلية-اخرى', 'ماڵ-و-چێشتخانە-و-باخچە/دیکۆر-و-مافوری-ماڵ/دیکۆراتی-تری-ماڵ', '6.5.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مستلزمات الحديقة والكراج', 'پێداویستی باخچە و گەراج', 'المنزل-والمطبخ-والحديقة/مستلزمات-الحديقة-والكراج', 'ماڵ-و-چێشتخانە-و-باخچە/پێداویستی-باخچە-و-گەراج', '6.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('نباتات وشتلات وبذور واشجار واسمدة', 'ڕووەک و نەمام و تۆو و دار و پەین', 'المنزل-والمطبخ-والحديقة/مستلزمات-الحديقة-والكراج/نباتات-وشتلات-وبذور-واشجار-واسمدة', 'ماڵ-و-چێشتخانە-و-باخچە/پێداویستی-باخچە-و-گەراج/ڕووەک-و-نەمام-و-تۆو-و-دار-و-پەین', '6.6.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معدات سقي ومرشات ماء (صوندات، رشاشات)', 'کەرەستەی ئاودان و پرژێنەری ئاو (سۆندە، ڕەشاش)', 'المنزل-والمطبخ-والحديقة/مستلزمات-الحديقة-والكراج/معدات-سقي-ومرشات-ماء', 'ماڵ-و-چێشتخانە-و-باخچە/پێداویستی-باخچە-و-گەراج/کەرەستەی-ئاودان-و-پرژێنەری-ئاو', '6.6.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادوات بستنة (مجرفة، مقص زرع)', 'ئامرازی باخداری (خاکەناز، مەقەستی ڕووەک)', 'المنزل-والمطبخ-والحديقة/مستلزمات-الحديقة-والكراج/ادوات-بستنة', 'ماڵ-و-چێشتخانە-و-باخچە/پێداویستی-باخچە-و-گەراج/ئامرازی-باخداری', '6.6.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معدات شوي ولوازم كشتات وسفرات ( فحم ،منقلة)', 'کەرەستەی برژاندن و پێداویستی گەشت و سەیران (خەڵووز، مەقەڵی)', 'المنزل-والمطبخ-والحديقة/مستلزمات-الحديقة-والكراج/معدات-شوي-ولوازم-كشتات-وسفرات', 'ماڵ-و-چێشتخانە-و-باخچە/پێداویستی-باخچە-و-گەراج/کەرەستەی-برژاندن-و-پێداویستی-گەشت-و-سەیران', '6.6.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مسابح منزلية وملحقاتها (نفخ، اطار معدني، فلاتر)', 'مەلەوانگەی ماڵان و پێداویستییەکانی (فووکردن، چوارچێوەی کانزایی، فلتەر)', 'المنزل-والمطبخ-والحديقة/مستلزمات-الحديقة-والكراج/مسابح-منزلية-وملحقاتها', 'ماڵ-و-چێشتخانە-و-باخچە/پێداویستی-باخچە-و-گەراج/مەلەوانگەی-ماڵان-و-پێداویستییەکانی', '6.6.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادوات المطبخ (غير كهربائية)', 'ئامرازی چێشتخانە (ناکارەبایی)', 'المنزل-والمطبخ-والحديقة/ادوات-المطبخ', 'ماڵ-و-چێشتخانە-و-باخچە/ئامرازی-چێشتخانە', '6.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اواني الطهي (مقالي، صواني فرن، جدور)', 'قاپوقاچاخی چێشتلێنان (تاوە، سینی فڕن، مەنجەڵ)', 'المنزل-والمطبخ-والحديقة/ادوات-المطبخ/اواني-الطهي', 'ماڵ-و-چێشتخانە-و-باخچە/ئامرازی-چێشتخانە/قاپوقاچاخی-چێشتلێنان', '6.7.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.7'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادوات المائدة والتقديم (اطباق، اكواب، ملاعق، سكاكين)', 'کەرەستەی سفرە و پێشکەشکردن (قاپ، پەرداخ، کەوچک، چەقۆ)', 'المنزل-والمطبخ-والحديقة/ادوات-المطبخ/ادوات-المائدة-والتقديم', 'ماڵ-و-چێشتخانە-و-باخچە/ئامرازی-چێشتخانە/کەرەستەی-سفرە-و-پێشکەشکردن', '6.7.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادوات تحضير الطعام والخبز والحلويات (مبراشة، مصفى، قوالب كيك ومعجنات وحلويات)', 'ئامرازی ئامادەکردنی خواردن و نان و شیرینی (ڕەندە، پاڵاوتە، قاڵبی کێک و هەویرکاری و شیرینی)', 'المنزل-والمطبخ-والحديقة/ادوات-المطبخ/ادوات-تحضير-الطعام-والخبز-والحلويات', 'ماڵ-و-چێشتخانە-و-باخچە/ئامرازی-چێشتخانە/ئامرازی-ئامادەکردنی-خواردن-و-نان-و-شیرینی', '6.7.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادوات تحضير المشروبات (قوري، دلة، ادوات قهوة وشاي مخصصة)', 'ئامرازی ئامادەکردنی خواردنەوە (قۆری، دۆڵکە، ئامرازی تایبەتی قاوە و چا)', 'المنزل-والمطبخ-والحديقة/ادوات-المطبخ/ادوات-تحضير-المشروبات', 'ماڵ-و-چێشتخانە-و-باخچە/ئامرازی-چێشتخانە/ئامرازی-ئامادەکردنی-خواردنەوە', '6.7.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('علب حفظ الطعام والمشروبات (ترامس، حافظات طعام)', 'دەفری هەڵگرتنی خواردن و خواردنەوە (تەرمۆس، حافیزەی خواردن)', 'المنزل-والمطبخ-والحديقة/ادوات-المطبخ/علب-حفظ-الطعام-والمشروبات', 'ماڵ-و-چێشتخانە-و-باخچە/ئامرازی-چێشتخانە/دەفری-هەڵگرتنی-خواردن-و-خواردنەوە', '6.7.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ملحقات وادوات مطبخ اخرى (فتاحات، قشارات، ادوات قياس، وغيرها)', 'پێداویستی و ئامرازی تری چێشتخانە (فەتاحە، قاشەر، ئامرازی پێوان، هتد)', 'المنزل-والمطبخ-والحديقة/ادوات-المطبخ/ملحقات-وادوات-مطبخ-اخرى', 'ماڵ-و-چێشتخانە-و-باخچە/ئامرازی-چێشتخانە/پێداویستی-و-ئامرازی-تری-چێشتخانە', '6.7.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('امن وحماية البيت', 'ئاسایش و پاراستنی ماڵ', 'المنزل-والمطبخ-والحديقة/امن-وحماية-البيت', 'ماڵ-و-چێشتخانە-و-باخچە/ئاسایش-و-پاراستنی-ماڵ', '6.8', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('انظمة انذار للبيت (حرامي، حريق)', 'سیستەمی ئاگادارکەرەوە بۆ ماڵ (دز، ئاگر)', 'المنزل-والمطبخ-والحديقة/امن-وحماية-البيت/انظمة-انذار-للبيت', 'ماڵ-و-چێشتخانە-و-باخچە/ئاسایش-و-پاراستنی-ماڵ/سیستەمی-ئاگادارکەرەوە-بۆ-ماڵ', '6.8.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اقفال وكيلونات وحماية شبابيك وابواب', 'قوفڵ و کلیل و پاراستنی پەنجەرە و دەرگا', 'المنزل-والمطبخ-والحديقة/امن-وحماية-البيت/اقفال-وكيلونات-وحماية-شبابيك-وابواب', 'ماڵ-و-چێشتخانە-و-باخچە/ئاسایش-و-پاراستنی-ماڵ/قوفڵ-و-کلیل-و-پاراستنی-پەنجەرە-و-دەرگا', '6.8.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معدات سلامة منزلية (سلم، صندوق اسعافات)', 'کەرەستەی سەلامەتی ماڵ (پەیژە، سندوقی فریاگوزاری)', 'المنزل-والمطبخ-والحديقة/امن-وحماية-البيت/معدات-سلامة-منزلية', 'ماڵ-و-چێشتخانە-و-باخچە/ئاسایش-و-پاراستنی-ماڵ/کەرەستەی-سەلامەتی-ماڵ', '6.8.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('متفرقات للمنزل والتراثيات', 'شتی جۆراوجۆر بۆ ماڵ و کەلەپوور', 'المنزل-والمطبخ-والحديقة/متفرقات-للمنزل-والتراثيات', 'ماڵ-و-چێشتخانە-و-باخچە/شتی-جۆراوجۆر-بۆ-ماڵ-و-کەلەپوور', '6.9', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('زينة وهدايا للمناسبات والاعياد', 'ڕازاندنەوە و دیاری بۆ بۆنە و جەژنەکان', 'المنزل-والمطبخ-والحديقة/متفرقات-للمنزل-والتراثيات/زينة-وهدايا-للمناسبات-والاعياد', 'ماڵ-و-چێشتخانە-و-باخچە/شتی-جۆراوجۆر-بۆ-ماڵ-و-کەلەپوور/ڕازاندنەوە-و-دیاری-بۆ-بۆنە-و-جەژنەکان', '6.9.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادوات ضيافة تراثية (استكانات، فناجين قهوة)', 'کەرەستەی میوانداری کەلەپووری (پیاڵە، فنجانی قاوە)', 'المنزل-والمطبخ-والحديقة/متفرقات-للمنزل-والتراثيات/ادوات-ضيافة-تراثية', 'ماڵ-و-چێشتخانە-و-باخچە/شتی-جۆراوجۆر-بۆ-ماڵ-و-کەلەپوور/کەرەستەی-میوانداری-کەلەپووری', '6.9.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مقتنيات تراثية وفلكلورية', 'شتی کەلەپووری و فۆلکلۆری', 'المنزل-والمطبخ-والحديقة/متفرقات-للمنزل-والتراثيات/مقتنيات-تراثية-وفلكلورية', 'ماڵ-و-چێشتخانە-و-باخچە/شتی-جۆراوجۆر-بۆ-ماڵ-و-کەلەپوور/شتی-کەلەپووری-و-فۆلکلۆری', '6.9.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('منظفات وادوات تنظيف البيت', 'پاککەرەوە و ئامرازی پاککردنەوەی ماڵ', 'المنزل-والمطبخ-والحديقة/منظفات-وادوات-تنظيف-البيت', 'ماڵ-و-چێشتخانە-و-باخچە/پاککەرەوە-و-ئامرازی-پاککردنەوەی-ماڵ', '6.10', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('منظفات منزلية', 'پاککەرەوەی ماڵ', 'المنزل-والمطبخ-والحديقة/منظفات-وادوات-تنظيف-البيت/منظفات-منزلية', 'ماڵ-و-چێشتخانە-و-باخچە/پاککەرەوە-و-ئامرازی-پاککردنەوەی-ماڵ/پاککەرەوەی-ماڵ', '6.10.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مبيدات حشرية وقوارض', 'دەرمانی مێرووکوژ و قرتێنەر', 'المنزل-والمطبخ-والحديقة/منظفات-وادوات-تنظيف-البيت/مبيدات-حشرية-وقوارض', 'ماڵ-و-چێشتخانە-و-باخچە/پاککەرەوە-و-ئامرازی-پاککردنەوەی-ماڵ/دەرمانی-مێرووکوژ-و-قرتێنەر', '6.10.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادوات تنظيف يدوية', 'ئامرازی پاککردنەوەی دەستی', 'المنزل-والمطبخ-والحديقة/منظفات-وادوات-تنظيف-البيت/ادوات-تنظيف-يدوية', 'ماڵ-و-چێشتخانە-و-باخچە/پاککەرەوە-و-ئامرازی-پاککردنەوەی-ماڵ/ئامرازی-پاککردنەوەی-دەستی', '6.10.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('صابون ومعقمات لليدين', 'سابوون و پاککەرەوەی دەست', 'المنزل-والمطبخ-والحديقة/منظفات-وادوات-تنظيف-البيت/صابون-ومعقمات-لليدين', 'ماڵ-و-چێشتخانە-و-باخچە/پاککەرەوە-و-ئامرازی-پاککردنەوەی-ماڵ/سابوون-و-پاککەرەوەی-دەست', '6.10.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مستلزمات غسيل الملابس', 'پێداویستی جل شوشتن', 'المنزل-والمطبخ-والحديقة/منظفات-وادوات-تنظيف-البيت/مستلزمات-غسيل-الملابس', 'ماڵ-و-چێشتخانە-و-باخچە/پاککەرەوە-و-ئامرازی-پاککردنەوەی-ماڵ/پێداویستی-جل-شوشتن', '6.10.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مستلزمات غسيل الاطباق', 'پێداویستی قاپ شوشتن', 'المنزل-والمطبخ-والحديقة/منظفات-وادوات-تنظيف-البيت/مستلزمات-غسيل-الاطباق', 'ماڵ-و-چێشتخانە-و-باخچە/پاککەرەوە-و-ئامرازی-پاککردنەوەی-ماڵ/پێداویستی-قاپ-شوشتن', '6.10.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.10'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('سلات واكياس مهملات', 'سەبەتە و کیسی خۆڵ', 'المنزل-والمطبخ-والحديقة/منظفات-وادوات-تنظيف-البيت/سلات-واكياس-مهملات', 'ماڵ-و-چێشتخانە-و-باخچە/پاککەرەوە-و-ئامرازی-پاککردنەوەی-ماڵ/سەبەتە-و-کیسی-خۆڵ', '6.10.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '6.10'));

-- End of Level 1 Category: 6

-- Level 1 Category: 7 - قطع الغيار والاكسسوارات للمركبات (الادوات الاحتياطية والكماليات)

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قطع الغيار والاكسسوارات للمركبات (الادوات الاحتياطية والكماليات)', 'پارچەی یەدەگ و ئێکسسواراتی ئۆتۆمبێل (کەرەستەی یەدەگ و جوانکاری)', 'قطع-الغيار-والاكسسوارات-للمركبات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل', '7', NULL);
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قطع غيار السيارات (ادوات احتياطية للسيارات)', 'پارچەی یەدەگی ئۆتۆمبێل (کەرەستەی یەدەگی ئۆتۆمبێل)', 'قطع-الغيار-والاكسسوارات-للمركبات/قطع-غيار-السيارات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگی-ئۆتۆمبێل', '7.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('المحرك واجزاؤه (مكينة وكير)', 'بزوێنەر و پارچەکانی (مەکینە و گێڕ)', 'قطع-الغيار-والاكسسوارات-للمركبات/قطع-غيار-السيارات/المحرك-واجزاؤه', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگی-ئۆتۆمبێل/بزوێنەر-و-پارچەکانی', '7.1.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الشاصي والبريكات', 'شاسی و برێکەکان', 'قطع-الغيار-والاكسسوارات-للمركبات/قطع-غيار-السيارات/الشاصي-والبريكات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگی-ئۆتۆمبێل/شاسی-و-برێکەکان', '7.1.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('البودي والهيكل واجزاؤه (دعاميات، بنيد، جاملغ)', 'بۆدی و هەیکەل و پارچەکانی (دعامە، بۆنید، چەمەلۆغ)', 'قطع-الغيار-والاكسسوارات-للمركبات/قطع-غيار-السيارات/البودي-والهيكل-واجزاؤه', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگی-ئۆتۆمبێل/بۆدی-و-هەیکەل-و-پارچەکانی', '7.1.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('انظمة العادم والتبريد (الاكزوز ،راديتر، مروحة)', 'سیستەمی گازدەر و فێنککەرەوە (ئەگزۆز، ڕادێتەر، پەروانە)', 'قطع-الغيار-والاكسسوارات-للمركبات/قطع-غيار-السيارات/انظمة-العادم-والتبريد', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگی-ئۆتۆمبێل/سیستەمی-گازدەر-و-فێنککەرەوە', '7.1.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قطع كهرباء والكترونيات السيارة (فيوزات، حساسات، كمبيوتر سيارة)', 'پارچەی کارەبا و ئەلیکترۆنیاتی ئۆتۆمبێل (فیوز، حەساس، کۆمپیوتەری سەیارە)', 'قطع-الغيار-والاكسسوارات-للمركبات/قطع-غيار-السيارات/قطع-كهرباء-والكترونيات-السيارة', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگی-ئۆتۆمبێل/پارچەی-کارەبا-و-ئەلیکترۆنیاتی-ئۆتۆمبێل', '7.1.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('(قطع ديكور داخلي، فلاتر، وغيرها) قطع غيار سيارات متنوعة', '(پارچەی دیکۆری ناوەوە، فلتەر، هتد) پارچەی یەدەگی جۆراوجۆری ئۆتۆمبێل', 'قطع-الغيار-والاكسسوارات-للمركبات/قطع-غيار-السيارات/قطع-غيار-سيارات-متنوعة', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگی-ئۆتۆمبێل/پارچەی-یەدەگی-جۆراوجۆری-ئۆتۆمبێل', '7.1.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اطارات وعجلات للمركبات (تايرات ووويلات)', 'تایە و ویلی ئۆتۆمبێل', 'قطع-الغيار-والاكسسوارات-للمركبات/اطارات-وعجلات-للمركبات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/تایە-و-ویلی-ئۆتۆمبێل', '7.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تايرات سيارات ورنجات (ويلات)', 'تایەی ئۆتۆمبێل و ڕینگ (ویل)', 'قطع-الغيار-والاكسسوارات-للمركبات/اطارات-وعجلات-للمركبات/تايرات-سيارات-ورنجات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/تایە-و-ویلی-ئۆتۆمبێل/تایەی-ئۆتۆمبێل-و-ڕینگ', '7.2.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تايرات شاحنات ومعدات ثقيلة', 'تایەی بارهەڵگر و ئامێری قورس', 'قطع-الغيار-والاكسسوارات-للمركبات/اطارات-وعجلات-للمركبات/تايرات-شاحنات-ومعدات-ثقيلة', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/تایە-و-ویلی-ئۆتۆمبێل/تایەی-بارهەڵگر-و-ئامێری-قورس', '7.2.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تايرات واطارات دراجات نارية وهوائية', 'تایە و چوارچێوەی ماتۆڕسکیل و پاسکیل', 'قطع-الغيار-والاكسسوارات-للمركبات/اطارات-وعجلات-للمركبات/تايرات-واطارات-دراجات-نارية-وهوائية', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/تایە-و-ویلی-ئۆتۆمبێل/تایە-و-چوارچێوەی-ماتۆڕسکیل-و-پاسکیل', '7.2.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('زيوت ومواد تشحيم للمركبات', 'ڕۆن و ماددەی چەورکردن بۆ ئۆتۆمبێل', 'قطع-الغيار-والاكسسوارات-للمركبات/زيوت-ومواد-تشحيم-للمركبات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/ڕۆن-و-ماددەی-چەورکردن-بۆ-ئۆتۆمبێل', '7.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('زيوت محرك ودهون للمركبات (سيارات، دراجات، شاحنات)', 'ڕۆنی بزوێنەر و چەوری بۆ ئۆتۆمبێل (سەیارە، ماتۆڕ، بارهەڵگر)', 'قطع-الغيار-والاكسسوارات-للمركبات/زيوت-ومواد-تشحيم-للمركبات/زيوت-محرك-ودهون-للمركبات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/ڕۆن-و-ماددەی-چەورکردن-بۆ-ئۆتۆمبێل/ڕۆنی-بزوێنەر-و-چەوری-بۆ-ئۆتۆمبێل', '7.3.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ماي راديتر ومواد تبريد للمركبات', 'ئاوی ڕادێتەر و ماددەی فێنککەرەوە بۆ ئۆتۆمبێل', 'قطع-الغيار-والاكسسوارات-للمركبات/زيوت-ومواد-تشحيم-للمركبات/ماي-راديتر-ومواد-تبريد-للمركبات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/ڕۆن-و-ماددەی-چەورکردن-بۆ-ئۆتۆمبێل/ئاوی-ڕادێتەر-و-ماددەی-فێنککەرەوە-بۆ-ئۆتۆمبێل', '7.3.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مواد تنظيف وصيانة كيمياوية للمركبات (منظف انجكتر، واكس)', 'ماددەی پاککەرەوە و سیانەی کیمیایی بۆ ئۆتۆمبێل (پاککەرەوەی ئینجێکتەر، واکس)', 'قطع-الغيار-والاكسسوارات-للمركبات/زيوت-ومواد-تشحيم-للمركبات/مواد-تنظيف-وصيانة-كيمياوية-للمركبات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/ڕۆن-و-ماددەی-چەورکردن-بۆ-ئۆتۆمبێل/ماددەی-پاککەرەوە-و-سیانەی-کیمیایی-بۆ-ئۆتۆمبێل', '7.3.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكسسوارات وكماليات السيارات', 'ئێکسسوارات و جوانکاری ئۆتۆمبێل', 'قطع-الغيار-والاكسسوارات-للمركبات/اكسسوارات-وكماليات-السيارات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/ئێکسسوارات-و-جوانکاری-ئۆتۆمبێل', '7.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اغطية وجادر للسيارة', 'بەرگ و چادر بۆ ئۆتۆمبێل', 'قطع-الغيار-والاكسسوارات-للمركبات/اكسسوارات-وكماليات-السيارات/اغطية-وجادر-للسيارة', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/ئێکسسوارات-و-جوانکاری-ئۆتۆمبێل/بەرگ-و-چادر-بۆ-ئۆتۆمبێل', '7.4.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ملصقات وزينة خارجية للسيارة', 'لۆگۆ و جوانی دەرەوەی ئۆتۆمبێل', 'قطع-الغيار-والاكسسوارات-للمركبات/اكسسوارات-وكماليات-السيارات/ملصقات-وزينة-خارجية-للسيارة', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/ئێکسسوارات-و-جوانکاری-ئۆتۆمبێل/لۆگۆ-و-جوانی-دەرەوەی-ئۆتۆمبێل', '7.4.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.4'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اضواء اضافية للسيارة (لايتات ولدات)', 'ڕووناکی زیادە بۆ ئۆتۆمبێل (لایت و لید)', 'قطع-الغيار-والاكسسوارات-للمركبات/اكسسوارات-وكماليات-السيارات/اضواء-اضافية-للسيارة', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/ئێکسسوارات-و-جوانکاری-ئۆتۆمبێل/ڕووناکی-زیادە-بۆ-ئۆتۆمبێل', '7.4.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('سلة سقف وحمالات للسيارة', 'سەبەتەی سەقف و هەڵگر بۆ ئۆتۆمبێل', 'قطع-الغيار-والاكسسوارات-للمركبات/اكسسوارات-وكماليات-السيارات/سلة-سقف-وحمالات-للسيارة', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/ئێکسسوارات-و-جوانکاری-ئۆتۆمبێل/سەبەتەی-سەقف-و-هەڵگر-بۆ-ئۆتۆمبێل', '7.4.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تلبيس كشنات للسيارة (اغطية مقاعد)', 'ڕووپۆشی کوشن بۆ ئۆتۆمبێل (بەرگی کورسی)', 'قطع-الغيار-والاكسسوارات-للمركبات/اكسسوارات-وكماليات-السيارات/تلبيس-كشنات-للسيارة', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/ئێکسسوارات-و-جوانکاری-ئۆتۆمبێل/ڕووپۆشی-کوشن-بۆ-ئۆتۆمبێل', '7.4.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('دوسات وارضيات داخلية للسيارة', 'دۆسە و زەوی ناوەوەی ئۆتۆمبێل', 'قطع-الغيار-والاكسسوارات-للمركبات/اكسسوارات-وكماليات-السيارات/دوسات-وارضيات-داخلية-للسيارة', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/ئێکسسوارات-و-جوانکاری-ئۆتۆمبێل/دۆسە-و-زەوی-ناوەوەی-ئۆتۆمبێل', '7.4.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معطرات واكسسوارات زينة داخلية للسيارة', 'بۆنخۆشکەر و ئێکسسواراتی جوانی ناوەوەی ئۆتۆمبێل', 'قطع-الغيار-والاكسسوارات-للمركبات/اكسسوارات-وكماليات-السيارات/معطرات-واكسسوارات-زينة-داخلية-للسيارة', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/ئێکسسوارات-و-جوانکاری-ئۆتۆمبێل/بۆنخۆشکەر-و-ئێکسسواراتی-جوانی-ناوەوەی-ئۆتۆمبێل', '7.4.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكسسوارات موبايل للسيارة (ستاند، شاحن سيارة)', 'ئێکسسواراتی مۆبایل بۆ ئۆتۆمبێل (ستاند، شەحنی سەیارە)', 'قطع-الغيار-والاكسسوارات-للمركبات/اكسسوارات-وكماليات-السيارات/اكسسوارات-موبايل-للسيارة', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/ئێکسسوارات-و-جوانکاری-ئۆتۆمبێل/ئێکسسواراتی-مۆبایل-بۆ-ئۆتۆمبێل', '7.4.8', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('انظمة الصوت والترفيه للمركبات', 'سیستەمی دەنگ و کات بەسەربردن بۆ ئۆتۆمبێل', 'قطع-الغيار-والاكسسوارات-للمركبات/انظمة-الصوت-والترفيه-للمركبات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/سیستەمی-دەنگ-و-کات-بەسەربردن-بۆ-ئۆتۆمبێل', '7.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مسجلات وانظمة صوت للسيارات والمركبات', 'مسەجەل و سیستەمی دەنگ بۆ ئۆتۆمبێل و هۆکارەکانی گواستنەوە', 'قطع-الغيار-والاكسسوارات-للمركبات/انظمة-الصوت-والترفيه-للمركبات/مسجلات-وانظمة-صوت-للسيارات-والمركبات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/سیستەمی-دەنگ-و-کات-بەسەربردن-بۆ-ئۆتۆمبێل/مسەجەل-و-سیستەمی-دەنگ-بۆ-ئۆتۆمبێل-و-هۆکارەکانی-گواستنەوە', '7.5.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('شاشات وانظمة ملاحة للمركبات (GPS)', 'شاشە و سیستەمی ڕێدۆزی بۆ ئۆتۆمبێل (GPS)', 'قطع-الغيار-والاكسسوارات-للمركبات/انظمة-الصوت-والترفيه-للمركبات/شاشات-وانظمة-ملاحة-للمركبات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/سیستەمی-دەنگ-و-کات-بەسەربردن-بۆ-ئۆتۆمبێل/شاشە-و-سیستەمی-ڕێدۆزی-بۆ-ئۆتۆمبێل', '7.5.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('سماعات ومضخمات صوت للمركبات', 'بیستۆک و گەورەکەری دەنگ بۆ ئۆتۆمبێل', 'قطع-الغيار-والاكسسوارات-للمركبات/انظمة-الصوت-والترفيه-للمركبات/سماعات-ومضخمات-صوت-للمركبات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/سیستەمی-دەنگ-و-کات-بەسەربردن-بۆ-ئۆتۆمبێل/بیستۆک-و-گەورەکەری-دەنگ-بۆ-ئۆتۆمبێل', '7.5.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.5'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('انظمة الامان والحماية للمركبات', 'سیستەمی ئاسایش و پاراستن بۆ ئۆتۆمبێل', 'قطع-الغيار-والاكسسوارات-للمركبات/انظمة-الامان-والحماية-للمركبات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/سیستەمی-ئاسایش-و-پاراستن-بۆ-ئۆتۆمبێل', '7.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة انذار ومانع سرقة للمركبات', 'ئامێری ئاگادارکەرەوە و دژە دزی بۆ ئۆتۆمبێل', 'قطع-الغيار-والاكسسوارات-للمركبات/انظمة-الامان-والحماية-للمركبات/اجهزة-انذار-ومانع-سرقة-للمركبات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/سیستەمی-ئاسایش-و-پاراستن-بۆ-ئۆتۆمبێل/ئامێری-ئاگادارکەرەوە-و-دژە-دزی-بۆ-ئۆتۆمبێل', '7.6.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كاميرات وحساسات للمركبات واجهزة تتبع', 'کامێرا و حەساس بۆ ئۆتۆمبێل و ئامێری شوێنپێهەڵگرتن', 'قطع-الغيار-والاكسسوارات-للمركبات/انظمة-الامان-والحماية-للمركبات/كاميرات-وحساسات-للمركبات-واجهزة-تتبع', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/سیستەمی-ئاسایش-و-پاراستن-بۆ-ئۆتۆمبێل/کامێرا-و-حەساس-بۆ-ئۆتۆمبێل-و-ئامێری-شوێنپێهەڵگرتن', '7.6.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اقفال اضافية وحماية للمركبات', 'قوفڵی زیادە و پاراستن بۆ ئۆتۆمبێل', 'قطع-الغيار-والاكسسوارات-للمركبات/انظمة-الامان-والحماية-للمركبات/اقفال-اضافية-وحماية-للمركبات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/سیستەمی-ئاسایش-و-پاراستن-بۆ-ئۆتۆمبێل/قوفڵی-زیادە-و-پاراستن-بۆ-ئۆتۆمبێل', '7.6.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادوات ومعدات صيانة المركبات', 'ئامراز و کەرەستەی سیانەی ئۆتۆمبێل', 'قطع-الغيار-والاكسسوارات-للمركبات/ادوات-ومعدات-صيانة-المركبات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/ئامراز-و-کەرەستەی-سیانەی-ئۆتۆمبێل', '7.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عدة يدوية للمركبات (سبانات، مفكات، جيك)', 'عەدەی دەستی بۆ ئۆتۆمبێل (سپانە، دەسکی، جەک)', 'قطع-الغيار-والاكسسوارات-للمركبات/ادوات-ومعدات-صيانة-المركبات/عدة-يدوية-للمركبات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/ئامراز-و-کەرەستەی-سیانەی-ئۆتۆمبێل/عەدەی-دەستی-بۆ-ئۆتۆمبێل', '7.7.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة فحص وتشخيص اعطال المركبات', 'ئامێری پشکنین و دەستنیشانکردنی کێشەی ئۆتۆمبێل', 'قطع-الغيار-والاكسسوارات-للمركبات/ادوات-ومعدات-صيانة-المركبات/اجهزة-فحص-وتشخيص-اعطال-المركبات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/ئامراز-و-کەرەستەی-سیانەی-ئۆتۆمبێل/ئامێری-پشکنین-و-دەستنیشانکردنی-کێشەی-ئۆتۆمبێل', '7.7.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معدات ورش وتصليح للمركبات (كمبريسر هواء)', 'کەرەستەی وەرشە و چاککردنەوە بۆ ئۆتۆمبێل (کۆمپرێسەری هەوا)', 'قطع-الغيار-والاكسسوارات-للمركبات/ادوات-ومعدات-صيانة-المركبات/معدات-ورش-وتصليح-للمركبات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/ئامراز-و-کەرەستەی-سیانەی-ئۆتۆمبێل/کەرەستەی-وەرشە-و-چاککردنەوە-بۆ-ئۆتۆمبێل', '7.7.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قطع غيار واكسسوارات الدراجات النارية', 'پارچەی یەدەگ و ئێکسسواراتی ماتۆڕسکیل', 'قطع-الغيار-والاكسسوارات-للمركبات/قطع-غيار-واكسسوارات-الدراجات-النارية', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگ-و-ئێکسسواراتی-ماتۆڕسکیل', '7.8', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قطع محرك وكير للدراجات النارية', 'پارچەی بزوێنەر و گێڕ بۆ ماتۆڕسکیل', 'قطع-الغيار-والاكسسوارات-للمركبات/قطع-غيار-واكسسوارات-الدراجات-النارية/قطع-محرك-وكير-للدراجات-النارية', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگ-و-ئێکسسواراتی-ماتۆڕسکیل/پارچەی-بزوێنەر-و-گێڕ-بۆ-ماتۆڕسکیل', '7.8.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.8'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكسسوارات وكماليات الدراجات النارية (خوذ، ملابس حماية، زينة)', 'ئێکسسوارات و جوانکاری ماتۆڕسکیل (کڵاو، جلوبەرگی پاراستن، جوانی)', 'قطع-الغيار-والاكسسوارات-للمركبات/قطع-غيار-واكسسوارات-الدراجات-النارية/اكسسوارات-وكماليات-الدراجات-النارية', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگ-و-ئێکسسواراتی-ماتۆڕسکیل/ئێکسسوارات-و-جوانکاری-ماتۆڕسکیل', '7.8.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قطع غيار واكسسوارات الشاحنات والمعدات الثقيلة', 'پارچەی یەدەگ و ئێکسسواراتی بارهەڵگر و ئامێری قورس', 'قطع-الغيار-والاكسسوارات-للمركبات/قطع-غيار-واكسسوارات-الشاحنات-والمعدات-الثقيلة', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگ-و-ئێکسسواراتی-بارهەڵگر-و-ئامێری-قورس', '7.9', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قطع محركات كبيرة للشاحنات والمعدات', 'پارچەی بزوێنەری گەورە بۆ بارهەڵگر و ئامێرەکان', 'قطع-الغيار-والاكسسوارات-للمركبات/قطع-غيار-واكسسوارات-الشاحنات-والمعدات-الثقيلة/قطع-محركات-كبيرة-للشاحنات-والمعدات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگ-و-ئێکسسواراتی-بارهەڵگر-و-ئامێری-قورس/پارچەی-بزوێنەری-گەورە-بۆ-بارهەڵگر-و-ئامێرەکان', '7.9.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('انظمة هيدروليك للشاحنات والمعدات', 'سیستەمی هایدرۆلیک بۆ بارهەڵگر و ئامێرەکان', 'قطع-الغيار-والاكسسوارات-للمركبات/قطع-غيار-واكسسوارات-الشاحنات-والمعدات-الثقيلة/انظمة-هيدروليك-للشاحنات-والمعدات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگ-و-ئێکسسواراتی-بارهەڵگر-و-ئامێری-قورس/سیستەمی-هایدرۆلیک-بۆ-بارهەڵگر-و-ئامێرەکان', '7.9.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معدات خاصة واكسسوارات للشاحنات', 'کەرەستەی تایبەت و ئێکسسوارات بۆ بارهەڵگرەکان', 'قطع-الغيار-والاكسسوارات-للمركبات/قطع-غيار-واكسسوارات-الشاحنات-والمعدات-الثقيلة/معدات-خاصة-واكسسوارات-للشاحنات', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگ-و-ئێکسسواراتی-بارهەڵگر-و-ئامێری-قورس/کەرەستەی-تایبەت-و-ئێکسسوارات-بۆ-بارهەڵگرەکان', '7.9.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مستلزمات القوارب والمركبات البحرية', 'پێداویستی بەلەم و ئۆتۆمبێلی دەریایی', 'قطع-الغيار-والاكسسوارات-للمركبات/مستلزمات-القوارب-والمركبات-البحرية', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پێداویستی-بەلەم-و-ئۆتۆمبێلی-دەریایی', '7.10', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قطع غيار محركات بحرية (مكائن بحرية)', 'پارچەی یەدەگی بزوێنەری دەریایی (مەکینەی دەریایی)', 'قطع-الغيار-والاكسسوارات-للمركبات/مستلزمات-القوارب-والمركبات-البحرية/قطع-غيار-محركات-بحرية', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پێداویستی-بەلەم-و-ئۆتۆمبێلی-دەریایی/پارچەی-یەدەگی-بزوێنەری-دەریایی', '7.10.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معدات سلامة وانقاذ بحري (سترات نجاة)', 'کەرەستەی سەلامەتی و ڕزگارکردنی دەریایی (چاکەتی ڕزگاربوون)', 'قطع-الغيار-والاكسسوارات-للمركبات/مستلزمات-القوارب-والمركبات-البحرية/معدات-سلامة-وانقاذ-بحري', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پێداویستی-بەلەم-و-ئۆتۆمبێلی-دەریایی/کەرەستەی-سەلامەتی-و-ڕزگارکردنی-دەریایی', '7.10.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكسسوارات بحرية (حبال، مراسي)', 'ئێکسسواراتی دەریایی ( گوریس، لەنگەر)', 'قطع-الغيار-والاكسسوارات-للمركبات/مستلزمات-القوارب-والمركبات-البحرية/اكسسوارات-بحرية', 'پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پێداویستی-بەلەم-و-ئۆتۆمبێلی-دەریایی/ئێکسسواراتی-دەریایی', '7.10.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '7.10'));

-- End of Level 1 Category: 7

-- Level 1 Category: 8 - الالكترونيات والاجهزة الرقمية

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الالكترونيات والاجهزة الرقمية', 'ئەلیکترۆنیات و ئامێری دیجیتاڵی', 'الالكترونيات-والاجهزة-الرقمية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی', '8', NULL);

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('موبايلات واجهزة لوحية (تابلت)', 'مۆبایل و تابلێت', 'الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت', '8.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('موبايلات ذكية (ايفون، سامسونج، شاومي، الخ)', 'مۆبایلی زیرەک (ئایفۆن، سامسۆنگ، شیاومی، هتد)', 'الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/موبايلات-ذكية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/مۆبایلی-زیرەک', '8.1.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تابلت وايباد', 'تابلێت و ئایپاد', 'الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/تابلت-وايباد', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/تابلێت-و-ئایپاد', '8.1.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ساعات ذكية ورياضية (ابل ووتش، سامسونج جير، الخ)', 'کاتژمێری زیرەک و وەرزشی (ئەپڵ وۆچ، سامسۆنگ گیێر، هتد)', 'الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/ساعات-ذكية-ورياضية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/کاتژمێری-زیرەک-و-وەرزشی', '8.1.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكسسوارات موبايلات وتابلت وساعات ذكية', 'ئێکسسواراتی مۆبایل و تابلێت و کاتژمێری زیرەک', 'الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/اكسسوارات-موبايلات-وتابلت-وساعات-ذكية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/ئێکسسواراتی-مۆبایل-و-تابلێت-و-کاتژمێری-زیرەک', '8.1.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كفرات وحافظات وجلاد حماية', 'کەڤەر و حافیزە و بەرگی پاراستن', 'الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/اكسسوارات-موبايلات-وتابلت-وساعات-ذكية/كفرات-وحافظات-وجلاد-حماية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/ئێکسسواراتی-مۆبایل-و-تابلێت-و-کاتژمێری-زیرەک/کەڤەر-و-حافیزە-و-بەرگی-پاراستن', '8.1.4.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('باور بانك (شاحن متنقل)', 'پاوەر بانک (شەحنی گەڕۆک)', 'الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/اكسسوارات-موبايلات-وتابلت-وساعات-ذكية/باور-بانك', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/ئێکسسواراتی-مۆبایل-و-تابلێت-و-کاتژمێری-زیرەک/پاوەر-بانک', '8.1.4.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كيبلات وشواحن', 'کێبڵ و شەحن', 'الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/اكسسوارات-موبايلات-وتابلت-وساعات-ذكية/كيبلات-وشواحن', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/ئێکسسواراتی-مۆبایل-و-تابلێت-و-کاتژمێری-زیرەک/کێبڵ-و-شەحن', '8.1.4.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('لصقات شاشة (حماية ضد الكسر والخدش)', 'لزگەی شاشە (پاراستن دژی شکاندن و ڕووشان)', 'الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/اكسسوارات-موبايلات-وتابلت-وساعات-ذكية/لصقات-شاشة', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/ئێکسسواراتی-مۆبایل-و-تابلێت-و-کاتژمێری-زیرەک/لزگەی-شاشە', '8.1.4.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('سماعات موبايل (سلكية، بلوتوث، ايربود)', 'بیستۆکی مۆبایل (وایەردار، بلوتوس، ئێربۆد)', 'الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/اكسسوارات-موبايلات-وتابلت-وساعات-ذكية/سماعات-موبايل', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/ئێکسسواراتی-مۆبایل-و-تابلێت-و-کاتژمێری-زیرەک/بیستۆکی-مۆبایل', '8.1.4.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.1.4'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكسسوارات اخرى (ستاندات، حلقات مسك، اقلام تابلت، وغيرها)', 'ئێکسسواراتی تر (ستاند، ئەڵقەی گرتن، قەڵەمی تابلێت، هتد)', 'الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/اكسسوارات-موبايلات-وتابلت-وساعات-ذكية/اكسسوارات-اخرى', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/ئێکسسواراتی-مۆبایل-و-تابلێت-و-کاتژمێری-زیرەک/ئێکسسواراتی-تر', '8.1.4.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.1.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('موبايلات ازرار (نوكيا، عادية)', 'مۆبایلی دوگمەدار (نۆکیا، ئاسایی)', 'الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/موبايلات-ازرار', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/مۆبایلی-دوگمەدار', '8.1.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة الكترونية صغيرة اخرى', 'ئامێری ئەلیکترۆنی بچووکی تر', 'الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/اجهزة-الكترونية-صغيرة-اخرى', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/مۆبایل-و-تابلێت/ئامێری-ئەلیکترۆنی-بچووکی-تر', '8.1.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كومبيوترات ولابتوبات وملحقاتها', 'کۆمپیوتەر و لاپتۆپ و ملحەقاتەکانی', 'الالكترونيات-والاجهزة-الرقمية/كومبيوترات-ولابتوبات-وملحقاتها', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/کۆمپیوتەر-و-لاپتۆپ-و-ملحەقاتەکانی', '8.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('لابتوبات ونوت بوك  -- notebook_laptop_example.json', 'لاپتۆپ و نۆتبووک', 'الالكترونيات-والاجهزة-الرقمية/كومبيوترات-ولابتوبات-وملحقاتها/لابتوبات-ونوت-بوك-notebook-laptop-examplejson', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/کۆمپیوتەر-و-لاپتۆپ-و-ملحەقاتەکانی/لاپتۆپ-و-نۆتبووک', '8.2.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كومبيوترات مكتبية وتجميعات العاب -- general_pc_build_laptop_example.json', 'کۆمپیوتەری سەر مێز و کۆکراوەی یاری', 'الالكترونيات-والاجهزة-الرقمية/كومبيوترات-ولابتوبات-وملحقاتها/كومبيوترات-مكتبية-وتجميعات-العاب-general-pc-build-laptop-examplejson', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/کۆمپیوتەر-و-لاپتۆپ-و-ملحەقاتەکانی/کۆمپیوتەری-سەر-مێز-و-کۆکراوەی-یاری', '8.2.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('شاشات الكمبيوتر (مونيتور) -- tv_monitor_example.json', 'شاشەی کۆمپیوتەر (مۆنیتۆر)', 'الالكترونيات-والاجهزة-الرقمية/كومبيوترات-ولابتوبات-وملحقاتها/شاشات-الكمبيوتر-tv-monitor-examplejson', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/کۆمپیوتەر-و-لاپتۆپ-و-ملحەقاتەکانی/شاشەی-کۆمپیوتەر', '8.2.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قطع كومبيوتر داخلية (كارت شاشة، رام، معالج، ماذربورد)', 'پارچەی ناوەوەی کۆمپیوتەر (کارتی شاشە، ڕام، پرۆسێسەر، ماذەربۆرد)', 'الالكترونيات-والاجهزة-الرقمية/كومبيوترات-ولابتوبات-وملحقاتها/قطع-كومبيوتر-داخلية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/کۆمپیوتەر-و-لاپتۆپ-و-ملحەقاتەکانی/پارچەی-ناوەوەی-کۆمپیوتەر', '8.2.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('أجهزة الإدخال للكمبيوتر (ماوس، كيبورد)', 'ئامێری داخڵکردن بۆ کۆمپیوتەر (ماوس، کیبۆرد)', 'الالكترونيات-والاجهزة-الرقمية/كومبيوترات-ولابتوبات-وملحقاتها/أجهزة-الإدخال-للكمبيوتر', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/کۆمپیوتەر-و-لاپتۆپ-و-ملحەقاتەکانی/ئامێری-داخڵکردن-بۆ-کۆمپیوتەر', '8.2.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('سماعات الراس الخاصة بالكمبيوتر (هيدفون)', 'بیستۆکی سەری تایبەت بە کۆمپیوتەر (هێدفۆن)', 'الالكترونيات-والاجهزة-الرقمية/كومبيوترات-ولابتوبات-وملحقاتها/سماعات-الراس-الخاصة-بالكمبيوتر', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/کۆمپیوتەر-و-لاپتۆپ-و-ملحەقاتەکانی/بیستۆکی-سەری-تایبەت-بە-کۆمپیوتەر', '8.2.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.2'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('حقائب ظهر وجنط لابتوب', 'جانتای پشت و جانتای لاپتۆپ', 'الالكترونيات-والاجهزة-الرقمية/كومبيوترات-ولابتوبات-وملحقاتها/حقائب-ظهر-وجنط-لابتوب', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/کۆمپیوتەر-و-لاپتۆپ-و-ملحەقاتەکانی/جانتای-پشت-و-جانتای-لاپتۆپ', '8.2.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكسسوارات وملحقات كومبيوتر (مراوح تبريد، ادوات تنظيف، فلاشات)', 'ئێکسسوارات و ملحەقاتی کۆمپیوتەر (پانکەی فێنککەرەوە، ئامرازی پاککردنەوە، فلاش)', 'الالكترونيات-والاجهزة-الرقمية/كومبيوترات-ولابتوبات-وملحقاتها/اكسسوارات-وملحقات-كومبيوتر', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/کۆمپیوتەر-و-لاپتۆپ-و-ملحەقاتەکانی/ئێکسسوارات-و-ملحەقاتی-کۆمپیوتەر', '8.2.8', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تلفزيونات وشاشات وانظمة صوت وفيديو', 'تەلەفزیۆن و شاشە و سیستەمی دەنگ و ڤیدیۆ', 'الالكترونيات-والاجهزة-الرقمية/تلفزيونات-وشاشات-وانظمة-صوت-وفيديو', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/تەلەفزیۆن-و-شاشە-و-سیستەمی-دەنگ-و-ڤیدیۆ', '8.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تلفزيونات ذكية وعادية (سمارت TV) -- tv_monitor_example.json', 'تەلەفزیۆنی زیرەک و ئاسایی (سمارت تیڤی)', 'الالكترونيات-والاجهزة-الرقمية/تلفزيونات-وشاشات-وانظمة-صوت-وفيديو/تلفزيونات-ذكية-وعادية-tv-monitor-examplejson', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/تەلەفزیۆن-و-شاشە-و-سیستەمی-دەنگ-و-ڤیدیۆ/تەلەفزیۆنی-زیرەک-و-ئاسایی', '8.3.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة صوت منزلية ومكبرات صوت --', 'ئامێری دەنگی ماڵان و گەورەکەری دەنگ', 'الالكترونيات-والاجهزة-الرقمية/تلفزيونات-وشاشات-وانظمة-صوت-وفيديو/اجهزة-صوت-منزلية-ومكبرات-صوت', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/تەلەفزیۆن-و-شاشە-و-سیستەمی-دەنگ-و-ڤیدیۆ/ئامێری-دەنگی-ماڵان-و-گەورەکەری-دەنگ', '8.3.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ستلايت ورسيفرات واشتراكات قنوات', 'سەتەلایت و ڕسیڤەر و بەشداری کەناڵەکان', 'الالكترونيات-والاجهزة-الرقمية/تلفزيونات-وشاشات-وانظمة-صوت-وفيديو/ستلايت-ورسيفرات-واشتراكات-قنوات', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/تەلەفزیۆن-و-شاشە-و-سیستەمی-دەنگ-و-ڤیدیۆ/سەتەلایت-و-ڕسیڤەر-و-بەشداری-کەناڵەکان', '8.3.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مشغلات دي في دي وبلوراي ومشغلات وسائط (اندرويد بوكس، ابل تي في)', 'پلەیری دی ڤی دی و بلوڕەی و پلەیری میدیا (ئەندرۆید بۆکس، ئەپڵ تیڤی)', 'الالكترونيات-والاجهزة-الرقمية/تلفزيونات-وشاشات-وانظمة-صوت-وفيديو/مشغلات-دي-في-دي-وبلوراي-ومشغلات-وسائط', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/تەلەفزیۆن-و-شاشە-و-سیستەمی-دەنگ-و-ڤیدیۆ/پلەیری-دی-ڤی-دی-و-بلوڕەی-و-پلەیری-میدیا', '8.3.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('داتا شو وملحقاته (بروجكتر، شاشة عرض، كيبلات)', 'داتاشۆ و ملحەقاتەکانی (پرۆجێکتەر، شاشەی پیشاندان، کێبڵ)', 'الالكترونيات-والاجهزة-الرقمية/تلفزيونات-وشاشات-وانظمة-صوت-وفيديو/داتا-شو-وملحقاته', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/تەلەفزیۆن-و-شاشە-و-سیستەمی-دەنگ-و-ڤیدیۆ/داتاشۆ-و-ملحەقاتەکانی', '8.3.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة تسجيل وتشغيل صوت احترافية (مسجلات، مايكروفونات استوديو)', 'ئامێری تۆمارکردن و لێدانی دەنگی پرۆفیشناڵ (مسەجەل، مایکرۆفۆنی ستۆدیۆ)', 'الالكترونيات-والاجهزة-الرقمية/تلفزيونات-وشاشات-وانظمة-صوت-وفيديو/اجهزة-تسجيل-وتشغيل-صوت-احترافية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/تەلەفزیۆن-و-شاشە-و-سیستەمی-دەنگ-و-ڤیدیۆ/ئامێری-تۆمارکردن-و-لێدانی-دەنگی-پرۆفیشناڵ', '8.3.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ستاندات تلفزيون وريموتات كونترول شاملة', 'ستاندی تەلەفزیۆن و ڕیمۆت کۆنترۆڵی هەمەجۆر', 'الالكترونيات-والاجهزة-الرقمية/تلفزيونات-وشاشات-وانظمة-صوت-وفيديو/ستاندات-تلفزيون-وريموتات-كونترول-شاملة', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/تەلەفزیۆن-و-شاشە-و-سیستەمی-دەنگ-و-ڤیدیۆ/ستاندی-تەلەفزیۆن-و-ڕیمۆت-کۆنترۆڵی-هەمەجۆر', '8.3.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.3'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كاميرات ومعدات تصوير فوتوغرافي وفيديو', 'کامێرا و کەرەستەی وێنەگرتنی فۆتۆگرافی و ڤیدیۆ', 'الالكترونيات-والاجهزة-الرقمية/كاميرات-ومعدات-تصوير-فوتوغرافي-وفيديو', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/کامێرا-و-کەرەستەی-وێنەگرتنی-فۆتۆگرافی-و-ڤیدیۆ', '8.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كاميرات رقمية صغيرة واكشن كاميرا (GoPro)', 'کامێرای دیجیتاڵی بچووک و ئاکشن کامێرا (GoPro)', 'الالكترونيات-والاجهزة-الرقمية/كاميرات-ومعدات-تصوير-فوتوغرافي-وفيديو/كاميرات-رقمية-صغيرة-واكشن-كاميرا', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/کامێرا-و-کەرەستەی-وێنەگرتنی-فۆتۆگرافی-و-ڤیدیۆ/کامێرای-دیجیتاڵی-بچووک-و-ئاکشن-کامێرا', '8.4.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كاميرات احترافية وعدساتها (DSLR، Mirrorless)', 'کامێرای پرۆفیشناڵ و هاوێنەکانی (DSLR، Mirrorless)', 'الالكترونيات-والاجهزة-الرقمية/كاميرات-ومعدات-تصوير-فوتوغرافي-وفيديو/كاميرات-احترافية-وعدساتها', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/کامێرا-و-کەرەستەی-وێنەگرتنی-فۆتۆگرافی-و-ڤیدیۆ/کامێرای-پرۆفیشناڵ-و-هاوێنەکانی', '8.4.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كاميرات فيديو احترافية ومنزلية', 'کامێرای ڤیدیۆیی پرۆفیشناڵ و ماڵان', 'الالكترونيات-والاجهزة-الرقمية/كاميرات-ومعدات-تصوير-فوتوغرافي-وفيديو/كاميرات-فيديو-احترافية-ومنزلية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/کامێرا-و-کەرەستەی-وێنەگرتنی-فۆتۆگرافی-و-ڤیدیۆ/کامێرای-ڤیدیۆیی-پرۆفیشناڵ-و-ماڵان', '8.4.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ملحقات كاميرات (فلاشات، حوامل ثلاثية، فلاتر، بطاريات اضافية)', 'ملحەقاتی کامێرا (فلاش، سێپایە، فلتەر، پاتری زیادە)', 'الالكترونيات-والاجهزة-الرقمية/كاميرات-ومعدات-تصوير-فوتوغرافي-وفيديو/ملحقات-كاميرات', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/کامێرا-و-کەرەستەی-وێنەگرتنی-فۆتۆگرافی-و-ڤیدیۆ/ملحەقاتی-کامێرا', '8.4.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('درونات تصوير وملحقاتها', 'درۆنی وێنەگرتن و ملحەقاتەکانی', 'الالكترونيات-والاجهزة-الرقمية/كاميرات-ومعدات-تصوير-فوتوغرافي-وفيديو/درونات-تصوير-وملحقاتها', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/کامێرا-و-کەرەستەی-وێنەگرتنی-فۆتۆگرافی-و-ڤیدیۆ/درۆنی-وێنەگرتن-و-ملحەقاتەکانی', '8.4.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معدات اضاءة استوديو تصوير', 'کەرەستەی ڕووناکی ستۆدیۆی وێنەگرتن', 'الالكترونيات-والاجهزة-الرقمية/كاميرات-ومعدات-تصوير-فوتوغرافي-وفيديو/معدات-اضاءة-استوديو-تصوير', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/کامێرا-و-کەرەستەی-وێنەگرتنی-فۆتۆگرافی-و-ڤیدیۆ/کەرەستەی-ڕووناکی-ستۆدیۆی-وێنەگرتن', '8.4.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('البومات صور واطارات صور رقمية وتقليدية', 'ئەلبوومی وێنە و چوارچێوەی وێنەی دیجیتاڵی و ئاسایی', 'الالكترونيات-والاجهزة-الرقمية/كاميرات-ومعدات-تصوير-فوتوغرافي-وفيديو/البومات-صور-واطارات-صور-رقمية-وتقليدية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/کامێرا-و-کەرەستەی-وێنەگرتنی-فۆتۆگرافی-و-ڤیدیۆ/ئەلبوومی-وێنە-و-چوارچێوەی-وێنەی-دیجیتاڵی-و-ئاسایی', '8.4.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة العاب الكترونية (قيمنق)', 'ئامێری یاری ئەلیکترۆنی (گەیمینگ)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-العاب-الكترونية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-یاری-ئەلیکترۆنی', '8.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة العاب منزلية ومحمولة (بلايستيشن، اكس بوكس، نينتندو سويتش) -- gaming_console_example.json', 'ئامێری یاری ماڵان و گەڕۆک (پلەیستەیشن، ئێکس بۆکس، نینتێندۆ سویچ)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-العاب-الكترونية/اجهزة-العاب-منزلية-ومحمولة-gaming-console-examplejson', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-یاری-ئەلیکترۆنی/ئامێری-یاری-ماڵان-و-گەڕۆک', '8.5.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.5'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('يدات تحكم (جويستك) وملحقاتها (ستيرنك قيمنق)', 'دەسکی کۆنترۆڵ (جۆیستیک) و ملحەقاتەکانی (ستێرنی گەیمینگ)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-العاب-الكترونية/يدات-تحكم-وملحقاتها', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-یاری-ئەلیکترۆنی/دەسکی-کۆنترۆڵ-و-ملحەقاتەکانی', '8.5.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('العاب فيديو (اقراص، حسابات تحميل رقمي) -- video_game_example.json', 'یاری ڤیدیۆیی (قەوان، هەژماری دابەزاندنی دیجیتاڵی)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-العاب-الكترونية/العاب-فيديو-video-game-examplejson', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-یاری-ئەلیکترۆنی/یاری-ڤیدیۆیی', '8.5.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكسسوارات قيمنق (كراسي قيمنق، نظارات VR، سماعات قيمنق)', 'ئێکسسواراتی گەیمینگ (کورسی گەیمینگ، چاویلکەی VR، بیستۆکی گەیمینگ)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-العاب-الكترونية/اكسسوارات-قيمنق', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-یاری-ئەلیکترۆنی/ئێکسسواراتی-گەیمینگ', '8.5.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('البيت الذكي والتحكم عن بعد', 'ماڵی زیرەک و کۆنترۆڵی دوور', 'الالكترونيات-والاجهزة-الرقمية/البيت-الذكي-والتحكم-عن-بعد', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ماڵی-زیرەک-و-کۆنترۆڵی-دوور', '8.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كاميرات مراقبة ذكية وانظمة حماية للمنزل', 'کامێرای چاودێری زیرەک و سیستەمی پاراستنی ماڵ', 'الالكترونيات-والاجهزة-الرقمية/البيت-الذكي-والتحكم-عن-بعد/كاميرات-مراقبة-ذكية-وانظمة-حماية-للمنزل', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ماڵی-زیرەک-و-کۆنترۆڵی-دوور/کامێرای-چاودێری-زیرەک-و-سیستەمی-پاراستنی-ماڵ', '8.6.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مساعدات صوتية ذكية (اليكسا، جوجل هوم)', 'یاریدەدەری دەنگی زیرەک (ئەلێکسا، گووگڵ هۆم)', 'الالكترونيات-والاجهزة-الرقمية/البيت-الذكي-والتحكم-عن-بعد/مساعدات-صوتية-ذكية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ماڵی-زیرەک-و-کۆنترۆڵی-دوور/یاریدەدەری-دەنگی-زیرەک', '8.6.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('انظمة اضاءة ذكية (لمبات ذكية، سويتشات ذكية)', 'سیستەمی ڕووناکی زیرەک (گلۆپی زیرەک، سویچی زیرەک)', 'الالكترونيات-والاجهزة-الرقمية/البيت-الذكي-والتحكم-عن-بعد/انظمة-اضاءة-ذكية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ماڵی-زیرەک-و-کۆنترۆڵی-دوور/سیستەمی-ڕووناکی-زیرەک', '8.6.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ثرموستات ذكي للتحكم بالتبريد والتدفئة', 'تێرمۆستاتی زیرەک بۆ کۆنترۆڵکردنی فێنککەرەوە و گەرمکەرەوە', 'الالكترونيات-والاجهزة-الرقمية/البيت-الذكي-والتحكم-عن-بعد/ثرموستات-ذكي-للتحكم-بالتبريد-والتدفئة', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ماڵی-زیرەک-و-کۆنترۆڵی-دوور/تێرمۆستاتی-زیرەک-بۆ-کۆنترۆڵکردنی-فێنککەرەوە-و-گەرمکەرەوە', '8.6.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اقفال ابواب ذكية وانظمة دخول بصمة وكارت', 'قوفڵی دەرگای زیرەک و سیستەمی چوونەژوورەوە بە پەنجەمۆر و کارت', 'الالكترونيات-والاجهزة-الرقمية/البيت-الذكي-والتحكم-عن-بعد/اقفال-ابواب-ذكية-وانظمة-دخول-بصمة-وكارت', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ماڵی-زیرەک-و-کۆنترۆڵی-دوور/قوفڵی-دەرگای-زیرەک-و-سیستەمی-چوونەژوورەوە-بە-پەنجەمۆر-و-کارت', '8.6.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة انترنت وشبكات', 'ئامێری ئینتەرنێت و تۆڕەکان', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-انترنت-وشبكات', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-ئینتەرنێت-و-تۆڕەکان', '8.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('راوترات ومودمات', 'ڕاوتەر و مۆدێم', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-انترنت-وشبكات/راوترات-ومودمات', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-ئینتەرنێت-و-تۆڕەکان/ڕاوتەر-و-مۆدێم', '8.7.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مقويات اشارة واي فاي (ريبتر، اكستندر، ميش سيستم)', 'بەهێزکەری ئاماژەی وایفای (ڕیپیتەر، ئێکستێندەر، مێش سیستەم)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-انترنت-وشبكات/مقويات-اشارة-واي-فاي', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-ئینتەرنێت-و-تۆڕەکان/بەهێزکەری-ئاماژەی-وایفای', '8.7.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كيبلات شبكة (انترنت) وملحقاتها (سويتشات، كارتات شبكة)', 'کێبڵی تۆڕ (ئینتەرنێت) و ملحەقاتەکانی (سویچ، کارتی تۆڕ)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-انترنت-وشبكات/كيبلات-شبكة-وملحقاتها', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-ئینتەرنێت-و-تۆڕەکان/کێبڵی-تۆڕ-و-ملحەقاتەکانی', '8.7.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة مكتبية والكترونيات عمل', 'ئامێری نووسینگە و ئەلیکترۆنیاتی کار', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-مكتبية-والكترونيات-عمل', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-نووسینگە-و-ئەلیکترۆنیاتی-کار', '8.8', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ماكينات تصوير مستندات (استنساخ)', 'مەکینەی کۆپیکردنی بەڵگەنامە (ئیستنساخ)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-مكتبية-والكترونيات-عمل/ماكينات-تصوير-مستندات', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-نووسینگە-و-ئەلیکترۆنیاتی-کار/مەکینەی-کۆپیکردنی-بەڵگەنامە', '8.8.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة فاكس وهواتف ارضية وسنترالات', 'ئامێری فاکس و تەلەفۆنی زەوی و سەنتراڵ', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-مكتبية-والكترونيات-عمل/اجهزة-فاكس-وهواتف-ارضية-وسنترالات', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-نووسینگە-و-ئەلیکترۆنیاتی-کار/ئامێری-فاکس-و-تەلەفۆنی-زەوی-و-سەنتراڵ', '8.8.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ماكينات عد وكشف تزوير النقود', 'مەکینەی ژماردن و دۆزینەوەی پارەی ساختە', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-مكتبية-والكترونيات-عمل/ماكينات-عد-وكشف-تزوير-النقود', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-نووسینگە-و-ئەلیکترۆنیاتی-کار/مەکینەی-ژماردن-و-دۆزینەوەی-پارەی-ساختە', '8.8.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكسسوارات الكترونية عامة ومتفرقة', 'ئێکسسواراتی ئەلیکترۆنی گشتی و جۆراوجۆر', 'الالكترونيات-والاجهزة-الرقمية/اكسسوارات-الكترونية-عامة-ومتفرقة', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئێکسسواراتی-ئەلیکترۆنی-گشتی-و-جۆراوجۆر', '8.9', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('بطاريات وشواحن عامة (قلم، ريموت)', 'پاتری و شەحنی گشتی (قەڵەم، ڕیمۆت)', 'الالكترونيات-والاجهزة-الرقمية/اكسسوارات-الكترونية-عامة-ومتفرقة/بطاريات-وشواحن-عامة', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئێکسسواراتی-ئەلیکترۆنی-گشتی-و-جۆراوجۆر/پاتری-و-شەحنی-گشتی', '8.9.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('حقائب واغطية واقية لاجهزة الكترونية (عامة)', 'جانتا و بەرگی پارێزەر بۆ ئامێری ئەلیکترۆنی (گشتی)', 'الالكترونيات-والاجهزة-الرقمية/اكسسوارات-الكترونية-عامة-ومتفرقة/حقائب-واغطية-واقية-لاجهزة-الكترونية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئێکسسواراتی-ئەلیکترۆنی-گشتی-و-جۆراوجۆر/جانتا-و-بەرگی-پارێزەر-بۆ-ئامێری-ئەلیکترۆنی', '8.9.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.9'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('حوامل وستاندات لاجهزة اخرى', 'هەڵگر و ستاند بۆ ئامێری تر', 'الالكترونيات-والاجهزة-الرقمية/اكسسوارات-الكترونية-عامة-ومتفرقة/حوامل-وستاندات-لاجهزة-اخرى', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئێکسسواراتی-ئەلیکترۆنی-گشتی-و-جۆراوجۆر/هەڵگر-و-ستاند-بۆ-ئامێری-تر', '8.9.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كيبلات ومحولات اخرى (HDMI، USB)', 'کێبڵ و گۆڕەری تر (HDMI، USB)', 'الالكترونيات-والاجهزة-الرقمية/اكسسوارات-الكترونية-عامة-ومتفرقة/كيبلات-ومحولات-اخرى', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئێکسسواراتی-ئەلیکترۆنی-گشتی-و-جۆراوجۆر/کێبڵ-و-گۆڕەری-تر', '8.9.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('وحدات خزن بيانات (ميموري، فلاش، هارد ديسك)', 'یەکەی هەڵگرتنی داتا (میمۆری، فلاش، هارد دیسک)', 'الالكترونيات-والاجهزة-الرقمية/وحدات-خزن-بيانات', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/یەکەی-هەڵگرتنی-داتا', '8.10', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('هارد ديسك خارجي (SSD، HDD)', 'هارد دیسکی دەرەکی (SSD، HDD)', 'الالكترونيات-والاجهزة-الرقمية/وحدات-خزن-بيانات/هارد-ديسك-خارجي', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/یەکەی-هەڵگرتنی-داتا/هارد-دیسکی-دەرەکی', '8.10.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ميموري كارد (رام موبايل وكاميرا)', 'میمۆری کارد (ڕامی مۆبایل و کامێرا)', 'الالكترونيات-والاجهزة-الرقمية/وحدات-خزن-بيانات/ميموري-كارد', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/یەکەی-هەڵگرتنی-داتا/میمۆری-کارد', '8.10.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('فلاش ميموري (USB درايف)', 'فلاش میمۆری (USB درایڤ)', 'الالكترونيات-والاجهزة-الرقمية/وحدات-خزن-بيانات/فلاش-ميموري', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/یەکەی-هەڵگرتنی-داتا/فلاش-میمۆری', '8.10.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('هارد ديسك داخلي للكومبيوتر واللابتوب (SSD، HDD) --', 'هارد دیسکی ناوەکی بۆ کۆمپیوتەر و لاپتۆپ (SSD، HDD)', 'الالكترونيات-والاجهزة-الرقمية/وحدات-خزن-بيانات/هارد-ديسك-داخلي-للكومبيوتر-واللابتوب', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/یەکەی-هەڵگرتنی-داتا/هارد-دیسکی-ناوەکی-بۆ-کۆمپیوتەر-و-لاپتۆپ', '8.10.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('طابعات وسكانرات ومستلزماتها', 'چاپکەر و سکانەر و پێداویستییەکانیان', 'الالكترونيات-والاجهزة-الرقمية/طابعات-وسكانرات-ومستلزماتها', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/چاپکەر-و-سکانەر-و-پێداویستییەکانیان', '8.11', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('طابعات (ليزر، حبر، متعددة الوظائف، فواتير)', 'چاپکەر (لێزەر، حوبر، فرەکار، پسوڵە)', 'الالكترونيات-والاجهزة-الرقمية/طابعات-وسكانرات-ومستلزماتها/طابعات', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/چاپکەر-و-سکانەر-و-پێداویستییەکانیان/چاپکەر', '8.11.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.11'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('سكانرات (ماسحات ضوئية)', 'سکانەر (ڕووپێوی ڕووناکی)', 'الالكترونيات-والاجهزة-الرقمية/طابعات-وسكانرات-ومستلزماتها/سكانرات', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/چاپکەر-و-سکانەر-و-پێداویستییەکانیان/سکانەر', '8.11.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.11'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('احبار طابعات', 'حوبری چاپکەر', 'الالكترونيات-والاجهزة-الرقمية/طابعات-وسكانرات-ومستلزماتها/احبار-طابعات', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/چاپکەر-و-سکانەر-و-پێداویستییەکانیان/حوبری-چاپکەر', '8.11.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.11'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ورق طباعة وصور مخصص', 'کاغەزی چاپ و وێنەی تایبەت', 'الالكترونيات-والاجهزة-الرقمية/طابعات-وسكانرات-ومستلزماتها/ورق-طباعة-وصور-مخصص', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/چاپکەر-و-سکانەر-و-پێداویستییەکانیان/کاغەزی-چاپ-و-وێنەی-تایبەت', '8.11.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.11'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة طاقة احتياطية وحماية', 'ئامێری وزەی یەدەگ و پاراستن', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-طاقة-احتياطية-وحماية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-وزەی-یەدەگ-و-پاراستن', '8.12', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('يو بي اس للكومبيوتر والاجهزة (عاكسات)', 'یو پی ئێس بۆ کۆمپیوتەر و ئامێرەکان (گۆڕەر)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-طاقة-احتياطية-وحماية/يو-بي-اس-للكومبيوتر-والاجهزة', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-وزەی-یەدەگ-و-پاراستن/یو-پی-ئێس-بۆ-کۆمپیوتەر-و-ئامێرەکان', '8.12.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.12'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('بطاريات يو بي اس واجهزة الكترونية كبيرة', 'پاتری یو پی ئێس و ئامێری ئەلیکترۆنی گەورە', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-طاقة-احتياطية-وحماية/بطاريات-يو-بي-اس-واجهزة-الكترونية-كبيرة', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-وزەی-یەدەگ-و-پاراستن/پاتری-یو-پی-ئێس-و-ئامێری-ئەلیکترۆنی-گەورە', '8.12.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.12'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('انظمة امنية الكترونية (للمحلات والشركات)', 'سیستەمی ئەمنی ئەلیکترۆنی (بۆ دوکان و کۆمپانیاکان)', 'الالكترونيات-والاجهزة-الرقمية/انظمة-امنية-الكترونية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/سیستەمی-ئەمنی-ئەلیکترۆنی', '8.13', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كاميرات مراقبة وانظمة تسجيل DVR/NVR', 'کامێرای چاودێری و سیستەمی تۆمارکردنی DVR/NVR', 'الالكترونيات-والاجهزة-الرقمية/انظمة-امنية-الكترونية/كاميرات-مراقبة-وانظمة-تسجيل-dvrnvr', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/سیستەمی-ئەمنی-ئەلیکترۆنی/کامێرای-چاودێری-و-سیستەمی-تۆمارکردنی-dvrnvr', '8.13.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.13'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('انظمة انذار ضد السرقة والحريق الكترونية', 'سیستەمی ئاگادارکەرەوەی دژە دزی و ئاگری ئەلیکترۆنی', 'الالكترونيات-والاجهزة-الرقمية/انظمة-امنية-الكترونية/انظمة-انذار-ضد-السرقة-والحريق-الكترونية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/سیستەمی-ئەمنی-ئەلیکترۆنی/سیستەمی-ئاگادارکەرەوەی-دژە-دزی-و-ئاگری-ئەلیکترۆنی', '8.13.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.13'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة منزلية كهربائية', 'ئامێری کارەبایی ماڵان', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان', '8.14', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة مطبخ كبيرة', 'ئامێری گەورەی چێشتخانە', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/اجهزة-مطبخ-كبيرة', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/ئامێری-گەورەی-چێشتخانە', '8.14.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ثلاجات ومجمدات (فريزرات)', 'ساردکەرەوە و بەفرگر (فریزەر)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/اجهزة-مطبخ-كبيرة/ثلاجات-ومجمدات', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/ئامێری-گەورەی-چێشتخانە/ساردکەرەوە-و-بەفرگر', '8.14.1.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('غسالات صحون', 'قاپشۆر', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/اجهزة-مطبخ-كبيرة/غسالات-صحون', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/ئامێری-گەورەی-چێشتخانە/قاپشۆر', '8.14.1.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('طباخات وافران (كهربائية وغازية)', 'تەباخ و فڕن (کارەبایی و غازی)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/اجهزة-مطبخ-كبيرة/طباخات-وافران', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/ئامێری-گەورەی-چێشتخانە/تەباخ-و-فڕن', '8.14.1.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة تبريد وتدفئة (مكيفات و صوبات)', 'ئامێری فێنککەرەوە و گەرمکەرەوە (موکەیف و سۆپا)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/اجهزة-تبريد-وتدفئة', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/ئامێری-فێنککەرەوە-و-گەرمکەرەوە', '8.14.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة تبريد (سبلت، مكيف شباك، مبردات هواء)', 'ئامێری فێنککەرەوە (سپلیت، موکەیفی پەنجەرە، هەوا ساردکەرەوە)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/اجهزة-تبريد-وتدفئة/اجهزة-تبريد', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/ئامێری-فێنککەرەوە-و-گەرمکەرەوە/ئامێری-فێنککەرەوە', '8.14.2.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة تدفئة (صوبات نفطية، كهربائية، غازية، دفاية زيتية)', 'ئامێری گەرمکەرەوە (سۆپای نەوتی، کارەبایی، غازی، سۆپای زەیتی)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/اجهزة-تبريد-وتدفئة/اجهزة-تدفئة', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/ئامێری-فێنککەرەوە-و-گەرمکەرەوە/ئامێری-گەرمکەرەوە', '8.14.2.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('منقيات ومرطبات هواء', 'هەواپاڵێو و شێدارکەرەوەی هەوا', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/اجهزة-تبريد-وتدفئة/منقيات-ومرطبات-هواء', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/ئامێری-فێنککەرەوە-و-گەرمکەرەوە/هەواپاڵێو-و-شێدارکەرەوەی-هەوا', '8.14.2.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مراوح (سقفية، ارضية، جدارية)', 'پانکە (سەقفی، زەوی، دیواری)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/اجهزة-تبريد-وتدفئة/مراوح', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/ئامێری-فێنککەرەوە-و-گەرمکەرەوە/پانکە', '8.14.2.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('غسالات ملابس ومجففات (نشافات)', 'جلشۆر و وشککەرەوە (نەشافە)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/غسالات-ملابس-ومجففات', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/جلشۆر-و-وشککەرەوە', '8.14.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة مطبخ صغيرة لتحضير الطعام', 'ئامێری بچووکی چێشتخانە بۆ ئامادەکردنی خواردن', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/اجهزة-مطبخ-صغيرة-لتحضير-الطعام', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/ئامێری-بچووکی-چێشتخانە-بۆ-ئامادەکردنی-خواردن', '8.14.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('برادات وفلاتر مياه الشرب', 'بەڕاد و فلتەری ئاوی خواردنەوە', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/اجهزة-مطبخ-صغيرة-لتحضير-الطعام/برادات-وفلاتر-مياه-الشرب', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/ئامێری-بچووکی-چێشتخانە-بۆ-ئامادەکردنی-خواردن/بەڕاد-و-فلتەری-ئاوی-خواردنەوە', '8.14.4.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('غلايات ماء كهربائية (كتلي)', 'چای سازکەری کارەبایی (کتلی)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/اجهزة-مطبخ-صغيرة-لتحضير-الطعام/غلايات-ماء-كهربائية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/ئامێری-بچووکی-چێشتخانە-بۆ-ئامادەکردنی-خواردن/چای-سازکەری-کارەبایی', '8.14.4.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قلايات كهربائية وهوائية', 'تاوەی کارەبایی و هەوایی', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/اجهزة-مطبخ-صغيرة-لتحضير-الطعام/قلايات-كهربائية-وهوائية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/ئامێری-بچووکی-چێشتخانە-بۆ-ئامادەکردنی-خواردن/تاوەی-کارەبایی-و-هەوایی', '8.14.4.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قدور ضغط كهربائية (جدر كهربائي)', 'مەنجەڵی پەستانی کارەبایی (مەنجەڵی کارەبایی)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/اجهزة-مطبخ-صغيرة-لتحضير-الطعام/قدور-ضغط-كهربائية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/ئامێری-بچووکی-چێشتخانە-بۆ-ئامادەکردنی-خواردن/مەنجەڵی-پەستانی-کارەبایی', '8.14.4.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مايكروويف وافران كهربائية صغيرة (اوفن)', 'مایکرۆوەیڤ و فڕنی کارەبایی بچووک (ئۆڤن)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/اجهزة-مطبخ-صغيرة-لتحضير-الطعام/مايكروويف-وافران-كهربائية-صغيرة', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/ئامێری-بچووکی-چێشتخانە-بۆ-ئامادەکردنی-خواردن/مایکرۆوەیڤ-و-فڕنی-کارەبایی-بچووک', '8.14.4.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('شوايات وكابسات كهربائية ومحمصة خبز (توستر)', 'کەباب ساز و گوشەر و نانبرژێنەری کارەبایی (تۆستەر)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/اجهزة-مطبخ-صغيرة-لتحضير-الطعام/شوايات-وكابسات-كهربائية-ومحمصة-خبز', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/ئامێری-بچووکی-چێشتخانە-بۆ-ئامادەکردنی-خواردن/کەباب-ساز-و-گوشەر-و-نانبرژێنەری-کارەبایی', '8.14.4.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خلاطات ومحضرات طعام وعجانات (خلاط، ست البيت)', 'خەڵاتە و ئامادەکەری خواردن و هەویرشێل (خەڵات، ستی بێت)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/اجهزة-مطبخ-صغيرة-لتحضير-الطعام/خلاطات-ومحضرات-طعام-وعجانات', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/ئامێری-بچووکی-چێشتخانە-بۆ-ئامادەکردنی-خواردن/خەڵاتە-و-ئامادەکەری-خواردن-و-هەویرشێل', '8.14.4.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة صنع القهوة والعصائر (مكينة قهوة، عصارة فواكه)', 'ئامێری دروستکردنی قاوە و شەربەت (مەکینەی قاوە، شەربەتگر)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/اجهزة-مطبخ-صغيرة-لتحضير-الطعام/اجهزة-صنع-القهوة-والعصائر', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/ئامێری-بچووکی-چێشتخانە-بۆ-ئامادەکردنی-خواردن/ئامێری-دروستکردنی-قاوە-و-شەربەت', '8.14.4.8', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مكانس كهربائية واجهزة تنظيف بالبخار', 'گسکی کارەبایی و ئامێری پاککردنەوە بە هەڵم', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/مكانس-كهربائية-واجهزة-تنظيف-بالبخار', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/گسکی-کارەبایی-و-ئامێری-پاککردنەوە-بە-هەڵم', '8.14.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اوتي ملابس (مكواة بخارية وعادية)', 'ئوتوی جل (ئوتوی هەڵمی و ئاسایی)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/اوتي-ملابس', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/ئوتوی-جل', '8.14.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ملحقات كهربائية منزلية (سيار، نقاط كهرباء، بطاريات، ماطور ماء، لايت شحن)', 'ملحەقاتی کارەبایی ماڵان (سەیار، خاڵی کارەبا، پاتری، ماتۆڕی ئاو، لایتی شەحن)', 'الالكترونيات-والاجهزة-الرقمية/اجهزة-منزلية-كهربائية/ملحقات-كهربائية-منزلية', 'ئەلیکترۆنیات-و-ئامێری-دیجیتاڵی/ئامێری-کارەبایی-ماڵان/ملحەقاتی-کارەبایی-ماڵان', '8.14.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '8.14'));

-- End of Level 1 Category: 8

-- Level 1 Category: 9 - الهوايات والترفيه والانشطة

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الهوايات والترفيه والانشطة', 'خولیا و کات بەسەربردن و چالاکی', 'الهوايات-والترفيه-والانشطة', 'خولیا-و-کات-بەسەربردن-و-چالاکی', '9', NULL);
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الرياضة واللياقة البدنية', 'وەرزش و لەشجوانی', 'الهوايات-والترفيه-والانشطة/الرياضة-واللياقة-البدنية', 'خولیا-و-کات-بەسەربردن-و-چالاکی/وەرزش-و-لەشجوانی', '9.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كرة قدم ومستلزماتها (كرة، احذية رياضية، ملابس)', 'تۆپی پێ و پێداویستییەکانی (تۆپ، پێڵاوی وەرزشی، جلوبەرگ)', 'الهوايات-والترفيه-والانشطة/الرياضة-واللياقة-البدنية/كرة-قدم-ومستلزماتها', 'خولیا-و-کات-بەسەربردن-و-چالاکی/وەرزش-و-لەشجوانی/تۆپی-پێ-و-پێداویستییەکانی', '9.1.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كرة سلة وطائرة ويد ومستلزماتها', 'تۆپی سەبەتە و بالە و دەست و پێداویستییەکانی', 'الهوايات-والترفيه-والانشطة/الرياضة-واللياقة-البدنية/كرة-سلة-وطائرة-ويد-ومستلزماتها', 'خولیا-و-کات-بەسەربردن-و-چالاکی/وەرزش-و-لەشجوانی/تۆپی-سەبەتە-و-بالە-و-دەست-و-پێداویستییەکانی', '9.1.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة رياضية منزلية ومتخصصة (جهاز جري، بايسكل ثابت، اجهزة حديد)', 'ئامێری وەرزشی ماڵان و تایبەتمەند (ئامێری ڕاکردن، پاسکیلی جێگیر، ئامێری ئاسن)', 'الهوايات-والترفيه-والانشطة/الرياضة-واللياقة-البدنية/اجهزة-رياضية-منزلية-ومتخصصة', 'خولیا-و-کات-بەسەربردن-و-چالاکی/وەرزش-و-لەشجوانی/ئامێری-وەرزشی-ماڵان-و-تایبەتمەند', '9.1.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ملابس واحذية رياضية لمختلف الرياضات', 'جلوبەرگ و پێڵاوی وەرزشی بۆ وەرزشە جیاوازەکان', 'الهوايات-والترفيه-والانشطة/الرياضة-واللياقة-البدنية/ملابس-واحذية-رياضية-لمختلف-الرياضات', 'خولیا-و-کات-بەسەربردن-و-چالاکی/وەرزش-و-لەشجوانی/جلوبەرگ-و-پێڵاوی-وەرزشی-بۆ-وەرزشە-جیاوازەکان', '9.1.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('رياضات دفاع عن النفس وفنون قتالية (كاراتيه، ملاكمة، بدلات، كفوف، واقيات)', 'وەرزشی بەرگری لەخۆ و هونەری جەنگی (کاراتێ، بۆکسێن، قات، دەستکێش، پارێزەر)', 'الهوايات-والترفيه-والانشطة/الرياضة-واللياقة-البدنية/رياضات-دفاع-عن-النفس-وفنون-قتالية', 'خولیا-و-کات-بەسەربردن-و-چالاکی/وەرزش-و-لەشجوانی/وەرزشی-بەرگری-لەخۆ-و-هونەری-جەنگی', '9.1.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('دراجات هوائية وملحقاتها', 'پاسکیل و ملحەقاتەکانی', 'الهوايات-والترفيه-والانشطة/الرياضة-واللياقة-البدنية/دراجات-هوائية-وملحقاتها', 'خولیا-و-کات-بەسەربردن-و-چالاکی/وەرزش-و-لەشجوانی/پاسکیل-و-ملحەقاتەکانی', '9.1.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مستلزمات ركض ومشي (احذية، ساعات رياضية، ملابس)', 'پێداویستی ڕاکردن و ڕۆیشتن (پێڵاو، کاتژمێری وەرزشی، جلوبەرگ)', 'الهوايات-والترفيه-والانشطة/الرياضة-واللياقة-البدنية/مستلزمات-ركض-ومشي', 'خولیا-و-کات-بەسەربردن-و-چالاکی/وەرزش-و-لەشجوانی/پێداویستی-ڕاکردن-و-ڕۆیشتن', '9.1.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.1'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادوات سباحة ورياضات مائية', 'کەرەستەی مەلەوانی و وەرزشی ئاوی', 'الهوايات-والترفيه-والانشطة/الرياضة-واللياقة-البدنية/ادوات-سباحة-ورياضات-مائية', 'خولیا-و-کات-بەسەربردن-و-چالاکی/وەرزش-و-لەشجوانی/کەرەستەی-مەلەوانی-و-وەرزشی-ئاوی', '9.1.8', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة حديد واثقال وكمال اجسام (دامبلص، بار)', 'ئامێری ئاسن و قورسایی و لەشجوانی (دامبڵس، بار)', 'الهوايات-والترفيه-والانشطة/الرياضة-واللياقة-البدنية/اجهزة-حديد-واثقال-وكمال-اجسام', 'خولیا-و-کات-بەسەربردن-و-چالاکی/وەرزش-و-لەشجوانی/ئامێری-ئاسن-و-قورسایی-و-لەشجوانی', '9.1.9', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادوات يوغا وتمارين رياضية منزلية (فرشة يوغا، اشرطة مقاومة)', 'کەرەستەی یۆگا و ڕاهێنانی وەرزشی ماڵان (فەرشی یۆگا، لێنتی بەرگری)', 'الهوايات-والترفيه-والانشطة/الرياضة-واللياقة-البدنية/ادوات-يوغا-وتمارين-رياضية-منزلية', 'خولیا-و-کات-بەسەربردن-و-چالاکی/وەرزش-و-لەشجوانی/کەرەستەی-یۆگا-و-ڕاهێنانی-وەرزشی-ماڵان', '9.1.10', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مستلزمات رياضات اخرى (تنس، بليارد، بولينغ)', 'پێداویستی وەرزشی تر (تێنس، بلیارد، بۆڵینگ)', 'الهوايات-والترفيه-والانشطة/الرياضة-واللياقة-البدنية/مستلزمات-رياضات-اخرى', 'خولیا-و-کات-بەسەربردن-و-چالاکی/وەرزش-و-لەشجوانی/پێداویستی-وەرزشی-تر', '9.1.11', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الموسيقى والفنون اليدوية', 'مۆسیقا و هونەری دەستی', 'الهوايات-والترفيه-والانشطة/الموسيقى-والفنون-اليدوية', 'خولیا-و-کات-بەسەربردن-و-چالاکی/مۆسیقا-و-هونەری-دەستی', '9.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('آلات موسيقية (عود، كيتار، اورغ، درامز، كمان)', 'ئامێری مۆسیقا (عوود، گیتار، ئۆرگ، دڕامز، کەمان)', 'الهوايات-والترفيه-والانشطة/الموسيقى-والفنون-اليدوية/آلات-موسيقية', 'خولیا-و-کات-بەسەربردن-و-چالاکی/مۆسیقا-و-هونەری-دەستی/ئامێری-مۆسیقا', '9.2.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معدات صوت وتسجيل ودي جي (مايكات، سماعات استوديو، مكسرات)', 'کەرەستەی دەنگ و تۆمارکردن و دی جەی (مایک، بیستۆکی ستۆدیۆ، میکسەر)', 'الهوايات-والترفيه-والانشطة/الموسيقى-والفنون-اليدوية/معدات-صوت-وتسجيل-ودي-جي', 'خولیا-و-کات-بەسەربردن-و-چالاکی/مۆسیقا-و-هونەری-دەستی/کەرەستەی-دەنگ-و-تۆمارکردن-و-دی-جەی', '9.2.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادوات رسم وفنون تشكيلية (الوان زيتية ومائية، فرش، كانفس)', 'کەرەستەی وێنەکێشان و هونەری شێوەکاری (ڕەنگی زەیتی و ئاوی، فڵچە، کانڤاس)', 'الهوايات-والترفيه-والانشطة/الموسيقى-والفنون-اليدوية/ادوات-رسم-وفنون-تشكيلية', 'خولیا-و-کات-بەسەربردن-و-چالاکی/مۆسیقا-و-هونەری-دەستی/کەرەستەی-وێنەکێشان-و-هونەری-شێوەکاری', '9.2.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اعمال يدوية وحرف ومستلزماتها (خياطة، تطريز، اكسسوارات يدوية)', 'کاری دەستی و پیشە و پێداویستییەکانی (دوورین، چنین، ئێکسسواراتی دەستی)', 'الهوايات-والترفيه-والانشطة/الموسيقى-والفنون-اليدوية/اعمال-يدوية-وحرف-ومستلزماتها', 'خولیا-و-کات-بەسەربردن-و-چالاکی/مۆسیقا-و-هونەری-دەستی/کاری-دەستی-و-پیشە-و-پێداویستییەکانی', '9.2.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادوات خط عربي وزخرفة', 'کەرەستەی خەتی عەرەبی و نەخشاندن', 'الهوايات-والترفيه-والانشطة/الموسيقى-والفنون-اليدوية/ادوات-خط-عربي-وزخرفة', 'خولیا-و-کات-بەسەربردن-و-چالاکی/مۆسیقا-و-هونەری-دەستی/کەرەستەی-خەتی-عەرەبی-و-نەخشاندن', '9.2.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.2'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كتب وقراءة ومجلات', 'کتێب و خوێندنەوە و گۆڤار', 'الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات', 'خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار', '9.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كتب دينية واسلامية', 'کتێبی ئایینی و ئیسلامی', 'الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/كتب-دينية-واسلامية', 'خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/کتێبی-ئایینی-و-ئیسلامی', '9.3.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كتب تعليمية ومناهج دراسية و ملازم', 'کتێبی فێرکاری و پرۆگرامی خوێندن و مەنهەج', 'الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/كتب-تعليمية-ومناهج-دراسية-و-ملازم', 'خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/کتێبی-فێرکاری-و-پرۆگرامی-خوێندن-و-مەنهەج', '9.3.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('روايات وقصص وكتب ادب وشعر', 'ڕۆمان و چیرۆک و کتێبی ئەدەب و شیعر', 'الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/روايات-وقصص-وكتب-ادب-وشعر', 'خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/ڕۆمان-و-چیرۆک-و-کتێبی-ئەدەب-و-شیعر', '9.3.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كتب علمية وتقنية وهندسية وطبية', 'کتێبی زانستی و تەکنیکی و ئەندازیاری و پزیشکی', 'الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/كتب-علمية-وتقنية-وهندسية-وطبية', 'خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/کتێبی-زانستی-و-تەکنیکی-و-ئەندازیاری-و-پزیشکی', '9.3.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قصص وكتب اطفال مصورة وتعليمية', 'چیرۆک و کتێبی منداڵانی وێنەدار و فێرکاری', 'الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/قصص-وكتب-اطفال-مصورة-وتعليمية', 'خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/چیرۆک-و-کتێبی-منداڵانی-وێنەدار-و-فێرکاری', '9.3.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كتب تاريخ وسياسة وجغرافية', 'کتێبی مێژوو و سیاسەت و جوگرافیا', 'الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/كتب-تاريخ-وسياسة-وجغرافية', 'خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/کتێبی-مێژوو-و-سیاسەت-و-جوگرافیا', '9.3.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كتب تطوير ذات وادارة اعمال وتنمية بشرية', 'کتێبی گەشەپێدانی خود و بەڕێوەبردنی کار و گەشەپێدانی مرۆیی', 'الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/كتب-تطوير-ذات-وادارة-اعمال-وتنمية-بشرية', 'خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/کتێبی-گەشەپێدانی-خود-و-بەڕێوەبردنی-کار-و-گەشەپێدانی-مرۆیی', '9.3.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مجلات وصحف وجرائد', 'گۆڤار و ڕۆژنامە', 'الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/مجلات-وصحف-وجرائد', 'خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/گۆڤار-و-ڕۆژنامە', '9.3.8', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كتب نادرة وقديمة ومخطوطات', 'کتێبی دەگمەن و کۆن و دەستنووس', 'الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/كتب-نادرة-وقديمة-ومخطوطات', 'خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/کتێبی-دەگمەن-و-کۆن-و-دەستنووس', '9.3.9', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.3'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('العاب تسلية وترفيه (غير الكترونية)', 'یاری کات بەسەربردن (نا ئەلیکترۆنی)', 'الهوايات-والترفيه-والانشطة/العاب-تسلية-وترفيه', 'خولیا-و-کات-بەسەربردن-و-چالاکی/یاری-کات-بەسەربردن', '9.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('العاب طاولة وورق لعب (شطرنج، زار، دومنة، ورق شدة)', 'یاری مێز و کاغەزی یاری (شەترەنج، زار، دۆمینە، کاغەزی یاریکردن)', 'الهوايات-والترفيه-والانشطة/العاب-تسلية-وترفيه/العاب-طاولة-وورق-لعب', 'خولیا-و-کات-بەسەربردن-و-چالاکی/یاری-کات-بەسەربردن/یاری-مێز-و-کاغەزی-یاری', '9.4.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('العاب شعبية وتراثية', 'یاری میللی و کەلەپووری', 'الهوايات-والترفيه-والانشطة/العاب-تسلية-وترفيه/العاب-شعبية-وتراثية', 'خولیا-و-کات-بەسەربردن-و-چالاکی/یاری-کات-بەسەربردن/یاری-میللی-و-کەلەپووری', '9.4.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('العاب ذكاء والغاز وتركيب (بازل، مكعب روبيك)', 'یاری زیرەکی و مەتەڵ و پازڵ (پازڵ، شەشپاڵووی ڕوبیک)', 'الهوايات-والترفيه-والانشطة/العاب-تسلية-وترفيه/العاب-ذكاء-والغاز-وتركيب', 'خولیا-و-کات-بەسەربردن-و-چالاکی/یاری-کات-بەسەربردن/یاری-زیرەکی-و-مەتەڵ-و-پازڵ', '9.4.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مقتنيات وتحف وانتيكات', 'شتی کۆکراوە و شتی هونەری و ئەنتیکە', 'الهوايات-والترفيه-والانشطة/مقتنيات-وتحف-وانتيكات', 'خولیا-و-کات-بەسەربردن-و-چالاکی/شتی-کۆکراوە-و-شتی-هونەری-و-ئەنتیکە', '9.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('عملات ورقية ومعدنية قديمة وطوابع وميداليات', 'دراوی کاغەز و کانزایی کۆن و پوول و مەدالیا', 'الهوايات-والترفيه-والانشطة/مقتنيات-وتحف-وانتيكات/عملات-ورقية-ومعدنية-قديمة-وطوابع-وميداليات', 'خولیا-و-کات-بەسەربردن-و-چالاکی/شتی-کۆکراوە-و-شتی-هونەری-و-ئەنتیکە/دراوی-کاغەز-و-کانزایی-کۆن-و-پوول-و-مەدالیا', '9.5.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تحف وانتيكات (اثاث قديم، مقتنيات تراثية، فنيات)', 'شتی هونەری و ئەنتیکە (کەلوپەلی کۆن، شتی کەلەپووری، هونەری)', 'الهوايات-والترفيه-والانشطة/مقتنيات-وتحف-وانتيكات/تحف-وانتيكات', 'خولیا-و-کات-بەسەربردن-و-چالاکی/شتی-کۆکراوە-و-شتی-هونەری-و-ئەنتیکە/شتی-هونەری-و-ئەنتیکە', '9.5.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ساعات جيب وساعات قديمة نادرة', 'کاتژمێری گیرفان و کاتژمێری کۆنی دەگمەن', 'الهوايات-والترفيه-والانشطة/مقتنيات-وتحف-وانتيكات/ساعات-جيب-وساعات-قديمة-نادرة', 'خولیا-و-کات-بەسەربردن-و-چالاکی/شتی-کۆکراوە-و-شتی-هونەری-و-ئەنتیکە/کاتژمێری-گیرفان-و-کاتژمێری-کۆنی-دەگمەن', '9.5.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('رحلات وكشتات وهوايات خارجية', 'گەشت و سەیران و خولیای دەرەوە', 'الهوايات-والترفيه-والانشطة/رحلات-وكشتات-وهوايات-خارجية', 'خولیا-و-کات-بەسەربردن-و-چالاکی/گەشت-و-سەیران-و-خولیای-دەرەوە', '9.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معدات صيد سمك وطيور', 'کەرەستەی ڕاوکردنی ماسی و باڵندە', 'الهوايات-والترفيه-والانشطة/رحلات-وكشتات-وهوايات-خارجية/معدات-صيد-سمك-وطيور', 'خولیا-و-کات-بەسەربردن-و-چالاکی/گەشت-و-سەیران-و-خولیای-دەرەوە/کەرەستەی-ڕاوکردنی-ماسی-و-باڵندە', '9.6.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.6'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تجهيزات الهايكنج وتسلق المرتفعات', 'ئامادەکاری شاخەوانی و سەرکەوتنی بەرزایی', 'الهوايات-والترفيه-والانشطة/رحلات-وكشتات-وهوايات-خارجية/تجهيزات-الهايكنج-وتسلق-المرتفعات', 'خولیا-و-کات-بەسەربردن-و-چالاکی/گەشت-و-سەیران-و-خولیای-دەرەوە/ئامادەکاری-شاخەوانی-و-سەرکەوتنی-بەرزایی', '9.6.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معدات فروسية وركوب خيل', 'کەرەستەی سوارچاکی و ئەسپسواری', 'الهوايات-والترفيه-والانشطة/رحلات-وكشتات-وهوايات-خارجية/معدات-فروسية-وركوب-خيل', 'خولیا-و-کات-بەسەربردن-و-چالاکی/گەشت-و-سەیران-و-خولیای-دەرەوە/کەرەستەی-سوارچاکی-و-ئەسپسواری', '9.6.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تلسكوبات ودربيل فلكي وبري', 'تێلسکۆپ و دووربینی فەلەکی و وشکانی', 'الهوايات-والترفيه-والانشطة/رحلات-وكشتات-وهوايات-خارجية/تلسكوبات-ودربيل-فلكي-وبري', 'خولیا-و-کات-بەسەربردن-و-چالاکی/گەشت-و-سەیران-و-خولیای-دەرەوە/تێلسکۆپ-و-دووربینی-فەلەکی-و-وشکانی', '9.6.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('فنون شعبية وتراثيات (كمقتنيات وهواية)', 'هونەری میللی و کەلەپووری (وەک شتی کۆکراوە و خولیا)', 'الهوايات-والترفيه-والانشطة/فنون-شعبية-وتراثيات', 'خولیا-و-کات-بەسەربردن-و-چالاکی/هونەری-میللی-و-کەلەپووری', '9.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ازياء شعبية وتراثية', 'جلوبەرگی میللی و کەلەپووری', 'الهوايات-والترفيه-والانشطة/فنون-شعبية-وتراثيات/ازياء-شعبية-وتراثية', 'خولیا-و-کات-بەسەربردن-و-چالاکی/هونەری-میللی-و-کەلەپووری/جلوبەرگی-میللی-و-کەلەپووری', '9.7.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('حلي ومجوهرات تراثية وفضة قديمة', 'خشڵ و گەوهەری کەلەپووری و زیوی کۆن', 'الهوايات-والترفيه-والانشطة/فنون-شعبية-وتراثيات/حلي-ومجوهرات-تراثية-وفضة-قديمة', 'خولیا-و-کات-بەسەربردن-و-چالاکی/هونەری-میللی-و-کەلەپووری/خشڵ-و-گەوهەری-کەلەپووری-و-زیوی-کۆن', '9.7.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('فخاريات وسيراميك يدوي وفني', 'گۆزە و سیرامیکی دەستی و هونەری', 'الهوايات-والترفيه-والانشطة/فنون-شعبية-وتراثيات/فخاريات-وسيراميك-يدوي-وفني', 'خولیا-و-کات-بەسەربردن-و-چالاکی/هونەری-میللی-و-کەلەپووری/گۆزە-و-سیرامیکی-دەستی-و-هونەری', '9.7.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('سجاد يدوي وبسط تراثية', 'فەرشی دەستی و بەرماڵی کەلەپووری', 'الهوايات-والترفيه-والانشطة/فنون-شعبية-وتراثيات/سجاد-يدوي-وبسط-تراثية', 'خولیا-و-کات-بەسەربردن-و-چالاکی/هونەری-میللی-و-کەلەپووری/فەرشی-دەستی-و-بەرماڵی-کەلەپووری', '9.7.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تذاكر فعاليات ومناسبات', 'بلیتی چالاکی و بۆنەکان', 'الهوايات-والترفيه-والانشطة/تذاكر-فعاليات-ومناسبات', 'خولیا-و-کات-بەسەربردن-و-چالاکی/بلیتی-چالاکی-و-بۆنەکان', '9.9', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تذاكر حفلات غنائية ومهرجانات', 'بلیتی ئاهەنگی گۆرانی و فیستیڤاڵ', 'الهوايات-والترفيه-والانشطة/تذاكر-فعاليات-ومناسبات/تذاكر-حفلات-غنائية-ومهرجانات', 'خولیا-و-کات-بەسەربردن-و-چالاکی/بلیتی-چالاکی-و-بۆنەکان/بلیتی-ئاهەنگی-گۆرانی-و-فیستیڤاڵ', '9.9.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.9'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تذاكر مباريات رياضية (كرة قدم وغيرها)', 'بلیتی یاری وەرزشی (تۆپی پێ و هیتر)', 'الهوايات-والترفيه-والانشطة/تذاكر-فعاليات-ومناسبات/تذاكر-مباريات-رياضية', 'خولیا-و-کات-بەسەربردن-و-چالاکی/بلیتی-چالاکی-و-بۆنەکان/بلیتی-یاری-وەرزشی', '9.9.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.9'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تذاكر مسرح وسينما ومعارض وفعاليات ثقافية', 'بلیتی شانۆ و سینەما و پێشانگا و چالاکی ڕۆشنبیری', 'الهوايات-والترفيه-والانشطة/تذاكر-فعاليات-ومناسبات/تذاكر-مسرح-وسينما-ومعارض-وفعاليات-ثقافية', 'خولیا-و-کات-بەسەربردن-و-چالاکی/بلیتی-چالاکی-و-بۆنەکان/بلیتی-شانۆ-و-سینەما-و-پێشانگا-و-چالاکی-ڕۆشنبیری', '9.9.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '9.9'));

-- End of Level 1 Category: 9

-- Level 1 Category: 10 - الحيوانات الاليفة ومستلزماتها

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الحيوانات الاليفة ومستلزماتها', 'ئاژەڵی ماڵی و پێداویستییەکانیان', 'الحيوانات-الاليفة-ومستلزماتها', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان', '10', NULL);
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الطيور الاليفة والزينة', 'باڵندەی ماڵی و جوانی', 'الحيوانات-الاليفة-ومستلزماتها/الطيور-الاليفة-والزينة', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/باڵندەی-ماڵی-و-جوانی', '10.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('حمام (زاجل، زينة، بغدادي)', 'کۆتر (نامەبەر، جوانی، بەغدادی)', 'الحيوانات-الاليفة-ومستلزماتها/الطيور-الاليفة-والزينة/حمام', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/باڵندەی-ماڵی-و-جوانی/کۆتر', '10.1.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('طيور زينة (كناري، حسون، بلبل، ببغاء، لوف بيرد)', 'باڵندەی جوانی (کەناری، حەسوون، بولبول، تووتی، لۆڤ بێرد)', 'الحيوانات-الاليفة-ومستلزماتها/الطيور-الاليفة-والزينة/طيور-زينة', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/باڵندەی-ماڵی-و-جوانی/باڵندەی-جوانی', '10.1.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('دجاج وبط وزينة للتربية المنزلية', 'مریشک و مراوی و جوانی بۆ بەخێوکردنی ماڵان', 'الحيوانات-الاليفة-ومستلزماتها/الطيور-الاليفة-والزينة/دجاج-وبط-وزينة-للتربية-المنزلية', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/باڵندەی-ماڵی-و-جوانی/مریشک-و-مراوی-و-جوانی-بۆ-بەخێوکردنی-ماڵان', '10.1.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('طيور اليفة اخرى', 'باڵندەی ماڵی تر', 'الحيوانات-الاليفة-ومستلزماتها/الطيور-الاليفة-والزينة/طيور-اليفة-اخرى', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/باڵندەی-ماڵی-و-جوانی/باڵندەی-ماڵی-تر', '10.1.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اسماك الزينة واحواضها', 'ماسی جوانی و حەوزەکانیان', 'الحيوانات-الاليفة-ومستلزماتها/اسماك-الزينة-واحواضها', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/ماسی-جوانی-و-حەوزەکانیان', '10.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اسماك زينة (جوبي، ذهبية، كوي)', 'ماسی جوانی (گۆپی، زێڕین، کۆی)', 'الحيوانات-الاليفة-ومستلزماتها/اسماك-الزينة-واحواضها/اسماك-زينة', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/ماسی-جوانی-و-حەوزەکانیان/ماسی-جوانی', '10.2.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.2'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('احواض سمك ومستلزماتها (فلتر، هيتر، اوكسجين، ديكور)', 'حەوزی ماسی و پێداویستییەکانی (فلتەر، گەرمکەر، ئۆکسجین، دیکۆر)', 'الحيوانات-الاليفة-ومستلزماتها/اسماك-الزينة-واحواضها/احواض-سمك-ومستلزماتها', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/ماسی-جوانی-و-حەوزەکانیان/حەوزی-ماسی-و-پێداویستییەکانی', '10.2.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اسماك للاكل وتربية منزلية (كارب، كطان)', 'ماسی بۆ خواردن و بەخێوکردنی ماڵان (کارپ، کەتان)', 'الحيوانات-الاليفة-ومستلزماتها/اسماك-الزينة-واحواضها/اسماك-للاكل-وتربية-منزلية', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/ماسی-جوانی-و-حەوزەکانیان/ماسی-بۆ-خواردن-و-بەخێوکردنی-ماڵان', '10.2.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قطط', 'پشیلە', 'الحيوانات-الاليفة-ومستلزماتها/قطط', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/پشیلە', '10.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كلاب', 'سەگ', 'الحيوانات-الاليفة-ومستلزماتها/كلاب', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/سەگ', '10.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كلاب حراسة وصيد (جيرمن شيبرد، دوبرمان)', 'سەگی پاسەوانی و ڕاو (جێرمەن شیپەرد، دۆبەرمان)', 'الحيوانات-الاليفة-ومستلزماتها/كلاب/كلاب-حراسة-وصيد', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/سەگ/سەگی-پاسەوانی-و-ڕاو', '10.4.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('كلاب زينة ورفقة (هاسكي، لولو، جريفو)', 'سەگی جوانی و هاوڕێیەتی (هاسکی، لولو، گریڤۆن)', 'الحيوانات-الاليفة-ومستلزماتها/كلاب/كلاب-زينة-ورفقة', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/سەگ/سەگی-جوانی-و-هاوڕێیەتی', '10.4.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('حيوانات مزارع وحقول (للافراد)', 'ئاژەڵی کێڵگە و مەزرا (بۆ تاکەکان)', 'الحيوانات-الاليفة-ومستلزماتها/حيوانات-مزارع-وحقول', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/ئاژەڵی-کێڵگە-و-مەزرا', '10.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اغنام وماعز (غنم، طليان)', 'مەڕ و بزن (مەڕ، بەرخ)', 'الحيوانات-الاليفة-ومستلزماتها/حيوانات-مزارع-وحقول/اغنام-وماعز', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/ئاژەڵی-کێڵگە-و-مەزرا/مەڕ-و-بزن', '10.5.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ابقار وجاموس وعجول', 'مانگا و گامێش و گوێرەکە', 'الحيوانات-الاليفة-ومستلزماتها/حيوانات-مزارع-وحقول/ابقار-وجاموس-وعجول', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/ئاژەڵی-کێڵگە-و-مەزرا/مانگا-و-گامێش-و-گوێرەکە', '10.5.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.5'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('خيول وحمير وبغال (حصين)', 'ئەسپ و کەر و هێستر (ئەسپ)', 'الحيوانات-الاليفة-ومستلزماتها/حيوانات-مزارع-وحقول/خيول-وحمير-وبغال', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/ئاژەڵی-کێڵگە-و-مەزرا/ئەسپ-و-کەر-و-هێستر', '10.5.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.5'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('حيوانات وطيور متنوعة', 'ئاژەڵ و باڵندەی جۆراوجۆر', 'الحيوانات-الاليفة-ومستلزماتها/حيوانات-وطيور-متنوعة', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/ئاژەڵ-و-باڵندەی-جۆراوجۆر', '10.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('صقور وطيور جارحة (للهواة)', 'هەڵۆ و باڵندەی ڕاوکەر (بۆ خولیاداران)', 'الحيوانات-الاليفة-ومستلزماتها/حيوانات-وطيور-متنوعة/صقور-وطيور-جارحة', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/ئاژەڵ-و-باڵندەی-جۆراوجۆر/هەڵۆ-و-باڵندەی-ڕاوکەر', '10.6.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('سلاحف وبرمائيات', 'کیسەڵ و وشکاوەکی', 'الحيوانات-الاليفة-ومستلزماتها/حيوانات-وطيور-متنوعة/سلاحف-وبرمائيات', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/ئاژەڵ-و-باڵندەی-جۆراوجۆر/کیسەڵ-و-وشکاوەکی', '10.6.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('قوارض اليفة (هامستر، ارانب صغيرة، سنجاب)', 'قرتێنەری ماڵی (هامستەر، کەروێشکی بچووک، سمۆرە)', 'الحيوانات-الاليفة-ومستلزماتها/حيوانات-وطيور-متنوعة/قوارض-اليفة', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/ئاژەڵ-و-باڵندەی-جۆراوجۆر/قرتێنەری-ماڵی', '10.6.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ارانب للتربية والزينة', 'کەروێشک بۆ بەخێوکردن و جوانی', 'الحيوانات-الاليفة-ومستلزماتها/حيوانات-وطيور-متنوعة/ارانب-للتربية-والزينة', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/ئاژەڵ-و-باڵندەی-جۆراوجۆر/کەروێشک-بۆ-بەخێوکردن-و-جوانی', '10.6.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('زواحف اليفة (سحالي، حيات غير سامة)', 'خشۆکی ماڵی (مارمێلکە، ماری بێ ژەهر)', 'الحيوانات-الاليفة-ومستلزماتها/حيوانات-وطيور-متنوعة/زواحف-اليفة', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/ئاژەڵ-و-باڵندەی-جۆراوجۆر/خشۆکی-ماڵی', '10.6.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('حيوانات اخرى (حرباء، نمس، وغيرها)', 'ئاژەڵی تر (حەربا، سمۆرە، هتد)', 'الحيوانات-الاليفة-ومستلزماتها/حيوانات-وطيور-متنوعة/حيوانات-اخرى', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/ئاژەڵ-و-باڵندەی-جۆراوجۆر/ئاژەڵی-تر', '10.6.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.6'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكل ومستلزمات الحيوانات الاليفة', 'خواردن و پێداویستی ئاژەڵی ماڵی', 'الحيوانات-الاليفة-ومستلزماتها/اكل-ومستلزمات-الحيوانات-الاليفة', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/خواردن-و-پێداویستی-ئاژەڵی-ماڵی', '10.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكل حيوانات', 'خواردنی ئاژەڵ', 'الحيوانات-الاليفة-ومستلزماتها/اكل-ومستلزمات-الحيوانات-الاليفة/اكل-حيوانات', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/خواردن-و-پێداویستی-ئاژەڵی-ماڵی/خواردنی-ئاژەڵ', '10.7.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكل قطط', 'خواردنی پشیلە', 'الحيوانات-الاليفة-ومستلزماتها/اكل-ومستلزمات-الحيوانات-الاليفة/اكل-حيوانات/اكل-قطط', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/خواردن-و-پێداویستی-ئاژەڵی-ماڵی/خواردنی-ئاژەڵ/خواردنی-پشیلە', '10.7.1.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.7.1'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكل كلاب', 'خواردنی سەگ', 'الحيوانات-الاليفة-ومستلزماتها/اكل-ومستلزمات-الحيوانات-الاليفة/اكل-حيوانات/اكل-كلاب', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/خواردن-و-پێداویستی-ئاژەڵی-ماڵی/خواردنی-ئاژەڵ/خواردنی-سەگ', '10.7.1.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.7.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكل طيور (حب، خلطات)', 'خواردنی باڵندە (دانەوێڵە، تێکەڵە)', 'الحيوانات-الاليفة-ومستلزماتها/اكل-ومستلزمات-الحيوانات-الاليفة/اكل-حيوانات/اكل-طيور', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/خواردن-و-پێداویستی-ئاژەڵی-ماڵی/خواردنی-ئاژەڵ/خواردنی-باڵندە', '10.7.1.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.7.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكل اسماك', 'خواردنی ماسی', 'الحيوانات-الاليفة-ومستلزماتها/اكل-ومستلزمات-الحيوانات-الاليفة/اكل-حيوانات/اكل-اسماك', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/خواردن-و-پێداویستی-ئاژەڵی-ماڵی/خواردنی-ئاژەڵ/خواردنی-ماسی', '10.7.1.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.7.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اكل حيوانات اخرى', 'خواردنی ئاژەڵی تر', 'الحيوانات-الاليفة-ومستلزماتها/اكل-ومستلزمات-الحيوانات-الاليفة/اكل-حيوانات/اكل-حيوانات-اخرى', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/خواردن-و-پێداویستی-ئاژەڵی-ماڵی/خواردنی-ئاژەڵ/خواردنی-ئاژەڵی-تر', '10.7.1.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.7.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اقفاص وبيوت وفرشات للحيوانات', 'قەفەس و ماڵ و فەرشی ئاژەڵ', 'الحيوانات-الاليفة-ومستلزماتها/اكل-ومستلزمات-الحيوانات-الاليفة/اقفاص-وبيوت-وفرشات-للحيوانات', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/خواردن-و-پێداویستی-ئاژەڵی-ماڵی/قەفەس-و-ماڵ-و-فەرشی-ئاژەڵ', '10.7.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('العاب واكسسوارات حيوانات (اطواق، مقاود، العاب مضغ)', 'یاری و ئێکسسواراتی ئاژەڵ (قۆڵە، ملوانکە، یاری گازگرتن)', 'الحيوانات-الاليفة-ومستلزماتها/اكل-ومستلزمات-الحيوانات-الاليفة/العاب-واكسسوارات-حيوانات', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/خواردن-و-پێداویستی-ئاژەڵی-ماڵی/یاری-و-ئێکسسواراتی-ئاژەڵ', '10.7.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادوات نظافة وعناية بالحيوانات', 'کەرەستەی پاکوخاوێنی و چاودێری ئاژەڵ', 'الحيوانات-الاليفة-ومستلزماتها/اكل-ومستلزمات-الحيوانات-الاليفة/ادوات-نظافة-وعناية-بالحيوانات', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/خواردن-و-پێداویستی-ئاژەڵی-ماڵی/کەرەستەی-پاکوخاوێنی-و-چاودێری-ئاژەڵ', '10.7.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مستلزمات عناية ونظافة (شامبو، فرشاة شعر، مقراضة اظافر)', 'پێداویستی چاودێری و پاکوخاوێنی (شامپۆ، فڵچەی قژ، نینۆکبڕ)', 'الحيوانات-الاليفة-ومستلزماتها/اكل-ومستلزمات-الحيوانات-الاليفة/ادوات-نظافة-وعناية-بالحيوانات/مستلزمات-عناية-ونظافة', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/خواردن-و-پێداویستی-ئاژەڵی-ماڵی/کەرەستەی-پاکوخاوێنی-و-چاودێری-ئاژەڵ/پێداویستی-چاودێری-و-پاکوخاوێنی', '10.7.4.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.7.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('رمل قطط وملحقاته (جاروف، صندوق رمل)', 'لم و پێداویستی پشیلە (خاکەناز، سندوقی لم)', 'الحيوانات-الاليفة-ومستلزماتها/اكل-ومستلزمات-الحيوانات-الاليفة/ادوات-نظافة-وعناية-بالحيوانات/رمل-قطط-وملحقاته', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/خواردن-و-پێداویستی-ئاژەڵی-ماڵی/کەرەستەی-پاکوخاوێنی-و-چاودێری-ئاژەڵ/لم-و-پێداویستی-پشیلە', '10.7.4.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.7.4'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('حفاضات ومناديل للحيوانات', 'دایبی و کلینێکسی ئاژەڵ', 'الحيوانات-الاليفة-ومستلزماتها/اكل-ومستلزمات-الحيوانات-الاليفة/ادوات-نظافة-وعناية-بالحيوانات/حفاضات-ومناديل-للحيوانات', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/خواردن-و-پێداویستی-ئاژەڵی-ماڵی/کەرەستەی-پاکوخاوێنی-و-چاودێری-ئاژەڵ/دایبی-و-کلینێکسی-ئاژەڵ', '10.7.4.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.7.4'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ملابس للحيوانات الاليفة', 'جلوبەرگی ئاژەڵی ماڵی', 'الحيوانات-الاليفة-ومستلزماتها/اكل-ومستلزمات-الحيوانات-الاليفة/ملابس-للحيوانات-الاليفة', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/خواردن-و-پێداویستی-ئاژەڵی-ماڵی/جلوبەرگی-ئاژەڵی-ماڵی', '10.7.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مستلزمات سفر وتنقل للحيوانات (بوكس نقل، احزمة امان)', 'پێداویستی گەشت و گواستنەوەی ئاژەڵ (سندوقی گواستنەوە، قایشی سەلامەتی)', 'الحيوانات-الاليفة-ومستلزماتها/اكل-ومستلزمات-الحيوانات-الاليفة/مستلزمات-سفر-وتنقل-للحيوانات', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/خواردن-و-پێداویستی-ئاژەڵی-ماڵی/پێداویستی-گەشت-و-گواستنەوەی-ئاژەڵ', '10.7.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.7'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معدات تربية حيوانات للمزارع والحقول', 'کەرەستەی بەخێوکردنی ئاژەڵ بۆ کێڵگە و مەزرا', 'الحيوانات-الاليفة-ومستلزماتها/معدات-تربية-حيوانات-للمزارع-والحقول', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/کەرەستەی-بەخێوکردنی-ئاژەڵ-بۆ-کێڵگە-و-مەزرا', '10.8', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معدات حقول ومزارع دواجن ومواشي', 'کەرەستەی کێڵگە و مەزرای پەلەوەر و ئاژەڵ', 'الحيوانات-الاليفة-ومستلزماتها/معدات-تربية-حيوانات-للمزارع-والحقول/معدات-حقول-ومزارع-دواجن-ومواشي', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/کەرەستەی-بەخێوکردنی-ئاژەڵ-بۆ-کێڵگە-و-مەزرا/کەرەستەی-کێڵگە-و-مەزرای-پەلەوەر-و-ئاژەڵ', '10.8.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مفاقس وحاضنات بيض', 'مەکینەی هەڵهێنانی هێلکە و داڵدە', 'الحيوانات-الاليفة-ومستلزماتها/معدات-تربية-حيوانات-للمزارع-والحقول/مفاقس-وحاضنات-بيض', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/کەرەستەی-بەخێوکردنی-ئاژەڵ-بۆ-کێڵگە-و-مەزرا/مەکینەی-هەڵهێنانی-هێلکە-و-داڵدە', '10.8.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معالف وسكايات (عادية واتوماتيك)', 'ئاخوڕ و ئاودان (ئاسایی و ئۆتۆماتیک)', 'الحيوانات-الاليفة-ومستلزماتها/معدات-تربية-حيوانات-للمزارع-والحقول/معالف-وسكايات', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/کەرەستەی-بەخێوکردنی-ئاژەڵ-بۆ-کێڵگە-و-مەزرا/ئاخوڕ-و-ئاودان', '10.8.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.8'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('ادوية ومستلزمات بيطرية اساسية', 'دەرمان و پێداویستی ڤێتێرنەری سەرەکی', 'الحيوانات-الاليفة-ومستلزماتها/معدات-تربية-حيوانات-للمزارع-والحقول/ادوية-ومستلزمات-بيطرية-اساسية', 'ئاژەڵی-ماڵی-و-پێداویستییەکانیان/کەرەستەی-بەخێوکردنی-ئاژەڵ-بۆ-کێڵگە-و-مەزرا/دەرمان-و-پێداویستی-ڤێتێرنەری-سەرەکی', '10.8.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '10.8'));

-- End of Level 1 Category: 10

-- Level 1 Category: 11 - الاعمال والمعدات التجارية والصناعية

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('الاعمال والمعدات التجارية والصناعية', 'کار و کەرەستەی بازرگانی و پیشەسازی', 'الاعمال-والمعدات-التجارية-والصناعية', 'کار-و-کەرەستەی-بازرگانی-و-پیشەسازی', '11', NULL);
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معدات والات للاعمال', 'کەرەستە و ئامێری کار', 'الاعمال-والمعدات-التجارية-والصناعية/معدات-والات-للاعمال', 'کار-و-کەرەستەی-بازرگانی-و-پیشەسازی/کەرەستە-و-ئامێری-کار', '11.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '11'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مكائن ومعدات صناعية وتصنيع', 'مەکینە و کەرەستەی پیشەسازی و بەرهەمهێنان', 'الاعمال-والمعدات-التجارية-والصناعية/معدات-والات-للاعمال/مكائن-ومعدات-صناعية-وتصنيع', 'کار-و-کەرەستەی-بازرگانی-و-پیشەسازی/کەرەستە-و-ئامێری-کار/مەکینە-و-کەرەستەی-پیشەسازی-و-بەرهەمهێنان', '11.1.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '11.1'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('تجهيزات مطاعم ومحلات وفنادق (ثلاجات عرض، رفوف، كاشيرات)', 'ئامادەکاری چێشتخانە و دوکان و هۆتێل (ساردکەرەوەی پیشاندان، ڕەفە، کاشێر)', 'الاعمال-والمعدات-التجارية-والصناعية/معدات-والات-للاعمال/تجهيزات-مطاعم-ومحلات-وفنادق', 'کار-و-کەرەستەی-بازرگانی-و-پیشەسازی/کەرەستە-و-ئامێری-کار/ئامادەکاری-چێشتخانە-و-دوکان-و-هۆتێل', '11.1.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '11.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معدات زراعية كبيرة (غير المركبات)', 'کەرەستەی کشتوکاڵی گەورە (جگە لە ئۆتۆمبێل)', 'الاعمال-والمعدات-التجارية-والصناعية/معدات-والات-للاعمال/معدات-زراعية-كبيرة', 'کار-و-کەرەستەی-بازرگانی-و-پیشەسازی/کەرەستە-و-ئامێری-کار/کەرەستەی-کشتوکاڵی-گەورە', '11.1.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '11.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اجهزة ومعدات طبية ومختبرات (للمؤسسات والعيادات)', 'ئامێر و کەرەستەی پزیشکی و تاقیگە (بۆ دامەزراوە و کلینیکەکان)', 'الاعمال-والمعدات-التجارية-والصناعية/معدات-والات-للاعمال/اجهزة-ومعدات-طبية-ومختبرات', 'کار-و-کەرەستەی-بازرگانی-و-پیشەسازی/کەرەستە-و-ئامێری-کار/ئامێر-و-کەرەستەی-پزیشکی-و-تاقیگە', '11.1.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '11.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('اثاث ولوازم مكتبية وتجارية (مكاتب، كراسي، خزانات ملفات)', 'کەلوپەل و پێداویستی نووسینگە و بازرگانی (مێز، کورسی، کەنتۆری فایل)', 'الاعمال-والمعدات-التجارية-والصناعية/معدات-والات-للاعمال/اثاث-ولوازم-مكتبية-وتجارية', 'کار-و-کەرەستەی-بازرگانی-و-پیشەسازی/کەرەستە-و-ئامێری-کار/کەلوپەل-و-پێداویستی-نووسینگە-و-بازرگانی', '11.1.5', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '11.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مولدات كهرباء كبيرة ومحولات للمؤسسات والمشاريع', 'مۆلیدەی کارەبای گەورە و گۆڕەر بۆ دامەزراوە و پڕۆژەکان', 'الاعمال-والمعدات-التجارية-والصناعية/معدات-والات-للاعمال/مولدات-كهرباء-كبيرة-ومحولات-للمؤسسات-والمشاريع', 'کار-و-کەرەستەی-بازرگانی-و-پیشەسازی/کەرەستە-و-ئامێری-کار/مۆلیدەی-کارەبای-گەورە-و-گۆڕەر-بۆ-دامەزراوە-و-پڕۆژەکان', '11.1.6', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '11.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('معدات مهنية وحرفية اخرى (عدة تصليح متخصصة)', 'کەرەستەی پیشەیی و دەستی تر (عەدەی چاککردنەوەی تایبەتمەند)', 'الاعمال-والمعدات-التجارية-والصناعية/معدات-والات-للاعمال/معدات-مهنية-وحرفية-اخرى', 'کار-و-کەرەستەی-بازرگانی-و-پیشەسازی/کەرەستە-و-ئامێری-کار/کەرەستەی-پیشەیی-و-دەستی-تر', '11.1.7', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '11.1'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('فرص تجارية ومشاريع وشراكات', 'هەلی بازرگانی و پڕۆژە و هاوبەشی', 'الاعمال-والمعدات-التجارية-والصناعية/فرص-تجارية-ومشاريع-وشراكات', 'کار-و-کەرەستەی-بازرگانی-و-پیشەسازی/هەلی-بازرگانی-و-پڕۆژە-و-هاوبەشی', '11.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '11'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('امتيازات تجارية (فرانشايز)', 'ئیمتیازی بازرگانی (فرانچایز)', 'الاعمال-والمعدات-التجارية-والصناعية/فرص-تجارية-ومشاريع-وشراكات/امتيازات-تجارية', 'کار-و-کەرەستەی-بازرگانی-و-پیشەسازی/هەلی-بازرگانی-و-پڕۆژە-و-هاوبەشی/ئیمتیازی-بازرگانی', '11.2.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '11.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مشاريع جاهزة للبيع (محلات، شركات شغالة)', 'پڕۆژەی ئامادە بۆ فرۆشتن (دوکان، کۆمپانیای کارا)', 'الاعمال-والمعدات-التجارية-والصناعية/فرص-تجارية-ومشاريع-وشراكات/مشاريع-جاهزة-للبيع', 'کار-و-کەرەستەی-بازرگانی-و-پیشەسازی/هەلی-بازرگانی-و-پڕۆژە-و-هاوبەشی/پڕۆژەی-ئامادە-بۆ-فرۆشتن', '11.2.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '11.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('فرص شراكة واستثمار في مشاريع', 'هەلی هاوبەشی و وەبەرهێنان لە پڕۆژەکان', 'الاعمال-والمعدات-التجارية-والصناعية/فرص-تجارية-ومشاريع-وشراكات/فرص-شراكة-واستثمار-في-مشاريع', 'کار-و-کەرەستەی-بازرگانی-و-پیشەسازی/هەلی-بازرگانی-و-پڕۆژە-و-هاوبەشی/هەلی-هاوبەشی-و-وەبەرهێنان-لە-پڕۆژەکان', '11.2.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '11.2'));

INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('وكالات تجارية (مطلوب وكيل او عرض وكالة)', 'بریکاری بازرگانی (پێویستە بریکار یان پێشنیاری بریکاری)', 'الاعمال-والمعدات-التجارية-والصناعية/فرص-تجارية-ومشاريع-وشراكات/وكالات-تجارية', 'کار-و-کەرەستەی-بازرگانی-و-پیشەسازی/هەلی-بازرگانی-و-پڕۆژە-و-هاوبەشی/بریکاری-بازرگانی', '11.2.4', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '11.2'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مواد اولية وبضاعة بالجملة للاعمال', 'ماددەی سەرەتایی و کاڵای جوملە بۆ کار', 'الاعمال-والمعدات-التجارية-والصناعية/مواد-اولية-وبضاعة-بالجملة-للاعمال', 'کار-و-کەرەستەی-بازرگانی-و-پیشەسازی/ماددەی-سەرەتایی-و-کاڵای-جوملە-بۆ-کار', '11.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '11'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مواد خام للصناعات المختلفة', 'ماددەی خاو بۆ پیشەسازی جیاواز', 'الاعمال-والمعدات-التجارية-والصناعية/مواد-اولية-وبضاعة-بالجملة-للاعمال/مواد-خام-للصناعات-المختلفة', 'کار-و-کەرەستەی-بازرگانی-و-پیشەسازی/ماددەی-سەرەتایی-و-کاڵای-جوملە-بۆ-کار/ماددەی-خاو-بۆ-پیشەسازی-جیاواز', '11.3.1', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '11.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('بضاعة بالجملة لمختلف الاصناف (ملابس، الكترونيات، مواد غذائية)', 'کاڵای جوملە بۆ جۆرە جیاوازەکان (جلوبەرگ، ئەلیکترۆنیات، ماددەی خۆراکی)', 'الاعمال-والمعدات-التجارية-والصناعية/مواد-اولية-وبضاعة-بالجملة-للاعمال/بضاعة-بالجملة-لمختلف-الاصناف', 'کار-و-کەرەستەی-بازرگانی-و-پیشەسازی/ماددەی-سەرەتایی-و-کاڵای-جوملە-بۆ-کار/کاڵای-جوملە-بۆ-جۆرە-جیاوازەکان', '11.3.2', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '11.3'));
INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('مكائن ومواد تغليف وتعبئة صناعية', 'مەکینە و ماددەی پێچانەوە و پاکەتکردنی پیشەسازی', 'الاعمال-والمعدات-التجارية-والصناعية/مواد-اولية-وبضاعة-بالجملة-للاعمال/مكائن-ومواد-تغليف-وتعبئة-صناعية', 'کار-و-کەرەستەی-بازرگانی-و-پیشەسازی/ماددەی-سەرەتایی-و-کاڵای-جوملە-بۆ-کار/مەکینە-و-ماددەی-پێچانەوە-و-پاکەتکردنی-پیشەسازی', '11.3.3', (SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = '11.3'));

-- End of Level 1 Category: 11

-- Re-enable triggers
SET session_replication_role = DEFAULT;

COMMIT;

-- Create indexes for better performance
CREATE INDEX CONCURRENTLY IF NOT EXISTS "idx_category_parent_id" ON "Category" ("ParentID");
CREATE INDEX CONCURRENTLY IF NOT EXISTS "idx_category_hierarchy_path" ON "Category" ("hierarchy_path");
CREATE INDEX CONCURRENTLY IF NOT EXISTS "idx_category_url_slug_arabic" ON "Category" ("UrlSlugArabic");
CREATE INDEX CONCURRENTLY IF NOT EXISTS "idx_category_url_slug_kurdish" ON "Category" ("UrlSlugKurdish");

-- Create unique constraints
ALTER TABLE "Category" ADD CONSTRAINT "uk_category_hierarchy_path" UNIQUE ("hierarchy_path");
ALTER TABLE "Category" ADD CONSTRAINT "uk_category_url_slug_arabic" UNIQUE ("UrlSlugArabic");
ALTER TABLE "Category" ADD CONSTRAINT "uk_category_url_slug_kurdish" UNIQUE ("UrlSlugKurdish");

-- Analyze table for query optimization
ANALYZE "Category";

-- Successfully inserted 715 categories

-- Query 1: Display hierarchy with proper indentation (tabs based on level)
-- This shows the complete hierarchy structure with visual indentation
SELECT
    "hierarchy_path",
    REPEAT('	', ARRAY_LENGTH(STRING_TO_ARRAY("hierarchy_path"::TEXT, '.'), 1) - 1) ||
    "hierarchy_path"::TEXT || '	' || "NameArabic" AS "Arabic_Hierarchy",
    REPEAT('	', ARRAY_LENGTH(STRING_TO_ARRAY("hierarchy_path"::TEXT, '.'), 1) - 1) ||
    "hierarchy_path"::TEXT || '	' || "NameKurdish" AS "Kurdish_Hierarchy",
    REPEAT('	', ARRAY_LENGTH(STRING_TO_ARRAY("hierarchy_path"::TEXT, '.'), 1) - 1) ||
    "hierarchy_path"::TEXT || '	' || "UrlSlugArabic" AS "ArabicUrlSlug",
    REPEAT('	', ARRAY_LENGTH(STRING_TO_ARRAY("hierarchy_path"::TEXT, '.'), 1) - 1) ||
    "hierarchy_path"::TEXT || '	' || "UrlSlugKurdish" AS "KurdishUrlSlug"
FROM "Category"
ORDER BY
    -- Custom ordering to sort hierarchy paths numerically
    STRING_TO_ARRAY("hierarchy_path"::TEXT, '.')::INT[];
