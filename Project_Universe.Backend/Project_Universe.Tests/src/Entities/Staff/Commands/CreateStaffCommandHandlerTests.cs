using Microsoft.EntityFrameworkCore;
using Project_Universe.Application.src.Entities.Staff.Commands.CreateStaff;
using Project_Universe.Tests.src.Entities.Staff.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Staff.Commands
{
    public class CreateStaffCommandHandlerTests : StaffTestCommandBase
    {
        [Fact]
        public async Task CreateStaffCommandHandler_Success()
        {
            var handler = new CreateStaffCommandHandler(Context);
            var name_staff = "Ivan";
            var lastname_staff = "Ivanov";
            var patronymic_staff = "Ivanovich";
            var email_staff = "ivan@example.com";
            var id_post = 3;

            var id_staff = await handler.Handle(
                new CreateStaffCommand
                {
                    name_staff = name_staff,
                    lastname_staff = lastname_staff,
                    patronymic_staff = patronymic_staff,
                    email_staff = email_staff,
                    id_post = id_post
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Staff.SingleOrDefaultAsync(entity =>
               entity.id_staff == id_staff &&
               entity.name_staff == name_staff &&
               entity.lastname_staff == lastname_staff &&
               entity.patronymic_staff == patronymic_staff &&
               entity.email_staff == email_staff &&
               entity.id_post == id_post));
        }
    }
}
