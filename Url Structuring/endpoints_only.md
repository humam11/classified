Collection: Main Page
- GET     {{apiPrefix}}/{{citySlug}}

Collection: Authentication
- POST    {{apiPrefix}}/sign-up
- POST    {{apiPrefix}}/sign-in

Collection: User Profile CRUD
- GET     {{apiPrefix}}/profiles/me
- PATCH   {{apiPrefix}}/profiles/me
- GET     {{apiPrefix}}/profiles/{{userSlug}}


Collection: User Reviews And Reports
- POST    {{apiPrefix}}/profiles/{{userSlug}}/reviews
- GET     {{apiPrefix}}/profiles/{{userSlug}}/reviews
- POST    {{apiPrefix}}/profiles/{{userSlug}}/reports
- POST    {{apiPrefix}}/bug-reports


Collection: User Ads Listing
- GET     {{apiPrefix}}/profiles/{{userSlug}}/ads


Collection: Public Ad Viewing - Category Level
- GET {{apiPrefix}}/{{categorySlug}}/ads/{{adSlug}}

Collection: Public Ad Viewing - Brand Level  
- GET {{apiPrefix}}/{{categorySlug}}/{{brandSlug}}/ads/{{adSlug}}

Collection: User Ad CRUD
- POST    {{apiPrefix}}/ads
- GET     {{apiPrefix}}/ads/me - Get all ads for authenticated user
- GET     {{apiPrefix}}/ads/{{adSlug}}/me
- PATCH   {{apiPrefix}}/ads/{{adSlug}}/me - Update ad details or archieve it
- DELETE  {{apiPrefix}}/ads/{{adSlug}}/me

Collection: Category Search
- GET     {{apiPrefix}}/{{citySlug}}/{{categorySlug}}

Collection: Brand Model Search
- GET     {{apiPrefix}}/{{citySlug}}/{{categorySlug}}/{{brandModelSlug}}

Collection: Car Year Search - Release Level
- GET     {{apiPrefix}}/{{citySlug}}/{{categorySlug}}/{{brandModelSlug}}/{{release-year}}

Collection: Chat & Messaging
**Conversation Management**
- GET     {{apiPrefix}}/conversations/me - Get all conversations for authenticated user
- POST    {{apiPrefix}}/ads/{{adSlug}}/conversations - Start a new conversation about an ad

**Message Management**
- GET     {{apiPrefix}}/conversations/{{conversationId}}/messages - Get all messages in conv.
- POST    {{apiPrefix}}/conversations/{{conversationId}}/messages - Send a new message
- PATCH   {{apiPrefix}}/messages/{{messageId}} - Update message read status