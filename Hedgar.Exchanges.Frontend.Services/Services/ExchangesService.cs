using Hedgar.Exchanges.Frontend.Domain.Business;
using Hedgar.Exchanges.Frontend.Repository.Context;
using Hedgar.Exchanges.Frontend.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Services.Services
{
    public class ExchangesService
    {
        private readonly ExchangeRepository repo;
        private readonly UserRepository userRepo;
        private DataContext _dbContext;
        public ExchangesService()
        {

            _dbContext = new DataContext();

            repo = new ExchangeRepository(_dbContext);
            userRepo = new UserRepository(_dbContext);
        }

        public List<Exchange> GetExchanges(string email)
        {
            var ctxUser = userRepo.ListarNoTracking(x => x.Email == email).FirstOrDefault();

            return repo.ListarNoTracking(x => x.UserId == ctxUser.Id).ToList();
        }

        public bool PostExchanges(Exchange exchange, string userEmail)
        {
            var userCtx = userRepo.ListarNoTracking(x => x.Email == userEmail).FirstOrDefault();

            exchange.DtExchange = DateTime.Now;
            exchange.UserId = userCtx.Id;

            repo.Inserir(exchange);

            var success = repo.Savechanges();

            return success > 0;
        }
    }
}
