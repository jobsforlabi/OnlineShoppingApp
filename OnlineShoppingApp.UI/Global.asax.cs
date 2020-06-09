using OnlineShoppingApp.UI.ModelMetadata;
using OnlineShoppingApp.UI.ModelMetadata.Filters;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace OnlineShoppingApp.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            System.Web.Mvc.ModelMetadataProviders.Current = new ExtensibleModelMetadataProvider(new IModelMetadataFilter[] 
                                                                        { 
                                                                            new LabelConventionFilter(),
                                                                            new ReadOnlyTemplateSelectorFilter(),
                                                                            new TextAreaByNameFilter(),
                                                                            new WatermarkConventionFilter(),
                                                                            new PasswordByNameConventionFilter()
                                                                        });
        }

        protected void Session_End()
        {
            FormsAuthentication.SignOut();
            Session.Remove("CurrentUser");
            Session.Abandon();
        }
    }
}
