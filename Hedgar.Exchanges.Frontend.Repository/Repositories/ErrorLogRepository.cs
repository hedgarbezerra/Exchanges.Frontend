using Hedgar.Exchanges.Frontend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Repository.Repositories
{
    public class ErrorLogRepository : BaseRepository<ErrorLog>
    {
        public ErrorLogRepository(DbContext context = null) : base(context)
        {

        }
    }
}
