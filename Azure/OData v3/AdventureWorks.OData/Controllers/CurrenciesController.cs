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
    builder.EntitySet<DimCurrency>("Currencies");
    builder.EntitySet<DimOrganization>("DimOrganizations"); 
    builder.EntitySet<FactCurrencyRate>("FactCurrencyRates"); 
    builder.EntitySet<FactInternetSale>("FactInternetSales"); 
    builder.EntitySet<FactResellerSale>("FactResellerSales"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CurrenciesController : ODataController
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // GET: odata/Currencies
        [EnableQuery]
        public IQueryable<DimCurrency> GetCurrencies()
        {
            return db.DimCurrencies;
        }

        // GET: odata/Currencies(5)
        [EnableQuery]
        public SingleResult<DimCurrency> GetDimCurrency([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimCurrencies.Where(dimCurrency => dimCurrency.CurrencyKey == key));
        }

        // PUT: odata/Currencies(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<DimCurrency> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimCurrency dimCurrency = db.DimCurrencies.Find(key);
            if (dimCurrency == null)
            {
                return NotFound();
            }

            patch.Put(dimCurrency);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimCurrencyExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimCurrency);
        }

        // POST: odata/Currencies
        public IHttpActionResult Post(DimCurrency dimCurrency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DimCurrencies.Add(dimCurrency);
            db.SaveChanges();

            return Created(dimCurrency);
        }

        // PATCH: odata/Currencies(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DimCurrency> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimCurrency dimCurrency = db.DimCurrencies.Find(key);
            if (dimCurrency == null)
            {
                return NotFound();
            }

            patch.Patch(dimCurrency);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimCurrencyExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimCurrency);
        }

        // DELETE: odata/Currencies(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DimCurrency dimCurrency = db.DimCurrencies.Find(key);
            if (dimCurrency == null)
            {
                return NotFound();
            }

            db.DimCurrencies.Remove(dimCurrency);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Currencies(5)/DimOrganizations
        [EnableQuery]
        public IQueryable<DimOrganization> GetDimOrganizations([FromODataUri] int key)
        {
            return db.DimCurrencies.Where(m => m.CurrencyKey == key).SelectMany(m => m.DimOrganizations);
        }

        // GET: odata/Currencies(5)/FactCurrencyRates
        [EnableQuery]
        public IQueryable<FactCurrencyRate> GetFactCurrencyRates([FromODataUri] int key)
        {
            return db.DimCurrencies.Where(m => m.CurrencyKey == key).SelectMany(m => m.FactCurrencyRates);
        }

        // GET: odata/Currencies(5)/FactInternetSales
        [EnableQuery]
        public IQueryable<FactInternetSale> GetFactInternetSales([FromODataUri] int key)
        {
            return db.DimCurrencies.Where(m => m.CurrencyKey == key).SelectMany(m => m.FactInternetSales);
        }

        // GET: odata/Currencies(5)/FactResellerSales
        [EnableQuery]
        public IQueryable<FactResellerSale> GetFactResellerSales([FromODataUri] int key)
        {
            return db.DimCurrencies.Where(m => m.CurrencyKey == key).SelectMany(m => m.FactResellerSales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DimCurrencyExists(int key)
        {
            return db.DimCurrencies.Count(e => e.CurrencyKey == key) > 0;
        }
    }
}
