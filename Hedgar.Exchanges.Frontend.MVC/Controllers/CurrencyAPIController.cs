using Hedgar.Exchanges.Frontend.Domain.DTO;
using Hedgar.Exchanges.Frontend.MVC.Models;
using Hedgar.Exchanges.Frontend.Services.Services;
using LazyCache;
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
    public class CurrencyAPIController : ApiController
    {
        private int cacheExpirationHours = 0;
        private int cacheExpirationMinutes = 2;
        private int cacheExpirationSeconds = 0;

        [HttpGet]
        [Route("all")]
        public IHttpActionResult Curriencies(string ids = "")
        {
            try
            {
                IAppCache cache = new CachingService();

                var currencyService = new CurrencyService();
                Func<List<Currency>> getCurrenciesFunc = () => currencyService.GetCurrencies(ids).ToList();

                var cachedCurrencies = cache.GetOrAdd("currencies", getCurrenciesFunc, new TimeSpan(cacheExpirationHours, cacheExpirationMinutes, cacheExpirationSeconds));

                // return Ok(currencyService.GetCurrencies(ids));
                return Ok(cachedCurrencies);

            }
            catch (Exception ex)
            {
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
                IAppCache cache = new CachingService();

                var currencyService = new CurrencyService();
                Func<List<Currency>> getCurrenciesFunc = () => currencyService.GetCurrencies(ids).ToList();

                var cachedCurrencies = cache.GetOrAdd("currencies", getCurrenciesFunc, new TimeSpan(cacheExpirationHours, cacheExpirationMinutes, cacheExpirationSeconds));

                // return Ok(currencyService.GetCurrencies(ids));
                return Ok(cachedCurrencies);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
