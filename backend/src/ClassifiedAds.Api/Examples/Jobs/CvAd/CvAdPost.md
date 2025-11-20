# POST Create CV Ad Example

Method: POST
URL: http://localhost:5059/api/ar/categories/وظائف-وخدمات/سير-ذاتية/سير-ذاتية-تقنية-معلومات/ads
Title          [Text]  مطور Full Stack - 5 سنوات خبرة
Description    [Text]  مطور Full Stack ذو خبرة 5 سنوات في تطوير تطبيقات الويب. خبرة في React، Node.js، MongoDB، PostgreSQL. أبحث عن فرصة عمل في شركة تقنية
IsDollar       [Text]  true
PriceValue     [Text]  2000
City           [Text]  بغداد
Region         [Text]  الكرخ
Neighborhood   [Text]  المنصور
FirstName      [Text]  أحمد
LastName       [Text]  محمد
Gender         [Text]  0
DateOfBirth    [Text]  1995-05-15
PhoneNumber    [Text]  +964 770 123 4567
ContactEmail   [Text]  ahmad.mohammed@email.com
JobSearchStatus [Text] 0
Education      [Text]  [{"InstitutionName":"جامعة بغداد","EducationDegree":2,"Specialization":"علوم الحاسوب","StartDate":"2013-09-01","EndDate":"2017-06-30"}]
Experience     [Text]  [{"CompanyName":"شركة التقنية المتقدمة","Position":"مطور Full Stack","StartDate":"2017-08-01","EndDate":"2022-12-31"},{"CompanyName":"شركة الحلول الرقمية","Position":"مطور Senior Full Stack","StartDate":"2023-01-01","EndDate":"2024-11-01"}]
Languages      [Text]  [{"Name":"العربية","LanguageProficiency":3},{"Name":"English","LanguageProficiency":2},{"Name":"Kurdish","LanguageProficiency":1}]
ImageFiles     [File]  📁 Select profile-photo.jpg
ImageFiles     [File]  📁 Select certificate.jpg

## Field Explanations:

### Enums:
- Gender: 0=Male, 1=Female
- JobSearchStatus: 0=LookingForWork, 1=EmployedAndLooking, 2=NotLooking
- EducationDegree: 0=HighSchool, 1=Diploma, 2=Bachelor, 3=Master, 4=PhD, 5=Other
- LanguageProficiency: 0=Basic, 1=Intermediate, 2=Fluent, 3=Native, 4=Other

### JSON Arrays:
- Education: Array of education entries with InstitutionName, EducationDegree, Specialization, StartDate, EndDate
- Experience: Array of work experience entries with CompanyName, Position, StartDate, EndDate
- Languages: Array of language skills with Name and LanguageProficiency level
