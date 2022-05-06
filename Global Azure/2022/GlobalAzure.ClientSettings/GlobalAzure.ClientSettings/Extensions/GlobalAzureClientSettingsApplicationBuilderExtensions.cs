using GlobalAzure.ClientSettings;

namespace Microsoft.AspNetCore.Builder
{
    public static class GlobalAzureClientSettingsApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseClientSettings(this IApplicationBuilder app, string path)
        {
            app.Map(path, p => p.UseMiddleware<ClientSettingsMiddleware>());

            return app;
        }
        public static IEndpointConventionBuilder MapClientSettings(this IEndpointRouteBuilder endpoint, string path)
        {
            var pipeline = endpoint.CreateApplicationBuilder()
                  .UseMiddleware<ClientSettingsMiddleware>()
                  .Build();

            return endpoint.Map(path, pipeline)
                        .WithDisplayName("Client Settings");
        }
    }
}
