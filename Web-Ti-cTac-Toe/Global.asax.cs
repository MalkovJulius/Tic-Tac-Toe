using System.Data.Entity;
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
            //Database.SetInitializer(new GameDbInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            using (GameContext db = new GameContext())
            {            
                db.Games.Add(new Game { YouWin = true, MoveGame = "Some else steps" });
                db.SaveChanges();
            }
        }
    }

    //public static void Application_Button_Click()
    //{

    //}

    //в данном классе я не уверен
    public class GameDbInitializer : DropCreateDatabaseAlways<GameContext>
    {
        protected override void Seed(GameContext context)
        {
            context.Games.Add(new Game { YouWin = true, MoveGame = "some step of player" });
            base.Seed(context);
            context.SaveChanges();
        }
    }
}
