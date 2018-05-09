using Altkom.EF.Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.EF.Shop.IServices
{
    public interface ICustomersService : IDisposable
    {
        void Add(Customer customer);
        Customer Get(int id);
        IList<Customer> Get();
        void Update(Customer customer);
        void Remove(int id);

        void Add(Customer customer1, Customer customer2);
        void AddDistributed(Customer customer1, Customer customer2);
    }
}
