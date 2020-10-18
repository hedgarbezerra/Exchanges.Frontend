using Hedgar.Exchanges.Frontend.MVC.Models;
using System.Web;
using System.Web.Mvc;

namespace Hedgar.Exchanges.Frontend.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomExceptionHandler());
        }
    }
}
