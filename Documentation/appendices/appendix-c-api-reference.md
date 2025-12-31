# Appendix C: API Endpoint Reference

## C.1 Base URL Structure

```
{base_url}/api/{lang}/{resource}
```

- `{base_url}`: Application base URL (e.g., `https://api.example.com`)
- `{lang}`: Language code (`en` or `ru`)
- `{resource}`: Resource path

---

## C.2 Ad Management Endpoints

### C.2.1 Create Ad

**Endpoint**: `POST /api/{lang}/categories/{categorySlug}`

**Content-Type**: `multipart/form-data`

**Request Body**:
```
title: string (required)
description: string (required)
priceValue: decimal (required)
priceCurrency: string (required)
locationIds: int[] (required, 3 elements)
images: file[] (optional, max 50MB each)
[category-specific fields]
```

**Response**: `201 Created`
```json
{
  "id": "507f1f77bcf86cd799439041"
}
```

---

### C.2.2 Search Ads by Category

**Endpoint**: `GET /api/{lang}/categories/{categorySlug}/ads`

**Query Parameters**:
- `page`: int (default: 1)
- `pageSize`: int (default: 20, max: 100)
- `sortBy`: string (price, date)
- `sortOrder`: string (asc, desc)
- `minPrice`: decimal
- `maxPrice`: decimal

**Response**: `200 OK`
```json
{
  "data": [
    {
      "id": "507f1f77bcf86cd799439041",
      "title": "2022 Toyota Land Cruiser VXR",
      "price": {
        "value": 65000.00,
        "currency": "USD",
        "displayText": "$65,000"
      },
      "location": {
        "locationIds": [1, 15, 150],
        "fullAddress": "Baghdad, Iraq"
      },
      "images": [
        {
          "imageUrl": "/images/ads/507f.../001.jpg",
          "order": 1
        }
      ],
      "createdAt": "2024-05-09T11:15:00Z"
    }
  ],
  "pagination": {
    "page": 1,
    "pageSize": 20,
    "totalCount": 150,
    "totalPages": 8
  }
}
```

---

### C.2.3 Get Single Ad

**Endpoint**: `GET /api/{lang}/categories/{categorySlug}/ads/{adSlug}`

**Response**: `200 OK`
```json
{
  "id": "507f1f77bcf86cd799439041",
  "title": "2022 Toyota Land Cruiser VXR",
  "description": "Premium condition, full service history",
  "price": {
    "value": 65000.00,
    "currency": "USD",
    "displayText": "$65,000"
  },
  "status": 1,
  "createdAt": "2024-05-09T11:15:00Z",
  "updatedAt": "2024-05-09T11:15:00Z",
  "userId": "018e9c9c-7c1a-7c1a-7c1a-7c1a7c1a7c1b",
  "category": {
    "categoryIds": [1, 2, 3]
  },
  "location": {
    "locationIds": [1, 15, 150],
    "fullAddress": "123 Republic St, Mansour, Baghdad",
    "coordinates": {
      "latitude": 33.3152,
      "longitude": 44.3661
    }
  },
  "images": [
    {
      "imageUrl": "/images/ads/507f.../001.jpg",
      "order": 1
    }
  ],
  "distanceKm": 40000,
  "transmission": 1,
  "fuelType": 1
}
```

---

### C.2.4 Update Ad by ID

**Endpoint**: `PATCH /api/{lang}/ads/{adId}`

**Content-Type**: `application/json`

**Request Body**:
```json
{
  "title": "Updated Title",
  "description": "Updated description",
  "priceValue": 60000.00
}
```

**Response**: `200 OK`
```json
{
  "message": "Ad updated successfully"
}
```

---

### C.2.5 Update Ad by Slug

**Endpoint**: `PATCH /api/{lang}/categories/{categorySlug}/ads/{adSlug}`

**Content-Type**: `application/json`

**Request Body**: Same as C.2.4

**Response**: `200 OK`

---

### C.2.6 Delete Ad by ID

**Endpoint**: `DELETE /api/{lang}/ads/{adId}`

**Response**: `200 OK`
```json
{
  "message": "Ad deleted successfully"
}
```

---

### C.2.7 Delete Ad by Slug

**Endpoint**: `DELETE /api/{lang}/categories/{categorySlug}/ads/{adSlug}`

**Response**: `200 OK`

---

## C.3 Brand/Model Search Endpoints

### C.3.1 Search by Brand/Model

**Endpoint**: `GET /api/{lang}/categories/{categorySlug}/models/{brandModelSlug}/ads`

**Query Parameters**: Same as C.2.2

**Response**: Same as C.2.2

---

### C.3.2 Search by Release Year

**Endpoint**: `GET /api/{lang}/categories/{categorySlug}/models/{brandModelSlug}/releases/{year}/ads`

**Query Parameters**: Same as C.2.2

**Response**: Same as C.2.2

---

## C.4 Error Responses

### C.4.1 Validation Error (400)

```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Title": ["Title is required"],
    "PriceValue": ["Price must be greater than 0"]
  }
}
```

---

### C.4.2 Not Found (404)

```json
{
  "error": "Ad not found",
  "status": 404
}
```

---

### C.4.3 Server Error (500)

```json
{
  "error": "An unexpected error occurred",
  "status": 500
}
```

---

## C.5 Request Examples

### C.5.1 Create Car Ad (cURL)

```bash
curl -X POST "https://api.example.com/api/en/categories/vehicles/cars" \
  -H "Content-Type: multipart/form-data" \
  -F "title=2022 Toyota Land Cruiser VXR" \
  -F "description=Premium condition" \
  -F "priceValue=65000" \
  -F "priceCurrency=USD" \
  -F "locationIds=1" \
  -F "locationIds=15" \
  -F "locationIds=150" \
  -F "distanceKm=40000" \
  -F "transmission=1" \
  -F "fuelType=1" \
  -F "images=@/path/to/image1.jpg" \
  -F "images=@/path/to/image2.jpg"
```

---

### C.5.2 Search Ads (cURL)

```bash
curl -X GET "https://api.example.com/api/en/categories/vehicles/cars/ads?page=1&pageSize=20&sortBy=price&sortOrder=desc&minPrice=50000&maxPrice=100000"
```

---

### C.5.3 Update Ad (cURL)

```bash
curl -X PATCH "https://api.example.com/api/en/ads/507f1f77bcf86cd799439041" \
  -H "Content-Type: application/json" \
  -d '{
    "title": "Updated Title",
    "priceValue": 60000
  }'
```

---

### C.5.4 Delete Ad (cURL)

```bash
curl -X DELETE "https://api.example.com/api/en/ads/507f1f77bcf86cd799439041"
```

---

**End of Appendix C**
