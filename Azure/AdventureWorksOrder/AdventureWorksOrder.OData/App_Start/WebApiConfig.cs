using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using AdventureWorksOrder.Model.Custom;

namespace AdventureWorksOrder.OData
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            config.Select().Expand().Filter().OrderBy().MaxTop(null).Count();

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<SalesOrderListItem>("Orders");
            var entity = builder.EntityType<SalesOrderListItem>()
                .HasKey(p => p.SalesOrderId);

            entity.Property(p => p.Customer);
            entity.Property(p => p.OrderDate);
            entity.Property(p => p.OrderNumber);
            entity.Property(p => p.SalesTerritoryId);

            entity.CamelCase();

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel())
                ;
        }
    }
}