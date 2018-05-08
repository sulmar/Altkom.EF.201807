using Altkom.EF.Shop.DbServices.Configurations;
using Altkom.EF.Shop.DbServices.Conventions;
using Altkom.EF.Shop.DbServices.Migrations;
using Altkom.EF.Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.EF.Shop.DbServices
{
    public class ShopContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public ShopContext()
            : base("ShopConnection")
        {
            // Zapewnia automatyczne aplikowanie migracji do najnowszej wersji
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopContext, Configuration>());

            this.ObjectContext.ObjectMaterialized += ObjectContext_ObjectMaterialized;

        }

        private void ObjectContext_ObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            
        }

        public ObjectContext ObjectContext => ((IObjectContextAdapter)this).ObjectContext;

        public override int SaveChanges()
        {
            SetCreateDate();
            SetModifiedDate();

            return base.SaveChanges();
        }

        private void SetModifiedDate()
        {
            this.ChangeTracker
                            .Entries<Base>()
                            .Where(e => e.State == EntityState.Modified)
                            .Select(e => e.Entity)
                            .ToList()
                            .ForEach(e => e.ModifiedDate = DateTime.Now);
        }

        private void SetCreateDate()
        {
            this.ChangeTracker
                .Entries<Base>()
                .Where(e => e.State == EntityState.Added)
                .Select(e => e.Entity)
                .ToList()
                .ForEach(e => e.CreateDate = DateTime.Now);
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
            modelBuilder.Configurations.Add(new ItemConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());

            modelBuilder.Conventions.Add(new DateTime2Convention());

            // TPT
            //modelBuilder.Entity<Product>().ToTable("Products");
            //modelBuilder.Entity<Service>().ToTable("Services");

            // TPC

            // modelBuilder.Entity<Product>().Map(m =>
            // {
            //     m.MapInheritedProperties();
            //     m.ToTable("Products");
            // });

            // modelBuilder.Entity<Item>().Property(p => p.Id)
            //     .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);


            // modelBuilder.Entity<Service>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("Services");
            //});

            base.OnModelCreating(modelBuilder);         
        }

    }
}
