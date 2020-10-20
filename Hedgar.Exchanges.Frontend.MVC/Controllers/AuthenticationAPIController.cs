using Hedgar.Exchanges.Frontend.Domain.Business;
using Hedgar.Exchanges.Frontend.Domain.DTO;
using Hedgar.Exchanges.Frontend.Services.Services;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace Hedgar.Exchanges.Frontend.MVC.Controllers
{
    [RoutePrefix("v1/api/authentication")]
    public class AuthenticationAPIController : ApiController
    {
        [HttpPost]
        [Route("signup")]
        public IHttpActionResult Signup([FromBody] User user)
        {
            try
            {

                var userService = new UserService();

                var signupSuccess = userService.SignUp(user);

                if (signupSuccess)
                {
                    var response = new 
                    {
                        message = "Sign up successfully.",
                        success = true
                    };


                    return Created(HttpContext.Current.Request.RawUrl, response);
                }
                else
                    return BadRequest("Something went wront while signing up.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login([FromBody] User user)
        {
            try
            {
                var userService = new UserService();
                User auhenticatedUser;

                var loginSuccess = userService.Login(user, out auhenticatedUser);

                if (loginSuccess)
                {
                    var userPreferences = userService.GetUserPreferences(auhenticatedUser.Exchanges);

                    WriteCookie("userpreference-tickerfrom", userPreferences.TickerFrom);
                    WriteCookie("userpreference-tickerto", userPreferences.TickerTo);
                    
                    FormsAuthentication.SetAuthCookie(auhenticatedUser.Email, true);

                    return Ok(new
                    {
                        success = true,
                        message = "Connected successfully."
                    });
                }
                else
                {
                    return Ok(new
                    {
                        success = false,
                        message = "E-mail or password are invalid."
                    });
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

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

        private void RemoveCookies()
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
