using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using UnitTesting.WebApi.Database;
using UnitTesting.WebApi.Model;

namespace UnitTesting.WebApi.Controllers
{
    [Authorize]
    public class FileController : ApiController
    {
        [HttpGet]
        public async Task<IEnumerable<FileReference>> GetAsync()
        {
            using (var db = new FileDbContext())
            {
                await db.AddTestDataAsync(User.Identity.Name);
                var files = db.FileReferences.Where(p => p.Author.Name == User.Identity.Name).ToList();

                var basePath = ConfigurationManager.AppSettings["FilesDirectory"];

                var result = new List<FileReference>();

                foreach (var item in files)
                {
                    if (File.Exists(Path.Combine(basePath, item.Path)))
                    {
                        result.Add(item);
                    }
                }
                return result;
            }
        }

        [HttpPost()]
        public async Task<FileReference> InsertAsync([FromUri]string name, [FromUri] FileType fileType)
        {
            using (var db = new FileDbContext())
            {
                var basePath = ConfigurationManager.AppSettings["FilesDirectory"];

                var existing = await db.FileReferences.FirstOrDefaultAsync(p => p.Author.Name == User.Identity.Name && p.Name == name);
                if (existing != null)
                {
                    throw new HttpResponseException(
                        new HttpResponseMessage(System.Net.HttpStatusCode.Conflict)
                        {
                            Content = new StringContent($"A file with name {name} already exists.")
                        });
                }

                var author = db.Users.FirstOrDefault(p => p.Name == User.Identity.Name);
                if (author == null)
                {
                    author = new User { Name = User.Identity.Name };
                }
                var id = Guid.NewGuid();
                var path = Path.Combine(basePath, $"{DateTime.Today:yyyy-MM-dd}\\{id}");
                using (var ms = new MemoryStream())
                {
                    using (var requestStream = await Request.Content.ReadAsStreamAsync())
                    {
                        await requestStream.CopyToAsync(ms);

                        Directory.CreateDirectory(new FileInfo(path).DirectoryName);
                        File.WriteAllBytes(path, ms.ToArray());
                    }
                }
                var fileReference = new FileReference { Id = id, Author = author, Name = name, FileType = fileType, Path = path };

                db.FileReferences.Add(fileReference);
                await db.SaveChangesAsync();

                return fileReference;
            }
        }
    }
}