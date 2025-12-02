
# Ad Slug Format (MongoDB ObjectId-Based)

Each ad must use a **clean, SEO-friendly slug** based on:

-   The ad title\
-   Plus the **last 8 characters of the ad's MongoDB ObjectId**

### Example

    objectId = 692bade560442b1ab8ff922
    last 8 chars = b8ff922
    ad slug = "bmw-2022-for-sell-b8ff922"
    
***notice: the slug should be updated when user updating and redefiend the title

------------------------------------------------------------------------

# Redirect Rules for SEO-Friendly Ad URLs

To avoid duplicate URLs and ensure every ad has **one canonical URL**,
the platform must enforce redirect rules depending on the category type.

## 1. Cars Category (has releases)

### Scenario

When a user accesses an ad from a search path that does not include the
release year, such as:

    /categories/{cars-categorySlug}/models/{brandModelSlug}/ads/{adSlug}

### Required Redirect

Redirect (301) to the release-based canonical URL:

    /categories/{cars-categorySlug}/models/{brandModelSlug}/releases/{releaseYear}/ads/{adSlug}

### Example

User accessed:

    /categories/{cars-categorySlug}/models/mercedes-g-class-6/ads/

Redirect to:

    /categories/{cars-categorySlug}/models/mercedes-g-class-6/releases/2022/ads/g-class-for-sell-120-3sdf4324

## 2. Phones Category (no releases, because only cars has it)

### Scenario

When accessing an ad from the brand-level search:

    /categories/{phones-categorySlug}/models/{brandSlug}/ads/

### Required Redirect

Redirect to:

    /categories/{phones-categorySlug}/models/{modelSlug}/ads/{adSlug}

### Example

User accessed:

    /categories/{phones-categorySlug}/models/apple/ads/

Redirect to:

    /categories/{phones-categorySlug}/models/apple-iphone-12/ads/iphone-12-for-sell-120-3sdf4324