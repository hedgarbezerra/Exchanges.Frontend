using Hedgar.Exchanges.Frontend.Domain.DTO;
using Hedgar.Exchanges.Frontend.Domain.Enumerators;
using Hedgar.Exchanges.Frontend.MVC.Models;
using Hedgar.Exchanges.Frontend.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hedgar.Exchanges.Frontend.MVC.Controllers
{
    [RoutePrefix("v1/api/currencies")]
    [Authorize]
    public class CurrencyAPIController : BaseAPIController
    {
        [HttpGet]
        [Route("list")]
        public IHttpActionResult Curriencies(string ids = "")
        {
            try
            {
                var currencyService = new CurrencyService();

                if (string.IsNullOrEmpty(ids))
                {
                    var enumList = Enum.GetValues(typeof(TickerEnumerator)).Cast<TickerEnumerator>().ToList();

                    ids = string.Join(",", enumList);
                }                    

                var currenciess =  currencyService.GetCurrencies(ids).ToList();

                return Ok(new
                {
                    success = true,
                    message = "Currencies listed successfuly",
                   data = currenciess
                });

            }
            catch (Exception ex)
            {
                LogException(ex);

                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("graph")]
        public IHttpActionResult CurrenciesGraph(string ids = "")
        {
            try
            {
                var currencyService = new CurrencyService();

                var start = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd'T'HH:mm:ssZ");
                var end = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ssZ");

                var sparkLine = currencyService.GetCurrencySparklines(ids, start, end).ToList();

                return Ok(new
                {
                    success = true,
                    message = "Currency sparkline listed successfuly",
                    data = sparkLine
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
