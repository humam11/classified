-- Insert Car Brands and Models for category_id = 2
-- PART 1: Insert all BRANDS first (run this separately before models)

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id) VALUES
-- German Brands
('Mercedes-Benz', 'مرسيدس بنز', 'مێرسێدێس بێنز', TRUE, 'mercedes-benz', '/images/brands/mercedes.jpg', 'mercedes', 'cars.mercedes_benz', NULL, 2),
('BMW', 'بي إم دبليو', 'بی ئێم دبلیو', TRUE, 'bmw', '/images/brands/bmw.jpg', 'bmw', 'cars.bmw', NULL, 2),
('Audi', 'أودي', 'ئاودی', TRUE, 'audi', '/images/brands/audi.jpg', 'audi', 'cars.audi', NULL, 2),
('Volkswagen', 'فولكس فاجن', 'فۆلکسڤاگن', TRUE, 'volkswagen', '/images/brands/volkswagen.jpg', 'volkswagen', 'cars.volkswagen', NULL, 2),
('Porsche', 'بورش', 'پۆرشە', TRUE, 'porsche', '/images/brands/porsche.jpg', 'porsche', 'cars.porsche', NULL, 2),

-- Japanese Brands
('Toyota', 'تويوتا', 'تۆیۆتا', TRUE, 'toyota', '/images/brands/toyota.jpg', 'toyota', 'cars.toyota', NULL, 2),
('Honda', 'هوندا', 'هۆندا', TRUE, 'honda', '/images/brands/honda.jpg', 'honda', 'cars.honda', NULL, 2),
('Nissan', 'نيسان', 'نیسان', TRUE, 'nissan', '/images/brands/nissan.jpg', 'nissan', 'cars.nissan', NULL, 2),
('Mazda', 'مازدا', 'مازدا', TRUE, 'mazda', '/images/brands/mazda.jpg', 'mazda', 'cars.mazda', NULL, 2),
('Lexus', 'لكزس', 'لێکسوس', TRUE, 'lexus', '/images/brands/lexus.jpg', 'lexus', 'cars.lexus', NULL, 2),
('Infiniti', 'إنفينيتي', 'ئینفینیتی', TRUE, 'infiniti', '/images/brands/infiniti.jpg', 'infiniti', 'cars.infiniti', NULL, 2),
('Subaru', 'سوبارو', 'سوبارو', TRUE, 'subaru', '/images/brands/subaru.jpg', 'subaru', 'cars.subaru', NULL, 2),
('Mitsubishi', 'ميتسوبيشي', 'میتسوبیشی', TRUE, 'mitsubishi', '/images/brands/mitsubishi.jpg', 'mitsubishi', 'cars.mitsubishi', NULL, 2),

-- American Brands
('Ford', 'فورد', 'فۆرد', TRUE, 'ford', '/images/brands/ford.jpg', 'ford', 'cars.ford', NULL, 2),
('Chevrolet', 'شيفروليه', 'شیفرۆلێت', TRUE, 'chevrolet', '/images/brands/chevrolet.jpg', 'chevrolet', 'cars.chevrolet', NULL, 2),
('GMC', 'جي إم سي', 'جی ئێم سی', TRUE, 'gmc', '/images/brands/gmc.jpg', 'gmc', 'cars.gmc', NULL, 2),
('Dodge', 'دودج', 'دۆدج', TRUE, 'dodge', '/images/brands/dodge.jpg', 'dodge', 'cars.dodge', NULL, 2),
('Jeep', 'جيب', 'جیپ', TRUE, 'jeep', '/images/brands/jeep.jpg', 'jeep', 'cars.jeep', NULL, 2),
('Tesla', 'تسلا', 'تێسلا', TRUE, 'tesla', '/images/brands/tesla.jpg', 'tesla', 'cars.tesla', NULL, 2),
('Cadillac', 'كاديلاك', 'کادیلاک', TRUE, 'cadillac', '/images/brands/cadillac.jpg', 'cadillac', 'cars.cadillac', NULL, 2),
('Ram', 'رام', 'ڕام', TRUE, 'ram', '/images/brands/ram.jpg', 'ram', 'cars.ram', NULL, 2),

