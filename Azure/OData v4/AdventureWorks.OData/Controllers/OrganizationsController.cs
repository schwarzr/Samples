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
    builder.EntitySet<DimOrganization>("Organizations");
    builder.EntitySet<DimCurrency>("DimCurrencies"); 
    builder.EntitySet<FactFinance>("FactFinances"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class OrganizationsController : ODataController
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // GET: odata/Organizations
        [EnableQuery]
        public IQueryable<DimOrganization> GetOrganizations()
        {
            return db.DimOrganizations;
        }

        // GET: odata/Organizations(5)
        [EnableQuery]
        public SingleResult<DimOrganization> GetDimOrganization([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimOrganizations.Where(dimOrganization => dimOrganization.OrganizationKey == key));
        }

        // PUT: odata/Organizations(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<DimOrganization> patch)
        {
            Validate(patch.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimOrganization dimOrganization = db.DimOrganizations.Find(key);
            if (dimOrganization == null)
            {
                return NotFound();
            }

            patch.Put(dimOrganization);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimOrganizationExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimOrganization);
        }

        // POST: odata/Organizations
        public IHttpActionResult Post(DimOrganization dimOrganization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DimOrganizations.Add(dimOrganization);
            db.SaveChanges();

            return Created(dimOrganization);
        }

        // PATCH: odata/Organizations(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DimOrganization> patch)
        {
            Validate(patch.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimOrganization dimOrganization = db.DimOrganizations.Find(key);
            if (dimOrganization == null)
            {
                return NotFound();
            }

            patch.Patch(dimOrganization);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimOrganizationExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimOrganization);
        }

        // DELETE: odata/Organizations(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DimOrganization dimOrganization = db.DimOrganizations.Find(key);
            if (dimOrganization == null)
            {
                return NotFound();
            }

            db.DimOrganizations.Remove(dimOrganization);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Organizations(5)/DimCurrency
        [EnableQuery]
        public SingleResult<DimCurrency> GetDimCurrency([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimOrganizations.Where(m => m.OrganizationKey == key).Select(m => m.DimCurrency));
        }

        // GET: odata/Organizations(5)/DimOrganization1
        [EnableQuery]
        public IQueryable<DimOrganization> GetDimOrganization1([FromODataUri] int key)
        {
            return db.DimOrganizations.Where(m => m.OrganizationKey == key).SelectMany(m => m.DimOrganization1);
        }

        // GET: odata/Organizations(5)/DimOrganization2
        [EnableQuery]
        public SingleResult<DimOrganization> GetDimOrganization2([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimOrganizations.Where(m => m.OrganizationKey == key).Select(m => m.DimOrganization2));
        }

        // GET: odata/Organizations(5)/FactFinances
        [EnableQuery]
        public IQueryable<FactFinance> GetFactFinances([FromODataUri] int key)
        {
            return db.DimOrganizations.Where(m => m.OrganizationKey == key).SelectMany(m => m.FactFinances);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DimOrganizationExists(int key)
        {
            return db.DimOrganizations.Count(e => e.OrganizationKey == key) > 0;
        }
    }
}
