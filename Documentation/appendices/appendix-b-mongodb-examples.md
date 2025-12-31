# Appendix B: MongoDB Document Examples

## B.1 Base Ad Document

```json
{
  "_id": ObjectId("507f1f77bcf86cd799439041"),
  "_t": "Ad",
  "title": "Example Ad Title",
  "description": "Detailed description of the item",
  "price": {
    "value": 1000.00,
    "currency": "USD",
    "displayText": "$1,000"
  },
  "status": 1,
  "createdAt": ISODate("2024-05-09T11:15:00Z"),
  "updatedAt": ISODate("2024-05-09T11:15:00Z"),
  "userId": "018e9c9c-7c1a-7c1a-7c1a-7c1a7c1a7c1b",
  "slug": "example-ad-title",
  "category": {
    "categoryIds": [1, 2, 3],
    "categoryPath": "1.2.3"
  },
  "location": {
    "locationIds": [1, 15, 150],
    "fullAddress": "123 Main St, District, City",
    "coordinates": {
      "latitude": 33.3152,
      "longitude": 44.3661
    }
  },
  "images": [
    {
      "imageId": "img_001",
      "imageUrl": "/images/ads/507f.../001.jpg",
      "order": 1
    }
  ]
}
```

---

## B.2 Car Ad Document (Complete Example)

```json
{
  "_id": ObjectId("507f1f77bcf86cd799439041"),
  "_t": "Car",
  "title": "2022 Toyota Land Cruiser VXR",
  "description": "Premium condition, full service history, single owner",
  "price": {
    "value": 65000.00,
    "currency": "USD",
    "displayText": "$65,000"
  },
  "status": 1,
  "createdAt": ISODate("2024-05-09T11:15:00Z"),
  "updatedAt": ISODate("2024-05-09T11:15:00Z"),
  "userId": "018e9c9c-7c1a-7c1a-7c1a-7c1a7c1a7c1b",
  "slug": "2022-toyota-land-cruiser-vxr",
  "category": {
    "categoryIds": [1, 2, 3],
    "categoryPath": "1.2.3"
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
      "imageId": "img_001",
      "imageUrl": "/images/ads/507f.../001.jpg",
      "order": 1
    },
    {
      "imageId": "img_002",
      "imageUrl": "/images/ads/507f.../002.jpg",
      "order": 2
    }
  ],
  "fuelType": 1,
  "enginePower": 304,
  "fuelTankCapacity": 138,
  "distanceKm": 40000,
  "engineDescription": "5.7L V8",
  "cylinders": 8,
  "transmission": 1,
  "driveType": 2,
  "color": "White Pearl",
  "brandModelIds": ["brand_123", "model_456"],
  "releaseYear": "2022"
}
```

---

## B.3 Laptop Ad Document

```json
{
  "_id": ObjectId("507f1f77bcf86cd799439042"),
  "_t": "Laptop",
  "title": "MacBook Pro 16-inch M2 Max",
  "description": "Like new, barely used, includes original box and accessories",
  "price": {
    "value": 2500.00,
    "currency": "USD",
    "displayText": "$2,500"
  },
  "status": 1,
  "createdAt": ISODate("2024-05-10T14:30:00Z"),
  "updatedAt": ISODate("2024-05-10T14:30:00Z"),
  "userId": "018e9c9c-7c1a-7c1a-7c1a-7c1a7c1a7c1c",
  "slug": "macbook-pro-16-inch-m2-max",
  "category": {
    "categoryIds": [10, 11, 12],
    "categoryPath": "10.11.12"
  },
  "location": {
    "locationIds": [1, 15, 151],
    "fullAddress": "456 Tech St, Karrada, Baghdad",
    "coordinates": {
      "latitude": 33.3152,
      "longitude": 44.3661
    }
  },
  "images": [
    {
      "imageId": "img_003",
      "imageUrl": "/images/ads/507f.../003.jpg",
      "order": 1
    }
  ],
  "processor": "Apple M2 Max",
  "ram": 32,
  "storage": 1024,
  "screenSize": 16.2,
  "graphicsCard": "Integrated",
  "operatingSystem": "macOS Sonoma",
  "condition": 1,
  "brandModelIds": ["brand_apple", "model_macbook_pro"]
}
```

---

## B.4 House Ad Document

