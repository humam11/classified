using ClassifiedAds.Application.DTOs.Ads;
using ClassifiedAds.Application.DTOs.Ads.Electronics;
using ClassifiedAds.Application.DTOs.Ads.Vehicles;
using ClassifiedAds.Application.DTOs.Ads.Vehicles.HeavyEquipment;
using ClassifiedAds.Application.DTOs.Ads.RealEstate;
using ClassifiedAds.Application.DTOs.Ads.Jobs;
using ClassifiedAds.Application.DTOs.Ads.Miscellaneous;

namespace ClassifiedAds.Application.Services;


public static class CategoryDtoMapper
{


    public class CategoryNotSupportedException : Exception
    {
        public string CategorySlug { get; }
        public string Language { get; }

        public CategoryNotSupportedException(string categorySlug, string language)
            : base($"The category '{categorySlug}' is not supported for language '{language}'")
        {
            CategorySlug = categorySlug;
            Language = language;
        }
    }


    private static readonly Dictionary<string, Type> _arabicCategoryMap = new()
    {
        ["الاعمال-والمعدات-التجارية-والصناعية/فرص-تجارية-ومشاريع-وشراكات/امتيازات-تجارية"] = typeof(CreateAdDto),
        ["الاعمال-والمعدات-التجارية-والصناعية/فرص-تجارية-ومشاريع-وشراكات/فرص-شراكة-واستثمار-في-مشاريع"] = typeof(CreateAdDto),
        ["الاعمال-والمعدات-التجارية-والصناعية/فرص-تجارية-ومشاريع-وشراكات/مشاريع-جاهزة-للبيع"] = typeof(CreateAdDto),
        ["الاعمال-والمعدات-التجارية-والصناعية/فرص-تجارية-ومشاريع-وشراكات/وكالات-تجارية"] = typeof(CreateAdDto),
        ["الالكترونيات-والاجهزة-الرقمية/اجهزة-العاب-الكترونية/اجهزة-العاب-منزلية-ومحمولة"] = typeof(CreateVideoConsoleAdDto),
        ["مركبات-ونقل/معدات-ثقيلة-واليات/رافعات"] = typeof(CreateCraneAdDto),

        ["الاعمال-والمعدات-التجارية-والصناعية/معدات-والات-للاعمال/اثاث-ولوازم-مكتبية-وتجارية"] = typeof(CreateAdDto),
                ["الالكترونيات-والاجهزة-الرقمية/اجهزة-العاب-الكترونية/اكسسوارات-قيمنق"] = typeof(CreateElectronicAdDto),
        ["الاعمال-والمعدات-التجارية-والصناعية/معدات-والات-للاعمال/اجهزة-ومعدات-طبية-ومختبرات"] = typeof(CreateAdDto),
        ["الاعمال-والمعدات-التجارية-والصناعية/معدات-والات-للاعمال/تجهيزات-مطاعم-ومحلات-وفنادق"] = typeof(CreateAdDto),
        ["الاعمال-والمعدات-التجارية-والصناعية/معدات-والات-للاعمال/معدات-زراعية-كبيرة"] = typeof(CreateAdDto),
        ["الاعمال-والمعدات-التجارية-والصناعية/معدات-والات-للاعمال/معدات-مهنية-وحرفية-اخرى"] = typeof(CreateAdDto),
        ["الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/روايات-وقصص-وكتب-ادب-وشعر"] = typeof(CreateBookAdDto),
        ["الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/قصص-وكتب-اطفال-مصورة-وتعليمية"] = typeof(CreateBookAdDto),
        ["الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/كتب-تاريخ-وسياسة-وجغرافية"] = typeof(CreateBookAdDto),
        ["الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/كتب-تطوير-ذات-وادارة-اعمال-وتنمية-بشرية"] = typeof(CreateBookAdDto),
        ["الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/كتب-تعليمية-ومناهج-دراسية-و-ملازم"] = typeof(CreateBookAdDto),
        ["الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/كتب-دينية-واسلامية"] = typeof(CreateBookAdDto),
        ["الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/كتب-علمية-وتقنية-وهندسية-وطبية"] = typeof(CreateBookAdDto),
        ["الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/كتب-نادرة-وقديمة-ومخطوطات"] = typeof(CreateAdDto),
        ["الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/مجلات-وصحف-وجرائد"] = typeof(CreateBookAdDto),
    };

