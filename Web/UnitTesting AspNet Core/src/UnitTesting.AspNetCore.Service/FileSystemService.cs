using System.IO;
using System.Threading.Tasks;
using UnitTesting.DotNetCore.Contract;

namespace UnitTesting.DotNetCore.Service
{
    public class FileSystemService : IFileSystemService
    {
        private readonly string _basePath;

        public FileSystemService(string basePath)
        {
            _basePath = basePath;
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