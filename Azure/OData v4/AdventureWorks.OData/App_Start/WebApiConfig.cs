using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Routing;
using System.Web.OData.Routing.Conventions;
using AdventureWorks.Model;

namespace AdventureWorks.OData
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            var currency = builder.EntitySet<DimCurrency>("Currencies");
            currency.EntityType.Ignore(p => p.FactCurrencyRates);

            var dates = builder.EntitySet<DimDate>("Dates");
            dates.EntityType.Ignore(p => p.FactCallCenters);
            dates.EntityType.Ignore(p => p.FactCurrencyRates);
            dates.EntityType.Ignore(p => p.FactFinances);
            dates.EntityType.Ignore(p => p.FactSalesQuotas);
            dates.EntityType.Ignore(p => p.FactSurveyResponses);

            var employee = builder.EntitySet<DimEmployee>("Employees");
            employee.EntityType.Ignore(p => p.FactSalesQuotas);

            builder.EntitySet<FactInternetSale>("InternetSales");

            var org = builder.EntitySet<DimOrganization>("Organizations");
            org.EntityType.Ignore(p => p.FactFinances);

            builder.EntitySet<DimProductCategory>("ProductCategories");
            builder.EntitySet<FactProductInventory>("ProductInventories");
            builder.EntitySet<DimProduct>("Products");
            builder.EntitySet<DimProductSubcategory>("ProductSubcategories");
            builder.EntitySet<DimPromotion>("Promotions");
            builder.EntitySet<FactResellerSale>("ResellerSales");
            builder.EntitySet<DimSalesTerritory>("SalesTerritories");

            var customer = builder.EntitySet<DimCustomer>("Customers");
            customer.EntityType.Ignore(p => p.FactSurveyResponses);

            builder.EntitySet<DimGeography>("Geographies");
            builder.EntitySet<DimReseller>("Resellers");
            builder.EntitySet<DimSalesReason>("SalesReasons");

            var function = builder.Function("SpecialReportSales");
            function.Parameter<int>("MaxAmount");
            function.ReturnsCollectionFromEntitySet<FactInternetSale>("InternetSales");

            config.AddODataQueryFilter();
            config.MapODataServiceRoute(
                "odata",
                "odata",
                builder.GetEdmModel());

            config.SetDefaultQuerySettings(new System.Web.OData.Query.DefaultQuerySettings
            {
                EnableCount = true,
                EnableExpand = true,
                EnableFilter = true,
                EnableOrderBy = true,
                EnableSelect = true,
                MaxTop = null
            });

            config.EnableDependencyInjection();
            config.EnsureInitialized();
        }
    }
}