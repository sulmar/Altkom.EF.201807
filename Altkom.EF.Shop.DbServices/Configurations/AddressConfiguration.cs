using Altkom.EF.Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.EF.Shop.DbServices.Configurations
{
    class AddressConfiguration : ComplexTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            Property(p => p.PostCode)
                .IsUnicode(false)
                .HasMaxLength(5);

            Property(p => p.City)
                .HasMaxLength(100);

            Property(p => p.Street)
                .HasMaxLength(100);
        }
    }
}