    private static readonly Dictionary<string, Type> _kurdishCategoryMap = new()
    {
        ["پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگ-و-ئێکسسواراتی-بارهەڵگر-و-ئامێری-قورس/پارچەی-بزوێنەری-گەورە-بۆ-بارهەڵگر-و-ئامێرەکان"] = typeof(CreateAdDto),
        ["پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگ-و-ئێکسسواراتی-بارهەڵگر-و-ئامێری-قورس/سیستەمی-هایدرۆلیک-بۆ-بارهەڵگر-و-ئامێرەکان"] = typeof(CreateAdDto),
        ["پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگ-و-ئێکسسواراتی-بارهەڵگر-و-ئامێری-قورس/کەرەستەی-تایبەت-و-ئێکسسوارات-بۆ-بارهەڵگرەکان"] = typeof(CreateAdDto),
        ["پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگ-و-ئێکسسواراتی-ماتۆڕسکیل/پارچەی-بزوێنەر-و-گێڕ-بۆ-ماتۆڕسکیل"] = typeof(CreateAdDto),
        ["پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگ-و-ئێکسسواراتی-ماتۆڕسکیل/ئێکسسوارات-و-جوانکاری-ماتۆڕسکیل"] = typeof(CreateAdDto),
        ["پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگی-ئۆتۆمبێل/بزوێنەر-و-پارچەکانی"] = typeof(CreateAdDto),
        ["پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگی-ئۆتۆمبێل/بۆدی-و-هەیکەل-و-پارچەکانی"] = typeof(CreateAdDto),
        ["پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگی-ئۆتۆمبێل/پارچەی-کارەبا-و-ئەلیکترۆنیاتی-ئۆتۆمبێل"] = typeof(CreateAdDto),
        ["پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگی-ئۆتۆمبێل/پارچەی-یەدەگی-جۆراوجۆری-ئۆتۆمبێل"] = typeof(CreateAdDto),
        ["خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/چیرۆک-و-کتێبی-منداڵانی-وێنەدار-و-فێرکاری"] = typeof(CreateBookAdDto),
        ["خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/ڕۆمان-و-چیرۆک-و-کتێبی-ئەدەب-و-شیعر"] = typeof(CreateBookAdDto),
        ["خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/کتێبی-دەگمەن-و-کۆن-و-دەستنووس"] = typeof(CreateAdDto),
        ["خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/کتێبی-زانستی-و-تەکنیکی-و-ئەندازیاری-و-پزیشکی"] = typeof(CreateBookAdDto),
        ["خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/کتێبی-فێرکاری-و-پرۆگرامی-خوێندن-و-مەنهەج"] = typeof(CreateBookAdDto),
        ["خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/کتێبی-گەشەپێدانی-خود-و-بەڕێوەبردنی-کار-و-گەشەپێدانی-مرۆیی"] = typeof(CreateBookAdDto),
        ["خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/کتێبی-مێژوو-و-سیاسەت-و-جوگرافیا"] = typeof(CreateBookAdDto),
        ["خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/کتێبی-ئایینی-و-ئیسلامی"] = typeof(CreateBookAdDto),
        ["خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/گۆڤار-و-ڕۆژنامە"] = typeof(CreateBookAdDto),
        ["خولیا-و-کات-بەسەربردن-و-چالاکی/گەشت-و-سەیران-و-خولیای-دەرەوە/تێلسکۆپ-و-دووربینی-فەلەکی-و-وشکانی"] = typeof(CreateAdDto),
    };

    

    public static Type GetDtoTypeOrThrow(string categorySlug, string language)
    {
        var dtoType = GetDtoType(categorySlug, language);
        if (dtoType == null)
        {
            throw new CategoryNotSupportedException(categorySlug, language);
        }
        return dtoType;
    }

    // Gets the DTO type for a given category slug and language
    public static Type? GetDtoType(string categorySlug, string language)
    {
        var map = language.ToLower() == "ar" ? _arabicCategoryMap : _kurdishCategoryMap;
        return map.TryGetValue(categorySlug, out var type) ? type : null;
    }

    /// Checks if a category slug is supported for the given language
    public static bool IsCategorySupported(string categorySlug, string language)
    {
        return GetDtoType(categorySlug, language) != null;
    }

