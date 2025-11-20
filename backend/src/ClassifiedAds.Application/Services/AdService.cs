using System.Text.RegularExpressions;
using ClassifiedAds.Application.Common;
using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.Interfaces;
using ClassifiedAds.Application.Mappers;
using ClassifiedAds.Domain.Common.Enums;
using ClassifiedAds.Domain.Common.ValueObjects;
using ClassifiedAds.Domain.Entities.Ads;
using ClassifiedAds.Domain.Entities.Ads.Electronics;
using ClassifiedAds.Domain.Entities.Ads.Miscellaneous;
using ClassifiedAds.Domain.Entities.Ads.RealEstate;
using ClassifiedAds.Domain.Entities.Ads.Vehicles;
using ClassifiedAds.Domain.Entities.Ads.Vehicles.HeavyEquipment;
using ClassifiedAds.Domain.Entities.Ads.JobsServices;
using MongoDB.Driver;

namespace ClassifiedAds.Application.Services;

public class AdService : IAdService
{
    private readonly IMongoCollection<Ad> _adsCollection;
    private readonly ILocationService _locationService;
    private readonly ICategoryService _categoryService;
    private readonly IImageService _imageService;

    public AdService(IMongoDatabase database, ILocationService locationService, ICategoryService categoryService, IImageService imageService)
    {
        _adsCollection = database.GetCollection<Ad>("ads");
        _locationService = locationService;
        _categoryService = categoryService;
        _imageService = imageService;
    }


    public async Task<object?> GetAdByIdAsync(string id)
    {
        var ad = await _adsCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
        if (ad == null) return null;

        // Map entity to DTO using appropriate mapper based on ad type
        // NOTE: Order matters! Derived types must come before base types
        // Each mapper returns its specific GetXxxAdDto type with full MongoDB structure
        object dto = ad switch
        {
            // Electronics (specific types before Electronic base)
            Computer computer => ComputerAdDtoMapper.MapToDto(computer),
            HandheldDevice handheld => HandheldDeviceAdDtoMapper.MapToDto(handheld),
            Laptop laptop => LaptopAdDtoMapper.MapToDto(laptop),
            TvMonitor tv => TvMonitorAdDtoMapper.MapToDto(tv),
            VideoConsole console => VideoConsoleAdDtoMapper.MapToDto(console),
            Electronic electronic => ElectronicAdDtoMapper.MapToDto(electronic),
            
            // Jobs/Services
            Cv cv => Mappers.Jobs.CvAdDtoMapper.MapToDto(cv),
            Service service => Mappers.Jobs.ServiceAdDtoMapper.MapToDto(service),
            Vacancy vacancy => Mappers.Jobs.VacancyAdDtoMapper.MapToDto(vacancy),
            
            // Miscellaneous
            Book book => BookAdDtoMapper.MapToDto(book),
            Cloth cloth => ClothAdDtoMapper.MapToDto(cloth),
            EngineOil oil => EngineOilAdDtoMapper.MapToDto(oil),
            Furniture furniture => FurnitureAdDtoMapper.MapToDto(furniture),
            Plant plant => PlantAdDtoMapper.MapToDto(plant),
            Shoe shoe => ShoeAdDtoMapper.MapToDto(shoe),
            TireWheel tire => TireWheelAdDtoMapper.MapToDto(tire),
            VideoGame game => VideoGameAdDtoMapper.MapToDto(game),
            
            // RealEstate (specific types before RealEstate base)
            Apartment apartment => ApartmentAdDtoMapper.MapToDto(apartment),
            ConstructionProject project => ConstructionProjectAdDtoMapper.MapToDto(project),
            House house => HouseAdDtoMapper.MapToDto(house),
            RealEstate realEstate => RealEstateAdDtoMapper.MapToDto(realEstate),
            
            // Heavy Equipment (specific types before HeavyEquipment base)
            Bulldozer bulldozer => Mappers.Vehicles.HeavyEquipment.BulldozerAdDtoMapper.MapToDto(bulldozer),
            Bus bus => Mappers.Vehicles.HeavyEquipment.BusAdDtoMapper.MapToDto(bus),
            Crane crane => Mappers.Vehicles.HeavyEquipment.CraneAdDtoMapper.MapToDto(crane),
            Excavator excavator => Mappers.Vehicles.HeavyEquipment.ExcavatorAdDtoMapper.MapToDto(excavator),
            HeavyEquipment heavyEquipment => Mappers.Vehicles.HeavyEquipment.HeavyEquipmentAdDtoMapper.MapToDto(heavyEquipment),
            
            // Vehicles (specific types before Transport base)
            Car car => Mappers.Vehicles.CarAdDtoMapper.MapToDto(car),
            Motorcycle motorcycle => Mappers.Vehicles.MotorcycleAdDtoMapper.MapToDto(motorcycle),
            Truck truck => Mappers.Vehicles.TruckAdDtoMapper.MapToDto(truck),
            Boat boat => Mappers.Vehicles.BoatAdDtoMapper.MapToDto(boat),
            Transport transport => Mappers.Vehicles.TransportAdDtoMapper.MapToDto(transport),
            
            _ => AdDtoMapper.MapToDto(ad)
        };

        return dto;
    }


