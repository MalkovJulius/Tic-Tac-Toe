using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Web_Tic_Tac_Toe.Controllers;
using Web_Tic_Tac_Toe.Models;

namespace Web_Tic_Tac_Toe
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //я не уверен в данном решении
            Database.SetInitializer(new GameDbInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
