using Microsoft.EntityFrameworkCore;
using Project_Universe.Persistence.src.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Staff.Common
{
    public class StaffContextFactory
    {
        public static int id_staff_for_delete = 3;
        public static int id_staff_for_update = 4;

        public static Project_UniverseDbContext Create()
        {
            var options = new DbContextOptionsBuilder<Project_UniverseDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new Project_UniverseDbContext(options);
            context.Database.EnsureCreated();
            context.Staff.AddRange(
                new Domain.src.Entities.Staff
                {
                    id_staff = 1,
                    name_staff = "Иван",
                    lastname_staff = "Иванов",
                    patronymic_staff = "Иванович",
                    email_staff = "ivanov@example.com",
                    id_post = 3
                },

                new Domain.src.Entities.Staff
                {
                    id_staff = 2,
                    name_staff = "Артем",
                    lastname_staff = "Артемов",
                    patronymic_staff = "Артемович",
                    email_staff = "artemov@example.com",
                    id_post = 3
                },

                new Domain.src.Entities.Staff

                {
                    id_staff = 3,
                    name_staff = "Владимир",
                    lastname_staff = "Владимиров",
                    patronymic_staff = "Владимирович",
                    email_staff = "vladimir@example.com",
                    id_post = 2
                },

                new Domain.src.Entities.Staff
                {
                    id_staff = 4,
                    name_staff = "Андрей",
                    lastname_staff = "Андреев",
                    patronymic_staff = "Андреевич",
                    email_staff = "andreev@example.com",
                    id_post = 1
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
