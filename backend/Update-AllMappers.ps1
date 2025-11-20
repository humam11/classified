# PowerShell script to update all remaining mappers to use GetXxxAdDto
# Run this from the backend directory

$baseMapping = @'
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            Price = new DTOs.Common.PriceResponseDto { Value = entity.Price.Value, IsDollar = entity.Price.IsDollar, ShowingPrice = entity.Price.ShowingPrice },
            LocationAd = new DTOs.Common.LocationAdResponseDto { LocationIds = entity.LocationAd.LocationIds, FullAddressArabic = entity.LocationAd.FullAddressArabic, FullAddressKurdish = entity.LocationAd.FullAddressKurdish, Street = entity.LocationAd.Street },
            Images = entity.Images.Select(img => new DTOs.Common.AdImageDto { ImageId = img.ImageId, ImageUrl = img.ImageUrl, Order = img.Order }).ToList(),
            Status = (int)entity.Status,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            ImageCount = entity.ImageCount,
            ViewsCount = entity.ViewsCount,
            Priority = entity.Priority,
            Slug = entity.Slug,
            Category = new DTOs.Common.CategoryResponseDto { CategoryJoins = entity.Category.CategoryJoins, CategoryIds = entity.Category.CategoryIds },
'@

Write-Host "This script will help update all mappers to use GetXxxAdDto pattern"
Write-Host "Completed: CV, Service, Vacancy, Book"
Write-Host "Remaining: 27 ad types"
Write-Host ""
Write-Host "Manual steps required for each mapper:"
Write-Host "1. Find the MapToDto method"
Write-Host "2. Change return type from XxxAdDto to GetXxxAdDto"
Write-Host "3. Replace the body with base mapping + category-specific fields"
Write-Host ""
Write-Host "Base mapping template saved in MAPPER_BASE_TEMPLATE.txt"
