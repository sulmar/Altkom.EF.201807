using Altkom.EF.Shop.IServices;
using Altkom.EF.Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.EF.Shop.DbServices
{
    public class DbProductsService : IProductsService
    {
        private ShopContext context;

        public DbProductsService()
        {
            context = new ShopContext();
        }

        public IList<Product> Get()
        {
            // return context.Products.ToList();

            var sql = "select Id, Name, Color, CreateDate, ModifiedDate from dbo.Items where ItemType = 'P'";

            return context.Database.SqlQuery<Product>(sql).ToList();
        }

        public Product Get(int id)
        {
            SqlParameter idParameter = new SqlParameter("@Id", System.Data.SqlDbType.Int);
            idParameter.Value = id;

            var sql = "select Id, Name, Color, CreateDate, ModifiedDate from dbo.Items where ItemType = 'P' and Id = @id";

            return context.Database.SqlQuery<Product>(sql, idParameter).SingleOrDefault();

        }

        public void Remove(int id)
        {
            var sql = "uspDeleteProduct @Id";

            SqlParameter idParameter = new SqlParameter("@Id", System.Data.SqlDbType.Int);
            idParameter.Value = id;

            context.Database.ExecuteSqlCommand(sql, idParameter);
        }

        public void Update(Product product)
        {
            SqlParameter idParameter = new SqlParameter("@Id", System.Data.SqlDbType.Int);
            idParameter.Value = product.Id;

            SqlParameter colorParameter = new SqlParameter("@Color", System.Data.SqlDbType.NVarChar);
            colorParameter.Value = product.Color;

            var sql = "update dbo.Items SET Color=@Color WHERE Id = @Id";

            context.Database.ExecuteSqlCommand(sql, idParameter, colorParameter);
        }
    }
}
