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
    builder.EntitySet<DimProductSubcategory>("ProductSubcategories");
    builder.EntitySet<DimProductCategory>("DimProductCategories"); 
    builder.EntitySet<DimProduct>("DimProducts"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ProductSubcategoriesController : ODataController
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // GET: odata/ProductSubcategories
        [EnableQuery]
        public IQueryable<DimProductSubcategory> GetProductSubcategories()
        {
            return db.DimProductSubcategories;
        }

        // GET: odata/ProductSubcategories(5)
        [EnableQuery]
        public SingleResult<DimProductSubcategory> GetDimProductSubcategory([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimProductSubcategories.Where(dimProductSubcategory => dimProductSubcategory.ProductSubcategoryKey == key));
        }

        // PUT: odata/ProductSubcategories(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<DimProductSubcategory> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimProductSubcategory dimProductSubcategory = db.DimProductSubcategories.Find(key);
            if (dimProductSubcategory == null)
            {
                return NotFound();
            }

            patch.Put(dimProductSubcategory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimProductSubcategoryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimProductSubcategory);
        }

        // POST: odata/ProductSubcategories
        public IHttpActionResult Post(DimProductSubcategory dimProductSubcategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DimProductSubcategories.Add(dimProductSubcategory);
            db.SaveChanges();

            return Created(dimProductSubcategory);
        }

        // PATCH: odata/ProductSubcategories(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DimProductSubcategory> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimProductSubcategory dimProductSubcategory = db.DimProductSubcategories.Find(key);
            if (dimProductSubcategory == null)
            {
                return NotFound();
            }

            patch.Patch(dimProductSubcategory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimProductSubcategoryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimProductSubcategory);
        }

        // DELETE: odata/ProductSubcategories(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DimProductSubcategory dimProductSubcategory = db.DimProductSubcategories.Find(key);
            if (dimProductSubcategory == null)
            {
                return NotFound();
            }

            db.DimProductSubcategories.Remove(dimProductSubcategory);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ProductSubcategories(5)/DimProductCategory
        [EnableQuery]
        public SingleResult<DimProductCategory> GetDimProductCategory([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimProductSubcategories.Where(m => m.ProductSubcategoryKey == key).Select(m => m.DimProductCategory));
        }

        // GET: odata/ProductSubcategories(5)/DimProducts
        [EnableQuery]
        public IQueryable<DimProduct> GetDimProducts([FromODataUri] int key)
        {
            return db.DimProductSubcategories.Where(m => m.ProductSubcategoryKey == key).SelectMany(m => m.DimProducts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DimProductSubcategoryExists(int key)
        {
            return db.DimProductSubcategories.Count(e => e.ProductSubcategoryKey == key) > 0;
        }
    }
}
