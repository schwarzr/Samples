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
    builder.EntitySet<DimReseller>("Resellers");
    builder.EntitySet<DimGeography>("DimGeographies"); 
    builder.EntitySet<FactResellerSale>("FactResellerSales"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ResellersController : ODataController
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // GET: odata/Resellers
        [EnableQuery]
        public IQueryable<DimReseller> GetResellers()
        {
            return db.DimResellers;
        }

        // GET: odata/Resellers(5)
        [EnableQuery]
        public SingleResult<DimReseller> GetDimReseller([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimResellers.Where(dimReseller => dimReseller.ResellerKey == key));
        }

        // PUT: odata/Resellers(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<DimReseller> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimReseller dimReseller = db.DimResellers.Find(key);
            if (dimReseller == null)
            {
                return NotFound();
            }

            patch.Put(dimReseller);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimResellerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimReseller);
        }

        // POST: odata/Resellers
        public IHttpActionResult Post(DimReseller dimReseller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DimResellers.Add(dimReseller);
            db.SaveChanges();

            return Created(dimReseller);
        }

        // PATCH: odata/Resellers(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DimReseller> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimReseller dimReseller = db.DimResellers.Find(key);
            if (dimReseller == null)
            {
                return NotFound();
            }

            patch.Patch(dimReseller);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimResellerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimReseller);
        }

        // DELETE: odata/Resellers(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DimReseller dimReseller = db.DimResellers.Find(key);
            if (dimReseller == null)
            {
                return NotFound();
            }

            db.DimResellers.Remove(dimReseller);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Resellers(5)/DimGeography
        [EnableQuery]
        public SingleResult<DimGeography> GetDimGeography([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimResellers.Where(m => m.ResellerKey == key).Select(m => m.DimGeography));
        }

        // GET: odata/Resellers(5)/FactResellerSales
        [EnableQuery]
        public IQueryable<FactResellerSale> GetFactResellerSales([FromODataUri] int key)
        {
            return db.DimResellers.Where(m => m.ResellerKey == key).SelectMany(m => m.FactResellerSales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DimResellerExists(int key)
        {
            return db.DimResellers.Count(e => e.ResellerKey == key) > 0;
        }
    }
}
