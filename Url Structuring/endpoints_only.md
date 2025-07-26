Collection: Main Page
- GET     {{apiPrefix}}/{{citySlug}}

Collection: Authentication
- POST {{apiPrefix}}/auth/sign-up
- POST {{apiPrefix}}/auth/sign-in                      
- POST {{apiPrefix}}/auth/sign-out
- POST {{apiPrefix}}/auth/refresh


Collection: User Profile Management (Info, Reviews, Top 3 Ads)
- GET     {{apiPrefix}}/profiles/{{userSlug}}
- PATCH   {{apiPrefix}}/profiles/{{userSlug}} (with permission check)


Collection: User Reviews And Reports
- POST    {{apiPrefix}}/profiles/{{userSlug}}/reviews
- GET     {{apiPrefix}}/profiles/{{userSlug}}/reviews #pagination needed
- GET     {{apiPrefix}}/profiles/{{userSlug}}/reviews/{{reviewSlug}}
- POST    {{apiPrefix}}/profiles/{{userSlug}}/reports
- POST    {{apiPrefix}}/bug-reports

Collection: User Ad CRUD
- POST    {{apiPrefix}}/ads/{{citySlug}}/{{categorySlug}}
- PATCH   {{apiPrefix}}/ads/{{adSlug}} (with permission check)
- DELETE  {{apiPrefix}}/ads/{{adSlug}} (with permission check)

Collection: User Ads Listing
- GET     {{apiPrefix}}/profiles/{{userSlug}}/ads  # Get all ads for non-authenticated user. pagination needed

Collection: Ads Category Search
- GET     {{apiPrefix}}/{{citySlug}}/{{categorySlug}} # pagination needed

Collection: Ads Brand Model Search
- GET     {{apiPrefix}}/{{citySlug}}/{{categorySlug}}/{{brandModelSlug}} # pagination needed

Collection: Ads Car Release Year Search
- GET     {{apiPrefix}}/{{citySlug}}/{{categorySlug}}/{{brandModelSlug}}/{{release-year}} # pagination needed

Collection: Public Ad Viewing - Category Level
- GET {{apiPrefix}}/{{categorySlug}}/ads/{{adSlug}}

Collection: Public Ad Viewing - Brand Model Level  
- GET {{apiPrefix}}/{{categorySlug}}/{{brandModelSlug}}/ads/{{adSlug}}

Collection: Public Ad Viewing - Release Year Level (for cars only)  
- GET {{apiPrefix}}/{{categorySlug}}/{{brandModelSlug}}/{{release-year}}/ads/{{adSlug}}

Collection: Chat & Messaging
**Conversation Management**
- GET     {{apiPrefix}}/conversations  # My conversations (authenticated users only) pagination needed
- POST    {{apiPrefix}}/ads/{{adSlug}}/conversations # Start conversation (after sending first message only)

**Message Management**
- GET     {{apiPrefix}}/conversations/{{conversationId}}/messages # Get all messages in conversation. pagination needed
- POST    {{apiPrefix}}/conversations/{{conversationId}}/messages # Send a new message
- PATCH   {{apiPrefix}}/conversations/{{conversationId}}/messages/{{messageId}} # Update message read status