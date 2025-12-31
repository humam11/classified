-- Categories Trigger
CREATE OR REPLACE FUNCTION handle_categories_notifications()
RETURNS TRIGGER AS $$
DECLARE
    payload JSON;
BEGIN
    CASE TG_OP
        WHEN 'INSERT' THEN
            payload = json_build_object(
                'type', 'category',
                'op', 'INSERT',
                'categoryId', NEW.category_id,
                'nameArabic', NEW.name_arabic,
                'nameKurdish', NEW.name_kurdish
            );
            PERFORM pg_notify('categories_channel', payload::text);
            RETURN NEW;

        WHEN 'UPDATE' THEN
            -- Only notify if relevant columns changed
            IF OLD.name_arabic IS DISTINCT FROM NEW.name_arabic OR OLD.name_kurdish IS DISTINCT FROM NEW.name_kurdish THEN
                payload = json_build_object(
                    'type', 'category',
                    'op', 'UPDATE',
                    'categoryId', NEW.category_id,
                    'nameArabic', NEW.name_arabic,
                    'nameKurdish', NEW.name_kurdish
                );
                PERFORM pg_notify('categories_channel', payload::text);
            END IF;
            RETURN NEW;

        WHEN 'DELETE' THEN
            payload = json_build_object(
                'type', 'category',
                'op', 'DELETE',
                'categoryId', OLD.category_id
            );
            PERFORM pg_notify('categories_channel', payload::text);
            RETURN OLD;
    END CASE;

    RETURN NULL;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS categories_notifications_trigger ON categories;
CREATE TRIGGER categories_notifications_trigger
AFTER INSERT OR UPDATE OF name_arabic, name_kurdish OR DELETE ON categories
FOR EACH ROW
EXECUTE FUNCTION handle_categories_notifications();


-- Brands Models Trigger
CREATE OR REPLACE FUNCTION handle_brands_models_notifications()
RETURNS TRIGGER AS $$
DECLARE
    payload JSON;
BEGIN
    CASE TG_OP
        WHEN 'INSERT' THEN
            payload = json_build_object(
                'type', 'brands_models',
                'op', 'INSERT',
                'brandModelId', NEW.brand_model_id,
                'categoryId', NEW.category_id,
                'nameEnglish', NEW.name_english,
                'nameArabic', NEW.name_arabic,
                'nameKurdish', NEW.name_kurdish
            );
            PERFORM pg_notify('brands_models_channel', payload::text);
            RETURN NEW;

        WHEN 'UPDATE' THEN
            -- Only notify if relevant columns changed
            IF OLD.name_english IS DISTINCT FROM NEW.name_english OR OLD.name_arabic IS DISTINCT FROM NEW.name_arabic OR OLD.name_kurdish IS DISTINCT FROM NEW.name_kurdish THEN
                payload = json_build_object(
                    'type', 'brands_models',
                    'op', 'UPDATE',
                    'categoryId', NEW.category_id,
                    'brandModelId', NEW.brand_model_id,
                    'nameEnglish', NEW.name_english,
                    'nameArabic', NEW.name_arabic,
                    'nameKurdish', NEW.name_kurdish
                );
                PERFORM pg_notify('brands_models_channel', payload::text);
            END IF;
            RETURN NEW;

        WHEN 'DELETE' THEN
            payload = json_build_object(
                'type', 'brands_models',
                'op', 'DELETE',
                'brandModelId', OLD.brand_model_id,
                'categoryId', OLD.category_id

            );
            PERFORM pg_notify('brands_models_channel', payload::text);
            RETURN OLD;
    END CASE;

    RETURN NULL;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS brands_models_notifications_trigger ON brands_models;
CREATE TRIGGER brands_models_notifications_trigger
AFTER INSERT OR UPDATE OF name_english, name_arabic, name_kurdish OR DELETE ON brands_models
FOR EACH ROW
EXECUTE FUNCTION handle_brands_models_notifications();


-- ============================================
-- TEST EXAMPLES (Run in separate session with LISTEN first)
-- ============================================

-- First, open another psql session and run:
-- LISTEN categories_channel;
-- LISTEN brands_models_channel;

-- Then run these tests in your main session:

-- ============================================
-- CATEGORIES TESTS
-- ============================================

-- 1. INSERT - Should notify: {op: INSERT, id: X, name_arabic: "...", name_kurdish: "..."}
INSERT INTO categories (name_arabic, name_kurdish, url_slug_arabic, url_slug_kurdish, is_leaf)
VALUES ('سيارات', 'ئۆتۆمبێل', 'cars-ar', 'cars-kr', true);

-- 2. UPDATE single column - Should notify: {op: UPDATE, id: X, columns: ["name_arabic"]}
UPDATE categories SET name_arabic = 'مركبات' WHERE url_slug_arabic = 'cars-ar';

-- 3. UPDATE both columns - Should notify: {op: UPDATE, id: X, columns: ["name_arabic", "name_kurdish"]}
UPDATE categories SET name_arabic = 'سيارات جديدة', name_kurdish = 'ئۆتۆمبێلی نوێ' WHERE url_slug_arabic = 'cars-ar';

-- 4. UPDATE non-tracked column - Should NOT notify
UPDATE categories SET image_url = 'test.jpg' WHERE url_slug_arabic = 'cars-ar';

-- 5. DELETE - Should notify: {op: DELETE, id: X}
DELETE FROM categories WHERE url_slug_arabic = 'cars-ar';


-- ============================================
-- BRANDS_MODELS TESTS
-- ============================================

-- First insert a category for FK reference
INSERT INTO categories (category_id, name_arabic, name_kurdish, url_slug_arabic, url_slug_kurdish, is_leaf)
VALUES (999, 'تست', 'تێست', 'test-ar', 'test-kr', true);

-- 1. INSERT - Should notify: {op: INSERT, id: X, name_english: "...", name_arabic: "...", name_kurdish: "..."}
INSERT INTO brands_models (name_english, name_arabic, name_kurdish, is_brand, url_slug, image_url, category_id)
VALUES ('Toyota', 'تويوتا', 'تۆیۆتا', true, 'toyota', 'toyota.jpg', 999);

-- 2. UPDATE single column - Should notify: {op: UPDATE, id: X, columns: ["name_english"]}
UPDATE brands_models SET name_english = 'Toyota Motors' WHERE url_slug = 'toyota';

-- 3. UPDATE two columns - Should notify: {op: UPDATE, id: X, columns: ["name_arabic", "name_kurdish"]}
UPDATE brands_models SET name_arabic = 'تويوتا موتورز', name_kurdish = 'تۆیۆتا مۆتۆرز' WHERE url_slug = 'toyota';

-- 4. UPDATE all three columns - Should notify: {op: UPDATE, id: X, columns: ["name_english", "name_arabic", "name_kurdish"]}
UPDATE brands_models SET name_english = 'Toyota Corp', name_arabic = 'شركة تويوتا', name_kurdish = 'کۆمپانیای تۆیۆتا' WHERE url_slug = 'toyota';

-- 5. UPDATE non-tracked column - Should NOT notify
UPDATE brands_models SET image_url = 'new-toyota.jpg' WHERE url_slug = 'toyota';

-- 6. DELETE - Should notify: {op: DELETE, id: X}
DELETE FROM brands_models WHERE url_slug = 'toyota';

-- Cleanup test category
DELETE FROM categories WHERE category_id = 999;
