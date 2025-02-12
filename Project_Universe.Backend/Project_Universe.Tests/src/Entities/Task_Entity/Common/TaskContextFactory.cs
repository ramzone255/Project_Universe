using Microsoft.EntityFrameworkCore;
using Project_Universe.Persistence.src.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Task_Entity.Common
{
    public class TaskContextFactory
    {
        public static int id_task_for_delete = 3;
        public static int id_task_for_update = 4;

        public static Project_UniverseDbContext Create()
        {
            var options = new DbContextOptionsBuilder<Project_UniverseDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new Project_UniverseDbContext(options);
            context.Database.EnsureCreated();
            context.Task.AddRange(
                new Domain.src.Entities.Task
                {
                    id_task = 1,
                    name_task = "Alfa",
                    comment = "AlfaCom",
                    id_priority = 1,
                    id_status = 1
                },

                new Domain.src.Entities.Task
                {
                    id_task = 2,
                    name_task = "Omega",
                    comment = "OmegaCom",
                    id_priority = 2,
                    id_status = 2
                },

                new Domain.src.Entities.Task
                {
                    id_task = id_task_for_delete,
                    name_task = "Beta",
                    comment = "BetaCom",
                    id_priority = 3,
                    id_status = 3
                },

                new Domain.src.Entities.Task
                {
                    id_task = id_task_for_update,
                    name_task = "Sigma",
                    comment = "SigmaCom",
                    id_priority = 4,
                    id_status = 4
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
