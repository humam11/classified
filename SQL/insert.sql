-- PostgreSQL script to insert brands and models data
-- Generated for testing purposes
-- Requires categories table to be populated first (category_id references)

BEGIN;

-- ============================================================================
-- VEHICLE BRANDS AND MODELS (Category: سيارات - hierarchy_path = '1.1')
-- ============================================================================

-- Get the category_id for Cars (سيارات)
-- Assuming category with hierarchy_path '1.1' is Cars

-- ============================================================================
-- BRAND: Toyota (تويوتا)
-- ============================================================================
INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Toyota', 'تويوتا', 'تۆیۆتا', TRUE, 'toyota', '/images/brands/toyota.png', 'toyota', '1', NULL, (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Camry', 'كامري', 'کامری', FALSE, 'toyota/camry', '/images/models/toyota-camry.png', 'camry', '1.1', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Toyota' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Corolla', 'كورولا', 'کۆرۆلا', FALSE, 'toyota/corolla', '/images/models/toyota-corolla.png', 'corolla', '1.2', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Toyota' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Land Cruiser', 'لاند كروزر', 'لاند کروزەر', FALSE, 'toyota/land-cruiser', '/images/models/toyota-land-cruiser.png', 'land_cruiser', '1.3', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Toyota' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Prado', 'برادو', 'پرادۆ', FALSE, 'toyota/prado', '/images/models/toyota-prado.png', 'prado', '1.4', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Toyota' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('RAV4', 'راف فور', 'ڕاڤ فۆر', FALSE, 'toyota/rav4', '/images/models/toyota-rav4.png', 'rav4', '1.5', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Toyota' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Hilux', 'هايلوكس', 'هایلۆکس', FALSE, 'toyota/hilux', '/images/models/toyota-hilux.png', 'hilux', '1.6', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Toyota' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Yaris', 'ياريس', 'یاریس', FALSE, 'toyota/yaris', '/images/models/toyota-yaris.png', 'yaris', '1.7', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Toyota' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Avalon', 'افالون', 'ئەڤالۆن', FALSE, 'toyota/avalon', '/images/models/toyota-avalon.png', 'avalon', '1.8', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Toyota' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Fortuner', 'فورتشنر', 'فۆرتشنەر', FALSE, 'toyota/fortuner', '/images/models/toyota-fortuner.png', 'fortuner', '1.9', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Toyota' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Supra', 'سوبرا', 'سوپرا', FALSE, 'toyota/supra', '/images/models/toyota-supra.png', 'supra', '1.10', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Toyota' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

-- ============================================================================
-- BRAND: Hyundai (هيونداي)
-- ============================================================================
INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Hyundai', 'هيونداي', 'هیۆندای', TRUE, 'hyundai', '/images/brands/hyundai.png', 'hyundai', '2', NULL, (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Elantra', 'النترا', 'ئێلانترا', FALSE, 'hyundai/elantra', '/images/models/hyundai-elantra.png', 'elantra', '2.1', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Hyundai' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Sonata', 'سوناتا', 'سۆناتا', FALSE, 'hyundai/sonata', '/images/models/hyundai-sonata.png', 'sonata', '2.2', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Hyundai' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Tucson', 'توسان', 'تووسان', FALSE, 'hyundai/tucson', '/images/models/hyundai-tucson.png', 'tucson', '2.3', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Hyundai' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Santa Fe', 'سانتا في', 'سانتا فێ', FALSE, 'hyundai/santa-fe', '/images/models/hyundai-santa-fe.png', 'santa_fe', '2.4', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Hyundai' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Accent', 'اكسنت', 'ئەکسێنت', FALSE, 'hyundai/accent', '/images/models/hyundai-accent.png', 'accent', '2.5', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Hyundai' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Azera', 'ازيرا', 'ئەزێرا', FALSE, 'hyundai/azera', '/images/models/hyundai-azera.png', 'azera', '2.6', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Hyundai' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Palisade', 'باليسيد', 'پالیسەید', FALSE, 'hyundai/palisade', '/images/models/hyundai-palisade.png', 'palisade', '2.7', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Hyundai' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Creta', 'كريتا', 'کرێتا', FALSE, 'hyundai/creta', '/images/models/hyundai-creta.png', 'creta', '2.8', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Hyundai' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

