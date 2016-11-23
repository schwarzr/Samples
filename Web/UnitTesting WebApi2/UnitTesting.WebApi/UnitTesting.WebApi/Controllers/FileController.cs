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
using UnitTesting.WebApi.Contract;
using UnitTesting.WebApi.Database;
using UnitTesting.WebApi.Model;
using UnitTesting.WebApi.Service;

namespace UnitTesting.WebApi.Controllers
{
    [Authorize]
    public class FileController : ApiController
    {
        private readonly IFileEntityService _fileEntityService;
        private readonly IFileSystemService _fileSystemService;

        public FileController()
        {
            _fileEntityService = new FileEntityService();
            _fileSystemService = new FileSystemService();
        }

        public FileController(IFileEntityService fileEntityService, IFileSystemService fileSystemService)
        {
            _fileEntityService = fileEntityService;
            _fileSystemService = fileSystemService;
        }

        #region original GetAsync

        //[HttpGet]
        //public async Task<IEnumerable<FileReference>> GetAsync()
        //{
        //    using (var db = new FileDbContext())
        //    {
        //        await db.AddTestDataAsync(User.Identity.Name);
        //        var files = db.FileReferences.Where(p => p.Author.Name == User.Identity.Name).ToList();

        //        var basePath = ConfigurationManager.AppSettings["FilesDirectory"];

        //        var result = new List<FileReference>();

        //        foreach (var item in files)
        //        {
        //            if (File.Exists(Path.Combine(basePath, item.Path)))
        //            {
        //                result.Add(item);
        //            }
        //        }
        //        return result;
        //    }
        //}

        #endregion original GetAsync

        #region testable GetAsync

        [HttpGet]
        public async Task<IEnumerable<FileReference>> GetAsync()
        {
            var files = await _fileEntityService.GetFilesForAuthorAsync(User.Identity.Name);

            var result = new List<FileReference>();

            foreach (var item in files)
            {
                if (await _fileSystemService.ExistsAsync(item.Path))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        #endregion testable GetAsync

        #region testable InsertAsync

        [HttpPost()]
        public async Task<FileReference> InsertAsync([FromUri]string name, [FromUri] FileType fileType)
        {
            var author = await _fileEntityService.GetOrCreateUserAsync(User.Identity.Name);
            var id = Guid.NewGuid();
            var path = $"{DateTime.Today:yyyy-MM-dd}\\{id}";

            var fileReference = new FileReference { Id = id, Author = author, Name = name, FileType = fileType, Path = path };

            try
            {
                await _fileEntityService.InsertFileReferenceAsync(fileReference);
            }
            catch (FileReferenceAlreadyExistsException)
            {
                throw new HttpResponseException(
                    new HttpResponseMessage(System.Net.HttpStatusCode.Conflict)
                    {
                        Content = new StringContent($"A file with name {name} already exists.")
                    });
            }

            using (var ms = new MemoryStream())
            {
                using (var requestStream = await Request.Content.ReadAsStreamAsync())
                {
                    await requestStream.CopyToAsync(ms);
                    await _fileSystemService.WriteFileAsync(path, ms.ToArray());
                }
            }

            return fileReference;
        }

        #endregion testable InsertAsync

        #region original InsertAsync

        //[HttpPost()]
        //public async Task<FileReference> InsertAsync([FromUri]string name, [FromUri] FileType fileType)
        //{
        //    using (var db = new FileDbContext())
        //    {
        //        var basePath = ConfigurationManager.AppSettings["FilesDirectory"];

        //        var existing = await db.FileReferences.FirstOrDefaultAsync(p => p.Author.Name == User.Identity.Name && p.Name == name);
        //        if (existing != null)
        //        {
        //            throw new HttpResponseException(
        //                new HttpResponseMessage(System.Net.HttpStatusCode.Conflict)
        //                {
        //                    Content = new StringContent($"A file with name {name} already exists.")
        //                });
        //        }

        //        var author = db.Users.FirstOrDefault(p => p.Name == User.Identity.Name);
        //        if (author == null)
        //        {
        //            author = new User { Name = User.Identity.Name };
        //        }
        //        var id = Guid.NewGuid();
        //        var path = Path.Combine(basePath, $"{DateTime.Today:yyyy-MM-dd}\\{id}");
        //        using (var ms = new MemoryStream())
        //        {
        //            using (var requestStream = await Request.Content.ReadAsStreamAsync())
        //            {
        //                await requestStream.CopyToAsync(ms);

        //                Directory.CreateDirectory(new FileInfo(path).DirectoryName);
        //                File.WriteAllBytes(path, ms.ToArray());
        //            }
        //        }
        //        var fileReference = new FileReference { Id = id, Author = author, Name = name, FileType = fileType, Path = path };

        //        db.FileReferences.Add(fileReference);
        //        await db.SaveChangesAsync();

        //        return fileReference;
        //    }
        //}

        #endregion original InsertAsync
    }
}