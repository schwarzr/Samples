using Microsoft.Extensions.DependencyInjection;

namespace GlobalAzure.ClientSettings
{
    public interface IClientSettingsBuilder
    {
        IServiceCollection Services { get; }
    }
}
