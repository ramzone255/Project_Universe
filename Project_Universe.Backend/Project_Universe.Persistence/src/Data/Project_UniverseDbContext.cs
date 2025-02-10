using Microsoft.EntityFrameworkCore;
using Project_Universe.Application.src.Interfaces;
using Project_Universe.Domain.src.Entities;
using Project_Universe.Persistence.src.EntityTypeConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Persistence.src.Data
{
    public class Project_UniverseDbContext : DbContext, IProject_UniverseDbContext
    {
        public DbSet<Contractor_Company> Contractor_Company { get; set; }
        public DbSet<Customer_Company> Customer_Company { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Priority> Priority { get; set; }
        public DbSet<Project_Task> Project_Task { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Task_Staff> Task_Staff { get; set; }
        public DbSet<Domain.src.Entities.Task> Task { get; set; }
        public DbSet<User> User { get; set; }
     
        public Project_UniverseDbContext(DbContextOptions<Project_UniverseDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new Contractor_CompanyConfiguration());
            builder.ApplyConfiguration(new Customer_CompanyConfiguration());
            builder.ApplyConfiguration(new PostConfiguration());
            builder.ApplyConfiguration(new PriorityConfiguration());
            builder.ApplyConfiguration(new Project_TaskConfiguration());
            builder.ApplyConfiguration(new ProjectConfiguration());
            builder.ApplyConfiguration(new StaffConfiguration());
            builder.ApplyConfiguration(new StatusConfiguration());
            builder.ApplyConfiguration(new Task_StaffConfiguration());
            builder.ApplyConfiguration(new TaskConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
