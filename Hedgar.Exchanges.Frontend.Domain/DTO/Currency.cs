using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Domain.DTO
{
    public class NomicsCurrencyData
    {
        public List<Currency> Currencies { get; set; }
    }

    public class Currency
    {
        public string id { get; set; }
        public string currency { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public string logo_url { get; set; }
        public string status { get; set; }
        public string price { get; set; }
        public DateTime price_date { get; set; }
        public DateTime price_timestamp { get; set; }
        public string circulating_supply { get; set; }
        public string max_supply { get; set; }
        public string market_cap { get; set; }
        public string num_exchanges { get; set; }
        public string num_pairs { get; set; }
        public DateTime first_candle { get; set; }
        public DateTime first_trade { get; set; }
        public DateTime first_order_book { get; set; }
        public string rank { get; set; }
        public string rank_delta { get; set; }
        public string high { get; set; }
        public DateTime high_timestamp { get; set; }
        public _1D _1d { get; set; }
        public _7D _7d { get; set; }
        public _30D _30d { get; set; }
        public _365D _365d { get; set; }
        public Ytd ytd { get; set; }
        public DateTime first_priced_at { get; set; }
    }

    public class _1D
    {
        public string volume { get; set; }
        public string price_change { get; set; }
        public string price_change_pct { get; set; }
        public string volume_change { get; set; }
        public string volume_change_pct { get; set; }
        public string market_cap_change { get; set; }
        public string market_cap_change_pct { get; set; }
    }

    public class _7D
    {
        public string volume { get; set; }
        public string price_change { get; set; }
        public string price_change_pct { get; set; }
        public string volume_change { get; set; }
        public string volume_change_pct { get; set; }
        public string market_cap_change { get; set; }
        public string market_cap_change_pct { get; set; }
    }

    public class _30D
    {
        public string volume { get; set; }
        public string price_change { get; set; }
        public string price_change_pct { get; set; }
        public string volume_change { get; set; }
        public string volume_change_pct { get; set; }
        public string market_cap_change { get; set; }
        public string market_cap_change_pct { get; set; }
    }

    public class _365D
    {
        public string volume { get; set; }
        public string price_change { get; set; }
        public string price_change_pct { get; set; }
        public string volume_change { get; set; }
        public string volume_change_pct { get; set; }
        public string market_cap_change { get; set; }
        public string market_cap_change_pct { get; set; }
    }

    public class Ytd
    {
        public string volume { get; set; }
        public string price_change { get; set; }
        public string price_change_pct { get; set; }
        public string volume_change { get; set; }
        public string volume_change_pct { get; set; }
        public string market_cap_change { get; set; }
        public string market_cap_change_pct { get; set; }
    }
}
