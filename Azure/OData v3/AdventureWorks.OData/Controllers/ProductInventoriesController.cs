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
    builder.EntitySet<FactProductInventory>("ProductInventories");
    builder.EntitySet<DimDate>("DimDates");
    builder.EntitySet<DimProduct>("DimProducts");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */

    public class ProductInventoriesController : ODataController
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // DELETE: odata/ProductInventories(5)
        public IHttpActionResult Delete([FromODataUri] int productKey, [FromODataUri] int dateKey)
        {
            FactProductInventory factProductInventory = db.FactProductInventories.Find(productKey, dateKey);
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
        public SingleResult<DimDate> GetDimDate([FromODataUri] int productKey, [FromODataUri] int dateKey)
        {
            return SingleResult.Create(db.FactProductInventories.Where(m => m.ProductKey == productKey && m.DateKey == dateKey).Select(m => m.DimDate));
        }

        // GET: odata/ProductInventories(5)/DimProduct
        [EnableQuery]
        public SingleResult<DimProduct> GetDimProduct([FromODataUri] int productKey, [FromODataUri] int dateKey)
        {
            return SingleResult.Create(db.FactProductInventories.Where(m => m.ProductKey == productKey && m.DateKey == dateKey).Select(m => m.DimProduct));
        }

        // GET: odata/ProductInventories(5)
        [EnableQuery]
        public SingleResult<FactProductInventory> GetFactProductInventory([FromODataUri] int productKey, [FromODataUri] int dateKey)
        {
            return SingleResult.Create(db.FactProductInventories.Where(factProductInventory => factProductInventory.ProductKey == productKey && factProductInventory.DateKey == dateKey));
        }

        // GET: odata/ProductInventories
        [EnableQuery]
        public IQueryable<FactProductInventory> GetProductInventories()
        {
            return db.FactProductInventories;
        }

        // PATCH: odata/ProductInventories(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int productKey, [FromODataUri] int dateKey, Delta<FactProductInventory> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FactProductInventory factProductInventory = db.FactProductInventories.Find(productKey, dateKey);
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
                if (!FactProductInventoryExists(productKey, dateKey))
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
        public IHttpActionResult Put([FromODataUri] int productKey, [FromODataUri] int dateKey, Delta<FactProductInventory> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FactProductInventory factProductInventory = db.FactProductInventories.Find(productKey, dateKey);
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
                if (!FactProductInventoryExists(productKey, dateKey))
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

        private bool FactProductInventoryExists(int productKey, int dateKey)
        {
            return db.FactProductInventories.Count(e => e.ProductKey == productKey && e.DateKey == dateKey) > 0;
        }
    }
}