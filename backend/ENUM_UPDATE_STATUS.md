# Enum Update Status

## ✅ Already Updated (Have QueryKey/QueryValue)
- JobType
- FuelType  
- Units
- Status (just updated)
- YesNo (just updated)

## 📝 Need to Update

### Common Enums
- None remaining

### Vehicle Enums
- CarDriveType
- MotorcycleDriveType
- Transmission

### Electronics Enums
- Color
- RamSize
- RefreshRate
- Region
- ScreenResolution
- StorageCapacity
- WebcamResolution

### Real Estate Enums
- CompletionStatus

### Miscellaneous Enums
- BookLanguage
- ClothCondition
- ClothingSize
- FurnitureMaterial
- OilType
- PlantType
- Season
- Viscosity

### Jobs/Services Enums
- DayOfWeek
- EducationDegree
- EducationLevel
- FieldOfStudy
- Gender
- JobSearchStatus
- LanguageProficiency
- PaymentPeriod
- WorkingHours

### PostgreSQL Enums
- BugReportStatus
- LocationSource
- UserReportReasonType
- UserReportStatus

### Chat Enums
- ContentType
- ConversationStatus

## Total: ~35 enums need updating

## Next Steps
1. Update validators to use localized messages
2. Create middleware to extract language from URL
3. Test enum query string generation
