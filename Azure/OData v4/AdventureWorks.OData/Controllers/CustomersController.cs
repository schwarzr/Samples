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
    builder.EntitySet<DimCustomer>("Customers");
    builder.EntitySet<DimGeography>("DimGeographies"); 
    builder.EntitySet<FactInternetSale>("FactInternetSales"); 
    builder.EntitySet<FactSurveyResponse>("FactSurveyResponses"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CustomersController : ODataController
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // GET: odata/Customers
        [EnableQuery]
        public IQueryable<DimCustomer> GetCustomers()
        {
            return db.DimCustomers;
        }

        // GET: odata/Customers(5)
        [EnableQuery]
        public SingleResult<DimCustomer> GetDimCustomer([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimCustomers.Where(dimCustomer => dimCustomer.CustomerKey == key));
        }

        // PUT: odata/Customers(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<DimCustomer> patch)
        {
            Validate(patch.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimCustomer dimCustomer = db.DimCustomers.Find(key);
            if (dimCustomer == null)
            {
                return NotFound();
            }

            patch.Put(dimCustomer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimCustomerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimCustomer);
        }

        // POST: odata/Customers
        public IHttpActionResult Post(DimCustomer dimCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DimCustomers.Add(dimCustomer);
            db.SaveChanges();

            return Created(dimCustomer);
        }

        // PATCH: odata/Customers(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DimCustomer> patch)
        {
            Validate(patch.GetInstance());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimCustomer dimCustomer = db.DimCustomers.Find(key);
            if (dimCustomer == null)
            {
                return NotFound();
            }

            patch.Patch(dimCustomer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimCustomerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimCustomer);
        }

        // DELETE: odata/Customers(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DimCustomer dimCustomer = db.DimCustomers.Find(key);
            if (dimCustomer == null)
            {
                return NotFound();
            }

            db.DimCustomers.Remove(dimCustomer);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Customers(5)/DimGeography
        [EnableQuery]
        public SingleResult<DimGeography> GetDimGeography([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimCustomers.Where(m => m.CustomerKey == key).Select(m => m.DimGeography));
        }

        // GET: odata/Customers(5)/FactInternetSales
        [EnableQuery]
        public IQueryable<FactInternetSale> GetFactInternetSales([FromODataUri] int key)
        {
            return db.DimCustomers.Where(m => m.CustomerKey == key).SelectMany(m => m.FactInternetSales);
        }

        // GET: odata/Customers(5)/FactSurveyResponses
        [EnableQuery]
        public IQueryable<FactSurveyResponse> GetFactSurveyResponses([FromODataUri] int key)
        {
            return db.DimCustomers.Where(m => m.CustomerKey == key).SelectMany(m => m.FactSurveyResponses);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DimCustomerExists(int key)
        {
            return db.DimCustomers.Count(e => e.CustomerKey == key) > 0;
        }
    }
}
