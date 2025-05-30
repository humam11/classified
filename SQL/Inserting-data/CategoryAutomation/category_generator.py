import re
import os
from typing import Dict, List, Tuple, Optional
from pathlib import Path
import logging

# Configure logging
logging.basicConfig(
    level=logging.INFO, format="%(asctime)s - %(levelname)s - %(message)s"
)
logger = logging.getLogger(__name__)


def clean_text_for_slug(text: str) -> str:
    """Clean text and convert to URL-friendly slug"""
    if not text:
        return ""
    
    # Remove content within parentheses
    text = re.sub(r'\s*\([^)]*\)', '', text)
    # Replace spaces and special characters with hyphens
    text = re.sub(r'[\s\-_]+', '-', text.strip())
    # Remove non-alphanumeric characters except hyphens (keep Arabic/Kurdish chars)
    text = re.sub(r'[^\w\u0600-\u06FF\u0750-\u077F-]', '', text)
    # Remove extra hyphens
    text = re.sub(r'-+', '-', text)
    # Remove leading/trailing hyphens
    return text.strip('-').lower()


def parse_hierarchy_file(file_path: str) -> Dict[str, str]:
    """Parse a hierarchy file and return a dictionary of path -> name"""
    categories = {}
    
    try:
        with open(file_path, 'r', encoding='utf-8') as file:
            content = file.read()
    except FileNotFoundError:
        logger.error(f"File not found: {file_path}")
        return {}
    except UnicodeDecodeError:
        logger.error(f"Encoding error reading file: {file_path}")
        return {}
    
    lines = content.strip().split('\n')
    
    for line_num, line in enumerate(lines, 1):
        line = line.strip()
        if not line:
            continue
            
        # Primary pattern: "1.2.3 Category Name"
        match = re.match(r'^(\d+(?:\.\d+)*)\s*[\t\s]+(.+)$', line)
        if match:
            path = match.group(1)
            name = match.group(2).strip()
            categories[path] = name
            continue
            
        # Alternative pattern: "1. Category Name"
        match = re.match(r'^(\d+\.?)\s*[\t\s]+(.+)$', line)
        if match:
            path = match.group(1).rstrip('.')
            name = match.group(2).strip()
            categories[path] = name
            continue
            
        logger.warning(
            f"Line {line_num} in {file_path} doesn't match expected format: {line}"
        )
    
    logger.info(f"Parsed {len(categories)} categories from {file_path}")
    return categories


def get_parent_path(path: str) -> Optional[str]:
    """Get parent path from current path"""
    if not path or '.' not in path:
        return None
    parts = path.split('.')
    return '.'.join(parts[:-1]) if len(parts) > 1 else None


def build_url_slug(
    path: str, categories: Dict[str, str], existing_slugs: Dict[str, str]
) -> str:
    """Build URL slug recursively based on hierarchy"""
    if path in existing_slugs:
        return existing_slugs[path]
    
    if path not in categories:
        logger.warning(f"Path {path} not found in categories")
        return ""
    
    current_name = categories[path]
    current_slug = clean_text_for_slug(current_name)
    
    parent_path = get_parent_path(path)
    if parent_path and parent_path in categories:
        parent_slug = build_url_slug(parent_path, categories, existing_slugs)
        full_slug = f"{parent_slug}/{current_slug}" if parent_slug else current_slug
    else:
        full_slug = current_slug
    
    existing_slugs[path] = full_slug
    return full_slug


def get_parent_id_reference(path: str) -> str:
    """Get parent ID reference for SQL using subquery"""
    parent_path = get_parent_path(path)
    if not parent_path:
        return "NULL"
    
    # Escape single quotes in path
    escaped_path = parent_path.replace("'", "''")
    return f'(SELECT "CategoryID" FROM "Category" WHERE "hierarchy_path" = \'{escaped_path}\')'


def sort_hierarchy_paths(paths: List[str]) -> List[str]:
    """Sort paths in proper hierarchical order (depth-first traversal)"""
    def parse_path(path):
        """Convert path to tuple of integers for sorting"""
        parts = path.split('.')
        numeric_parts = []
        for part in parts:
            try:
                numeric_parts.append(int(part))
            except ValueError:
                logger.warning(f"Non-numeric part in path {path}: {part}")
                numeric_parts.append(0)
        return tuple(numeric_parts)
    
    # Create list of (parsed_path, original_path) tuples for sorting
    path_tuples = [(parse_path(path), path) for path in paths]
    
    # Sort by parsed path - this gives proper hierarchical order
    path_tuples.sort(key=lambda x: x[0])
    
    # Return original paths in correct order
    return [path for _, path in path_tuples]


