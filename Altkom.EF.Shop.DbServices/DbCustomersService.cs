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
            throw new NotImplementedException();
        }

        public IList<Customer> Get()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
