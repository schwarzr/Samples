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
    builder.EntitySet<DimGeography>("Geographies");
    builder.EntitySet<DimCustomer>("DimCustomers"); 
    builder.EntitySet<DimReseller>("DimResellers"); 
    builder.EntitySet<DimSalesTerritory>("DimSalesTerritories"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class GeographiesController : ODataController
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // GET: odata/Geographies
        [EnableQuery]
        public IQueryable<DimGeography> GetGeographies()
        {
            return db.DimGeographies;
        }

        // GET: odata/Geographies(5)
        [EnableQuery]
        public SingleResult<DimGeography> GetDimGeography([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimGeographies.Where(dimGeography => dimGeography.GeographyKey == key));
        }

        // PUT: odata/Geographies(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<DimGeography> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimGeography dimGeography = db.DimGeographies.Find(key);
            if (dimGeography == null)
            {
                return NotFound();
            }

            patch.Put(dimGeography);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimGeographyExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimGeography);
        }

        // POST: odata/Geographies
        public IHttpActionResult Post(DimGeography dimGeography)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DimGeographies.Add(dimGeography);
            db.SaveChanges();

            return Created(dimGeography);
        }

        // PATCH: odata/Geographies(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DimGeography> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimGeography dimGeography = db.DimGeographies.Find(key);
            if (dimGeography == null)
            {
                return NotFound();
            }

            patch.Patch(dimGeography);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimGeographyExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimGeography);
        }

        // DELETE: odata/Geographies(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DimGeography dimGeography = db.DimGeographies.Find(key);
            if (dimGeography == null)
            {
                return NotFound();
            }

            db.DimGeographies.Remove(dimGeography);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Geographies(5)/DimCustomers
        [EnableQuery]
        public IQueryable<DimCustomer> GetDimCustomers([FromODataUri] int key)
        {
            return db.DimGeographies.Where(m => m.GeographyKey == key).SelectMany(m => m.DimCustomers);
        }

        // GET: odata/Geographies(5)/DimResellers
        [EnableQuery]
        public IQueryable<DimReseller> GetDimResellers([FromODataUri] int key)
        {
            return db.DimGeographies.Where(m => m.GeographyKey == key).SelectMany(m => m.DimResellers);
        }

        // GET: odata/Geographies(5)/DimSalesTerritory
        [EnableQuery]
        public SingleResult<DimSalesTerritory> GetDimSalesTerritory([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimGeographies.Where(m => m.GeographyKey == key).Select(m => m.DimSalesTerritory));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DimGeographyExists(int key)
        {
            return db.DimGeographies.Count(e => e.GeographyKey == key) > 0;
        }
    }
}
