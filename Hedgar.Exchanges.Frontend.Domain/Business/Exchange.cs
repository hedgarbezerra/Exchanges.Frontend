using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Domain.Business
{
    public class Exchange
    {
        public int Id { get; set; }
        public string TickerFrom { get; set; }
        public string TickerTo { get; set; }
        public decimal Value { get; set; }
        public DateTime DtExchange { get; set; }
        public int UserId { get; set; }
    }
}
