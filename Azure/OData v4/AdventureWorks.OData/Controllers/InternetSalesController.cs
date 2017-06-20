using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.OData;
using System.Web.OData.Routing;
using AdventureWorks.Model;

namespace AdventureWorks.OData.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using AdventureWorks.Model;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<FactInternetSale>("InternetSales");
    builder.EntitySet<DimCurrency>("DimCurrencies");
    builder.EntitySet<DimCustomer>("DimCustomers");
    builder.EntitySet<DimDate>("DimDates");
    builder.EntitySet<DimProduct>("DimProducts");
    builder.EntitySet<DimPromotion>("DimPromotions");
    builder.EntitySet<DimSalesReason>("DimSalesReasons");
    builder.EntitySet<DimSalesTerritory>("DimSalesTerritories");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */

    public class InternetSalesController : ODataController
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // DELETE: odata/InternetSales(5)
        public IHttpActionResult Delete([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            FactInternetSale factInternetSale = db.FactInternetSales.Find(keySalesOrderNumber, keySalesOrderLineNumber);
            if (factInternetSale == null)
            {
                return NotFound();
            }

            db.FactInternetSales.Remove(factInternetSale);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/InternetSales(5)/DimCurrency
        [EnableQuery]
        public SingleResult<DimCurrency> GetDimCurrency([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            return SingleResult.Create(db.FactInternetSales.Where(m => m.SalesOrderNumber == keySalesOrderNumber && m.SalesOrderLineNumber == keySalesOrderLineNumber).Select(m => m.DimCurrency));
        }

        // GET: odata/InternetSales(5)/DimCustomer
        [EnableQuery]
        public SingleResult<DimCustomer> GetDimCustomer([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            return SingleResult.Create(db.FactInternetSales.Where(m => m.SalesOrderNumber == keySalesOrderNumber && m.SalesOrderLineNumber == keySalesOrderLineNumber).Select(m => m.DimCustomer));
        }

        // GET: odata/InternetSales(5)/DimDate
        [EnableQuery]
        public SingleResult<DimDate> GetDimDate([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            return SingleResult.Create(db.FactInternetSales.Where(m => m.SalesOrderNumber == keySalesOrderNumber && m.SalesOrderLineNumber == keySalesOrderLineNumber).Select(m => m.DimDate));
        }

        // GET: odata/InternetSales(5)/DimDate1
        [EnableQuery]
        public SingleResult<DimDate> GetDimDate1([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            return SingleResult.Create(db.FactInternetSales.Where(m => m.SalesOrderNumber == keySalesOrderNumber && m.SalesOrderLineNumber == keySalesOrderLineNumber).Select(m => m.DimDate1));
        }

        // GET: odata/InternetSales(5)/DimDate2
        [EnableQuery]
        public SingleResult<DimDate> GetDimDate2([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            return SingleResult.Create(db.FactInternetSales.Where(m => m.SalesOrderNumber == keySalesOrderNumber && m.SalesOrderLineNumber == keySalesOrderLineNumber).Select(m => m.DimDate2));
        }

        // GET: odata/InternetSales(5)/DimProduct
        [EnableQuery]
        public SingleResult<DimProduct> GetDimProduct([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            return SingleResult.Create(db.FactInternetSales.Where(m => m.SalesOrderNumber == keySalesOrderNumber && m.SalesOrderLineNumber == keySalesOrderLineNumber).Select(m => m.DimProduct));
        }

        // GET: odata/InternetSales(5)/DimPromotion
        [EnableQuery]
        public SingleResult<DimPromotion> GetDimPromotion([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            return SingleResult.Create(db.FactInternetSales.Where(m => m.SalesOrderNumber == keySalesOrderNumber && m.SalesOrderLineNumber == keySalesOrderLineNumber).Select(m => m.DimPromotion));
        }

        // GET: odata/InternetSales(5)/DimSalesReasons
        [EnableQuery]
        public IQueryable<DimSalesReason> GetDimSalesReasons([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            return db.FactInternetSales.Where(m => m.SalesOrderNumber == keySalesOrderNumber && m.SalesOrderLineNumber == keySalesOrderLineNumber).SelectMany(m => m.DimSalesReasons);
        }

        // GET: odata/InternetSales(5)/DimSalesTerritory
        [EnableQuery]
        public SingleResult<DimSalesTerritory> GetDimSalesTerritory([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            return SingleResult.Create(db.FactInternetSales.Where(m => m.SalesOrderNumber == keySalesOrderNumber && m.SalesOrderLineNumber == keySalesOrderLineNumber).Select(m => m.DimSalesTerritory));
        }

        // GET: odata/InternetSales(5)
        [EnableQuery]
        public SingleResult<FactInternetSale> GetFactInternetSale([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            return SingleResult.Create(db.FactInternetSales.Where(factInternetSale => factInternetSale.SalesOrderNumber == keySalesOrderNumber && factInternetSale.SalesOrderLineNumber == keySalesOrderLineNumber));
        }

        // GET: odata/InternetSales
        [EnableQuery]
        public IQueryable<FactInternetSale> GetInternetSales()
        {
            return db.FactInternetSales;
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("SpecialReportSales(MaxAmount={maxAmount})")]
        public IHttpActionResult GetSpecialReportSales([FromODataUri] int maxAmount)
        {
            var baseQuery = db.FactInternetSales.GroupBy(p => p.SalesOrderNumber)
                            .Where(p => p.Sum(x => x.SalesAmount) < maxAmount);

            var query = db.FactInternetSales.Join(baseQuery, p => p.SalesOrderNumber, p => p.Key, (p, q) => p);

            return Ok(query);
        }

        // PATCH: odata/InternetSales(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber, Delta<FactInternetSale> patch)
        {
            Validate(patch.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FactInternetSale factInternetSale = db.FactInternetSales.Find(keySalesOrderNumber, keySalesOrderLineNumber);
            if (factInternetSale == null)
            {
                return NotFound();
            }

            patch.Patch(factInternetSale);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactInternetSaleExists(keySalesOrderNumber, keySalesOrderLineNumber))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(factInternetSale);
        }

        // POST: odata/InternetSales
        public IHttpActionResult Post(FactInternetSale factInternetSale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FactInternetSales.Add(factInternetSale);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FactInternetSaleExists(factInternetSale.SalesOrderNumber, factInternetSale.SalesOrderLineNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(factInternetSale);
        }

        // PUT: odata/InternetSales(5)
        public IHttpActionResult Put([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber, Delta<FactInternetSale> patch)
        {
            Validate(patch.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FactInternetSale factInternetSale = db.FactInternetSales.Find(keySalesOrderNumber, keySalesOrderLineNumber);
            if (factInternetSale == null)
            {
                return NotFound();
            }

            patch.Put(factInternetSale);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactInternetSaleExists(keySalesOrderNumber, keySalesOrderLineNumber))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(factInternetSale);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FactInternetSaleExists(string keySalesOrderNumber, byte keySalesOrderLineNumber)
        {
            return db.FactInternetSales.Count(e => e.SalesOrderNumber == keySalesOrderNumber && e.SalesOrderLineNumber == keySalesOrderLineNumber) > 0;
        }
    }
}