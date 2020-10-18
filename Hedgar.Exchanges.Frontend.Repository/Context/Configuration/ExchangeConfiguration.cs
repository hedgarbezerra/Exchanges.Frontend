using Hedgar.Exchanges.Frontend.Domain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Repository.Context.Configuration
{
    internal class ExchangeConfiguration : BaseConfiguration<Exchange>
    {
        protected override void ConfigurateFields()
        {
            Property(p => p.Id)
                .HasColumnName("ID")
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(p => p.TickerFrom)
                .HasColumnName("TICKER_FROM")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            Property(p => p.TickerTo)
                .HasColumnName("TICKER_TO")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            Property(p => p.Value)
                .HasColumnName("EXCHANGE_VALUE")
                .HasColumnType("DECIMAL")
                .HasPrecision(19, 2)
                .IsOptional();

            Property(p => p.DtExchange)
                .HasColumnName("EXCHANGE_DT")
                .HasColumnType("DATETIME");

            Property(p => p.UserId)
                .HasColumnName("USERID")
                .HasColumnType("INT");
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
            ToTable("TB_EXCHANGES");
        }
    }
}
