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
    builder.EntitySet<DimSalesReason>("SalesReasons");
    builder.EntitySet<FactInternetSale>("FactInternetSales"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class SalesReasonsController : ODataController
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // GET: odata/SalesReasons
        [EnableQuery]
        public IQueryable<DimSalesReason> GetSalesReasons()
        {
            return db.DimSalesReasons;
        }

        // GET: odata/SalesReasons(5)
        [EnableQuery]
        public SingleResult<DimSalesReason> GetDimSalesReason([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimSalesReasons.Where(dimSalesReason => dimSalesReason.SalesReasonKey == key));
        }

        // PUT: odata/SalesReasons(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<DimSalesReason> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimSalesReason dimSalesReason = db.DimSalesReasons.Find(key);
            if (dimSalesReason == null)
            {
                return NotFound();
            }

            patch.Put(dimSalesReason);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimSalesReasonExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimSalesReason);
        }

        // POST: odata/SalesReasons
        public IHttpActionResult Post(DimSalesReason dimSalesReason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DimSalesReasons.Add(dimSalesReason);
            db.SaveChanges();

            return Created(dimSalesReason);
        }

        // PATCH: odata/SalesReasons(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DimSalesReason> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimSalesReason dimSalesReason = db.DimSalesReasons.Find(key);
            if (dimSalesReason == null)
            {
                return NotFound();
            }

            patch.Patch(dimSalesReason);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimSalesReasonExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimSalesReason);
        }

        // DELETE: odata/SalesReasons(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DimSalesReason dimSalesReason = db.DimSalesReasons.Find(key);
            if (dimSalesReason == null)
            {
                return NotFound();
            }

            db.DimSalesReasons.Remove(dimSalesReason);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/SalesReasons(5)/FactInternetSales
        [EnableQuery]
        public IQueryable<FactInternetSale> GetFactInternetSales([FromODataUri] int key)
        {
            return db.DimSalesReasons.Where(m => m.SalesReasonKey == key).SelectMany(m => m.FactInternetSales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DimSalesReasonExists(int key)
        {
            return db.DimSalesReasons.Count(e => e.SalesReasonKey == key) > 0;
        }
    }
}
