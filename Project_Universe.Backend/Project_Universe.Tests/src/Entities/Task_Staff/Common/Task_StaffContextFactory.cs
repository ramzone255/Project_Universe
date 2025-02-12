using Microsoft.EntityFrameworkCore;
using Project_Universe.Persistence.src.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Task_Staff.Common
{
    public class Task_StaffContextFactory
    {
        public static int id_task_staff_for_delete = 3;
        public static int id_task_staff_for_update = 4;

        public static Project_UniverseDbContext Create()
        {
            var options = new DbContextOptionsBuilder<Project_UniverseDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new Project_UniverseDbContext(options);
            context.Database.EnsureCreated();
            context.Task_Staff.AddRange(
                new Domain.src.Entities.Task_Staff
                {
                    id_task_staff = 1,
                    id_task = null,
                    id_staff = 1
                },

                new Domain.src.Entities.Task_Staff
                {
                    id_task_staff = 2,
                    id_task = 2,
                    id_staff = 2
                },

                new Domain.src.Entities.Task_Staff
                {
                    id_task_staff = id_task_staff_for_delete,
                    id_task = null,
                    id_staff = 3
                },

                new Domain.src.Entities.Task_Staff
                {
                    id_task_staff = id_task_staff_for_update,
                    id_task = 4,
                    id_staff = null
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
