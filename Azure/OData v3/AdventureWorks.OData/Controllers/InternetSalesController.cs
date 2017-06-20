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
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using AdventureWorks.Model;

namespace AdventureWorks.OData.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
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
        public IHttpActionResult Delete([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            FactInternetSale factInternetSale = db.FactInternetSales.Find(salesOrderNumber, salesOrderLineNumber);
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
        public SingleResult<DimCurrency> GetDimCurrency([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            return SingleResult.Create(db.FactInternetSales.Where(m => m.SalesOrderNumber == salesOrderNumber && m.SalesOrderLineNumber == salesOrderLineNumber).Select(m => m.DimCurrency));
        }

        // GET: odata/InternetSales(5)/DimCustomer
        [EnableQuery]
        public SingleResult<DimCustomer> GetDimCustomer([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            return SingleResult.Create(db.FactInternetSales.Where(m => m.SalesOrderNumber == salesOrderNumber && m.SalesOrderLineNumber == salesOrderLineNumber).Select(m => m.DimCustomer));
        }

        // GET: odata/InternetSales(5)/DimDate
        [EnableQuery]
        public SingleResult<DimDate> GetDimDate([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            return SingleResult.Create(db.FactInternetSales.Where(m => m.SalesOrderNumber == salesOrderNumber && m.SalesOrderLineNumber == salesOrderLineNumber).Select(m => m.DimDate));
        }

        // GET: odata/InternetSales(5)/DimDate1
        [EnableQuery]
        public SingleResult<DimDate> GetDimDate1([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            return SingleResult.Create(db.FactInternetSales.Where(m => m.SalesOrderNumber == salesOrderNumber && m.SalesOrderLineNumber == salesOrderLineNumber).Select(m => m.DimDate1));
        }

        // GET: odata/InternetSales(5)/DimDate2
        [EnableQuery]
        public SingleResult<DimDate> GetDimDate2([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            return SingleResult.Create(db.FactInternetSales.Where(m => m.SalesOrderNumber == salesOrderNumber && m.SalesOrderLineNumber == salesOrderLineNumber).Select(m => m.DimDate2));
        }

        // GET: odata/InternetSales(5)/DimProduct
        [EnableQuery]
        public SingleResult<DimProduct> GetDimProduct([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            return SingleResult.Create(db.FactInternetSales.Where(m => m.SalesOrderNumber == salesOrderNumber && m.SalesOrderLineNumber == salesOrderLineNumber).Select(m => m.DimProduct));
        }

        // GET: odata/InternetSales(5)/DimPromotion
        [EnableQuery]
        public SingleResult<DimPromotion> GetDimPromotion([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            return SingleResult.Create(db.FactInternetSales.Where(m => m.SalesOrderNumber == salesOrderNumber && m.SalesOrderLineNumber == salesOrderLineNumber).Select(m => m.DimPromotion));
        }

        // GET: odata/InternetSales(5)/DimSalesReasons
        [EnableQuery]
        public IQueryable<DimSalesReason> GetDimSalesReasons([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            return db.FactInternetSales.Where(m => m.SalesOrderNumber == salesOrderNumber && m.SalesOrderLineNumber == salesOrderLineNumber).SelectMany(m => m.DimSalesReasons);
        }

        // GET: odata/InternetSales(5)/DimSalesTerritory
        [EnableQuery]
        public SingleResult<DimSalesTerritory> GetDimSalesTerritory([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            return SingleResult.Create(db.FactInternetSales.Where(m => m.SalesOrderNumber == salesOrderNumber && m.SalesOrderLineNumber == salesOrderLineNumber).Select(m => m.DimSalesTerritory));
        }

        // GET: odata/InternetSales(5)
        [EnableQuery]
        public SingleResult<FactInternetSale> GetFactInternetSale([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            return SingleResult.Create(db.FactInternetSales.Where(factInternetSale => factInternetSale.SalesOrderNumber == salesOrderNumber && factInternetSale.SalesOrderLineNumber == salesOrderLineNumber));
        }

        // GET: odata/InternetSales
        [EnableQuery]
        public IQueryable<FactInternetSale> GetInternetSales()
        {
            return db.FactInternetSales;
        }

        // PATCH: odata/InternetSales(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber, Delta<FactInternetSale> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FactInternetSale factInternetSale = db.FactInternetSales.Find(salesOrderNumber, salesOrderLineNumber);
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
                if (!FactInternetSaleExists(salesOrderNumber, salesOrderLineNumber))
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
        public IHttpActionResult Put([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber, Delta<FactInternetSale> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FactInternetSale factInternetSale = db.FactInternetSales.Find(salesOrderNumber, salesOrderLineNumber);
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
                if (!FactInternetSaleExists(salesOrderNumber, salesOrderLineNumber))
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

        private bool FactInternetSaleExists(string salesOrderNumber, byte salesOrderLineNumber)
        {
            return db.FactInternetSales.Count(e => e.SalesOrderNumber == salesOrderNumber && e.SalesOrderLineNumber == salesOrderLineNumber) > 0;
        }
    }
}