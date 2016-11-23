using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting.WebApi.Contract;
using UnitTesting.WebApi.Database;
using UnitTesting.WebApi.Model;

namespace UnitTesting.WebApi.Service
{
    public class FileEntityService : IFileEntityService
    {
        public async Task<IEnumerable<FileReference>> GetFilesForAuthorAsync(string authorName)
        {
            using (var db = new FileDbContext())
            {
                return await db.FileReferences.Where(p => p.Author.Name == authorName).ToListAsync();
            }
        }

        public async Task<User> GetOrCreateUserAsync(string name)
        {
            using (var db = new FileDbContext())
            {
                var dbUser = await db.Users.FirstOrDefaultAsync(p => p.Name == name);

                if (dbUser == null)
                {
                    dbUser = new User { Name = name };
                    db.Users.Add(dbUser);
                    await db.SaveChangesAsync();
                }
                return dbUser;
            }
        }

        public async Task<FileReference> InsertFileReferenceAsync(FileReference fileReference)
        {
            using (var db = new FileDbContext())
            {
                if (await db.FileReferences.AnyAsync(p => p.AuthorId == fileReference.Author.Id && p.Name == fileReference.Name))
                {
                    throw new FileReferenceAlreadyExistsException();
                }

                db.FileReferences.Add(fileReference);
                db.Entry(fileReference.Author).State = EntityState.Unchanged;
                var saved = await db.SaveChangesAsync();
            }
            return fileReference;
        }
    }
}