using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hedgar.Exchanges.Frontend.MVC.Controllers
{
    public class BaseMVCController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
        protected void WriteCookie(string cookieName, string value)
        {
            var exp = new TimeSpan(0, 12, 0, 0);

            var cookie = new HttpCookie(cookieName)
            {
                Value = value,
                Expires = DateTime.Now + exp
            };

            Response.Cookies.Add(cookie);
        }

        protected void RemoveCookies()
        {
            string[] allDomainCookes = HttpContext.Request.Cookies.AllKeys;

            foreach (string domainCookie in allDomainCookes)
            {
                var expiredCookie = new HttpCookie(domainCookie)
                {
                    Expires = DateTime.Now.AddDays(-7),
                };
                HttpContext.Response.Cookies.Add(expiredCookie);
            }
            HttpContext.Request.Cookies.Clear();
        }
    }
}