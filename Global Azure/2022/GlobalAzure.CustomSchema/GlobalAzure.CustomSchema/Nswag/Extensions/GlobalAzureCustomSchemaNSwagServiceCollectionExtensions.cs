using GlobalAzure.CustomSchema.NSwag;
using Microsoft.EntityFrameworkCore;
using NSwag.Generation.AspNetCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class GlobalAzureCustomSchemaNSwagServiceCollectionExtensions
    {
        public static IServiceCollection AddOpenApiDocument<TContext>(this IServiceCollection services, Action<AspNetCoreOpenApiDocumentGeneratorSettings, IServiceProvider> configuration = null)
            where TContext : DbContext
        {
            return services
                    .AddOpenApiDocument((settings, serviceProvider) =>
                    {
                        settings.SchemaProcessors.Add(new DbContextSchemaProcessor<TContext>(serviceProvider));
                        configuration?.Invoke(settings, serviceProvider);
                    });
        }
    }
}
