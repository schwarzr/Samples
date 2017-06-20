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
    builder.EntitySet<DimEmployee>("Employees");
    builder.EntitySet<DimSalesTerritory>("DimSalesTerritories"); 
    builder.EntitySet<FactResellerSale>("FactResellerSales"); 
    builder.EntitySet<FactSalesQuota>("FactSalesQuotas"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EmployeesController : ODataController
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // GET: odata/Employees
        [EnableQuery]
        public IQueryable<DimEmployee> GetEmployees()
        {
            return db.DimEmployees;
        }

        // GET: odata/Employees(5)
        [EnableQuery]
        public SingleResult<DimEmployee> GetDimEmployee([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimEmployees.Where(dimEmployee => dimEmployee.EmployeeKey == key));
        }

        // PUT: odata/Employees(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<DimEmployee> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimEmployee dimEmployee = db.DimEmployees.Find(key);
            if (dimEmployee == null)
            {
                return NotFound();
            }

            patch.Put(dimEmployee);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimEmployeeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimEmployee);
        }

        // POST: odata/Employees
        public IHttpActionResult Post(DimEmployee dimEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DimEmployees.Add(dimEmployee);
            db.SaveChanges();

            return Created(dimEmployee);
        }

        // PATCH: odata/Employees(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DimEmployee> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimEmployee dimEmployee = db.DimEmployees.Find(key);
            if (dimEmployee == null)
            {
                return NotFound();
            }

            patch.Patch(dimEmployee);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimEmployeeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimEmployee);
        }

        // DELETE: odata/Employees(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DimEmployee dimEmployee = db.DimEmployees.Find(key);
            if (dimEmployee == null)
            {
                return NotFound();
            }

            db.DimEmployees.Remove(dimEmployee);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Employees(5)/DimEmployee1
        [EnableQuery]
        public IQueryable<DimEmployee> GetDimEmployee1([FromODataUri] int key)
        {
            return db.DimEmployees.Where(m => m.EmployeeKey == key).SelectMany(m => m.DimEmployee1);
        }

        // GET: odata/Employees(5)/DimEmployee2
        [EnableQuery]
        public SingleResult<DimEmployee> GetDimEmployee2([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimEmployees.Where(m => m.EmployeeKey == key).Select(m => m.DimEmployee2));
        }

        // GET: odata/Employees(5)/DimSalesTerritory
        [EnableQuery]
        public SingleResult<DimSalesTerritory> GetDimSalesTerritory([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimEmployees.Where(m => m.EmployeeKey == key).Select(m => m.DimSalesTerritory));
        }

        // GET: odata/Employees(5)/FactResellerSales
        [EnableQuery]
        public IQueryable<FactResellerSale> GetFactResellerSales([FromODataUri] int key)
        {
            return db.DimEmployees.Where(m => m.EmployeeKey == key).SelectMany(m => m.FactResellerSales);
        }

        // GET: odata/Employees(5)/FactSalesQuotas
        [EnableQuery]
        public IQueryable<FactSalesQuota> GetFactSalesQuotas([FromODataUri] int key)
        {
            return db.DimEmployees.Where(m => m.EmployeeKey == key).SelectMany(m => m.FactSalesQuotas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DimEmployeeExists(int key)
        {
            return db.DimEmployees.Count(e => e.EmployeeKey == key) > 0;
        }
    }
}
