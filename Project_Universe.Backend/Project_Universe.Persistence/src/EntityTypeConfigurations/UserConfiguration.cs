using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Universe.Domain.src.Entities;

namespace Project_Universe.Persistence.src.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(note => note.id_user);
            builder.HasIndex(note => note.id_user).IsUnique();
            builder.Property(note => note.user_name).HasMaxLength(20);
            builder.Property(note => note.user_password).HasMaxLength(20);
            builder.Property(note => note.id_staff).IsRequired();
        }
    }
}
