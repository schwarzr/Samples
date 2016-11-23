using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Owin;
using UnitTesting.WebApi.Controllers;
using UnitTesting.WebApi.Model;
using UnitTesting.WebApi.ServiceMock;

namespace UnitTesting.WebApi.Tests.Controllers
{
    [TestClass]
    public class FileControllerWebClientTest
    {
        private const string _readOnlyUrl = "http://localhost:8888/";
        private static IDisposable _webApp;

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            _webApp.Dispose();
        }

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            _webApp = CreateWebApp(_readOnlyUrl,
                resolver => resolver.RegisterFactory<FileController>(() => new FileController(new FileEntityServiceMock(), new FileSystemServiceMock()))
                );
        }

        public static IDisposable CreateWebApp(string baseUri, Action<UnitTestDependencyResolver> registerResolver)
        {
            return WebApp.Start(baseUri, app =>
            {
                HttpConfiguration config = new HttpConfiguration();
                WebApiConfig.Register(config);
                var resolver = new UnitTestDependencyResolver(config.DependencyResolver);
                config.Filters.Add(new UnitTestAuthenticationFilter());
                config.DependencyResolver = resolver;
                app.UseWebApi(config);

                registerResolver(resolver);
            });
        }

        [TestMethod]
        public async Task WebClientGetAsyncTest()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{_readOnlyUrl}api/file");
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                var files = await response.Content.ReadAsAsync<IEnumerable<FileReference>>();

                Assert.AreEqual(3, files.Count());
            }
        }

        [TestMethod]
        public async Task WebClientInsertAlreadyExistingFileAsyncTest()
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync($"{_readOnlyUrl}api/file?name=Testfile1&fileType=Document", new ByteArrayContent(Encoding.UTF8.GetBytes("Test")));
                Assert.AreEqual(HttpStatusCode.Conflict, response.StatusCode);
            }
        }

        [TestMethod]
        public async Task WebClientInsertAsyncTest()
        {
            var baseUrl = "http://localhost:8889/";
            var fileEntityService = new FileEntityServiceMock();
            var fileSystemService = new FileSystemServiceMock();

            using (var app = CreateWebApp(baseUrl, resolver => resolver.RegisterFactory<FileController>(() => new FileController(fileEntityService, fileSystemService))))
            {
                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync($"{baseUrl}api/file?name=Testfile10&fileType=Document", new ByteArrayContent(Encoding.UTF8.GetBytes("Test")));
                    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                    var file = await response.Content.ReadAsAsync<FileReference>();
                    Assert.AreEqual(FileType.Document, file.FileType);
                    Assert.AreEqual("Testfile10", file.Name);
                    Assert.IsTrue(file.Path.EndsWith(file.Id.ToString()));
                    response = await client.PostAsync($"{baseUrl}api/file?name=Testfile10&fileType=Document", new ByteArrayContent(Encoding.UTF8.GetBytes("Test")));
                    Assert.AreEqual(HttpStatusCode.Conflict, response.StatusCode);
                }
            }
        }
    }
}