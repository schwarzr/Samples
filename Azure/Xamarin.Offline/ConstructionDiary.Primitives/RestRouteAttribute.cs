using System;

namespace ConstructionDiary
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class RestRouteAttribute : Attribute
    {
        public RestRouteAttribute(string routePrefix)
        {
            RoutePrefix = routePrefix;
        }

        public string RoutePrefix { get; }
    }
}