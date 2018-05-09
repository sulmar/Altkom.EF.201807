using Altkom.EF.Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.EF.Shop.IServices
{
    public interface IServicesService
    {
        IList<Service> Get();

        void Add(Service service);

        void Update(Service service);

        Task<IList<Service>> GetAsync();

        Task AddAsync(Service service);

        
    }
}
