using Altkom.EF.Shop.IServices;
using Altkom.EF.Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.EF.Shop.DbServices
{
    public class DbServicesService : IServicesService
    {
        private readonly ShopContext context;

        public DbServicesService()
        {
            context = new ShopContext();
        }

       

        public IList<Service> Get()
        {
            // lokalne wyłączenie śledzenia obiektów
            return context.Services.AsNoTracking().ToList();

            // context.ChangeTracker.DetectChanges();
        }

        public void Add(Service service)
        {
            Console.WriteLine(context.Entry(service).State);

            context.Services.Attach(service);

            Console.WriteLine(context.Entry(service).State);

            // context.ObjectContext.Detach(service);

            context.Entry(service).State = System.Data.Entity.EntityState.Detached;

            Console.WriteLine(context.Entry(service).State);

            context.Services.Add(service);

            // context.Services.Attach(service);
            // context.Entry(service).State = System.Data.Entity.EntityState.Added;

            Console.WriteLine(context.Entry(service).State);

            context.SaveChanges();
        }

        public void Update(Service service)
        {
            Console.WriteLine(context.Entry(service).State);

            context.SaveChanges();
        }

        public async Task<IList<Service>> GetAsync()
        {
            return await context.Services.ToListAsync();
        }

        public async Task AddAsync(Service service)
        {
            context.Services.Add(service);

            await context.SaveChangesAsync();
        }

        public void AddSync(Service service)
        {
            AddAsync(service).Wait();
        }

        public IList<Service> GetSync()
        {
            return GetAsync().Result;
        }
    }
}
