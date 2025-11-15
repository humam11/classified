# Multipart Image Upload Implementation

## Overview
Implemented multipart/form-data image upload functionality for classified ads with automatic WebP conversion and optimization.

## Key Features

### 1. Image Upload via Multipart Form Data
- Accepts 1-5 images per ad
- Supports formats: JPG, JPEG, PNG, GIF, WebP
- Max file size: 10MB per image
- Images uploaded separately from JSON data

### 2. Automatic Image Processing
- **WebP Conversion**: All images automatically converted to WebP format
- **Optimization**: Quality set to 85% for optimal size/quality balance
- **Resizing**: Images resized to max 1920x1080 (maintains aspect ratio)
- **Unique Naming**: Each image gets a unique GUID-based filename
- **Organized Storage**: Images stored in `wwwroot/images/ads/{adId}/`

### 3. Image Order
- Order determined by upload sequence (no manual ordering needed)
- First uploaded image = Order 1, second = Order 2, etc.

## API Changes

### Controller Endpoint
**POST** `/api/{lang}/categories/{**categorySlug}`

**Content-Type**: `multipart/form-data`

**Parameters**:
- `adData` (form field, text): JSON string containing ad details
- `images` (form field, file): Image files (1-5 files)

**Example Request**:
```
POST /api/ar/categories/مركبات-ونقل/سيارات/ads
Content-Type: multipart/form-data

adData: {"title":"تويوتا كامري","price":{"value":35000,"isDollar":true},"locationAd":{"city":"بغداد"}}
images: [car1.jpg, car2.jpg]
```

## Architecture Changes

### New Components

#### 1. IImageService Interface
```csharp
public interface IImageService
{
    Task<List<ProcessedImageInfo>> ProcessAndSaveImagesAsync(List<ImageUpload> images, string adId);
    Task DeleteAdImagesAsync(string adId);
}
```

#### 2. ImageService Implementation
- Converts images to WebP format using ImageSharp
- Resizes images to max dimensions
- Saves to local file system
- Generates public URLs

#### 3. ImageUpload Abstraction
```csharp
public class ImageUpload
{
    public Stream Stream { get; set; }
    public string FileName { get; set; }
    public long Length { get; set; }
}
```

This abstraction keeps the Application layer independent of ASP.NET Core types.

### Modified Components

#### 1. DynamicAdsController
- Changed from `[FromBody] JsonElement` to `[FromForm] string adData` + `[FromForm] List<IFormFile> images`
- Added image validation (count, size, format)
- Converts IFormFile to ImageUpload abstraction

#### 2. IAdService
- Added `CreateAdWithImagesAsync` method

#### 3. AdService
- Implements image processing workflow:
  1. Create ad entity
  2. Insert to MongoDB (get ID)
  3. Process and save images
  4. Update ad with image URLs

#### 4. AdImageDto
- Simplified to display-only DTO
- Removed IFormFile reference (moved to controller layer)

## Configuration

### appsettings.json
```json
{
  "ImageStorage": {
    "Path": "wwwroot/images/ads",
    "BaseUrl": "/images/ads"
  }
}
```

## Dependencies

### New Package
- **SixLabors.ImageSharp** v3.1.6: Image processing library

## Validation Rules

### Image Validation
- **Count**: 1-5 images required
- **Size**: Max 10MB per image
- **Format**: .jpg, .jpeg, .png, .gif, .webp
- **Processing**: Auto-resize to 1920x1080 max
- **Conversion**: All formats converted to WebP

### Ad Data Validation
- Same as before (title, description, price, location required)

## File Structure

```
wwwroot/
└── images/
    └── ads/
        └── {adId}/
            ├── {guid1}.webp
            ├── {guid2}.webp
            └── ...
```

## Testing

### Using Postman
1. Create POST request to endpoint
2. Select Body → form-data
3. Add `adData` key (Text) with JSON value
4. Add `images` key (File) and select image files
5. Add multiple `images` keys for multiple files

### Using curl (Windows PowerShell)
```powershell
curl -X POST "http://localhost:5059/api/ar/categories/مركبات-ونقل/سيارات/ads" `
  -F "adData={`"title`":`"Test`",`"price`":{`"value`":1000,`"isDollar`":true},`"locationAd`":{`"city`":`"بغداد`"}}" `
  -F "images=@C:\path\to\image1.jpg" `
  -F "images=@C:\path\to\image2.jpg"
```

## Benefits

1. **Performance**: WebP format reduces file sizes by 25-35%
2. **Consistency**: All images in same format
3. **Optimization**: Automatic resizing prevents oversized images
4. **Organization**: Images grouped by ad ID
5. **Clean Architecture**: Application layer independent of web framework
6. **Validation**: Comprehensive validation at controller level

## Future Enhancements

- [ ] Generate thumbnails for listing pages
- [ ] Add image compression levels based on image type
- [ ] Implement CDN integration
- [ ] Add watermarking support
- [ ] Implement lazy loading URLs
- [ ] Add image metadata extraction (EXIF)
