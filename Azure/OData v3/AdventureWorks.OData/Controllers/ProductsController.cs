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
    builder.EntitySet<DimProduct>("Products");
    builder.EntitySet<DimProductSubcategory>("DimProductSubcategories"); 
    builder.EntitySet<FactInternetSale>("FactInternetSales"); 
    builder.EntitySet<FactProductInventory>("FactProductInventories"); 
    builder.EntitySet<FactResellerSale>("FactResellerSales"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ProductsController : ODataController
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // GET: odata/Products
        [EnableQuery]
        public IQueryable<DimProduct> GetProducts()
        {
            return db.DimProducts;
        }

        // GET: odata/Products(5)
        [EnableQuery]
        public SingleResult<DimProduct> GetDimProduct([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimProducts.Where(dimProduct => dimProduct.ProductKey == key));
        }

        // PUT: odata/Products(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<DimProduct> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimProduct dimProduct = db.DimProducts.Find(key);
            if (dimProduct == null)
            {
                return NotFound();
            }

            patch.Put(dimProduct);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimProduct);
        }

        // POST: odata/Products
        public IHttpActionResult Post(DimProduct dimProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DimProducts.Add(dimProduct);
            db.SaveChanges();

            return Created(dimProduct);
        }

        // PATCH: odata/Products(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DimProduct> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimProduct dimProduct = db.DimProducts.Find(key);
            if (dimProduct == null)
            {
                return NotFound();
            }

            patch.Patch(dimProduct);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimProduct);
        }

        // DELETE: odata/Products(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DimProduct dimProduct = db.DimProducts.Find(key);
            if (dimProduct == null)
            {
                return NotFound();
            }

            db.DimProducts.Remove(dimProduct);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Products(5)/DimProductSubcategory
        [EnableQuery]
        public SingleResult<DimProductSubcategory> GetDimProductSubcategory([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimProducts.Where(m => m.ProductKey == key).Select(m => m.DimProductSubcategory));
        }

        // GET: odata/Products(5)/FactInternetSales
        [EnableQuery]
        public IQueryable<FactInternetSale> GetFactInternetSales([FromODataUri] int key)
        {
            return db.DimProducts.Where(m => m.ProductKey == key).SelectMany(m => m.FactInternetSales);
        }

        // GET: odata/Products(5)/FactProductInventories
        [EnableQuery]
        public IQueryable<FactProductInventory> GetFactProductInventories([FromODataUri] int key)
        {
            return db.DimProducts.Where(m => m.ProductKey == key).SelectMany(m => m.FactProductInventories);
        }

        // GET: odata/Products(5)/FactResellerSales
        [EnableQuery]
        public IQueryable<FactResellerSale> GetFactResellerSales([FromODataUri] int key)
        {
            return db.DimProducts.Where(m => m.ProductKey == key).SelectMany(m => m.FactResellerSales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DimProductExists(int key)
        {
            return db.DimProducts.Count(e => e.ProductKey == key) > 0;
        }
    }
}
