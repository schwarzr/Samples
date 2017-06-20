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
        public IHttpActionResult Delete([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            FactResellerSale factResellerSale = db.FactResellerSales.Find(salesOrderNumber, salesOrderLineNumber);
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
        public SingleResult<DimCurrency> GetDimCurrency([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            return SingleResult.Create(db.FactResellerSales.Where(m => m.SalesOrderNumber == salesOrderNumber && m.SalesOrderLineNumber == salesOrderLineNumber).Select(m => m.DimCurrency));
        }

        // GET: odata/ResellerSales(5)/DimDate
        [EnableQuery]
        public SingleResult<DimDate> GetDimDate([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            return SingleResult.Create(db.FactResellerSales.Where(m => m.SalesOrderNumber == salesOrderNumber && m.SalesOrderLineNumber == salesOrderLineNumber).Select(m => m.DimDate));
        }

        // GET: odata/ResellerSales(5)/DimDate1
        [EnableQuery]
        public SingleResult<DimDate> GetDimDate1([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            return SingleResult.Create(db.FactResellerSales.Where(m => m.SalesOrderNumber == salesOrderNumber && m.SalesOrderLineNumber == salesOrderLineNumber).Select(m => m.DimDate1));
        }

        // GET: odata/ResellerSales(5)/DimDate2
        [EnableQuery]
        public SingleResult<DimDate> GetDimDate2([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            return SingleResult.Create(db.FactResellerSales.Where(m => m.SalesOrderNumber == salesOrderNumber && m.SalesOrderLineNumber == salesOrderLineNumber).Select(m => m.DimDate2));
        }

        // GET: odata/ResellerSales(5)/DimEmployee
        [EnableQuery]
        public SingleResult<DimEmployee> GetDimEmployee([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            return SingleResult.Create(db.FactResellerSales.Where(m => m.SalesOrderNumber == salesOrderNumber && m.SalesOrderLineNumber == salesOrderLineNumber).Select(m => m.DimEmployee));
        }

        // GET: odata/ResellerSales(5)/DimProduct
        [EnableQuery]
        public SingleResult<DimProduct> GetDimProduct([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            return SingleResult.Create(db.FactResellerSales.Where(m => m.SalesOrderNumber == salesOrderNumber && m.SalesOrderLineNumber == salesOrderLineNumber).Select(m => m.DimProduct));
        }

        // GET: odata/ResellerSales(5)/DimPromotion
        [EnableQuery]
        public SingleResult<DimPromotion> GetDimPromotion([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            return SingleResult.Create(db.FactResellerSales.Where(m => m.SalesOrderNumber == salesOrderNumber && m.SalesOrderLineNumber == salesOrderLineNumber).Select(m => m.DimPromotion));
        }

        // GET: odata/ResellerSales(5)/DimReseller
        [EnableQuery]
        public SingleResult<DimReseller> GetDimReseller([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            return SingleResult.Create(db.FactResellerSales.Where(m => m.SalesOrderNumber == salesOrderNumber && m.SalesOrderLineNumber == salesOrderLineNumber).Select(m => m.DimReseller));
        }

        // GET: odata/ResellerSales(5)/DimSalesTerritory
        [EnableQuery]
        public SingleResult<DimSalesTerritory> GetDimSalesTerritory([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            return SingleResult.Create(db.FactResellerSales.Where(m => m.SalesOrderNumber == salesOrderNumber && m.SalesOrderLineNumber == salesOrderLineNumber).Select(m => m.DimSalesTerritory));
        }

        // GET: odata/ResellerSales(5)
        [EnableQuery]
        public SingleResult<FactResellerSale> GetFactResellerSale([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber)
        {
            return SingleResult.Create(db.FactResellerSales.Where(factResellerSale => factResellerSale.SalesOrderNumber == salesOrderNumber && factResellerSale.SalesOrderLineNumber == salesOrderLineNumber));
        }

        // GET: odata/ResellerSales
        [EnableQuery]
        public IQueryable<FactResellerSale> GetResellerSales()
        {
            return db.FactResellerSales;
        }

        // PATCH: odata/ResellerSales(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber, Delta<FactResellerSale> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FactResellerSale factResellerSale = db.FactResellerSales.Find(salesOrderNumber, salesOrderLineNumber);
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
                if (!FactResellerSaleExists(salesOrderNumber, salesOrderLineNumber))
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
        public IHttpActionResult Put([FromODataUri] string salesOrderNumber, [FromODataUri] byte salesOrderLineNumber, Delta<FactResellerSale> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FactResellerSale factResellerSale = db.FactResellerSales.Find(salesOrderNumber, salesOrderLineNumber);
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
                if (!FactResellerSaleExists(salesOrderNumber, salesOrderLineNumber))
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

        private bool FactResellerSaleExists(string salesOrderNumber, byte salesOrderLineNumber)
        {
            return db.FactResellerSales.Count(e => e.SalesOrderNumber == salesOrderNumber && e.SalesOrderLineNumber == salesOrderLineNumber) > 0;
        }
    }
}