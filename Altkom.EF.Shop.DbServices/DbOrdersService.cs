using Altkom.EF.Shop.IServices;
using Altkom.EF.Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

            if (order.Customer.Id != 0)
            {
                context.Entry(order.Customer).State = System.Data.Entity.EntityState.Unchanged;
            }

            foreach (var detail in order.Details)
            {
                if (detail.Item.Id != 0)
                {
                    context.Entry(detail.Item).State = System.Data.Entity.EntityState.Unchanged;
                }
            }

            var entities = context.ChangeTracker.Entries();

            context.SaveChanges();
        }

        public Order Get(int id)
        {
            var order = context.Orders
                .Include(p=> p.Customer) // hint: add using System.Data.Entity;              
                //.Include(p => p.Details)
                // .Include($"{nameof(Order.Details)}.{nameof(Item)}")
                .Include( p => p.Details.Select(d=>d.Item))
                .SingleOrDefault(p=>p.Id == id);

            return order;
        }
    }
}
