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
    builder.EntitySet<DimProductCategory>("ProductCategories");
    builder.EntitySet<DimProductSubcategory>("DimProductSubcategories"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ProductCategoriesController : ODataController
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // GET: odata/ProductCategories
        [EnableQuery]
        public IQueryable<DimProductCategory> GetProductCategories()
        {
            return db.DimProductCategories;
        }

        // GET: odata/ProductCategories(5)
        [EnableQuery]
        public SingleResult<DimProductCategory> GetDimProductCategory([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimProductCategories.Where(dimProductCategory => dimProductCategory.ProductCategoryKey == key));
        }

        // PUT: odata/ProductCategories(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<DimProductCategory> patch)
        {
            Validate(patch.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimProductCategory dimProductCategory = db.DimProductCategories.Find(key);
            if (dimProductCategory == null)
            {
                return NotFound();
            }

            patch.Put(dimProductCategory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimProductCategoryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimProductCategory);
        }

        // POST: odata/ProductCategories
        public IHttpActionResult Post(DimProductCategory dimProductCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DimProductCategories.Add(dimProductCategory);
            db.SaveChanges();

            return Created(dimProductCategory);
        }

        // PATCH: odata/ProductCategories(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DimProductCategory> patch)
        {
            Validate(patch.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimProductCategory dimProductCategory = db.DimProductCategories.Find(key);
            if (dimProductCategory == null)
            {
                return NotFound();
            }

            patch.Patch(dimProductCategory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimProductCategoryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimProductCategory);
        }

        // DELETE: odata/ProductCategories(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DimProductCategory dimProductCategory = db.DimProductCategories.Find(key);
            if (dimProductCategory == null)
            {
                return NotFound();
            }

            db.DimProductCategories.Remove(dimProductCategory);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ProductCategories(5)/DimProductSubcategories
        [EnableQuery]
        public IQueryable<DimProductSubcategory> GetDimProductSubcategories([FromODataUri] int key)
        {
            return db.DimProductCategories.Where(m => m.ProductCategoryKey == key).SelectMany(m => m.DimProductSubcategories);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DimProductCategoryExists(int key)
        {
            return db.DimProductCategories.Count(e => e.ProductCategoryKey == key) > 0;
        }
    }
}
