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
    builder.EntitySet<DimSalesTerritory>("SalesTerritories");
    builder.EntitySet<DimEmployee>("DimEmployees"); 
    builder.EntitySet<DimGeography>("DimGeographies"); 
    builder.EntitySet<FactInternetSale>("FactInternetSales"); 
    builder.EntitySet<FactResellerSale>("FactResellerSales"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class SalesTerritoriesController : ODataController
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // GET: odata/SalesTerritories
        [EnableQuery]
        public IQueryable<DimSalesTerritory> GetSalesTerritories()
        {
            return db.DimSalesTerritories;
        }

        // GET: odata/SalesTerritories(5)
        [EnableQuery]
        public SingleResult<DimSalesTerritory> GetDimSalesTerritory([FromODataUri] int key)
        {
            return SingleResult.Create(db.DimSalesTerritories.Where(dimSalesTerritory => dimSalesTerritory.SalesTerritoryKey == key));
        }

        // PUT: odata/SalesTerritories(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<DimSalesTerritory> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimSalesTerritory dimSalesTerritory = db.DimSalesTerritories.Find(key);
            if (dimSalesTerritory == null)
            {
                return NotFound();
            }

            patch.Put(dimSalesTerritory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimSalesTerritoryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimSalesTerritory);
        }

        // POST: odata/SalesTerritories
        public IHttpActionResult Post(DimSalesTerritory dimSalesTerritory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DimSalesTerritories.Add(dimSalesTerritory);
            db.SaveChanges();

            return Created(dimSalesTerritory);
        }

        // PATCH: odata/SalesTerritories(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<DimSalesTerritory> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DimSalesTerritory dimSalesTerritory = db.DimSalesTerritories.Find(key);
            if (dimSalesTerritory == null)
            {
                return NotFound();
            }

            patch.Patch(dimSalesTerritory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DimSalesTerritoryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dimSalesTerritory);
        }

        // DELETE: odata/SalesTerritories(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            DimSalesTerritory dimSalesTerritory = db.DimSalesTerritories.Find(key);
            if (dimSalesTerritory == null)
            {
                return NotFound();
            }

            db.DimSalesTerritories.Remove(dimSalesTerritory);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/SalesTerritories(5)/DimEmployees
        [EnableQuery]
        public IQueryable<DimEmployee> GetDimEmployees([FromODataUri] int key)
        {
            return db.DimSalesTerritories.Where(m => m.SalesTerritoryKey == key).SelectMany(m => m.DimEmployees);
        }

        // GET: odata/SalesTerritories(5)/DimGeographies
        [EnableQuery]
        public IQueryable<DimGeography> GetDimGeographies([FromODataUri] int key)
        {
            return db.DimSalesTerritories.Where(m => m.SalesTerritoryKey == key).SelectMany(m => m.DimGeographies);
        }

        // GET: odata/SalesTerritories(5)/FactInternetSales
        [EnableQuery]
        public IQueryable<FactInternetSale> GetFactInternetSales([FromODataUri] int key)
        {
            return db.DimSalesTerritories.Where(m => m.SalesTerritoryKey == key).SelectMany(m => m.FactInternetSales);
        }

        // GET: odata/SalesTerritories(5)/FactResellerSales
        [EnableQuery]
        public IQueryable<FactResellerSale> GetFactResellerSales([FromODataUri] int key)
        {
            return db.DimSalesTerritories.Where(m => m.SalesTerritoryKey == key).SelectMany(m => m.FactResellerSales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DimSalesTerritoryExists(int key)
        {
            return db.DimSalesTerritories.Count(e => e.SalesTerritoryKey == key) > 0;
        }
    }
}
