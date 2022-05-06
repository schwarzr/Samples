using System.IO;
using System.Threading.Tasks;

namespace GlobalAzure.ClientSettings
{
    public interface IClientSettingsService
    {
        Task WriteSettingsAsync(Stream response);
    }
}
