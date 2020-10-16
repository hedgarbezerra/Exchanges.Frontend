using Hedgar.Exchanges.Frontend.Domain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Frontend.Repository.Context.Configuration
{
    public class ExampleConfiguration : BaseConfiguration<ExampleClass>
    {
        protected override void ConfigurateFields()
        {
            //Defines all fields and their properties in database

            Property(x => x.Id)
                .HasColumnName("Column name")
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }

        protected override void ConfigurateFK()
        {
            //Defines foreign keys
        }

        protected override void ConfiguratePK()
        {
            //Defines table primary key
            HasKey(x => x.Id);
        }

        protected override void ConfigurateTableName()
        {
            //Table name
            ToTable("table example");
        }
    }
}
