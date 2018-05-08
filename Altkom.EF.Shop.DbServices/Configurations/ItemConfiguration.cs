using Altkom.EF.Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.EF.Shop.DbServices.Configurations
{
    class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            // Dostosowanie TPH
            this.Map<Product>(m => m.Requires("ItemType").HasValue("P"))
                .Map<Service>(m => m.Requires("ItemType").HasValue("S"))
               ;



        }
    }
}
