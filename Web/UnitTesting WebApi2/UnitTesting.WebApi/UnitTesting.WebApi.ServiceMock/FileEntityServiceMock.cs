using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting.WebApi.Contract;
using UnitTesting.WebApi.Model;

namespace UnitTesting.WebApi.ServiceMock
{
    public class FileEntityServiceMock : IFileEntityService
    {
        private readonly List<FileReference> _fileReferences;

        private readonly List<User> _user;

        public FileEntityServiceMock()
        {
            _user = new List<User>() {
                new User { Id = 1, Name = "UnitTestUser" },
                new User { Id = 2, Name = "OtherUser" }
            };

            _fileReferences = new List<FileReference>() {
           new FileReference { Id = Guid.NewGuid(),AuthorId = 1, Author = _user[0], Name = "Testfile1", Path = "TestFile1.jpg", FileType = FileType.Image },
           new FileReference { Id = Guid.NewGuid(),AuthorId = 1, Author = _user[0], Name = "Testfile2", Path = "TestFile2.pdf", FileType = FileType.Document },
           new FileReference { Id = Guid.NewGuid(),AuthorId = 1, Author = _user[0], Name = "Testfile3", Path = "TestFile3.bin", FileType = FileType.Undefined },
           new FileReference { Id = Guid.NewGuid(),AuthorId = 1, Author = _user[0], Name = "Testfile4", Path = "TestFile4.iso", FileType = FileType.Undefined },
           new FileReference { Id = Guid.NewGuid(),AuthorId = 2, Author = _user[1], Name = "Testfile5", Path = "TestFile4.iso", FileType = FileType.Undefined }
        };
        }

        public Task<IEnumerable<FileReference>> GetFilesForAuthorAsync(string authorName)
        {
            return Task.FromResult<IEnumerable<FileReference>>(_fileReferences.Where(p => p.Author.Name == authorName).ToList());
        }

        public Task<User> GetOrCreateUserAsync(string name)
        {
            var user = _user.FirstOrDefault(p => p.Name == name);
            if (user == null)
            {
                user = new User { Id = _user.Max(p => p.Id) + 1, Name = name };
                _user.Add(user);
            }
            return Task.FromResult(user);
        }

        public Task<FileReference> InsertFileReferenceAsync(FileReference fileReference)
        {
            if (_fileReferences.Any(p => p.AuthorId == fileReference.Author.Id && p.Name == fileReference.Name))
            {
                throw new FileReferenceAlreadyExistsException();
            }

            _fileReferences.Add(fileReference);
            fileReference.AuthorId = fileReference.Author.Id;
            return Task.FromResult(fileReference);
        }
    }
}