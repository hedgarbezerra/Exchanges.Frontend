using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hedgar.Exchanges.Frontend.MVC.Controllers
{
    //[Authorize]
    public class HomeController : BaseMVCController
    {
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }           
        }

        public ActionResult Exchanges()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                return RedirectToAction("Index");

            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                return RedirectToAction("Index");

            return View();
        }


        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            RemoveCookies();

            return RedirectToAction("Login");
        }
    }
}