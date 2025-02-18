using Microsoft.EntityFrameworkCore;
using Project_Universe.Persistence.src.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Project.Common
{
    public class ProjectContextFactory
    {
        public static int id_project_for_delete = 3;
        public static int id_project_for_update = 4;

        public static Project_UniverseDbContext Create()
        {
            var options = new DbContextOptionsBuilder<Project_UniverseDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new Project_UniverseDbContext(options);
            context.Database.EnsureCreated();
            context.Project.AddRange(
                new Domain.src.Entities.Project
                {
                    id_project = 1,
                    name_project = "Alfa",
                    start_date_project = DateTime.Now,
                    end_date_project = null,
                    id_contractor_company = 1,
                    id_customer_company = 1,
                    id_priority = 1
                },

                new Domain.src.Entities.Project
                {
                    id_project = 2,
                    name_project = "Omega",
                    start_date_project = DateTime.Now,
                    end_date_project = DateTime.Now,
                    id_contractor_company = 2,
                    id_customer_company = 2,
                    id_priority = 2
                },

                new Domain.src.Entities.Project
                {
                    id_project = id_project_for_delete,
                    name_project = "Sigma",
                    start_date_project = DateTime.Now,
                    end_date_project = DateTime.Now,
                    id_contractor_company = 3,
                    id_customer_company = 3,
                    id_priority = 3
                },

                new Domain.src.Entities.Project
                {
                    id_project = id_project_for_update,
                    name_project = "Beta",
                    start_date_project = DateTime.Now,
                    end_date_project = null,
                    id_contractor_company = 4,
                    id_customer_company = 4,
                    id_priority = 4
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(Project_UniverseDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
