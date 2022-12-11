namespace SampleApplication
{
    public static class EndpointRouteBuilderExtensions
    {
        public static IEndpointConventionBuilder MapPingPong(this IEndpointRouteBuilder endpoints, string route)
        {
            var pipeline = endpoints.CreateApplicationBuilder()
                .UseMiddleware<PingPongMiddleware>()
                .Build();

            return endpoints
                .Map(route, pipeline)
                .WithDisplayName("Ping-pong");
        }
    }
}
