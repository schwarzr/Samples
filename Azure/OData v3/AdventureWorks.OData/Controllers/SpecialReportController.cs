using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData.Query;
using AdventureWorks.Model;

namespace AdventureWorks.OData.Controllers
{
    [RoutePrefix("api/specialreport")]
    public class SpecialReportController : ApiController
    {
        private readonly AdventureWorksContext _context;

        public SpecialReportController()
        {
            _context = new AdventureWorksContext();
        }

        [Route("Sales")]
        [HttpGet]
        public async Task<IHttpActionResult> GetSales(ODataQueryOptions<FactInternetSale> options)
        {
            var baseQuery = _context.FactInternetSales.GroupBy(p => p.SalesOrderNumber)
                            .Where(p => p.Sum(x => x.SalesAmount) < 500);

            var query = _context.FactInternetSales.Join(baseQuery, p => p.SalesOrderNumber, p => p.Key, (p, q) => p);

            var resultQuery = options.ApplyTo(query);

            return Ok(await resultQuery.ToListAsync());
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }
    }
}