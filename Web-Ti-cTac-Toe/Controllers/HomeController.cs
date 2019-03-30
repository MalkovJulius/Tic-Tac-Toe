using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Web_Tic_Tac_Toe.Models;

namespace Web_Tic_Tac_Toe.Controllers
{
    public class HomeController : Controller
    {
        GameContext db = new GameContext();        

        public ActionResult Index()
        {                     
            ViewBag.DBGames = db.Games;
            ViewBag.DBPlayers = db.Players;
            return View(db.Games);            
        }
       
        public ActionResult RemoveTable()
        {
            //TODO: Fix it, always remove data id Data Base
            using (GameContext db = new GameContext())
            {                                   
                db.Games.RemoveRange(db.Games);
                db.Players.RemoveRange(db.Players);
                db.SaveChanges();
            }           
            return View("Index");
        }

        public ActionResult AddData(string value, int countStep)
        {
            string gameDescription=MessageDescription(countStep);            

            using (GameContext db = new GameContext())
            {
                db.Games.Add(new Game() { NameOfWinner=value, DescriptionGame=gameDescription });
                db.SaveChanges();
            }
            return View("Index");
        }

        private string MessageDescription(int countStep)
        {
            string description;
            switch (countStep)
            {
                case 3:
                    description = "It was a great game";
                    break;
                case 4:
                    description = "The game went well";
                    break;
                default:
                    description = "Hard game";
                    break;
            }
            return description;
        }
    }

    public class GameDbInitializer : DropCreateDatabaseIfModelChanges<GameContext>
    {
        protected override void Seed(GameContext context)
        {
            context.Games.Add(new Game { NameOfWinner = "Dead Heat", DescriptionGame = "it happens",  });
            context.Players.Add(new Player { Name="PC", SchoreWin=0, SchoreLose=0 });
            base.Seed(context);
            context.SaveChanges();
        }
    }
}