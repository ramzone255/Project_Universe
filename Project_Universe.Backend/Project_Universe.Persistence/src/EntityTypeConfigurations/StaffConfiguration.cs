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
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(note => note.id_staff);
            builder.HasIndex(note => note.id_staff).IsUnique();
            builder.Property(note => note.name_staff).HasMaxLength(50);
            builder.Property(note => note.lastname_staff).HasMaxLength(50);
            builder.Property(note => note.patronymic_staff).HasMaxLength(50);
            builder.Property(note => note.email_staff).HasMaxLength(50);
            builder.HasOne(note => note.Post)
                .WithMany(note => note.Staff)
                .HasForeignKey(note => note.id_post)
                .IsRequired();
        }
    }
}
