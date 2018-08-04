using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Web_Tic_Tac_Toe.Models;

namespace Web_Tic_Tac_Toe
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //я не уверен в данном решении
            Database.SetInitializer(new GameDbInitializer());

            using (GameContext db = new GameContext())
            {
                Game game = new Game()
                {                    
                    YouWin = true,
                    MoveGame = "some else step"
                };
                db.Games.Add(game);
                db.SaveChanges();
            }

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
