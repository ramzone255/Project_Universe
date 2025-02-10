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
    public class TaskConfiguration : IEntityTypeConfiguration<Domain.src.Entities.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.src.Entities.Task> builder)
        {
            builder.HasKey(note => note.id_task);
            builder.HasIndex(note => note.id_task).IsUnique();
            builder.Property(note => note.name_task).HasMaxLength(50);
            builder.Property(note => note.comment).HasMaxLength(250);
            builder.Property(note => note.id_status).IsRequired();
            builder.Property(note => note.id_priority).IsRequired();
        }
    }
}
