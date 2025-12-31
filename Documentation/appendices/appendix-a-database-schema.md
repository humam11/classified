# Appendix A: Complete Database Schema

## A.1 PostgreSQL Schema

### A.1.1 Users Table

```sql
CREATE TABLE users (
    user_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    username VARCHAR(50) NOT NULL UNIQUE,
    email VARCHAR(100) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    location_id INTEGER REFERENCES locations(location_id),
    rating DECIMAL(3,2) DEFAULT 0.00,
    review_count INTEGER DEFAULT 0,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT chk_rating CHECK (rating >= 0 AND rating <= 5)
);
```

---

### A.1.2 Categories Table

```sql
CREATE TABLE categories (
    category_id SMALLSERIAL PRIMARY KEY,
    name_english VARCHAR(120) NOT NULL,
    name_russian VARCHAR(120) NOT NULL,
    slug_english VARCHAR(120) NOT NULL,
    slug_russian VARCHAR(120) NOT NULL,
    parent_id SMALLINT REFERENCES categories(category_id),
    hierarchy_path LTREE,
    level INTEGER GENERATED ALWAYS AS (nlevel(hierarchy_path)) STORED,
    is_leaf BOOLEAN NOT NULL DEFAULT FALSE,
    CONSTRAINT chk_level CHECK (level <= 3)
);

CREATE INDEX idx_categories_hierarchy ON categories USING GIST (hierarchy_path);
CREATE INDEX idx_categories_parent ON categories(parent_id);
```

---

### A.1.3 Locations Table

```sql
CREATE TABLE locations (
    location_id SERIAL PRIMARY KEY,
    name_english VARCHAR(100) NOT NULL,
    name_russian VARCHAR(100) NOT NULL,
    parent_id INTEGER REFERENCES locations(location_id),
    hierarchy_path LTREE,
    level INTEGER GENERATED ALWAYS AS (nlevel(hierarchy_path)) STORED,
    CONSTRAINT chk_level CHECK (level <= 3)
);

CREATE INDEX idx_locations_hierarchy ON locations USING GIST (hierarchy_path);
CREATE INDEX idx_locations_parent ON locations(parent_id);
```

---

### A.1.4 Brands_Models Table

```sql
CREATE TABLE brands_models (
    brand_model_id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    parent_id INTEGER REFERENCES brands_models(brand_model_id),
    category_id SMALLINT REFERENCES categories(category_id),
    is_brand BOOLEAN NOT NULL DEFAULT TRUE,
    automation_keyword VARCHAR(100),
    CONSTRAINT chk_brand_or_model CHECK (
        (is_brand = TRUE AND parent_id IS NULL) OR
        (is_brand = FALSE AND parent_id IS NOT NULL)
    )
);

CREATE INDEX idx_brands_models_parent ON brands_models(parent_id);
CREATE INDEX idx_brands_models_category ON brands_models(category_id);
```

---

### A.1.5 Releases Table

```sql
CREATE TABLE releases (
    release_id SERIAL PRIMARY KEY,
    model_id INTEGER NOT NULL REFERENCES brands_models(brand_model_id),
    release_year SMALLINT NOT NULL,
    name VARCHAR(100),
    CONSTRAINT chk_year CHECK (release_year >= 1900 AND release_year <= 2100),
    UNIQUE(model_id, release_year)
);

CREATE INDEX idx_releases_model ON releases(model_id);
```

---

### A.1.6 User_Reviews Table

```sql
CREATE TABLE user_reviews (
    review_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    reviewer_id UUID NOT NULL REFERENCES users(user_id),
    reviewed_user_id UUID NOT NULL REFERENCES users(user_id),
    rating SMALLINT NOT NULL,
    comment TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT chk_rating CHECK (rating >= 1 AND rating <= 5),
    CONSTRAINT chk_not_self_review CHECK (reviewer_id != reviewed_user_id)
);

CREATE INDEX idx_user_reviews_reviewed ON user_reviews(reviewed_user_id);
```

---

### A.1.7 User_Reports Table

```sql
CREATE TABLE user_reports (
    report_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    reporter_id UUID NOT NULL REFERENCES users(user_id),
    reported_user_id UUID NOT NULL REFERENCES users(user_id),
    reason TEXT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT chk_not_self_report CHECK (reporter_id != reported_user_id)
);
```

---

### A.1.8 Bug_Reports Table

```sql
CREATE TABLE bug_reports (
    bug_id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    user_id UUID REFERENCES users(user_id),
    description TEXT NOT NULL,
    status VARCHAR(20) DEFAULT 'open',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT chk_status CHECK (status IN ('open', 'in_progress', 'resolved', 'closed'))
);
```

---

## A.2 MongoDB Collections

### A.2.1 Ads Collection

[See Appendix B for complete document examples]

**Indexes**:
```javascript
db.ads.createIndex({ "category.categoryIds": 1 });
db.ads.createIndex({ "location.locationIds": 1 });
db.ads.createIndex({ userId: 1 });
db.ads.createIndex({ slug: 1 });
db.ads.createIndex({ status: 1 });
db.ads.createIndex({ createdAt: -1 });
db.ads.createIndex({ "price.value": 1 });
```

---

### A.2.2 Conversations Collection

```javascript
{
  _id: ObjectId,
  participants: [UUID, UUID],
  adId: ObjectId,
  lastMessageAt: ISODate,
  createdAt: ISODate
}
```

**Indexes**:
```javascript
db.conversations.createIndex({ participants: 1 });
db.conversations.createIndex({ adId: 1 });
```

---

### A.2.3 Messages Collection

```javascript
{
  _id: ObjectId,
  conversationId: ObjectId,
  senderId: UUID,
  content: String,
  isRead: Boolean,
  sentAt: ISODate
}
```

**Indexes**:
```javascript
db.messages.createIndex({ conversationId: 1, sentAt: -1 });
db.messages.createIndex({ senderId: 1 });
```

---

**End of Appendix A**
