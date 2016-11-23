using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitTesting.DotNetCore.Contract;
using UnitTesting.DotNetCore.Database;
using UnitTesting.DotNetCore.Model;

namespace UnitTesting.DotNetCore.Service
{
    public class FileEntityService : IFileEntityService
    {
        private readonly FileDbContext _context;

        public FileEntityService(FileDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FileReference>> GetFilesForAuthorAsync(string authorName)
        {
            return await _context.FileReferences.Where(p => p.Author.Name == authorName).ToListAsync();
        }

        public async Task<User> GetOrCreateUserAsync(string name)
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(p => p.Name == name);

            if (dbUser == null)
            {
                dbUser = new User { Name = name };
                _context.Users.Add(dbUser);
                await _context.SaveChangesAsync();
            }
            return dbUser;
        }

        public async Task<FileReference> InsertFileReferenceAsync(FileReference fileReference)
        {
            if (await _context.FileReferences.AnyAsync(p => p.AuthorId == fileReference.Author.Id && p.Name == fileReference.Name))
            {
                throw new FileReferenceAlreadyExistsException();
            }

            _context.FileReferences.Add(fileReference);
            _context.Entry(fileReference.Author).State = EntityState.Unchanged;
            var saved = await _context.SaveChangesAsync();
            return fileReference;
        }
    }
}