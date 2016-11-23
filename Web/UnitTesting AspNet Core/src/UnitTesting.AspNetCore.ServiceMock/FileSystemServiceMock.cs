using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting.DotNetCore.Contract;
using UnitTesting.DotNetCore.ServiceMock;

namespace UnitTesting.DotNetCore.ServiceMock
{
    public class FileSystemServiceMock : IFileSystemService
    {
        private readonly List<string> _paths;

        public FileSystemServiceMock()
        {
            _paths = new List<string>() {
                "TestFile1.jpg",
                "TestFile2.pdf",
                "TestFile4.iso"
            };
        }

        public Task<bool> ExistsAsync(string path)
        {
            return Task.FromResult(_paths.Contains(path));
        }

        public Task WriteFileAsync(string path, byte[] content)
        {
            _paths.Add(path);
            return Task.CompletedTask;
        }
    }
}