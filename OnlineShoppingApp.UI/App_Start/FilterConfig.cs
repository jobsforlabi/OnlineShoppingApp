using OnlineShoppingApp.UI.ControllerUtilities;
using OnlineShoppingApp.UI.ModelMetadata.Filters;
using System.Web.Mvc;

namespace OnlineShoppingApp.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new HandleExceptionFilter());
        }
    }
}
