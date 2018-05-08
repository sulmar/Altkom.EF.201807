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
            GetProductTest();

            GetProductsTest();

            GetOrderTest();

            AddOrderTest();

            UpdateCustomerTest();

            GetCustomersTest();

            GetCustomerTest();

            

            AddCustomerTest();
        }

        private static void GetProductTest()
        {
            IProductsService productsService = new DbProductsService();
            var product = productsService.Get(1);
        }

        private static void GetProductsTest()
        {
            IProductsService productsService = new DbProductsService();
            var products = productsService.Get();
        }

        private static void GetOrderTest()
        {
            IOrdersService ordersService = new DbOrdersService();
            var order = ordersService.Get(1);
        }

        private static void UpdateCustomerTest()
        {
            using (ICustomersService customersService = new DbCustomersService())
            {
                var customer = customersService.Get(1);

                customer.FirstName = "Bartek";

                customersService.Update(customer);
            }
        }

        private static void GetCustomersTest()
        {
            using (ICustomersService customersService = new DbCustomersService())
            {
                var customers = customersService.Get();

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.FullName);
                }
            }
        }

        private static void GetCustomerTest()
        {
            ICustomersService customersService = new DbCustomersService();

            var customer = customersService.Get(1);

            Console.WriteLine(customer.FullName);
        }

        private static void AddOrderTest()
        {
            var address = new Address
            {
                City = "Warszawa",
                PostCode = "01466",
                Street = "Chłodna"
            };

            //var customer = new Customer
            //{
            //    FirstName = "Marcin",
            //    LastName = "Sulecki",
            //    DeliveryAddress = address,
            //    Birthday = DateTime.Now
            //};

            ICustomersService customersService = new DbCustomersService();
            var customer = customersService.Get(1);

            var product1 = new Product
            {
                Id = 1,
                Name = "Mysz",
                Color = "Red"
            };

            var service1 = new Service
            {
                Id = 2,
                Name = "Szkolenie EF"
            };

            var product2 = new Product
            {
                Id = 3,
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


            var od = new OrderDetail
            {
                Item = product2,
                Quantity = 5,
                UnitPrice = 200
            };

            order.Details.Add(od);

            order.Details.Add(od);

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
