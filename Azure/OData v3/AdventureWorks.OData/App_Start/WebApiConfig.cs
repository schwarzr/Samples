using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Routing;
using System.Web.Http.OData.Routing.Conventions;
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

            var conventions = ODataRoutingConventions.CreateDefault();
            conventions.Insert(0, new CompositeKeyRoutingConvention());

            config.AddODataQueryFilter();
            config.Routes.MapODataServiceRoute(
                "odata",
                "odata",
                builder.GetEdmModel(),
                new DefaultODataPathHandler(),
                conventions);
        }

        private class CompositeKeyRoutingConvention : EntityRoutingConvention
        {
            public override string SelectAction(System.Web.Http.OData.Routing.ODataPath odataPath, System.Web.Http.Controllers.HttpControllerContext controllerContext, ILookup<string, System.Web.Http.Controllers.HttpActionDescriptor> actionMap)
            {
                var action = base.SelectAction(odataPath, controllerContext, actionMap);
                if (action != null)
                {
                    var routeValues = controllerContext.RouteData.Values;
                    if (routeValues.ContainsKey(ODataRouteConstants.Key))
                    {
                        var keyRaw = routeValues[ODataRouteConstants.Key] as string;
                        IEnumerable<string> compoundKeyPairs = keyRaw.Split(',');
                        if (compoundKeyPairs == null || compoundKeyPairs.Count() == 0)
                        {
                            return action;
                        }

                        foreach (var compoundKeyPair in compoundKeyPairs)
                        {
                            string[] pair = compoundKeyPair.Split('=');
                            if (pair == null || pair.Length != 2)
                            {
                                continue;
                            }
                            var keyName = pair[0].Trim();
                            var keyValue = pair[1].Trim();

                            routeValues.Add(keyName, keyValue);
                        }
                    }
                }

                return action;
            }
        }
    }
}