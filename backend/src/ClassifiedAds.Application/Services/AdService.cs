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
using MongoDB.Bson;
using MongoDB.Driver;

namespace ClassifiedAds.Application.Services;

public class AdService : IAdService
{
    private readonly IMongoCollection<Ad> _adsCollection;
    private readonly ILocationService _locationService;
    private readonly ICategoryService _categoryService;
    private readonly IImageService _imageService;
    private readonly IBrandModelReleaseService _brandModelReleaseService;

    public AdService(
        IMongoDatabase database, 
        ILocationService locationService, 
        ICategoryService categoryService, 
        IImageService imageService,
        IBrandModelReleaseService brandModelReleaseService)
    {
        _adsCollection = database.GetCollection<Ad>("ads");
        _locationService = locationService;
        _categoryService = categoryService;
        _imageService = imageService;
        _brandModelReleaseService = brandModelReleaseService;
    }

    public async Task<object?> GetAdByIdAsync(string id)
    {
        var ad = await _adsCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
        if (ad == null) return null;

        object dto = ad switch
        {
            Computer computer => ComputerAdDtoMapper.MapToDto(computer),
            HandheldDevice handheld => HandheldDeviceAdDtoMapper.MapToDto(handheld),
            Laptop laptop => LaptopAdDtoMapper.MapToDto(laptop),
            TvMonitor tv => TvMonitorAdDtoMapper.MapToDto(tv),
            Domain.Entities.Ads.Electronics.Console console => ConsoleAdDtoMapper.MapToDto(console),
            Electronic electronic => ElectronicAdDtoMapper.MapToDto(electronic),
            Cv cv => Mappers.Jobs.CvAdDtoMapper.MapToDto(cv),
            Service service => Mappers.Jobs.ServiceAdDtoMapper.MapToDto(service),
            Vacancy vacancy => Mappers.Jobs.VacancyAdDtoMapper.MapToDto(vacancy),
            Book book => BookAdDtoMapper.MapToDto(book),
            Cloth cloth => ClothAdDtoMapper.MapToDto(cloth),
            EngineOil oil => EngineOilAdDtoMapper.MapToDto(oil),
            Furniture furniture => FurnitureAdDtoMapper.MapToDto(furniture),
            Plant plant => PlantAdDtoMapper.MapToDto(plant),
            Shoe shoe => ShoeAdDtoMapper.MapToDto(shoe),
            TireWheel tire => TireWheelAdDtoMapper.MapToDto(tire),
            VideoGame game => VideoGameAdDtoMapper.MapToDto(game),
            Apartment apartment => ApartmentAdDtoMapper.MapToDto(apartment),
            ConstructionProject project => ConstructionProjectAdDtoMapper.MapToDto(project),
            House house => HouseAdDtoMapper.MapToDto(house),
            RealEstate realEstate => RealEstateAdDtoMapper.MapToDto(realEstate),
            Bulldozer bulldozer => Mappers.Vehicles.HeavyEquipment.BulldozerAdDtoMapper.MapToDto(bulldozer),
            Bus bus => Mappers.Vehicles.HeavyEquipment.BusAdDtoMapper.MapToDto(bus),
            Crane crane => Mappers.Vehicles.HeavyEquipment.CraneAdDtoMapper.MapToDto(crane),
            Excavator excavator => Mappers.Vehicles.HeavyEquipment.ExcavatorAdDtoMapper.MapToDto(excavator),
            HeavyEquipment heavyEquipment => Mappers.Vehicles.HeavyEquipment.HeavyEquipmentAdDtoMapper.MapToDto(heavyEquipment),
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
        // Generate ObjectId first so we can use it for the slug
        var objectId = ObjectId.GenerateNewId().ToString();
        var slug = GenerateSlug(dto.Title, objectId);
        var userId = Guid.Empty; // TODO: Get from JWT token
        var language = LanguageContext.Current ?? "ar";

        // Resolve category slugs from PostgreSQL (both Arabic and Kurdish)
        var (categoriesSlugsArabic, categoriesSlugsKurdish) = await _categoryService.ResolveCategorySlugsAsync(categorySlug, language);

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

        // Handle Car with brand/model/release resolution (async mapper)
        if (dto is DTOs.Ads.Vehicles.CreateCarAdDto carDto)
        {
            ad = await Mappers.Vehicles.CarAdDtoMapper.MapToEntityAsync(
                carDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish,
                locationIds, fullAddressArabic, fullAddressKurdish,
                categorySlug, language, _brandModelReleaseService);
        }
        // Handle Truck with brand resolution (async mapper)
        else if (dto is DTOs.Ads.Vehicles.CreateTruckAdDto truckDto)
        {
            ad = await Mappers.Vehicles.TruckAdDtoMapper.MapToEntityAsync(
                truckDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish,
                locationIds, fullAddressArabic, fullAddressKurdish,
                categorySlug, language, _brandModelReleaseService);
        }
        else if (dto is DTOs.Ads.Miscellaneous.CreateBookAdDto bookDto)
        {
            ad = Mappers.BookAdDtoMapper.MapToEntity(bookDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Miscellaneous.CreateClothAdDto clothDto)
        {
            ad = Mappers.ClothAdDtoMapper.MapToEntity(clothDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Miscellaneous.CreateEngineOilAdDto oilDto)
        {
            ad = Mappers.EngineOilAdDtoMapper.MapToEntity(oilDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Miscellaneous.CreateFurnitureAdDto furnitureDto)
        {
            ad = Mappers.FurnitureAdDtoMapper.MapToEntity(furnitureDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Miscellaneous.CreatePlantAdDto plantDto)
        {
            ad = Mappers.PlantAdDtoMapper.MapToEntity(plantDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Miscellaneous.CreateShoeAdDto shoeDto)
        {
            ad = Mappers.ShoeAdDtoMapper.MapToEntity(shoeDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Miscellaneous.CreateTireWheelAdDto tireDto)
        {
            ad = Mappers.TireWheelAdDtoMapper.MapToEntity(tireDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        // Handle VideoGame with brand/model resolution (async mapper)
        else if (dto is DTOs.Ads.Miscellaneous.CreateVideoGameAdDto gameDto)
        {
            ad = await Mappers.VideoGameAdDtoMapper.MapToEntityAsync(
                gameDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish,
                locationIds, fullAddressArabic, fullAddressKurdish,
                categorySlug, language, _brandModelReleaseService);
        }
        else if (dto is DTOs.Ads.Electronics.CreateComputerAdDto computerDto)
        {
            ad = Mappers.ComputerAdDtoMapper.MapToEntity(computerDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        // Handle Console with brand/model resolution (async mapper)
        else if (dto is DTOs.Ads.Electronics.CreateConsoleAdDto consoleDto)
        {
            ad = await Mappers.ConsoleAdDtoMapper.MapToEntityAsync(
                consoleDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish,
                locationIds, fullAddressArabic, fullAddressKurdish,
                categorySlug, language, _brandModelReleaseService);
        }
        // Handle HandheldDevice with brand/model resolution (async mapper)
        else if (dto is DTOs.Ads.Electronics.CreateHandheldDeviceAdDto handheldDto)
        {
            ad = await Mappers.HandheldDeviceAdDtoMapper.MapToEntityAsync(
                handheldDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish,
                locationIds, fullAddressArabic, fullAddressKurdish,
                categorySlug, language, _brandModelReleaseService);
        }
        // Handle Laptop with brand resolution (async mapper)
        else if (dto is DTOs.Ads.Electronics.CreateLaptopAdDto laptopDto)
        {
            ad = await Mappers.LaptopAdDtoMapper.MapToEntityAsync(
                laptopDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish,
                locationIds, fullAddressArabic, fullAddressKurdish,
                categorySlug, language, _brandModelReleaseService);
        }
        // Handle TvMonitor with brand resolution (async mapper)
        else if (dto is DTOs.Ads.Electronics.CreateTvMonitorAdDto tvDto)
        {
            ad = await Mappers.TvMonitorAdDtoMapper.MapToEntityAsync(
                tvDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish,
                locationIds, fullAddressArabic, fullAddressKurdish,
                categorySlug, language, _brandModelReleaseService);
        }
        else if (dto is DTOs.Ads.Electronics.CreateElectronicAdDto electronicDto)
        {
            ad = Mappers.ElectronicAdDtoMapper.MapToEntity(electronicDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.RealEstate.CreateApartmentAdDto apartmentDto)
        {
            ad = Mappers.ApartmentAdDtoMapper.MapToEntity(apartmentDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.RealEstate.CreateHouseAdDto houseDto)
        {
            ad = Mappers.HouseAdDtoMapper.MapToEntity(houseDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.RealEstate.CreateConstructionProjectAdDto projectDto)
        {
            ad = Mappers.ConstructionProjectAdDtoMapper.MapToEntity(projectDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.RealEstate.CreateRealEstateAdDto realEstateDto)
        {
            ad = Mappers.RealEstateAdDtoMapper.MapToEntity(realEstateDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Vehicles.HeavyEquipment.CreateBulldozerAdDto bulldozerDto)
        {
            ad = Mappers.Vehicles.HeavyEquipment.BulldozerAdDtoMapper.MapToEntity(bulldozerDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Vehicles.HeavyEquipment.CreateBusAdDto busDto)
        {
            ad = Mappers.Vehicles.HeavyEquipment.BusAdDtoMapper.MapToEntity(busDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Vehicles.HeavyEquipment.CreateCraneAdDto craneDto)
        {
            ad = Mappers.Vehicles.HeavyEquipment.CraneAdDtoMapper.MapToEntity(craneDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Vehicles.HeavyEquipment.CreateExcavatorAdDto excavatorDto)
        {
            ad = Mappers.Vehicles.HeavyEquipment.ExcavatorAdDtoMapper.MapToEntity(excavatorDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Vehicles.HeavyEquipment.CreateHeavyEquipmentAdDto heavyEquipmentDto)
        {
            ad = Mappers.Vehicles.HeavyEquipment.HeavyEquipmentAdDtoMapper.MapToEntity(heavyEquipmentDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        // Handle Motorcycle with brand resolution (async mapper)
        else if (dto is DTOs.Ads.Vehicles.CreateMotorcycleAdDto motorcycleDto)
        {
            ad = await Mappers.Vehicles.MotorcycleAdDtoMapper.MapToEntityAsync(
                motorcycleDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish,
                locationIds, fullAddressArabic, fullAddressKurdish,
                categorySlug, language, _brandModelReleaseService);
        }
        else if (dto is DTOs.Ads.Vehicles.CreateBoatAdDto boatDto)
        {
            ad = Mappers.Vehicles.BoatAdDtoMapper.MapToEntity(boatDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Vehicles.CreateTransportAdDto transportDto)
        {
            ad = Mappers.Vehicles.TransportAdDtoMapper.MapToEntity(transportDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Jobs.CreateVacancyAdDto vacancyDto)
        {
            ad = Mappers.Jobs.VacancyAdDtoMapper.MapToEntity(vacancyDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Jobs.CreateCvAdDto cvDto)
        {
            ad = Mappers.Jobs.CvAdDtoMapper.MapToEntity(cvDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else if (dto is DTOs.Ads.Jobs.CreateServiceAdDto serviceDto)
        {
            ad = Mappers.Jobs.ServiceAdDtoMapper.MapToEntity(serviceDto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }
        else
        {
            ad = Mappers.AdDtoMapper.MapToEntity(dto, slug, userId, categoriesSlugsArabic, categoriesSlugsKurdish, locationIds, fullAddressArabic, fullAddressKurdish);
        }

        // Assign the pre-generated ObjectId
        ad.Id = objectId;

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
        
        var mappedDto = MapUpdateDtoByAdType(dto, existingAd, form);

        if (!string.IsNullOrEmpty(mappedDto.Title))
        {
            existingAd.Title = mappedDto.Title;
            existingAd.Slug = GenerateSlug(mappedDto.Title, existingAd.Id!);
        }

        if (mappedDto.Description != null)
        {
            existingAd.Description = mappedDto.Description;
        }

        if (mappedDto.IsDollar.HasValue || mappedDto.PriceValue.HasValue)
        {
            if (mappedDto.IsDollar.HasValue)
            {
                existingAd.Price.IsDollar = mappedDto.IsDollar.Value;
            }
            
            if (mappedDto.PriceValue.HasValue)
            {
                existingAd.Price.Value = mappedDto.PriceValue.Value;
            }

            existingAd.Price.ShowingPrice = AdDtoMapper.FormatShowingPrice(
                existingAd.Price.IsDollar,
                existingAd.Price.Value);
        }

        if (!string.IsNullOrEmpty(mappedDto.City) || !string.IsNullOrEmpty(mappedDto.Region) || 
            !string.IsNullOrEmpty(mappedDto.Neighborhood) || !string.IsNullOrEmpty(mappedDto.Street))
        {
            var existingAddressParts = existingAd.LocationAd.FullAddressArabic.Split('،');
            var existingCity = existingAddressParts.Length > 0 ? existingAddressParts[0].Trim() : null;
            var existingRegion = existingAddressParts.Length > 1 ? existingAddressParts[1].Trim() : null;
            var existingNeighborhood = existingAddressParts.Length > 2 ? existingAddressParts[2].Trim() : null;

            string? finalCity, finalRegion, finalNeighborhood, finalStreet;

            if (!string.IsNullOrEmpty(mappedDto.City))
            {
                finalCity = mappedDto.City;
                finalRegion = mappedDto.Region;
                finalNeighborhood = mappedDto.Neighborhood;
                finalStreet = mappedDto.Street;
            }
            else if (!string.IsNullOrEmpty(mappedDto.Region))
            {
                finalCity = existingCity;
                finalRegion = mappedDto.Region;
                finalNeighborhood = mappedDto.Neighborhood;
                finalStreet = mappedDto.Street;
            }
            else if (!string.IsNullOrEmpty(mappedDto.Neighborhood))
            {
                finalCity = existingCity;
                finalRegion = existingRegion;
                finalNeighborhood = mappedDto.Neighborhood;
                finalStreet = mappedDto.Street;
            }
            else
            {
                finalCity = existingCity;
                finalRegion = existingRegion;
                finalNeighborhood = existingNeighborhood;
                finalStreet = mappedDto.Street ?? existingAd.LocationAd.Street;
            }

            var locationDto = new DTOs.Common.LocationAdDto
            {
                City = finalCity,
                Region = finalRegion,
                Neighborhood = finalNeighborhood,
                Street = finalStreet
            };

            var (locationIds, fullAddressArabic, fullAddressKurdish) =
                await _locationService.ResolveLocationAsync(locationDto, language);

            existingAd.LocationAd = new LocationAd
            {
                LocationIds = locationIds,
                FullAddressArabic = fullAddressArabic,
                FullAddressKurdish = fullAddressKurdish,
                Street = locationDto.Street
            };
        }

        // Update category-specific attributes
        UpdateAttributesByAdType(existingAd, mappedDto);

        // Handle brand/model/release updates for entities that support it
        await UpdateBrandModelReleaseAsync(existingAd, mappedDto, language);

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
        await _imageService.DeleteAdImagesAsync(id);
        var result = await _adsCollection.DeleteOneAsync(a => a.Id == id);
        return result.DeletedCount > 0;
    }

    private string GenerateSlug(string title, string objectId)
    {
        // Get unique ID prefix (last 6 characters of ObjectId)
        var idPrefix = objectId.Length >= 6 ? objectId.Substring(objectId.Length - 6) : objectId;
        
        // Sanitize title: lowercase, keep Arabic/Kurdish/English letters, numbers, spaces, hyphens
        var titleSlug = title.ToLowerInvariant();
        // Keep: a-z, 0-9, Arabic (0600-06FF), Kurdish/Arabic extended (0750-077F, FB50-FDFF, FE70-FEFF), spaces, hyphens
        titleSlug = Regex.Replace(titleSlug, @"[^\u0600-\u06FF\u0750-\u077F\uFB50-\uFDFF\uFE70-\uFEFFa-z0-9\s-]", "");
        titleSlug = Regex.Replace(titleSlug, @"\s+", "-");
        titleSlug = Regex.Replace(titleSlug, @"-+", "-");
        titleSlug = titleSlug.Trim('-');
        
        // Take first 20 characters, but truncate at last complete word boundary
        if (titleSlug.Length > 20)
        {
            titleSlug = titleSlug.Substring(0, 20);
            var lastHyphen = titleSlug.LastIndexOf('-');
            if (lastHyphen > 0 && lastHyphen < titleSlug.Length - 1)
            {
                // Cut at last hyphen to avoid partial words
                titleSlug = titleSlug.Substring(0, lastHyphen);
            }
            titleSlug = titleSlug.TrimEnd('-');
        }
        
        // Format: {id}-{title} - ID prefix first for better RTL display
        // Example: 0bf94d-رافعة-برجية
        return $"{idPrefix}-{titleSlug}";
    }


    private void UpdateAttributesByAdType(Ad existingAd, AdDto mappedDto)
    {
        if (mappedDto is DTOs.Ads.Miscellaneous.BookAdDto bookDto)
            Mappers.BookAdDtoMapper.UpdateAttributes(existingAd, bookDto);
        else if (mappedDto is DTOs.Ads.Miscellaneous.ClothAdDto clothDto)
            Mappers.ClothAdDtoMapper.UpdateAttributes(existingAd, clothDto);
        else if (mappedDto is DTOs.Ads.Miscellaneous.EngineOilAdDto oilDto)
            Mappers.EngineOilAdDtoMapper.UpdateAttributes(existingAd, oilDto);
        else if (mappedDto is DTOs.Ads.Miscellaneous.FurnitureAdDto furnitureDto)
            Mappers.FurnitureAdDtoMapper.UpdateAttributes(existingAd, furnitureDto);
        else if (mappedDto is DTOs.Ads.Miscellaneous.PlantAdDto plantDto)
            Mappers.PlantAdDtoMapper.UpdateAttributes(existingAd, plantDto);
        else if (mappedDto is DTOs.Ads.Miscellaneous.ShoeAdDto shoeDto)
            Mappers.ShoeAdDtoMapper.UpdateAttributes(existingAd, shoeDto);
        else if (mappedDto is DTOs.Ads.Miscellaneous.TireWheelAdDto tireDto)
            Mappers.TireWheelAdDtoMapper.UpdateAttributes(existingAd, tireDto);
        else if (mappedDto is DTOs.Ads.Miscellaneous.VideoGameAdDto gameDto)
            Mappers.VideoGameAdDtoMapper.UpdateAttributes(existingAd, gameDto);
        else if (mappedDto is DTOs.Ads.Electronics.ComputerAdDto computerDto)
            Mappers.ComputerAdDtoMapper.UpdateAttributes(existingAd, computerDto);
        else if (mappedDto is DTOs.Ads.Electronics.ConsoleAdDto consoleDto)
            Mappers.ConsoleAdDtoMapper.UpdateAttributes(existingAd, consoleDto);
        else if (mappedDto is DTOs.Ads.Electronics.HandheldDeviceAdDto handheldDto)
            Mappers.HandheldDeviceAdDtoMapper.UpdateAttributes(existingAd, handheldDto);
        else if (mappedDto is DTOs.Ads.Electronics.LaptopAdDto laptopDto)
            Mappers.LaptopAdDtoMapper.UpdateAttributes(existingAd, laptopDto);
        else if (mappedDto is DTOs.Ads.Electronics.TvMonitorAdDto tvDto)
            Mappers.TvMonitorAdDtoMapper.UpdateAttributes(existingAd, tvDto);
        else if (mappedDto is DTOs.Ads.Electronics.ElectronicAdDto electronicDto)
            Mappers.ElectronicAdDtoMapper.UpdateAttributes(existingAd, electronicDto);
        else if (mappedDto is DTOs.Ads.RealEstate.ApartmentAdDto apartmentDto)
            Mappers.ApartmentAdDtoMapper.UpdateAttributes(existingAd, apartmentDto);
        else if (mappedDto is DTOs.Ads.RealEstate.HouseAdDto houseDto)
            Mappers.HouseAdDtoMapper.UpdateAttributes(existingAd, houseDto);
        else if (mappedDto is DTOs.Ads.RealEstate.ConstructionProjectAdDto projectDto)
            Mappers.ConstructionProjectAdDtoMapper.UpdateAttributes(existingAd, projectDto);
        else if (mappedDto is DTOs.Ads.RealEstate.RealEstateAdDto realEstateDto)
            Mappers.RealEstateAdDtoMapper.UpdateAttributes(existingAd, realEstateDto);
        else if (mappedDto is DTOs.Ads.Vehicles.HeavyEquipment.BulldozerAdDto bulldozerDto)
            Mappers.Vehicles.HeavyEquipment.BulldozerAdDtoMapper.UpdateAttributes(existingAd, bulldozerDto);
        else if (mappedDto is DTOs.Ads.Vehicles.HeavyEquipment.BusAdDto busDto)
            Mappers.Vehicles.HeavyEquipment.BusAdDtoMapper.UpdateAttributes(existingAd, busDto);
        else if (mappedDto is DTOs.Ads.Vehicles.HeavyEquipment.CraneAdDto craneDto)
            Mappers.Vehicles.HeavyEquipment.CraneAdDtoMapper.UpdateAttributes(existingAd, craneDto);
        else if (mappedDto is DTOs.Ads.Vehicles.HeavyEquipment.ExcavatorAdDto excavatorDto)
            Mappers.Vehicles.HeavyEquipment.ExcavatorAdDtoMapper.UpdateAttributes(existingAd, excavatorDto);
        else if (mappedDto is DTOs.Ads.Vehicles.HeavyEquipment.HeavyEquipmentAdDto heavyEquipmentDto)
            Mappers.Vehicles.HeavyEquipment.HeavyEquipmentAdDtoMapper.UpdateAttributes(existingAd, heavyEquipmentDto);
        else if (mappedDto is DTOs.Ads.Vehicles.CarAdDto carDto)
            Mappers.Vehicles.CarAdDtoMapper.UpdateAttributes(existingAd, carDto);
        else if (mappedDto is DTOs.Ads.Vehicles.MotorcycleAdDto motorcycleDto)
            Mappers.Vehicles.MotorcycleAdDtoMapper.UpdateAttributes(existingAd, motorcycleDto);
        else if (mappedDto is DTOs.Ads.Vehicles.TruckAdDto truckDto)
            Mappers.Vehicles.TruckAdDtoMapper.UpdateAttributes(existingAd, truckDto);
        else if (mappedDto is DTOs.Ads.Vehicles.BoatAdDto boatDto)
            Mappers.Vehicles.BoatAdDtoMapper.UpdateAttributes(existingAd, boatDto);
        else if (mappedDto is DTOs.Ads.Vehicles.TransportAdDto transportDto)
            Mappers.Vehicles.TransportAdDtoMapper.UpdateAttributes(existingAd, transportDto);
        else if (mappedDto is DTOs.Ads.Jobs.VacancyAdDto vacancyDto)
            Mappers.Jobs.VacancyAdDtoMapper.UpdateAttributes(existingAd, vacancyDto);
        else if (mappedDto is DTOs.Ads.Jobs.CvAdDto cvDto)
            Mappers.Jobs.CvAdDtoMapper.UpdateAttributes(existingAd, cvDto);
        else if (mappedDto is DTOs.Ads.Jobs.ServiceAdDto serviceDto)
            Mappers.Jobs.ServiceAdDtoMapper.UpdateAttributes(existingAd, serviceDto);
    }

    private AdDto MapUpdateDtoByAdType(AdDto baseDto, Ad existingAd, Microsoft.AspNetCore.Http.IFormCollection form)
    {
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
            Domain.Entities.Ads.Electronics.Console => Mappers.ConsoleAdDtoMapper.MapFormToUpdateDto(baseDto, form),
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

    private async Task UpdateBrandModelReleaseAsync(Ad existingAd, AdDto mappedDto, string language)
    {
        // Get category slug from existing ad for brand/model resolution
        var categorySlug = language.ToLower() == "ar" 
            ? existingAd.Category.CategoriesSlugsArabic.LastOrDefault() ?? ""
            : existingAd.Category.CategoriesSlugsKurdish.LastOrDefault() ?? "";

        // Handle Car with brand/model/release
        if (existingAd is Car car && mappedDto is DTOs.Ads.Vehicles.CarAdDto carDto)
        {
            if (!string.IsNullOrEmpty(carDto.BrandName) && !string.IsNullOrEmpty(carDto.ModelName))
            {
                var (modelId, modelsSlugs) = await _brandModelReleaseService.ResolveBrandModelAsync(
                    categorySlug, language, carDto.BrandName, carDto.ModelName);
                car.ModelsSlugs = modelsSlugs;

                // Also update release year if provided
                if (!string.IsNullOrEmpty(carDto.ReleaseYear))
                {
                    var (_, releaseYear) = await _brandModelReleaseService.ResolveReleaseAsync(modelId, carDto.ReleaseYear);
                    car.ReleaseYear = releaseYear;
                }
            }
            else if (!string.IsNullOrEmpty(carDto.ReleaseYear) && car.ModelsSlugs?.Count > 0)
            {
                // Only release year changed, need to get modelId from existing slugs
                // For now, we'll skip this case - user should provide brand+model when changing release
            }
        }
        // Handle Truck with brand only
        else if (existingAd is Truck truck && mappedDto is DTOs.Ads.Vehicles.TruckAdDto truckDto)
        {
            if (!string.IsNullOrEmpty(truckDto.BrandName))
            {
                var (_, modelsSlugs) = await _brandModelReleaseService.ResolveBrandAsync(
                    categorySlug, language, truckDto.BrandName);
                truck.ModelsSlugs = modelsSlugs;
            }
        }
        // Handle Motorcycle with brand only
        else if (existingAd is Motorcycle motorcycle && mappedDto is DTOs.Ads.Vehicles.MotorcycleAdDto motorcycleDto)
        {
            if (!string.IsNullOrEmpty(motorcycleDto.BrandName))
            {
                var (_, modelsSlugs) = await _brandModelReleaseService.ResolveBrandAsync(
                    categorySlug, language, motorcycleDto.BrandName);
                motorcycle.ModelsSlugs = modelsSlugs;
            }
        }
        // Handle VideoGame with brand + model
        else if (existingAd is VideoGame game && mappedDto is DTOs.Ads.Miscellaneous.VideoGameAdDto gameDto)
        {
            if (!string.IsNullOrEmpty(gameDto.BrandName) && !string.IsNullOrEmpty(gameDto.ModelName))
            {
                var (_, modelsSlugs) = await _brandModelReleaseService.ResolveBrandModelAsync(
                    categorySlug, language, gameDto.BrandName, gameDto.ModelName);
                game.ModelsSlugs = modelsSlugs;
            }
        }
        // Handle Console with brand + model
        else if (existingAd is Domain.Entities.Ads.Electronics.Console console && mappedDto is DTOs.Ads.Electronics.ConsoleAdDto consoleDto)
        {
            if (!string.IsNullOrEmpty(consoleDto.BrandName) && !string.IsNullOrEmpty(consoleDto.ModelName))
            {
                var (_, modelsSlugs) = await _brandModelReleaseService.ResolveBrandModelAsync(
                    categorySlug, language, consoleDto.BrandName, consoleDto.ModelName);
                console.ModelsSlugs = modelsSlugs;
            }
        }
        // Handle HandheldDevice with brand + model
        else if (existingAd is HandheldDevice handheld && mappedDto is DTOs.Ads.Electronics.HandheldDeviceAdDto handheldDto)
        {
            if (!string.IsNullOrEmpty(handheldDto.BrandName) && !string.IsNullOrEmpty(handheldDto.ModelName))
            {
                var (_, modelsSlugs) = await _brandModelReleaseService.ResolveBrandModelAsync(
                    categorySlug, language, handheldDto.BrandName, handheldDto.ModelName);
                handheld.ModelsSlugs = modelsSlugs;
            }
        }
        // Handle Laptop with brand only
        else if (existingAd is Laptop laptop && mappedDto is DTOs.Ads.Electronics.LaptopAdDto laptopDto)
        {
            if (!string.IsNullOrEmpty(laptopDto.BrandName))
            {
                var (_, modelsSlugs) = await _brandModelReleaseService.ResolveBrandAsync(
                    categorySlug, language, laptopDto.BrandName);
                laptop.ModelsSlugs = modelsSlugs;
            }
        }
        // Handle TvMonitor with brand only
        else if (existingAd is TvMonitor tv && mappedDto is DTOs.Ads.Electronics.TvMonitorAdDto tvDto)
        {
            if (!string.IsNullOrEmpty(tvDto.BrandName))
            {
                var (_, modelsSlugs) = await _brandModelReleaseService.ResolveBrandAsync(
                    categorySlug, language, tvDto.BrandName);
                tv.ModelsSlugs = modelsSlugs;
            }
        }
    }

    public async Task<object?> GetAdBySlugAsync(string slug)
    {
        // Clean the incoming slug from invisible Unicode characters
        var cleanSlug = RemoveInvisibleCharacters(slug);
        
        // First try exact match with cleaned slug
        var ad = await _adsCollection.Find(a => a.Slug == cleanSlug).FirstOrDefaultAsync();
        
        // If not found, try matching with original slug (in case DB has invisible chars)
        if (ad == null)
        {
            ad = await _adsCollection.Find(a => a.Slug == slug).FirstOrDefaultAsync();
        }
        
        // If still not found, search all ads and compare cleaned slugs
        if (ad == null)
        {
            // Use regex to find ads where slug contains the clean slug pattern
            // This handles cases where DB slug has invisible characters
            var allAds = await _adsCollection.Find(_ => true).ToListAsync();
            ad = allAds.FirstOrDefault(a => RemoveInvisibleCharacters(a.Slug ?? "") == cleanSlug);
        }
        
        if (ad == null) return null;
        return MapAdToDto(ad);
    }

    // Remove invisible Unicode characters from a string
    private static string RemoveInvisibleCharacters(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        // Remove common invisible Unicode characters
        var invisibleChars = new char[]
        {
            '\u200E', // Left-to-Right Mark (LRM)
            '\u200F', // Right-to-Left Mark (RLM)
            '\u202A', // Left-to-Right Embedding
            '\u202B', // Right-to-Left Embedding
            '\u202C', // Pop Directional Formatting
            '\u202D', // Left-to-Right Override
            '\u202E', // Right-to-Left Override
            '\u2066', // Left-to-Right Isolate
            '\u2067', // Right-to-Left Isolate
            '\u2068', // First Strong Isolate
            '\u2069', // Pop Directional Isolate
            '\u200B', // Zero Width Space
            '\u200C', // Zero Width Non-Joiner
            '\u200D', // Zero Width Joiner
            '\uFEFF'  // Zero Width No-Break Space (BOM)
        };

        foreach (var invisibleChar in invisibleChars)
        {
            input = input.Replace(invisibleChar.ToString(), "");
        }

        return input;
    }

    public async Task<List<object>> SearchAdsByCategoryAsync(string categorySlug, string language)
    {
        // MongoDB field names are camelCase
        var slugField = language.ToLower() == "ar" 
            ? "category.categoriesSlugsArabic" 
            : "category.categoriesSlugsKurdish";

        var filter = Builders<Ad>.Filter.And(
            Builders<Ad>.Filter.AnyEq(slugField, categorySlug),
            Builders<Ad>.Filter.Eq(a => a.Status, Status.Active)
        );

        var ads = await _adsCollection
            .Find(filter)
            .SortByDescending(a => a.CreatedAt)
            .ToListAsync();

        return ads.Select(MapAdToDto).ToList();
    }

    public async Task<List<object>> SearchAdsByBrandModelAsync(string categorySlug, string brandModelSlug, string language)
    {
        // MongoDB field names are camelCase
        var slugField = language.ToLower() == "ar" 
            ? "category.categoriesSlugsArabic" 
            : "category.categoriesSlugsKurdish";

        var filter = Builders<Ad>.Filter.And(
            Builders<Ad>.Filter.AnyEq(slugField, categorySlug),
            Builders<Ad>.Filter.AnyEq("modelsSlugs", brandModelSlug),
            Builders<Ad>.Filter.Eq(a => a.Status, Status.Active)
        );

        var ads = await _adsCollection
            .Find(filter)
            .SortByDescending(a => a.CreatedAt)
            .ToListAsync();

        return ads.Select(MapAdToDto).ToList();
    }

    public async Task<List<object>> SearchAdsByReleaseYearAsync(string categorySlug, string brandModelSlug, string releaseYear, string language)
    {
        // MongoDB field names are camelCase
        var slugField = language.ToLower() == "ar" 
            ? "category.categoriesSlugsArabic" 
            : "category.categoriesSlugsKurdish";

        var filter = Builders<Ad>.Filter.And(
            Builders<Ad>.Filter.AnyEq(slugField, categorySlug),
            Builders<Ad>.Filter.AnyEq("modelsSlugs", brandModelSlug),
            Builders<Ad>.Filter.Eq("releaseYear", releaseYear),
            Builders<Ad>.Filter.Eq(a => a.Status, Status.Active)
        );

        var ads = await _adsCollection
            .Find(filter)
            .SortByDescending(a => a.CreatedAt)
            .ToListAsync();

        return ads.Select(MapAdToDto).ToList();
    }

    public CanonicalUrlInfo GetCanonicalUrlInfo(object adDto, string language)
    {
        // Extract common properties using reflection or pattern matching
        var adType = adDto.GetType();
        var bindingFlags = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.DeclaredOnly;
        
        // Try declared only first, then fall back to all public
        var slugProp = adType.GetProperty("Slug", bindingFlags) ?? adType.GetProperty("Slug");
        var categoryProp = adType.GetProperty("Category", bindingFlags) ?? adType.GetProperty("Category");
        var specsProp = adType.GetProperty("Specs", bindingFlags) ?? adType.GetProperty("Specs");

        var slug = slugProp?.GetValue(adDto)?.ToString() ?? "";
        var category = categoryProp?.GetValue(adDto);
        object? specs = null;
        
        // Handle ambiguous Specs property by trying to get it safely
        try
        {
            specs = specsProp?.GetValue(adDto);
        }
        catch (System.Reflection.AmbiguousMatchException)
        {
            // If ambiguous, try to get the most derived Specs property
            var allSpecsProps = adType.GetProperties().Where(p => p.Name == "Specs").ToList();
            if (allSpecsProps.Count > 0)
            {
                // Get the one declared in the most derived type
                specsProp = allSpecsProps.OrderByDescending(p => GetTypeDepth(p.DeclaringType)).FirstOrDefault();
                specs = specsProp?.GetValue(adDto);
            }
        }

        // Get category slug
        string categorySlug = "";
        if (category != null)
        {
            var catType = category.GetType();
            var slugsField = language.ToLower() == "ar" 
                ? catType.GetProperty("CategoriesSlugsArabic") 
                : catType.GetProperty("CategoriesSlugsKurdish");
            var slugsList = slugsField?.GetValue(category) as List<string>;
            categorySlug = slugsList?.LastOrDefault() ?? "";
        }

        // ============================================================================
        // CANONICAL URL STRUCTURE CONFIGURATION
        // ============================================================================
        // 
        // URL LEVELS:
        // -----------
        // 1. CategoryOnly: /categories/{category}/ads/{slug}
        //    - Used for: RealEstate, Jobs, Services, Furniture, etc.
        //
        // 2. BrandOnly (1 level): /categories/{category}/models/{brand}/ads/{slug}
        //    - Used for: Truck, Motorcycle, Laptop, TvMonitor
        //    - modelsSlugs array: ["brand"] (first element only)
        //
        // 3. BrandModel (2 levels): /categories/{category}/models/{brand}/{model}/ads/{slug}
        //    - Used for: VideoGame, HandheldDevice, Console
        //    - modelsSlugs array: ["brand", "brand/model"] (last element = brand/model)
        //
        // 4. ReleaseYear (2 levels + year): /categories/{category}/models/{brand}/{model}/releases/{year}/ads/{slug}
        //    - Used for: Car
        //    - modelsSlugs array: ["brand", "brand/model"] + releaseYear field
        //
        // TO CHANGE URL STRUCTURE:
        // ------------------------
        // - To make VideoGame use BrandOnly (1 level): Move "VideoGame" from BrandModel section to BrandOnly section
        // - To make Console use BrandOnly (1 level): Move "Console" from BrandModel section to BrandOnly section
        // - To add new type with brand: Add type name to appropriate section below
        // ============================================================================

        var typeName = adType.Name;
        
        // ----------------------------------------------------------------------------
        // RELEASE YEAR LEVEL (Brand + Model + Year): Car only
        // URL: /models/{brand}/{model}/releases/{year}/ads/{slug}
        // modelsSlugs: ["toyota", "toyota/corolla"] → uses "toyota/corolla"
        // ----------------------------------------------------------------------------
        if (typeName.Contains("Car"))
        {
            string? brandModelSlug = null;
            string? releaseYear = null;
            
            if (specs != null)
            {
                var specsType = specs.GetType();
                var modelsSlugsField = specsType.GetProperty("ModelsSlugs");
                var releaseYearField = specsType.GetProperty("ReleaseYear");
                
                var modelsList = modelsSlugsField?.GetValue(specs) as List<string>;
                // Use last element which contains "brand/model" format
                brandModelSlug = modelsList?.LastOrDefault();
                releaseYear = releaseYearField?.GetValue(specs)?.ToString();
            }

            return new CanonicalUrlInfo
            {
                AdSlug = slug,
                CategorySlug = categorySlug,
                BrandModelSlug = brandModelSlug,
                ReleaseYear = releaseYear,
                Level = CanonicalUrlLevel.ReleaseYear
            };
        }
        
        // ----------------------------------------------------------------------------
        // BRAND + MODEL LEVEL (2 levels): VideoGame, HandheldDevice, Console
        // URL: /models/{brand}/{model}/ads/{slug}
        // modelsSlugs: ["sony", "sony/playstation-5"] → uses "sony/playstation-5"
        // 
        // TO CHANGE TO BRAND ONLY: Move type name to BrandOnly section below
        // ----------------------------------------------------------------------------
        if (typeName.Contains("VideoGame") ||      // To make brand-only: move to BrandOnly section
            typeName.Contains("HandheldDevice") || // To make brand-only: move to BrandOnly section
            typeName.Contains("Console"))          // To make brand-only: move to BrandOnly section
        {
            string? brandModelSlug = null;
            
            if (specs != null)
            {
                var specsType = specs.GetType();
                var modelsSlugsField = specsType.GetProperty("ModelsSlugs");
                var modelsList = modelsSlugsField?.GetValue(specs) as List<string>;
                // Use last element which contains "brand/model" format
                brandModelSlug = modelsList?.LastOrDefault();
            }

            return new CanonicalUrlInfo
            {
                AdSlug = slug,
                CategorySlug = categorySlug,
                BrandModelSlug = brandModelSlug,
                Level = CanonicalUrlLevel.BrandModel
            };
        }

        // ----------------------------------------------------------------------------
        // BRAND ONLY LEVEL (1 level): Truck, Motorcycle, Laptop, TvMonitor
        // URL: /models/{brand}/ads/{slug}
        // modelsSlugs: ["lenovo", "lenovo/ideapad-gaming-3"] → uses "lenovo" (first element)
        // 
        // TO ADD NEW TYPE: Add typeName.Contains("NewType") to the condition
        // ----------------------------------------------------------------------------
        if (typeName.Contains("Truck") ||      // Brand only: /models/mercedes/ads/{slug}
            typeName.Contains("Motorcycle") || // Brand only: /models/honda/ads/{slug}
            typeName.Contains("Laptop") ||     // Brand only: /models/lenovo/ads/{slug}
            typeName.Contains("TvMonitor"))    // Brand only: /models/samsung/ads/{slug}
        {
            string? brandSlug = null;
            
            if (specs != null)
            {
                var specsType = specs.GetType();
                var modelsSlugsField = specsType.GetProperty("ModelsSlugs");
                var modelsList = modelsSlugsField?.GetValue(specs) as List<string>;
                // Use FIRST element which contains brand only
                brandSlug = modelsList?.FirstOrDefault();
            }

            return new CanonicalUrlInfo
            {
                AdSlug = slug,
                CategorySlug = categorySlug,
                BrandModelSlug = brandSlug,
                Level = CanonicalUrlLevel.BrandModel // Still uses BrandModel level but with single slug
            };
        }

        // ----------------------------------------------------------------------------
        // CATEGORY ONLY LEVEL (no models): All other ad types
        // URL: /categories/{category}/ads/{slug}
        // Used for: RealEstate, Jobs, Services, Furniture, Books, etc.
        // ----------------------------------------------------------------------------
        return new CanonicalUrlInfo
        {
            AdSlug = slug,
            CategorySlug = categorySlug,
            Level = CanonicalUrlLevel.CategoryOnly
        };
    }

    private static int GetTypeDepth(Type? type)
    {
        int depth = 0;
        while (type != null)
        {
            depth++;
            type = type.BaseType;
        }
        return depth;
    }

    private object MapAdToDto(Ad ad)
    {
        return ad switch
        {
            Computer computer => ComputerAdDtoMapper.MapToDto(computer),
            HandheldDevice handheld => HandheldDeviceAdDtoMapper.MapToDto(handheld),
            Laptop laptop => LaptopAdDtoMapper.MapToDto(laptop),
            TvMonitor tv => TvMonitorAdDtoMapper.MapToDto(tv),
            Domain.Entities.Ads.Electronics.Console console => ConsoleAdDtoMapper.MapToDto(console),
            Electronic electronic => ElectronicAdDtoMapper.MapToDto(electronic),
            Cv cv => Mappers.Jobs.CvAdDtoMapper.MapToDto(cv),
            Service service => Mappers.Jobs.ServiceAdDtoMapper.MapToDto(service),
            Vacancy vacancy => Mappers.Jobs.VacancyAdDtoMapper.MapToDto(vacancy),
            Book book => BookAdDtoMapper.MapToDto(book),
            Cloth cloth => ClothAdDtoMapper.MapToDto(cloth),
            EngineOil oil => EngineOilAdDtoMapper.MapToDto(oil),
            Furniture furniture => FurnitureAdDtoMapper.MapToDto(furniture),
            Plant plant => PlantAdDtoMapper.MapToDto(plant),
            Shoe shoe => ShoeAdDtoMapper.MapToDto(shoe),
            TireWheel tire => TireWheelAdDtoMapper.MapToDto(tire),
            VideoGame game => VideoGameAdDtoMapper.MapToDto(game),
            Apartment apartment => ApartmentAdDtoMapper.MapToDto(apartment),
            ConstructionProject project => ConstructionProjectAdDtoMapper.MapToDto(project),
            House house => HouseAdDtoMapper.MapToDto(house),
            RealEstate realEstate => RealEstateAdDtoMapper.MapToDto(realEstate),
            Bulldozer bulldozer => Mappers.Vehicles.HeavyEquipment.BulldozerAdDtoMapper.MapToDto(bulldozer),
            Bus bus => Mappers.Vehicles.HeavyEquipment.BusAdDtoMapper.MapToDto(bus),
            Crane crane => Mappers.Vehicles.HeavyEquipment.CraneAdDtoMapper.MapToDto(crane),
            Excavator excavator => Mappers.Vehicles.HeavyEquipment.ExcavatorAdDtoMapper.MapToDto(excavator),
            HeavyEquipment heavyEquipment => Mappers.Vehicles.HeavyEquipment.HeavyEquipmentAdDtoMapper.MapToDto(heavyEquipment),
            Car car => Mappers.Vehicles.CarAdDtoMapper.MapToDto(car),
            Motorcycle motorcycle => Mappers.Vehicles.MotorcycleAdDtoMapper.MapToDto(motorcycle),
            Truck truck => Mappers.Vehicles.TruckAdDtoMapper.MapToDto(truck),
            Boat boat => Mappers.Vehicles.BoatAdDtoMapper.MapToDto(boat),
            Transport transport => Mappers.Vehicles.TransportAdDtoMapper.MapToDto(transport),
            _ => AdDtoMapper.MapToDto(ad)
        };
    }
}
