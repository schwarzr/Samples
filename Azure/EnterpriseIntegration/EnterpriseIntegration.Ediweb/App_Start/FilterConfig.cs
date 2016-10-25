using System.Web;
using System.Web.Mvc;

namespace EnterpriseIntegration.Ediweb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