-- Korean Brands
('Hyundai', 'هيونداي', 'هیوندای', TRUE, 'hyundai', '/images/brands/hyundai.jpg', 'hyundai', 'cars.hyundai', NULL, 2),
('Kia', 'كيا', 'کیا', TRUE, 'kia', '/images/brands/kia.jpg', 'kia', 'cars.kia', NULL, 2),
('Genesis', 'جينيسيس', 'جێنێسیس', TRUE, 'genesis', '/images/brands/genesis.jpg', 'genesis', 'cars.genesis', NULL, 2),

-- British Brands
('Land Rover', 'لاند روفر', 'لاند ڕۆڤەر', TRUE, 'land-rover', '/images/brands/land-rover.jpg', 'land_rover', 'cars.land_rover', NULL, 2),
('Jaguar', 'جاكوار', 'جاگوار', TRUE, 'jaguar', '/images/brands/jaguar.jpg', 'jaguar', 'cars.jaguar', NULL, 2),
('Mini', 'ميني', 'مینی', TRUE, 'mini', '/images/brands/mini.jpg', 'mini', 'cars.mini', NULL, 2),
('Bentley', 'بنتلي', 'بێنتلی', TRUE, 'bentley', '/images/brands/bentley.jpg', 'bentley', 'cars.bentley', NULL, 2),
('Rolls-Royce', 'رولز رويس', 'ڕۆلز ڕۆیس', TRUE, 'rolls-royce', '/images/brands/rolls-royce.jpg', 'rolls_royce', 'cars.rolls_royce', NULL, 2),
('Aston Martin', 'أستون مارتن', 'ئاستۆن مارتن', TRUE, 'aston-martin', '/images/brands/aston-martin.jpg', 'aston_martin', 'cars.aston_martin', NULL, 2),

-- Italian Brands
('Ferrari', 'فيراري', 'فێراری', TRUE, 'ferrari', '/images/brands/ferrari.jpg', 'ferrari', 'cars.ferrari', NULL, 2),
('Lamborghini', 'لامبورغيني', 'لامبۆرگینی', TRUE, 'lamborghini', '/images/brands/lamborghini.jpg', 'lamborghini', 'cars.lamborghini', NULL, 2),
('Maserati', 'مازيراتي', 'مازێراتی', TRUE, 'maserati', '/images/brands/maserati.jpg', 'maserati', 'cars.maserati', NULL, 2),
('Alfa Romeo', 'ألفا روميو', 'ئالفا ڕۆمیۆ', TRUE, 'alfa-romeo', '/images/brands/alfa-romeo.jpg', 'alfa_romeo', 'cars.alfa_romeo', NULL, 2),
('Fiat', 'فيات', 'فیات', TRUE, 'fiat', '/images/brands/fiat.jpg', 'fiat', 'cars.fiat', NULL, 2),

-- French Brands
('Peugeot', 'بيجو', 'پیژۆ', TRUE, 'peugeot', '/images/brands/peugeot.jpg', 'peugeot', 'cars.peugeot', NULL, 2),
('Renault', 'رينو', 'ڕینۆ', TRUE, 'renault', '/images/brands/renault.jpg', 'renault', 'cars.renault', NULL, 2),
('Citroen', 'سيتروين', 'سیترۆین', TRUE, 'citroen', '/images/brands/citroen.jpg', 'citroen', 'cars.citroen', NULL, 2),

-- Swedish Brands
('Volvo', 'فولفو', 'ڤۆلڤۆ', TRUE, 'volvo', '/images/brands/volvo.jpg', 'volvo', 'cars.volvo', NULL, 2),

