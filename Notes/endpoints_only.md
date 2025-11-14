# API Endpoints - Redesigned for SEO & URL Clarity
**{apiPrefix}/{locationSlug}/categories/electronics/phones/brands/samsung-سامسونغ/models/galaxy-s20-جالاكسي-اس٢٠/ads for searching**
**{apiPrefix}/categories/electronics/phones/brands/samsung-سامسونغ/models/galaxy-s20-جالاكسي-اس٢٠/ads/{adSlug} for ad specific**



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
- POST    `{apiPrefix}/{locationSlug}/categories/{categorySlug}/ads`

## Collection: User Ads Listing
- GET     `{apiPrefix}/users/{userId}/ads`  # pagination needed


## Collection: Ads Search & Browsing

### Category Level Search
- GET     `{apiPrefix}/{locationSlug}/categories/{categorySlug}/ads` # pagination needed

### Brand Level Search
- GET     `{apiPrefix}/{locationSlug}/categories/{categorySlug}/brands/{brandModelSlug}/ads` # pagination needed

### Model Level Search
- GET     `{apiPrefix}/{locationSlug}/categories/{categorySlug}/brands/{brandModelSlug}/models/{brandModelSlug}/ads` # pagination needed

### Car Release Year Level Search
- GET     `{apiPrefix}/{locationSlug}/categories/{categorySlug}/brands/{brandModelSlug}/models/{brandModelSlug}/years/{release-year}/ads` # pagination needed

## Collection: Public Ad Viewing, Editing & Deleting

### Category Level
- GET `{apiPrefix}/categories/{categorySlug}/ads/{adSlug}`
- PATCH `{apiPrefix}/categories/{categorySlug}/ads/{adSlug}` (with permission check)
- DELETE `{apiPrefix}/categories/{categorySlug}/ads/{adSlug}` (with permission check)

### Brand Level  
- GET `{apiPrefix}/categories/{categorySlug}/brands/{brandModelSlug}/ads/{adSlug}`
- PATCH `{apiPrefix}/categories/{categorySlug}/brands/{brandModelSlug}/ads/{adSlug}` (with permission check)
- DELETE `{apiPrefix}/categories/{categorySlug}/brands/{brandModelSlug}/ads/{adSlug}` (with permission check)

### Model Level  
- GET `{apiPrefix}/categories/{categorySlug}/brands/{brandModelSlug}/models/{brandModelSlug}/ads/{adSlug}`
- PATCH `{apiPrefix}/categories/{categorySlug}/brands/{brandModelSlug}/models/{brandModelSlug}/ads/{adSlug}` (with permission check)
- DELETE `{apiPrefix}/categories/{categorySlug}/brands/{brandModelSlug}/models/{brandModelSlug}/ads/{adSlug}` (with permission check)

### Release Year Level (for cars only)
- GET `{apiPrefix}/categories/{categorySlug}/brands/{brandModelSlug}/models/{brandModelSlug}/years/{release-year}/ads/{adSlug}`
- PATCH `{apiPrefix}/categories/{categorySlug}/brands/{brandModelSlug}/models/{brandModelSlug}/years/{release-year}/ads/{adSlug}` (with permission check)
- DELETE `{apiPrefix}/categories/{categorySlug}/brands/{brandModelSlug}/models/{brandModelSlug}/years/{release-year}/ads/{adSlug}` (with permission check)

## Collection: Chat & Messaging

### Conversation Management
- POST    `{apiPrefix}/ads/{adSlug}/conversations` # Start conversation (after sending first message only)
- GET     `{apiPrefix}/conversations`  # (with permission check) pagination needed

### Message Management
- GET     `{apiPrefix}/conversations/{conversationId}/messages` # Get all messages in conversation. pagination needed
- POST    `{apiPrefix}/conversations/{conversationId}/messages` # Send a new message
- PATCH   `{apiPrefix}/conversations/{conversationId}/messages/{messageId}` # Update message read status