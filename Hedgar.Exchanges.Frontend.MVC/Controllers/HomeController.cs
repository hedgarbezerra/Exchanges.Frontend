using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hedgar.Exchanges.Frontend.MVC.Controllers
{
    public class HomeController : BaseMVCController
    {
        public ActionResult Index()
        {
            try
            {
                throw new Exception();
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}