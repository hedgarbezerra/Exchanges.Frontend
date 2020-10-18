using Hedgar.Exchanges.Frontend.Domain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Repository.Context.Configuration
{
    public class TickerConfiguration : BaseConfiguration<Ticker>
    {
        protected override void ConfigurateFields()
        {
            Property(p => p.Id)
                .HasColumnName("ID")
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(p => p.TickerId)
                .HasColumnName("TICKER_ID")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            Property(p => p.Name)
                .HasColumnName("TICKER_NAME")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

        }

        protected override void ConfigurateFK()
        {
        }

        protected override void ConfiguratePK()
        {
            HasKey(p => p.Id);
        }

        protected override void ConfigurateTableName()
        {
            ToTable("TB_TICKERS");
        }
    }
}
