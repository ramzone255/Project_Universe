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
    public class Project_TaskConfiguration : IEntityTypeConfiguration<Project_Task>
    {
        public void Configure(EntityTypeBuilder<Project_Task> builder)
        {
            builder.HasKey(note => note.id_project_task);
            builder.HasIndex(note => note.id_project_task).IsUnique();
            builder.HasOne(note => note.Project)
                .WithMany(note => note.Project_Task)
                .HasForeignKey(note => note.id_project)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);
            builder.HasOne(note => note.Task)
                .WithMany(note => note.Project_Task)
                .HasForeignKey(note => note.id_task)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);
        }
    }
}