def escape_sql_string(text: str) -> str:
    """Escape single quotes and other special characters for SQL"""
    return text.replace("'", "''").replace("\\", "\\\\")


def generate_hierarchy_display_queries() -> str:
    """Generate SQL queries to display the hierarchy in a readable format"""
    return '''
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
'''


def generate_postgresql_inserts(arabic_file: str, kurdish_file: str) -> str:
    """Generate complete PostgreSQL insert statements"""
    
    # Parse both files
    arabic_categories = parse_hierarchy_file(arabic_file)
    kurdish_categories = parse_hierarchy_file(kurdish_file)
    
    if not arabic_categories or not kurdish_categories:
        raise ValueError("One or both category files are empty or invalid")
    
    logger.info(f"Arabic categories: {len(arabic_categories)}")
    logger.info(f"Kurdish categories: {len(kurdish_categories)}")
    
    # Find common paths
    common_paths = set(arabic_categories.keys()) & set(kurdish_categories.keys())
    
    if not common_paths:
        raise ValueError("No common paths found between Arabic and Kurdish files")
    
    logger.info(f"Found {len(common_paths)} common paths")
    
    # Sort paths in proper hierarchical order
    sorted_paths = sort_hierarchy_paths(list(common_paths))
    
    # Debug: Print first 20 sorted paths to verify order
    logger.info("First 20 sorted paths:")
    for i, path in enumerate(sorted_paths[:20]):
        logger.info(f"  {i+1}: {path} -> {arabic_categories[path]}")
    
    # Build slugs for both languages
    arabic_slugs = {}
    kurdish_slugs = {}
    
    for path in sorted_paths:
        build_url_slug(path, arabic_categories, arabic_slugs)
        build_url_slug(path, kurdish_categories, kurdish_slugs)
    
    # Generate SQL
    sql_parts = [
        "-- PostgreSQL script to insert all category data",
        "-- Generated automatically - do not edit manually",
        f"-- Total categories to insert: {len(sorted_paths)}",
        "",
        "BEGIN;",
        "",
        "-- Disable triggers for better performance",
        "SET session_replication_role = replica;",
        "",
    ]
    
    current_level_1 = None
    insert_count = 0
    
    for path in sorted_paths:
        level_1 = path.split('.')[0]
        
        # Add comment for new level 1 category
        if level_1 != current_level_1:
            if current_level_1 is not None:
                sql_parts.append("")
                sql_parts.append(f"-- End of Level 1 Category: {current_level_1}")
                sql_parts.append("")
            
            sql_parts.append(f"-- Level 1 Category: {level_1} - {arabic_categories.get(level_1, 'Unknown')}")
            sql_parts.append("")
            current_level_1 = level_1
        
        # Get and escape data
        arabic_name = escape_sql_string(arabic_categories[path])
        kurdish_name = escape_sql_string(kurdish_categories[path])
        arabic_slug = escape_sql_string(arabic_slugs[path])
        kurdish_slug = escape_sql_string(kurdish_slugs[path])
        
        parent_id = get_parent_id_reference(path)
        
        # Generate INSERT statement
        insert_sql = f"""INSERT INTO "Category" ("NameArabic", "NameKurdish", "UrlSlugArabic", "UrlSlugKurdish", "hierarchy_path", "ParentID") 
VALUES ('{arabic_name}', '{kurdish_name}', '{arabic_slug}', '{kurdish_slug}', '{path}', {parent_id});"""
        
        sql_parts.append(insert_sql)
        insert_count += 1
        
        # Add a blank line every 10 inserts for readability
        if insert_count % 10 == 0:
            sql_parts.append("")
    
    # Final level 1 category end comment
    if current_level_1 is not None:
        sql_parts.append("")
        sql_parts.append(f"-- End of Level 1 Category: {current_level_1}")
    
    sql_parts.extend([
        "",
        "-- Re-enable triggers",
        "SET session_replication_role = DEFAULT;",
        "",
        "COMMIT;",
        "",
        "-- Create indexes for better performance",
        'CREATE INDEX CONCURRENTLY IF NOT EXISTS "idx_category_parent_id" ON "Category" ("ParentID");',
        'CREATE INDEX CONCURRENTLY IF NOT EXISTS "idx_category_hierarchy_path" ON "Category" ("hierarchy_path");',
        'CREATE INDEX CONCURRENTLY IF NOT EXISTS "idx_category_url_slug_arabic" ON "Category" ("UrlSlugArabic");',
        'CREATE INDEX CONCURRENTLY IF NOT EXISTS "idx_category_url_slug_kurdish" ON "Category" ("UrlSlugKurdish");',
        "",
        "-- Create unique constraints",
        'ALTER TABLE "Category" ADD CONSTRAINT "uk_category_hierarchy_path" UNIQUE ("hierarchy_path");',
        'ALTER TABLE "Category" ADD CONSTRAINT "uk_category_url_slug_arabic" UNIQUE ("UrlSlugArabic");',
        'ALTER TABLE "Category" ADD CONSTRAINT "uk_category_url_slug_kurdish" UNIQUE ("UrlSlugKurdish");',
        "",
        "-- Analyze table for query optimization",
        'ANALYZE "Category";',
        "",
        f"-- Successfully inserted {insert_count} categories",
    ])
    
    # Add the hierarchy display queries
    sql_parts.append(generate_hierarchy_display_queries())
    
    return '\n'.join(sql_parts)


