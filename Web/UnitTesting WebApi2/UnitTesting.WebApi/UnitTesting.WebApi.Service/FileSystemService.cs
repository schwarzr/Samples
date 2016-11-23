using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting.WebApi.Contract;

namespace UnitTesting.WebApi.Service
{
    public class FileSystemService : IFileSystemService
    {
        private readonly string _basePath;

        public FileSystemService()
        {
            _basePath = ConfigurationManager.AppSettings["FilesDirectory"];
        }

        public Task<bool> ExistsAsync(string path)
        {
            return Task.FromResult(File.Exists(Path.Combine(_basePath, path)));
        }

        public Task WriteFileAsync(string path, byte[] content)
        {
            var newPath = Path.Combine(_basePath, path);

            Directory.CreateDirectory(new FileInfo(newPath).DirectoryName);

            File.WriteAllBytes(newPath, content);

            return Task.CompletedTask;
        }
    }
}