-- ============================================================================
-- BRAND: Kia (كيا)
-- ============================================================================
INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Kia', 'كيا', 'کیا', TRUE, 'kia', '/images/brands/kia.png', 'kia', '3', NULL, (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Optima', 'اوبتيما', 'ئۆپتیما', FALSE, 'kia/optima', '/images/models/kia-optima.png', 'optima', '3.1', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Kia' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Sportage', 'سبورتاج', 'سپۆرتاج', FALSE, 'kia/sportage', '/images/models/kia-sportage.png', 'sportage', '3.2', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Kia' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Sorento', 'سورينتو', 'سۆرێنتۆ', FALSE, 'kia/sorento', '/images/models/kia-sorento.png', 'sorento', '3.3', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Kia' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Cerato', 'سيراتو', 'سێراتۆ', FALSE, 'kia/cerato', '/images/models/kia-cerato.png', 'cerato', '3.4', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Kia' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('K5', 'كي 5', 'کەی 5', FALSE, 'kia/k5', '/images/models/kia-k5.png', 'k5', '3.5', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Kia' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Carnival', 'كارنيفال', 'کارنیڤال', FALSE, 'kia/carnival', '/images/models/kia-carnival.png', 'carnival', '3.6', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Kia' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Telluride', 'تيلورايد', 'تێلوراید', FALSE, 'kia/telluride', '/images/models/kia-telluride.png', 'telluride', '3.7', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Kia' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));


-- ============================================================================
-- BRAND: Nissan (نيسان)
-- ============================================================================
INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Nissan', 'نيسان', 'نیسان', TRUE, 'nissan', '/images/brands/nissan.png', 'nissan', '4', NULL, (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Altima', 'التيما', 'ئەلتیما', FALSE, 'nissan/altima', '/images/models/nissan-altima.png', 'altima', '4.1', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Nissan' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Maxima', 'ماكسيما', 'ماکسیما', FALSE, 'nissan/maxima', '/images/models/nissan-maxima.png', 'maxima', '4.2', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Nissan' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Patrol', 'باترول', 'پاترۆل', FALSE, 'nissan/patrol', '/images/models/nissan-patrol.png', 'patrol', '4.3', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Nissan' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('X-Trail', 'اكس تريل', 'ئێکس ترەیل', FALSE, 'nissan/x-trail', '/images/models/nissan-x-trail.png', 'x_trail', '4.4', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Nissan' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Sunny', 'صني', 'سەنی', FALSE, 'nissan/sunny', '/images/models/nissan-sunny.png', 'sunny', '4.5', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Nissan' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Sentra', 'سنترا', 'سێنترا', FALSE, 'nissan/sentra', '/images/models/nissan-sentra.png', 'sentra', '4.6', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Nissan' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Kicks', 'كيكس', 'کیکس', FALSE, 'nissan/kicks', '/images/models/nissan-kicks.png', 'kicks', '4.7', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Nissan' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Pathfinder', 'باثفايندر', 'پاسفایندەر', FALSE, 'nissan/pathfinder', '/images/models/nissan-pathfinder.png', 'pathfinder', '4.8', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Nissan' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

