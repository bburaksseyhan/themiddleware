using Microsoft.AspNetCore.Builder;
using RequestTracer.Core.Middlewares;

namespace RequestTracer.Core
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