-- Chinese Brands
('BYD', 'بي واي دي', 'بی وای دی', TRUE, 'byd', '/images/brands/byd.jpg', 'byd', 'cars.byd', NULL, 2),
('Geely', 'جيلي', 'جیلی', TRUE, 'geely', '/images/brands/geely.jpg', 'geely', 'cars.geely', NULL, 2),
('MG', 'إم جي', 'ئێم جی', TRUE, 'mg', '/images/brands/mg.jpg', 'mg', 'cars.mg', NULL, 2);


-- PART 2: Insert all MODELS (run this AFTER brands are inserted)
-- Uses subqueries to get parent_id from existing brands

INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, automation_keyword, hierarchy_path, parent_id, category_id) VALUES
-- Mercedes-Benz Models
('A-Class', 'الفئة A', 'A-کلاس', FALSE, 'mercedes-a-class', '/images/models/mercedes-a-class.jpg', 'mercedes_a_class', 'cars.mercedes_benz.a_class', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Mercedes-Benz' AND category_id = 2), 2),
('C-Class', 'الفئة C', 'C-کلاس', FALSE, 'mercedes-c-class', '/images/models/mercedes-c-class.jpg', 'mercedes_c_class', 'cars.mercedes_benz.c_class', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Mercedes-Benz' AND category_id = 2), 2),
('E-Class', 'الفئة E', 'E-کلاس', FALSE, 'mercedes-e-class', '/images/models/mercedes-e-class.jpg', 'mercedes_e_class', 'cars.mercedes_benz.e_class', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Mercedes-Benz' AND category_id = 2), 2),
('S-Class', 'الفئة S', 'S-کلاس', FALSE, 'mercedes-s-class', '/images/models/mercedes-s-class.jpg', 'mercedes_s_class', 'cars.mercedes_benz.s_class', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Mercedes-Benz' AND category_id = 2), 2),
('GLA', 'جي إل إيه', 'جی ئێل ئەی', FALSE, 'mercedes-gla', '/images/models/mercedes-gla.jpg', 'mercedes_gla', 'cars.mercedes_benz.gla', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Mercedes-Benz' AND category_id = 2), 2),
('GLC', 'جي إل سي', 'جی ئێل سی', FALSE, 'mercedes-glc', '/images/models/mercedes-glc.jpg', 'mercedes_glc', 'cars.mercedes_benz.glc', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Mercedes-Benz' AND category_id = 2), 2),
('GLE', 'جي إل إي', 'جی ئێل ئی', FALSE, 'mercedes-gle', '/images/models/mercedes-gle.jpg', 'mercedes_gle', 'cars.mercedes_benz.gle', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Mercedes-Benz' AND category_id = 2), 2),
('GLS', 'جي إل إس', 'جی ئێل ئێس', FALSE, 'mercedes-gls', '/images/models/mercedes-gls.jpg', 'mercedes_gls', 'cars.mercedes_benz.gls', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Mercedes-Benz' AND category_id = 2), 2),
('AMG GT', 'إيه إم جي جي تي', 'ئەی ئێم جی جی تی', FALSE, 'mercedes-amg-gt', '/images/models/mercedes-amg-gt.jpg', 'mercedes_amg_gt', 'cars.mercedes_benz.amg_gt', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Mercedes-Benz' AND category_id = 2), 2),
('EQS', 'إي كيو إس', 'ئی کیو ئێس', FALSE, 'mercedes-eqs', '/images/models/mercedes-eqs.jpg', 'mercedes_eqs', 'cars.mercedes_benz.eqs', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Mercedes-Benz' AND category_id = 2), 2),
('G-Class', 'الفئة G', 'G-کلاس', FALSE, 'mercedes-g-class', '/images/models/mercedes-g-class.jpg', 'mercedes_g_class', 'cars.mercedes_benz.g_class', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Mercedes-Benz' AND category_id = 2), 2),
('CLA', 'سي إل إيه', 'سی ئێل ئەی', FALSE, 'mercedes-cla', '/images/models/mercedes-cla.jpg', 'mercedes_cla', 'cars.mercedes_benz.cla', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Mercedes-Benz' AND category_id = 2), 2),

-- BMW Models
('1 Series', 'الفئة 1', '1 سێری', FALSE, 'bmw-1-series', '/images/models/bmw-1-series.jpg', 'bmw_1_series', 'cars.bmw.series_1', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND category_id = 2), 2),
('3 Series', 'الفئة 3', '3 سێری', FALSE, 'bmw-3-series', '/images/models/bmw-3-series.jpg', 'bmw_3_series', 'cars.bmw.series_3', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND category_id = 2), 2),
('5 Series', 'الفئة 5', '5 سێری', FALSE, 'bmw-5-series', '/images/models/bmw-5-series.jpg', 'bmw_5_series', 'cars.bmw.series_5', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND category_id = 2), 2),
('7 Series', 'الفئة 7', '7 سێری', FALSE, 'bmw-7-series', '/images/models/bmw-7-series.jpg', 'bmw_7_series', 'cars.bmw.series_7', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND category_id = 2), 2),
('X1', 'إكس 1', 'ئێکس 1', FALSE, 'bmw-x1', '/images/models/bmw-x1.jpg', 'bmw_x1', 'cars.bmw.x1', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND category_id = 2), 2),
('X3', 'إكس 3', 'ئێکس 3', FALSE, 'bmw-x3', '/images/models/bmw-x3.jpg', 'bmw_x3', 'cars.bmw.x3', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND category_id = 2), 2),
('X5', 'إكس 5', 'ئێکس 5', FALSE, 'bmw-x5', '/images/models/bmw-x5.jpg', 'bmw_x5', 'cars.bmw.x5', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND category_id = 2), 2),
('X7', 'إكس 7', 'ئێکس 7', FALSE, 'bmw-x7', '/images/models/bmw-x7.jpg', 'bmw_x7', 'cars.bmw.x7', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND category_id = 2), 2),
('M3', 'إم 3', 'ئێم 3', FALSE, 'bmw-m3', '/images/models/bmw-m3.jpg', 'bmw_m3', 'cars.bmw.m3', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND category_id = 2), 2),
('M5', 'إم 5', 'ئێم 5', FALSE, 'bmw-m5', '/images/models/bmw-m5.jpg', 'bmw_m5', 'cars.bmw.m5', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND category_id = 2), 2),
('i4', 'آي 4', 'ئای 4', FALSE, 'bmw-i4', '/images/models/bmw-i4.jpg', 'bmw_i4', 'cars.bmw.i4', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND category_id = 2), 2),
('iX', 'آي إكس', 'ئای ئێکس', FALSE, 'bmw-ix', '/images/models/bmw-ix.jpg', 'bmw_ix', 'cars.bmw.ix', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND category_id = 2), 2),
('Z4', 'زد 4', 'زێد 4', FALSE, 'bmw-z4', '/images/models/bmw-z4.jpg', 'bmw_z4', 'cars.bmw.z4', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND category_id = 2), 2),
('X6', 'إكس 6', 'ئێکس 6', FALSE, 'bmw-x6', '/images/models/bmw-x6.jpg', 'bmw_x6', 'cars.bmw.x6', (SELECT brand_model_id FROM brands_models WHERE name_english = 'BMW' AND category_id = 2), 2),

