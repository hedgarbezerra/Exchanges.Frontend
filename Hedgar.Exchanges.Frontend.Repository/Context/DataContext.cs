using Hedgar.Exchanges.Frontend.Domain.Business;
using Hedgar.Exchanges.Frontend.Domain.Models;
using Hedgar.Exchanges.Frontend.Repository.Context.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DbConnection")
        {
        }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Configurations.Add(new ErrorLogConfiguration());
            builder.Configurations.Add(new UserConfiguration());
            builder.Configurations.Add(new ExchangeConfiguration());
           // builder.Configurations.Add(new TickerConfiguration());
        }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        //public virtual DbSet<Ticker> Tickers { get; set; }
        public virtual DbSet<Exchange> Exchanges { get; set; }

    }
}
