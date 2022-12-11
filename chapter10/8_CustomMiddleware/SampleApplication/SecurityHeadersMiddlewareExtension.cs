namespace SampleApplication
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseSecurityHeaders(
            this IApplicationBuilder app)
        {
            return app.UseMiddleware<SecurityHeadersMiddleware>();
        }

    }
}
