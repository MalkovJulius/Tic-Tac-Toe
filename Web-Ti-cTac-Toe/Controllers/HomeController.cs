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
            return View(db.Games);
        }

        //[System.Web.Services.WebMethod()]
        //[System.Web.Script.Services.ScriptMethod()]
        public ActionResult RemoveTable()
        {
            //TODO: Fix it, always remove data id Data Base
            using (GameContext db = new GameContext())
            {
                //context.Games.RemoveRange(context.Games);                    
                db.Games.RemoveRange(db.Games);
                db.SaveChanges();
            }
            //return View(db.Games);
            //return RedirectToAction("Index");
            return View("Index");
        }

        public ActionResult AddData()
        {
            using (GameContext db = new GameContext())
            {
                db.Games.Add(new Game() { YouWin=true, MoveGame="Set new Value" });
                db.SaveChanges();
            }
            return View("Index");
        }
    }
}