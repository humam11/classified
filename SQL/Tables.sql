-- PostgreSQL Tables with snake_case naming convention
-- Drop the database if it exists
DROP DATABASE IF EXISTS "classified";

-- Create the database
CREATE DATABASE "classified";

-- Connect to the new database
\c "classified";

-- Set timezone for this database
ALTER DATABASE "classified" SET timezone = 'Asia/Baghdad';

-- Reconnect to apply the timezone setting
\c "classified";

-- Enable extensions
CREATE EXTENSION IF NOT EXISTS ltree;     -- For hierarchy_path

-- Locations Table
CREATE TABLE locations (
    -- Primary Key
    location_id SMALLSERIAL PRIMARY KEY,

    -- Core Location Data
    name_english VARCHAR(50) NULL,
    name_arabic VARCHAR(50) NOT NULL,
    name_kurdish VARCHAR(50) NOT NULL,

    -- Hierarchical Data
    hierarchy_path LTREE NOT NULL,
    level INTEGER GENERATED ALWAYS AS (nlevel(hierarchy_path)) STORED,

    -- Foreign Keys
    parent_id SMALLINT NULL REFERENCES locations(location_id),

    -- Constraints
    UNIQUE (name_english, hierarchy_path),
    UNIQUE (name_arabic, hierarchy_path),
    UNIQUE (name_kurdish, hierarchy_path)
);

CREATE INDEX ix_locations_hierarchy_path ON locations USING GIST (hierarchy_path);


-- Users Table
CREATE TABLE users (
    -- Primary Key
    user_id uuid DEFAULT uuidv7() PRIMARY KEY, -- Use uuidv7() if available
    
    -- Core Identifying Information
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50),
    
    -- Contact Information
    email VARCHAR(100) NULL,
    normalized_email VARCHAR(256) NULL,
    phone_number VARCHAR(20) NULL,
    
    -- Authentication & Security
    password_hash BYTEA NOT NULL,
    email_confirmed BOOLEAN NOT NULL DEFAULT FALSE,
    phone_number_confirmed BOOLEAN NOT NULL DEFAULT FALSE,

    -- Profile Data
    profile_picture_url VARCHAR(255) NULL,
    average_rating DECIMAL(2,1) NULL,
    review_count INTEGER DEFAULT 0,

    -- Location Data
    latitude DECIMAL(9,6) NULL,
    longitude DECIMAL(9,6) NULL,
    location_source SMALLINT CHECK (location_source BETWEEN 0 AND 2) NOT NULL,

    created_at TIMESTAMPTZ NOT NULL DEFAULT TIMEZONE('UTC', NOW()),

    -- Foreign Keys
    location_id SMALLINT NULL REFERENCES locations(location_id),

    -- Constraints
    CONSTRAINT chk_contact_info CHECK (
        (phone_number IS NOT NULL OR email IS NOT NULL)
    )
);

-- User Reports Table
CREATE TABLE user_reports (
    -- Primary Key
    user_report_id uuid DEFAULT uuidv7() PRIMARY KEY,

    -- Core Report Data
    reason_type SMALLINT CHECK (reason_type BETWEEN 0 AND 5) NOT NULL,
    description VARCHAR(500),

    -- Moderation Status
    status SMALLINT CHECK (status BETWEEN 0 AND 2) NOT NULL DEFAULT 0,

    -- Metadata
    created_at TIMESTAMPTZ NOT NULL DEFAULT TIMEZONE('UTC', NOW()),

    -- Foreign Keys
    reporter_id UUID NOT NULL REFERENCES users(user_id),
    reported_id UUID NOT NULL REFERENCES users(user_id)
);

-- Bug Reports Table
CREATE TABLE bug_reports (
    -- Primary Key
    bug_report_id uuid DEFAULT uuidv7() PRIMARY KEY,

    -- Core Report Data
    description VARCHAR(1000),
    screenshot_url VARCHAR(512),

    -- Status Tracking
    status SMALLINT CHECK (status BETWEEN 0 AND 3) NOT NULL DEFAULT 0,

    -- Metadata
    created_at TIMESTAMPTZ NOT NULL DEFAULT TIMEZONE('UTC', NOW()),

    -- Foreign Keys
    user_id UUID NOT NULL REFERENCES users(user_id)
);

