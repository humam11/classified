# API Endpoints - Redesigned for SEO & URL Clarity
**{apiPrefix}/categories/الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/موبايلات-ذكية/models/samsung-galaxy-s20/ads for searching**
**{apiPrefix}/categories/الالكترونيات-والاجهزة-الرقمية/موبايلات-واجهزة-لوحية/موبايلات-ذكية/models/samsung-galaxy-s20/ads/{adSlug} for ad specific**



## Collection: Main Page
- GET     `{apiPrefix}/{locationSlug}`

## Collection: Authentication
- POST `{apiPrefix}/auth/sign-up`
- POST `{apiPrefix}/auth/sign-in`                      
- POST `{apiPrefix}/auth/sign-out`
- POST `{apiPrefix}/auth/refresh`

## Collection: User Profile Management (Info, Reviews, Top 3 Ads)
- GET     `{apiPrefix}/users/{userId}`
- PATCH   `{apiPrefix}/users/{userId}` (with permission check)

## Collection: User Reviews And Reports
- POST    `{apiPrefix}/users/{userId}/reviews`
- GET     `{apiPrefix}/users/{userId}/reviews` # pagination needed
- GET     `{apiPrefix}/users/{userId}/reviews/{reviewSlug}`
- POST    `{apiPrefix}/users/{userId}/reports`
- POST    `{apiPrefix}/bug-reports`

## Collection: User Ad CRUD
- POST    `{apiPrefix}/categories/{categorySlug}/ads`

## Collection: User Ads Listing
- GET     `{apiPrefix}/users/{userId}/ads`  # pagination needed


## Collection: Ads Search & Browsing (long. latu. should be provided within request)

### Category Level Search
- GET     `{apiPrefix}/categories/{categorySlug}/ads` 

### BrandModel Level Search
- GET     `{apiPrefix}/categories/{categorySlug}/models/{brandModelSlug}/ads` 

### Car Release Year Level Search
- GET     `{apiPrefix}/categories/{categorySlug}/models/{brandModelSlug}/releases/{release-year}/ads`

## Specific Ad Viewing

### Category Level (most of ads)
- GET `{apiPrefix}/categories/{categorySlug}/ads/{adSlug}`

### Brand Level  (Truck, Motorcycle, VideoGame, HandhledDevice, Laptop, TvMonitor, Console)
- GET `{apiPrefix}/categories/{categorySlug}/models/{brandModelSlug}/ads/{adSlug}`

### Release Year Level (for cars only)
- GET `{apiPrefix}/categories/{categorySlug}/models/{brandModelSlug}/releases/{release-year}/ads/{adSlug}`


## Collection: Chat & Messaging

### Conversation Management
- POST    `{apiPrefix}/ads/{adSlug}/conversations` # Start conversation (after sending first message only)
- GET     `{apiPrefix}/conversations`  # (with permission check) pagination needed

### Message Management
- GET     `{apiPrefix}/conversations/{conversationId}/messages` # Get all messages in conversation. pagination needed
- POST    `{apiPrefix}/conversations/{conversationId}/messages` # Send a new message
- PATCH   `{apiPrefix}/conversations/{conversationId}/messages/{messageId}` # Update message read status