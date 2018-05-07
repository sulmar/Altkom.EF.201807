using Altkom.EF.Shop.DbServices;
using Altkom.EF.Shop.IServices;
using Altkom.EF.Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.EF.Shop.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            AddOrderTest();

            AddCustomerTest();
        }

        private static void AddOrderTest()
        {
            var address = new Address
            {
                City = "Warszawa",
                PostCode = "01466",
                Street = "Chłodna"
            };

            var customer = new Customer
            {
                FirstName = "Marcin",
                LastName = "Sulecki",
                DeliveryAddress = address,
                Birthday = DateTime.Now
            };


            var product1 = new Product
            {
                Name = "Mysz",
                Color = "Red"
            };

            var service1 = new Service
            {
                Name = "Szkolenie EF"
            };

            var product2 = new Product
            {
                Name = "Klawiatura",
                Color = "Blue"
            };

            var order = new Order
            {
                Customer = customer,
                DateOrder = DateTime.Now,
            };

            order.Details.Add(new OrderDetail
            {
                Item = product1,
                Quantity = 3,
                UnitPrice = 99
            });

            order.Details.Add(new OrderDetail
            {
                Item = service1,
                Quantity = 5,
                UnitPrice = 100
            });

            order.Details.Add(new OrderDetail
            {
                Item = product2,
                Quantity = 5,
                UnitPrice = 200
            });


            IOrdersService ordersService = new DbOrdersService();
            ordersService.Add(order);
        }

        private static void AddCustomerTest()
        {
            var address = new Address
            {
                City = "Warszawa",
                PostCode = "01466",
                Street = "Chłodna"
            };

            var customer = new Customer
            {
                FirstName = "Marcin",
                LastName = "Sulecki",
                DeliveryAddress = address,
                Birthday = DateTime.Now
            };

            ICustomersService customersService = new DbCustomersService();
            customersService.Add(customer);

        }
    }
}
