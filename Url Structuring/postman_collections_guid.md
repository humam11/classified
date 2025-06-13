# Postman Collections Setup Guide
- apiPrefix (base url) = `www.domain.com/${version}/${langCode}`

## Collection 1: Authentication
**Collection Name**: `Authentication`

### Requests:
1. **Sign Up**
   - Method: `POST`
   - URL: `{{apiPrefix}}/sign-up`
   - Body: `raw/JSON`

2. **Sign In**
   - Method: `POST`
   - URL: `{{apiPrefix}}/sign-in`
   - Body: `raw/JSON`

---

## Version Management Strategy

### URL Structure with Versioning:
**Pattern**: `{{apiPrefix}}/endpoint`

**Examples**:
- V1 Arabic: `https://mybasedomain.com/v1/ar/profiles/me`
- V1 Kurdish: `https://mybasedomain.com/v1/kr/profiles/me`
- V2 Arabic: `https://mybasedomain.com/v2/ar/profiles/me`
- V2 Kurdish: `https://mybasedomain.com/v2/kr/profiles/me`
# here get redirect automatically so if {{apiPrefix}}/profiles/{userSlug} so userSlug = to authenticated user then will redirect him to {{apiPrefix}}/profiles/me


### Environment-Based Version Testing:
1. **Development**: Always uses latest stable version (v1)
2. **Production**: Uses production-ready version (v1)
3. **Testing**: Uses current stable version (v1)
4. **V2 Testing**: Dedicated environment for v2 features

### Version Switching:
To test different API versions, simply:
1. Change the `version` variable from `"v1"` to `"v2"`
2. Or switch to the "V2 Testing" environment
3. All requests will automatically use the new version

### Backward Compatibility Testing:
Create separate collections for each major version:
- **API v1 Collection** - All endpoints with v1 specifics  
- **API v2 Collection** - All endpoints with v2 updates
- **Cross-Version Tests** - Compare v1 vs v2 responses

---

## Collection 2: User Profile Management
**Collection Name**: `User Profile Management`

### Requests:
1. **Get Own Profile**
   - Method: `GET`
   - URL: `{{apiPrefix}}/profiles/me`
   - Auth: Bearer Token

2. **Update Own Profile**
   - Method: `PATCH`
   - URL: `{{apiPrefix}}/profiles/me`
   - Auth: Bearer Token
   - Body: `raw/JSON`

3. **Get Public User Profile**
   - Method: `GET`
   - URL: `{{apiPrefix}}/profiles/{{userSlug}}`

---

## Collection 3: User Ad Management
**Collection Name**: `User Ad Management`

### Requests:
1. **Get Own Ad (Private)**
   - Method: `GET`
   - URL: `{{apiPrefix}}/ads/{{adSlug}}/me`
   - Auth: Bearer Token

2. **Update Own Ad**
   - Method: `PATCH`
   - URL: `{{apiPrefix}}/ads/{{adSlug}}/me`
   - Auth: Bearer Token
   - Body: `raw/JSON`

3. **Delete Own Ad**
   - Method: `DELETE`
   - URL: `{{apiPrefix}}/ads/{{adSlug}}/me`
   - Auth: Bearer Token

---

## Collection 4: Reviews & Reports
**Collection Name**: `Reviews & Reports`

### Requests:
1. **Create User Review**
   - Method: `POST`
   - URL: `{{apiPrefix}}/profiles/{{userSlug}}/reviews`
   - Auth: Bearer Token
   - Body: `raw/JSON`

2. **Get User Reviews**
   - Method: `GET`
   - URL: `{{apiPrefix}}/profiles/{{userSlug}}/reviews`
   - Query Params: `page`, `limit`

3. **Report User**
   - Method: `POST`
   - URL: `{{apiPrefix}}/profiles/{{userSlug}}/reports`
   - Auth: Bearer Token
   - Body: `raw/JSON`

4. **Report Site Bug**
   - Method: `POST`
   - URL: `{{apiPrefix}}/bug-reports`
   - Auth: Bearer Token
   - Body: `raw/JSON`

---

## Collection 5: User Ads Listing
**Collection Name**: `User Ads Listing`

### Requests:
1. **Get User's Public Ads**
   - Method: `GET`
   - URL: `{{apiPrefix}}/profiles/{{userSlug}}/ads/`
   - Query Params: `page`, `limit`

---

## Collection 6: Location-Based Search
**Collection Name**: `Location-Based Search`

### Requests:
1. **location Search**
   - Method: `GET`
   - URL: `{{apiPrefix}}/{{citySlug}}/`
   - Query Params: `page`, `limit`

---

## Collection 7: Category-Based Search
**Collection Name**: `Category-Based Search`

### Requests:
1. **Category Search**
   - Method: `GET`
   - URL: `{{apiPrefix}}/{{citySlug}}/{{categorySlug}}/`
   - Query Params: `page`, `limit`

2. **Category with Filters**
   - Method: `GET`
   - URL: `{{apiPrefix}}/{{citySlug}}/{{categorySlug}}/`

---

## Collection 8: Brand & Model Search
**Collection Name**: `Brand & Model Search`

### Requests:
1. **Brand/Model Search**
   - Method: `GET`
   - URL: `{{apiPrefix}}/{{citySlug}}/{{categorySlug}}/{{brandModelSlug}}/`
   - Query Params: `page`, `limit`

2. **Brand/Model with Filters**
   - Method: `GET`
   - URL: `{{apiPrefix}}/{{citySlug}}/{{categorySlug}}/{{brandModelSlug}}/`
   - Query Params: `min_price`, `condition`, `page`, `limit`

---

