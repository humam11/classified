# PowerShell Script to Apply Specs Migration to All Ad Types
# This script updates DTOs and Mappers to group category-specific fields into a Specs object

$adTypes = @(
    # Jobs
    @{Name="Vacancy"; Path="Jobs"; Fields=@("CompanyName", "CompanyEmail", "CompanyPhone", "EmploymentType", "ExperienceLevel", "EducationLevel", "RequiredSkills", "Benefits", "ApplicationDeadline")},
    
    # Miscellaneous
    @{Name="Book"; Path="Miscellaneous"; Fields=@("BookLanguage", "Pages")},
    @{Name="Cloth"; Path="Miscellaneous"; Fields=@("ClothCondition", "ClothingSize", "Season")},
    @{Name="EngineOil"; Path="Miscellaneous"; Fields=@("Volume", "OilType", "Viscosity")},
    @{Name="Furniture"; Path="Miscellaneous"; Fields=@("FurnitureMaterial", "Length", "Width", "Height")},
    @{Name="Plant"; Path="Miscellaneous"; Fields=@("PlantType", "PlantHeight", "PotIncluded")},
    @{Name="Shoe"; Path="Miscellaneous"; Fields=@("ShoeSize", "ShoeCondition", "ShoeMaterial")},
    @{Name="TireWheel"; Path="Miscellaneous"; Fields=@("TireWidth", "AspectRatio", "RimDiameter", "TireCondition")},
    @{Name="VideoGame"; Path="Miscellaneous"; Fields=@("Platform", "Genre", "Condition")},
    
    # Electronics
    @{Name="Electronic"; Path="Electronics"; Fields=@("IsNew", "WarrantyMonths")},
    @{Name="Computer"; Path="Electronics"; Fields=@("IsNew", "WarrantyMonths", "Cpu", "RamSize", "IsSSD", "StorageCapacity", "GraphicsCard", "ModelId")},
    @{Name="Laptop"; Path="Electronics"; Fields=@("IsNew", "WarrantyMonths", "Cpu", "RamSize", "IsSSD", "StorageCapacity", "GraphicsCard", "UsbPorts", "HdmiPorts", "ScreenSize", "IsTouchscreen", "Resolution", "IsBacklitKeyboard", "HasWebcam", "WebcamResolution", "HasFingerprintReader", "Color", "ModelId")},
    @{Name="HandheldDevice"; Path="Electronics"; Fields=@("IsNew", "WarrantyMonths", "StorageCapacity", "RamSize", "Color", "MainCamera", "FrontCamera", "MainCameraResolution", "FrontCameraResolution", "BatteryCapacity", "ScreenSize", "Processor", "DualSim", "WaterproofSupport", "StylusSupport", "ModelId")},
    @{Name="TvMonitor"; Path="Electronics"; Fields=@("IsNew", "WarrantyMonths", "ScreenSize", "ScreenResolution", "SmartTv", "RefreshRate", "HdmiPorts", "UsbPorts", "ModelId")},
    @{Name="VideoConsole"; Path="Electronics"; Fields=@("IsNew", "WarrantyMonths", "StorageCapacity", "ConsoleRegion", "ModelId")},
    
    # RealEstate
    @{Name="RealEstate"; Path="RealEstate"; Fields=@("Area")},
    @{Name="Apartment"; Path="RealEstate"; Fields=@("Area", "Bedrooms", "Bathrooms", "Elevator", "Furnished", "FloorNumber")},
    @{Name="House"; Path="RealEstate"; Fields=@("Area", "Floors", "Bedrooms", "Bathrooms", "Garage", "Garden")},
    @{Name="ConstructionProject"; Path="RealEstate"; Fields=@("Area", "CompletionStatus")},
    
    # Vehicles
    @{Name="Transport"; Path="Vehicles"; Fields=@("FuelType", "EnginePower", "FuelTankCapacity")},
    @{Name="Boat"; Path="Vehicles"; Fields=@("FuelType", "EnginePower", "FuelTankCapacity", "Length", "Capacity")},
    @{Name="Car"; Path="Vehicles"; Fields=@("FuelType", "EnginePower", "FuelTankCapacity", "DistanceKm", "EngineDescription", "Cylinders", "Transmission", "DriveType", "Color", "ModelId", "SubModelReleaseId")},
    @{Name="Motorcycle"; Path="Vehicles"; Fields=@("FuelType", "EnginePower", "FuelTankCapacity", "MotorcycleDriveType", "GearCount", "ModelId")},
    @{Name="Truck"; Path="Vehicles"; Fields=@("FuelType", "EnginePower", "FuelTankCapacity", "DistanceKm", "LoadCapacity", "AxleCount", "ModelId")},
    
    # HeavyEquipment
    @{Name="HeavyEquipment"; Path="Vehicles/HeavyEquipment"; Fields=@("FuelType", "EnginePower", "FuelTankCapacity", "OperatingMass", "Weight")},
    @{Name="Bulldozer"; Path="Vehicles/HeavyEquipment"; Fields=@("FuelType", "EnginePower", "FuelTankCapacity", "OperatingMass", "Weight", "BladeWidth", "MaxPushingCapacity", "TrackWidth")},
    @{Name="Bus"; Path="Vehicles/HeavyEquipment"; Fields=@("FuelType", "EnginePower", "FuelTankCapacity", "OperatingMass", "Weight", "SeatingCapacity")},
    @{Name="Crane"; Path="Vehicles/HeavyEquipment"; Fields=@("FuelType", "EnginePower", "FuelTankCapacity", "OperatingMass", "Weight", "LiftingCapacity", "MaxLiftingHeight", "BoomLength", "RotationAngle")},
    @{Name="Excavator"; Path="Vehicles/HeavyEquipment"; Fields=@("FuelType", "EnginePower", "FuelTankCapacity", "OperatingMass", "Weight", "BucketCapacity", "DiggingDepth")}
)

Write-Host "Specs Migration Script" -ForegroundColor Cyan
Write-Host "======================" -ForegroundColor Cyan
Write-Host ""
Write-Host "This script will update $($adTypes.Count) ad types to use the Specs pattern."
Write-Host "Press Ctrl+C to cancel, or any key to continue..."
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")

Write-Host ""
Write-Host "Starting migration..." -ForegroundColor Green

foreach ($adType in $adTypes) {
    Write-Host "Processing $($adType.Name)..." -ForegroundColor Yellow
    
    # Note: This is a template script
    # Actual implementation would require:
    # 1. Reading the DTO file
    # 2. Extracting field definitions
    # 3. Creating XxxSpecsDto class
    # 4. Updating GetXxxAdDto to use Specs
    # 5. Reading the Mapper file
    # 6. Updating MapToDto method to populate Specs object
    
    Write-Host "  - DTO: backend/src/ClassifiedAds.Application/DTOs/Ads/$($adType.Path)/$($adType.Name)AdDto.cs"
    Write-Host "  - Mapper: backend/src/ClassifiedAds.Application/Mappers/$($adType.Path)/$($adType.Name)AdDtoMapper.cs"
}

Write-Host ""
Write-Host "Migration template created. Manual updates required for each file." -ForegroundColor Yellow
Write-Host "See SPECS_MIGRATION_SCRIPT.md for the pattern to apply." -ForegroundColor Yellow
