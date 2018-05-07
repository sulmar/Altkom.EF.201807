using Altkom.EF.Shop.DbServices.Configurations;
using Altkom.EF.Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.EF.Shop.DbServices
{
    public class ShopContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ShopContext()
            : base("ShopConnection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region konfiguracja bezpośrednio w kontekście

            //modelBuilder.Entity<Customer>()
            //    .HasKey(p => p.Id);

            //modelBuilder.Entity<Customer>()
            //    .Property(p => p.FirstName)
            //    .HasMaxLength(50);

            //modelBuilder.Entity<Customer>()
            //    .Property(p => p.LastName)
            //    .HasMaxLength(50)
            //    .IsRequired();

            //modelBuilder.ComplexType<Address>()
            //    .Property(p => p.PostCode)
            //    .IsUnicode(false)
            //    .HasMaxLength(5);

            //modelBuilder.ComplexType<Address>()
            //    .Property(p => p.City)
            //    .HasMaxLength(100);

            //modelBuilder.ComplexType<Address>()
            //    .Property(p => p.Street)
            //    .HasMaxLength(100);

            #endregion

            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
            base.OnModelCreating(modelBuilder);         
        }

    }
}
