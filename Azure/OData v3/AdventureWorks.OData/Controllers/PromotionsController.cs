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
    builder.EntitySet<DimPromotion>("Promotions");
    builder.EntitySet<FactInternetSale>("FactInternetSales"); 
    builder.EntitySet<FactResellerSale>("FactResellerSales"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PromotionsController : ODataController
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // GET: odata/Promotions
        [EnableQuery]
        public IQueryable<DimPromotion> GetPromotions()
        {
            return db.DimPromotions;
        }

        // GET: odata/Promotions(5)
        [EnableQuery]
        public SingleResult<DimPromotion> GetDimPromotion([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimPromotions.Where(dimPromotion => dimPromotion.PromotionKey == key));
        }

        // PUT: odata/Promotions(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<DimPromotion> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimPromotion dimPromotion = db.DimPromotions.Find(key);
            if (dimPromotion == null)
            {
                return NotFound();
            }

            patch.Put(dimPromotion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimPromotionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimPromotion);
        }

        // POST: odata/Promotions
        public IHttpActionResult Post(DimPromotion dimPromotion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DimPromotions.Add(dimPromotion);
            db.SaveChanges();

            return Created(dimPromotion);
        }

        // PATCH: odata/Promotions(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DimPromotion> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimPromotion dimPromotion = db.DimPromotions.Find(key);
            if (dimPromotion == null)
            {
                return NotFound();
            }

            patch.Patch(dimPromotion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimPromotionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimPromotion);
        }

        // DELETE: odata/Promotions(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DimPromotion dimPromotion = db.DimPromotions.Find(key);
            if (dimPromotion == null)
            {
                return NotFound();
            }

            db.DimPromotions.Remove(dimPromotion);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Promotions(5)/FactInternetSales
        [EnableQuery]
        public IQueryable<FactInternetSale> GetFactInternetSales([FromODataUri] int key)
        {
            return db.DimPromotions.Where(m => m.PromotionKey == key).SelectMany(m => m.FactInternetSales);
        }

        // GET: odata/Promotions(5)/FactResellerSales
        [EnableQuery]
        public IQueryable<FactResellerSale> GetFactResellerSales([FromODataUri] int key)
        {
            return db.DimPromotions.Where(m => m.PromotionKey == key).SelectMany(m => m.FactResellerSales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DimPromotionExists(int key)
        {
            return db.DimPromotions.Count(e => e.PromotionKey == key) > 0;
        }
    }
}
