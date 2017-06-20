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
    builder.EntitySet<FactProductInventory>("ProductInventories");
    builder.EntitySet<DimDate>("DimDates");
    builder.EntitySet<DimProduct>("DimProducts");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */

    public class ProductInventoriesController : ODataController
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // DELETE: odata/ProductInventories(5)
        public IHttpActionResult Delete([FromODataUri] int keyProductKey, [FromODataUri] int keyDateKey)
        {
            FactProductInventory factProductInventory = db.FactProductInventories.Find(keyProductKey, keyDateKey);
            if (factProductInventory == null)
            {
                return NotFound();
            }

            db.FactProductInventories.Remove(factProductInventory);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ProductInventories(5)/DimDate
        [EnableQuery]
        public SingleResult<DimDate> GetDimDate([FromODataUri] int keyProductKey, [FromODataUri] int keyDateKey)
        {
            return SingleResult.Create(db.FactProductInventories.Where(m => m.ProductKey == keyProductKey && m.DateKey == keyDateKey).Select(m => m.DimDate));
        }

        // GET: odata/ProductInventories(5)/DimProduct
        [EnableQuery]
        public SingleResult<DimProduct> GetDimProduct([FromODataUri] int keyProductKey, [FromODataUri] int keyDateKey)
        {
            return SingleResult.Create(db.FactProductInventories.Where(m => m.ProductKey == keyProductKey && m.DateKey == keyDateKey).Select(m => m.DimProduct));
        }

        // GET: odata/ProductInventories(5)
        [EnableQuery]
        public SingleResult<FactProductInventory> GetFactProductInventory([FromODataUri] int keyProductKey, [FromODataUri] int keyDateKey)
        {
            return SingleResult.Create(db.FactProductInventories.Where(factProductInventory => factProductInventory.ProductKey == keyProductKey && factProductInventory.DateKey == keyDateKey));
        }

        // GET: odata/ProductInventories
        [EnableQuery]
        public IQueryable<FactProductInventory> GetProductInventories()
        {
            return db.FactProductInventories;
        }

        // PATCH: odata/ProductInventories(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int keyProductKey, [FromODataUri] int keyDateKey, Delta<FactProductInventory> patch)
        {
            Validate(patch.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FactProductInventory factProductInventory = db.FactProductInventories.Find(keyProductKey, keyDateKey);
            if (factProductInventory == null)
            {
                return NotFound();
            }

            patch.Patch(factProductInventory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactProductInventoryExists(keyProductKey, keyDateKey))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(factProductInventory);
        }

        // POST: odata/ProductInventories
        public IHttpActionResult Post(FactProductInventory factProductInventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FactProductInventories.Add(factProductInventory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FactProductInventoryExists(factProductInventory.ProductKey, factProductInventory.DateKey))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(factProductInventory);
        }

        // PUT: odata/ProductInventories(5)
        public IHttpActionResult Put([FromODataUri] int keyProductKey, [FromODataUri] int keyDateKey, Delta<FactProductInventory> patch)
        {
            Validate(patch.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FactProductInventory factProductInventory = db.FactProductInventories.Find(keyProductKey, keyDateKey);
            if (factProductInventory == null)
            {
                return NotFound();
            }

            patch.Put(factProductInventory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactProductInventoryExists(keyProductKey, keyDateKey))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(factProductInventory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FactProductInventoryExists(int keyProductKey, int keyDateKey)
        {
            return db.FactProductInventories.Count(e => e.ProductKey == keyProductKey && e.DateKey == keyDateKey) > 0;
        }
    }
}