-- ============================================================================
-- BRAND: Honda (هوندا)
-- ============================================================================
INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Honda', 'هوندا', 'هۆندا', TRUE, 'honda', '/images/brands/honda.png', 'honda', '5', NULL, (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Accord', 'اكورد', 'ئەکۆرد', FALSE, 'honda/accord', '/images/models/honda-accord.png', 'accord', '5.1', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Honda' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Civic', 'سيفيك', 'سیڤیک', FALSE, 'honda/civic', '/images/models/honda-civic.png', 'civic', '5.2', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Honda' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('CR-V', 'سي ار في', 'سی ئار ڤی', FALSE, 'honda/cr-v', '/images/models/honda-cr-v.png', 'cr_v', '5.3', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Honda' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Pilot', 'بايلوت', 'پایلۆت', FALSE, 'honda/pilot', '/images/models/honda-pilot.png', 'pilot', '5.4', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Honda' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('HR-V', 'اتش ار في', 'ئێچ ئار ڤی', FALSE, 'honda/hr-v', '/images/models/honda-hr-v.png', 'hr_v', '5.5', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Honda' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('City', 'سيتي', 'سیتی', FALSE, 'honda/city', '/images/models/honda-city.png', 'city', '5.6', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Honda' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

-- ============================================================================
-- BRAND: Mercedes-Benz (مرسيدس)
-- ============================================================================
INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Mercedes-Benz', 'مرسيدس', 'مێرسێدێس', TRUE, 'mercedes-benz', '/images/brands/mercedes-benz.png', 'mercedes', '6', NULL, (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('C-Class', 'سي كلاس', 'سی کلاس', FALSE, 'mercedes-benz/c-class', '/images/models/mercedes-c-class.png', 'c_class', '6.1', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Mercedes-Benz' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('E-Class', 'اي كلاس', 'ئی کلاس', FALSE, 'mercedes-benz/e-class', '/images/models/mercedes-e-class.png', 'e_class', '6.2', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Mercedes-Benz' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('S-Class', 'اس كلاس', 'ئێس کلاس', FALSE, 'mercedes-benz/s-class', '/images/models/mercedes-s-class.png', 's_class', '6.3', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Mercedes-Benz' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('GLE', 'جي ال اي', 'جی ئێل ئی', FALSE, 'mercedes-benz/gle', '/images/models/mercedes-gle.png', 'gle', '6.4', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Mercedes-Benz' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('GLC', 'جي ال سي', 'جی ئێل سی', FALSE, 'mercedes-benz/glc', '/images/models/mercedes-glc.png', 'glc', '6.5', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Mercedes-Benz' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('GLS', 'جي ال اس', 'جی ئێل ئێس', FALSE, 'mercedes-benz/gls', '/images/models/mercedes-gls.png', 'gls', '6.6', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Mercedes-Benz' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('A-Class', 'ايه كلاس', 'ئەی کلاس', FALSE, 'mercedes-benz/a-class', '/images/models/mercedes-a-class.png', 'a_class', '6.7', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Mercedes-Benz' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('AMG GT', 'ايه ام جي جي تي', 'ئەی ئێم جی جی تی', FALSE, 'mercedes-benz/amg-gt', '/images/models/mercedes-amg-gt.png', 'amg_gt', '6.8', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Mercedes-Benz' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

-- ============================================================================
-- BRAND: BMW (بي ام دبليو)
-- ============================================================================
INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('BMW', 'بي ام دبليو', 'بی ئێم دەبڵیو', TRUE, 'bmw', '/images/brands/bmw.png', 'bmw', '7', NULL, (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('3 Series', 'الفئة الثالثة', 'پۆلی سێیەم', FALSE, 'bmw/3-series', '/images/models/bmw-3-series.png', '3_series', '7.1', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('5 Series', 'الفئة الخامسة', 'پۆلی پێنجەم', FALSE, 'bmw/5-series', '/images/models/bmw-5-series.png', '5_series', '7.2', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('7 Series', 'الفئة السابعة', 'پۆلی حەوتەم', FALSE, 'bmw/7-series', '/images/models/bmw-7-series.png', '7_series', '7.3', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('X3', 'اكس 3', 'ئێکس 3', FALSE, 'bmw/x3', '/images/models/bmw-x3.png', 'x3', '7.4', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('X5', 'اكس 5', 'ئێکس 5', FALSE, 'bmw/x5', '/images/models/bmw-x5.png', 'x5', '7.5', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('X7', 'اكس 7', 'ئێکس 7', FALSE, 'bmw/x7', '/images/models/bmw-x7.png', 'x7', '7.6', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('X6', 'اكس 6', 'ئێکس 6', FALSE, 'bmw/x6', '/images/models/bmw-x6.png', 'x6', '7.7', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('M4', 'ام 4', 'ئێم 4', FALSE, 'bmw/m4', '/images/models/bmw-m4.png', 'm4', '7.8', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));


-- ============================================================================
-- BRAND: Audi (اودي)
-- ============================================================================
INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Audi', 'اودي', 'ئاودی', TRUE, 'audi', '/images/brands/audi.png', 'audi', '8', NULL, (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('A4', 'ايه 4', 'ئەی 4', FALSE, 'audi/a4', '/images/models/audi-a4.png', 'a4', '8.1', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Audi' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('A6', 'ايه 6', 'ئەی 6', FALSE, 'audi/a6', '/images/models/audi-a6.png', 'a6', '8.2', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Audi' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('A8', 'ايه 8', 'ئەی 8', FALSE, 'audi/a8', '/images/models/audi-a8.png', 'a8', '8.3', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Audi' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Q5', 'كيو 5', 'کیو 5', FALSE, 'audi/q5', '/images/models/audi-q5.png', 'q5', '8.4', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Audi' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Q7', 'كيو 7', 'کیو 7', FALSE, 'audi/q7', '/images/models/audi-q7.png', 'q7', '8.5', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Audi' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Q8', 'كيو 8', 'کیو 8', FALSE, 'audi/q8', '/images/models/audi-q8.png', 'q8', '8.6', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Audi' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('RS6', 'ار اس 6', 'ئار ئێس 6', FALSE, 'audi/rs6', '/images/models/audi-rs6.png', 'rs6', '8.7', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Audi' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

-- ============================================================================
-- BRAND: Lexus (لكزس)
-- ============================================================================
INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Lexus', 'لكزس', 'لێکسەس', TRUE, 'lexus', '/images/brands/lexus.png', 'lexus', '9', NULL, (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('ES', 'اي اس', 'ئی ئێس', FALSE, 'lexus/es', '/images/models/lexus-es.png', 'es', '9.1', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Lexus' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('LS', 'ال اس', 'ئێل ئێس', FALSE, 'lexus/ls', '/images/models/lexus-ls.png', 'ls', '9.2', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Lexus' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('RX', 'ار اكس', 'ئار ئێکس', FALSE, 'lexus/rx', '/images/models/lexus-rx.png', 'rx', '9.3', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Lexus' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('LX', 'ال اكس', 'ئێل ئێکس', FALSE, 'lexus/lx', '/images/models/lexus-lx.png', 'lx', '9.4', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Lexus' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('GX', 'جي اكس', 'جی ئێکس', FALSE, 'lexus/gx', '/images/models/lexus-gx.png', 'gx', '9.5', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Lexus' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('NX', 'ان اكس', 'ئێن ئێکس', FALSE, 'lexus/nx', '/images/models/lexus-nx.png', 'nx', '9.6', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Lexus' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('IS', 'اي اس', 'ئای ئێس', FALSE, 'lexus/is', '/images/models/lexus-is.png', 'is_lexus', '9.7', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Lexus' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

-- ============================================================================
-- BRAND: Ford (فورد)
-- ============================================================================
INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Ford', 'فورد', 'فۆرد', TRUE, 'ford', '/images/brands/ford.png', 'ford', '10', NULL, (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('F-150', 'اف 150', 'ئێف 150', FALSE, 'ford/f-150', '/images/models/ford-f-150.png', 'f_150', '10.1', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Ford' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Explorer', 'اكسبلورر', 'ئێکسپلۆرەر', FALSE, 'ford/explorer', '/images/models/ford-explorer.png', 'explorer', '10.2', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Ford' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Mustang', 'موستانج', 'مۆستانگ', FALSE, 'ford/mustang', '/images/models/ford-mustang.png', 'mustang', '10.3', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Ford' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Expedition', 'اكسبيديشن', 'ئێکسپێدیشن', FALSE, 'ford/expedition', '/images/models/ford-expedition.png', 'expedition', '10.4', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Ford' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Edge', 'ايدج', 'ئێدج', FALSE, 'ford/edge', '/images/models/ford-edge.png', 'edge', '10.5', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Ford' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Taurus', 'تورس', 'تۆرس', FALSE, 'ford/taurus', '/images/models/ford-taurus.png', 'taurus', '10.6', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Ford' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Bronco', 'برونكو', 'برۆنکۆ', FALSE, 'ford/bronco', '/images/models/ford-bronco.png', 'bronco', '10.7', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Ford' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

-- ============================================================================
-- BRAND: Chevrolet (شيفروليه)
-- ============================================================================
INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Chevrolet', 'شيفروليه', 'شێڤرۆلێت', TRUE, 'chevrolet', '/images/brands/chevrolet.png', 'chevrolet', '11', NULL, (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Tahoe', 'تاهو', 'تاهۆ', FALSE, 'chevrolet/tahoe', '/images/models/chevrolet-tahoe.png', 'tahoe', '11.1', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Chevrolet' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Suburban', 'سوبربان', 'سوبەربان', FALSE, 'chevrolet/suburban', '/images/models/chevrolet-suburban.png', 'suburban', '11.2', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Chevrolet' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Silverado', 'سيلفرادو', 'سیلڤەرادۆ', FALSE, 'chevrolet/silverado', '/images/models/chevrolet-silverado.png', 'silverado', '11.3', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Chevrolet' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Camaro', 'كامارو', 'کامارۆ', FALSE, 'chevrolet/camaro', '/images/models/chevrolet-camaro.png', 'camaro', '11.4', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Chevrolet' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Malibu', 'ماليبو', 'مالیبو', FALSE, 'chevrolet/malibu', '/images/models/chevrolet-malibu.png', 'malibu', '11.5', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Chevrolet' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Traverse', 'ترافيرس', 'تراڤێرس', FALSE, 'chevrolet/traverse', '/images/models/chevrolet-traverse.png', 'traverse', '11.6', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Chevrolet' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id)
VALUES ('Equinox', 'ايكوينوكس', 'ئێکوینۆکس', FALSE, 'chevrolet/equinox', '/images/models/chevrolet-equinox.png', 'equinox', '11.7', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Chevrolet' AND is_brand = TRUE), (SELECT category_id FROM categories WHERE hierarchy_path = '1.1'));

