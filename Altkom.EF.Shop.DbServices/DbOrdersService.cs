using Altkom.EF.Shop.IServices;
using Altkom.EF.Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

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

        public Order GetLazy(int id)
        {
            var order = context.Orders
                .SingleOrDefault(p => p.Id == id);

            Console.WriteLine(order.Customer.FirstName);
            return order;
        }

        public Order GetManual(int id)
        {
            var order = context.Orders
               .SingleOrDefault(p => p.Id == id);

            // TODO: ...

            // Explicit loading

            // pobranie pojedynczego obiektu
            context.Entry(order)
                .Reference(p => p.Customer)
                .Load();

            // pobranie kolekcji
            context.Entry(order)
                .Collection(p => p.Details)
                .Load();

            return order;
        }

        public void Update(Order order)
        {
            context.Entry(order).State = EntityState.Modified;

            try
            {
                context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {

            }
            
        }
    }
}
