using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Project_Universe.Domain.src.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Persistence.src.EntityTypeConfigurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(note => note.id_project);
            builder.HasIndex(note => note.id_project).IsUnique();
            builder.Property(note => note.name_project).HasMaxLength(50);
            builder.Property(note => note.id_contractor_company).IsRequired();
            builder.Property(note => note.id_customer_company).IsRequired();
            builder.Property(note => note.id_priority).IsRequired();
        }
    }
}
