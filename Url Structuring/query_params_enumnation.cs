using System;
using System.Reflection;
using System.Text;
using System.Web;
using System.Collections.Specialized;

namespace FuelTypeUrlGenerator
{
    class Program
    {
        public enum FuelType
        {
            [LanguageDisplay(Arabic = "بنزين", Kurdish = "بەنزین")]
            Gasoline = 0,

            [LanguageDisplay(Arabic = "ديزل", Kurdish = "دیزەل")]
            Diesel = 1,

            [LanguageDisplay(Arabic = "كهرباء", Kurdish = "کارەبا")]
            Electric = 2,

            [LanguageDisplay(Arabic = "هجين", Kurdish = "هایبرید")]
            Hybrid = 3,

            [LanguageDisplay(Arabic = "غاز", Kurdish = "گاز")]
            Gas = 4,

            [LanguageDisplay(Arabic = "أخرى", Kurdish = "ئەویتر")]
            Other = 5
        }

        [AttributeUsage(AttributeTargets.Field)]
        public class LanguageDisplayAttribute : Attribute
        {
            public string Arabic { get; set; }
            public string Kurdish { get; set; }
        }


        // you don't need this for asp.net core application
        static void Main(string[] args)
        {
            // Enhanced encoding setup
            Console.OutputEncoding = new UTF8Encoding(false);
            Console.InputEncoding = Encoding.UTF8;
            Console.Title = "Fuel Type URL Generator";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Fuel Type URL Generator ===");
                Console.WriteLine("Choose language (ar for Arabic, kr for Kurdish):");
                string lang = Console.ReadLine()?.ToLower().Trim();

                if (lang != "ar" && lang != "kr")
                {
                    Console.WriteLine("Invalid input. Please enter 'ar' or 'kr'.");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine("\nEnter fuel type index (0-5):");
                DisplayFuelTypes(lang);

                if (!int.TryParse(Console.ReadLine(), out int index) || index < 0 || index > 5)
                {
                    Console.WriteLine("Invalid index. Please enter 0-5.");
                    Console.ReadKey();
                    continue;
                }

                // Generate query parameters
                GenerateUrls((FuelType)index, lang);

                Console.WriteLine("\nPress any key to continue or Q to quit...");
                if (Console.ReadKey().Key == ConsoleKey.Q)
                    break;
            }
        }


        // you don't need this for asp.net core application
        static void DisplayFuelTypes(string lang)
        {
            for (int i = 0; i <= 5; i++)
            {
                var fuelType = (FuelType)i;
                var display = GetDisplayValue(fuelType, lang);
                Console.WriteLine($"{i}: {fuelType} ({display})");
            }
        }


        // you don't need this for asp.net core application
        static void GenerateUrls(FuelType fuelType, string lang)
        {
            string paramName = GetParamName(lang);
            string displayValue = GetDisplayValue(fuelType, lang);

            // Display results
            Console.WriteLine("\n=== Results ===");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Language: {(lang == "ar" ? "Arabic" : "Kurdish")}");
            Console.WriteLine($"Fuel Type: {fuelType}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Raw Parameter: {paramName}={displayValue}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Encoded Parameter: {HttpUtility.UrlEncode(paramName)}={HttpUtility.UrlEncode(displayValue)}");

            Console.ForegroundColor = ConsoleColor.Gray;
            string encodedQueryParam = $"{HttpUtility.UrlEncode(paramName)}={HttpUtility.UrlEncode(displayValue)}";
            Console.WriteLine($"Query Parameter Length: {encodedQueryParam.Length} characters");

            Console.ResetColor();
        }

        static string GetDisplayValue(FuelType fuelType, string languageCode)
        {
            var field = fuelType.GetType().GetField(fuelType.ToString());
            var attribute = field?.GetCustomAttribute<LanguageDisplayAttribute>();

            return languageCode switch
            {
                "ar" => attribute?.Arabic,
                "kr" => attribute?.Kurdish
            };
        }

        static string GetParamName(string languageCode)
        {
            return languageCode switch
            {
                "ar" => "نوع-الوقود",
                "kr" => "جۆری-سوتەمەنی"
            };
        }
    }
}

/*
 * SEO TECHNICAL ISSUES ADDRESSED:
 * 
 * 1. ARABIC KEYWORD MATCHING:
 *    - Uses native Arabic terms (بنزين, ديزل, كهرباء, هجين, غاز) that match user search behavior
 *    - Parameter names in Arabic (نوع-الوقود) align with how users naturally search
 *    - Eliminates English-Arabic mixing that reduces search relevance
 * 
 * 2. URL ENCODING COMPATIBILITY:
 *    - HttpUtility.UrlEncode() handles UTF-8 Arabic characters properly
 *    - Prevents URL corruption across different browsers and systems
 *    - Maintains searchable content while ensuring technical compatibility
 * 
 * 3. SEARCH ENGINE INDEXING:
 *    - Arabic parameters are indexed as searchable content by Google
 *    - Complete Arabic context signals stronger topical relevance
 *    - URL structure matches user search intent (دراجات نارية بنزين)
 * 
 * 4. USER EXPERIENCE & SHAREABILITY:
 *    - Clean, readable Arabic URLs when displayed in browsers
 *    - Proper encoding ensures URLs work when shared via social media/messaging
 *    - Maintains semantic meaning for Arabic-speaking users
 *    - Character count tracking helps monitor URL length limits for optimal performance
 * 
 * 5. SEO ANALYSIS FEATURE:
 *    - Provides raw and encoded parameter comparison for SEO optimization
 *    - Displays character length metrics for URL performance monitoring
 *    - Enables A/B testing of different Arabic keyword variations
 *    - Supports multi-language SEO strategy (Arabic/Kurdish) with consistent structure


exactly! For ASP.NET Core, you primarily need:
1. The Enum with Attributes
    public enum FuelType
2. The Attribute Class
    [AttributeUsage(AttributeTargets.Field)]
    public class LanguageDisplayAttribute : Attribute...
3. Helper Methods for ASP.NET Core
    GetDisplayValue
    GetParamName

 examples of early strcutring in following documents:
    - plant_example.json
    - book_example.json
 */