## Collection 9: Car-Specific Endpoints
**Collection Name**: `Car-Specific Endpoints`

### Requests:
1. **Get Car Brands & Models**
   - Method: `GET`
   - URL: `{{apiPrefix}}/{{citySlug}}/{{categorySlug}}/{{brandModelSlug}}/`
   - Query Params: `page`, `limit`

2. **Get Specific Release Year**
   - Method: `GET`
   - URL: `{{apiPrefix}}/{{citySlug}}/{{categorySlug}}/{{brandModelSlug}}/{{release-year}}/`
   - Query Params: `page`, `limit`

3. **Release Year with Filters**
   - Method: `GET`
   - URL: `{{apiPrefix}}/{{citySlug}}/{{categorySlug}}/{{brandModelSlug}}/{{release-year}}/`
   - Query Params: `min_price`, `condition`, `page`, `limit`

---

## Query Parameters
For detailed information about all available query parameters, filtering options, and usage examples, please refer to the [Query Parameters Guide](./query_parameters_guide.md).

---

## Complete Variable Reference Guide

### Base Configuration Variables
- `baseUrl` - Main API base URL (e.g., "https://mybasedomain.com")
- `version` - API version (v1/v2)
- `langCode` - Language code (ar/kr)

### Authentication Variables
- `authToken` - JWT access token for authenticated requests
- `refreshToken` - Refresh token for token renewal

### Entity Slug Variables
- `userSlug` - User profile slug (e.g., "john-doe-a3f9")
- `adSlug` - Advertisement slug (e.g., "used-iphone-15-pro-max-256gb-a3f9")

### Location Variables
- `citySlug` - City slug (e.g., "baghdad-b2c8")

### Category & Product Variables
- `categorySlug` - Product category slug (e.g., "electronics-e4d7")
- `brandModelSlug` - Brand and model slug (e.g., "iphone-15-pro-f5a2")
- `releaseYear` - Product release year (e.g., "2024")

### Filter Variables
- `minPrice` - Minimum price filter
- `maxPrice` - Maximum price filter
- `condition` - Product condition (new/used/refurbished)

### Pagination Variables
- `page` - Current page number
- `limit` - Items per page limit

### ID Variables (for direct API calls)
- `userId` - Numeric user ID
- `adId` - Numeric advertisement ID
- `reviewId` - Numeric review ID
- `reportId` - Numeric report ID

---

## Variable Usage Examples

### Using Variables in URLs:
```
{{apiPrefix}}/{{version}}/{{langCode}}/profiles/{{userSlug}}
{{apiPrefix}}/{{version}}/{{langCode}}/ads/{{adSlug}}/me
{{apiPrefix}}/{{version}}/{{langCode}}/{{citySlug}}/{{categorySlug}}/
{{apiPrefix}}/{{version}}/{{langCode}}/{{citySlug}}/{{categorySlug}}/{{brandModelSlug}}/{{releaseYear}}
```

### Using Variables in Query Parameters:
```
{{apiPrefix}}/{{version}}/{{langCode}}/{{citySlug}}/{{categorySlug}}/?min_price={{minPrice}}&condition={{condition}}&page={{page}}&limit={{limit}}
```

### Using Variables in Headers:
```
Authorization: Bearer {{authToken}}
Content-Type: application/json
Accept-Language: {{langCode}}
```

---

## Dynamic Variable Setting

### Pre-request Scripts (for automatic token handling):
```javascript
// Set auth token from login response
pm.test("Set auth token", function () {
    var jsonData = pm.response.json();
    pm.environment.set("authToken", jsonData.access_token);
    pm.environment.set("refreshToken", jsonData.refresh_token);
});
```

### Test Scripts (for extracting IDs):
```javascript
// Extract user slug from response
pm.test("Extract user slug", function () {
    var jsonData = pm.response.json();
    pm.environment.set("userSlug", jsonData.user.slug);
});

// Extract ad slug from response
pm.test("Extract ad slug", function () {
    var jsonData = pm.response.json();
    pm.environment.set("adSlug", jsonData.ad.slug);
});
```

### Step 1: Create Workspace
1. Open Postman
2. Create new Workspace: "My Classified API"

### Step 2: Create Collections
For each collection above:
1. Click "New" → "Collection"
2. Name the collection
3. Add description from the documentation
4. Save collection

### Step 3: Add Requests
For each request in each collection:
1. Click "Add Request" in the collection
2. Set the HTTP method
3. Enter the URL with variables
4. Add authentication if required
5. Add query parameters
6. Add request body for POST/PATCH requests
7. Save the request

### Step 4: Setup Environment
1. Click gear icon (top right)
2. Click "Add"
3. Name: "Development"
4. Add all variables from above
5. Save environment
6. Select "Development" environment

### Step 5: Test Collections
1. Set up authentication tokens
2. Test each collection separately
3. Verify responses
4. Update environment variables as needed

---

## Sample Request Bodies

### Sign Up Request Body:
```json
{
  "username": "johndoe",
  "email": "john@example.com",
  "password": "securePassword123",
  "phone": "+9641234567890"
}
```

### Create Review Request Body:
```json
{
  "rating": 5,
  "comment": "Great seller, fast delivery!",
  "transaction_id": "txn_123456"
}
```

### Report User Request Body:
```json
{
  "reason": "spam",
  "description": "User is posting duplicate ads",
  "evidence_urls": ["https://example.com/screenshot1.jpg"]
}
```

### Update Profile Request Body:
```json
{
  "display_name": "John Doe",
  "bio": "Trusted seller since 2020",
  "phone": "+9641234567890",
  "location": "Baghdad, Iraq"
}
```