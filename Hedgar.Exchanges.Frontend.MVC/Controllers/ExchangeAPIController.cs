using Hedgar.Exchanges.Frontend.Domain.Business;
using Hedgar.Exchanges.Frontend.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Hedgar.Exchanges.Frontend.MVC.Controllers
{
    [RoutePrefix("v1/api/exchanges")]
    [Authorize]
    public class ExchangeAPIController: BaseAPIController
    {
        [Route("list")]
        [HttpGet]
        public IHttpActionResult ListExchanges()
        {
            try
            {
                var service = new ExchangesService();
                var user = RequestContext.Principal.Identity.Name;

                var exchanges = service.GetExchanges(user);

                return Ok(new
                {
                    data = exchanges,
                    success = true,
                    message = $"Found {exchanges.Count} exchanges."
                });

            }
            catch (Exception ex)
            {
                LogException(ex);

                return InternalServerError(ex);
            }
        }

        [Route("save")]
        [HttpPost]
        public IHttpActionResult SaveExchange([FromBody]Exchange exchange)
        {
            try
            {
                var service = new ExchangesService();
                var userId = HttpContext.Current.User.Identity.Name;

                var posted = service.PostExchanges(exchange, userId);

                return Ok(new
                {
                    success = posted,
                    message = posted ? $"Exchanged your {exchange.TickerFrom} to {exchange.TickerTo} successfully" : "Something went wrong while exchanging."

                });
            }
            catch (Exception ex)
            {
                LogException(ex);

                return InternalServerError(ex);
            }
        }
    }
}