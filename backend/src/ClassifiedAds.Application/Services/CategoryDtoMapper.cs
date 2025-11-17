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
        ["الاعمال-والمعدات-التجارية-والصناعية/فرص-تجارية-ومشاريع-وشراكات/امتيازات-تجارية"] = typeof(AdDto),
        ["الاعمال-والمعدات-التجارية-والصناعية/فرص-تجارية-ومشاريع-وشراكات/فرص-شراكة-واستثمار-في-مشاريع"] = typeof(AdDto),
        ["الاعمال-والمعدات-التجارية-والصناعية/فرص-تجارية-ومشاريع-وشراكات/مشاريع-جاهزة-للبيع"] = typeof(AdDto),
        ["الاعمال-والمعدات-التجارية-والصناعية/فرص-تجارية-ومشاريع-وشراكات/وكالات-تجارية"] = typeof(AdDto),
        ["الاعمال-والمعدات-التجارية-والصناعية/معدات-والات-للاعمال/اثاث-ولوازم-مكتبية-وتجارية"] = typeof(AdDto),
        ["الاعمال-والمعدات-التجارية-والصناعية/معدات-والات-للاعمال/اجهزة-ومعدات-طبية-ومختبرات"] = typeof(AdDto),
        ["الاعمال-والمعدات-التجارية-والصناعية/معدات-والات-للاعمال/تجهيزات-مطاعم-ومحلات-وفنادق"] = typeof(AdDto),
        ["الاعمال-والمعدات-التجارية-والصناعية/معدات-والات-للاعمال/معدات-زراعية-كبيرة"] = typeof(AdDto),
        ["الاعمال-والمعدات-التجارية-والصناعية/معدات-والات-للاعمال/معدات-مهنية-وحرفية-اخرى"] = typeof(AdDto),
        ["الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/روايات-وقصص-وكتب-ادب-وشعر"] = typeof(BookAdDto),
        ["الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/قصص-وكتب-اطفال-مصورة-وتعليمية"] = typeof(BookAdDto),
        ["الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/كتب-تاريخ-وسياسة-وجغرافية"] = typeof(BookAdDto),
        ["الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/كتب-تطوير-ذات-وادارة-اعمال-وتنمية-بشرية"] = typeof(BookAdDto),
        ["الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/كتب-تعليمية-ومناهج-دراسية-و-ملازم"] = typeof(BookAdDto),
        ["الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/كتب-دينية-واسلامية"] = typeof(BookAdDto),
        ["الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/كتب-علمية-وتقنية-وهندسية-وطبية"] = typeof(BookAdDto),
        ["الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/كتب-نادرة-وقديمة-ومخطوطات"] = typeof(AdDto),
        ["الهوايات-والترفيه-والانشطة/كتب-وقراءة-ومجلات/مجلات-وصحف-وجرائد"] = typeof(BookAdDto),
    };

    private static readonly Dictionary<string, Type> _kurdishCategoryMap = new()
    {
        ["پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگ-و-ئێکسسواراتی-بارهەڵگر-و-ئامێری-قورس/پارچەی-بزوێنەری-گەورە-بۆ-بارهەڵگر-و-ئامێرەکان"] = typeof(AdDto),
        ["پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگ-و-ئێکسسواراتی-بارهەڵگر-و-ئامێری-قورس/سیستەمی-هایدرۆلیک-بۆ-بارهەڵگر-و-ئامێرەکان"] = typeof(AdDto),
        ["پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگ-و-ئێکسسواراتی-بارهەڵگر-و-ئامێری-قورس/کەرەستەی-تایبەت-و-ئێکسسوارات-بۆ-بارهەڵگرەکان"] = typeof(AdDto),
        ["پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگ-و-ئێکسسواراتی-ماتۆڕسکیل/پارچەی-بزوێنەر-و-گێڕ-بۆ-ماتۆڕسکیل"] = typeof(AdDto),
        ["پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگ-و-ئێکسسواراتی-ماتۆڕسکیل/ئێکسسوارات-و-جوانکاری-ماتۆڕسکیل"] = typeof(AdDto),
        ["پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگی-ئۆتۆمبێل/بزوێنەر-و-پارچەکانی"] = typeof(AdDto),
        ["پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگی-ئۆتۆمبێل/بۆدی-و-هەیکەل-و-پارچەکانی"] = typeof(AdDto),
        ["پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگی-ئۆتۆمبێل/پارچەی-کارەبا-و-ئەلیکترۆنیاتی-ئۆتۆمبێل"] = typeof(AdDto),
        ["پارچەی-یەدەگ-و-ئێکسسواراتی-ئۆتۆمبێل/پارچەی-یەدەگی-ئۆتۆمبێل/پارچەی-یەدەگی-جۆراوجۆری-ئۆتۆمبێل"] = typeof(AdDto),
        ["خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/چیرۆک-و-کتێبی-منداڵانی-وێنەدار-و-فێرکاری"] = typeof(BookAdDto),
        ["خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/ڕۆمان-و-چیرۆک-و-کتێبی-ئەدەب-و-شیعر"] = typeof(BookAdDto),
        ["خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/کتێبی-دەگمەن-و-کۆن-و-دەستنووس"] = typeof(AdDto),
        ["خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/کتێبی-زانستی-و-تەکنیکی-و-ئەندازیاری-و-پزیشکی"] = typeof(BookAdDto),
        ["خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/کتێبی-فێرکاری-و-پرۆگرامی-خوێندن-و-مەنهەج"] = typeof(BookAdDto),
        ["خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/کتێبی-گەشەپێدانی-خود-و-بەڕێوەبردنی-کار-و-گەشەپێدانی-مرۆیی"] = typeof(BookAdDto),
        ["خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/کتێبی-مێژوو-و-سیاسەت-و-جوگرافیا"] = typeof(BookAdDto),
        ["خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/کتێبی-ئایینی-و-ئیسلامی"] = typeof(BookAdDto),
        ["خولیا-و-کات-بەسەربردن-و-چالاکی/کتێب-و-خوێندنەوە-و-گۆڤار/گۆڤار-و-ڕۆژنامە"] = typeof(BookAdDto),
        ["خولیا-و-کات-بەسەربردن-و-چالاکی/گەشت-و-سەیران-و-خولیای-دەرەوە/تێلسکۆپ-و-دووربینی-فەلەکی-و-وشکانی"] = typeof(AdDto),
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
        if (dtoType == typeof(BookAdDto))
            return typeof(Mappers.BookAdDtoMapper);
        
        // Default to AdDtoMapper
        return typeof(Mappers.AdDtoMapper);
    }

    // // Maps form data to the appropriate DTO type based on category
    // public static CreateAdDto MapFormToDto(CreateAdDto baseDto, string categorySlug, string language, Microsoft.AspNetCore.Http.IFormCollection form)
    // {
    //     var dtoType = GetDtoType(categorySlug, language);
        
    //     if (dtoType == typeof(BookAdDto))
    //     {
    //         return new CreateBookAdDto
    //         {
    //             Title = baseDto.Title,
    //             Description = baseDto.Description,
    //             IsDollar = baseDto.IsDollar,
    //             PriceValue = baseDto.PriceValue,
    //             City = baseDto.City,
    //             Region = baseDto.Region,
    //             Neighborhood = baseDto.Neighborhood,
    //             Street = baseDto.Street,
    //             ImageFiles = baseDto.ImageFiles,
    //             BookLanguage = form.TryGetValue("BookLanguage", out var bookLang) && 
    //                           Enum.TryParse<Domain.Entities.Ads.Miscellaneous.Enums.BookLanguage>(bookLang, out var lang) 
    //                           ? lang : null,
    //             Pages = form.TryGetValue("Pages", out var pages) && ushort.TryParse(pages, out var p) ? p : null
    //         };
    //     }

    //     return baseDto;
    // }

}
