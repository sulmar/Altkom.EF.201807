using Altkom.EF.Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.EF.Shop.IServices
{
    public interface IOrdersService
    {
        void Add(Order order);
    }
}
