using ClassifiedAds.Application.Common;
using System.Text.RegularExpressions;

namespace ClassifiedAds.Api.Middleware;

public class LanguageMiddleware
{
    private readonly RequestDelegate _next;
    private static readonly Regex LanguageRegex = new(@"^/(?:api/)?(?<lang>ar|kr)/", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public LanguageMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value;
        
        if (!string.IsNullOrEmpty(path))
        {
            var match = LanguageRegex.Match(path);
            if (match.Success)
            {
                var language = match.Groups["lang"].Value.ToLower();
                LanguageContext.Current = language;
            }
        }

        await _next(context);
    }
}

public static class LanguageMiddlewareExtensions
{
    public static IApplicationBuilder UseLanguageMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LanguageMiddleware>();
    }
}
