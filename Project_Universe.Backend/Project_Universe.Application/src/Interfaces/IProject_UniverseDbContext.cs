using Microsoft.EntityFrameworkCore;
using Project_Universe.Domain.src.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Application.src.Interfaces
{
    public interface IProject_UniverseDbContext
    {
        DbSet<Contractor_Company> Contractor_Company {  get; set; }
        DbSet<Customer_Company> Customer_Company { get; set; }
        DbSet<Post> Post { get; set; }
        DbSet<Priority> Priority { get; set; }
        DbSet<Project_Task> Project_Task { get; set; }
        DbSet<Project> Project { get; set; }
        DbSet<Staff> Staff { get; set; }
        DbSet<Status> Status { get; set; }
        DbSet<Task_Staff> Task_Staff { get; set; }
        DbSet<Domain.src.Entities.Task> Task { get; set; }
        DbSet<User> User { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
