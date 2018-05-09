using Altkom.EF.Shop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.EF.Shop.DbServices.Configurations
{
    
    class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            // HasKey(p => p.Id);

            Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsConcurrencyToken();

            Property(p=> p.LastName)
                .HasMaxLength(70)
                .IsRequired();


            // Dodanie indeksu
            Property(p => p.Birthday)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, 
                new IndexAnnotation(new IndexAttribute()));

            // Dodanie unikalnego indeksu
            Property(p => p.Pesel)
                .HasMaxLength(11)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute() { IsUnique = true }));

            //             this.MapToStoredProcedures();
        }
    }
}
