﻿using Hedgar.Exchanges.Frontend.Domain.DTO;
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

                var sparkLine = currencyService.GetCurrencySparklines(start, end, ids).ToList();

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


        [Route("rates")]
        [HttpGet]
        public IHttpActionResult Rates(string id)
        {
            try
            {

                var currencyService = new CurrencyService();

                var exchangeRates = currencyService.GetAllCurrencyRates(id);

                return Ok(new
                {
                    data = exchangeRates,
                    success = true,
                    message = $"Currency exchange rate listed."
                });

            }
            catch (Exception ex)
            {
                LogException(ex);

                return InternalServerError(ex);
            }
        }

        [Route("specificrate")]
        [HttpGet]
        public IHttpActionResult SpecificRates(string idFrom, string idTo)
        {
            try
            {

                var currencyService = new CurrencyService();

                var exchangeRates = currencyService.GetSpecificCurrencyRates(idFrom, idTo);

                return Ok(new
                {
                    data = exchangeRates,
                    success = true,
                    message = $"Currency exchange rate listed."
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
