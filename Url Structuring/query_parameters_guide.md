# Query Parameters Guide

## Common Parameters (All Categories)
```
?is_new=true|false                    // Filter by new/used items
?warranty_months=1-60                 // Filter by warranty duration
?currency=usd|iqd                     // Filter by currency type (USD/IQD)
?min_price=100                        // Minimum price (in selected currency)
?max_price=1000                       // Maximum price (in selected currency)
?sort=price_asc|price_desc|date_desc  // Sort by price (unified across currencies) or date
?page=1                               // Pagination page number
?limit=20                             // Items per page
```

## Price Handling and Display
- All prices are stored in a single `value` field:
  - If `isDollar: false` (default), value is in IQD
  - If `isDollar: true`, value is in USD
- Exchange rates are stored in a separate collection `exchange_rates`:
  ```json
  {
    "_id": "exchange_rate_usd_iqd",
    "rate": 1300,
    "lastUpdate": "2024-03-14T12:00:00Z",
    "isActive": true
  }
  ```
- Display format:
  - USD prices: "X دولار" (e.g., "384.62 دولار")
  - IQD prices: "X,XXX الف دينار عراقي" (e.g., "500,000 الف دينار عراقي")
- Sorting works by converting all prices to IQD using the current exchange rate:
  - USD prices: value × current_exchange_rate
  - IQD prices: value (as is)
- Example sorting with exchange rate 1300 IQD/USD:
  ```
  Ad 1: $2 (2,600 IQD)      // value=2, isDollar=true
  Ad 2: 1,500 IQD           // value=1500, isDollar=false
  Ad 3: $3 (3,900 IQD)      // value=3, isDollar=true
  Ad 4: 2,000 IQD           // value=2000, isDollar=false
  
  Sorted by price_asc: Ad 2 → Ad 1 → Ad 4 → Ad 3
  ```

## Electronics Category Parameters

### Smartphones & Tablets Parameters
```
?storage_capacity=128|256|512|1024    // Storage size in GB
?ram=4|6|8|12|16                      // RAM size in GB
?color=black|white|gold|silver        // Device color
?main_camera=true|false               // Has main camera
?front_camera=true|false              // Has front camera
?min_camera_resolution=48             // Minimum camera MP
?min_battery=4000                     // Minimum battery capacity
?min_screen_size=6.0                  // Minimum screen size
?processor=snapdragon|exynos|mediatek // Processor type
?dual_sim=true|false                  // Dual SIM support
?waterproof=true|false                // Waterproof support
?stylus=true|false                    // Stylus support
```

### Laptops & Computers Parameters
```
?cpu=amd|intel|apple                  // CPU brand/type
?ram_size=8|16|32|64                  // RAM size in GB
?is_ssd=true|false                    // Storage type
?storage_size=256|512|1024|2048       // Storage size in GB
?graphics_card=nvidia|amd|intel       // Graphics card type
?min_usb_ports=2                      // Minimum USB ports
?min_hdmi_ports=1                     // Minimum HDMI ports
?min_screen_size=13.0                 // Minimum screen size
?is_touchscreen=true|false            // Touchscreen support
?resolution=1080p|2k|4k               // Screen resolution
?is_backlit_keyboard=true|false       // Backlit keyboard
?has_webcam=true|false                // Webcam presence
?webcam_resolution=720p|1080p|4k      // Webcam resolution
?has_fingerprint=true|false           // Fingerprint reader
?color=black|silver|gold              // Device color
```

### TVs & Monitors Parameters
```
?min_screen_size=32                   // Minimum screen size
?resolution=hd|fhd|2k|4k|8k           // Screen resolution
?smart_tv=true|false                  // Smart TV capability
?min_refresh_rate=60                  // Minimum refresh rate
?min_hdmi_ports=2                     // Minimum HDMI ports
?min_usb_ports=1                      // Minimum USB ports
```

### Gaming Consoles Parameters
```
?storage_capacity=256|512|1024        // Storage size in GB
?region=usa|europe|japan|global       // Console region
```

## Usage Examples

1. **Search for new smartphones with specific features:**
```
{{apiPrefix}}/{{citySlug}}/electronics/smartphones/samsung/galaxy-s24?is_new=true&storage_capacity=256&ram=8&min_battery=4000&currency=usd&min_price=800&max_price=1200
```

2. **Find gaming laptops with specific specs:**
```
{{apiPrefix}}/{{citySlug}}/electronics/laptops/asus/rog-strix?cpu=amd&ram_size=16&is_ssd=true&storage_size=1024&min_screen_size=15.6&currency=iqd&min_price=2000000&max_price=3000000
```

3. **Search for 4K TVs with specific features:**
```
{{apiPrefix}}/{{citySlug}}/electronics/tvs/samsung/qn90c?min_screen_size=55&resolution=4k&smart_tv=true&min_refresh_rate=120&currency=usd&min_price=1000&max_price=2000
```

4. **Find gaming consoles with filters:**
```
{{apiPrefix}}/{{citySlug}}/electronics/consoles/sony/ps5?storage_capacity=1024&region=global&currency=iqd&min_price=800000&max_price=1000000
```

Note: 
- All query parameters are optional. Multiple parameters can be combined using '&'
- The API will return items matching ALL specified criteria (AND logic)
- Brand and model are part of the URL path instead of query parameters
- Price filters work with the selected currency (USD/IQD) and will automatically convert based on current rates
- Currency conversion uses the current exchange rate from the `exchange_rates` collection 