    public async Task<string> CreateAdAsync<TDto>(TDto dto, string categorySlug, List<ImageUpload> images) where TDto : AdDto
    {
        var slug = GenerateSlug(dto.Title);
        var userId = Guid.Empty; // TODO: Get from JWT token
        var language = LanguageContext.Current ?? "ar";

        // Resolve category from PostgreSQL
        var (categoryIds, categoryJoins) = await _categoryService.ResolveCategoryAsync(categorySlug, language);

        // Resolve location from PostgreSQL
        var locationDto = new DTOs.Common.LocationAdDto
        {
            City = dto.City,
            Region = dto.Region,
            Neighborhood = dto.Neighborhood,
            Street = dto.Street
        };
        var (locationIds, fullAddressArabic, fullAddressKurdish) =
            await _locationService.ResolveLocationAsync(locationDto, language);

        // Map DTO to entity using appropriate mapper based on DTO type
        Ad ad;
        if (dto is DTOs.Ads.Miscellaneous.CreateBookAdDto bookDto)
        {
            ad = Mappers.BookAdDtoMapper.MapToEntity(bookDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Miscellaneous.CreateClothAdDto clothDto)
        {
            ad = Mappers.ClothAdDtoMapper.MapToEntity(clothDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Miscellaneous.CreateEngineOilAdDto oilDto)
        {
            ad = Mappers.EngineOilAdDtoMapper.MapToEntity(oilDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Miscellaneous.CreateFurnitureAdDto furnitureDto)
        {
            ad = Mappers.FurnitureAdDtoMapper.MapToEntity(furnitureDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Miscellaneous.CreatePlantAdDto plantDto)
        {
            ad = Mappers.PlantAdDtoMapper.MapToEntity(plantDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Miscellaneous.CreateShoeAdDto shoeDto)
        {
            ad = Mappers.ShoeAdDtoMapper.MapToEntity(shoeDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Miscellaneous.CreateTireWheelAdDto tireDto)
        {
            ad = Mappers.TireWheelAdDtoMapper.MapToEntity(tireDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Miscellaneous.CreateVideoGameAdDto gameDto)
        {
            ad = Mappers.VideoGameAdDtoMapper.MapToEntity(gameDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Electronics.CreateComputerAdDto computerDto)
        {
            ad = Mappers.ComputerAdDtoMapper.MapToEntity(computerDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Electronics.CreateVideoConsoleAdDto consoleDto)
        {
            ad = Mappers.VideoConsoleAdDtoMapper.MapToEntity(consoleDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Electronics.CreateHandheldDeviceAdDto handheldDto)
        {
            ad = Mappers.HandheldDeviceAdDtoMapper.MapToEntity(handheldDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Electronics.CreateLaptopAdDto laptopDto)
        {
            ad = Mappers.LaptopAdDtoMapper.MapToEntity(laptopDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Electronics.CreateTvMonitorAdDto tvDto)
        {
            ad = Mappers.TvMonitorAdDtoMapper.MapToEntity(tvDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Electronics.CreateElectronicAdDto electronicDto)
        {
            ad = Mappers.ElectronicAdDtoMapper.MapToEntity(electronicDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.RealEstate.CreateApartmentAdDto apartmentDto)
        {
            ad = Mappers.ApartmentAdDtoMapper.MapToEntity(apartmentDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.RealEstate.CreateHouseAdDto houseDto)
        {
            ad = Mappers.HouseAdDtoMapper.MapToEntity(houseDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.RealEstate.CreateConstructionProjectAdDto projectDto)
        {
            ad = Mappers.ConstructionProjectAdDtoMapper.MapToEntity(projectDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.RealEstate.CreateRealEstateAdDto realEstateDto)
        {
            ad = Mappers.RealEstateAdDtoMapper.MapToEntity(realEstateDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
                else if (dto is DTOs.Ads.Vehicles.HeavyEquipment.CreateBulldozerAdDto bulldozerDto)
        {
            ad = Mappers.Vehicles.HeavyEquipment.BulldozerAdDtoMapper.MapToEntity(bulldozerDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Vehicles.HeavyEquipment.CreateBusAdDto busDto)
        {
            ad = Mappers.Vehicles.HeavyEquipment.BusAdDtoMapper.MapToEntity(busDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Vehicles.HeavyEquipment.CreateCraneAdDto craneDto)
        {
            ad = Mappers.Vehicles.HeavyEquipment.CraneAdDtoMapper.MapToEntity(craneDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Vehicles.HeavyEquipment.CreateExcavatorAdDto excavatorDto)
        {
            ad = Mappers.Vehicles.HeavyEquipment.ExcavatorAdDtoMapper.MapToEntity(excavatorDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Vehicles.HeavyEquipment.CreateHeavyEquipmentAdDto heavyEquipmentDto)
        {
            ad = Mappers.Vehicles.HeavyEquipment.HeavyEquipmentAdDtoMapper.MapToEntity(heavyEquipmentDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Vehicles.CreateCarAdDto carDto)
        {
            ad = Mappers.Vehicles.CarAdDtoMapper.MapToEntity(carDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Vehicles.CreateMotorcycleAdDto motorcycleDto)
        {
            ad = Mappers.Vehicles.MotorcycleAdDtoMapper.MapToEntity(motorcycleDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Vehicles.CreateTruckAdDto truckDto)
        {
            ad = Mappers.Vehicles.TruckAdDtoMapper.MapToEntity(truckDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Vehicles.CreateBoatAdDto boatDto)
        {
            ad = Mappers.Vehicles.BoatAdDtoMapper.MapToEntity(boatDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Vehicles.CreateTransportAdDto transportDto)
        {
            ad = Mappers.Vehicles.TransportAdDtoMapper.MapToEntity(transportDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Jobs.CreateVacancyAdDto vacancyDto)
        {
            ad = Mappers.Jobs.VacancyAdDtoMapper.MapToEntity(vacancyDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Jobs.CreateCvAdDto cvDto)
        {
            ad = Mappers.Jobs.CvAdDtoMapper.MapToEntity(cvDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Jobs.CreateServiceAdDto serviceDto)
        {
            ad = Mappers.Jobs.ServiceAdDtoMapper.MapToEntity(serviceDto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else
        {
            ad = Mappers.AdDtoMapper.MapToEntity(dto, slug, userId, categoryIds, categoryJoins, locationIds, fullAddressArabic, fullAddressKurdish);
        }

        // Insert into MongoDB
        await _adsCollection.InsertOneAsync(ad);

        // Process and save images
        var processedImages = await _imageService.ProcessAndSaveImagesAsync(images, ad.Id!);

        ad.Images = processedImages.Select(img => new AdImage
        {
            ImageUrl = img.ImageUrl,
            Order = img.Order
        }).ToList();

        ad.ImageCount = (byte)ad.Images.Count;
        ad.UpdatedAt = DateTime.UtcNow;

        await _adsCollection.ReplaceOneAsync(a => a.Id == ad.Id, ad);

        return ad.Id!;
    }

    public async Task<bool> UpdateAdAsync(string id, AdDto dto, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        var existingAd = await _adsCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
        if (existingAd == null) return false;

        var language = LanguageContext.Current ?? "ar";
        
        // Map form data to appropriate DTO type based on existing ad type
        var mappedDto = MapUpdateDtoByAdType(dto, existingAd, form);

        // Update title if provided
        if (!string.IsNullOrEmpty(mappedDto.Title))
        {
            existingAd.Title = mappedDto.Title;
            existingAd.Slug = GenerateSlug(mappedDto.Title);
        }

        // Update description if provided
        if (mappedDto.Description != null)
        {
            existingAd.Description = mappedDto.Description;
        }

        // Update price if provided (validator ensures PriceValue is provided when IsDollar changes)
        if (mappedDto.IsDollar.HasValue || mappedDto.PriceValue.HasValue)
        {
            // Update currency type first
            if (mappedDto.IsDollar.HasValue)
            {
                existingAd.Price.IsDollar = mappedDto.IsDollar.Value;
            }
            
            // Then update value
            if (mappedDto.PriceValue.HasValue)
            {
                existingAd.Price.Value = mappedDto.PriceValue.Value;
            }

            // Recalculate ShowingPrice after price update
            existingAd.Price.ShowingPrice = AdDtoMapper.FormatShowingPrice(
                existingAd.Price.IsDollar,
                existingAd.Price.Value);
        }

        // Update location if any location field is provided
        if (!string.IsNullOrEmpty(mappedDto.City) || !string.IsNullOrEmpty(mappedDto.Region) || 
            !string.IsNullOrEmpty(mappedDto.Neighborhood) || !string.IsNullOrEmpty(mappedDto.Street))
        {
            // Extract existing location parts
            var existingAddressParts = existingAd.LocationAd.FullAddressArabic.Split('،');
            var existingCity = existingAddressParts.Length > 0 ? existingAddressParts[0].Trim() : null;
            var existingRegion = existingAddressParts.Length > 1 ? existingAddressParts[1].Trim() : null;
            var existingNeighborhood = existingAddressParts.Length > 2 ? existingAddressParts[2].Trim() : null;

            // Determine final location values
            // If user provides a location field, use ONLY what they provide (auto-clear children)
            string? finalCity;
            string? finalRegion;
            string? finalNeighborhood;
            string? finalStreet;

            // If City is provided (whether same or different), use only provided values
            if (!string.IsNullOrEmpty(mappedDto.City))
            {
                finalCity = mappedDto.City;
                finalRegion = mappedDto.Region; // null if not provided
                finalNeighborhood = mappedDto.Neighborhood; // null if not provided
                finalStreet = mappedDto.Street; // null if not provided
            }
            // If Region is provided (and City is not), use existing City + provided Region
            else if (!string.IsNullOrEmpty(mappedDto.Region))
            {
                finalCity = existingCity;
                finalRegion = mappedDto.Region;
                finalNeighborhood = mappedDto.Neighborhood; // null if not provided
                finalStreet = mappedDto.Street; // null if not provided
            }
            // If Neighborhood is provided (and City/Region are not), use existing City/Region + provided Neighborhood
            else if (!string.IsNullOrEmpty(mappedDto.Neighborhood))
            {
                finalCity = existingCity;
                finalRegion = existingRegion;
                finalNeighborhood = mappedDto.Neighborhood;
                finalStreet = mappedDto.Street; // null if not provided
            }
            // If only Street is provided, keep all existing location data
            else
            {
                finalCity = existingCity;
                finalRegion = existingRegion;
                finalNeighborhood = existingNeighborhood;
                finalStreet = mappedDto.Street ?? existingAd.LocationAd.Street;
            }

            // Build location DTO
            var locationDto = new DTOs.Common.LocationAdDto
            {
                City = finalCity,
                Region = finalRegion,
                Neighborhood = finalNeighborhood,
                Street = finalStreet
            };

            // Resolve new location from PostgreSQL
            var (locationIds, fullAddressArabic, fullAddressKurdish) =
                await _locationService.ResolveLocationAsync(locationDto, language);

            // Create new LocationAd object (same as CreateAdAsync)
            existingAd.LocationAd = new LocationAd
            {
                LocationIds = locationIds,
                FullAddressArabic = fullAddressArabic,
                FullAddressKurdish = fullAddressKurdish,
                Street = locationDto.Street
            };
        }

        // Update category-specific attributes
        if (mappedDto is DTOs.Ads.Miscellaneous.BookAdDto bookDto)
        {
            Mappers.BookAdDtoMapper.UpdateAttributes(existingAd, bookDto);
        }
        else if (mappedDto is DTOs.Ads.Miscellaneous.ClothAdDto clothDto)
        {
            Mappers.ClothAdDtoMapper.UpdateAttributes(existingAd, clothDto);
        }
        else if (mappedDto is DTOs.Ads.Miscellaneous.EngineOilAdDto oilDto)
        {
            Mappers.EngineOilAdDtoMapper.UpdateAttributes(existingAd, oilDto);
        }
        else if (mappedDto is DTOs.Ads.Miscellaneous.FurnitureAdDto furnitureDto)
        {
            Mappers.FurnitureAdDtoMapper.UpdateAttributes(existingAd, furnitureDto);
        }
        else if (mappedDto is DTOs.Ads.Miscellaneous.PlantAdDto plantDto)
        {
            Mappers.PlantAdDtoMapper.UpdateAttributes(existingAd, plantDto);
        }
        else if (mappedDto is DTOs.Ads.Miscellaneous.ShoeAdDto shoeDto)
        {
            Mappers.ShoeAdDtoMapper.UpdateAttributes(existingAd, shoeDto);
        }
        else if (mappedDto is DTOs.Ads.Miscellaneous.TireWheelAdDto tireDto)
        {
            Mappers.TireWheelAdDtoMapper.UpdateAttributes(existingAd, tireDto);
        }
        else if (mappedDto is DTOs.Ads.Miscellaneous.VideoGameAdDto gameDto)
        {
            Mappers.VideoGameAdDtoMapper.UpdateAttributes(existingAd, gameDto);
        }
        else if (mappedDto is DTOs.Ads.Electronics.ComputerAdDto computerDto)
        {
            Mappers.ComputerAdDtoMapper.UpdateAttributes(existingAd, computerDto);
        }
        else if (mappedDto is DTOs.Ads.Electronics.VideoConsoleAdDto consoleDto)
        {
            Mappers.VideoConsoleAdDtoMapper.UpdateAttributes(existingAd, consoleDto);
        }
        else if (mappedDto is DTOs.Ads.Electronics.HandheldDeviceAdDto handheldDto)
        {
            Mappers.HandheldDeviceAdDtoMapper.UpdateAttributes(existingAd, handheldDto);
        }
        else if (mappedDto is DTOs.Ads.Electronics.LaptopAdDto laptopDto)
        {
            Mappers.LaptopAdDtoMapper.UpdateAttributes(existingAd, laptopDto);
        }
        else if (mappedDto is DTOs.Ads.Electronics.TvMonitorAdDto tvDto)
        {
            Mappers.TvMonitorAdDtoMapper.UpdateAttributes(existingAd, tvDto);
        }
        else if (mappedDto is DTOs.Ads.Electronics.ElectronicAdDto electronicDto)
        {
            Mappers.ElectronicAdDtoMapper.UpdateAttributes(existingAd, electronicDto);
        }
        else if (mappedDto is DTOs.Ads.RealEstate.ApartmentAdDto apartmentDto)
        {
            Mappers.ApartmentAdDtoMapper.UpdateAttributes(existingAd, apartmentDto);
        }
        else if (mappedDto is DTOs.Ads.RealEstate.HouseAdDto houseDto)
        {
            Mappers.HouseAdDtoMapper.UpdateAttributes(existingAd, houseDto);
        }
        else if (mappedDto is DTOs.Ads.RealEstate.ConstructionProjectAdDto projectDto)
        {
            Mappers.ConstructionProjectAdDtoMapper.UpdateAttributes(existingAd, projectDto);
        }
        else if (mappedDto is DTOs.Ads.RealEstate.RealEstateAdDto realEstateDto)
        {
            Mappers.RealEstateAdDtoMapper.UpdateAttributes(existingAd, realEstateDto);
        }
        else if (mappedDto is DTOs.Ads.Vehicles.HeavyEquipment.BulldozerAdDto bulldozerDto)
        {
            Mappers.Vehicles.HeavyEquipment.BulldozerAdDtoMapper.UpdateAttributes(existingAd, bulldozerDto);
        }
        else if (mappedDto is DTOs.Ads.Vehicles.HeavyEquipment.BusAdDto busDto)
        {
            Mappers.Vehicles.HeavyEquipment.BusAdDtoMapper.UpdateAttributes(existingAd, busDto);
        }
        else if (mappedDto is DTOs.Ads.Vehicles.HeavyEquipment.CraneAdDto craneDto)
        {
            Mappers.Vehicles.HeavyEquipment.CraneAdDtoMapper.UpdateAttributes(existingAd, craneDto);
        }
        else if (mappedDto is DTOs.Ads.Vehicles.HeavyEquipment.ExcavatorAdDto excavatorDto)
        {
            Mappers.Vehicles.HeavyEquipment.ExcavatorAdDtoMapper.UpdateAttributes(existingAd, excavatorDto);
        }
        else if (mappedDto is DTOs.Ads.Vehicles.HeavyEquipment.HeavyEquipmentAdDto heavyEquipmentDto)
        {
            Mappers.Vehicles.HeavyEquipment.HeavyEquipmentAdDtoMapper.UpdateAttributes(existingAd, heavyEquipmentDto);
        }
        else if (mappedDto is DTOs.Ads.Vehicles.CarAdDto carDto)
        {
            Mappers.Vehicles.CarAdDtoMapper.UpdateAttributes(existingAd, carDto);
        }
        else if (mappedDto is DTOs.Ads.Vehicles.MotorcycleAdDto motorcycleDto)
        {
            Mappers.Vehicles.MotorcycleAdDtoMapper.UpdateAttributes(existingAd, motorcycleDto);
        }
        else if (mappedDto is DTOs.Ads.Vehicles.TruckAdDto truckDto)
        {
            Mappers.Vehicles.TruckAdDtoMapper.UpdateAttributes(existingAd, truckDto);
        }
        else if (mappedDto is DTOs.Ads.Vehicles.BoatAdDto boatDto)
        {
            Mappers.Vehicles.BoatAdDtoMapper.UpdateAttributes(existingAd, boatDto);
        }
        else if (mappedDto is DTOs.Ads.Vehicles.TransportAdDto transportDto)
        {
            Mappers.Vehicles.TransportAdDtoMapper.UpdateAttributes(existingAd, transportDto);
        }
        else if (mappedDto is DTOs.Ads.Jobs.VacancyAdDto vacancyDto)
        {
            Mappers.Jobs.VacancyAdDtoMapper.UpdateAttributes(existingAd, vacancyDto);
        }
        else if (mappedDto is DTOs.Ads.Jobs.CvAdDto cvDto)
        {
            Mappers.Jobs.CvAdDtoMapper.UpdateAttributes(existingAd, cvDto);
        }
        else if (mappedDto is DTOs.Ads.Jobs.ServiceAdDto serviceDto)
        {
            Mappers.Jobs.ServiceAdDtoMapper.UpdateAttributes(existingAd, serviceDto);
        }

        // Update images if provided
        if (mappedDto.ImageFiles != null && mappedDto.ImageFiles.Count > 0)
        {
            await _imageService.DeleteAdImagesAsync(id);

            var imageUploads = dto.ImageFiles.Select(img => new ImageUpload
            {
                Stream = img.OpenReadStream(),
                FileName = img.FileName,
                Length = img.Length
            }).ToList();

            var processedImages = await _imageService.ProcessAndSaveImagesAsync(imageUploads, id);

            existingAd.Images = processedImages.Select(img => new AdImage
            {
                ImageUrl = img.ImageUrl,
                Order = img.Order
            }).ToList();

            existingAd.ImageCount = (byte)existingAd.Images.Count;
        }

        existingAd.UpdatedAt = DateTime.UtcNow;
        await _adsCollection.ReplaceOneAsync(a => a.Id == id, existingAd);
        return true;
    }

    public async Task<bool> DeleteAdAsync(string id)
    {
        // Delete associated images first
        await _imageService.DeleteAdImagesAsync(id);
        
        // Delete ad from MongoDB
        var result = await _adsCollection.DeleteOneAsync(a => a.Id == id);
        return result.DeletedCount > 0;
    }

    private string GenerateSlug(string title)
    {
        // Simple slug generation - remove special characters and replace spaces with hyphens
        var slug = title.ToLowerInvariant();
        slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");
        slug = Regex.Replace(slug, @"\s+", "-");
        slug = Regex.Replace(slug, @"-+", "-");
        slug = slug.Trim('-');
        
        // Add random suffix to ensure uniqueness
        slug += "-" + Guid.NewGuid().ToString("N").Substring(0, 8);
        
        return slug;
    }

    private AdDto MapUpdateDtoByAdType(AdDto baseDto, Ad existingAd, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        // Delegate to appropriate mapper based on existing ad type
        return existingAd switch
        {
            Book => Mappers.BookAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Cloth => Mappers.ClothAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            EngineOil => Mappers.EngineOilAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Furniture => Mappers.FurnitureAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Plant => Mappers.PlantAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Shoe => Mappers.ShoeAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            TireWheel => Mappers.TireWheelAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            VideoGame => Mappers.VideoGameAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Computer => Mappers.ComputerAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            VideoConsole => Mappers.VideoConsoleAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            HandheldDevice => Mappers.HandheldDeviceAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Laptop => Mappers.LaptopAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            TvMonitor => Mappers.TvMonitorAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Electronic => Mappers.ElectronicAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Apartment => Mappers.ApartmentAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            House => Mappers.HouseAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            ConstructionProject => Mappers.ConstructionProjectAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Domain.Entities.Ads.RealEstate.RealEstate => Mappers.RealEstateAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Bulldozer => Mappers.Vehicles.HeavyEquipment.BulldozerAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Bus => Mappers.Vehicles.HeavyEquipment.BusAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Crane => Mappers.Vehicles.HeavyEquipment.CraneAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Excavator => Mappers.Vehicles.HeavyEquipment.ExcavatorAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            HeavyEquipment => Mappers.Vehicles.HeavyEquipment.HeavyEquipmentAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Car => Mappers.Vehicles.CarAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Motorcycle => Mappers.Vehicles.MotorcycleAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Truck => Mappers.Vehicles.TruckAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Boat => Mappers.Vehicles.BoatAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Transport => Mappers.Vehicles.TransportAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Vacancy => Mappers.Jobs.VacancyAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Cv => Mappers.Jobs.CvAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            Service => Mappers.Jobs.ServiceAdDtoMapper.MapFormToUpdateDto(baseDto, form),
            _ => baseDto
        };
    }
}
