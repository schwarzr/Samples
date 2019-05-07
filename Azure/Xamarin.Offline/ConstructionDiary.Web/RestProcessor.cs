using System.Linq;
using System.Threading.Tasks;
using NSwag.SwaggerGeneration.AspNetCore;
using NSwag.SwaggerGeneration.Processors;
using NSwag.SwaggerGeneration.Processors.Contexts;

namespace ConstructionDiary.Web
{
    public class RestProcessor : IDocumentProcessor
    {
        public Task ProcessAsync(DocumentProcessorContext context)
        {
            return Task.CompletedTask;
        }
    }
}