using Hedgar.Exchanges.Frontend.Domain.DTO;
using Hedgar.Exchanges.Frontend.Services.API;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Services.Services
{
    public class CurrencyService
    {
        private readonly string _APIKey = ConfigurationManager.AppSettings["nomicsAPIKey"];
        private const string _baseUrl = "https://api.nomics.com/v1";

        public ICollection<Currency> GetCurrencies(string tickerIds = "")
        {
            var param = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrEmpty(tickerIds))
                param.Add(new KeyValuePair<string, string>("ids", tickerIds));

            var client = new RequestClient();

            var currencies = client.Get<List<Currency>>($"{_baseUrl}/currencies/ticker?key={_APIKey}&interval=0h", param);

            return currencies;
        }

        public ICollection<CurrencySparkline> GetCurrencySparklines(string start = "", string end = "", string ids = "")
        {
            var param = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrEmpty(ids))
                param.Add(new KeyValuePair<string, string>("ids", ids));

            if (string.IsNullOrEmpty(start))
                start = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd'T'HH:mm:ssZ");

            param.Add(new KeyValuePair<string, string>("start", start));

            if (!string.IsNullOrEmpty(end))
                param.Add(new KeyValuePair<string, string>("end", end));


            var client = new RequestClient();

            var sparklines = client.Get<List<CurrencySparkline>>($"{_baseUrl}/currencies/sparkline?key={_APIKey}", param);

            return sparklines;
        }
    }
}