    // Gets all supported category slugs for a language
    public static IEnumerable<string> GetAllCategorySlugs(string language)
    {
        var map = language.ToLower() == "ar" ? _arabicCategoryMap : _kurdishCategoryMap;
        return map.Keys;
    }

    // Gets the DTO type name for a category slug
    public static string? GetDtoTypeName(string categorySlug, string language)
    {
        var type = GetDtoType(categorySlug, language);
        return type?.Name;
    }

    // Gets the mapper type for a DTO type
    public static Type GetMapperType(Type dtoType)
    {
        if (dtoType == typeof(CreateBookAdDto) || dtoType == typeof(BookAdDto))
            return typeof(Mappers.BookAdDtoMapper);
        if (dtoType == typeof(CreateClothAdDto) || dtoType == typeof(ClothAdDto))
            return typeof(Mappers.ClothAdDtoMapper);
        if (dtoType == typeof(CreateEngineOilAdDto) || dtoType == typeof(EngineOilAdDto))
            return typeof(Mappers.EngineOilAdDtoMapper);
        if (dtoType == typeof(CreateFurnitureAdDto) || dtoType == typeof(FurnitureAdDto))
            return typeof(Mappers.FurnitureAdDtoMapper);
        if (dtoType == typeof(CreatePlantAdDto) || dtoType == typeof(PlantAdDto))
            return typeof(Mappers.PlantAdDtoMapper);
        if (dtoType == typeof(CreateShoeAdDto) || dtoType == typeof(ShoeAdDto))
            return typeof(Mappers.ShoeAdDtoMapper);
        if (dtoType == typeof(CreateTireWheelAdDto) || dtoType == typeof(TireWheelAdDto))
            return typeof(Mappers.TireWheelAdDtoMapper);
        if (dtoType == typeof(CreateVideoGameAdDto) || dtoType == typeof(VideoGameAdDto))
            return typeof(Mappers.VideoGameAdDtoMapper);
        if (dtoType == typeof(CreateComputerAdDto) || dtoType == typeof(ComputerAdDto))
            return typeof(Mappers.ComputerAdDtoMapper);
        if (dtoType == typeof(CreateVideoConsoleAdDto) || dtoType == typeof(VideoConsoleAdDto))
            return typeof(Mappers.VideoConsoleAdDtoMapper);
        if (dtoType == typeof(CreateHandheldDeviceAdDto) || dtoType == typeof(HandheldDeviceAdDto))
            return typeof(Mappers.HandheldDeviceAdDtoMapper);
        if (dtoType == typeof(CreateLaptopAdDto) || dtoType == typeof(LaptopAdDto))
            return typeof(Mappers.LaptopAdDtoMapper);
        if (dtoType == typeof(CreateTvMonitorAdDto) || dtoType == typeof(TvMonitorAdDto))
            return typeof(Mappers.TvMonitorAdDtoMapper);
        if (dtoType == typeof(CreateElectronicAdDto) || dtoType == typeof(ElectronicAdDto))
            return typeof(Mappers.ElectronicAdDtoMapper);
        if (dtoType == typeof(CreateApartmentAdDto) || dtoType == typeof(ApartmentAdDto))
            return typeof(Mappers.ApartmentAdDtoMapper);
        if (dtoType == typeof(CreateHouseAdDto) || dtoType == typeof(HouseAdDto))
            return typeof(Mappers.HouseAdDtoMapper);
        if (dtoType == typeof(CreateConstructionProjectAdDto) || dtoType == typeof(ConstructionProjectAdDto))
            return typeof(Mappers.ConstructionProjectAdDtoMapper);
        if (dtoType == typeof(CreateRealEstateAdDto) || dtoType == typeof(RealEstateAdDto))
            return typeof(Mappers.RealEstateAdDtoMapper);
        if (dtoType == typeof(CreateCarAdDto) || dtoType == typeof(CarAdDto))
            return typeof(Mappers.Vehicles.CarAdDtoMapper);
        if (dtoType == typeof(CreateMotorcycleAdDto) || dtoType == typeof(MotorcycleAdDto))
            return typeof(Mappers.Vehicles.MotorcycleAdDtoMapper);
        if (dtoType == typeof(CreateTruckAdDto) || dtoType == typeof(TruckAdDto))
            return typeof(Mappers.Vehicles.TruckAdDtoMapper);
        if (dtoType == typeof(CreateBoatAdDto) || dtoType == typeof(BoatAdDto))
            return typeof(Mappers.Vehicles.BoatAdDtoMapper);
        if (dtoType == typeof(CreateBulldozerAdDto) || dtoType == typeof(BulldozerAdDto))
            return typeof(Mappers.Vehicles.HeavyEquipment.BulldozerAdDtoMapper);
        if (dtoType == typeof(CreateBusAdDto) || dtoType == typeof(BusAdDto))
            return typeof(Mappers.Vehicles.HeavyEquipment.BusAdDtoMapper);
        if (dtoType == typeof(CreateCraneAdDto) || dtoType == typeof(CraneAdDto))
            return typeof(Mappers.Vehicles.HeavyEquipment.CraneAdDtoMapper);
        if (dtoType == typeof(CreateExcavatorAdDto) || dtoType == typeof(ExcavatorAdDto))
            return typeof(Mappers.Vehicles.HeavyEquipment.ExcavatorAdDtoMapper);
        if (dtoType == typeof(CreateHeavyEquipmentAdDto) || dtoType == typeof(HeavyEquipmentAdDto))
            return typeof(Mappers.Vehicles.HeavyEquipment.HeavyEquipmentAdDtoMapper);
        if (dtoType == typeof(CreateTransportAdDto) || dtoType == typeof(TransportAdDto))
            return typeof(Mappers.Vehicles.TransportAdDtoMapper);
        
        // Default to AdDtoMapper
        return typeof(Mappers.AdDtoMapper);
    }