-- User Reviews Table
CREATE TABLE user_reviews (
    -- Primary Key
    user_review_id uuid DEFAULT uuidv7() PRIMARY KEY,

    -- Core Review Data
    rating SMALLINT CHECK (rating BETWEEN 1 AND 5) NOT NULL,
    comment VARCHAR(1000),
    
    -- Metadata
    created_at TIMESTAMPTZ NOT NULL DEFAULT TIMEZONE('UTC', NOW()),
    
    -- Foreign Keys
    reviewer_id UUID NOT NULL REFERENCES users(user_id),
    reviewed_id UUID NOT NULL REFERENCES users(user_id),

    -- Constraints
    CONSTRAINT uq_review UNIQUE (reviewer_id, reviewed_id)
);



-- Categories Table
CREATE TABLE categories (
    -- Primary Key
    category_id SMALLSERIAL PRIMARY KEY,
    
    -- Core Descriptive Fields
    name_arabic VARCHAR(120) NOT NULL,
    name_kurdish VARCHAR(120) NOT NULL,
    
    -- Metadata Fields
    url_slug_arabic VARCHAR(255) NOT NULL UNIQUE,
    url_slug_kurdish VARCHAR(255) NOT NULL UNIQUE,
    image_url VARCHAR(255),

    -- Hierarchical Data
    hierarchy_path LTREE NULL,
    level INTEGER GENERATED ALWAYS AS (nlevel(hierarchy_path)) STORED,
    is_leaf BOOLEAN NOT NULL,
    
    -- Foreign Keys
    parent_id SMALLINT NULL REFERENCES categories(category_id)
);

CREATE INDEX ix_categories_hierarchy_path ON categories USING GIST (hierarchy_path);

-- Brand Models Table
CREATE TABLE brands_models (
    -- Primary Key
    brand_model_id SMALLSERIAL PRIMARY KEY,
    
    -- Core Descriptive Fields
    name_english VARCHAR(50) NOT NULL,
    name_arabic VARCHAR(50),
    name_kurdish VARCHAR(50),
    is_brand BOOLEAN NOT NULL,

    -- Metadata Fields
    url_slug VARCHAR(255) NOT NULL,
    image_url VARCHAR(255) NOT NULL,
    automation_keyword VARCHAR(255) NULL UNIQUE,
    
    -- Hierarchical Data
    hierarchy_path LTREE NULL,
    level INTEGER GENERATED ALWAYS AS (nlevel(hierarchy_path)) STORED,

    -- Foreign Keys
    parent_id SMALLINT REFERENCES brands_models(brand_model_id),
    category_id SMALLINT NOT NULL REFERENCES categories(category_id),
    
    -- Constraints
    UNIQUE (category_id, name_english),
    CONSTRAINT chk_brands_models_hierarchy CHECK (
        (is_brand = TRUE AND parent_id IS NULL) OR
        (is_brand = FALSE AND parent_id IS NOT NULL)
    )
);

CREATE INDEX ix_brands_models_hierarchy_path ON brands_models USING GIST (hierarchy_path);


-- Releases Table
CREATE TABLE releases (
    -- Primary Key
    release_id SMALLSERIAL PRIMARY KEY,
    
    -- Core Data Fields
    release_year VARCHAR(4) NOT NULL,
    
    -- Metadata Fields
    image_url VARCHAR(255) NOT NULL,

    -- Foreign Keys
    model_id SMALLINT NOT NULL REFERENCES brands_models(brand_model_id),
    
    -- Constraints
    UNIQUE (model_id, release_year)
);

CREATE INDEX ix_releases_model_id ON releases(model_id);

-- Comments for documentation
COMMENT ON TABLE locations IS 'Hierarchical location data: City (0) → District (1) → Neighborhood (2)';
COMMENT ON TABLE users IS 'User accounts and profiles';
COMMENT ON TABLE user_reports IS 'User-to-user reports for moderation';
COMMENT ON TABLE bug_reports IS 'Technical bug reports from users';
COMMENT ON TABLE user_reviews IS 'User ratings and reviews (1-5 stars)';
COMMENT ON TABLE categories IS 'Hierarchical category structure for ads';
COMMENT ON TABLE brands_models IS 'Brand and model hierarchy (Brand → Model)';
COMMENT ON TABLE releases IS 'Model release years (sub-models)';