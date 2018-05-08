using Altkom.EF.Shop.IServices;
using Altkom.EF.Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.EF.Shop.DbServices
{
    public class DbCustomersService : ICustomersService
    {
        private ShopContext context;

        public DbCustomersService()
        {
           context = new ShopContext();
        }

        public IList<Customer> Get(string postcode)
        {
            throw new NotImplementedException();
        }

        public void Add(Customer customer)
        {
            context.Customers.Add(customer);

            context.SaveChanges();
        }

        public Customer Get(int id)
        {
            // return context.Customers.Find(id);

            return context.Customers.SingleOrDefault(c => c.Id == id);

            // return context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public IList<Customer> Get()
        {
            IQueryable<Customer> customers = context
                .Customers
                .Where(c => c.FirstName == "Marcin");

            customers = customers
                .OrderBy(c => c.Id)
                .Skip(1)
                .Take(2);

            return customers.ToList();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            Console.WriteLine(context.Entry(customer).State);

            // ustawiamy ręcznie stan obiektu
            // automatycznie wszystkie właściwości ustawiane są na IsModified
            // context.Entry(customer).State = System.Data.Entity.EntityState.Modified;

            // ustawia konkretne właściwości do zmodyfikowania
            // stan obiektu jest automatyczne ustawiany na Modified
            context.Entry(customer).Property(p => p.FirstName).IsModified = true;            

            Console.WriteLine(context.Entry(customer).State);

            var entities = context.ChangeTracker.Entries();

            context.SaveChanges();

        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
