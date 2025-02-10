using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_Universe.Domain.src.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Persistence.src.EntityTypeConfigurations
{
    public class Customer_CompanyConfiguration : IEntityTypeConfiguration<Customer_Company>
    {
        public void Configure(EntityTypeBuilder<Customer_Company> builder)
        {
            builder.HasKey(note => note.id_customer_company);
            builder.HasIndex(note => note.id_customer_company).IsUnique();
            builder.Property(note => note.name_customer_company).HasMaxLength(50);
            builder.Property(note => note.description_customer_company).HasMaxLength(250);
        }
    }
}
