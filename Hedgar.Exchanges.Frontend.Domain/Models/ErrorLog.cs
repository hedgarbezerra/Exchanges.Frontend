using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Domain.Models
{
    public sealed class ErrorLog
    {
        public int Id { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionUrl { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionSource { get; set; }
        public string Parameters { get; set; }
        public DateTime DtHrErro { get; set; }
    }
}
