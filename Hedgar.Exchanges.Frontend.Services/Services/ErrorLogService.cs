using Hedgar.Exchanges.Frontend.Domain.Models;
using Hedgar.Exchanges.Frontend.Repository.Context;
using Hedgar.Exchanges.Frontend.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Services.Services
{
    public class ErrorLogService
    {
        private readonly ErrorLogRepository repo;
        private DataContext _dbContext;

        public ErrorLogService()
        {
            _dbContext = new DataContext();

            this.repo = new ErrorLogRepository(_dbContext);
        }

        public void FazerLog(ErrorLog error)
        {
            repo.Inserir(error);

            repo.Savechanges();
        }

        public List<ErrorLog> Listar(DateTime dtInicio, DateTime dtFim)
        {
            return repo.Listar(x => x.DtHrErro > dtInicio && x.DtHrErro < dtFim).ToList();
        }
        public List<ErrorLog> Listar(Expression<Func<ErrorLog, bool>> filtro = null)
        {
            return repo.Listar(filtro).ToList();
        }
    }
}
