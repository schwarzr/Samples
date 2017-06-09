using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using LargeData.Database;
using LargeData.Model;
using LargeData.Model.Custom;
using LargeDate.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace LargeData.Web.Controllers
{
    [Route("api/[controller]")]
    public class InternetSalesController : Controller
    {
        private readonly AdventureWorksContext _context;

        public InternetSalesController(AdventureWorksContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<InternetSale>> GetAsync(DateTime? from = null, DateTime? until = null)
        {
            ManageVaryHeader(this.HttpContext);
            return (await InternetSalesDataAccess.GetInternetSalesQueryAsync(_context, from, until));
        }

        [HttpGet]
        [Route("info")]
        public async Task<IEnumerable<InternetSaleInfo>> GetInfoAsync(DateTime? from = null, DateTime? until = null)
        {
            ManageVaryHeader(this.HttpContext);
            var query = await InternetSalesDataAccess.GetInternetSaleInfosQueryAsync(_context, from, until);
            return query;
        }

        [HttpGet]
        [Route("info/stream")]
        public async Task<Stream> GetInfoStreamAsync(DateTime? from = null, DateTime? until = null)
        {
            var query = await InternetSalesDataAccess.GetInternetSaleInfosQueryAsync(_context, from, until);
            return new DataStream<InternetSaleInfo>(query);
        }

        private void ManageVaryHeader(HttpContext context)
        {
            // If the Accept-Encoding header is present, always add the Vary header
            // This will be added as a feature in the next release of the middleware.
            // https://github.com/aspnet/BasicMiddleware/issues/187

            var accept = context.Request.Headers[HeaderNames.AcceptEncoding];

            if (!StringValues.IsNullOrEmpty(accept))
            {
                context.Response.Headers.Append(HeaderNames.Vary, HeaderNames.AcceptEncoding);
            }
        }
    }
}