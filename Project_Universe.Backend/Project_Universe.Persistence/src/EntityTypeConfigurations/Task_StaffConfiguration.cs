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
    public class Task_StaffConfiguration : IEntityTypeConfiguration<Task_Staff>
    {
        public void Configure(EntityTypeBuilder<Task_Staff> builder)
        {
            builder.HasKey(note => note.id_task_staff);
            builder.HasIndex(note => note.id_task_staff).IsUnique();
            builder.Property(note => note.id_staff);
            builder.Property(note => note.id_task);
        }
    }
}
