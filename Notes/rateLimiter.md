approximated sliding window
https://smudge.ai/blog/ratelimit-algorithms

approximation = (prevWindowCount * prevWindowWeight) + currentWindowCount

you don’t need to manually use timestamps.

The SlidingWindowLimiter in .NET handles that for you.

    options.AddSlidingWindowLimiter("SlidingWindow", limiterOptions =>
    {
        limiterOptions.Window = TimeSpan.FromMinutes(1);
        limiterOptions.PermitLimit = 100;
        limiterOptions.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        limiterOptions.QueueLimit = 10;
        limiterOptions.SegmentsPerWindow = 6;
        limiterOptions.AutoReplenishment = true;
    });

public async Task<RateLimitResult> CheckRateLimit(HttpContext context)
{
    string key;
    int limit;
    
    if (context.User.Identity?.IsAuthenticated == true)
    {
        // Authenticated: 5,000 requests per hour per user
        key = $"user:{context.User.Identity.Name}";
        limit = 5000;
    }
    else
    {
        // Unauthenticated: 60 requests per hour per IP
        key = $"ip:{context.Connection.RemoteIpAddress}";
        limit = 60;
    }
    
    var limiter = new RedisSlidingWindowRateLimiter(_redis, limit, TimeSpan.FromHours(1));
    return await limiter.TryAcquireAsync(key);
}