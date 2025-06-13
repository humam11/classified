{"_id": ObjectId,       // ObjectId
"title": "string",     // string
"description": "string", // string
"price": 65000.00,     // float
"showingPrice": "string", // string
"isActive": true,      // bool
"createdAt": DateTime, // DateTime
"updatedAt": DateTime, // DateTime
"imageCount": 5,       // sbyte
"viewsCount": 235,     // ushort
"isDollar": true,      // bool
"userId": ObjectId,    // ObjectId
"categoryId": ObjectId, // ObjectId
"priority": 2,         // sbyte (1-4)
"slug": "string"       // string


    "location": {
        "cityId": 1,       // short
        "locationIds": [], // short[]
        "fullAddressArabic": "string", // string
        "fullAddressKurdish": "string", // string
        "street": "string", // string
        "hierarchy": {
            "city": {
                "id": 1,   // short
                "nameEnglish": "string", // string
                "nameArabic": "string",  // string
                "nameKurdish": "string"  // string
            },
            // district and neighborhood follow same structure
        }
    }


    "images": [{
        "imageId": "Guid", // Guid
        "imageUrl": "string", // string
        "order": 1        // sbyte (1-5)
    }]

}
