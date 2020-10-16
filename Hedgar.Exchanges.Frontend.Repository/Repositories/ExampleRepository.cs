using Hedgar.Exchanges.Frontend.Domain.Business;
using Hedgar.Exchanges.Frontend.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Repository.Repositories
{
    public class ExampleRepository : BaseRepository<ExampleClass>
    {
        public ExampleRepository(DataContext context = null) : base(context)
        {
        }
    }
}
