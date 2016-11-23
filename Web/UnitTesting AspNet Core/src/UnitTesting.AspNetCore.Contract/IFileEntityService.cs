using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting.DotNetCore.Model;

namespace UnitTesting.DotNetCore.Contract
{
    public interface IFileEntityService
    {
        Task<IEnumerable<FileReference>> GetFilesForAuthorAsync(string authorName);

        Task<User> GetOrCreateUserAsync(string name);

        Task<FileReference> InsertFileReferenceAsync(FileReference fileReference);
    }
}