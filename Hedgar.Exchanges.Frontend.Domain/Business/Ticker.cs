﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Domain.Business
{
    public class Ticker
    {
        public int Id { get; set; }
        public string TickerId { get; set; }
        public string Name { get; set; }
    }
}
