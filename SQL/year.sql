-- Migration script to rename model_releases to releases, change release_year type, and remove url_slug

-- Step 1: Rename the table
ALTER TABLE model_releases RENAME TO releases;

-- Step 2: Rename the primary key column
ALTER TABLE releases RENAME COLUMN model_release_id TO release_id;

-- Step 3: Change release_year from SMALLINT to VARCHAR(4)
ALTER TABLE releases 
    ALTER COLUMN release_year TYPE VARCHAR(4) USING release_year::VARCHAR(4);

-- Step 4: Drop the old check constraint (if exists)
ALTER TABLE releases DROP CONSTRAINT IF EXISTS model_releases_release_year_check;

-- Step 5: Drop the url_slug column (no longer needed)
ALTER TABLE releases DROP COLUMN IF EXISTS url_slug;

-- Step 6: Drop the old index and create new one
DROP INDEX IF EXISTS ix_model_releases_model_id_url_slug;
CREATE INDEX IF NOT EXISTS ix_releases_model_id ON releases(model_id);

-- Step 7: Update the comment
COMMENT ON TABLE releases IS 'Model release years (sub-models)';

-- Example insert with new structure
-- INSERT INTO releases (release_year, image_url, model_id)
-- VALUES ('2024', 'https://example.com/images/model3-2024.png', 3);
