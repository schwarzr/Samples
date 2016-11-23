using System;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UnitTesting.DotNetCore.Contract;
using UnitTesting.DotNetCore.Controllers;
using UnitTesting.DotNetCore.Database;
using UnitTesting.DotNetCore.Model;
using UnitTesting.DotNetCore.Service;
using UnitTesting.DotNetCore.ServiceMock;
using Xunit;

namespace ControllerTest
{
    public class FileControllerTest
    {
        private static readonly IServiceProvider _readOnlyServiceProvider;

        static FileControllerTest()
        {
            _readOnlyServiceProvider = GetServiceProvider();
        }

        [Fact]
        public async Task TestGetAsync()
        {
            using (var scope = _readOnlyServiceProvider.CreateScope())
            {
                var controller = scope.ServiceProvider.GetService<FileController>();
                controller.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext()
                    {
                        User = GetUnitTestPrincipal()
                    }
                };

                var files = await controller.GetAsync();
                Assert.Equal(3, files.Count());
                Assert.NotNull(files.SingleOrDefault(p => p.Name == "Testfile1"));
                Assert.NotNull(files.SingleOrDefault(p => p.Name == "Testfile2"));
                Assert.NotNull(files.SingleOrDefault(p => p.Name == "Testfile4"));
            }
        }

        [Fact]
        public async Task TestInsertAlreadyExistsAsync()
        {
            var provider = GetServiceProvider();

            using (var scope = provider.CreateScope())
            {
                var controller = scope.ServiceProvider.GetService<FileController>();
                controller.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext()
                    {
                        User = GetUnitTestPrincipal()
                    }
                };

                var files = await controller.InsertAsync("Testfile1", UnitTesting.DotNetCore.Model.FileType.Document);
                Assert.IsType<ObjectResult>(files);
                Assert.Equal(409, ((ObjectResult)files).StatusCode);
            }
        }

        [Fact]
        public async Task TestInsertAsync()
        {
            var provider = GetServiceProvider();

            using (var scope = provider.CreateScope())
            {
                var controller = scope.ServiceProvider.GetService<FileController>();
                controller.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext()
                    {
                        User = GetUnitTestPrincipal()
                    }
                };

                var files = await controller.InsertAsync("Testfile10", UnitTesting.DotNetCore.Model.FileType.Document);
                Assert.IsType<JsonResult>(files);
                Assert.IsType<FileReference>(((JsonResult)files).Value);
                var fileRef = ((JsonResult)files).Value as FileReference;
                Assert.Equal("Testfile10", fileRef.Name);
                Assert.Equal(FileType.Document, fileRef.FileType);
                Assert.True(fileRef.Path.EndsWith(fileRef.Id.ToString()));
            }

            using (var scope = provider.CreateScope())
            {
                var controller = scope.ServiceProvider.GetService<FileController>();
                controller.ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext()
                    {
                        User = GetUnitTestPrincipal()
                    }
                };

                var files = await controller.InsertAsync("Testfile10", UnitTesting.DotNetCore.Model.FileType.Document);
                Assert.IsType<ObjectResult>(files);
                Assert.Equal(409, ((ObjectResult)files).StatusCode);
            }
        }

        private static IServiceProvider GetServiceProvider()
        {
            var collection = new ServiceCollection();
            collection.AddMvc()
                .AddApplicationPart(typeof(FileController).GetTypeInfo().Assembly)
                .AddControllersAsServices();

            collection.AddEntityFrameworkInMemoryDatabase();
            collection.AddDbContext<FileDbContext>(builder => builder.UseInMemoryDatabase());

            collection.AddScoped<IFileSystemService, FileSystemServiceMock>();
            collection.AddScoped<IFileEntityService, FileEntityService>();

            var provider = collection.BuildServiceProvider();

            using (var scope = provider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<FileDbContext>();
                context.AddTestDataAsync("UnitTestUser").Wait();
                context.SaveChanges();
            }
            return provider;
        }

        private static ClaimsPrincipal GetUnitTestPrincipal()
        {
            var claims = new[] {
                new Claim(ClaimTypes.Name,"UnitTestUser"),
                new Claim(ClaimTypes.Role,"Admin")
            };
            return new ClaimsPrincipal(new ClaimsIdentity(claims, "basic"));
        }
    }
}