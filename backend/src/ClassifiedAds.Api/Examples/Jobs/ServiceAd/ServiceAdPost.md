# POST Create Service Ad Example

Method: POST
URL: http://localhost:5059/api/ar/categories/وظائف-وخدمات/خدمات/خدمات-صيانة-وإصلاح/ads
Title          [Text]  خدمات صيانة وإصلاح أجهزة الكمبيوتر
Description    [Text]  نقدم خدمات صيانة وإصلاح أجهزة الكمبيوتر واللابتوب. خبرة 10 سنوات. خدمة سريعة وموثوقة. نأتي إلى موقعك
PriceValue     [Text]  25000
IsDollar       [Text]  false
City           [Text]  بغداد
Region         [Text]  الكرخ
Neighborhood   [Text]  المنصور
Street         [Text]  شارع الاميرات، محل رقم 15
PaymentPeriod  [Text]  3
DailyAvailability [Text] [{"DayWeek":2,"IsAvailable":1,"Is24Hours":0,"TimeSlots":[{"OpeningTime":"09:00","ClosingTime":"18:00"}]},{"DayWeek":3,"IsAvailable":1,"Is24Hours":0,"TimeSlots":[{"OpeningTime":"09:00","ClosingTime":"18:00"}]},{"DayWeek":4,"IsAvailable":1,"Is24Hours":0,"TimeSlots":[{"OpeningTime":"09:00","ClosingTime":"18:00"}]},{"DayWeek":5,"IsAvailable":1,"Is24Hours":0,"TimeSlots":[{"OpeningTime":"09:00","ClosingTime":"18:00"}]},{"DayWeek":6,"IsAvailable":1,"Is24Hours":0,"TimeSlots":[{"OpeningTime":"09:00","ClosingTime":"18:00"}]},{"DayWeek":7,"IsAvailable":1,"Is24Hours":1,"TimeSlots":null},{"DayWeek":8,"IsAvailable":0,"Is24Hours":null,"TimeSlots":null}]
ImageFiles     [File]  📁 Select service-photo.jpg
ImageFiles     [File]  📁 Select work-sample.jpg

## Field Explanations:

### Enums:
- PaymentPeriod: 0=PerMonth, 1=PerShift, 2=PerHour, 3=PerService, 4=PerServiceAlt, 5=PerMeter, 6=PerPiece, 7=PerDay, 8=PerMinute
- DayWeek: 0=Everyday, 1=Depend, 2=Sunday, 3=Monday, 4=Tuesday, 5=Wednesday, 6=Thursday, 7=Friday, 8=Saturday
- YesNo: 0=No, 1=Yes

### DailyAvailability JSON Array:
Each entry represents availability for a specific day with the following structure:
- **DayWeek**: Day of the week (0-8)
- **IsAvailable**: Whether available on this day (0=No, 1=Yes)
- **Is24Hours**: Whether working 24 hours (0=No, 1=Yes) - Only when IsAvailable=Yes
- **TimeSlots**: Array of time slots - Only when IsAvailable=Yes and Is24Hours=No

### Validation Rules:
1. If `DayWeek` is provided → `IsAvailable` must be provided
2. If `IsAvailable` = No (0) → `Is24Hours` and `TimeSlots` must be null
3. If `IsAvailable` = Yes (1) → `Is24Hours` must be provided
4. If `Is24Hours` = No (0) → `TimeSlots` must be provided (at least one)
5. If `Is24Hours` = Yes (1) → `TimeSlots` must be null or empty

### Example Breakdown:
- Sunday-Thursday (2-6): Available 9 AM - 6 PM
- Friday (7): Available 24 hours
- Saturday (8): Not available
