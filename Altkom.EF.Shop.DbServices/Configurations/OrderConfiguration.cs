using Altkom.EF.Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.EF.Shop.DbServices.Configurations
{
    class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            Property(p => p.DateOrder).HasColumnType("datetime2");

            Property(p => p.RowVersion)
                .IsConcurrencyToken()
                .IsRowVersion();
        }
    }
}
