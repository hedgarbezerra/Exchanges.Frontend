using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Domain.DTO
{
    public class CurrencySparklineData
    {
        public List<CurrencySparkline> data { get; set; }
    }

    public class CurrencySparkline
    {
        public string currency { get; set; }
        public List<DateTime> timestamps { get; set; }
        public List<string> prices { get; set; }
    }

}
