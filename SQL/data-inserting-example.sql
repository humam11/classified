        SELECT version();
SELECT uuidv7();

INSERT INTO locations (
    name_english,
    name_arabic,
    name_kurdish,
    hierarchy_path,
    parent_id
)
VALUES
('Baghdad', 'بغداد', 'بەغداد', 'baghdad', NULL);



INSERT INTO locations (
    name_english,
    name_arabic,
    name_kurdish,
    hierarchy_path,
    parent_id
)
VALUES
('Karkh', 'الكرخ', 'كرخ', 'baghdad.karkh', 1),
('Rusafa', 'الرصافة', 'رصافة', 'baghdad.rusafa', 1);


INSERT INTO locations (
    name_english,
    name_arabic,
    name_kurdish,
    hierarchy_path,
    parent_id
)
VALUES
('Mansour', 'المنصور', 'منصور', 'baghdad.karkh.mansour', 2),
('Amiriya', 'العامرية', 'عامریه‌', 'baghdad.karkh.amiriya', 2);



-- Check if parent category exists
SELECT category_id, name_arabic, url_slug_arabic, parent_id
FROM categories
WHERE name_arabic = 'مركبات-ونقل';

-- Check if child category exists
SELECT category_id, name_arabic, url_slug_arabic, parent_id
FROM categories
WHERE name_arabic = 'سيارات';
