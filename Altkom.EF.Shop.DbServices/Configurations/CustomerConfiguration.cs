using Altkom.EF.Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.EF.Shop.DbServices.Configurations
{
    
    class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            // HasKey(p => p.Id);

            Property(p => p.FirstName)
                .HasMaxLength(50);

            Property(p=> p.LastName)
                .HasMaxLength(70)
                .IsRequired();
        }
    }
}
