using Hedgar.Exchanges.Frontend.Domain.Business;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Repository.Repositories
{
    public class ExchangeRepository : BaseRepository<Exchange>
    {
        public ExchangeRepository(DbContext context = null) : base(context)
        {

        }
    }
}
