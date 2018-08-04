using System.Web;
using System.Web.Mvc;

namespace Web_Tic_Tac_Toe
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