def validate_hierarchy_integrity(categories: Dict[str, str]) -> bool:
    """Validate that all parent paths exist for child categories"""
    paths = set(categories.keys())
    
    for path in paths:
        parent_path = get_parent_path(path)
        if parent_path and parent_path not in paths:
            logger.error(f"Missing parent path '{parent_path}' for child '{path}'")
            return False
    
    logger.info("Hierarchy integrity validation passed")
    return True


def show_hierarchy_summary(categories: Dict[str, str]) -> None:
    """Show a summary of the hierarchy structure"""
    paths = list(categories.keys())
    sorted_paths = sort_hierarchy_paths(paths)
    
    level_counts = {}
    for path in paths:
        level = len(path.split('.'))
        level_counts[level] = level_counts.get(level, 0) + 1
    
    print("\nHierarchy Summary:")
    print("-" * 30)
    for level in sorted(level_counts.keys()):
        print(f"Level {level}: {level_counts[level]} categories")
    
    print(f"\nTotal categories: {len(categories)}")
    
    # Show top-level categories
    top_level = [path for path in sorted_paths if '.' not in path]
    print(f"\nTop-level categories ({len(top_level)}):")
    for path in top_level:
        print(f"  {path}: {categories[path]}")


def find_missing_translations(arabic_categories: Dict[str, str], 
                             kurdish_categories: Dict[str, str]) -> Tuple[List[str], List[str]]:
    """Find categories that exist in one language but not the other"""
    arabic_paths = set(arabic_categories.keys())
    kurdish_paths = set(kurdish_categories.keys())
    
    arabic_only = list(arabic_paths - kurdish_paths)
    kurdish_only = list(kurdish_paths - arabic_paths)
    
    return arabic_only, kurdish_only


def export_missing_translations(arabic_only: List[str], 
                               kurdish_only: List[str],
                               arabic_categories: Dict[str, str],
                               kurdish_categories: Dict[str, str]) -> None:
    """Export missing translations to separate files for review"""
    
    if arabic_only:
        with open("missing_kurdish_translations.txt", "w", encoding="utf-8") as f:
            f.write("Categories that need Kurdish translation:\n")
            f.write("=" * 50 + "\n\n")
            for path in sort_hierarchy_paths(arabic_only):
                f.write(f"{path}\t{arabic_categories[path]}\n")
        logger.info(f"Exported {len(arabic_only)} missing Kurdish translations")
    
    if kurdish_only:
        with open("missing_arabic_translations.txt", "w", encoding="utf-8") as f:
            f.write("Categories that need Arabic translation:\n")
            f.write("=" * 50 + "\n\n")
            for path in sort_hierarchy_paths(kurdish_only):
                f.write(f"{path}\t{kurdish_categories[path]}\n")
        logger.info(f"Exported {len(kurdish_only)} missing Arabic translations")


