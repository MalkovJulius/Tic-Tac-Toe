using System;
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


        public static MvcHtmlString BtnAddClick(int i, int j)
        {
            string cross = "Content/site/cross.png";            
            string circle = "Content/site/circle.png";            
            TagBuilder img = new TagBuilder("img");            
            img.MergeAttribute("src", cross);
            img.MergeAttribute("height", "30");
            img.MergeAttribute("width", "30");
            return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
        } 

        public static MvcHtmlString Image(int i, int j)             
        {
            string str = "Content/site/null.png";
            TagBuilder img = new TagBuilder("img");
            string tempName = i.ToString()+j.ToString();
            img.MergeAttribute("name", tempName);
            img.MergeAttribute("src", str);
            img.MergeAttribute("height", "30");
            img.MergeAttribute("width","30");            
            return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
        }

        protected void ButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;
        }
        /*public void AddCharacter()
        {
            int i = 1;
            int j = 1;
            string cross = "Content/site/cross.png";
            string circle = "Content/site/circle.png";
            string tempName = i.ToString() + j.ToString();
            if ()
            {

            }

        }*/
    }

}