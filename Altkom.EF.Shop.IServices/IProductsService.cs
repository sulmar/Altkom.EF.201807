﻿using Altkom.EF.Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.EF.Shop.IServices
{
    public interface IProductsService
    {
        IList<Product> Get();

        Product Get(int id);

        void Update(Product product);

        void Remove(int id);
    }
}
