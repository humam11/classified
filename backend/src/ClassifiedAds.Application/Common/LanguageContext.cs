namespace ClassifiedAds.Application.Common;

public static class LanguageContext
{
    private static readonly AsyncLocal<string> _currentLanguage = new();

    public static string Current
    {
        get => _currentLanguage.Value ?? "ar";
        set => _currentLanguage.Value = value;
    }

    public static bool IsArabic => Current == "ar";
    public static bool IsKurdish => Current == "kr";
}