    // Maps form data to the appropriate DTO type based on category
    public static AdDto MapFormToDto(CreateAdDto baseDto, string categorySlug, string language, Microsoft.AspNetCore.Http.IFormCollection form)
    {
        var dtoType = GetDtoType(categorySlug, language);
        
        // Delegate to appropriate mapper based on DTO type
        if (dtoType == typeof(CreateBookAdDto))
        {
            return Mappers.BookAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateClothAdDto))
        {
            return Mappers.ClothAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateEngineOilAdDto))
        {
            return Mappers.EngineOilAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateFurnitureAdDto))
        {
            return Mappers.FurnitureAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreatePlantAdDto))
        {
            return Mappers.PlantAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateShoeAdDto))
        {
            return Mappers.ShoeAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateTireWheelAdDto))
        {
            return Mappers.TireWheelAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateVideoGameAdDto))
        {
            return Mappers.VideoGameAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateComputerAdDto))
        {
            return Mappers.ComputerAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateVideoConsoleAdDto))
        {
            return Mappers.VideoConsoleAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateHandheldDeviceAdDto))
        {
            return Mappers.HandheldDeviceAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateLaptopAdDto))
        {
            return Mappers.LaptopAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateTvMonitorAdDto))
        {
            return Mappers.TvMonitorAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateElectronicAdDto))
        {
            return Mappers.ElectronicAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateApartmentAdDto))
        {
            return Mappers.ApartmentAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateHouseAdDto))
        {
            return Mappers.HouseAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateConstructionProjectAdDto))
        {
            return Mappers.ConstructionProjectAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateRealEstateAdDto))
        {
            return Mappers.RealEstateAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateCarAdDto))
        {
            return Mappers.Vehicles.CarAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateMotorcycleAdDto))
        {
            return Mappers.Vehicles.MotorcycleAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateTruckAdDto))
        {
            return Mappers.Vehicles.TruckAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateBoatAdDto))
        {
            return Mappers.Vehicles.BoatAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateBulldozerAdDto))
        {
            return Mappers.Vehicles.HeavyEquipment.BulldozerAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateBusAdDto))
        {
            return Mappers.Vehicles.HeavyEquipment.BusAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateCraneAdDto))
        {
            return Mappers.Vehicles.HeavyEquipment.CraneAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateExcavatorAdDto))
        {
            return Mappers.Vehicles.HeavyEquipment.ExcavatorAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateHeavyEquipmentAdDto))
        {
            return Mappers.Vehicles.HeavyEquipment.HeavyEquipmentAdDtoMapper.MapFormToDto(baseDto, form);
        }
        else if (dtoType == typeof(CreateTransportAdDto))
        {
            return Mappers.Vehicles.TransportAdDtoMapper.MapFormToDto(baseDto, form);
        }

        // Default to base DTO for general categories
        return baseDto;
    }

}
