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
    builder.EntitySet<FactResellerSale>("ResellerSales");
    builder.EntitySet<DimCurrency>("DimCurrencies");
    builder.EntitySet<DimDate>("DimDates");
    builder.EntitySet<DimEmployee>("DimEmployees");
    builder.EntitySet<DimProduct>("DimProducts");
    builder.EntitySet<DimPromotion>("DimPromotions");
    builder.EntitySet<DimReseller>("DimResellers");
    builder.EntitySet<DimSalesTerritory>("DimSalesTerritories");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */

    public class ResellerSalesController : ODataController
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // DELETE: odata/ResellerSales(5)
        public IHttpActionResult Delete([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            FactResellerSale factResellerSale = db.FactResellerSales.Find(keySalesOrderNumber, keySalesOrderLineNumber);
            if (factResellerSale == null)
            {
                return NotFound();
            }

            db.FactResellerSales.Remove(factResellerSale);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ResellerSales(5)/DimCurrency
        [EnableQuery]
        public SingleResult<DimCurrency> GetDimCurrency([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            return SingleResult.Create(db.FactResellerSales.Where(m => m.SalesOrderNumber == keySalesOrderNumber && m.SalesOrderLineNumber == keySalesOrderLineNumber).Select(m => m.DimCurrency));
        }

        // GET: odata/ResellerSales(5)/DimDate
        [EnableQuery]
        public SingleResult<DimDate> GetDimDate([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            return SingleResult.Create(db.FactResellerSales.Where(m => m.SalesOrderNumber == keySalesOrderNumber && m.SalesOrderLineNumber == keySalesOrderLineNumber).Select(m => m.DimDate));
        }

        // GET: odata/ResellerSales(5)/DimDate1
        [EnableQuery]
        public SingleResult<DimDate> GetDimDate1([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            return SingleResult.Create(db.FactResellerSales.Where(m => m.SalesOrderNumber == keySalesOrderNumber && m.SalesOrderLineNumber == keySalesOrderLineNumber).Select(m => m.DimDate1));
        }

        // GET: odata/ResellerSales(5)/DimDate2
        [EnableQuery]
        public SingleResult<DimDate> GetDimDate2([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            return SingleResult.Create(db.FactResellerSales.Where(m => m.SalesOrderNumber == keySalesOrderNumber && m.SalesOrderLineNumber == keySalesOrderLineNumber).Select(m => m.DimDate2));
        }

        // GET: odata/ResellerSales(5)/DimEmployee
        [EnableQuery]
        public SingleResult<DimEmployee> GetDimEmployee([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            return SingleResult.Create(db.FactResellerSales.Where(m => m.SalesOrderNumber == keySalesOrderNumber && m.SalesOrderLineNumber == keySalesOrderLineNumber).Select(m => m.DimEmployee));
        }

        // GET: odata/ResellerSales(5)/DimProduct
        [EnableQuery]
        public SingleResult<DimProduct> GetDimProduct([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            return SingleResult.Create(db.FactResellerSales.Where(m => m.SalesOrderNumber == keySalesOrderNumber && m.SalesOrderLineNumber == keySalesOrderLineNumber).Select(m => m.DimProduct));
        }

        // GET: odata/ResellerSales(5)/DimPromotion
        [EnableQuery]
        public SingleResult<DimPromotion> GetDimPromotion([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            return SingleResult.Create(db.FactResellerSales.Where(m => m.SalesOrderNumber == keySalesOrderNumber && m.SalesOrderLineNumber == keySalesOrderLineNumber).Select(m => m.DimPromotion));
        }

        // GET: odata/ResellerSales(5)/DimReseller
        [EnableQuery]
        public SingleResult<DimReseller> GetDimReseller([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            return SingleResult.Create(db.FactResellerSales.Where(m => m.SalesOrderNumber == keySalesOrderNumber && m.SalesOrderLineNumber == keySalesOrderLineNumber).Select(m => m.DimReseller));
        }

        // GET: odata/ResellerSales(5)/DimSalesTerritory
        [EnableQuery]
        public SingleResult<DimSalesTerritory> GetDimSalesTerritory([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            return SingleResult.Create(db.FactResellerSales.Where(m => m.SalesOrderNumber == keySalesOrderNumber && m.SalesOrderLineNumber == keySalesOrderLineNumber).Select(m => m.DimSalesTerritory));
        }

        // GET: odata/ResellerSales(5)
        [EnableQuery]
        public SingleResult<FactResellerSale> GetFactResellerSale([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber)
        {
            return SingleResult.Create(db.FactResellerSales.Where(factResellerSale => factResellerSale.SalesOrderNumber == keySalesOrderNumber && factResellerSale.SalesOrderLineNumber == keySalesOrderLineNumber));
        }

        // GET: odata/ResellerSales
        [EnableQuery]
        public IQueryable<FactResellerSale> GetResellerSales()
        {
            return db.FactResellerSales;
        }

        // PATCH: odata/ResellerSales(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber, Delta<FactResellerSale> patch)
        {
            Validate(patch.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FactResellerSale factResellerSale = db.FactResellerSales.Find(keySalesOrderNumber, keySalesOrderLineNumber);
            if (factResellerSale == null)
            {
                return NotFound();
            }

            patch.Patch(factResellerSale);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactResellerSaleExists(keySalesOrderNumber, keySalesOrderLineNumber))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(factResellerSale);
        }

        // POST: odata/ResellerSales
        public IHttpActionResult Post(FactResellerSale factResellerSale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FactResellerSales.Add(factResellerSale);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FactResellerSaleExists(factResellerSale.SalesOrderNumber, factResellerSale.SalesOrderLineNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(factResellerSale);
        }

        // PUT: odata/ResellerSales(5)
        public IHttpActionResult Put([FromODataUri] string keySalesOrderNumber, [FromODataUri] byte keySalesOrderLineNumber, Delta<FactResellerSale> patch)
        {
            Validate(patch.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FactResellerSale factResellerSale = db.FactResellerSales.Find(keySalesOrderNumber, keySalesOrderLineNumber);
            if (factResellerSale == null)
            {
                return NotFound();
            }

            patch.Put(factResellerSale);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactResellerSaleExists(keySalesOrderNumber, keySalesOrderLineNumber))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(factResellerSale);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FactResellerSaleExists(string keySalesOrderNumber, byte keySalesOrderLineNumber)
        {
            return db.FactResellerSales.Count(e => e.SalesOrderNumber == keySalesOrderNumber && e.SalesOrderLineNumber == keySalesOrderLineNumber) > 0;
        }
    }
}