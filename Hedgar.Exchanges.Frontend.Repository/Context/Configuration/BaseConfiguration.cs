using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Repository.Context.Configuration
{
    public abstract class BaseConfiguration<T> : EntityTypeConfiguration<T>
         where T : class
    {
        public BaseConfiguration()
        {
            ConfigurateTableName();
            ConfiguratePK();
            ConfigurateFields();
            ConfigurateFK();
        }
        protected abstract void ConfigurateFields();

        protected abstract void ConfigurateFK();

        protected abstract void ConfiguratePK();

        protected abstract void ConfigurateTableName();
    }
}
