using Hedgar.Exchanges.Frontend.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Services.Services
{
    public class UserService
    {
        private UserRepository repo;
        private ExchangeRepository exchangeRepo;

        public UserService()
        {
            repo = new UserRepository();
            exchangeRepo = new ExchangeRepository();
        }
    }

}
