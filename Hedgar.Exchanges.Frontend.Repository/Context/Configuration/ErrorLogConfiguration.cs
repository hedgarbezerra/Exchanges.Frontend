using Hedgar.Exchanges.Frontend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Repository.Context.Configuration
{
    internal class ErrorLogConfiguration : BaseConfiguration<ErrorLog>
    {
        protected override void ConfigurateFields()
        {
            Property(p => p.Id)
                .HasColumnName("ID")
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(p => p.ExceptionUrl)
                .HasColumnName("EXCEPTION_URL")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            Property(p => p.ExceptionMessage)
                .HasColumnName("EXCEPTION_MESSAGE")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            Property(p => p.ExceptionSource)
                .HasColumnName("EXCEPTION_SOURCE")
                .HasColumnType("VARCHAR");

            Property(p => p.ExceptionType)
                .HasColumnName("EXCEPTION_TYPE")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            Property(p => p.DtHrErro)
                .HasColumnName("EXCEPTION_DTHR")
                .HasColumnType("DATETIME")
                .IsRequired();
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
            ToTable("TB_LOG_ERRORS");
        }
    }
}