-- Audi Models
('A3', 'إيه 3', 'ئەی 3', FALSE, 'audi-a3', '/images/models/audi-a3.jpg', 'audi_a3', 'cars.audi.a3', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Audi' AND category_id = 2), 2),
('A4', 'إيه 4', 'ئەی 4', FALSE, 'audi-a4', '/images/models/audi-a4.jpg', 'audi_a4', 'cars.audi.a4', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Audi' AND category_id = 2), 2),
('A6', 'إيه 6', 'ئەی 6', FALSE, 'audi-a6', '/images/models/audi-a6.jpg', 'audi_a6', 'cars.audi.a6', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Audi' AND category_id = 2), 2),
('A8', 'إيه 8', 'ئەی 8', FALSE, 'audi-a8', '/images/models/audi-a8.jpg', 'audi_a8', 'cars.audi.a8', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Audi' AND category_id = 2), 2),
('Q3', 'كيو 3', 'کیو 3', FALSE, 'audi-q3', '/images/models/audi-q3.jpg', 'audi_q3', 'cars.audi.q3', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Audi' AND category_id = 2), 2),
('Q5', 'كيو 5', 'کیو 5', FALSE, 'audi-q5', '/images/models/audi-q5.jpg', 'audi_q5', 'cars.audi.q5', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Audi' AND category_id = 2), 2),
('Q7', 'كيو 7', 'کیو 7', FALSE, 'audi-q7', '/images/models/audi-q7.jpg', 'audi_q7', 'cars.audi.q7', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Audi' AND category_id = 2), 2),
('Q8', 'كيو 8', 'کیو 8', FALSE, 'audi-q8', '/images/models/audi-q8.jpg', 'audi_q8', 'cars.audi.q8', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Audi' AND category_id = 2), 2),
('e-tron', 'إي ترون', 'ئی ترۆن', FALSE, 'audi-e-tron', '/images/models/audi-e-tron.jpg', 'audi_e_tron', 'cars.audi.e_tron', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Audi' AND category_id = 2), 2),
('RS6', 'آر إس 6', 'ئاڕ ئێس 6', FALSE, 'audi-rs6', '/images/models/audi-rs6.jpg', 'audi_rs6', 'cars.audi.rs6', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Audi' AND category_id = 2), 2),
('TT', 'تي تي', 'تی تی', FALSE, 'audi-tt', '/images/models/audi-tt.jpg', 'audi_tt', 'cars.audi.tt', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Audi' AND category_id = 2), 2),

-- Volkswagen Models
('Golf', 'جولف', 'گۆلف', FALSE, 'volkswagen-golf', '/images/models/vw-golf.jpg', 'vw_golf', 'cars.volkswagen.golf', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Volkswagen' AND category_id = 2), 2),
('Passat', 'باسات', 'پاسات', FALSE, 'volkswagen-passat', '/images/models/vw-passat.jpg', 'vw_passat', 'cars.volkswagen.passat', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Volkswagen' AND category_id = 2), 2),
('Tiguan', 'تيجوان', 'تیگوان', FALSE, 'volkswagen-tiguan', '/images/models/vw-tiguan.jpg', 'vw_tiguan', 'cars.volkswagen.tiguan', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Volkswagen' AND category_id = 2), 2),
('Touareg', 'طوارق', 'تواڕێگ', FALSE, 'volkswagen-touareg', '/images/models/vw-touareg.jpg', 'vw_touareg', 'cars.volkswagen.touareg', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Volkswagen' AND category_id = 2), 2),
('Polo', 'بولو', 'پۆلۆ', FALSE, 'volkswagen-polo', '/images/models/vw-polo.jpg', 'vw_polo', 'cars.volkswagen.polo', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Volkswagen' AND category_id = 2), 2),
('Arteon', 'أرتيون', 'ئارتیۆن', FALSE, 'volkswagen-arteon', '/images/models/vw-arteon.jpg', 'vw_arteon', 'cars.volkswagen.arteon', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Volkswagen' AND category_id = 2), 2),
('ID.4', 'آي دي 4', 'ئای دی 4', FALSE, 'volkswagen-id4', '/images/models/vw-id4.jpg', 'vw_id4', 'cars.volkswagen.id4', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Volkswagen' AND category_id = 2), 2),
('Jetta', 'جيتا', 'جێتا', FALSE, 'volkswagen-jetta', '/images/models/vw-jetta.jpg', 'vw_jetta', 'cars.volkswagen.jetta', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Volkswagen' AND category_id = 2), 2),

-- Porsche Models
('911', '911', '911', FALSE, 'porsche-911', '/images/models/porsche-911.jpg', 'porsche_911', 'cars.porsche.p911', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Porsche' AND category_id = 2), 2),
('Cayenne', 'كايين', 'کایێن', FALSE, 'porsche-cayenne', '/images/models/porsche-cayenne.jpg', 'porsche_cayenne', 'cars.porsche.cayenne', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Porsche' AND category_id = 2), 2),
('Macan', 'ماكان', 'ماکان', FALSE, 'porsche-macan', '/images/models/porsche-macan.jpg', 'porsche_macan', 'cars.porsche.macan', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Porsche' AND category_id = 2), 2),
('Panamera', 'باناميرا', 'پانامێرا', FALSE, 'porsche-panamera', '/images/models/porsche-panamera.jpg', 'porsche_panamera', 'cars.porsche.panamera', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Porsche' AND category_id = 2), 2),
('Taycan', 'تايكان', 'تایکان', FALSE, 'porsche-taycan', '/images/models/porsche-taycan.jpg', 'porsche_taycan', 'cars.porsche.taycan', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Porsche' AND category_id = 2), 2),
('718', '718', '718', FALSE, 'porsche-718', '/images/models/porsche-718.jpg', 'porsche_718', 'cars.porsche.p718', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Porsche' AND category_id = 2), 2),

-- Toyota Models
('Corolla', 'كورولا', 'کۆرۆلا', FALSE, 'toyota-corolla', '/images/models/toyota-corolla.jpg', 'toyota_corolla', 'cars.toyota.corolla', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Toyota' AND category_id = 2), 2),
('Camry', 'كامري', 'کامری', FALSE, 'toyota-camry', '/images/models/toyota-camry.jpg', 'toyota_camry', 'cars.toyota.camry', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Toyota' AND category_id = 2), 2),
('RAV4', 'راف 4', 'ڕاڤ 4', FALSE, 'toyota-rav4', '/images/models/toyota-rav4.jpg', 'toyota_rav4', 'cars.toyota.rav4', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Toyota' AND category_id = 2), 2),
('Land Cruiser', 'لاند كروزر', 'لاند کڕووزەر', FALSE, 'toyota-land-cruiser', '/images/models/toyota-land-cruiser.jpg', 'toyota_land_cruiser', 'cars.toyota.land_cruiser', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Toyota' AND category_id = 2), 2),
('Hilux', 'هايلكس', 'هایلۆکس', FALSE, 'toyota-hilux', '/images/models/toyota-hilux.jpg', 'toyota_hilux', 'cars.toyota.hilux', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Toyota' AND category_id = 2), 2),
('Prius', 'بريوس', 'پریوس', FALSE, 'toyota-prius', '/images/models/toyota-prius.jpg', 'toyota_prius', 'cars.toyota.prius', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Toyota' AND category_id = 2), 2),
('Highlander', 'هايلاندر', 'هایلاندەر', FALSE, 'toyota-highlander', '/images/models/toyota-highlander.jpg', 'toyota_highlander', 'cars.toyota.highlander', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Toyota' AND category_id = 2), 2),
('Yaris', 'ياريس', 'یاریس', FALSE, 'toyota-yaris', '/images/models/toyota-yaris.jpg', 'toyota_yaris', 'cars.toyota.yaris', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Toyota' AND category_id = 2), 2),
('Fortuner', 'فورتشنر', 'فۆرچنەر', FALSE, 'toyota-fortuner', '/images/models/toyota-fortuner.jpg', 'toyota_fortuner', 'cars.toyota.fortuner', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Toyota' AND category_id = 2), 2),
('Supra', 'سوبرا', 'سوپرا', FALSE, 'toyota-supra', '/images/models/toyota-supra.jpg', 'toyota_supra', 'cars.toyota.supra', (SELECT brand_model_id FROM brands_models WHERE name_english = 'Toyota' AND category_id = 2), 2);