using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Universe.Domain.src.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project_Universe.Persistence.src.EntityTypeConfigurations
{
    public class Contractor_CompanyConfiguration : IEntityTypeConfiguration<Contractor_Company>
    {
        public void Configure(EntityTypeBuilder<Contractor_Company> builder)
        {
            builder.HasKey(note => note.id_contractor_company);
            builder.HasIndex(note => note.id_contractor_company).IsUnique();
            builder.Property(note => note.name_contractor_company).HasMaxLength(50);
            builder.Property(note => note.description_contractor_company).HasMaxLength(250);
        }
    }
}
