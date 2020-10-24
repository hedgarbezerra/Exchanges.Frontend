using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Domain.DTO
{

    public class CurrencyRateData
    {        public string asset_id_base { get; set; }
        public List<CurrencyRate> rates { get; set; }
    }

    public class CurrencyRate
    {
        public DateTime time { get; set; }
        public string asset_id_quote { get; set; }
        public float rate { get; set; }
    }

}