def main():
    """Main function to run the script"""
    print("PostgreSQL Category Insert Generator")
    print("=" * 40)
    
    # Use pathlib for better path handling
    base_path = Path("../../../Planning/Categories")
    arabic_file = base_path / "Arabic-data_categories_inserting.txt"
    kurdish_file = base_path / "Kurdish-data_categories_inserting.txt"
    
    # Alternative paths if the above don't exist
    if not arabic_file.exists():
        arabic_file = Path("Arabic-data_categories_inserting.txt")
    if not kurdish_file.exists():
        kurdish_file = Path("Kurdish-data_categories_inserting.txt")
    
    # Validate file paths
    missing_files = []
    for file_path in [arabic_file, kurdish_file]:
        if not file_path.exists():
            missing_files.append(str(file_path))
    
    if missing_files:
        logger.error(f"Files not found: {missing_files}")
        print("\nPlease ensure the following files exist:")
        for file_path in missing_files:
            print(f"  - {file_path}")
        return
    
    try:
        # Parse files
        logger.info("Parsing category files...")
        arabic_categories = parse_hierarchy_file(str(arabic_file))
        kurdish_categories = parse_hierarchy_file(str(kurdish_file))
        
        if not arabic_categories:
            logger.error("No Arabic categories found")
            return
        
        if not kurdish_categories:
            logger.error("No Kurdish categories found")
            return
        
        # Show hierarchy summaries
        print(f"\nArabic Categories:")
        show_hierarchy_summary(arabic_categories)
        
        print(f"\nKurdish Categories:")
        show_hierarchy_summary(kurdish_categories)
        
        # Validate hierarchy integrity
        logger.info("Validating hierarchy integrity...")
        if not validate_hierarchy_integrity(arabic_categories):
            logger.error("Arabic hierarchy integrity check failed")
            return
        
        if not validate_hierarchy_integrity(kurdish_categories):
            logger.error("Kurdish hierarchy integrity check failed")
            return
        
        # Find missing translations
        arabic_only, kurdish_only = find_missing_translations(
            arabic_categories, kurdish_categories
        )
        
        if arabic_only or kurdish_only:
            logger.warning(f"Found missing translations: "
                          f"{len(arabic_only)} Arabic-only, "
                          f"{len(kurdish_only)} Kurdish-only")
            export_missing_translations(arabic_only, kurdish_only, 
                                      arabic_categories, kurdish_categories)
        
        # Find common paths
        common_paths = set(arabic_categories.keys()) & set(kurdish_categories.keys())
        
        if not common_paths:
            logger.error("No common paths found between Arabic and Kurdish files")
            return
        
        logger.info(f"Found {len(common_paths)} categories with both translations")
        
        # Generate SQL
        logger.info("Generating PostgreSQL insert statements...")
        sql_content = generate_postgresql_inserts(str(arabic_file), str(kurdish_file))
        
        # Save to file
        output_file = Path("category_inserts.sql")
        output_file.write_text(sql_content, encoding='utf-8')
        
        logger.info(f"✅ SQL file generated successfully: {output_file}")
        
        # Show final summary
        print(f"\n" + "=" * 50)
        print(f"GENERATION COMPLETE")
        print(f"=" * 50)
        print(f"📁 Output file: {output_file}")
        print(f"📊 Categories processed: {len(common_paths)}")
        print(f"🔗 File size: {output_file.stat().st_size / 1024:.1f} KB")
        
        if arabic_only:
            print(f"⚠️  Missing Kurdish translations: {len(arabic_only)}")
            print(f"   See: missing_kurdish_translations.txt")
        
        if kurdish_only:
            print(f"⚠️  Missing Arabic translations: {len(kurdish_only)}")
            print(f"   See: missing_arabic_translations.txt")
        
        print(f"\n✅ Ready to execute in PostgreSQL!")
        print(f"   Run: psql -d your_database -f {output_file}")
        print(f"\n📋 Bonus: The SQL file includes display queries at the end")
        print(f"   Use them to view your hierarchy in various formats!")
            
    except Exception as e:
        logger.error(f"❌ Error generating SQL: {str(e)}")
        import traceback
        traceback.print_exc()


if __name__ == "__main__":
    main()
