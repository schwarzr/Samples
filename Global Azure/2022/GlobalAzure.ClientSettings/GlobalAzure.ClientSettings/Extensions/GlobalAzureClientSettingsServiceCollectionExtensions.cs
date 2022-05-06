using GlobalAzure.ClientSettings;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class GlobalAzureClientSettingsServiceCollectionExtensions
    {
        public static IClientSettingsBuilder AddClientSettings(this IServiceCollection services)
        {
            return new ClientSettingsBuilder(services);
        }
    }
}
