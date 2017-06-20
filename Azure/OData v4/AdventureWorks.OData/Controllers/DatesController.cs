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
    builder.EntitySet<DimDate>("Dates");
    builder.EntitySet<FactCallCenter>("FactCallCenters"); 
    builder.EntitySet<FactCurrencyRate>("FactCurrencyRates"); 
    builder.EntitySet<FactFinance>("FactFinances"); 
    builder.EntitySet<FactInternetSale>("FactInternetSales"); 
    builder.EntitySet<FactProductInventory>("FactProductInventories"); 
    builder.EntitySet<FactResellerSale>("FactResellerSales"); 
    builder.EntitySet<FactSalesQuota>("FactSalesQuotas"); 
    builder.EntitySet<FactSurveyResponse>("FactSurveyResponses"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DatesController : ODataController
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // GET: odata/Dates
        [EnableQuery]
        public IQueryable<DimDate> GetDates()
        {
            return db.DimDates;
        }

        // GET: odata/Dates(5)
        [EnableQuery]
        public SingleResult<DimDate> GetDimDate([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimDates.Where(dimDate => dimDate.DateKey == key));
        }

        // PUT: odata/Dates(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<DimDate> patch)
        {
            Validate(patch.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimDate dimDate = db.DimDates.Find(key);
            if (dimDate == null)
            {
                return NotFound();
            }

            patch.Put(dimDate);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimDateExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimDate);
        }

        // POST: odata/Dates
        public IHttpActionResult Post(DimDate dimDate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DimDates.Add(dimDate);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DimDateExists(dimDate.DateKey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(dimDate);
        }

        // PATCH: odata/Dates(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DimDate> patch)
        {
            Validate(patch.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimDate dimDate = db.DimDates.Find(key);
            if (dimDate == null)
            {
                return NotFound();
            }

            patch.Patch(dimDate);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimDateExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimDate);
        }

        // DELETE: odata/Dates(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DimDate dimDate = db.DimDates.Find(key);
            if (dimDate == null)
            {
                return NotFound();
            }

            db.DimDates.Remove(dimDate);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Dates(5)/FactCallCenters
        [EnableQuery]
        public IQueryable<FactCallCenter> GetFactCallCenters([FromODataUri] int key)
        {
            return db.DimDates.Where(m => m.DateKey == key).SelectMany(m => m.FactCallCenters);
        }

        // GET: odata/Dates(5)/FactCurrencyRates
        [EnableQuery]
        public IQueryable<FactCurrencyRate> GetFactCurrencyRates([FromODataUri] int key)
        {
            return db.DimDates.Where(m => m.DateKey == key).SelectMany(m => m.FactCurrencyRates);
        }

        // GET: odata/Dates(5)/FactFinances
        [EnableQuery]
        public IQueryable<FactFinance> GetFactFinances([FromODataUri] int key)
        {
            return db.DimDates.Where(m => m.DateKey == key).SelectMany(m => m.FactFinances);
        }

        // GET: odata/Dates(5)/FactInternetSales
        [EnableQuery]
        public IQueryable<FactInternetSale> GetFactInternetSales([FromODataUri] int key)
        {
            return db.DimDates.Where(m => m.DateKey == key).SelectMany(m => m.FactInternetSales);
        }

        // GET: odata/Dates(5)/FactInternetSales1
        [EnableQuery]
        public IQueryable<FactInternetSale> GetFactInternetSales1([FromODataUri] int key)
        {
            return db.DimDates.Where(m => m.DateKey == key).SelectMany(m => m.FactInternetSales1);
        }

        // GET: odata/Dates(5)/FactInternetSales2
        [EnableQuery]
        public IQueryable<FactInternetSale> GetFactInternetSales2([FromODataUri] int key)
        {
            return db.DimDates.Where(m => m.DateKey == key).SelectMany(m => m.FactInternetSales2);
        }

        // GET: odata/Dates(5)/FactProductInventories
        [EnableQuery]
        public IQueryable<FactProductInventory> GetFactProductInventories([FromODataUri] int key)
        {
            return db.DimDates.Where(m => m.DateKey == key).SelectMany(m => m.FactProductInventories);
        }

        // GET: odata/Dates(5)/FactResellerSales
        [EnableQuery]
        public IQueryable<FactResellerSale> GetFactResellerSales([FromODataUri] int key)
        {
            return db.DimDates.Where(m => m.DateKey == key).SelectMany(m => m.FactResellerSales);
        }

        // GET: odata/Dates(5)/FactResellerSales1
        [EnableQuery]
        public IQueryable<FactResellerSale> GetFactResellerSales1([FromODataUri] int key)
        {
            return db.DimDates.Where(m => m.DateKey == key).SelectMany(m => m.FactResellerSales1);
        }

        // GET: odata/Dates(5)/FactResellerSales2
        [EnableQuery]
        public IQueryable<FactResellerSale> GetFactResellerSales2([FromODataUri] int key)
        {
            return db.DimDates.Where(m => m.DateKey == key).SelectMany(m => m.FactResellerSales2);
        }

        // GET: odata/Dates(5)/FactSalesQuotas
        [EnableQuery]
        public IQueryable<FactSalesQuota> GetFactSalesQuotas([FromODataUri] int key)
        {
            return db.DimDates.Where(m => m.DateKey == key).SelectMany(m => m.FactSalesQuotas);
        }

        // GET: odata/Dates(5)/FactSurveyResponses
        [EnableQuery]
        public IQueryable<FactSurveyResponse> GetFactSurveyResponses([FromODataUri] int key)
        {
            return db.DimDates.Where(m => m.DateKey == key).SelectMany(m => m.FactSurveyResponses);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DimDateExists(int key)
        {
            return db.DimDates.Count(e => e.DateKey == key) > 0;
        }
    }
}
