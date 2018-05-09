using Altkom.EF.Shop.DbServices;
using Altkom.EF.Shop.IServices;
using Altkom.EF.Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.EF.Shop.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MetadataTest();

            AsyncAwaitResultTest();

            AsyncAwaitTest();

            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();

            NoTrackingAddTest();

            NoTrackingTest();

            UpdateOrderTest();

            UpdateCustomerTest();

            DistributedTransactionTest();

            DatabaseTransactionTest();

            GetManualTest();

            GetLazyOrderTest();

            GetProductTest();

            GetProductsTest();

            GetOrderTest();

            AddOrderTest();

            UpdateCustomerTest();

            GetCustomersTest();

            GetCustomerTest();

            AddCustomerTest();
        }

        private static void MetadataTest()
        {
            using (var context = new ShopContext())
            {
                var workspace = context.ObjectContext.MetadataWorkspace;

                var tables = workspace.GetItems<EntityType>(DataSpace.SSpace);

                foreach (var table in tables)
                {
                    Console.WriteLine(table.Name);
                    Console.WriteLine("===========");

                    foreach (var property in table.Properties)
                    {
                        var isPrimaryKey = table.KeyProperties.Contains(property);

                        if (isPrimaryKey)
                        {
                            Console.Write("PK ");
                        }

                        Console.WriteLine(property.Name);
                    }

                }


            }
        }

        private static async void AsyncAwaitResultTest()
        {
            var result1 = await CalculateAsync();

            var result2 = await CalculateAsync();

            var summary = result1 + result2;

            Console.WriteLine($"summary: {summary}");
        }

        private static async void AsyncAwaitTest()
        {
            //DoWorkAsync()
            //    .ContinueWith(task => Console.WriteLine("Next work"));

            await DoWorkAsync();

            await DoWorkAsync();

            await DoWorkAsync();

            await DoWorkAsync();

            await DoWorkAsync();

            await DoWorkAsync();

            await DoWorkAsync();

        }

        private static void DoWork()
        {
            Console.WriteLine($"Working... #{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine($"Done. #{Thread.CurrentThread.ManagedThreadId}");
        }

        private static Task DoWorkAsync()
        {
            return Task.Run(() => DoWork());
        }

        private static Task<decimal> CalculateAsync()
        {
            return Task.FromResult(Calculate());

            return Task.Run(() => Calculate());
        }

        private static decimal Calculate()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));

            return 100;
        }

        private static void NoTrackingAddTest()
        {
            var service = new Service { Name = "Rozwój oprogramowania" };

            IServicesService servicesService = new DbServicesService();
            servicesService.Add(service);
        }

        private static void NoTrackingTest()
        {
            IServicesService servicesService = new DbServicesService();
            var services = servicesService.Get();

            var service = services.First();

            service.Name = "Wymiana tonera";

            servicesService.Update(service);
        }

        private static void UpdateOrderTest()
        {
            IOrdersService ordersService = new DbOrdersService();

            var order = ordersService.Get(1);

            order.DeliveryDate = DateTime.Today.AddDays(14);

            ordersService.Update(order);
        }

        private static void DistributedTransactionTest()
        {
            var address = new Address
            {
                City = "Warszawa",
                PostCode = "01466",
                Street = "Chłodna"
            };

            var customer1 = new Customer
            {
                FirstName = "Marcin",
                LastName = "Sulecki",
                DeliveryAddress = address
            };

            var customer2 = new Customer
            {
                FirstName = "Kasia",
                LastName = "Sulecka",
                DeliveryAddress = address
            };

            ICustomersService customersService = new DbCustomersService();
            customersService.AddDistributed(customer1, customer2);
        }

        private static void DatabaseTransactionTest()
        {
            var address = new Address
            {
                City = "Warszawa",
                PostCode = "01466",
                Street = "Chłodna"
            };

            var customer1 = new Customer
            {
                FirstName = "Marcin",
                LastName = "Sulecki",
                DeliveryAddress = address
            };

            var customer2 = new Customer
            {
                FirstName = "Kasia",
                LastName = "Sulecka",
                DeliveryAddress = address
            };

            ICustomersService customersService = new DbCustomersService();
            customersService.Add(customer1, customer2);
        }

        private static void GetManualTest()
        {
            IOrdersService ordersService = new DbOrdersService();
            var order = ordersService.GetManual(1);
        }

        private static void GetLazyOrderTest()
        {
            IOrdersService ordersService = new DbOrdersService();
            var order = ordersService.GetLazy(1);
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

                customer.FirstName = "Kasia";

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
