using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.WebApi.Contract
{
    public interface IFileSystemService
    {
        Task<bool> ExistsAsync(string path);

        Task WriteFileAsync(string path, byte[] content);
    }
}