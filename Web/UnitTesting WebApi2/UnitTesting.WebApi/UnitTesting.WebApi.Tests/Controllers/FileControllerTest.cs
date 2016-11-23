using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owin;
using UnitTesting.WebApi.Contract;
using UnitTesting.WebApi.Controllers;
using UnitTesting.WebApi.Model;
using UnitTesting.WebApi.ServiceMock;

namespace UnitTesting.WebApi.Tests.Controllers
{
    [TestClass]
    public class FileControllerTest
    {
        [TestMethod]
        public async Task FileControllerGetAyncTest()
        {
            var controller = new FileController(new FileEntityServiceMock(), new FileSystemServiceMock());
            SetUser(controller);

            var files = await controller.GetAsync();

            Assert.AreEqual(3, files.Count());
            Assert.IsNotNull(files.SingleOrDefault(p => p.Name == "Testfile1"));
            Assert.IsNotNull(files.SingleOrDefault(p => p.Name == "Testfile2"));
            Assert.IsNotNull(files.SingleOrDefault(p => p.Name == "Testfile4"));
        }

        [TestMethod]
        public async Task FileControllerInsertAlreadyExistingFileAyncTest()
        {
            var controller = new FileController(new FileEntityServiceMock(), new FileSystemServiceMock());
            SetUser(controller);
            try
            {
                var files = await controller.InsertAsync("Testfile1", FileType.Image);
                Assert.Fail();
            }
            catch (HttpResponseException ex)
            {
                Assert.AreEqual(System.Net.HttpStatusCode.Conflict, ex.Response.StatusCode);
            }
        }

        [TestMethod]
        public async Task FileControllerInsertAyncTest()
        {
            var controller = new FileController(new FileEntityServiceMock(), new FileSystemServiceMock());
            SetUser(controller);
            controller.Request = new HttpRequestMessage(HttpMethod.Post, new Uri("http://localhost:1234/api/file?name=Testfile10&fileType=Document")) { Content = new StringContent("test") };

            var file = await controller.InsertAsync("Testfile10", FileType.Image);

            Assert.AreEqual("Testfile10", file.Name);

            var files = await controller.GetAsync();
            Assert.AreEqual(4, files.Count());
        }

        private static void SetUser(FileController controller)
        {
            var claims = new[] {
                    new Claim(ClaimTypes.Name,"UnitTestUser")
            };
            controller.User = new ClaimsPrincipal(new ClaimsIdentity(claims));
        }
    }
}