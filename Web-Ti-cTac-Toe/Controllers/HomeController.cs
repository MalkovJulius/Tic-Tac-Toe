using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.UI.WebControls;
using Web_Tic_Tac_Toe.Models;
using System.Linq;
using Newtonsoft.Json;

namespace Web_Tic_Tac_Toe.Controllers
{
    public class HomeController : Controller
    {
        GameContext db = new GameContext();        

        public ActionResult Index()
        {                     
            ViewBag.DBGames = db.Games;
            ViewBag.DBPlayers = db.Players;
            return View(/*db.Games*/);            
        }    

        [WebMethod]
        public void RemoveTable()
        {            
            using (GameContext db = new GameContext())
            {                                   
                db.Games.RemoveRange(db.Games);
                db.Players.RemoveRange(db.Players);
                NotEmptyTable(db);
                db.SaveChanges();                
            }                
        }

        public static void NotEmptyTable(GameContext db)
        {
            db.Games.Add(new Game {
                GameId = 1,
                NameOfWinner = "Dead Heat",
                DescriptionGame = "it happens",
                Player = new Player { PlayerId = 1, Name = "PC", SchoreWin = 0, SchoreLose = 0 }
            });
            //db.Players.Add(new Player { PlayerId = 1, Name = "PC", SchoreWin = 0, SchoreLose = 0 });
        }

        [WebMethod]               
        public void AddData(string nameWin, int countStep)
        {
            if ((nameWin == null)&&(countStep==0)) throw new ArgumentNullException("Js function set null value");
            else
            {
                using (GameContext db = new GameContext())
                {
                    Player player;
                    if (nameWin == "PC") {
                        player = db.Players.FirstOrDefault(p => p.Name == "PC");
                        player.SchoreWin++;
                        //TODO: SchoreLose++ at loser Player. If Player not exist add him
                    }
                    else
                    {
                        //TODO: Find Player end change score
                        //TODO: If player do not exist add him
                    } 

                    db.Games.Add(new Game()
                    {
                        NameOfWinner = nameWin,
                        DescriptionGame = MessageDescription(countStep),  
                        Player = new Player { Name = nameWin, SchoreWin = 1 }
                    });
                    db.SaveChanges();                    
                }
            }           
        }

        private string MessageDescription(int countStep)
        {            
            switch (countStep)
            {
                case 3:
                    return "It was a great game";                   
                case 4:
                    return "The game went well";                   
                default:
                    return "Hard game";                   
            }            
        }


        private void AddUserInData(GameContext db)
        {           
                //TODO: find first Player with name== nameWin, if not found create new Player             
        }

        //TODO: not display BackEnd?
        [WebMethod]
        public ActionResult ShowScore()
        {            
            using (GameContext db = new GameContext())
            {
                var winersOfPlayer = from p in db.Players where p.Name != "PC" select p;
                int winsPlayer=0;
                foreach (Player pl in winersOfPlayer)
                {
                    winsPlayer += pl.SchoreWin;
                }
                //пусть берётся значение побед людей из PC ScoreLose
                var winsPC = db.Players.FirstOrDefault(p => p.Name == "PC").SchoreWin;
                var score = new { winPl = winsPlayer, winPC = winsPC };                
                return Json(score, JsonRequestBehavior.AllowGet);
            }                        
        }
    }

    public class GameDbInitializer : DropCreateDatabaseIfModelChanges<GameContext>
    {
        protected override void Seed(GameContext context)
        {            
            HomeController.NotEmptyTable(context);
            base.Seed(context);
            context.SaveChanges();
        }
    }
}