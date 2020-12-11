using Microsoft.AspNetCore.Builder;

namespace WooliesxChallenge.Api
{
    public static class ErrorHandingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
