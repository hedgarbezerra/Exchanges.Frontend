using Hedgar.Exchanges.Frontend.Domain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Repository.Context.Configuration
{
    internal class UserConfiguration : BaseConfiguration<User>
    {
        protected override void ConfigurateFields()
        {
            Property(p => p.Id)
                .HasColumnName("ID")
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(p => p.Email)
                .HasColumnName("EMAIL")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            Property(p => p.Password)
                .HasColumnName("USERPASSWORD")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            Property(p => p.Name)
                .HasColumnName("USERNAME")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            Property(p => p.DtBirth)
                .HasColumnName("DT_BIRTH")
                .HasColumnType("DATETIME")
                .IsRequired();

            Property(p => p.DtSignUp)
                .HasColumnName("DT_REGISTER")
                .HasColumnType("DATETIME")
                .IsRequired();


        }

        protected override void ConfigurateFK()
        {
            HasMany(p => p.Exchanges).WithOptional();
        }

        protected override void ConfiguratePK()
        {
            HasKey(p => p.Id);
        }

        protected override void ConfigurateTableName()
        {
            ToTable("TB_USERS");
        }
    }
}
