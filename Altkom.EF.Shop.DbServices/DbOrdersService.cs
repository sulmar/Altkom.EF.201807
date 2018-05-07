using Altkom.EF.Shop.IServices;
using Altkom.EF.Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.EF.Shop.DbServices
{
    public class DbOrdersService : IOrdersService
    {
        private ShopContext context;

        public DbOrdersService()
        {
            context = new ShopContext();
        }

        public void Add(Order order)
        {
            context.Orders.Add(order);

            context.SaveChanges();
        }
    }
}
