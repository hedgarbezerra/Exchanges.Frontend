using Hedgar.Exchanges.Frontend.Domain.Models;
using Hedgar.Exchanges.Frontend.Services.Services;
using System;
using System.Web;
using System.Web.Http;

namespace Hedgar.Exchanges.Frontend.MVC.Controllers
{
    public class BaseAPIController : ApiController
    {
        protected void LogException(Exception ex)
        {
            var errorService = new ErrorLogService();

            errorService.FazerLog(new ErrorLog
            {
                DtHrErro = DateTime.Now,
                ExceptionMessage = ex.Message,
                ExceptionSource = ex.StackTrace,
                ExceptionType = ex.GetType().FullName,
                ExceptionUrl = HttpContext.Current.Request.Url.AbsoluteUri
            });
        }
        protected void WriteCookie(string cookieName, string value)
        {
            var exp = new TimeSpan(0, 12, 0, 0);

            var cookie = new HttpCookie(cookieName)
            {
                Value = value,
                Expires = DateTime.Now + exp
            };

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        protected void RemoveCookies()
        {
            string[] allDomainCookes = HttpContext.Current.Request.Cookies.AllKeys;

            foreach (string domainCookie in allDomainCookes)
            {
                var expiredCookie = new HttpCookie(domainCookie)
                {
                    Expires = DateTime.Now.AddDays(-7),
                };
                HttpContext.Current.Response.Cookies.Add(expiredCookie);
            }
            HttpContext.Current.Request.Cookies.Clear();
        }
    }
}
