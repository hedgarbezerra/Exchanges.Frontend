using Hedgar.Exchanges.Frontend.Domain.Business;
using Hedgar.Exchanges.Frontend.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Services.Hedgar.Exchanges.Frontend.Services
{
    public class ExampleService
    {
        private ExampleRepository repo;

        public ExampleService()
        {
            repo = new ExampleRepository();
        }

        public void Add(ExampleClass example)
        {
            repo.Inserir(example);

            repo.Savechanges();
        }
    }
}