```json
{
  "_id": ObjectId("507f1f77bcf86cd799439043"),
  "_t": "House",
  "title": "Modern 4-Bedroom Villa with Pool",
  "description": "Spacious villa in prime location, fully furnished, ready to move in",
  "price": {
    "value": 450000.00,
    "currency": "USD",
    "displayText": "$450,000"
  },
  "status": 1,
  "createdAt": ISODate("2024-05-11T09:00:00Z"),
  "updatedAt": ISODate("2024-05-11T09:00:00Z"),
  "userId": "018e9c9c-7c1a-7c1a-7c1a-7c1a7c1a7c1d",
  "slug": "modern-4-bedroom-villa-with-pool",
  "category": {
    "categoryIds": [20, 21, 22],
    "categoryPath": "20.21.22"
  },
  "location": {
    "locationIds": [1, 15, 152],
    "fullAddress": "789 Garden St, Jadriya, Baghdad",
    "coordinates": {
      "latitude": 33.2900,
      "longitude": 44.3800
    }
  },
  "images": [
    {
      "imageId": "img_004",
      "imageUrl": "/images/ads/507f.../004.jpg",
      "order": 1
    },
    {
      "imageId": "img_005",
      "imageUrl": "/images/ads/507f.../005.jpg",
      "order": 2
    },
    {
      "imageId": "img_006",
      "imageUrl": "/images/ads/507f.../006.jpg",
      "order": 3
    }
  ],
  "area": 350,
  "areaUnit": 0,
  "bedrooms": 4,
  "bathrooms": 3,
  "floors": 2,
  "yearBuilt": 2020,
  "furnished": 1,
  "hasGarden": 1,
  "hasPool": 1,
  "hasParking": 1,
  "listingType": 0
}
```

---

## B.5 CV Ad Document

```json
{
  "_id": ObjectId("507f1f77bcf86cd799439044"),
  "_t": "CvAd",
  "title": "Senior Software Engineer - Full Stack",
  "description": "Experienced developer seeking new opportunities",
  "price": {
    "value": 0.00,
    "currency": "USD",
    "displayText": "Negotiable"
  },
  "status": 1,
  "createdAt": ISODate("2024-05-12T10:00:00Z"),
  "updatedAt": ISODate("2024-05-12T10:00:00Z"),
  "userId": "018e9c9c-7c1a-7c1a-7c1a-7c1a7c1a7c1e",
  "slug": "senior-software-engineer-full-stack",
  "category": {
    "categoryIds": [30, 31, 32],
    "categoryPath": "30.31.32"
  },
  "location": {
    "locationIds": [1, 15, 150],
    "fullAddress": "Baghdad, Iraq",
    "coordinates": {
      "latitude": 33.3152,
      "longitude": 44.3661
    }
  },
  "images": [],
  "jobTitle": "Senior Software Engineer",
  "yearsOfExperience": 8,
  "education": [
    {
      "degree": "Bachelor of Computer Science",
      "institution": "University of Baghdad",
      "graduationYear": 2015
    }
  ],
  "skills": ["C#", "ASP.NET Core", "React", "PostgreSQL", "MongoDB"],
  "languages": ["English", "Arabic"],
  "availability": 1,
  "expectedSalary": {
    "value": 5000.00,
    "currency": "USD",
    "displayText": "$5,000/month"
  }
}
```

---

## B.6 Vacancy Ad Document

```json
{
  "_id": ObjectId("507f1f77bcf86cd799439045"),
  "_t": "VacancyAd",
  "title": "Frontend Developer - React",
  "description": "We are looking for an experienced React developer to join our team",
  "price": {
    "value": 0.00,
    "currency": "USD",
    "displayText": "Competitive Salary"
  },
  "status": 1,
  "createdAt": ISODate("2024-05-13T11:00:00Z"),
  "updatedAt": ISODate("2024-05-13T11:00:00Z"),
  "userId": "018e9c9c-7c1a-7c1a-7c1a-7c1a7c1a7c1f",
  "slug": "frontend-developer-react",
  "category": {
    "categoryIds": [30, 31, 33],
    "categoryPath": "30.31.33"
  },
  "location": {
    "locationIds": [1, 15, 150],
    "fullAddress": "Baghdad, Iraq",
    "coordinates": {
      "latitude": 33.3152,
      "longitude": 44.3661
    }
  },
  "images": [],
  "companyName": "Tech Solutions Inc.",
  "jobTitle": "Frontend Developer",
  "employmentType": 0,
  "experienceRequired": 3,
  "educationRequired": "Bachelor's Degree in Computer Science or related field",
  "requiredSkills": ["React", "JavaScript", "TypeScript", "CSS", "HTML"],
  "responsibilities": [
    "Develop user interfaces using React",
    "Collaborate with backend developers",
    "Write clean, maintainable code"
  ],
  "benefits": ["Health insurance", "Flexible hours", "Remote work option"],
  "salaryRange": {
    "min": 2000.00,
    "max": 4000.00,
    "currency": "USD",
    "displayText": "$2,000 - $4,000/month"
  },
  "applicationDeadline": ISODate("2024-06-13T23:59:59Z")
}
```

---

**End of Appendix B**
