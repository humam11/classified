# Testing Multipart Form Upload

## Important Note
**.http files DO NOT support actual file uploads!** You must use Postman or curl.

## Option 1: Test with Postman (RECOMMENDED)

1. **Open Postman**
2. **Create new POST request**
3. **URL**: `http://localhost:5059/api/ar/categories/مركبات-ونقل/سيارات/ads`
4. **Go to Body tab** → Select **form-data**
5. **Add these fields** (all as Text type except Images):

| Key | Type | Value |
|-----|------|-------|
| Title | Text | تويوتا كامري 2023 |
| Description | Text | سيارة نظيفة جداً |
| PriceValue | Text | 35000 |
| PriceIsDollar | Text | true |
| City | Text | بغداد |
| Region | Text | الكرخ |
| Neighborhood | Text | المنصور |
| Street | Text | شارع الكرادة |
| Images | File | [Select an image file] |

6. **Click Send**

## Option 2: Test with PowerShell curl

```powershell
# Create a test image first or use an existing one
$imagePath = "C:\path\to\your\image.jpg"

curl -X POST "http://localhost:5059/api/ar/categories/مركبات-ونقل/سيارات/ads" `
  -F "Title=تويوتا كامري 2023" `
  -F "Description=سيارة نظيفة جداً" `
  -F "PriceValue=35000" `
  -F "PriceIsDollar=true" `
  -F "City=بغداد" `
  -F "Region=الكرخ" `
  -F "Neighborhood=المنصور" `
  -F "Street=شارع الكرادة" `
  -F "Images=@$imagePath"
```

## Option 3: Test with CMD curl

```cmd
curl -X POST "http://localhost:5059/api/ar/categories/مركبات-ونقل/سيارات/ads" ^
  -F "Title=تويوتا كامري 2023" ^
  -F "Description=سيارة نظيفة جداً" ^
  -F "PriceValue=35000" ^
  -F "PriceIsDollar=true" ^
  -F "City=بغداد" ^
  -F "Region=الكرخ" ^
  -F "Neighborhood=المنصور" ^
  -F "Street=شارع الكرادة" ^
  -F "Images=@C:\path\to\image.jpg"
```

## Troubleshooting

### Error: "Failed to read the request form"
This error in .http files is EXPECTED because .http files cannot send actual file data. Use Postman or curl instead.

### Error: "At least one image is required"
Make sure you're selecting an actual image file in Postman or using the correct file path in curl.

### Error: "Image exceeds 10MB limit"
Your image file is too large. Resize it or use a smaller image.

### Error: "Invalid format"
Only these formats are allowed: .jpg, .jpeg, .png, .gif, .webp

## Expected Response

```json
{
  "id": "673701234567890abcdef123"
}
```

The images will be:
- Converted to WebP format
- Resized to max 1920x1080
- Saved to: `wwwroot/images/ads/{adId}/`
- Accessible at: `/images/ads/{adId}/{guid}.webp`
