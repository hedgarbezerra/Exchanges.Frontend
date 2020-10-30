using Hedgar.Exchanges.Frontend.Domain.Business;
using Hedgar.Exchanges.Frontend.Domain.DTO;
using Hedgar.Exchanges.Frontend.Domain.Enumerators;
using Hedgar.Exchanges.Frontend.Repository.Context;
using Hedgar.Exchanges.Frontend.Repository.Repositories;
using Hedgar.Exchanges.Frontend.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Services.Services
{
    public class UserService
    {
        private readonly UserRepository repo;
        private readonly ExchangeRepository exchangeRepo;
        private DataContext _dbContext;

        public UserService()
        {
            _dbContext = new DataContext();

            repo = new UserRepository(_dbContext);
            exchangeRepo = new ExchangeRepository(_dbContext);
        }

        public bool SignUp(User user)
        {
            var usersByEmail = repo.ListarNoTracking(x => x.Email == user.Email);

            if (usersByEmail.Any())
                throw new Exception("E-mail is already used in another account.");

            user.Password = Hashing.ComputeHash(user.Password);
            user.DtSignUp = DateTime.Now;

            repo.Inserir(user);

            var result = repo.Savechanges();

            return result > 0;
        }

        public bool Login(User user, out User outUser)
        {
            outUser = null;

            var ctxUser = repo.Listar(x => x.Email == user.Email).FirstOrDefault();

            if (ctxUser == null)
                return false;

            var passwordMatch = Hashing.VerifyHash(user.Password, ctxUser.Password);

            if (passwordMatch)
                outUser = ctxUser;

            return passwordMatch;

        }

        public UserPreferences GetUserPreferences(User user)
        {
            var ctxUser = repo.Listar(x => x.Email == user.Email).FirstOrDefault();

            var mostTickerFrom = ctxUser.Exchanges.Count > 0 ? ctxUser.Exchanges.GroupBy(i => i.TickerFrom).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First() : "";
            var mostTickerTo = ctxUser.Exchanges.Count > 0 ? ctxUser.Exchanges.GroupBy(i => i.TickerTo).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First() : "";

            return new UserPreferences
            {
                TickerFrom = mostTickerFrom,
                TickerTo = mostTickerTo
            };
        }

        public UserPreferences GetUserPreferences(List<Exchange> exchanges)
        {
            var mostTickerFrom = exchanges.Count > 0 ? exchanges.GroupBy(i => i.TickerFrom).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First() : "";
            var mostTickerTo = exchanges.Count > 0 ?  exchanges.GroupBy(i => i.TickerTo).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First() : "";

            return new UserPreferences
            {
                TickerFrom = mostTickerFrom,
                TickerTo = mostTickerTo
            };
        }
    }
}
