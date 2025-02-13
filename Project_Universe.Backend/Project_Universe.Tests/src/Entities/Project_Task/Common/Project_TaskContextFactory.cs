using Microsoft.EntityFrameworkCore;
using Project_Universe.Persistence.src.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Project_Task.Common
{
    public class Project_TaskContextFactory
    {
        public static int id_project_task_for_delete = 3;
        public static int id_project_task_for_update = 4;

        public static Project_UniverseDbContext Create()
        {
            var options = new DbContextOptionsBuilder<Project_UniverseDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new Project_UniverseDbContext(options);
            context.Database.EnsureCreated();
            context.Project_Task.AddRange(
                new Domain.src.Entities.Project_Task
                {
                    id_project_task = 1,
                    id_project = null,
                    id_task = 1
                },

                new Domain.src.Entities.Project_Task
                {
                    id_project_task = 2,
                    id_project = 2,
                    id_task = null
                },

                new Domain.src.Entities.Project_Task
                {
                    id_project_task = id_project_task_for_delete,
                    id_project = 3,
                    id_task = 3
                },

                new Domain.src.Entities.Project_Task
                {
                    id_project_task = id_project_task_for_update,
                    id_project = 4,
                    id_task = 4
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
